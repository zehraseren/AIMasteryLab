# 📝 Hugging Face Text Summarization
### 🎯 Proje Hakkında
Bu proje, Hugging Face Inference API kullanılarak verilen uzun bir metnin kısa ve anlamlı bir özetinin oluşturulmasını sağlar. Kullanıcıdan alınan metin, önceden eğitilmiş bir özetleme modeli olan `facebook/bart-large-cnn` ile işlenir ve özet sonuç terminalde gösterilir.

### 🚀 Özellikler
+ Uzun metinlerden anlamlı özet çıkarımı
+ Hugging Face API ile REST entegrasyonu
+ `facebook/bart-large-cnn transformer` modeli kullanımı

### 💡 Öğrendiklerim
+ Hugging Face API'de özetleme (summarization) modeli ile çalışma
+ HttpClient ile JSON veri gönderimi
+ Farklı modellerle (`distilbart`, `bart`) test yapılabilirlik

### 🔧 Kurulum
1. Hugging Face hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Projeyi çalıştırın:
```
dotnet run
```
5. Terminale bir metin girin:
###### Örnek Metin: 
```
Istanbul, a city that spans two continents, is rich in history, culture, and architectural beauty. The Hagia Sophia, once a church, then a mosque, and now a museum, stands as a symbol of the city’s layered past. Nearby, the Blue Mosque dazzles with its intricate blue tiles and majestic domes. Topkapi Palace offers a glimpse into the opulent lifestyle of the Ottoman sultans, while the Grand Bazaar, one of the largest covered markets in the world, entices visitors with its vibrant stalls and historic charm. Don't miss the Basilica Cistern with its eerie ambiance and Medusa head columns. A cruise along the Bosphorus showcases stunning waterfront mansions and bridges connecting Europe and Asia. Galata Tower provides panoramic views of the city, and Istiklal Avenue offers a lively mix of shops, cafes, and street performers. Istanbul is a mesmerizing blend of the old and new, where every corner reveals a new story.
```
###### Çıktı Örneği:
```
Istanbul is rich in history, culture, and architectural beauty. The Hagia Sophia, once a church, then a mosque, and now a museum, stands as a symbol of the city's layered past. Topkapi Palace offers a glimpse into the opulent lifestyle of the Ottoman sultans.
```

### 🧠 Kullanılan Model
+ Model: `facebook/bart-large-cnn`
+ Amaç: Genel metin özetleme
+ Model tipi: Transformer tabanlı, encoder-decoder mimarisi

#### Alternatifler:
+ `sshleifer/distilbart-cnn-12-6` → Daha hafif model, hızlı inference
+ `falconsai/text_summarization` → Yeni nesil community modelleri

### 📌 Notlar
+ Girilen metin 1024 token üzerindeyse model kısaltabilir, anlam kaybı yaşanabilir.
+ Türkçe metinler için özel `fine-tune` edilmiş modeller denenebilir.
+ Geliştirmeye ve özelleştirmeye açık bir altyapı sunar.
