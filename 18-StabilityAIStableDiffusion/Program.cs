using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Konsol çıktı karakter kodlamasını UTF-8 olarak ayarlar (emoji ve özel karakterler için)
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🤖 Prompt'tan Görsel Üretici - Stability AI");
        Console.Write("Lütfen bir prompt giriniz: (örn: a wearing sunglasses on a beach): ");
        string prompt = Console.ReadLine();

        string apiKey = "YOUR_API_KEY_HERE";

        // Kullanmak istediğin modelin ID'si 
        string engineId = "stable-diffusion-v1-6";
        string apiUrl = $"https://api.stability.ai/v1/generation/{engineId}/text-to-image";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // İstek gövdesi (prompt, cfg_scale, görsel boyutu, adımlar vs.)
        var requestBody = new
        {
            // Üretilecek görselin tarifini içeren prompt alanı
            text_prompts = new[]
            {
                new { text = prompt }
            },

            // AI'in prompta ne kadar sadık kalacağını belirler (7–15 arası önerilir)
            cfg_scale = 12,

            // Görselin boyutu
            height = 512,
            width = 512,

            // Tek bir API çağrısında kaç görsel üretileceğini belirler
            samples = 1,

            // Görselin üretilme sürecindeki denoising (gürültü azaltma) adımlarının sayısı (daha fazla = daha kaliteli ama daha yavaş)
            steps = 30
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
        var response = await client.PostAsync(apiUrl, jsonContent);

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"Hata: {response.StatusCode}");
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine(error);
            return;
        }

        var responseString = await response.Content.ReadAsStringAsync();
        var responseJson = JsonDocument.Parse(responseString);

        // Üretilen görselin base64 formatında verisini alır
        string base64Image = responseJson
            .RootElement
            .GetProperty("artifacts")[0]
            .GetProperty("base64")
            .GetString();

        // Base64'ü byte dizisine dönüştürür
        byte[] imageBytes = Convert.FromBase64String(base64Image);

        // Dosya ismini oluştur (tarih-saat bilgisi içerir)
        string fileName = $"generated_{DateTime.Now:yyyyMMdd_HHmmss}.jpg";

        // Görseli diske yazar
        await File.WriteAllBytesAsync(fileName, imageBytes);

        Console.WriteLine($"✅ Görsel başarıyla oluşturuldu ve kaydedildi: {fileName}");
    }
}