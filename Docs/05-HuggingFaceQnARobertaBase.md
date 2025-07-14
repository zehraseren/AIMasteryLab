# ❓ Hugging Face Question Answering with RobertaBase
### 🎯 Proje Hakkında  
Bu proje, Hugging Face `deepset/roberta-base-squad2` modeli ile `soru-cevap (Question Answering)` işlemi yapar.  
Kullanıcıdan alınan bir bağlam (context) ve soru (question) girdilerine göre model, bağlamdan cevabı çıkartır ve ekrana yazdırır.

### 🚀 Özellikler
- Hugging Face API entegrasyonu  
- Roberta tabanlı `deepset/roberta-base-squad2` modeli  
- Doğal dil işleme temelli bağlamdan cevap çıkarımı  

### 💡 Öğrendiklerim
+ Hugging Face üzerinden Roberta modeli nasıl kullanılır?
+ JSON veri yapısıyla model entegrasyonu
+ Question Answering task yapısı (context + question → answer)
+ JSON parse işlemleri ve hata yakalama

### 🔧 Kurulum ve Kullanım 
1. hugging Face hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir metin girerek sonucu gözlemleyin 👇
```
🧾 Bir Metin Giriniz: Istanbul is a city in Turkey that spans two continents: Europe and Asia. It has a rich history and is known for landmarks like Hagia Sophia, Blue Mosque, and the Bosphorus.

❓ Soru: What is Istanbul known for?

🧠 Cevap: landmarks like Hagia Sophia, Blue Mosque, and the Bosphorus
```

### 🔗 Kaynaklar
+ [Hugging Face - deepset/roberta-base-squad2](https://api-inference.huggingface.co/models/deepset/roberta-base-squad2)
