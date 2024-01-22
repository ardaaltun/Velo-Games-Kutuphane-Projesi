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

        public List<KitapSinifi> Kitaplar { get { return kitaplar; } }

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
            Console.WriteLine("Kitabin Adi:              " + kitap.Baslik);
            Console.WriteLine("Kitabin Yazari:           " + kitap.Yazar);
            Console.WriteLine("ISBN No:                  " + kitap.ISBN.ToString("0000"));
            Console.WriteLine("Kopya Sayisi:             " + kitap.KopyaSayisi);
            Console.WriteLine("Odunc Verilmis Kitap No:  " + kitap.OduncKopya);
            Console.WriteLine("Kalan Iade Suresi (Gun):  " + kitap.KalanSure);
            Console.WriteLine("----------------------------------");
        }

        public void KitapEkle(KitapSinifi kitap)
        {
            kitaplar.Add(kitap);
        }

        public void KitapIade(KitapSinifi kitap)
        {
            if (kitap.OduncKopya > 0)
            {
                kitap.KopyaSayisi += 1;
                kitap.OduncKopya -= 1;
                kitap.KalanSure = 14; //14 gun iade suresi
                Console.WriteLine("Kitap basariyla iade edildi...");
            }
            else
            {
                Console.WriteLine("Kitap odunc verilemedi... Bu kitap zaten hic verilmemis...");
            }
        }

        public void KitapOdunc(KitapSinifi kitap)
        {
            if (kitap.KopyaSayisi > 0)
            {
                Console.WriteLine("Kitap odunc alindi...");
                kitap.KopyaSayisi -= 1;
                kitap.OduncKopya += 1;
                kitap.KalanSure = 14;
            }
            else
            {
                Console.WriteLine("Kitap odunc alinamadi... Bu kitap stoklarimizda kalmamistir...");
            }
        }

        public void KitapKalanSure(KitapSinifi kitap)
        {
            Console.WriteLine("Kalan iade suresi: ", kitap.KalanSure);
        }
    }
}
