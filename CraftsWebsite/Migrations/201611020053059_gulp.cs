namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gulp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products");
            CreateTable(
                "dbo.Products1",
                c => new
                    {
                        ProductsId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProductsId);
            
            AddForeignKey("dbo.Customers", "ProductsId", "dbo.Products1", "ProductsId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products1");
            DropTable("dbo.Products1");
            AddForeignKey("dbo.Customers", "ProductsId", "dbo.Products", "ProductsId");
        }
    }
}
