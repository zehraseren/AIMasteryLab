using System.Text;
using UglyToad.PdfPig;
using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Okunacak PDF dosyasının tam yolu
        string pdfPath = "YOUR_PATH_HERE";
        string apiKey = "YOUR_API_KEY_HERE";

        // Belirtilen PDF dosyası mevcut mu?
        if (!File.Exists(pdfPath))
        {
            Console.WriteLine("PDF dosyası bulunamadı!");
            return;
        }

        // PDF'deki tüm sayfalardan metin toplar
        string pdfText = "";

        //  PDF dosyası açılıyor ve sayfa sayfa işlenmeye hazır hâle getiriliyor
        // PdfPig kütüphanesiyle PDF içeriği okunur, metin çıkarımı yapılabilir
        using (var document = PdfDocument.Open(pdfPath))
        {
            foreach (var page in document.GetPages())
            {
                pdfText += page.Text + "\n"; // Her sayfa sonuna yeni satır karakteri
            }
        }

        // Claude için hazırlanacak prompt oluşturulur
        string prompt = $"Aşağıdaki metni detaylıca özetler misin?\n\n{pdfText}";

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
        Console.WriteLine("PDF Özeti: ");
        Console.WriteLine(responseString);
    }
}