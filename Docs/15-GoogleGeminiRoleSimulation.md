# 🎭 Google Gemini Role Simulation
### 🎯 Proje Hakkında
Bu proje, Google Gemini API'sini kullanarak farklı rollerde sohbet edebileceğiniz basit bir .NET konsol uygulamasıdır. Kullanıcı, bir rol (psikolog, maç yorumcusu, finansal yatırım uzmanı, tarihçi, turist rehberi) seçer ve ardından sorduğu soruya seçilen rolün bakış açısından yanıt alır.

### 🚀 Özellikler
+ Rol Seçimi: Uygulama başlangıcında farklı roller arasından seçim yapabilme.

Dinamik Prompt Oluşturma: Seçilen role ve kullanıcının sorusuna göre Gemini API'ye gönderilecek prompt'un otomatik olarak oluşturulması.

Gemini API Entegrasyonu: gemini-1.5-pro modelini kullanarak yapay zeka destekli yanıtlar alma.

Konsol Tabanlı Arayüz: Basit ve kullanımı kolay konsol arayüzü.

### 💡 Öğrendiklerim
+ 

### 🔧 Kurulum ve Kullanım 
1. Google Gemini hesabı oluşturun
2. API key alın
3. Kod içindeki `YOUR_API_KEY_HERE` kısmını kendi API key'inizle değiştirin
4. Uygulamayı çalıştırın:
```
dotnet run
```
5. Konsola bir soru sorarak sonucu gözlemleyin 👇
```
🎭 Rolünüzü seçiniz:
1) Psikolog
2) Maç Yorumcusu
3) Finansal Yatırım Uzmanı
4) Tarihçi
5) Turist Rehberi

Seçiminiz: 5

❓ Sormak istediğiniz cümleyi giriniz: Kapadokya'da 3 gün geçireceğim. Neler yapmalıyım?

🧠 Gemini Cevap: Kapadokya'ya hoş geldiniz! Üç gününüzü dolu dolu geçirmeniz için size harika bir plan hazırladım. İşte mutlaka görmeniz ve denemeniz gerekenler:
1. Gün: Peri Bacaları ve Yeraltı Şehirleri
...
2. Gün: Yeraltı Şehirleri ve Vadiler
...
3. Gün: Paşabağ ve Zelve Açık Hava Müzesi
...
Mutlaka Denemeniz Gereken Lezzetler:
...
```

### 🛠 Kullanılan Teknolojiler
+ .NET 9 Console App
+ C# (async/await pattern)
+ Google Gemini 1.5 Pro API
+ `HttpClient`, `JsonSerializer`, `JsonDocument`





