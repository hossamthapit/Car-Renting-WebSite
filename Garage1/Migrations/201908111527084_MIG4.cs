namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG4 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Cars", "NumberOfCars");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Cars", "NumberOfCars", c => c.Int(nullable: false));
        }
    }
}
