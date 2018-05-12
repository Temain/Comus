namespace Comus.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConveyorTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Conveyor",
                c => new
                    {
                        ConveyorId = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Title = c.Int(nullable: false),
                        PossibleVolume = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        DateOfLastStart = c.DateTime(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConveyorId);
            
            CreateTable(
                "dbo.ConveyorDefect",
                c => new
                    {
                        ConveyorDefectId = c.Int(nullable: false, identity: true),
                        ConveyorId = c.Int(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        Downtime = c.Int(nullable: false),
                        Comment = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ConveyorDefectId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .ForeignKey("dbo.Conveyor", t => t.ConveyorId)
                .Index(t => t.ConveyorId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ConveyorDefect", "ConveyorId", "dbo.Conveyor");
            DropForeignKey("dbo.ConveyorDefect", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.ConveyorDefect", new[] { "ApplicationUserId" });
            DropIndex("dbo.ConveyorDefect", new[] { "ConveyorId" });
            DropTable("dbo.ConveyorDefect");
            DropTable("dbo.Conveyor");
        }
    }
}
