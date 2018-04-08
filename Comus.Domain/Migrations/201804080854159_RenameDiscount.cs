namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Discount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Client", "Descount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Client", "Descount", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.Client", "Discount");
        }
    }
}
