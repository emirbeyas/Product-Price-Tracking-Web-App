namespace _2DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tbl_Fiyatlar", "tblUrunID");
            DropColumn("dbo.tbl_Urunler", "TblKullaniciID");
            RenameColumn(table: "dbo.tbl_Fiyatlar", name: "tbl_Urunler_ID", newName: "tblUrunID");
            RenameColumn(table: "dbo.tbl_Urunler", name: "Tbl_Kullanicilar_ID", newName: "TblKullaniciID");
            RenameIndex(table: "dbo.tbl_Fiyatlar", name: "IX_tbl_Urunler_ID", newName: "IX_tblUrunID");
            RenameIndex(table: "dbo.tbl_Urunler", name: "IX_Tbl_Kullanicilar_ID", newName: "IX_TblKullaniciID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.tbl_Urunler", name: "IX_TblKullaniciID", newName: "IX_Tbl_Kullanicilar_ID");
            RenameIndex(table: "dbo.tbl_Fiyatlar", name: "IX_tblUrunID", newName: "IX_tbl_Urunler_ID");
            RenameColumn(table: "dbo.tbl_Urunler", name: "TblKullaniciID", newName: "Tbl_Kullanicilar_ID");
            RenameColumn(table: "dbo.tbl_Fiyatlar", name: "tblUrunID", newName: "tbl_Urunler_ID");
            AddColumn("dbo.tbl_Urunler", "TblKullaniciID", c => c.Int());
            AddColumn("dbo.tbl_Fiyatlar", "tblUrunID", c => c.Int());
        }
    }
}
