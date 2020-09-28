namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG8 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Logs", name: "LogFile_ID", newName: "log_ID");
            RenameIndex(table: "dbo.Logs", name: "IX_LogFile_ID", newName: "IX_log_ID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Logs", name: "IX_log_ID", newName: "IX_LogFile_ID");
            RenameColumn(table: "dbo.Logs", name: "log_ID", newName: "LogFile_ID");
        }
    }
}
