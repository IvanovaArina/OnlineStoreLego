
namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlist : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.WishlistTables",
                c => new
                    {
                        wishlistId = c.Int(nullable: false, identity: true),
                        test = c.Int(nullable: false),
                        Wishlist_wishlistId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.wishlistId)
                .ForeignKey("dbo.WishlistTables", t => t.Wishlist_wishlistId)
                .Index(t => t.Wishlist_wishlistId);
            
            AddColumn("dbo.UDbTables", "wishlistId", c => c.Int(nullable: false));
            CreateIndex("dbo.UDbTables", "wishlistId");
            AddForeignKey("dbo.UDbTables", "wishlistId", "dbo.WishlistTables", "wishlistId", cascadeDelete: true);
            DropColumn("dbo.UDbTables", "Test");
            DropColumn("dbo.UDbTables", "Test2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UDbTables", "Test2", c => c.String());
            AddColumn("dbo.UDbTables", "Test", c => c.String(nullable: false));
            DropForeignKey("dbo.UDbTables", "wishlistId", "dbo.WishlistTables");
            DropForeignKey("dbo.WishlistTables", "Wishlist_wishlistId", "dbo.WishlistTables");
            DropIndex("dbo.WishlistTables", new[] { "Wishlist_wishlistId" });
            DropIndex("dbo.UDbTables", new[] { "wishlistId" });
            DropColumn("dbo.UDbTables", "wishlistId");
            DropTable("dbo.WishlistTables");
        }
    }
}
