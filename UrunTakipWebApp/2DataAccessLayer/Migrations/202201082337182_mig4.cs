namespace _2DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Fiyatlar", "tblUrunID", c => c.Int());
            AddColumn("dbo.tbl_Urunler", "TblKullaniciID", c => c.Int());
            DropColumn("dbo.tbl_Urunler", "marka");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tbl_Urunler", "marka", c => c.String(maxLength: 50));
            DropColumn("dbo.tbl_Urunler", "TblKullaniciID");
            DropColumn("dbo.tbl_Fiyatlar", "tblUrunID");
        }
    }
}
