namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddClientRequest : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientRequest",
                c => new
                    {
                        ClientRequestId = c.Int(nullable: false, identity: true),
                        Company = c.String(),
                        PersonId = c.Int(nullable: false),
                        Phone = c.String(),
                        ClientSourceId = c.Int(),
                        ProductTypeId = c.Int(),
                        ClientRequestStatusId = c.Int(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ClientRequestId)
                .ForeignKey("dbo.ClientRequestStatus", t => t.ClientRequestStatusId)
                .ForeignKey("dbo.ClientSource", t => t.ClientSourceId)
                .ForeignKey("dbo.Person", t => t.PersonId)
                .ForeignKey("dbo.ProductType", t => t.ProductTypeId)
                .Index(t => t.PersonId)
                .Index(t => t.ClientSourceId)
                .Index(t => t.ProductTypeId)
                .Index(t => t.ClientRequestStatusId);
            
            CreateTable(
                "dbo.ClientRequestStatus",
                c => new
                    {
                        ClientRequestStatusId = c.Int(nullable: false, identity: true),
                        ClientRequestStatusName = c.String(),
                        CreatedAt = c.DateTime(),
                        UpdatedAt = c.DateTime(),
                        DeletedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.ClientRequestStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientRequest", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.ClientRequest", "PersonId", "dbo.Person");
            DropForeignKey("dbo.ClientRequest", "ClientSourceId", "dbo.ClientSource");
            DropForeignKey("dbo.ClientRequest", "ClientRequestStatusId", "dbo.ClientRequestStatus");
            DropIndex("dbo.ClientRequest", new[] { "ClientRequestStatusId" });
            DropIndex("dbo.ClientRequest", new[] { "ProductTypeId" });
            DropIndex("dbo.ClientRequest", new[] { "ClientSourceId" });
            DropIndex("dbo.ClientRequest", new[] { "PersonId" });
            DropTable("dbo.ClientRequestStatus");
            DropTable("dbo.ClientRequest");
        }
    }
}
