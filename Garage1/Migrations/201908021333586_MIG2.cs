namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Period", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Period");
        }
    }
}
