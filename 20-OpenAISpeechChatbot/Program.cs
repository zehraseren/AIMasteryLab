using System.Text;
using NAudio.Wave;
using System.Text.Json;
using System.Speech.Synthesis;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("🎤 Sesli Chatbot başladı. Konuşmak için enter tuşuna basınız.");

        while (true)
        {
            Console.ReadLine();
            string audioFilePath = "recorded.wav";

            // 1. Ses kaydı al
            Console.WriteLine("🎙️ Konuşmaya başlayın");

            RecordAudio(audioFilePath);
            Console.WriteLine("🛑 Kayıt tamamlandı.");

            // 2) OpenAI Whisper API ile konuşmayı metne çevir
            string transcription = await TranscribeAudioAsync(audioFilePath);
            Console.WriteLine($"🗣️ Sen: {transcription}");

            // 3) ChatGPT'ye soruyu gönder
            string reply = await AskChatGptAsync(transcription);
            Console.WriteLine($"🤖 ChatGPT: {reply}");

            // 4) Yanıtı seslendir
            var synth = new SpeechSynthesizer();
            synth.Speak(reply);
        }
    }

    // Ses kaydını yapan metottur, çıktı dosyasının yolunu parametre olarak alır
    static void RecordAudio(string outpoutFilePath)
    {
        // Mikrofon girişini temsil eden bir WaveInEvent nesnesi oluşturulur
        using var waveIn = new WaveInEvent();

        // Kaydedilecek sesin formatı: 16kHz örnekleme, mono (tek kanal)
        waveIn.WaveFormat = new WaveFormat(16000, 1);

        // WAVE formatında bir ses dosyası oluşturulu
        using var writer = new WaveFileWriter(outpoutFilePath, waveIn.WaveFormat);

        // Mikrofon verisi geldiğinde çalışacak olay tetikleyici tanımlanır
        // a.Buffer: Mikrofonla alınan ses verisi
        // a.BytesRecorded: O anda kaç byte veri kaydedildiğini belirtir
        // writer.Write(...): Bu byte'ları ".wav" dosyasına yazar
        waveIn.DataAvailable += (s, a) => writer.Write(a.Buffer, 0, a.BytesRecorded);

        // Ses kaydı başlatılır
        waveIn.StartRecording();

        // 10 saniye boyunca kayıt yapılması için ana thread uyutulur
        Thread.Sleep(10000);

        // 10 saniye sonra kayıt durdurulur
        waveIn.StopRecording();
    }

    // Verilen ses dosyasını OpenAI'nin Whisper modeli ile yazıya çevirir
    static async Task<string> TranscribeAudioAsync(string audioFilePath)
    {
        // OpenAI API anahtarı tanımlanır
        string apiKey = "YOUR_API_KEY_HERE";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        // Multipart form verisi oluşturulur (dosya + model bilgisi)
        using var form = new MultipartFormDataContent();

        // Ses dosyasını okumak için FileStream açılır
        using var fs = File.OpenRead(audioFilePath);

        // Ses dosyası forma eklenir
        form.Add(new StreamContent(fs), "file", Path.GetFileName(audioFilePath));

        // Whisper model adı forma eklenir
        form.Add(new StringContent("whisper-1"), "model");

        // POST isteği ile OpenAI transkripsiyon endpoint'ine form gönderilir
        var response = await client.PostAsync("https://api.openai.com/v1/audio/transcriptions", form);
        var result = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(result);

        // JSON içinden transkripsiyon metni alınıp döndürülür
        return doc.RootElement.GetProperty("text").GetString();
    }

    static async Task<string> AskChatGptAsync(string userMessage)
    {
        // OpenAI API anahtarı tanımlanır
        string apiKey = "YOUR_API_KEY_HERE";
        using var client = new HttpClient();
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

        // API'ye gönderilecek veri yapısı hazırlanır
        var payload = new
        {
            model = "gpt-3.5-turbo", // Kullanılacak model
            messages = new[]
            {
                new { role = "user", content = userMessage } // Kullanıcı mesajı
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
        var result = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(result);

        // ChatGPT'den gelen cevabın içeriği çekilir ve geri döndürülür
        return doc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
    }
}