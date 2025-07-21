using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";

        // Kullanılacak Gemini modelinin adı
        string model = "gemini-1.5-pro";

        // Gemini API'nin generateContent metoduna yapılacak isteğin tam URL'i
        string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

        // Yapay zeka içerik planlayıcısının başlangıç rolü ve görevi tanımlanır
        string context = "Sen bir yapay zekan içerik planlayacısısın. Kullanıcının fikrine göre içerik üretmesine yardım edeceksin. Fikri aldıktan sonra kullanıcıya doğru soruları sorarak onu yönlendirecek ve sonunda içerik planını çıkaracaksın.";

        Console.Write("Bir fikrin var mı? (Örnek: Bir kafe açmak istiyorum): ");

        // Kullanıcının başlangıç fikrini okunur
        string userInput = Console.ReadLine();

        // Gemini'ye gönderilecek ilk prompt oluşturulur
        // Rol tanımı, kullanıcının fikri ve ilk soru sorma talimatı içerir
        string userPrompt = $"{context}\n\n Kullanıcının fikri: {userInput}\n\n Şimdi ona adım adım sorular sormaya başla.";

        // 5 tur boyunca karşılıklı soru-cevap döngüsü başlatılır
        for (int i = 0; i < 5; i++)
        {
            // Gemini'ye mevcut prompt'u göndererek bir sonraki soruyu alır
            string question = await SentToGemini(apiKey, endpoint, userPrompt);
            Console.WriteLine($"\nAgent: {question}");

            Console.Write("Sen: ");
            string answer = Console.ReadLine();

            // Mevcut prompt'a kullanıcının cevabını ve yeni bir soru sorma talimatını ekler
            // Bu, sohbet geçmişini koruyarak Gemini'nin bağlamı anlamasını sağlar
            userPrompt += $"\n\n Kullanıcının cevabı: {answer}\n\n Yeni sorunu sor.";
        }

        // 5 tur sonunda yeterli bilgiye ulaşıldığı varsayılarak, nihai içerik planını oluşturması için Gemini'ye talimat verilir
        string finalPrompt = $"{userPrompt}\n\n Artık yeterli bilgiye sahipsin. Kullanıcı için detaylı bir içerik planı oluştur.";

        // Nihai prompt'u Gemini'ye göndererek içerik planını alır
        string finalOutput = await SentToGemini(apiKey, endpoint, finalPrompt);

        Console.WriteLine($"\n Nihai İçerik Planı: \n {finalOutput}");
    }

    // Gemini API'ye istek göndermek ve yanıtı almak için yardımcı metot
    static async Task<string> SentToGemini(string apiKey, string endpoint, string prompt)
    {
        // API'ye gönderilecek istek gövdesi oluşturulur
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new
                        {
                            text = prompt
                        }
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

            // Gemini API yanıt yapısına göre cevaba ulaşılır, "candidates" dizisinin ilk elemanına, onun içindeki "content" nesnesine, onun içindeki "parts" dizisinin ilk elemanına ve son olarak "text" özelliğine erişilir
            return doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();
        }
        catch
        {
            return "Bir hata oluştu!";
        }
    }
}