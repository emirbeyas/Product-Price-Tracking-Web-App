namespace _2DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Urunler", "Tbl_Kullanicilar_ID", c => c.Int());
            CreateIndex("dbo.tbl_Urunler", "Tbl_Kullanicilar_ID");
            AddForeignKey("dbo.tbl_Urunler", "Tbl_Kullanicilar_ID", "dbo.tbl_Kullanicilar", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tbl_Urunler", "Tbl_Kullanicilar_ID", "dbo.tbl_Kullanicilar");
            DropIndex("dbo.tbl_Urunler", new[] { "Tbl_Kullanicilar_ID" });
            DropColumn("dbo.tbl_Urunler", "Tbl_Kullanicilar_ID");
        }
    }
}
