# 🧠 Hugging Face Sentiment Analysis
### 🎯 Proje Hakkında
Bu proje, Hugging Face API kullanarak metinler üzerinden duygu analizi yapmayı amaçlar. Kullanıcıdan alınan metin, önceden eğitilmiş bir transformer modeli ile analiz edilir ve sonucunda metnin `duygu durumu (pozitif, nötr, negatif)` ile birlikte `güven skoru (% cinsinden)` kullanıcıya sunulur.

### 🚀 Özellikler
+ Kullanıcıdan metin alma (console)
+ Hugging Face modeli ile duygu analizi (Sentiment Classification)
+ Duygu durumu: Pozitif 😊 | Nötr 😐 | Negatif 😞
+ Güven skoru: Yüzde formatında detaylı çıktı
+ Emoji destekli, keyifli terminal çıktısı

### 💡 Öğrendiklerim
+ Hugging Face Inference API yapısı
+ HttpClient ile JSON veri gönderimi
+ Token bazlı authentication
+ API response parse etme (JsonDocument)
+ Score sıralaması ve etiket eşleştirme
+ `CultureInfo.InvariantCulture` ile sayı formatlama

### 🔧 Kurulum
1. hugging Face hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir metin girerek sonucu gözlemleyin 👇
```
Bir Metin Giriniz: Bugün çok keyifliyim!

🧾 Girdi Metni: Bugün çok keyifliyim!
🧠 Duygu Analizi: 
🎭 Duygu Durumu: POZİTİF 😊
📊 Güven Skoru: %95.23
```

### 🧪 Model Bilgisi
+ Model: `cardiffnlp/twitter-roberta-base-sentiment`
+ Eğitim Verisi: İngilizce tweet tabanlı
+ Duygu Etiketleri: LABEL_0 = Negatif, LABEL_1 = Nötr, LABEL_2 = Pozitif
+ Türkçe için kullanılabilecek modeller:
  - `savasy/bert-base-turkish-sentiment-cased`
  - `dbmdz/bert-base-turkish-cased`
  - `ITU-NLP/bert-base-turkish-sentiment`
