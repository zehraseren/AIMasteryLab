using System.Text;
using System.Text.Json;
using System.Globalization;
using System.Net.Http.Headers;

var apiKey = "YOUR_API_KEY_HERE";

// Kullanıcıdan analiz edilecek metni alır
Console.Write("Bir Metin Giriniz: ");
var text = Console.ReadLine();

// Cümle Örnekleri:
// Everything is going to greate today, I feel really happy!
// This day was terrible, nothing the way I wanted.
// I had eggs for breakfast and went to work.

// Kullanılacak modelin Hugging Face API URL'i
var modelUrl = "https://api-inference.huggingface.co/models/cardiffnlp/twitter-roberta-base-sentiment";

using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

// API'ye gönderilecek JSON verisi oluşturulur
var json = JsonSerializer.Serialize(new { inputs = text });
var content = new StringContent(json, Encoding.UTF8, "application/json");

var response = await client.PostAsync(modelUrl, content);
var result = await response.Content.ReadAsStringAsync();

var doc = JsonDocument.Parse(result);
var items = doc.RootElement[0];

// En yüksek güven skoruna sahip label’ı seçer
var topLabel = items
    .EnumerateArray()
    .OrderByDescending(x => x.GetProperty("score").GetDouble())
    .First();

// Etiket (duygu) ve güven skoru (confidence) bilgilerini alır
var label = topLabel.GetProperty("label").GetString();
var score = topLabel.GetProperty("score").GetDouble();

// cardiffnlp/twitter-roberta-base-sentiment modeli 3 duygu etiketi ile eğitilmiştir, başka label'lar vermez
// Etiket isimleri ("LABEL_0" vs) sabittir çünkü Hugging Face üzerindeki bu model, eğitim sırasında bu etiketleri kullanmıştır
string labelText = label switch
{
    "LABEL_0" => "NEGATİF 😞",
    "LABEL_1" => "NÖTR 😐",
    "LABEL_2" => "POZİTİF 😊",
    _ => "BİLİNMİYOR"
};

// Unicode desteğiyle (emojiler için) terminale düzgün çıktı verilir
Console.OutputEncoding = Encoding.UTF8;
Console.WriteLine($"\n🧾 Girdi Metni: {text}");

Console.WriteLine("🧠 Duygu Analizi: ");
Console.WriteLine($"🎭 Duygu Durumu: {labelText}");
// F2, Fixed-point formatta, virgülden sonra 2 basamak göster demektir yani kullanıcıya net, okunabilir bir yüzde değeri verir.
// CultureInfo.InvariantCulture, Sayıyı her bölgede aynı şekilde yaz demektir böylece programın çıktısı başka dillere geçilince sorun çıkmaz
Console.WriteLine($"📊 Güven Skoru: %{(score * 100).ToString("F2", CultureInfo.InvariantCulture)}");