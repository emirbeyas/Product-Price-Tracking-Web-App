using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1EntityLayer.Concrete;

namespace _3BusinessLogicLayer.Abstract
{
    public interface IFiyatlarService
    {
        List<tbl_Fiyatlar> GetList();
        List<tbl_Fiyatlar> GetList(int urunId);
        tbl_Fiyatlar GetByID(int id);
        void AddFiyat(tbl_Fiyatlar tbl_Fiyatlar);
        void UpdateFiyat(tbl_Fiyatlar tbl_Fiyatlar);
        void DeleteFiyat(tbl_Fiyatlar tbl_Fiyatlar);
    }
}
