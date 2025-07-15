# 🧠 Microsoft Azure Computer Vision
### 🎯 Proje Hakkında
+ Bu projede Microsoft Azure’un `Computer Vision API` servisi kullanılarak görsellerin içeriği analiz edilmiştir. Proje; görselden açıklama (`caption`) üretme ve nesne tespiti (`object detection`) gibi temel görsel analiz işlemlerini gerçekleştirmektedir.
  
### 🚀 Özellikler
+ Görselden açıklama (caption) çıkarımı
+ Görseldeki nesnelerin tanımlanması
+ Azure REST API ile entegrasyon
+ API Key ile güvenli bağlantı
+ JSON verisinin ayrıştırılması
  
### 💡 Öğrendiklerim
+ Microsoft Azure Cognitive Services kullanımı
+ REST API üzerinden görsel verisi gönderimi
+ `application/octet-stream` veri formatı ile HTTP POST işlemi
+ JSON parsing ve conditional logic kullanımı
+ Gerçek zamanlı görsel içerik analizi mantığı

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
Nesne: person (Güven: %99.31)
Nesne: refrigerator (Güven: %92.05)
```

🛠 Kullanılan Özellikler
+ `Description`: Görsel hakkında genel bir açıklama sunar
+ `Objects`: Görseldeki nesneleri adlandırır ve güven skorlarıyla birlikte listeler
+ `Tags`, `Color`, `Categories`: Opsiyonel olarak API üzerinden dönebilir
