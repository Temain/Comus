namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTimeFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ClientSource", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ClientSource", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ClientSource", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ProductType", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ProductType", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ProductType", "DeletedAt", c => c.DateTime());
            AddColumn("dbo.ClientStatus", "CreatedAt", c => c.DateTime());
            AddColumn("dbo.ClientStatus", "UpdatedAt", c => c.DateTime());
            AddColumn("dbo.ClientStatus", "DeletedAt", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ClientStatus", "DeletedAt");
            DropColumn("dbo.ClientStatus", "UpdatedAt");
            DropColumn("dbo.ClientStatus", "CreatedAt");
            DropColumn("dbo.ProductType", "DeletedAt");
            DropColumn("dbo.ProductType", "UpdatedAt");
            DropColumn("dbo.ProductType", "CreatedAt");
            DropColumn("dbo.ClientSource", "DeletedAt");
            DropColumn("dbo.ClientSource", "UpdatedAt");
            DropColumn("dbo.ClientSource", "CreatedAt");
        }
    }
}
