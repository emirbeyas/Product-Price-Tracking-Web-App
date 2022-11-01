using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1EntityLayer.Concrete
{
    public class tbl_Kullanicilar
    {
        [Key]
        public int ID { get; set; }

        [StringLength(30)]
        public string sifre { get; set; }

        [MaxLength]
        public string eMail { get; set; }
        public bool admin { get; set; }
        public ICollection<tbl_Urunler> tbl_Urunlers { get; set; }
    }
}
