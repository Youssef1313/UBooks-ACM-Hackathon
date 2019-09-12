namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookModelAgain : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "SellerOrBuyer_Id", newName: "AdvertisementOwner_Id");
            RenameIndex(table: "dbo.Books", name: "IX_SellerOrBuyer_Id", newName: "IX_AdvertisementOwner_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_AdvertisementOwner_Id", newName: "IX_SellerOrBuyer_Id");
            RenameColumn(table: "dbo.Books", name: "AdvertisementOwner_Id", newName: "SellerOrBuyer_Id");
        }
    }
}
