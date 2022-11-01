using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrunTakip.Scrap
{
    public class CekilenUrun
    {
        public string UrunUrl, UrunAdi, Marka, ResimURL;
        public double Fiyat;

        public CekilenUrun(string UrunUrl, string UrunAdi, string Marka, string ResimURL, double Fiyat)
        {
            this.UrunUrl = UrunUrl;
            this.UrunAdi = UrunAdi;
            this.Marka = Marka;
            this.ResimURL = ResimURL;
            this.Fiyat = Fiyat;

        }
        
    }
}