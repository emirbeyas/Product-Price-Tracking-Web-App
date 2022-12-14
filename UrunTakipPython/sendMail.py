import smtplib
from email.mime.multipart import MIMEMultipart
from email.mime.text import MIMEText
import sys


def mailGonder(alici, urunAdi, urunFiyat):
    try:
        mail = smtplib.SMTP("smtp.gmail.com", 587)
        mail.ehlo()
        mail.starttls()
        mail.login("mailAdress", "mailPass")

        mesaj = MIMEMultipart()
        mesaj["From"] = "uruntakib@gmail.com"
        mesaj["To"] = alici
        mesaj["Subject"] = urunAdi

        body = """
    
        Takip Ettiğiniz %s isimli ürün %f ₺ ye düşmüştür. 
    
        """ % (urunAdi, urunFiyat)

        body_text = MIMEText(body, "plain")
        mesaj.attach(body_text)

        mail.sendmail(mesaj["From"], mesaj["To"], mesaj.as_string())
        print("Mail gönderildi.")
        mail.close()

    except:
        print("Hata:", sys.exc_info()[0])
