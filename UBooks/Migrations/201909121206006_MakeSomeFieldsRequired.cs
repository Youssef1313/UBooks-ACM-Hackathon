namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeSomeFieldsRequired : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "AdvertisementOwner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "AdvertisementOwner_Id" });
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "Author", c => c.String(nullable: false));
            AlterColumn("dbo.Books", "AdvertisementOwner_Id", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Books", "AdvertisementOwner_Id");
            AddForeignKey("dbo.Books", "AdvertisementOwner_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "AdvertisementOwner_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "AdvertisementOwner_Id" });
            AlterColumn("dbo.Books", "AdvertisementOwner_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Books", "Author", c => c.String());
            AlterColumn("dbo.Books", "Description", c => c.String());
            AlterColumn("dbo.Books", "Title", c => c.String());
            CreateIndex("dbo.Books", "AdvertisementOwner_Id");
            AddForeignKey("dbo.Books", "AdvertisementOwner_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
