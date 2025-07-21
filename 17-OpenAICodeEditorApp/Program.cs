using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Konsol çıktı karakter kodlamasını UTF-8 olarak ayarlar (emoji ve özel karakterler için)
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🤖 OpenAI Kod Asistanına Hoş Geldin\n");
        Console.WriteLine("Kodunuzu yazın ve aşağıdaki işlemlerden birini seçin\n");
        Console.WriteLine("1) Açıklama Üret");
        Console.WriteLine("2) Refactor Et");
        Console.WriteLine("3) Test Case Oluştur");

        Console.Write("\nSeçimin (1/2/3): ");
        var choice = Console.ReadLine();

        // Kullanıcıdan çok satırlı kod girişi al, "END" yazana kadar devam eder
        Console.WriteLine("\nKodunuzu Girin (bitirmek için 'END' yazın): ");

        StringBuilder userCode = new();

        string? line;
        while ((line = Console.ReadLine()) != null && line.Trim() != "END")
        {
            userCode.AppendLine(line);
        }

        // Kullanıcının seçimine göre OpenAI'ye gönderilecek promptlar
        string prompt = choice switch
        {
            "1" => $"Lütfen aşağıdaki C# kodunu açıklayıcı şekilde açıkla:\n\n{userCode}",
            "2" => $"Lütfen aşağıdaki C# kodunu daha temiz, okunabilir ve iyi şekilde refactor et:\n\n{userCode}",
            "3" => $"Lütfen aşağıdaki C# kodu için unit test case üret:\n\n{userCode}",
            _ => throw new ArgumentException("Geçersiz seçim")
        };

        var result = await AskOpenAI(prompt);
        Console.WriteLine("\n💭 OpenAI'ın Yanıtı: ");
        Console.WriteLine(result);
    }

    // OpenAI API'sine istek atıp sonucu dönen async metot
    static async Task<string> AskOpenAI(string prompt)
    {
        const string apiKey = "YOUR_API_KEY_HERE";
        const string endpoint = "https://api.openai.com/v1/chat/completions";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        var requestBody = new
        {
            model = "gpt-3.5-turbo",
            messages = new[]
            {
                new { role = "system", content = "Sen uzman bir C# yazılım geliştiricisisin. Kodları açıkla, düzelt veya test case üret." },
                new { role = "user", content = prompt }
            },
            temperature = 0.7
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync(endpoint, content);
            var responseJson = await response.Content.ReadAsStringAsync();

            // Debug için
            Console.WriteLine("OpenAI JSON yanıtı:\n" + responseJson);

            var doc = JsonDocument.Parse(responseJson);
            var root = doc.RootElement;

            // Eğer hata varsa
            if (root.TryGetProperty("error", out JsonElement error))
            {
                var message = error.GetProperty("message").GetString();
                return $"❌ OpenAI Hatası: {message}";
            }

            // Normal durum
            var answer = root.GetProperty("choices")[0]
                             .GetProperty("message")
                             .GetProperty("content")
                             .GetString();

            return answer.Trim();
        }
        catch (Exception ex)
        {
            return $"❌ Beklenmeyen Hata: {ex.Message}";
        }
    }
}