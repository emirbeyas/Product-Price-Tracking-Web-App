using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace UrunTakip.Scrap
{
    public class Scrap
    {
        public List<CekilenUrun> scrapFromTrendyol(string arananUrun)
        {
            string Url = "https://www.trendyol.com/sr?q=" + arananUrun.Replace(' ', '+');


            List<CekilenUrun> trendyolurunler = new List<CekilenUrun>();

            var document = new HtmlWeb().Load(Url);

            string UrunUrl, UrunAdi, Marka, ResimURL;
            double Fiyat;

            var urunler = document.DocumentNode.SelectNodes("//div[contains(@class,'p-card-wrppr')]");
            if (urunler != null)
            {
                foreach (var item in urunler)
                {
                    UrunUrl = "https://www.trendyol.com" + item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a").Attributes["href"].Value;
                    ResimURL = "https://www.trendyol.com" + item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'image-container')]//div[contains(@class,'p-card-img-wr')]//img").Attributes["src"].Value;
                    UrunAdi = item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'prdct-desc-cntnr')]//div[contains(@class,'prdct-desc-cntnr-ttl-w')]//span[2]").InnerText;
                    Marka = item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'prdct-desc-cntnr')]//div[contains(@class,'prdct-desc-cntnr-ttl-w')]//span[1]").InnerText;

                    if (item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'price-promotion-container')]//div[contains(@class,'prmtn-cntnr')]//div//div[contains(@class,'prc-box-dscntd')]") != null)
                    {
                        Fiyat = Convert.ToDouble(item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'price-promotion-container')]//div[contains(@class,'prmtn-cntnr')]//div//div[contains(@class,'prc-box-dscntd')]").InnerText.Split(' ')[0]);

                    }
                    else if (item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'price-promotion-container')]//div[contains(@class,'prc-cntnr')]//div") != null)
                    {
                        Fiyat = Convert.ToDouble(item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//a//div[contains(@class,'prdct-desc-cntnr-wrppr')]//div[contains(@class,'price-promotion-container')]//div[contains(@class,'prc-cntnr')]//div").InnerText.Split(' ')[0]);

                    }
                    else if (item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//div[contains(@class,'product-price')]//div[contains(@class,'pr-bx-dsc')]//div[contains(@class,'prc-box-dscntd')]") != null)
                    {
                        Fiyat = Convert.ToDouble(item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//div[contains(@class,'product-price')]//div[contains(@class,'pr-bx-dsc')]//div[contains(@class,'prc-box-dscntd')]").InnerText.Split(' ')[0]);
                    }
                    else if (item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//div[contains(@class,'product-price')]//div[contains(@class,'prc-box-sllng')]") != null)
                    {
                        Fiyat = Convert.ToDouble(item.SelectSingleNode("div[contains(@class,'p-card-chldrn-cntnr')]//div[contains(@class,'product-price')]//div[contains(@class,'prc-box-sllng')]").InnerText.Split(' ')[0]);

                    }
                    else
                    {
                        Fiyat = 0;
                    }

                    trendyolurunler.Add(new CekilenUrun(UrunUrl, UrunAdi, Marka, ResimURL, Fiyat));
                }
            }
            
            return trendyolurunler;
        }
        public List<CekilenUrun> scrapFromGittigidiyor(string arananUrun)
        {
            string Url = "https://www.gittigidiyor.com/arama/?k=" + arananUrun.Replace(' ', '+');


            List<CekilenUrun> gittigidiyorUrunler = new List<CekilenUrun>();

            var document = new HtmlWeb().Load(Url);

            string UrunUrl, UrunAdi, Marka, ResimURL;
            double Fiyat;

            var urunler = document.DocumentNode.SelectNodes("//div[contains(@class,'fbkkZW')]//div[contains(@class,'dTGwmm')]//div[contains(@class,'gyNBA')]//div[contains(@class,'jCCkZh')]//ul//li");
            if (urunler != null)
            {
                foreach (var item in urunler)
                {
                    UrunUrl = item.SelectSingleNode("article[contains(@class,'product-card')]//a").Attributes["href"].Value;
                    ResimURL = item.SelectSingleNode("article[contains(@class,'product-card')]//a//section[contains(@class,'product-card__image')]//img").Attributes["src"].Value;
                    UrunAdi = item.SelectSingleNode("article[contains(@class,'product-card')]//a//header//hgroup//h3").InnerText;
                    Marka = item.SelectSingleNode("article[contains(@class,'product-card')]//a//header//hgroup//h3").InnerText.Split(' ')[0];
                    Fiyat = Convert.ToDouble(item.SelectSingleNode("article[contains(@class,'product-card')]//a//section[contains(@class,'price')]//span[contains(@class,'buy-price')]").InnerText.Trim().Split(' ')[0]);

                    gittigidiyorUrunler.Add(new CekilenUrun(UrunUrl, UrunAdi, Marka, ResimURL, Fiyat));
                }
            }
            
            return gittigidiyorUrunler;
        }
        public List<CekilenUrun> scrapFromN11(string arananUrun)
        {
            string Url = "https://www.n11.com/arama?q=" + arananUrun.Replace(' ', '+');

            List<CekilenUrun> N11Urunler = new List<CekilenUrun>();

            var document = new HtmlWeb().Load(Url);

            string UrunUrl, UrunAdi, Marka, ResimURL;
            double Fiyat;

            var urunler = document.DocumentNode.SelectNodes("//div[contains(@class,'productArea')]//section[contains(@class,'resultListGroup')]//div[contains(@id,'view')]//ul//li[contains(@class,'column')]");
            if (urunler != null)
            {
                foreach (var item in urunler)
                {
                    UrunUrl = item.SelectSingleNode("div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a").Attributes["href"].Value;
                    ResimURL = item.SelectSingleNode("div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a//img").Attributes["data-original"].Value;
                    UrunAdi = item.SelectSingleNode("div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a//h3[contains(@class,'productName')]").InnerText.Trim();
                    Marka = item.SelectSingleNode("div[contains(@class,'columnContent')]//div[contains(@class,'pro')]//a//h3[contains(@class,'productName')]").InnerText.Trim().Split(' ')[0];
                    Fiyat = Convert.ToDouble(item.SelectSingleNode("div[contains(@class,'columnContent')]//div[contains(@class,'proDetail')]//span[contains(@class,'newPrice')]//ins").InnerText.Split(' ')[0]);

                    N11Urunler.Add(new CekilenUrun(UrunUrl, UrunAdi, Marka, ResimURL, Fiyat));
                }
            }
           
            return N11Urunler;
        }

    }
}