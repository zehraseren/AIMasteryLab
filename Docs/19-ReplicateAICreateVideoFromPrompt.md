# 🎬 Replicate AI ile Video Üretici Uygulaması
Bu uygulama, Replicate AI platformunu kullanarak girilen metinsel tanıma (prompt) göre bir video üretir. Replicate'in video üretim modellerinden birini API aracılığıyla çağırır, oluşan videoyu indirir ve bilgisayarınızda otomatik olarak oynatır.

### 🚀 Özellikler
+ Kullanıcıdan detaylı bir metin (prompt) alır
+ Replicate API üzerinden video üretir
+ Üretilen videoyu `.mp4` formatında indirir
+ İndirilen videoyu varsayılan video oynatıcıyla otomatik açar

### 🔧 Kurulum ve Kullanım
1. Replicate hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir isteklerinizi yazın sonucu gözlemleyin
```
🎬 Replicate AI ile Video Üretici Uygulaması
Please Input Here Prompt Text: a majestic medieval stone castle built on a steep cliff edge, bathed in golden sunset light...

📼 Video üretiliyor...
📼 Video üretiliyor...
📼 Video üretiliyor...

// Video otomatik olarak açılır
```

### 🛠 Kullanılan Teknolojiler
+ C# (.NET 9.0)
+ HttpClient ile API isteği
+ `System.Diagnostics` ile video oynatma
+ `System.Text.Json` ile JSON ayrıştırma






