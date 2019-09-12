namespace UBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddExpiredAdvertisement : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ExpiredAdvertisement", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ExpiredAdvertisement");
        }
    }
}
