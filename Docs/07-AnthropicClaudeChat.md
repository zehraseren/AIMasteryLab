# 🤖 Anthropic Claude AI Chat App  
### 🎯 Proje Hakkında

Bu proje, Anthropic tarafından geliştirilen `Claude AI` ile yapılan bir **chat (soru-cevap)** uygulamasıdır. Kullanıcıdan alınan metin, Claude-3 Opus modeli ile işlenir ve doğal dilde bir yanıt üretilir.  
.NET Console uygulaması olarak tasarlanmıştır ve `HttpClient` kullanılarak API ile iletişim kurar.

### 🚀 Özellikler
+ Claude ile gerçek zamanlı metin sohbeti  
+ Sade ve okunabilir konsol arayüzü  
+ API token ile güvenli istek  
+ Max token, temperature gibi yaratıcı ayarlar  
+ İleride multi-turn (geçmişli) sohbet desteklenebilir

### 💡 Öğrendiklerim
+ Anthropic Claude API’nin çalışma yapısı
+ `POST` isteği ile mesaj gönderme
+ `messages` dizisi mantığı (`role: user / assistant`)
+ MediaType / header yönetimi

### 🔧 Kurulum ve Kullanım 
1. Anthropic Claude hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir metin girerek sonucu gözlemleyin 👇
```
👩🏻‍💻 Lütfen sorunuzu yazınız: Merhaba Claude! Bana Mustafa Kemal Atatürk'ü birkaç cümle ile tanımlar mısın?

💬 Claude'un cevabı: Mustafa Kemal Atatürk (1881-1938), Türkiye Cumhuriyeti'nin kurucusu ve ilk Cumhurbaşkanı'dır.
Osmanlı İmparatorluğu'nun yıkılması ardından Türk Kurtuluş Savaşı'nı başarıyla yönetti ve modern Türkiye'yi kuran liderdir.
Askeri dehasının yanı sıra devrimci vizyonuyla ülkesini çağdaş medeniyetler seviyesine çıkarmayı hedeflemiş, eğitim, hukuk, sosyal yaşam ve siyasi sistemde köklü reformlar gerçekleştirmiştir.
Harf devrimi, kadınlara seçme ve seçilme hakkı verilmesi, laiklik ilkesinin benimsenmesi ve modern eğitim sisteminin kurulması gibi devrimlerle Türkiye'yi geleneksel yapıdan modern bir cumhuriyete dönüştürmüştür.
"Yurtta sulh, cihanda sulh" ilkesiyle barışçıl dış politika benimseyen Atatürk, sadece Türkiye için değil, tüm dünya için ilham verici bir lider olarak kabul edilir.
```

### 🧠 Kullanılan Teknolojiler & Model Bilgisi
+ **Dil modeli:** `claude-3-opus-20240229`
+ **API sağlayıcı:** [Anthropic](https://www.anthropic.com/)
+ **Model versiyonu:** `2023-06-01`
+ **Programlama dili:** C#
+ **Platform:** .NET 9

### Örnek API Request Formatı
```
{
  "model": "claude-3-opus-20240229",
  "max_tokens": 1000,
  "temperature": 0.7,
  "messages": [
    {
      "role": "user",
      "content": "Claude nedir?"
    }
  ]
}
```

### 📌 Önemli Notlar
+ Claude’un cevabı JSON içinde `content[0].text` olarak gelir.
+ `temperature` artırıldıkça daha yaratıcı ama daha tutarsız cevaplar gelebilir.
+ Claude cevap üretmeden önce birkaç saniye bekleyebilir, bu normaldir.

### 🔗 Kaynaklar
+ [Anthropic Developer Docs](https://docs.anthropic.com/en/home)
