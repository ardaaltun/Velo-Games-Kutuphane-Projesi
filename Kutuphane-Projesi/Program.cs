using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Kutuphane_Projesi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool bitti = false;
            bool anamenu = true;
            int secim;
            KutuphaneSinifi kutuphane = new KutuphaneSinifi();
            KitapSinifi k1 = new KitapSinifi("Ardanin Hayati", "Arda Altun", 0001, 3, 0);
            kutuphane.KitapEkle(k1);

            while (!bitti)
            {
                if(anamenu)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Kitap Ekle");
                    Console.WriteLine("2. Kitap Detay Goster");
                    Console.WriteLine("3. Butun Kitaplari Listele");
                    Console.WriteLine("4. Programi Kapat");

                    Console.Write("Secim: (1-4): ");
                }
                

                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        // Kitap Ekle
                        case 1:
                            anamenu = false;
                            Console.WriteLine("KITAP EKLE");
                            Console.WriteLine("------------------------");

                            Console.Write("Kitap Ismini Girin: ");
                            string kitapIsim = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("Yazar Ismini Girin: ");
                            string yazarIsim = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("ISBN No Girin: ");
                            int isbnNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Kopya Sayisi Girin: ");
                            int kopyasay = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Odunc Sayisi Girin: ");
                            int oduncsay = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            KitapSinifi kitap = new KitapSinifi(kitapIsim, yazarIsim, isbnNo, kopyasay, oduncsay);
                            kutuphane.KitapEkle(kitap);

                            Console.WriteLine("Kitap basariyla eklendi... Ana menuye yonlendiriliyorsunuz...");
                            anamenu = true;
                            break;


                        // Kitap detayi
                        case 2:
                            Console.WriteLine("KITAP DETAYI");
                            Console.WriteLine("------------------------");
                            kutuphane.TumKitaplariGoruntule();
                            break;

                        // Tum kitaplari yazdir
                        case 3:
                            Console.WriteLine("BUTUN KITAPLARI GORUNTULE");
                            Console.WriteLine("------------------------");
                            break;
                        
                            //Cikis
                        case 4:
                            Console.WriteLine("Cikis yapiliyor...");
                            Thread.Sleep(1200);
                            bitti = true;
                            return;
                        default:
                            Console.WriteLine("Gecersiz menu numarasi, lutfen belirtilen seceneklerden birini secin.");
                            break;
                    }
                }

                else
                {
                    Console.WriteLine("Gecersiz menu numarasi, lutfen belirtilen seceneklerden birini secin.");
                }

                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
