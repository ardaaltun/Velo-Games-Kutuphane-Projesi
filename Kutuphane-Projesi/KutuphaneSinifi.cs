using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Projesi
{
    public class KutuphaneSinifi
    {
        private static KutuphaneSinifi _kutuphane = null;
        public static KutuphaneSinifi Kutuphane
        {
            get
            {
                if (_kutuphane == null)
                {
                    _kutuphane = new KutuphaneSinifi();
                }
                return _kutuphane;
            }
        }
        static List<KitapSinifi> kitaplar = new List<KitapSinifi>();

        public void TumKitaplariGoruntule()
        {
            foreach (KitapSinifi k in kitaplar)
            {
                KitapDetay(k);
            }
        }

        public void KitapDetay(KitapSinifi kitap)
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Kitabin Adi:     " + kitap.Baslik);
            Console.WriteLine("Kitabin Yazari:  " + kitap.Yazar);
            Console.WriteLine("ISBN No:         " + kitap.ISBN.ToString("0000"));
            Console.WriteLine("Kopya Sayisi:    " + kitap.KopyaSayisi);
            Console.WriteLine("Odunc Kitap No:  " + kitap.OduncKopya);
            Console.WriteLine("----------------------------------");
        }

        public void KitapEkle(KitapSinifi kitap)
        {
            kitaplar.Add(kitap);
        }
    }
}
