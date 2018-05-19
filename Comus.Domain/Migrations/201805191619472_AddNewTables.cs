namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNewTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientSource",
                c => new
                    {
                        ClientSourceId = c.Int(nullable: false, identity: true),
                        ClientSourceName = c.String(),
                    })
                .PrimaryKey(t => t.ClientSourceId);
            
            CreateTable(
                "dbo.ProductType",
                c => new
                    {
                        ProductTypeId = c.Int(nullable: false, identity: true),
                        ProductTypeName = c.String(),
                    })
                .PrimaryKey(t => t.ProductTypeId);
            
            AddColumn("dbo.Client", "ProductTypeId", c => c.Int());
            AddColumn("dbo.Client", "ClientSourceId", c => c.Int());
            AddColumn("dbo.Product", "ProductTypeId", c => c.Int());
            CreateIndex("dbo.Client", "ProductTypeId");
            CreateIndex("dbo.Client", "ClientSourceId");
            CreateIndex("dbo.Product", "ProductTypeId");
            AddForeignKey("dbo.Client", "ClientSourceId", "dbo.ClientSource", "ClientSourceId");
            AddForeignKey("dbo.Client", "ProductTypeId", "dbo.ProductType", "ProductTypeId");
            AddForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType", "ProductTypeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.Client", "ProductTypeId", "dbo.ProductType");
            DropForeignKey("dbo.Client", "ClientSourceId", "dbo.ClientSource");
            DropIndex("dbo.Product", new[] { "ProductTypeId" });
            DropIndex("dbo.Client", new[] { "ClientSourceId" });
            DropIndex("dbo.Client", new[] { "ProductTypeId" });
            DropColumn("dbo.Product", "ProductTypeId");
            DropColumn("dbo.Client", "ClientSourceId");
            DropColumn("dbo.Client", "ProductTypeId");
            DropTable("dbo.ProductType");
            DropTable("dbo.ClientSource");
        }
    }
}
