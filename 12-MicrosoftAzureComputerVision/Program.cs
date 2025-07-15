using System.Text.Json;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Analiz edilecek görselin dosya yolu
        string imagePath = "YOUR_IMAGE_PATH_HERE";

        // Azure portalından alınan abonelik anahtarı
        string subscriptionKey = "YOUR_SUBSCRIPTION_KEY_HERE";

        // Azure Computer Vision hizmetine ait uç nokta (endpoint)
        string endpoint = "YOUR_ENDPOINT_HERE";

        // API adresi ve istenen parametrelerle birlikte URI oluşturulur
        string apiUrl = $"{endpoint}/vision/v3.2/analyze";
        string requestParameters = "visualFeatures=Categories,Description,Tags,Color&language=en&model-version=latest";
        string uri = $"{apiUrl}?{requestParameters}";

        // Görsel dosyasının varlığı kontrol edilir
        if (!File.Exists(imagePath))
        {
            Console.WriteLine($"Görsel dosyası bulunamadı: {imagePath}");
            return;
        }

        // Görsel dosyası byte dizisine çevrilir
        byte[] imageBytes = await File.ReadAllBytesAsync(imagePath);
        using (HttpClient client = new HttpClient())

        using (ByteArrayContent content = new ByteArrayContent(imageBytes))
        {
            // Authorization header eklenir (Doğru olan Subscription-Key başlığı!)
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", subscriptionKey);

            // İçerik tipi olarak binary stream (octet-stream) belirtilir
            content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");

            // API'ye POST isteği gönderilir
            HttpResponseMessage response = await client.PostAsync(uri, content);
            string result = await response.Content.ReadAsStringAsync();

            // Eğer başarılıysa, gelen JSON verisi işlenir
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Azure Yanıtı:");
                JsonDocument json = JsonDocument.Parse(result);

                // "description" objesi içindeki "captions" dizisinin ilk elemanı alınır
                var description = json.RootElement.GetProperty("description").GetProperty("captions")[0];

                // Caption içindeki görselle ilgili açıklama metni çekilir
                string text = description.GetProperty("text").GetString();

                // Caption'ın güven skoru (confidence score) çekilir ve double'a çevrilir
                double confidence = description.GetProperty("confidence").GetDouble();

                // Ekrana açıklama ve güven skoru yazdırılır
                Console.WriteLine($"Açıklama: {text} (Güven: %{confidence * 100:0.00})");
            }
            else
            {
                // Hata durumunda durum kodu ve hata mesajı yazdırılır
                Console.WriteLine("Bir hata oluştu!");
                Console.WriteLine($"Status: {response.StatusCode}");
                Console.WriteLine("Yanıt: " + result);
            }
        }
    }
}