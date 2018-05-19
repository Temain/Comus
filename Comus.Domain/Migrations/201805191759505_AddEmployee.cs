namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Client", "EmployeeId", c => c.Int());
            CreateIndex("dbo.Client", "EmployeeId");
            AddForeignKey("dbo.Client", "EmployeeId", "dbo.Employee", "EmployeeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Client", "EmployeeId", "dbo.Employee");
            DropIndex("dbo.Client", new[] { "EmployeeId" });
            DropColumn("dbo.Client", "EmployeeId");
        }
    }
}
