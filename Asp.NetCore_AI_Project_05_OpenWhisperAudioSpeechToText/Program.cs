using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "api key buraya gelecek"; //Open AI API key buraya gelecek
        string audioFilePath = "audio1.mp3"; // Ses dosyasının yolu

        using (var client=new HttpClient()) // HttpClient nesnesi oluşturuluyor
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey); // Open AI API key buraya gelecek
            var form = new MultipartFormDataContent(); // MultipartFormDataContent nesnesi oluşturuluyor
            var audioContent = new ByteArrayContent(File.ReadAllBytes(audioFilePath)); // Ses dosyası okunuyor
            audioContent.Headers.ContentType=MediaTypeHeaderValue.Parse("audio/mpeg"); // Ses dosyasının içeriği ayarlanıyor
            form.Add(audioContent, "file", Path.GetFileName(audioFilePath)); // Ses dosyası form verisine ekleniyor
            form.Add(new StringContent("whisper-1"), "model"); // Model adı ekleniyor

            Console.WriteLine("Ses dosyası yükleniyor..."); // Yükleme işlemi başlatılıyor
            var response = await client.PostAsync("https://api.openai.com/v1/audio/transcriptions", form); // Ses dosyası OpenAI API'ye gönderiliyor
            if (response.IsSuccessStatusCode) // Eğer yanıt başarılıysa
            {
                var result = await response.Content.ReadAsStringAsync(); // Yanıt içeriği okunuyor
                Console.WriteLine("Yanıt: " + result); // Yanıt ekrana yazdırılıyor
            }
            else // Eğer yanıt başarısızsa
            {
                Console.WriteLine("Hata: " + response.StatusCode); // Hata durumu ekrana yazdırılıyor
            }
        }
    }
}