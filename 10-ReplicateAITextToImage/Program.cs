using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Kullanıcıdan metin (prompt) alınır
        Console.Write("Text to Image: ");
        string prompt = Console.ReadLine();

        // Replicate API Token'ı ve endpoint adresi
        string token = "YOUR_API_KEY_HERE";
        string apiUrl = "https://api.replicate.com/v1/predictions";

        var requestBody = new
        {
            // stable-diffusion 1.5 model versiyonu
            version = "7762fd07cf82c948538e41f63f77d685e02b063e37e496e96eef46c929f9bdc",
            input = new
            {
                prompt = prompt // Kullanıcının verdiği görsel tanımı
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("token", token);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        Console.WriteLine("Image creating...");

        var response = await client.PostAsync(apiUrl, content);
        string responseContent = await response.Content.ReadAsStringAsync();

        Console.WriteLine("API Yanıtı: ");
        Console.WriteLine(responseContent);
    }
}