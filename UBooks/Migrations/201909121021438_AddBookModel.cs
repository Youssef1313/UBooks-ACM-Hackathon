namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBookModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Author = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        SellDate = c.DateTime(nullable: false),
                        Seller_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Seller_Id)
                .Index(t => t.Seller_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Seller_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Books", new[] { "Seller_Id" });
            DropTable("dbo.Books");
        }
    }
}
