import scrap
import DbContext
import sendMail


Urunler = DbContext.getUrunlerList()

for i in Urunler:
    anlikFiyat = scrap.scrap(i[1], i[2])
    if i[10] != anlikFiyat and anlikFiyat != 0:
        DbContext.addFiyat(anlikFiyat, i[0])
        print("ürün fiyati güncellendi")

        if i[11] and i[8] >= anlikFiyat:
            sendMail.mailGonder(DbContext.findUserEmail(i[4]), i[2], anlikFiyat)
            DbContext.bildirimGonderildi(i[0])

