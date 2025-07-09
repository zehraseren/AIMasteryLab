# 📞 Deepgram Speech to Text Integration
### 🎯 Proje Hakkında
Deepgram API kullanarak ses dosyalarını metne çevirme uygulamasıdır. HTTP Client ile REST API entegrasyonu yapılmıştır.

### 🚀 Özellikler
+ MP3 ses dosyası işleme
+ Türkçe dil desteği
+ JSON response parsing
+ Error handling
+ Console output

### 💡 Öğrendiklerim
+ Deepgram API'nin REST endpoint yapısı
+ HTTP Client ile file upload işlemi
+ JSON response parsing teknikleri
+ Authentication header kullanımı
+ Error handling best practices

### 🔧 Kurulum
1. Deepgram hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. `testtr.mp3` dosyasını proje klasörüne koyun


***

### NOTLAR
##### 🔍 Arka Plan: Bu JSON yapısı nereden geliyor?
+ Bir ses tanıma servisine (`Deepgram`) gönderilen bir ses dosyasının dönüş cevabıdır. API, sesin çözümünü (transkripti) JSON formatında döner.

##### JSON Hiyerarşisi ve Anlamları:
```
{
  "results": {
    "channels": [
      {
        "alternatives": [
          {
            "transcript": "Bugün hava çok güzel."
          }
        ]
      }
    ]
  }
}
```

+ `results`
  - `Anlamı:` Tüm sonuçların bulunduğu ana kapsayıcıdır.
  - Yani sistemin sunduğu tüm tanıma (speech recognition) sonuçlarını içerir.
  - Bu sonuçlar birden fazla kanal olabilir (bir podcast düşünülebilir, biri konuşuyor, sonra diğeri giriyor gibi).
 
+ `channels`
  - `Anlamı:` Ses dosyasındaki kanalların her biri için ayrı ayrı sonuçları içerir.
  - Eğer stereo (çift kanallı) bir kayıt varsa, mesela bir taraf konuşuyor sonra diğeri cevaplıyor — işte bu her biri bir `channel` olarak temsil edilir.
  - Bu, `channel[0]` birinci konuşmacı, `channel[1]` ikinci konuşmacı olabilir.

+ `alternatives`
  - `Anlamı:` Bir kanal içindeki konuşmanın farklı olasılıklı transkriptleridir.
  - Speech-to-text sistemleri bazen kararsız kalır ve birkaç farklı yorum üretir.
  - Örneğin:
  ```
  "alternatives": [
      { "transcript": "Bugün hava çok güzel." },
      { "transcript": "Bugün haber çok güzel." }
  ]
  ```
  - Genelde ilk sıradaki (`alternatives[0]`) en yüksek güven skoruna (confidence) sahip olandır.

#### Özetle hiyerarşi aşağıdaki şekilde olmalıdır:
```
results
  └── channels[]             --> Birden fazla kanal (konuşmacı) olabilir
        └── alternatives[]   --> Her kanal için birden fazla yorum (tahmin) olabilir
              └── transcript --> En iyi tahmin edilen metin burada
```

***

### 🎯 Gerçek Hayattan Bir Örnek:
Bir podcast kaydı çözümleniyor varsayılsın:
+ `channels[0]` → Sunucu
+ `channels[1]` → Konuk
+ `alternatives[0]` → Sunucunun söylediği şeyin en doğru çözümü
+ `transcript` → "Bugün sizlerle yapay zekâyı konuşacağız."
