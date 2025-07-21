# 🤖 OpenAI C# Code Assistant
### 🎯 Proje Hakkında
Bu proje, C# geliştiricilerinin kodlarını daha hızlı anlaması, temizlemesi ve test etmesi için `OpenAI GPT-3.5 API`’si ile entegre edilmiş interaktif bir konsol uygulamasıdır.

### 🚀 Özellikler
+ `Kod Açıklaması`: Yazdığın C# kodunu detaylı ve anlaşılır şekilde açıklar.
+ `Refactor (Yeniden Düzenleme)`: Kodunu daha okunabilir ve temiz hale getirir.
+ `Test Case Üretimi`: Mevcut kodun için birim testler otomatik olarak oluşturur.

### 💡 Öğrendiklerim
+ OpenAI API entegrasyonu ve async HTTP istek yönetimi
+ JSON serileştirme ve ayrıştırma (System.Text.Json)
+ Konsol uygulaması için kullanıcı girdisi alma teknikleri
+ C# 9+ dil özellikleri ve pattern matching kullanımı
+ API anahtarı yönetimi ve güvenlik konusunda temel farkındalık

### 🔧 Kurulum ve Kullanım
1. OpenAI hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir isteklerinizi yazın sonucu gözlemleyin
```
Kodunuzu yazın ve aşağıdaki işlemlerden birini seçin:

1) Açıklama Üret
2) Refactor Et
3) Test Case Oluştur

Seçiminiz (1/2/3): 1

Kodunuzu Girin (bitirmek için 'END' yazın):

// Kod

OpenAI JSON yanıtı: ...
```

### 🛠 Kullanılan Teknolojiler
+ C# / .NET 9
+ `System.Text.Json` ile JSON işleme
+ `HttpClient` ile RESTful API kullanımı
+ OpenAI GPT-3.5 API

### 🔗 Kaynaklar
+ [OpenAI API Dokümantasyonu](https://platform.openai.com/docs/api-reference/introduction)
