# 💭 Google Gemini Auto Agent
### 🎯 Proje Hakkında
Bu proje, Google Gemini API'sini kullanarak interaktif bir şekilde içerik planları oluşturmanıza yardımcı olan basit bir .NET konsol uygulamasıdır. Uygulama, başlangıçtaki fikrinizi alarak size adım adım sorular sorar ve bu sorulara verdiğiniz yanıtlara göre detaylı bir içerik planı oluşturur.

### 🚀 Özellikler
+ Google Gemini (gemini-1.5-pro) API ile etkileşim
+ 5 turluk dinamik soru-cevap döngüsü
+ Bağlamsal olarak gelişen prompt mantığı
+ Otomatik içerik planı oluşturma
+ .NET 9 uyumlu C# konsol uygulaması

### 💡 Öğrendiklerim
+ Google Gemini API yapısı ve cevap parsing
+ Prompt design ve context yönetimi
+ C# ile AI entegrasyonu
+ Dinamik, kullanıcıyla etkileşimli uygulama geliştirme

### 🔧 Kurulum ve Kullanım
1. Google Gemini hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir isteklerinizi yazın sonucu gözlemleyin

### 🛠 Kullanılan Teknolojiler
+ C# / .NET 9
+ `System.Text.Json` ile JSON işleme
+ `HttpClient` ile RESTful API kullanımı
+ Google Gemini 1.5 Pro modeli
