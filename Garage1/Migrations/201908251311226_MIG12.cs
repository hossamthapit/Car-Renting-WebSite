namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Logs", "nationalID", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Logs", "nationalID");
        }
    }
}
