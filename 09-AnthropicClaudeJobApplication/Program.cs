using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";

        string prompt = "Bana 'Yazılım' geliştirici pozisyonu hazırlanan, profesyonel ama samimi tonda bir iş başvuru e-postası yazar mısın? Adım Zehra, 1 yıldır .NET geliştiriciyim, ekip çalışmasına yatkınım, uzaktan veya hibrit çalışmaya uygunum.";

        using var client = new HttpClient();
        client.BaseAddress = new Uri("https://api.anthropic.com/");
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        client.DefaultRequestHeaders.Add("anthropic-version", "2023-06-01");
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        var requestBody = new
        {
            model = "claude-3-opus-20240229",
            max_tokens = 1000,
            temperature = 0.5,
            messages = new[]
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

        // responseString Claude’dan dönen string (ham JSON) veri.
        var json = JsonNode.Parse(responseString);

        // json?["content"], JSON içindeki "content" adlı listeyi alır. ? sayesinde null olursa patlamaz
        // [0] ile listenin ilk elemanına ulaşılır (çünkü "content" bir array — liste)
        // ["text"], o ilk elemanın "text" adlı özelliğini çeker
        // .ToString(), sonuç olarak gelen JsonNode’u düz string formatına çevirir
        string? textContext = json?["content"]?[0]?["text"]?.ToString();

        Console.WriteLine("E-mail Örneği: ");
        Console.WriteLine(textContext);
    }
}