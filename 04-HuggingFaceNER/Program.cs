using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var apiKey = "YOUR_API_KEY_HERE";
        Console.Write("Please input text here: ");
        var inputText = Console.ReadLine();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            var requestBody = new
            {
                inputs = inputText,
            };

            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Türkçe Dil Desteği
            var response = await client.PostAsync("https://api-inference.huggingface.co/models/savasy/bert-base-turkish-ner-cased", content);

            // İngilizce Dil Desteği
            //var response = await client.PostAsync("https://api-inference.huggingface.co/models/Jean-Baptiste/roberta-large-ner-english", content);
            var responseString = await response.Content.ReadAsStringAsync();

            Console.WriteLine("NER Output: ");
            Console.WriteLine(responseString);

            var doc = JsonDocument.Parse(responseString);
            foreach (var item in doc.RootElement.EnumerateArray())
            {
                string entity = item.GetProperty("entity_group").GetString();
                string word = item.GetProperty("word").GetString();
                double score = Math.Round(item.GetProperty("score").GetDouble() * 100, 2);
                Console.WriteLine($" -->  {word}");
                Console.WriteLine($"       |Type: {entity}");
                Console.WriteLine($"       |Score: {score}%");
            }
            ;
        }

    }
}