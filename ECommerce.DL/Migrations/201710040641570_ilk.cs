namespace ECommerce.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ilk : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Brands",
                c => new
                    {
                        BrandID = c.Int(nullable: false, identity: true),
                        BrandName = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.BrandID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductsID = c.Int(nullable: false, identity: true),
                        ProductsName = c.String(nullable: false, maxLength: 50),
                        ProductDetail = c.String(maxLength: 100),
                        SizeID = c.Int(nullable: false),
                        ColorID = c.Int(nullable: false),
                        BrandID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UnitsInStock = c.Int(nullable: false),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.ProductsID)
                .ForeignKey("dbo.Brands", t => t.BrandID, cascadeDelete: true)
                .Index(t => t.BrandID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductsID = c.Int(nullable: false),
                        CategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductsID, t.CategoryID })
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductsID, cascadeDelete: true)
                .Index(t => t.ProductsID)
                .Index(t => t.CategoryID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductCategories", "ProductsID", "dbo.Products");
            DropForeignKey("dbo.ProductCategories", "CategoryID", "dbo.Categories");
            DropForeignKey("dbo.Products", "BrandID", "dbo.Brands");
            DropIndex("dbo.ProductCategories", new[] { "CategoryID" });
            DropIndex("dbo.ProductCategories", new[] { "ProductsID" });
            DropIndex("dbo.Products", new[] { "BrandID" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.Brands");
        }
    }
}
