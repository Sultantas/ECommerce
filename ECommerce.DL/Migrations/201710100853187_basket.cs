namespace ECommerce.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basket : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Basket",
                c => new
                    {
                        BasketID = c.Int(nullable: false),
                        TotalOrder = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                        User = c.String(maxLength: 128),
                        PaymentDate = c.DateTime(),
                        ShipDate = c.DateTime(),
                        ShippedDate = c.DateTime(),
                        Status = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.BasketID)
                .ForeignKey("dbo.Users", t => t.User)
                .Index(t => t.User);
            
            CreateTable(
                "dbo.BasketDetail",
                c => new
                    {
                        BasketID = c.Int(nullable: false),
                        ProductsID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.BasketID, t.ProductsID })
                .ForeignKey("dbo.Basket", t => t.BasketID, cascadeDelete: true)
                .Index(t => t.BasketID);
            
            CreateTable(
                "dbo.BasketTemp",
                c => new
                    {
                        User = c.String(nullable: false, maxLength: 128),
                        ProductsID = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Duration = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User, t.ProductsID })
                .ForeignKey("dbo.Users", t => t.User, cascadeDelete: true)
                .Index(t => t.User);
            
            CreateTable(
                "dbo.Param",
                c => new
                    {
                        ParamID = c.String(nullable: false, maxLength: 128),
                        ParamName = c.String(),
                        Parameter = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ParamID);
            
            AddColumn("dbo.Users", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BasketTemp", "User", "dbo.Users");
            DropForeignKey("dbo.Basket", "User", "dbo.Users");
            DropForeignKey("dbo.BasketDetail", "BasketID", "dbo.Basket");
            DropIndex("dbo.BasketTemp", new[] { "User" });
            DropIndex("dbo.BasketDetail", new[] { "BasketID" });
            DropIndex("dbo.Basket", new[] { "User" });
            DropColumn("dbo.Users", "Address");
            DropTable("dbo.Param");
            DropTable("dbo.BasketTemp");
            DropTable("dbo.BasketDetail");
            DropTable("dbo.Basket");
        }
    }
}
