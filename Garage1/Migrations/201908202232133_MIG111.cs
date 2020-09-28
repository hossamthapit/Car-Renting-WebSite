namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG111 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "FirstName", c => c.String());
            AlterColumn("dbo.Clients", "LastName", c => c.String());
            AlterColumn("dbo.Clients", "Country", c => c.String());
            AlterColumn("dbo.Clients", "City", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "City", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "Country", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Clients", "FirstName", c => c.String(nullable: false));
        }
    }
}
