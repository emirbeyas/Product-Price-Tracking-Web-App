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
    public class UrunlerManager : IUrunlerService
    {
        IUrunlerDal _urunlerDal;

        public UrunlerManager(IUrunlerDal urunlerDal)
        {
            _urunlerDal = urunlerDal;
        }
        public void AddUrun(tbl_Urunler tbl_Urunler)
        {
            _urunlerDal.Insert(tbl_Urunler);
        }

        public void DeleteUrun(tbl_Urunler tbl_Urunler)
        {
            _urunlerDal.Delete(tbl_Urunler);
        }

        public tbl_Urunler GetByID(int id)
        {
            return _urunlerDal.GetByID(x => x.ID == id);
        }

        public List<tbl_Urunler> GetList()
        {
            return _urunlerDal.List();
        }

        public void UpdateUrun(tbl_Urunler tbl_Urunler)
        {
            _urunlerDal.Update(tbl_Urunler);
        }
    }
}
