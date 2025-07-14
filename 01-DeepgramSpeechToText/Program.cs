using System.Text.Json;
using System.Net.Http.Headers;

// Deepgram API anahtarını tanımlanır (güvenlik açısından bunu bir config dosyasına alman önerilir)
var apiKey = "YOUR_API_KEY_HERE";
// Yüklenecek ses dosyasının yolud
var filepath = "testeng.mp3";

// Dosyanın var olup olmadığını kontrol edir; yoksa işlemi iptal edilir
if (!File.Exists(filepath))
{
    Console.WriteLine("Dosya bulunamadı.");
    return;
}

// HttpClient nesnesi oluşturuluyor; IDisposable olduğu için using kullanılıyor
using var client = new HttpClient();

// API anahtarıyla yetkilendirme başlığı eklenir (Deepgram Token tabanlı çalışır)
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", apiKey);

// Dosya okunur ve HTTP içeriği (StreamContent) olarak hazırlanır
using var fileStream = File.OpenRead(filepath);
var content = new StreamContent(fileStream);

// İçerik tipi (MIME type) mp3 olarak ayarlanır
content.Headers.ContentType = new MediaTypeHeaderValue("audio/mp3");

// Deepgram'e ses dosyası POST ediliyor — varsayılan olarak İngilizce varsayılır 
var response = await client.PostAsync("https://api.deepgram.com/v1/listen", content);

// Türkçe dil desteği için
//var response = await client.PostAsync("https://api.deepgram.com/v1/listen?language=tr", content);

// JSON formatında gelen yanıt string olarak alınır
var json = await response.Content.ReadAsStringAsync();

try
{
    // JSON verisini ayrıştırmak için bir JsonDocument nesnesi oluşturulur
    var doc = JsonDocument.Parse(json);

    // JSON yapısında sırasıyla "results" -> "channels"[0] -> "alternatives"[0] -> "transcript" alanlarına erişilir
    // Deepgram response: results -> channels[0] -> alternatives[0] -> transcript
    var transcript = doc.RootElement
        .GetProperty("results")               // "results" objesi alınır
        .GetProperty("channels")[0]           // "channels" dizisinden ilk öğe alını
        .GetProperty("alternatives")[0]       // "alternatives" dizisinden ilk öğe alınır
        .GetProperty("transcript")            // "transcript" alanı alını
        .GetString();                         // Değer string olarak okunur

    // Konsola başlık ve çeviri metni yazdırılır
    Console.WriteLine();
    Console.WriteLine("Çeviri Metni: \n");
    Console.WriteLine(transcript);
}
catch (Exception ex)
{
    // JSON ayrıştırma sırasında bir hata oluşursa kullanıcı bilgilendirilir
    Console.WriteLine("Json çözümleme sıralasında bir hata oluştu.");
    Console.WriteLine(ex.Message);

    // Hatalı JSON çıktısı da gösterilir, kolay debugging için
    Console.WriteLine("\n Gelen Yanıt: \n" + json);

    // Hata tekrar fırlatılır, üst katmandaki hata yönetimine geçmesi için
    throw;
}