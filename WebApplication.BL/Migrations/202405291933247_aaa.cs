namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaa : DbMigration
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
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.CartTables", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.WishlistTables", t => t.WishlistId, cascadeDelete: true)
                .Index(t => t.WishlistId)
                .Index(t => t.CartId);
            
            CreateTable(
                "dbo.CartTables",
                c => new
                    {
                        cartId = c.Int(nullable: false, identity: true),
                        testCart = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.cartId);
            
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
            DropForeignKey("dbo.ProductTables", "CartId", "dbo.CartTables");
            DropIndex("dbo.ProductTables", new[] { "CartId" });
            DropIndex("dbo.ProductTables", new[] { "WishlistId" });
            DropTable("dbo.WishlistTables");
            DropTable("dbo.CartTables");
            DropTable("dbo.ProductTables");
        }
    }
}
