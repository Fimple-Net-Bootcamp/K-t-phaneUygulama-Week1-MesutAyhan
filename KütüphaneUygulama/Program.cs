using KütüphaneUygulama.Entities;
class Program
{
    static void Main()
    {
        Random random = new Random();
        
        Kutuphane kutuphane = new Kutuphane();

        Kitap kitap1 = new Kitap
        {
            Adi = "Oblomov",
            Yazar = " İvan Gonçarov",
            YayinYili = 1859,
            KitapID = random.Next(1, 999)
    };

        Kitap kitap2 = new Kitap
        {
            Adi = "Beyaz Diş",
            Yazar = "Jack London",
            YayinYili = 1906,
            KitapID = random.Next(1, 999)
};

        Kitap kitap3 = new Kitap
        {
            Adi = "Bir İdam Mahkûmunun Son Günü",
            Yazar = "Victor Hugo",
            YayinYili = 1829,
            KitapID = random.Next(1, 999)
        };
        Kitap kitap4 = new Kitap
        {
            Adi = "Saatleri Ayarlama Enstitüsü",
            Yazar = "Ahmet Hamdi Tanpınar",
            YayinYili = 1961,
            KitapID = random.Next(1, 999)
        };
        Kitap kitap5 = new Kitap
        {
            Adi = "Sinekli Bakkal",
            Yazar = "Halide Edip Adıvar",
            YayinYili = 1936,
            KitapID = random.Next(1, 999)
        };

        Uye uye1 = new Uye
        {
            Adi = "Yusuf",
            Soyadi = "Kül",
            UyeNo = 101
        };

        Uye uye2 = new Uye
        {
            Adi = "Selim",
            Soyadi = "Aç",
            UyeNo = 102
        };
        Uye uye3 = new Uye
        {
            Adi = "Zafer",
            Soyadi = "Bilgili",
            UyeNo = 103
        };

        kutuphane.KitapEkle(kitap1);
        kutuphane.KitapEkle(kitap2);
        kutuphane.KitapEkle(kitap3);
        kutuphane.KitapEkle(kitap4);
        kutuphane.KitapEkle(kitap5);
        kutuphane.UyeEkle(uye1);
        kutuphane.UyeEkle(uye2);
        kutuphane.UyeEkle(uye3);
       

        //kutuphane.Yazdir();

        while (true) 
        {
            Console.WriteLine("Menu");
            Console.WriteLine("0.Çıkış Yap");
            Console.WriteLine("1.Kitap Ekle");
            Console.WriteLine("2.Kitap Sil");
            Console.WriteLine("3.Kitap Kirala");
            Console.WriteLine("4.Üye Ekle");
            Console.WriteLine("5.Tüm Bilgiler");
            Console.Write("Seçiniz: ");
            string Secim = Console.ReadLine();
            string kitapID;
            string uyeNo = Console.ReadLine();
            switch (Secim) {
                case "0": 
                    Console.WriteLine("Çıkış Yaptınız");
                    return;
                case "1":
                    kutuphane.Yazdir();
                    Console.WriteLine("Kitap Ekle'yi Seçtiniz");
                    Console.Write("Kitap Adı: ");
                    string kitapAdi = Console.ReadLine();
                    Console.Write("Kitabın Yazarı: ");
                    string kitapYazari = Console.ReadLine();
                    Console.Write("Yayın Yılı: ");
                    string yayinYili = Console.ReadLine();
                    Kitap yeniKitap = new Kitap
                    {
                        Adi = kitapAdi,
                        Yazar = kitapYazari,
                        YayinYili = int.Parse(yayinYili),
                        KitapID = random.Next(1, 999),
                    };
                    kutuphane.KitapEkle(yeniKitap);
                    kutuphane.Yazdir();
                    break;
                case "2":
                    kutuphane.KitaplariYazdir();
                    Console.WriteLine("Kitap Sil'i Seçtiniz");
                    Console.Write("Silinecek olan kitabın ID'sini giriniz: ");
                    kitapID = Console.ReadLine();
                    kutuphane.KitapSil(int.Parse(kitapID));
                    kutuphane.KitaplariYazdir();
                    break;
                case "3":
                    kutuphane.KitaplariYazdir();
                    Console.WriteLine("Kitap Kirala'yı Seçtiniz");
                    Console.Write("Kitap kiralamak için üye no'nuzu giriniz: ");
                    uyeNo =(Console.ReadLine());
                    var member = kutuphane.uyeler.Find(x => x.UyeNo == int.Parse(uyeNo));
                    if (member != null)
                    {
                        Console.Write("Kiralamak istediğiniz kitabın ID'sini giriniz: ");
                        kitapID = Console.ReadLine();
                        kutuphane.KitapKirala(member, int.Parse(kitapID));
                    }
                    else
                        Console.WriteLine("Üye Bulunamadı!");
                    break;
                case "4":
                    Console.Write("Adınızı Giriniz: ");
                    string uyeAdi = Console.ReadLine();
                    Console.Write("Soyadınızı Giriniz: ");
                    string uyeSoyadi = Console.ReadLine();
                    Uye yeniUye = new Uye
                    {
                        Adi = uyeAdi,
                        Soyadi = uyeSoyadi,
                        UyeNo = random.Next(1, 999),
                    };
                    kutuphane.UyeEkle(yeniUye);
                    kutuphane.Yazdir();
                    break;
                case "5":
                    kutuphane.Yazdir();
                    break;
                default:
                    Console.WriteLine("Geçersiz Seçim Yaptınız");
                    break;

            }
        }
    }
}
