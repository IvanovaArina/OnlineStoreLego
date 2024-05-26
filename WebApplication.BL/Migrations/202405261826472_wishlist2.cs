namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlist2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.WishlistTables", "Wishlist_wishlistId", "dbo.WishlistTables");
            DropIndex("dbo.WishlistTables", new[] { "Wishlist_wishlistId" });
            DropColumn("dbo.WishlistTables", "Wishlist_wishlistId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WishlistTables", "Wishlist_wishlistId", c => c.Int(nullable: false));
            CreateIndex("dbo.WishlistTables", "Wishlist_wishlistId");
            AddForeignKey("dbo.WishlistTables", "Wishlist_wishlistId", "dbo.WishlistTables", "wishlistId");
        }
    }
}
