using Google.Cloud.Vision.V1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Google Cloud Vision API ile Karakter Okuması Yapılacak Resim Yolu:");
        string imagePath = Console.ReadLine(); // Kullanıcıdan resim yolu alınıyor

        string credentialPath = "buraya servis json dosyası gelecek";
        Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialPath); // Google Cloud kimlik bilgileri ayarlanıyor
        try
        {
            var client=ImageAnnotatorClient.Create(); // Google Cloud Vision istemcisi oluşturuluyor
            var image = Image.FromFile(imagePath); // Resim dosyası yükleniyor
            var response = client.DetectText(image); // Resimden metin tespiti yapılıyor
            Console.WriteLine("Okunan Metin:");
            foreach (var annotation in response)
            {
                Console.WriteLine(annotation.Description); // Okunan metin ekrana yazdırılıyor
            }
        }
        catch (Exception)
        {

          Console.WriteLine("Hata: Resim dosyası bulunamadı veya Google Cloud kimlik bilgileri hatalı."); // Hata mesajı
        }
    }
}