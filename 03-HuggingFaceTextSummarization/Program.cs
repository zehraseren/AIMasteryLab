using System.Text;
using System.Text.Json;
using System.Net.Http.Headers;

Console.Write("Enter your text here: ");

var apiKey = "YOUR_API_KEY_HERE";
var inputText = Console.ReadLine();

// API'ye gönderilecek istek verisini oluşturulur
var requestData = new
{
    inputs = inputText, // Hugging Face API beklediği key: "inputs"
};

var json = JsonSerializer.Serialize(requestData);
var content = new StringContent(json, Encoding.UTF8, "application/json");

using var client = new HttpClient();
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);

var response = await client.PostAsync("https://api-inference.huggingface.co/models/facebook/bart-large-cnn", content);
var responseContent = await response.Content.ReadAsStringAsync();

Console.WriteLine($"Text Summarize: {responseContent}");