namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Client", "Company");
        }
    }
}
