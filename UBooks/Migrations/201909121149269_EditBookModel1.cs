namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditBookModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "AddedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "SellDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "SellDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Books", "AddedDate");
        }
    }
}
