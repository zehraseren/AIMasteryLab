# 🧾 HuggingFace Named Entity Recognition (NER)

### 🎯 Proje Hakkında  
Bu proje, Hugging Face `savasy/bert-base-turkish-ner-cased` modeli kullanılarak yazılmış bir Named Entity Recognition (NER) uygulamasıdır.  
Konsoldan girilen Türkçe metin içerisindeki kişi, kurum ve konum gibi varlıkları tespit eder ve güven skorlarıyla birlikte ekrana yazdırır.

### 🚀 Özellikler
- ✅ Hugging Face API entegrasyonu
- 🧠 Türkçe dil desteği ile NER analizi
- 📊 Güven skorları (%)
- 🖥️ Temiz ve sade konsol çıktısı
- 🔒 Token bazlı yorumlama ve parse işlemi

### 💡 Öğrendiklerim
+ Hugging Face API ile NER nasıl yapılır?
+ JSON parse etme ve token verisini işleme
+ API key ile yetkilendirme
+ Model seçimine göre doğruluk farkları (Jean-Baptiste vs. savasy)

### 🔧 Kurulum ve Kullanım
1. Hugging Face hesabı oluşturun
2. API key alın
3. Kod içindeki YOUR_API_KEY_HERE kısmını kendi API key'inizle değiştirin
4. Projeyi çalıştırın:
```
dotnet run
```
5. Terminale bir metin girin:
###### Örnek Metin:
```
Galatasaray Teknik Direktörü Okan Buruk, UEFA Şampiyonlar Ligi maçında Real Madrid'e karşı 2-1 kazandıkları zaferin ardından açıklamalarda bulundu.
```

###### Çıktı Örneği:
```
 --> Galatasaray
       |Type: ORG
       |Score: 99,55%
 --> Okan Buruk
       |Type: PER
       |Score: 99,83%
 --> UEFA Şampiyonlar Ligi
       |Type: ORG
       |Score: 99,52%
 --> Real Madrid
       |Type: ORG
       |Score: 99,92%
```

### 🔗 Kaynaklar
+ (Hugging Face - savasy/bert-base-turkish-ner-cased)[https://huggingface.co/savasy/bert-base-turkish-ner-cased]
