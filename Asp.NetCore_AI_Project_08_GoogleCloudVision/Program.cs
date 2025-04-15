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
            var client=ImageAnnotator
        }
        catch (Exception)
        {

            throw;
        }
    }
}