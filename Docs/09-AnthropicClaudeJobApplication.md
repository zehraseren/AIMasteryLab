# 💼 Anthropic Claude İş Başvurusu Asistanı
### 🎯 Proje Hakkında  
Bu proje, `Claude 3 (Opus)` modelini kullanarak profesyonel ama samimi bir iş başvurusu e-postası oluşturmayı amaçlar.  
Kullanıcıdan alınan bilgilerle kişiselleştirilmiş bir başvuru metni oluşturulur.

### 🚀 Özellikler
- Türkçe prompt desteği
- Claude 3 (Opus) ile doğal dil üretimi
- JSON formatında prompt gönderimi
- Console uygulaması ile etkileşimli kullanım
- Null-safe JSON parsing

### 💡 Öğrendiklerim
+ Claude 3 Opus API kullanımı
+ JSON üzerinden nested parsing işlemleri
+ Prompt oluşturma ve kişiselleştirme
+ Console uygulaması ile AI etkileşimi

### 🔧 Kurulum ve Kullanım 
1. Anthropic Claude hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsoldaki sonucu gözlemleyin 👇
###### Örnek Prompt:
```
Bana 'Yazılım' geliştirici pozisyonu hazırlanan, profesyonel ama samimi tonda bir iş başvuru e-postası yazar mısın? 
Adım Zehra, 1 yıldır .NET geliştiriciyim, ekip çalışmasına yatkınım, uzaktan veya hibrit çalışmaya uygunum.
```
###### E-mail Örneği:
```
E-mail Örneği: [E-posta örneği burada yer alır]
```

### 📌 Uygulama Akışı
1. Kullanıcıdan iş başvurusu için gerekli bilgiler alınır (şu an prompt içinde sabit).
2. Claude'a uygun şekilde `messages` formatında JSON veri hazırlanır.
3. Yanıt Claude 3 Opus modelinden alınır.
4. Claude'un döndürdüğü başvuru e-postası ekrana yazdırılır.
###### Claude'dan gelen JSON yapı:
```
{
  "content": [
    {
      "type": "text",
      "text": "Sayın Yetkili,\nYazılım geliştirici pozisyonu için..."
    }
  ]
}
```

### 🛠 Kullanılan Teknolojiler
+ `C# / .NET`
+ `System.Net.Http`
+ `System.Text.Json`
+ `Anthropic Claude API`

### ✨ Bonus Fikirler
+ Kullanıcıdan ad, pozisyon, deneyim vb. dinamik alanlar alınabilir
+ Claude'a İngilizce prompt göndererek çok dilli başvuru üretimi yapılabilir
+ Mülakat sorularını da bu sistemle üretip aynı proje altında çeşitlilik sağlanabilir

### 🔗 Kaynaklar
+ [Anthropic Developer Docs](https://docs.anthropic.com/en/home)
