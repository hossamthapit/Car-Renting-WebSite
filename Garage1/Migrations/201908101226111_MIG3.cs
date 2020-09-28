namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cars", "RentDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Cars", "period", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Cars", "period");
            DropColumn("dbo.Cars", "RentDate");
        }
    }
}
