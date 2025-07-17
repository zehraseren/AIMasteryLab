using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";

        // Kullanmak istenilen Gemini modeli tanımlır
        string model = "gemini-1.5-pro";

        // Google Gemini API endpoint'i oluşturulur
        string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";
        Console.Write("Sormak istediğiniz soruyu yazın: ");
        string question = Console.ReadLine();

        // Google Gemini API'nin beklediği request formatında veriyi hazırlar
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = question } // Kullanıcının sorusunu "text" alanına yerleştirilir
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var response = await client.PostAsync(endpoint, content);
        var responseText = await response.Content.ReadAsStringAsync();

        try
        {
            var doc = JsonDocument.Parse(responseText);

            // Yanıtın içinde dönen metin alınır (Gemini'nin cevabı burada yer alır)
            string answer = doc.RootElement
                // Gemini API, her cevabı bu liste içinde "aday" olarak döner. Genelde tek elemanlı olur ama çoklu olabilir. [0] ile ilk cevabı alınır
                .GetProperty("candidates")[0]

                // "content" objesine geçilir, bu objede cevap parçalara bölünmüş olarak tutulur
                .GetProperty("content")

                // Cevabın ilk parçasını alınır, "parts" bir dizi olduğu için sıfırıncı indeksteki metin parçası cekilir
                .GetProperty("parts")[0]

                // Bu parça içindeki text alanı çekilir, sıl cevap burada saklıdır
                .GetProperty("text")
                .GetString();

            Console.WriteLine($"Gemini Cevap: {answer}");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Yanıt çözümlemesi başarısız oldu.");
            Console.WriteLine($"Gelen Yanıt: {responseText} {ex}");
            throw;
        }
    }
}