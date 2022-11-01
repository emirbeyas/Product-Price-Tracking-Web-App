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
    public class FiyatlarManager : IFiyatlarService
    {
        IFiyatlarDal _fiyatlarDal;

        public FiyatlarManager(IFiyatlarDal fiyatlarDal)
        {
            _fiyatlarDal = fiyatlarDal;
        }
        
        public void AddFiyat(tbl_Fiyatlar tbl_Fiyatlar)
        {
            _fiyatlarDal.Insert(tbl_Fiyatlar);
        }

        public void DeleteFiyat(tbl_Fiyatlar tbl_Fiyatlar)
        {
            _fiyatlarDal.Delete(tbl_Fiyatlar);
        }

        public tbl_Fiyatlar GetByID(int id)
        {
            return _fiyatlarDal.GetByID(x => x.ID == id);
        }

        public List<tbl_Fiyatlar> GetList()
        {
            return _fiyatlarDal.List();
        }

        public List<tbl_Fiyatlar> GetList(int urunId)
        {
            return _fiyatlarDal.List(x => x.tblUrunID == urunId);
        }

        public void UpdateFiyat(tbl_Fiyatlar tbl_Fiyatlar)
        {
            _fiyatlarDal.Update(tbl_Fiyatlar);
        }
    }
}
