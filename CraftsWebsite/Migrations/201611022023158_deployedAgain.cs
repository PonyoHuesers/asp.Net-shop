namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deployedAgain : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "Customers1");
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomersId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Balance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ProductsId = c.Int(),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomersId)
                .ForeignKey("dbo.Products", t => t.ProductsId)
                .Index(t => t.ProductsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "ProductsId", "dbo.Products");
            DropIndex("dbo.Customers", new[] { "ProductsId" });
            DropTable("dbo.Customers");
            RenameTable(name: "dbo.Customers1", newName: "Customers");
        }
    }
}
