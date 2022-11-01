import requests
from bs4 import BeautifulSoup
import datetime
import lxml


def scrap(url, urunAdi):
    website = url.split(".")[1]

    if website == "n11":
        urlFromSql = url
        url = "https://www.n11.com/arama?q=" + urunAdi.replace(" ", "+")

    r = requests.get(url)
    soup = BeautifulSoup(r.content, "lxml")

    if website == "trendyol":
        st = soup.find("div", attrs={"class": "flex-container"})
        st1 = st.find("div", attrs={"class": "product-container"})
        st2 = st1.find("div", attrs={"class": "container-right-content"})
        st3 = st2.find("div", attrs={"class": "pr-in-w"})

        try:
            st4 = st3.find("div", attrs={"class": "pr-in-cn"})
            st5 = st4.find("div", attrs={"class": "product-price-container"})
            sonuc = st5.find("span", attrs={"class": "prc-dsc"}).text
        except AttributeError:
            sonuc = st3.find("div", attrs={"class": "pr-bx-nm"}).text
        except:
            print("HATA oluştu")

        return float(sonuc.split(" ")[0].replace(".", "").replace(",", "."))

    elif website == "gittigidiyor":
        st = soup.find("div", attrs={"id": "gallery-title-price-sellerInformation"})
        st1 = st.find("div", attrs={"id": "sellerPriceShippingKeyContainer"})
        st2 = st1.find("div", attrs={"id": "sellerPriceShippingKey"})
        st3 = st2.find("div", attrs={"id": "spp-price-grayContainer"})
        st4 = st3.find("div", attrs={"id": "price"})
        st5 = st4.find("div", attrs={"id": "sp-price-container"})
        try:
            sonuc = st5.find("div", attrs={"class": "lastPrice"}).text.strip()
        except AttributeError:
            sonuc = st5.find("span", attrs={"class": "lastPrice"}).text.strip()
        except:
            print("HATA oluştu")

        return float(sonuc.split(" ")[0].replace(".", "").replace(",", "."))

    elif website == "n11":
        st = soup.find("div", attrs={"id": "contentListing"})
        st1 = st.find("div", attrs={"class": "listingHolder"})
        st2 = st1.find("div", attrs={"class": "productArea"})
        st3 = st2.find("section", attrs={"class": "import-search-view"})
        st4 = st3.find("div", attrs={"class": "listView"})
        st5 = st4.find("ul", attrs={"class": "clearfix"})
        st6 = st5.find_all("li", attrs={"class": "column"})

        for i in st6:
            st7 = i.find("div", attrs={"class": "columnContent"})
            st8 = st7.find("div", attrs={"class": "pro"})
            st9 = st8.find("a", attrs={"class": "plink"}).get("href")

            if urlFromSql == st9:
                eb = i.find("div", attrs={"class": "columnContent"})
                eb1 = eb.find("div", attrs={"class": "proDetail"})
                eb2 = eb1.find("span", attrs={"class": "newPrice"}).text.strip().split(' ')[0].replace(".", "").replace(",", ".")

                return float(eb2)

        print("ürün Fiyatı bulunamadı")

