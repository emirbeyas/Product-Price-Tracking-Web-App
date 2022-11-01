namespace _2DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Urunler", "satici", c => c.String(maxLength: 50));
            AddColumn("dbo.tbl_Urunler", "puani", c => c.String(maxLength: 5));
            AddColumn("dbo.tbl_Urunler", "degerlendirmeSayisi", c => c.String(maxLength: 5));
            AddColumn("dbo.tbl_Urunler", "bildirimFiyat", c => c.Double(nullable: false));
            AddColumn("dbo.tbl_Urunler", "tahminiFiyat", c => c.Double(nullable: false));
            AlterColumn("dbo.tbl_Fiyatlar", "fiyat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.tbl_Fiyatlar", "fiyat", c => c.Single(nullable: false));
            DropColumn("dbo.tbl_Urunler", "tahminiFiyat");
            DropColumn("dbo.tbl_Urunler", "bildirimFiyat");
            DropColumn("dbo.tbl_Urunler", "degerlendirmeSayisi");
            DropColumn("dbo.tbl_Urunler", "puani");
            DropColumn("dbo.tbl_Urunler", "satici");
        }
    }
}
