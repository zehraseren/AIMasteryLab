# 🎙️ OpenAI Voice Chatbot Uygulaması
### 🎯 Proje Hakkında
Bu proje, OpenAI GPT modeli ile entegre çalışan `C# tabanlı bir sesli chatbot` uygulamasıdır. Kullanıcıdan ses kaydı alır, bu sesi metne çevirir, GPT modeli ile yanıt alır ve yanıtı tekrar sesli olarak sunar.

### 🚀 Özellikler
+ 10 saniyelik ses kaydı alır
+ Ses dosyasını metne dönüştürür
+ GPT üzerinden metni analiz eder ve yanıt üretir
+ Yanıtı sesli şekilde kullanıcıya okur

### 📌 NOT
##### RecordAudio metodundaki `waveIn.WaveFormat = new WaveFormat(sampleRate, channels)` kod satırında:
1. `sampleRate` nedir?
+ 1 saniyede kaç tane ses örneği (sample) alınmasıdır.

| Değer (Hz) | Anlamı | Kullanım Alanı |
|-|-|-|
| 8000 | Düşük kalite, az yer kaplar | Telefon görüşmeleri, VIOP |
| 16000 | Orta kalite, konuşma için ideal | 🔉 Sesli anahtarlar, chatbot, OpenAI Whisper |
| 22050 | Müzik dışı medyada ideal | Podcast, sesli kitap |
| 44100 | CD kalitesi | 🎵 Müzik kayıtları |
| 48000 | Yayın standı | 🎙️ Film, TV, profesyonel kayıt |
| 96000+ | Profesyonel yüksek kalite | Stüdyo kayıtları, müzik prodüksiyon |

2. `channels` nedir?
+ Kaç tane ses kanalıyla kayıt yapılacağıdır.

| Kanal Sayısı | Anlamı |Ne zaman kullanılır? |
|-|-|-|
| 1 (Mono) | Tüm ses tek kanalda | Mikrofon, sesli chatbot, telefon |
| 2 (Stereo ) | Sol & sağ kanallar ayrı | Müzik, oyun, film, video |
| >2 (Surround) | 5.1, 7.1 gibi | Sinema sistemleri |


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
🎤 Sesli Chatbot başladı. Konuşmak için enter tuşuna basınız.

🎙️ Konuşmaya başlayın
🛑 Kayıt tamamlandı
🗣️ Sen: ...
🤖 ChatGPT: ...

...
```

### 🛠 Kullanılan Teknolojiler
+ C# / .NET 9
+ OpenAI API (ChatGPT)
+ System.Speech.Synthesis (Text-to-Speech için)
+ NAudio (Ses kaydı alma)

### 🔗 Kaynaklar
+ [OpenAI API Dokümantasyonu](https://platform.openai.com/docs/api-reference/introduction)
