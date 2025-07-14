using System.Text;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Azure abonelik anahtarı ve bölge bilgisi
        string subscriptionKey = "YOUR_SUBSCRIPTION_KEY_HERE";
        string region = "westeurope";

        // Token alma endpoint'i
        string tokenEndpoint = $"https://{region}.api.cognitive.microsoft.com/sts/v1.0/issuetoken";

        var token = await GetTokenAsync(subscriptionKey, tokenEndpoint);

        // Kullanıcıdan alınacak metin 
        // İngilizce Dil Örneği
        //string userText = "Hello World, this a test voice, I Hope this voice is work, thank for your listening and watching.";

        // Türkçe Dil Örneği
        string userText = "Merhaba arkadaşlar, bu bir deneme mesajıdır. Amacımız Microsoft Azure kullanarak metni ses dönüştürmektir. Umarım başarılı olabiliriz.";

        // Ses sentezleme fonksiyonuna token, bölge ve metin gönderilir
        await SynchesizeSpeechAsync(token, region, userText);
    }

    // Azure'dan authentication token'ı alır
    static async Task<string> GetTokenAsync(string key, string endpoint)
    {
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
        var response = await client.PostAsync(endpoint, null);
        return await response.Content.ReadAsStringAsync();
    }

    // Metni ses dosyasına çeviren asıl metot
    static async Task SynchesizeSpeechAsync(string token, string region, string text)
    {
        using var client = new HttpClient();

        // Azure token'ı authorization header'a eklenir
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        client.DefaultRequestHeaders.Add("User-Agent", "AZURETTSClient");

        // Çıkış formatı: WAV (16kHz, 16bit, mono)
        client.DefaultRequestHeaders.Add("X-Microsoft-OutputFormat", "riff-16khz-16bit-mono-pcm");

        // İngilizce seslendirme için SSML
        //string ssml = $@"<speak version='1.0' xml:lang='en-US'><voice xml:lang='en-US' name='en-US-JennyNeural'>{text}</voice></speak>";

        // Türkçe seslendirme için SSML
        string ssml = $@"<speak version='1.0' xml:lang='tr-TR'><voice xml:lang='tr-TR' name='tr-TR-AhmetNeural'>{text}</voice></speak>";

        // SSML içeriği HTTP body olarak gönderilir
        var content = new StringContent(ssml, Encoding.UTF8, "application/ssml+xml");

        // Ses sentezleme servisine istek gönderilir
        var result = await client.PostAsync($"https://{region}.tts.speech.microsoft.com/cognitiveservices/v1", content);

        if (result.IsSuccessStatusCode)
        {
            // Eğer başarıyla döndüyse, ses dosyası byte[] olarak alınır ve kaydedilir
            var audioBytes = await result.Content.ReadAsByteArrayAsync();

            // İngilizce Çıktı
            //File.WriteAllBytes("output.wav", audioBytes);
            File.WriteAllBytes("output2.wav", audioBytes);

            // Türkçe Çıktı
            //Console.WriteLine("Ses dosyası oluşturuldu: output.wav");
            Console.WriteLine("Ses dosyası oluşturuldu: output2.wav");
        }
        else
        {
            Console.WriteLine("Hata: " + result.StatusCode);
            Console.WriteLine(await result.Content.ReadAsStringAsync());
        }
    }
}