# 🎨 Stability AI ile Metinden Görsel Üretimi
### 🧠 Proje Hakkında 
Bu proje, Stability AI'nin Stable Diffusion modelini kullanarak verilen bir metin (prompt) üzerinden görsel üretimi yapar. `C#` ve `HttpClient` kullanılarak Stability API'sine istek atılır ve gelen görsel `.jpg` olarak kaydedilir

### 🚀 Özellikler
+ Prompt ile özel görseller üretme
+ 512x512 boyutunda görsel çıktısı
+ 30 adımda kalite odaklı görsel oluşturma
+ `cfg_scale` ile yaratıcılık–sadakat ayarı
+ JSON üzerinden basit ve hızlı API kullanımı

### 🔧 Kurulum ve Kullanım
1. StabilityAI hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir isteklerinizi yazın sonucu gözlemleyin
```
🤖 Prompt'tan Görsel Üretici - Stability AI
Lütfen bir prompt giriniz: (örn: a wearing sunglasses on a beach): A sunlit vineyard stretching across rolling hills at golden hour, with lush green grapevines heavy with ripe purple grapes. The sky is partly cloudy with dramatic light rays piercing through the clouds. In the distance, a rustic wooden farmhouse with a red tiled roof sits beside a narrow dirt path. A few birds fly across the sky, and the scene is bathed in warm, soft sunlight with subtle shadows. Ultra-detailed, photorealistic, 8K resolution, cinematic atmosphere

✅ Görsel başarıyla oluşturuldu ve kaydedildi: generated_20250721_235937.jpg
```
###### Oluşturulan Görsel:
<img width="512" height="512" alt="generated_20250721_235937" src="https://github.com/user-attachments/assets/95c8b563-583e-4344-87c3-7fdc278e1509" />

### 🛠 Kullanılan Teknolojiler
+ C# / .NET 9
+ `System.Text.Json` ile JSON işleme
+ Stability AI (Text-to-Image endpoint)
