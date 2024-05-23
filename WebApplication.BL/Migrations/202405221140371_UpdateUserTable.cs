namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UDbTables", "Password", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
