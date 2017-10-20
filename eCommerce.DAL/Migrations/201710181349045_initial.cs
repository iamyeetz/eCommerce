namespace eCommerce.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderId" });
            DropPrimaryKey("dbo.Baskets");
            AddColumn("dbo.Baskets", "BasketId", c => c.Guid(nullable: false));
            AddColumn("dbo.Customers", "CustomerName", c => c.String());
            AddPrimaryKey("dbo.Baskets", "BasketId");
            CreateIndex("dbo.OrderItems", "Order_OrderID");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "BasketId", cascadeDelete: true);
            DropColumn("dbo.Baskets", "Id");
            DropColumn("dbo.Products", "CostPrice");
            DropColumn("dbo.Customers", "Name");
            DropColumn("dbo.Customers", "Address");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "Name", c => c.String(maxLength: 80));
            AddColumn("dbo.Products", "CostPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Baskets", "Id", c => c.Guid(nullable: false));
            DropForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets");
            DropIndex("dbo.OrderItems", new[] { "Order_OrderID" });
            DropPrimaryKey("dbo.Baskets");
            DropColumn("dbo.Customers", "CustomerName");
            DropColumn("dbo.Baskets", "BasketId");
            AddPrimaryKey("dbo.Baskets", "Id");
            CreateIndex("dbo.OrderItems", "Order_OrderId");
            AddForeignKey("dbo.BasketItems", "BasketId", "dbo.Baskets", "Id", cascadeDelete: true);
        }
    }
}
