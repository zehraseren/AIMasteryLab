using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";

        Console.Write("---------- Context Area ----------");
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Enter your context here: ");
        var context = Console.ReadLine();

        Console.WriteLine();
        Console.WriteLine();
        Console.Write("---------- Question Area ----------");
        Console.WriteLine();
        Console.WriteLine();

        Console.Write("Enter your question here: ");
        var question = Console.ReadLine();

        using (var client = new HttpClient())
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

            //  API'ye gönderilecek veriyi hazırlar (context + question)
            var requestBody = new
            {
                inputs = new
                {
                    question = question,
                    context = context
                }
            };

            // JSON’a dönüştür ve content tipi ile birlikte hazırlığa al
            var json = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://api-inference.huggingface.co/models/deepset/roberta-base-squad2", content);

            // Gelen cevabı metin (string) olarak okur
            var responseString = await response.Content.ReadAsStringAsync();

            // JSON yanıtı parse eder, “answer” isimli property varsa ekrana yazdırır
            var doc = JsonDocument.Parse(responseString);
            if (doc.RootElement.TryGetProperty("answer", out var answer))
            {
                // Kullanıcının verdiği metin
                Console.WriteLine();
                Console.WriteLine("Text: " + context);

                // Kullanıcının sorduğu soru
                Console.WriteLine();
                Console.WriteLine("Question: " + question);

                // Modelin bulduğu cevap
                Console.WriteLine();
                Console.WriteLine("Answer: " + answer.GetString());
            }
            else
            {
                Console.WriteLine("No answer found or model not yet available.");
                Console.WriteLine(responseString); // Detaylı hata çıktısı
            }
        }
    }

}