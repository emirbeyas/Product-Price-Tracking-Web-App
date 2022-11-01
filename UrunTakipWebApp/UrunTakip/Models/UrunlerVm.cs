using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using _1EntityLayer.Concrete;

namespace UrunTakip.Models
{
    public class UrunlerVm
    {
        public tbl_Urunler urun { get; set; }

        public IEnumerable<tbl_Fiyatlar> fiyatlars { get; set; }
    }
}