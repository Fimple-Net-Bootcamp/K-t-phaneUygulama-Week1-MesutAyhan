using KütüphaneUygulama.Entities;

namespace KütüphaneUygulama.Interfaces
{
    public interface IKutuphane
    {
        void KitapEkle(Kitap kitap);
        void KitapSil(int kitapID);
        void KitapKirala(Uye uye, Kitap kitap);
        void KitapIadeAl(Uye uye, Kitap kitap);
    }
}
