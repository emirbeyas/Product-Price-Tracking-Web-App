using _1EntityLayer.Concrete;
using _2DataAccessLayer.Abstract;
using _3BusinessLogicLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3BusinessLogicLayer.Concrete
{
    public class KullanicilarManager : IKullanicilarService
    {
        IKullanicilarDal _KullanicilarDal;

        public KullanicilarManager(IKullanicilarDal kullanicilarDal)
        {
            _KullanicilarDal = kullanicilarDal;
        }
        public void AddKullanici(tbl_Kullanicilar tbl_Kullanicilar)
        {
            _KullanicilarDal.Insert(tbl_Kullanicilar);
        }

        public void DeleteKullanici(tbl_Kullanicilar tbl_Kullanicilar)
        {
            _KullanicilarDal.Delete(tbl_Kullanicilar); 
        }

        public tbl_Kullanicilar GetByID(int id)
        {
            return _KullanicilarDal.GetByID(x => x.ID == id);
        }

        public List<tbl_Kullanicilar> GetList()
        {
            return _KullanicilarDal.List();
        }

        public void UpdateKullanici(tbl_Kullanicilar tbl_Kullanicilar)
        {
            _KullanicilarDal.Update(tbl_Kullanicilar);
        }
    }
}
