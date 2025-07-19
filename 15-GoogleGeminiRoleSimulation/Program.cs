using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "YOUR_API_KEY_HERE";

        // Kullanılacak Gemini modelinin adı.
        string model = "gemini-1.5-pro";

        // Gemini API'nin generateContent metoduna yapılacak isteğin tam URL'i
        string endpoint = $"https://generativelanguage.googleapis.com/v1beta/models/{model}:generateContent?key={apiKey}";

        // Kullanıcıya rol seçimi menüsü gösterilir
        Console.WriteLine("Rolünüzü seçiniz: ");
        Console.WriteLine("1) Psikolog");
        Console.WriteLine("2) Maç Yorumcusu");
        Console.WriteLine("3) Finansal Yatırım Uzmanı");
        Console.WriteLine("4) Tarihçi");
        Console.WriteLine("5) Turist Rehberi");
        Console.WriteLine();
        Console.Write("Seçiminiz: ");

        // Kullanıcının seçimine göre uygun rol açıklamasını belirler
        // 'switch' ifadesi ile farklı seçimlere farklı metinler atanır
        string roleChoice = Console.ReadLine();
        string rolePrompt = roleChoice switch
        {
            "1" => "Sen bir psikologsun. Danışanın sorularına empatik, açıklayıcı ve sakin bir dille yanıt ver.",
            "2" => "Sen bir maç yorumcususun. Sorulan soruya sanki maç başlamadan birkaç saat önce stada gitmiş gibi o atmosferi hisseden ve heyecanlandıran cevap ver.",
            "3" => "Sen bir finans yatırım danışmanısın. Kullanıcının bütçesine ve hedeflerine göre yatırım önerileri yap.",
            "4" => "Sen bir tarihçisin. Olayları bilimsel kaynaklara dayanarak detaylı olarak anlat.",
            "5" => "Sen bir turist rehberisin, sorulan soruya o şehri çok iyi bilen, o şehirde mutlaka görülmesi gereken ve yenilmesi gereken lezzetleri listleyerek yanıt ver.",
            _ => "Geçersiz rol seçimi."
        };

        Console.WriteLine();
        Console.Write("Sormak istediğiniz cümleyi giriniz: ");
        string userInput = Console.ReadLine();

        // Rol açıklaması ve kullanıcının sorusunu birleştirerek Gemini'ye gönderilecek nihai prompt'u oluşturur
        string finalPrompt = $"{rolePrompt}\n\n Kullanıcıdan Gelen Soru: {userInput}";

        // Gemini API'ye gönderilecek istek gövdesi (JSON formatında) oluşturulur
        // 'contents' altında bir dizi vardır, her bir eleman bir konuşma dönüşünü temsil eder
        // Burada sadece kullanıcının sorusu (rolePrompt ile birleştirilmiş hali) gönderilir
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
                            text = finalPrompt // Oluşturulan nihai prompt buraya yerleştirilir
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
            // Gelen JSON yanıtını ayrıştırır
            var doc = JsonDocument.Parse(responseText);

            // Gemini API yanıt yapısına göre cevaba ulaşılır
            // "candidates" dizisinin ilk elemanına, onun içindeki "content" nesnesine, onun içindeki "parts" dizisinin ilk elemanına ve son olarak "text" özelliğine erişilir
            string answer = doc.RootElement
                .GetProperty("candidates")[0]
                .GetProperty("content")
                .GetProperty("parts")[0]
                .GetProperty("text")
                .GetString();

            Console.WriteLine($"\nGemini Cevap: {answer}");
        }
        catch
        {
            Console.WriteLine($"\nYanıt Hatası: {responseText}");
            throw;
        }
    }
}