namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listOfProducts29 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductTables",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductNumber = c.Int(nullable: false),
                        ProductName = c.String(nullable: false),
                        Price = c.Double(nullable: false),
                        CategoryByAge = c.String(nullable: false),
                        Category = c.String(nullable: false),
                        SellCategory = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        isActive = c.Boolean(nullable: false),
                        ProductDetail = c.String(),
                        WishlistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.WishlistTables", t => t.WishlistId, cascadeDelete: true)
                .Index(t => t.WishlistId);
            
            CreateTable(
                "dbo.WishlistTables",
                c => new
                    {
                        wishlistId = c.Int(nullable: false, identity: true),
                        test = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.wishlistId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTables", "WishlistId", "dbo.WishlistTables");
            DropIndex("dbo.ProductTables", new[] { "WishlistId" });
            DropTable("dbo.WishlistTables");
            DropTable("dbo.ProductTables");
        }
    }
}
