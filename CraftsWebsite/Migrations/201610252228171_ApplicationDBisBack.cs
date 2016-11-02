namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplicationDBisBack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.Products", t => t.ProductsId, cascadeDelete: true)
                .Index(t => t.ProductsId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "ProductsId" });
            DropTable("dbo.Products");
            DropTable("dbo.Customers");
        }
    }
}
