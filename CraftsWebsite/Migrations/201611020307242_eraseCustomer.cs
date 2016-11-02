namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class eraseCustomer : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Product_ProductsId", "dbo.Products1");
            DropForeignKey("dbo.Customers", "Product_ProductsId1", "dbo.Products1");
            DropForeignKey("dbo.Customers", "Products_ProductsId", "dbo.Products1");
            DropIndex("dbo.Customers", new[] { "Product_ProductsId" });
            DropIndex("dbo.Customers", new[] { "Product_ProductsId1" });
            DropIndex("dbo.Customers", new[] { "Products_ProductsId" });
            DropTable("dbo.Customers");
            DropTable("dbo.Products1");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products1",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductsId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductsId = c.Int(),
                        Quantity = c.Int(nullable: false),
                        Product_ProductsId = c.Int(),
                        Product_ProductsId1 = c.Int(),
                        Products_ProductsId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateIndex("dbo.Customers", "Products_ProductsId");
            CreateIndex("dbo.Customers", "Product_ProductsId1");
            CreateIndex("dbo.Customers", "Product_ProductsId");
            AddForeignKey("dbo.Customers", "Products_ProductsId", "dbo.Products1", "ProductsId");
            AddForeignKey("dbo.Customers", "Product_ProductsId1", "dbo.Products1", "ProductsId");
            AddForeignKey("dbo.Customers", "Product_ProductsId", "dbo.Products1", "ProductsId");
        }
    }
}
