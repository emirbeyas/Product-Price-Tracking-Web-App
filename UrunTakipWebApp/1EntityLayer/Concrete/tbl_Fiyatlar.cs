using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1EntityLayer.Concrete
{
    public class tbl_Fiyatlar
    {
        [Key]
        public int ID { get; set; }
        public double fiyat { get; set; }
        public DateTime tarih { get; set; }

        public int? tblUrunID { get; set; }
        [ForeignKey("tblUrunID")]
        public virtual tbl_Urunler tbl_Urunler { get; set; }
    }
}
