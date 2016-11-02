namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableProductId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "ProductsId" });
            AlterColumn("dbo.Customers", "ProductsId", c => c.Int());
            CreateIndex("dbo.Customers", "ProductsId");
            AddForeignKey("dbo.Customers", "ProductsId", "dbo.Products", "ProductsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "ProductsId" });
            AlterColumn("dbo.Customers", "ProductsId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "ProductsId");
            AddForeignKey("dbo.Customers", "ProductsId", "dbo.Products", "ProductsId", cascadeDelete: true);
        }
    }
}
