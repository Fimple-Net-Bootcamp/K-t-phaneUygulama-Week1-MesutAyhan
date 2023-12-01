using KütüphaneUygulama.Interfaces;

namespace KütüphaneUygulama.Entities
{
    public class Kutuphane : IKutuphane, IYazdirilabilir
    {
        private List<Kitap> kitaplar;
        public List<Uye> uyeler;
        private List<Kitap> kiralanmisKitaplar;
        private List<Kitap> kutuphanekiKitaplar;

        public Kutuphane()
        {
            kitaplar = new List<Kitap>();
            uyeler = new List<Uye>();
            kiralanmisKitaplar = new List<Kitap>();
            kutuphanekiKitaplar = new List<Kitap>();
        }

        public void UyeEkle(Uye uye)
        {
            uyeler.Add(uye);
        }
        public void KitapEkle(Kitap kitap)
        {
            kitaplar.Add(kitap);
            kutuphanekiKitaplar.Add(kitap);
        }

        public void KitapSil(int kitapID)
        {
            Kitap Silinecek = kitaplar.FirstOrDefault(kitap => kitap.KitapID == kitapID);
            kitaplar.Remove(Silinecek);
            kutuphanekiKitaplar.Remove(Silinecek);
            kiralanmisKitaplar.Remove(Silinecek);
        }

        public void KitapKirala(Uye uye, int kitapID)
        {
            Kitap kiralanacakKitap = kutuphanekiKitaplar.Find(kitap => kitap.KitapID == kitapID);

            if (kiralanacakKitap != null && uye != null && !uye.KiradakiKitaplar.Contains(kiralanacakKitap) && uye.KiradakiKitaplar.Count < 3)
            {

                Kitap Kiralanacak = kitaplar.FirstOrDefault(kitap => kitap.KitapID == kitapID);
                uye.KiradakiKitaplar.Add(kiralanacakKitap);
                kitaplar.Remove(Kiralanacak);
                kutuphanekiKitaplar.Remove(Kiralanacak);
                kiralanmisKitaplar.Add(Kiralanacak);
                Console.WriteLine($"{kiralanacakKitap.Adi} kitabı {uye.Adi} {uye.Soyadi}'ye kiralandı.");
            }
            else if (uye.KiradakiKitaplar.Count >= 3)
            {
                Console.WriteLine($"{uye.Adi} {uye.Soyadi} zaten 3 kitap kiralamış durumda.");
            }
            else
            {
                Console.WriteLine("Kitap kiralanamadı.");
            }
        }

        public void KitapIadeAl(Uye uye, int kitapID)
        {
            Kitap iadeEdilecekKitap = uye.KiradakiKitaplar.Find(kitap => kitap.KitapID == kitapID);

            if (iadeEdilecekKitap != null)
            {
                uye.KiradakiKitaplar.Remove(iadeEdilecekKitap);
                kutuphanekiKitaplar.Add(iadeEdilecekKitap);
                kiralanmisKitaplar.Remove(iadeEdilecekKitap);
                Console.WriteLine($"{iadeEdilecekKitap.Adi} kitabı {uye.Adi} {uye.Soyadi}'den iade alındı.");
            }
            else
            {
                Console.WriteLine("Kitap bulunamadı.");
            }
        }

        public void Yazdir()
        {
            Console.WriteLine("Kitaplar:");
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede boşta olan kitap bulunmamaktadır.");
            }
            else
            {
                foreach (var kitap in kitaplar)
                {
                    Console.WriteLine($"{kitap.KitapID} - {kitap.Adi} - {kitap.Yazar} - {kitap.YayinYili}");
                }
            }

            Console.WriteLine("\nÜyeler:");
            if (uyeler.Count == 0)
            {
                Console.WriteLine("Kütüphaneye üye kaydı bulunmamaktadır.");
            }
            else
            {
                foreach (var uye in uyeler)
                {
                    Console.WriteLine($"{uye.UyeNo} - {uye.Adi} {uye.Soyadi}");
                    Console.WriteLine("Kiraladığı Kitaplar:");
                    if (uye.KiradakiKitaplar.Count == 0)
                    {
                        Console.WriteLine("Üyenin kiraladığı kitap bulunmamaktadır.");
                    }
                    else
                    {
                        foreach (var kiraladigiKitap in uye.KiradakiKitaplar)
                        {
                            Console.WriteLine($"{kiraladigiKitap.Adi}");
                        }
                    }
                    Console.WriteLine("-------------");
                }
            }

            Console.WriteLine("\nKiralanmış Kitaplar:");
            if (kiralanmisKitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kiralanmış kitap bulunmamaktadır.");
            }
            else
            {
                foreach (var kiralanmisKitap in kiralanmisKitaplar)
                {
                    Console.WriteLine($"{kiralanmisKitap.KitapID} - {kiralanmisKitap.Adi} - {kiralanmisKitap.Yazar} - {kiralanmisKitap.YayinYili}");
                }
            }

            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            if (kutuphanekiKitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kullanılmayan kitap bulunmamaktadır.");
            }
            else
            {
                foreach (var kutuphanedekiKitap in kutuphanekiKitaplar)
                {
                    Console.WriteLine($"{kutuphanedekiKitap.KitapID} - {kutuphanedekiKitap.Adi} - {kutuphanedekiKitap.Yazar} - {kutuphanedekiKitap.YayinYili}");
                }
            }
        }
        public void KitaplariYazdir()
        {
            Console.WriteLine("Kitaplar:");
            if (kitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede boşta olan kitap bulunmamaktadır.");
            }
            else
            {
                foreach (var kitap in kitaplar)
                {
                    Console.WriteLine($"{kitap.KitapID} - {kitap.Adi} - {kitap.Yazar} - {kitap.YayinYili}");
                }
            }

            Console.WriteLine("\nKütüphanedeki Kitaplar:");
            if (kutuphanekiKitaplar.Count == 0)
            {
                Console.WriteLine("Kütüphanede kullanılmayan kitap bulunmamaktadır.");
            }
            else
            {
                foreach (var kutuphanedekiKitap in kutuphanekiKitaplar)
                {
                    Console.WriteLine($"{kutuphanedekiKitap.KitapID} - {kutuphanedekiKitap.Adi} - {kutuphanedekiKitap.Yazar} - {kutuphanedekiKitap.YayinYili}");
                }
            }
        }

        public void KitapKirala(Uye uye, Kitap kitap)
        {
            throw new NotImplementedException();
        }

        public void KitapIadeAl(Uye uye, Kitap kitap)
        {
            throw new NotImplementedException();
        }
    }
}
