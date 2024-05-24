namespace WebApplication.BL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateUDbTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UDbTables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 30),
                        UserIp = c.String(nullable: false, maxLength: 30),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UDbTables");
        }
    }
}
