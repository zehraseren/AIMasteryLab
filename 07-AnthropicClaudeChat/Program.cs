using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";
        Console.Write("Lütfen sorunuzu yazınız: ");
        string prompt = Console.ReadLine();

        using var client = new HttpClient();

        // API isteklerinin gönderileceği temel adres (Base URL ayarlanır)
        client.BaseAddress = new Uri("https://api.anthropic.com");

        // "x-api-key" başlığı ile Claude API istek yapan kullanıcıyı tanır (kimliğini doğrular)
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);

        // Kullanılan Claude API versiyonu belirtilir
        // Bu versiyon, endpoint’in kabul edeceği formatı ve kuralları belirler
        client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");

        // Server'a gönderilen verinin tipi belirtilir
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // Claude modeline gönderilecek veri
        var requestBody = new
        {
            model = "claude-3-opus-20240229", // Kullanılan Claude modeli
            max_tokens = 1000, // Claude’un döndüreceği maksimum yanıt uzunluğu
            temperature = 0.7, // Yaratıcılık seviyesi
            messages = new[] // Sohbet geçmişi
            {
                new
                {
                    role="user",
                    content=prompt
                }
            }
        };

        var jsonContent = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

        var response = await client.PostAsync("v1/messages", jsonContent);
        var responseString = await response.Content.ReadAsStringAsync();
        Console.WriteLine("Cevap: ");
        Console.WriteLine(responseString);
    }
}