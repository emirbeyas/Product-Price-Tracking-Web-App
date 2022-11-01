using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1EntityLayer.Concrete;

namespace _3BusinessLogicLayer.Abstract
{
    public interface IUrunlerService
    {
        List<tbl_Urunler> GetList();
        tbl_Urunler GetByID(int id);
        void AddUrun(tbl_Urunler tbl_Urunler);
        void UpdateUrun(tbl_Urunler tbl_Urunler);
        void DeleteUrun(tbl_Urunler tbl_Urunler);

    }
}
