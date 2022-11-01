using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1EntityLayer.Concrete
{
    public class tbl_Urunler
    {
        [Key]
        public int ID { get; set; }
        
        [MaxLength]
        public string urunLink { get; set; }

        [MaxLength]
        public string urunAdi { get; set; }
        
        [StringLength(50)]
        public string satici { get; set; }
        
        [StringLength(20)]
        public string puani { get; set; }
        
        [StringLength(20)]
        public string degerlendirmeSayisi { get; set; }
        
        public double bildirimFiyat { get; set; }

        public double tahminiFiyat { get; set; }
        public double guncelFiyat { get; set; }
        public bool bildirimDurum { get; set; }

        [MaxLength]
        public string resimUrl { get; set; }

        public int? TblKullaniciID { get; set; }
        [ForeignKey("TblKullaniciID")]
        public virtual tbl_Kullanicilar Tbl_Kullanicilar{ get; set; }


        public ICollection<tbl_Fiyatlar> tbl_Fiyatlars { get; set; }
    }
}
