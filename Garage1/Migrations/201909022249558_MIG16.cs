namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "carID", c => c.Int(nullable: false));
            DropColumn("dbo.Logs", "CarOrPackageID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Logs", "CarOrPackageID", c => c.Int(nullable: false));
            DropColumn("dbo.Logs", "carID");
        }
    }
}
