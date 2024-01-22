using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
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
            KitapSinifi k1 = new KitapSinifi("Ardanin Hayati", "Arda Altun", 0001, 3, 0, 14);
            KitapSinifi k2= new KitapSinifi("Arabalar", "Reco eko", 0002, 5, 0, 14);
            KitapSinifi k3= new KitapSinifi("gezegenler", "newton", 000, 33, 11, 14);

            kutuphane.KitapEkle(k1);
            kutuphane.KitapEkle(k2);
            kutuphane.KitapEkle(k3);

            while (!bitti)
            {
                if(anamenu)
                {
                    Console.WriteLine("Menu:");
                    Console.WriteLine("1. Kitap Ekle");
                    Console.WriteLine("2. Kitap Arama");
                    Console.WriteLine("3. Tum Kitaplari Listele");
                    Console.WriteLine("4. Kitap Odunc Alma");
                    Console.WriteLine("5. Kitap Iade Etme");
                    Console.WriteLine("6. Programi Kapat");

                    Console.Write("Secim: (1-6): ");
                }
                

                if (int.TryParse(Console.ReadLine(), out secim))
                {
                    switch (secim)
                    {
                        // Kitap Ekle
                        case 1:
                            Console.Clear();
                            anamenu = false;
                            Console.WriteLine("KITAP EKLE");
                            Console.WriteLine("------------------------");

                            Console.Write("Kitap Ismini Girin (Iptal icin Q'ya basin): ");
                            string kitapIsim = Console.ReadLine();
                            Console.WriteLine();
                            if(kitapIsim.ToLower() == "q") { Console.Clear(); anamenu = true; break; }
                            Console.Write("Yazar Ismini Girin: ");
                            string yazarIsim = Console.ReadLine();
                            Console.WriteLine();

                            Console.Write("ISBN No Girin (4 hane) ");
                            int isbnNo = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Kopya Sayisi Girin: ");
                            int kopyasay = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            Console.Write("Odunc Sayisi Girin: ");
                            int oduncsay = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            KitapSinifi kitap = new KitapSinifi(kitapIsim, yazarIsim, isbnNo, kopyasay, oduncsay, 14);
                            kutuphane.KitapEkle(kitap);

                            Console.WriteLine("Kitap basariyla eklendi... Ana menuye yonlendiriliyorsunuz...");
                            anamenu = true;
                            break;


                        // Kitap ara (ilk karsilastigi kitabi dondurur, ayni isimli yazar olursa yazilacak algoritmayi yazmaya ugrasmadim basic c# bilgisi olculdugu icin)
                        case 2:
                            Console.Clear();
                            Console.WriteLine("KITAP ARA");
                            Console.WriteLine("------------------------");
                            Console.Write("Kitap Ismi veya Yazar ismi Girin (Iptal icin Q'ya basin: ");
                            string isim = Console.ReadLine().ToLower();
                            if (isim.ToLower() == "q") { Console.Clear(); anamenu = true; break; }
                            else
                            {
                                bool buldu = false;
                                foreach (KitapSinifi k in kutuphane.Kitaplar)
                                {
                                    if (k.Baslik.ToLower().Contains(isim) || k.Yazar.ToLower().Contains(isim))
                                    {
                                        kutuphane.KitapDetay(k);
                                        anamenu = true;
                                        buldu = true;
                                        break;
                                    }
                                    
                                }
                                if(!buldu)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Kitap bulunamadi!!!");
                                    Console.WriteLine("------------------------");
                                    anamenu = true;
                                }
                                
                            }
                            
                            break;

                        // Tum kitaplari yazdir
                        case 3:
                            Console.Clear();
                            Console.WriteLine("BUTUN KITAPLARI GORUNTULE");
                            Console.WriteLine("------------------------");
                            kutuphane.TumKitaplariGoruntule();
                            break;
                        case 4:
                            Console.Clear();
                            Console.WriteLine("KITAP ODUNC ALMA");
                            Console.WriteLine("------------------------");
                            Console.Write("Odunc Alinacak Kitap Ismini Girin (Iptal icin Q'ya basin: ");
                            string odunc = Console.ReadLine().ToLower();
                            if (odunc.ToLower() == "q") { Console.Clear(); anamenu = true; break; }
                            else
                            {
                                bool buldu = false;
                                foreach (KitapSinifi k in kutuphane.Kitaplar)
                                {
                                    if (k.Baslik.ToLower().Contains(odunc) || k.Yazar.ToLower().Contains(odunc))
                                    {
                                        Console.Clear();
                                        kutuphane.KitapOdunc(k);
                                        Console.WriteLine("------------------------");
                                        Console.WriteLine("Odunc Alinan Kitap Bilgisi: ");
                                        kutuphane.KitapDetay(k);
                                        anamenu = true;
                                        buldu = true;
                                        break;
                                    }
                                }
                                if(!buldu)
                                {
                                    Console.Clear();
                                    anamenu = true;
                                    Console.WriteLine("Girilen veriye dair kitap bulunamadi!");
                                    Console.WriteLine("------------------------");
                                }
                                
                            }
                            
                            break;
                        case 5:
                            Console.Clear();
                            Console.WriteLine("KITAP IADE ETME");
                            Console.WriteLine("------------------------");
                            Console.Write("Odunc Verilecek Kitap Ismini Girin (Iptal icin Q'ya basin: ");
                            string iade = Console.ReadLine().ToLower();
                            if (iade.ToLower() == "q") { Console.Clear(); anamenu = true; break; }
                            else
                            {
                                bool buldu = false;
                                foreach (KitapSinifi k in kutuphane.Kitaplar)
                                {
                                    if (k.Baslik.ToLower().Contains(iade) || k.Yazar.ToLower().Contains(iade))
                                    {
                                        Console.Clear();
                                        kutuphane.KitapIade(k);
                                        Console.WriteLine("------------------------");
                                        Console.WriteLine("Odunc Verilen Kitap Bilgisi: ");
                                        kutuphane.KitapDetay(k);
                                        anamenu = true;
                                        buldu = true;
                                        break;
                                    }
                                }
                                if(!buldu)
                                {
                                    Console.Clear();
                                    anamenu = true;
                                    Console.WriteLine("Girilen veriye dair kitap bulunamadi!");
                                    Console.WriteLine("------------------------");
                                }
                                

                            }
                            
                            break;

                        //Cikis
                        case 6:
                            Console.Clear();
                            Console.WriteLine("Cikis yapiliyor...");
                            Thread.Sleep(1200);
                            bitti = true;
                            return;
                        default:
                            Console.Clear();
                            Console.WriteLine("Gecersiz menu numarasi, lutfen belirtilen seceneklerden birini secin.");
                            break;
                    }
                }

                else
                {
                    Console.Clear();
                    Console.WriteLine("Gecersiz menu numarasi, lutfen belirtilen seceneklerden birini secin.");
                }

                Console.WriteLine();
            }


            Console.ReadKey();
        }
    }
}
