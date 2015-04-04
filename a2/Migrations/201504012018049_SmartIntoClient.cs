namespace a2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmartIntoClient : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Smarts", "id", "dbo.Clients");
            DropForeignKey("dbo.Clients", "id", "dbo.Smarts");
            DropIndex("dbo.Smarts", new[] { "id" });
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.Smarts");
            AlterColumn("dbo.Clients", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Smarts", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Clients", "id");
            AddPrimaryKey("dbo.Smarts", "id");
            CreateIndex("dbo.Clients", "id");
            AddForeignKey("dbo.Clients", "id", "dbo.Smarts", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "id", "dbo.Smarts");
            DropIndex("dbo.Clients", new[] { "id" });
            DropPrimaryKey("dbo.Smarts");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.Smarts", "id", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Smarts", "id");
            AddPrimaryKey("dbo.Clients", "id");
            CreateIndex("dbo.Smarts", "id");
            AddForeignKey("dbo.Clients", "id", "dbo.Smarts", "id");
            AddForeignKey("dbo.Smarts", "id", "dbo.Clients", "id");
        }
    }
}
