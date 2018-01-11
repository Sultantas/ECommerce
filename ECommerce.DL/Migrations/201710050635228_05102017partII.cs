namespace ECommerce.DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _05102017partII : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductColors", "Categories_CategoryID", "dbo.Categories");
            DropForeignKey("dbo.ProductSizes", "Categories_CategoryID", "dbo.Categories");
            DropIndex("dbo.ProductColors", new[] { "Categories_CategoryID" });
            DropIndex("dbo.ProductSizes", new[] { "Categories_CategoryID" });
            CreateIndex("dbo.ProductColors", "ProductsID");
            CreateIndex("dbo.ProductSizes", "ProductsID");
            AddForeignKey("dbo.ProductColors", "ProductsID", "dbo.Products", "ProductsID", cascadeDelete: true);
            AddForeignKey("dbo.ProductSizes", "ProductsID", "dbo.Products", "ProductsID", cascadeDelete: true);
            DropColumn("dbo.ProductColors", "Categories_CategoryID");
            DropColumn("dbo.ProductSizes", "Categories_CategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductSizes", "Categories_CategoryID", c => c.Int());
            AddColumn("dbo.ProductColors", "Categories_CategoryID", c => c.Int());
            DropForeignKey("dbo.ProductSizes", "ProductsID", "dbo.Products");
            DropForeignKey("dbo.ProductColors", "ProductsID", "dbo.Products");
            DropIndex("dbo.ProductSizes", new[] { "ProductsID" });
            DropIndex("dbo.ProductColors", new[] { "ProductsID" });
            CreateIndex("dbo.ProductSizes", "Categories_CategoryID");
            CreateIndex("dbo.ProductColors", "Categories_CategoryID");
            AddForeignKey("dbo.ProductSizes", "Categories_CategoryID", "dbo.Categories", "CategoryID");
            AddForeignKey("dbo.ProductColors", "Categories_CategoryID", "dbo.Categories", "CategoryID");
        }
    }
}
