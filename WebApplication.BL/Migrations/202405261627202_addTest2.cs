namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTest2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UDbTables", "Test2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UDbTables", "Test2");
        }
    }
}
