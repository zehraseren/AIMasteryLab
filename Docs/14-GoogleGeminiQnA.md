# ❓🗨️ Google Gemini Question Answering with 1.5 Pro
### 🎯 Proje Hakkında  
Bu projede, Google Gemini 1.5 Pro modeli kullanılarak basit ama güçlü bir .NET C# konsol uygulaması geliştirildi. Kullanıcı, konsola bir soru yazar ve Gemini'den gelen akıllı cevabı anında ekranda görür.

### 🚀 Özellikler
+ Google Gemini 1.5 Pro modeli kullanımı
+ REST API üzerinden `POST` isteğiyle içerik üretimi
+ Kullanıcıdan CLI üzerinden input alımı
+ Detaylı hata yönetimi (try-catch bloğu)
+ `HttpClient` ile modern API iletişimi
+ `StringContent` ve `MediaTypeWithQualityHeaderValue` kullanımı

### 💡 Öğrendiklerim
+ Gemini API endpoint yapısı ve auth sistemi
+ JSON içerisindeki nested dizilerden veri çıkarma (özellikle `.GetProperty(...)[0]` zincirleme mantığı)
###### JSON Yapısı (Beklenen format)
```
{
  "candidates": [
    {
      "content": {
        "parts": [
          {
            "text": "Merhaba, size nasıl yardımcı olabilirim?"
          }
        ]
      }
    }
  ]
}
```
+ Hata ayıklama için `responseText`’in raw olarak yazdırılmasının önemi
+ Exception handling ile fallback ve loglama mekanizması
+ CLI'dan kullanıcıdan alınan girdilerle dinamik veri oluşturma

### 🔧 Kurulum ve Kullanım 
1. Google Gemini hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir soru sorarak sonucu gözlemleyin 👇
```
❓ Sormak istediğiniz soruyu yazın: Yapay zeka nedir?

🧠 Gemini Cevap: Yapay zeka, insan benzeri görevleri yerine getirebilen sistemlerin genel adıdır.
```

### 🛠 Kullanılan Teknolojiler
+ .NET 9 Console App
+ C# (async/await pattern)
+ Google Gemini 1.5 Pro API
+ `HttpClient`, `JsonSerializer`, `JsonDocument`
