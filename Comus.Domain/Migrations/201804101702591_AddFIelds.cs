namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFIelds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "VolumeOfPurchases", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Product", "Warehouse", c => c.String());
            AddColumn("dbo.Product", "MaxCapacity", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "MaxCapacity");
            DropColumn("dbo.Product", "Warehouse");
            DropColumn("dbo.Client", "VolumeOfPurchases");
        }
    }
}
