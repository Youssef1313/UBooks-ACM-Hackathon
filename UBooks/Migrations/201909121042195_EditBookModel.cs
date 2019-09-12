namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Seller_Id", newName: "SellerOrBuyer_Id");
            RenameIndex(table: "dbo.Books", name: "IX_Seller_Id", newName: "IX_SellerOrBuyer_Id");
            AddColumn("dbo.Books", "IsForSell", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "IsForSell");
            RenameIndex(table: "dbo.Books", name: "IX_SellerOrBuyer_Id", newName: "IX_Seller_Id");
            RenameColumn(table: "dbo.Books", name: "SellerOrBuyer_Id", newName: "Seller_Id");
        }
    }
}
