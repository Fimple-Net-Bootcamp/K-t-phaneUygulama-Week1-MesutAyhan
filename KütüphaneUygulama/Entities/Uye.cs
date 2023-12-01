namespace KütüphaneUygulama.Entities
{
    public class Uye
    {
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public int UyeNo { get; set; }
        public List<Kitap> KiradakiKitaplar { get; set; }

        public Uye()
        {
            KiradakiKitaplar = new List<Kitap>();
        }
    }
}
