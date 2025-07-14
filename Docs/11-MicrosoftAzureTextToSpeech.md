# 🗣️ Microsoft Azure Text To Speech
### 🎯 Proje Hakkında
Bu proje, Microsoft Azure'un `Text-to-Speech (TTS)` servisini kullanarak verilen bir metni doğal bir insan sesiyle ses dosyasına çevirir. Hem Türkçe hem de İngilizce `SSML (Speech Synthesis Markup Language)` desteğiyle farklı dillerde çıktı alabilirsiniz.
.NET ortamında HttpClient kullanılarak REST API üzerinden ses dosyası oluşturulmuştur.

### 🚀 Özellikler
+ Azure TTS API ile REST entegrasyonu
+ Türkçe ve İngilizce SSML destekli ses üretimi
+ WAV formatında ses çıktısı
+ Token alma ve yetkilendirme işlemleri
+ Hata yakalama ve durum yönetimi

### 💡 Öğrendiklerim
+ Azure Speech Service erişimi ve token alma
+ SSML formatında ses sentezi
+ `HttpClient` ile POST işlemleri
+ WAV formatında dosya oluşturma ve kaydetme
+ Azure API response analizi ve hata ayıklama

### 🔧 Kurulum ve Kullanım
1. Azure portal üzerinden bir Speech hizmeti oluşturun
2. `YOUR_API_KEY_HERE` ve `YOUR_REGION_HERE` alanlarını doldurun
3. Program.cs içindeki metni kendi cümlelerinizle güncelleyin
4. Projeyi çalıştırın, `output2.wav` dosyası oluşacaktır
```
dotnet run
```
> Çalıştırdıktan sonra `output2.wav` dosyasını ses oynatıcıda açarak sonucu dinleyebilirsiniz.

######  Örnek SSML Parçası
```
<speak version='1.0' xml:lang='tr-TR'>
  <voice xml:lang='tr-TR' name='tr-TR-AhmetNeural'>
    Merhaba arkadaşlar, bu bir deneme mesajıdır.
  </voice>
</speak>
```

### 💬 Not
+ `tr-TR-AhmetNeural` yerine `en-US-JennyNeural` gibi sesler kullanarak farklı dillerde konuşmalar üretebilirsiniz.
+ Azure TTS modelleri için tam liste: [Microsoft Speech Voice List](https://learn.microsoft.com/en-us/azure/ai-services/speech-service/language-support?tabs=stt)
