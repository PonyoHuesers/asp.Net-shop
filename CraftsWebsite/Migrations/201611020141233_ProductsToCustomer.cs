namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsToCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products1");
            DropIndex("dbo.Customers", new[] { "ProductsId" });
            AddColumn("dbo.Customers", "Product_ProductsId", c => c.Int());
            AddColumn("dbo.Customers", "Product_ProductsId1", c => c.Int());
            AddColumn("dbo.Customers", "Products_ProductsId", c => c.Int());
            CreateIndex("dbo.Customers", "Product_ProductsId");
            CreateIndex("dbo.Customers", "Product_ProductsId1");
            CreateIndex("dbo.Customers", "Products_ProductsId");
            AddForeignKey("dbo.Customers", "Products_ProductsId", "dbo.Products1", "ProductsId");
            AddForeignKey("dbo.Customers", "Product_ProductsId1", "dbo.Products1", "ProductsId");
            AddForeignKey("dbo.Customers", "Product_ProductsId", "dbo.Products1", "ProductsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Product_ProductsId", "dbo.Products1");
            DropForeignKey("dbo.Customers", "Product_ProductsId1", "dbo.Products1");
            DropForeignKey("dbo.Customers", "Products_ProductsId", "dbo.Products1");
            DropIndex("dbo.Customers", new[] { "Products_ProductsId" });
            DropIndex("dbo.Customers", new[] { "Product_ProductsId1" });
            DropIndex("dbo.Customers", new[] { "Product_ProductsId" });
            DropColumn("dbo.Customers", "Products_ProductsId");
            DropColumn("dbo.Customers", "Product_ProductsId1");
            DropColumn("dbo.Customers", "Product_ProductsId");
            CreateIndex("dbo.Customers", "ProductsId");
            AddForeignKey("dbo.Customers", "ProductsId", "dbo.Products1", "ProductsId");
        }
    }
}
