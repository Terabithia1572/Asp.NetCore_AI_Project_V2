using Newtonsoft.Json;
using System.Text;

class Program
{
    public static async Task Main(string[] args)
    {
        string apiKey= "api key burayagelecek"; // Open AI API key buraya gelecek
        Console.WriteLine("DALL-E ile resim oluşturma işlemi başlatılıyor..."); // Başlangıç mesajı
        string prompt=Console.ReadLine(); // Kullanıcıdan resim oluşturma isteği alınıyor
        using (HttpClient client=new())
        {
            client.DefaultRequestHeaders.Add("Authorization",$"Bearer {apiKey}");
            var requestBody = new
            {
                prompt = prompt,// Resim oluşturma isteği
                n = 1,// Resim sayısı
                size = "1024x1024" //Resim boyutu
            };
            string jsonBody=JsonConvert.SerializeObject(requestBody); // JSON formatına dönüştürülüyor
            var content = new StringContent(jsonBody, Encoding.UTF8, "application/json"); // İçerik oluşturuluyor
        }
    }
}