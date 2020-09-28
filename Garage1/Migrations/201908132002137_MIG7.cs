namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Logs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MSG = c.String(),
                        kind = c.Int(nullable: false),
                        date = c.DateTime(nullable: false),
                        period = c.Int(nullable: false),
                        LogFile_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LogFiles", t => t.LogFile_ID)
                .Index(t => t.LogFile_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Logs", "LogFile_ID", "dbo.LogFiles");
            DropIndex("dbo.Logs", new[] { "LogFile_ID" });
            DropTable("dbo.Logs");
        }
    }
}
