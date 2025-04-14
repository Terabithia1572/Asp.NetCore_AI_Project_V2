using Tesseract;

class Program { 
static void Main(string[] args)
{
    Console.WriteLine("Karakter Okuması Yapılacak Resim Yolu:");
    string imagePath = Console.ReadLine(); // Kullanıcıdan resim yolu alınıyor
    Console.WriteLine("Tesseract Veri Yolu:");
    string tessdataPath = @"C:\tessdata"; // Tesseract veri yolu

    try
    {
        using (var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default)) // Tesseract motoru başlatılıyor
        {
            using (var img = Pix.LoadFromFile(imagePath)) // Resim dosyası yükleniyor
            {
                using (var page = engine.Process(img)) //Resim İşleniyor
                {
                    string text = page.GetText(); // Resimden metin okunuyor
                    Console.WriteLine("Okunan Metin:");
                    Console.WriteLine(text); // Okunan metin ekrana yazdırılıyor
                }
            }
        }
    }
    catch (Exception)
    {

       Console.WriteLine("Hata: Resim dosyası bulunamadı veya Tesseract veri yolu hatalı."); // Hata mesajı
    }
}
}