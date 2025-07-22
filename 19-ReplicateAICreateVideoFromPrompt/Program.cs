using System.Text;
using System.Text.Json;
using System.Diagnostics;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        // Konsolun karakter kodlamasını UTF8'e göre ayarlar (emoji desteği vs. için)
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🎬 Replicate AI ile Video Üretici Uygulaması");

        // Kullanıcıdan video oluşturulacak metin alınır
        Console.Write("Please Input Here Prompt Text:  ");
        string prompt = Console.ReadLine();

        // Replicate API anahtarı
        string apiKey = "YOUR_API_KEY_HERE";

        // Model versiyonu boş bırakılırsa Replicate en günceli kullanır
        string version = "﻿9f747673945c62801b13b84701c783929c0ee784e4748ec062204894dda1a351";

        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", apiKey);

        // 1) Video üretim isteği | API'ye gönderilecek istek gövdesi
        var body = new
        {
            version, // Model versiyonu, boş bırakılırsa en son sürüm kullanılır
            input = new
            {
                prompt, // Kullanıcının verdiği metin tanımı
                num_frames = 24, // Videodaki toplam kare (fream) sayısı
                fps = 8, // Videonun saniyedeki kare sayısı (frames per second)
                guidance_scale = 12.5, // Prompt'a ne kadar bağlı kalınacağı
                num_inference_steps = 50, // Her kare için modelin kaç adımda çalışacağı (ne kadar yüksekse, kalite artar ama süre uzar)
                width = 1024,
                height = 576,
            }
        };

        // Yanıttan üretim ID'si alınır
        var json = JsonSerializer.Serialize(body);
        var response = await client.PostAsync("https://api.replicate.com/v1/predictions", new StringContent(json, Encoding.UTF8, "application/json"));

        if (!response.IsSuccessStatusCode)
        {
            Console.WriteLine($"API Hatası: {await response.Content.ReadAsStringAsync()}");
            return;
        }

        var pred = JsonDocument.Parse(await response.Content.ReadAsStringAsync());
        string id = pred.RootElement.GetProperty("id").GetString();
        Console.WriteLine("📼 Video üretiliyor...");

        // 2) Üretim durumu döngüsü
        string status = "";
        string videoUrl = "";

        // Üretim tamamlanana kadar döngüye girer
        while (status != "succeeded")
        {
            await Task.Delay(5000); // 5 saniye bekle

            // API'den üretimin güncel durumunu alır
            var chk = await client.GetAsync($"https://api.replicate.com/v1/predictions/{id}");
            var chkJson = JsonDocument.Parse(await chk.Content.ReadAsStringAsync());

            // Durum alınır (succeeded, failed, starting, processing vb.)
            status = chkJson.RootElement.GetProperty("status").GetString();
            Console.WriteLine($"⌛ Durum: {status}");

            if (status == "succeeded") // Eğer başarıyla üretilirse video URL'ini alınır
            {
                // Video URL'ini alır
                var output = chkJson.RootElement.GetProperty("output");

                // Çoğu zaman output bir dizi olur, eğer array ise ilk eleman alınır, değilse direkt alınır
                videoUrl = output.ValueKind == JsonValueKind.Array ? output[0].GetString() : output.GetString();
            }
            else if (status == "failed") // Video üretim başarısız olursa kullanıcıya bildirir
            {
                // Üretim başarısızsa kullanıcıya bildirilir ve çıkılır
                Console.WriteLine("❌ Video üretimi başarısız oldu.");
                return;
            }
        }

        Console.WriteLine($"👌🏻 Video Hazır: {videoUrl}");

        // 3) Video İndirme
        // Video URL'sinden bir stream açılır
        using var stream = await client.GetStreamAsync(videoUrl);

        // Uygulama dizininde bir dosya oluşturulur
        await using var file = File.Create("generated_video.mp4");

        // Video stream'i dosyaya yazılır
        await stream.CopyToAsync(file);
        Console.WriteLine("🎉 Video indirildi -> generated_video.mp4");

        // 4) Video Oynatma
        // Oluşturulan videoyu sistemin varsayılan video oynatıcısıyla açar
        Process.Start(new ProcessStartInfo
        {
            // Açılacak dosyanın adı
            FileName = "generated_video.mp4",
            // Shell üzerinden çalıştırma (Windows Media Player gibi varsayılan uygulama kullanılır)
            UseShellExecute = true
        });
    }
}