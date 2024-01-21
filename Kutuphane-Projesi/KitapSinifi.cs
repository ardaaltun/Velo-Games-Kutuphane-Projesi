using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kutuphane_Projesi
{
    public class KitapSinifi
    {
        private string _baslik;
        private string _yazar;
        private int _isbn;
        private int _kopya_sayisi;
        private int _odunc_alinan_kopya;

        public KitapSinifi(string baslik, string yazar, int isbn, int kopya_sayisi, int odunc_alinan_kopya)
        {
            Baslik = baslik;
            Yazar = yazar;
            _isbn = isbn;
            _kopya_sayisi = kopya_sayisi;
            _odunc_alinan_kopya = odunc_alinan_kopya;
        }

        public string Baslik { get{ return _baslik; } private set{ _baslik = value;}}
        public string Yazar { get{ return _yazar; } private set{ _yazar = value;}}
        public int ISBN { get{ return _isbn; } private set{ _isbn = value;}}
        public int KopyaSayisi { get{ return _kopya_sayisi; } private set{ _kopya_sayisi = value;}}
        public int OduncKopya { get{ return _odunc_alinan_kopya; } private set{ _odunc_alinan_kopya = value;}}
    }
}
