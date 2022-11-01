namespace _2DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tbl_Urunler", "guncelFiyat", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tbl_Urunler", "guncelFiyat");
        }
    }
}
