# 🎨 Replicate AI ile Metinden Görsel Oluşturma
### 🧠 Proje Hakkında  
Bu projede, kullanıcıdan alınan bir metin (prompt) Replicate AI üzerindeki `Stable Diffusion v1.5` modeliyle görsele dönüştürülür. Uygulama, basit bir `Console` arayüzüyle çalışır ve API'den dönen JSON verisini ekrana yazdırır.

### 🚀 Özellikler
+ Metinden görsel üretimi (Text-to-Image)
+ Replicate API entegrasyonu
+ Stable Diffusion 1.5 model kullanımı
+ JSON formatında veri gönderimi
+ Console tabanlı arayüz

### 💡 Öğrendiklerim
+ Replicate API kullanım şekli
+ Authorization header yapısı
+ JSON verisi ile AI model çağrısı
+ Model versiyon kontrolü

### 🔧 Kurulum
1. [Replicate hesabı oluşturun](https://replicate.com)
2. Token alın: `r8_...` şeklinde başlar
3. Kodda `token` ve model `version` ID'sini güncelleyin
4. Konsolda çizdirmek istediğiniz görseli tanımlayın
###### Örnek Prompt:
```
A futuristic cityscape at night with neon lights and flying cars
```

### 🧪 Kullanılan Teknolojiler
+ `.NET (C#)`
+ `HttpClient`
+ `System.Text.Json`
+ `Replicate API`

### 📌 Notlar
+ Replicate API ilk çağrıda sadece bir `prediction_id`[](url) döndürür.
+ Görsel oluşturulması birkaç saniye sürebilir.
