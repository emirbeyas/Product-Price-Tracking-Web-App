using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HtmlAgilityPack;

namespace UrunTakip.Scrap
{
    public class yorumlar
    {
        public string yorum;
        public string tarih;
        public yorumlar(string yorum, string tarih)
        {
            this.yorum = yorum;
            this.tarih = tarih;
        }
    }
    public class UrunDetay
    {
        public string UrunUrl, UrunAdi, Marka, ResimURL, DetayHTML, Satici, WebSitesi, DegerlendirmePuani;
        public double Fiyat;
        public int DegerlendirmeSayisi;
        public List<yorumlar> commentList = new List<yorumlar>();

        public UrunDetay(string Url, double Fiyat)
        {
            UrunUrl = Url;
            this.Fiyat = Fiyat;
            WebSitesi = Url.Split('.')[1];
            var document = new HtmlWeb().Load(Url);

            
            switch (WebSitesi)
            {
                case "trendyol":
                    var container = document.DocumentNode.SelectSingleNode("//div[contains(@class,'product-detail-container')]//div[contains(@class,'flex-container')]");
                    var rightcontainer = container.SelectSingleNode("div[contains(@class,'product-container')]//div[contains(@class,'container-right-content')]//div[contains(@class,'pr-in-w')]//div//div");

                    if (container.SelectSingleNode("div[contains(@class,'product-container')]//div[contains(@class,'gallery-container')]//div[contains(@class,'focused')]//img") != null)
                        ResimURL = container.SelectSingleNode("div[contains(@class,'product-container')]//div[contains(@class,'gallery-container')]//div[contains(@class,'focused')]//img").Attributes["src"].Value.ToString();

                    if (rightcontainer.SelectSingleNode("div//h1//span") != null)
                        UrunAdi = rightcontainer.SelectSingleNode("div//h1//span").InnerText;

                    if (rightcontainer.SelectSingleNode("div//h1//a") != null)
                        Marka = rightcontainer.SelectSingleNode("div//h1//a").InnerText;

                    if (rightcontainer.SelectSingleNode("div[contains(@class,'merchant-box-wrapper')]//a") != null)
                        Satici = rightcontainer.SelectSingleNode("div[contains(@class,'merchant-box-wrapper')]//a").InnerText;

                    if (rightcontainer.SelectSingleNode("//div[contains(@class,'pr-in-ratings')]//a[contains(@class,'rvw-cnt-tx')]") != null)
                        DegerlendirmeSayisi = Convert.ToInt32(rightcontainer.SelectSingleNode("//div[contains(@class,'pr-in-ratings')]//a[contains(@class,'rvw-cnt-tx')]").InnerText.Split(' ')[0]);    

                    break;
                case "gittigidiyor":
                    var containergittigidiyor = document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'boxContent')]");

                    if (containergittigidiyor.SelectSingleNode("div[contains(@id,'gallery')]//img[contains(@id,'big-photo')]") != null)
                        ResimURL = containergittigidiyor.SelectSingleNode("div[contains(@id,'gallery')]//img[contains(@id,'big-photo')]").Attributes["src"].Value;
                    
                    if (containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@class, 'title-container')]//h1") != null)
                        UrunAdi = containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@class, 'title-container')]//h1").InnerText;
                    
                    if (containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@class, 'title-container')]//h1") != null)
                        Marka = containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@class, 'title-container')]//h1").InnerText.Split(' ')[0];
                    
                    if (containergittigidiyor.SelectSingleNode("//div[contains(@id,'sellerPriceShippingKeyContainer')]//div[contains(@id,'seller-info')]//ul[contains(@class,'seller-info-content')]//li[contains(@class,'member-name')]//a//span[contains(@class,'member-nick')]") != null)
                        Satici = containergittigidiyor.SelectSingleNode("//div[contains(@id,'sellerPriceShippingKeyContainer')]//div[contains(@id,'seller-info')]//ul[contains(@class,'seller-info-content')]//li[contains(@class,'member-name')]//a//span[contains(@class,'member-nick')]").InnerText;

                    if (containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@id, 'review-brandSerial')]//div[contains(@class, 'catalog-review-title')]//a[contains(@class, 'catalog-review-link-small')]//div[contains(@class, 'catalog-point-container')]//strong") != null)
                        DegerlendirmePuani = containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@id, 'review-brandSerial')]//div[contains(@class, 'catalog-review-title')]//a[contains(@class, 'catalog-review-link-small')]//div[contains(@class, 'catalog-point-container')]//strong").InnerText.Trim();
                    
                    if (containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@id, 'review-brandSerial')]//div[contains(@class, 'catalog-review-title')]//a[contains(@class, 'catalog-review-link-small')]//div[contains(@class, 'catalog-point-container')]//span[contains(@class, 'catalog-review-count')]//span") != null)
                        DegerlendirmeSayisi = Convert.ToInt32(containergittigidiyor.SelectSingleNode("//div[contains(@id, 'badgeTitleReviewBrand')]//div[contains(@id, 'review-brandSerial')]//div[contains(@class, 'catalog-review-title')]//a[contains(@class, 'catalog-review-link-small')]//div[contains(@class, 'catalog-point-container')]//span[contains(@class, 'catalog-review-count')]//span").InnerText.Trim());


                    break;
                case "n11":
                    var containern11 = document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'proDetailArea')]");

                    if (containern11.SelectSingleNode("//div[contains(@class,'unf-p-img-box')]//div[contains(@class,'imgObj')]//a") != null)
                        ResimURL = containern11.SelectSingleNode("//div[contains(@class,'unf-p-img-box')]//div[contains(@class,'imgObj')]//a").Attributes["href"].Value;
                    
                    if (containern11.SelectSingleNode("//div[contains(@class,'unf-p-detail')]//div[contains(@class,'unf-p-title')]//div[contains(@class,'nameHolder')]//h1") != null)
                        UrunAdi = containern11.SelectSingleNode("//div[contains(@class,'unf-p-detail')]//div[contains(@class,'unf-p-title')]//div[contains(@class,'nameHolder')]//h1").InnerText.Trim();
                    
                    if (document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'unf-p-right')]//div[contains(@class,'main-seller')]//a") != null)
                        Satici = document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'unf-p-right')]//div[contains(@class,'main-seller')]//a").InnerText;

                    if (containern11.SelectSingleNode("//div[contains(@class,'unf-p-detail')]//div[contains(@class,'unf-p-title')]//div[contains(@class,'ratingCont')]//span[contains(@class,'ratingText')]//span[contains(@class,'reviewNum')]") != null)
                        DegerlendirmeSayisi = Convert.ToInt32(containern11.SelectSingleNode("//div[contains(@class,'unf-p-detail')]//div[contains(@class,'unf-p-title')]//div[contains(@class,'ratingCont')]//span[contains(@class,'ratingText')]//span[contains(@class,'reviewNum')]").InnerText);
                    
                    if (document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'unf-review')]//div[contains(@class,'unf-review-context')]//div[contains(@class,'panelContent')]//div[contains(@class,'commentHeader')]//div[contains(@class,'avarageRating')]//div[contains(@class,'avarageText')]") != null)
                        DegerlendirmePuani = document.DocumentNode.SelectSingleNode("//div[contains(@class,'container')]//div[contains(@class,'unf-review')]//div[contains(@class,'unf-review-context')]//div[contains(@class,'panelContent')]//div[contains(@class,'commentHeader')]//div[contains(@class,'avarageRating')]//div[contains(@class,'avarageText')]").InnerText.Remove(0,11).Split(' ')[0];

                    var yorumlarn11 = document.DocumentNode.SelectNodes("//div[contains(@class,'container')]//div[contains(@class,'unf-review')]//div[contains(@class,'unf-review-context')]//div[contains(@class,'panelContent')]//div[contains(@class,'holder')]//ul//li[contains(@class,'comment')]");
                    if (yorumlarn11 != null)
                    {
                        foreach (var item in yorumlarn11)
                        {
                            commentList.Add(new yorumlar(item.SelectSingleNode("p").InnerText, item.SelectSingleNode("//span[contains(@class,'commentDate')]").InnerText.Trim()));
                        }
                    }
                   
                    break;
            }
        }
    }
}