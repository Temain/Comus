namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDiscount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Descount", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "Descount");
        }
    }
}
