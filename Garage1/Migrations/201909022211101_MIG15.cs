namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "CarOrPackageID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "CarOrPackageID");
        }
    }
}
