namespace CraftsWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetQuantityToCustomers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Products", "Quantity");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.Customers", "Quantity");
        }
    }
}
