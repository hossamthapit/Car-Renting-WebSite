namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogFiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LogFiles");
        }
    }
}
