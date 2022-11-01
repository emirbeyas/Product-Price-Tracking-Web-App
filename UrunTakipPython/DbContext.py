import datetime
import pypyodbc

db = pypyodbc.connect(
    'Driver={SQL Server};'
    'Server=DESKTOP-RPPFAF1;'
    'Database=DBUrunTakip;'
    'Trusted_Connection=True;'
)
imlec = db.cursor()


def findUserEmail(userId):
    cmd = "SELECT eMail FROM tbl_Kullanicilar where ID = " + str(userId)
    imlec.execute(cmd)
    emails = imlec.fetchone()
    return emails[0]


def getUrunlerList():
    cmd = "SELECT * FROM tbl_Urunler"
    imlec.execute(cmd)
    Urunler = imlec.fetchall()
    return Urunler


def addFiyat(newPrice, urunId):
    cmd = 'INSERT INTO tbl_Fiyatlar VALUES(?,?,?)'
    veriler = (newPrice, datetime.datetime.now(), urunId)
    imlec.execute(cmd, veriler)
    db.commit()


def bildirimGonderildi(urunID):
    cmd = "UPDATE tbl_Urunler SET bildirimDurum = 0 where ID = " + str(urunID)
    imlec.execute(cmd)
    db.commit()


def getFiyatlar(urunId):
    cmd = "SELECT * FROM tbl_Fiyatlar WHERE tblUrunID = " + str(urunId) + "ORDER BY tarih"
    imlec.execute(cmd)
    urunFiyatlari = imlec.fetchall()
    return urunFiyatlari


