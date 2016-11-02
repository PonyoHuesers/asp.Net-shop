namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PoofAPplicationDB : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "Product_Id", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "Product_Id" });
            DropTable("dbo.Customers");
            DropTable("dbo.Products");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Product_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "Product_Id");
            AddForeignKey("dbo.Customers", "Product_Id", "dbo.Products", "Id");
        }
    }
}
