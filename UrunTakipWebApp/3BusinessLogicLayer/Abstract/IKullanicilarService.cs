using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1EntityLayer.Concrete;

namespace _3BusinessLogicLayer.Abstract
{
    public interface IKullanicilarService
    {
        List<tbl_Kullanicilar> GetList();
        tbl_Kullanicilar GetByID(int id);
        void AddKullanici(tbl_Kullanicilar tbl_Kullanicilar);
        void UpdateKullanici(tbl_Kullanicilar tbl_Kullanicilar);
        void DeleteKullanici(tbl_Kullanicilar tbl_Kullanicilar);
    }
}
