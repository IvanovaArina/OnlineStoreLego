namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserContext : DbMigration
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
                        IsActive = c.Boolean(nullable: false),
                        ProductDetail = c.String(),
                        ImagePath = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        UserName = c.String(),
                        Rating = c.Int(nullable: false),
                        Text = c.String(),
                        Approved = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UDbTable_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.ProductTables", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.UDbTables", t => t.UDbTable_UserId)
                .Index(t => t.ProductId)
                .Index(t => t.UDbTable_UserId);
            
            CreateTable(
                "dbo.UDbTables",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 100),
                        Role = c.Int(nullable: false),
                        WishlistId = c.Int(nullable: false),
                        CartId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "UDbTable_UserId", "dbo.UDbTables");
            DropForeignKey("dbo.Reviews", "ProductId", "dbo.ProductTables");
            DropIndex("dbo.Reviews", new[] { "UDbTable_UserId" });
            DropIndex("dbo.Reviews", new[] { "ProductId" });
            DropTable("dbo.UDbTables");
            DropTable("dbo.Reviews");
            DropTable("dbo.ProductTables");
        }
    }
}
