namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDbTables", "Test", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDbTables", "Test");
        }
    }
}
