using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UrunTakip.Scrap;

namespace UrunTakip.Models
{
    public class UrunlerListViewModel
    {
        public IEnumerable<CekilenUrun> trendyolUrunler { get; set; }
        public IEnumerable<CekilenUrun> gittigidiyorUrunler { get; set; }
        public IEnumerable<CekilenUrun> N11Urunler { get; set; }
    }
}