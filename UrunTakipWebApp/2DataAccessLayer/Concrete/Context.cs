using _1EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace _2DataAccessLayer.Concrete
{
    public class Context: DbContext
    {
        public DbSet<tbl_Fiyatlar> tbl_Fiyatlars { get; set; }

        public DbSet<tbl_Urunler> tbl_Urunlers { get; set; }

        public DbSet<tbl_Kullanicilar> tbl_Kullanicilars { get; set; }

    }
}
