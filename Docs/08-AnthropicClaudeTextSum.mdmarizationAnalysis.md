# 🧠 Anthropic Claude Text Summarization & Analysis
### 🎯 Proje Hakkında
Bu proje, PDF formatındaki metinleri okuyarak `Claude 3 (Opus)` modeli aracılığıyla özetleme ve içerik analizi gerçekleştirmeyi amaçlar.   Anthropic’in API servisi kullanılarak yapay zekâ destekli metin işleme sağlanır.

### 🚀 Özellikler
+ PDF dosyasından sayfa bazlı metin çıkarımı
+ Claude 3 Opus modeliyle detaylı özetleme
+ HTTP tabanlı REST API entegrasyonu
+ JSON formatında mesaj yapısı oluşturma
+ Türkçe prompt desteği

### 💡 Öğrendiklerim
+ Claude 3 API yapısı ve mesaj formatı
+ PDF parsing teknikleri (PdfPig)
+ Yapay zekâ ile uzun metin analizi
+ REST API'ye JSON içerik gönderimi

### 🔧 Kurulum ve Kullanım 
1. Anthropic Claude hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'iniz ve `YOUR_PATH_HERE` dosyanızın olduğu path ile değiştirin
4. `UglyToad.PdfPig` NuGet paketini projeye dahil edin
5. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsoldaki sonucu gözlemleyin 👇
```
🧾 PDF Özeti: [PDF'den çıkarılan metin burada yer alır]
```

### 🧑‍💻 Kullanılan Teknolojiler
- `C#` / `.NET`
- `Anthropic Claude API`
- `UglyToad.PdfPig` (PDF okuma)
- `System.Net.Http` & `System.Text.Json`

### 🔗 Kaynaklar
+ [Anthropic Developer Docs](https://docs.anthropic.com/en/home)
