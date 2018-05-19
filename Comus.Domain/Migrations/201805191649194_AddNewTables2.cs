namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientStatus",
                c => new
                    {
                        ClientStatusId = c.Int(nullable: false, identity: true),
                        ClientStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ClientStatusId);
            
            AddColumn("dbo.Client", "ClientStatusId", c => c.Int());
            CreateIndex("dbo.Client", "ClientStatusId");
            AddForeignKey("dbo.Client", "ClientStatusId", "dbo.ClientStatus", "ClientStatusId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "ClientStatusId", "dbo.ClientStatus");
            DropIndex("dbo.Client", new[] { "ClientStatusId" });
            DropColumn("dbo.Client", "ClientStatusId");
            DropTable("dbo.ClientStatus");
        }
    }
}
