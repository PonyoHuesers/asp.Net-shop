namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class APISupport : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Product_Id", c => c.Int());
            CreateIndex("dbo.Customers", "Product_Id");
            AddForeignKey("dbo.Customers", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.Customers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Name", c => c.String());
            DropForeignKey("dbo.Customers", "Product_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Product_Id" });
            DropColumn("dbo.Customers", "Product_Id");
        }
    }
}
