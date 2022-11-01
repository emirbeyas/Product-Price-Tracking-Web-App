using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;


namespace UrunTakip.Scrap
{
    public class ScrapIndex
    {

        public List<CekilenUrun> scrapFromn11Index()
        {
            string Url = "https://www.n11.com/super-firsatlar";

            List<CekilenUrun> n11Index = new List<CekilenUrun>();
            string UrunUrl, UrunAdi, ResimURL;
            double Fiyat;
            var document = new HtmlWeb().Load(Url);

            var urunler = document.DocumentNode.SelectNodes("//div[contains(@class,'dailyDealGroup')]//div[contains(@class,'listingGroup')]//div[contains(@class,'catalogView')]//ul//li[contains(@class,'column')]");
            if (urunler != null)
            {
                foreach (var item in urunler)
                {
                    Fiyat = Convert.ToDouble(item.SelectSingleNode("//input[contains(@class,'productDisplayPrice')]").Attributes["value"].Value);
                    UrunUrl = item.SelectSingleNode("//div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a").Attributes["href"].Value;
                    UrunAdi = item.SelectSingleNode("//div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a").Attributes["title"].Value;
                    ResimURL = item.SelectSingleNode("//div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a//img[contains(@class,'lazy')]").Attributes["src"].Value;
                    n11Index.Add(new CekilenUrun(UrunUrl, UrunAdi, "", ResimURL, Fiyat));
                }
            }

            return n11Index;
        }
    }
}