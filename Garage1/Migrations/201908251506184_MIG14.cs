namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "ssn", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "ssn");
        }
    }
}
