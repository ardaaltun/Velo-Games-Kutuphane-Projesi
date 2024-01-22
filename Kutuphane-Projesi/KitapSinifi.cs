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
        private int _kalanSure;

        public KitapSinifi(string baslik, string yazar, int isbn, int kopya_sayisi, int odunc_alinan_kopya, int kalanSure)
        {
            this._baslik = baslik;
            this._yazar = yazar;
            this._isbn = isbn;
            this._kopya_sayisi = kopya_sayisi;
            this._odunc_alinan_kopya = odunc_alinan_kopya;
            this._kalanSure = kalanSure;
        }

        public string Baslik { get{ return _baslik; } }
        public string Yazar { get{ return _yazar; } }
        public int ISBN { get{ return _isbn; } }
        public int KopyaSayisi { get{ return _kopya_sayisi; } set{ _kopya_sayisi = value;}}
        public int OduncKopya { get{ return _odunc_alinan_kopya; } set{ _odunc_alinan_kopya = value;}}

        public int KalanSure { get { return _kalanSure; } set { _kalanSure = value; } }
    }
}
