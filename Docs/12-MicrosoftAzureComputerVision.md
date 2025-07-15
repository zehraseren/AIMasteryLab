# 🧠 Microsoft Azure Computer Vision
### 🎯 Proje Hakkında
+ Bu proje, Microsoft Azure'un `Computer Vision API`'sini kullanarak bir görselin içeriğini analiz eder. Görselde ne olduğu hakkında açıklayıcı bir metin üretir ve tahminin güven skorunu kullanıcıya sunar.

### 🚀 Özellikler
+ JPEG formatında görsel analizi
+ Görselle ilgili açıklama (caption) üretimi
+ Güven skoru gösterimi
+ `JsonDocument` ile JSON parsing
+ API ile `application/octet-stream` içerik gönderimi

### 💡 Öğrendiklerim
+ Azure Computer Vision API ile görsel açıklama oluşturma
+ JSON içinden `caption` ve `confidence` verilerini çekme
+ API yanıtlarındaki hata kontrolü
+ Görsel verisinin `ByteArrayContent` ile gönderimi

### 🔧 Kurulum ve Kullanım
1. Azure portal'dan bir Computer Vision kaynağı oluşturun
2. `imagePath`, `subscriptionKey` ve `endpoint` alanlarını doldurun
> `imagePath` değişkenine analiz etmek istediğiniz görselin dosya yolunu girin
3. Projeyi çalıştırın
```
dotnet run
```
4. Konsoldaki sonucu gözlemleyin 👇
```
Azure Yanıtı:
Açıklama: a man riding a bicycle with a dog on a leash (Güven: %60,34)
```

🛠 Kullanılan Teknolojiler
+ Microsoft Azure Computer Vision v3.2 API
+ `HttpClient` ile API entegrasyonu
