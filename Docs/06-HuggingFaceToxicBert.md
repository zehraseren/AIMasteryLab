# ☣️ Hugging Face Toxic Comment Classification with BERT
### 🎯 Proje Hakkında  
Bu proje, Hugging Face platformundaki [`unitary/toxic-bert`](https://huggingface.co/unitary/toxic-bert) modeli ile kullanıcı yorumlarında **zehirli (toxic)** içerikleri tespit eder.  
Metin içindeki **hakaret, aşağılama, cinsiyetçilik, nefret söylemi** gibi içerikler sınıflandırılarak yüzdesel skorlarla sunulur.

### 🚀 Özellikler
- Hugging Face API ile canlı model entegrasyonu  
- Çoklu etiket analizi (multi-label classification)  
- Skor tabanlı çıktı  

### 💡 Öğrendiklerim
+ Hugging Face ile multi-label classification nasıl yapılır?
+ Toxic-BERT modelinin çalışma mantığı
+ JSON response parsing
+ Skora dayalı koşullu mantık kurma

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
👩🏻‍💻 Bir Yorum Yazınız: You're such an idiot, nobody wants to hear stupid opinions.

📊 Yorum Analizi:
                  toxic --> %91.27
                  insult --> %84.12
                  obscene --> %72.88
```

### 🧷 Etiketler ve Anlamları

| Etiket         | Açıklama |
|----------------|----------|
| `toxic`        | Genel olarak saldırgan, zehirli içerik |
| `severe_toxic` | Yoğun derecede zehirli, ciddi hakaret veya tehdit |
| `obscene`      | Küfür, müstehcen dil |
| `threat`       | Fiziksel veya psikolojik tehdit |
| `insult`       | Aşağılama, hakaret |
| `identity_hate`| Kimliğe (ırk, din, cinsiyet vb.) yönelik nefret söylemi |

💬 Model her etiket için ayrı skor üretir (0.00 – 1.00 arası).  
Skorlar % ile gösterilir ve 50% üzeri skorlar daha anlamlı kabul edilir.

### 🧪 Kullanılan Model
- **Model:** `unitary/toxic-bert`
- **Taban Model:** `bert-base-uncased`
- **Görev:** Multi-label classification (her kategori için ayrı skor)

### 🔗 Kaynaklar
+ [Hugging Face - unitary/toxic-bert](https://api-inference.huggingface.co/models/unitary/toxic-bert)
