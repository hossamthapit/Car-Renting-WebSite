namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG11 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ClientCars", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.PackageClients", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.OfferClients", "Client_NationalId", "dbo.Clients");
            DropIndex("dbo.ClientCars", new[] { "Client_NationalId" });
            DropIndex("dbo.PackageClients", new[] { "Client_NationalId" });
            DropIndex("dbo.OfferClients", new[] { "Client_NationalId" });
            DropPrimaryKey("dbo.Clients");
            DropPrimaryKey("dbo.ClientCars");
            DropPrimaryKey("dbo.PackageClients");
            DropPrimaryKey("dbo.OfferClients");
            AlterColumn("dbo.Clients", "NationalId", c => c.Long(nullable: false, identity: true));
            AlterColumn("dbo.Clients", "Phone", c => c.Long(nullable: false));
            AlterColumn("dbo.ClientCars", "Client_NationalId", c => c.Long(nullable: false));
            AlterColumn("dbo.PackageClients", "Client_NationalId", c => c.Long(nullable: false));
            AlterColumn("dbo.OfferClients", "Client_NationalId", c => c.Long(nullable: false));
            AddPrimaryKey("dbo.Clients", "NationalId");
            AddPrimaryKey("dbo.ClientCars", new[] { "Client_NationalId", "Car_ID" });
            AddPrimaryKey("dbo.PackageClients", new[] { "Package_ID", "Client_NationalId" });
            AddPrimaryKey("dbo.OfferClients", new[] { "Offer_ID", "Client_NationalId" });
            CreateIndex("dbo.ClientCars", "Client_NationalId");
            CreateIndex("dbo.PackageClients", "Client_NationalId");
            CreateIndex("dbo.OfferClients", "Client_NationalId");
            AddForeignKey("dbo.ClientCars", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
            AddForeignKey("dbo.PackageClients", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
            AddForeignKey("dbo.OfferClients", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferClients", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.PackageClients", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.ClientCars", "Client_NationalId", "dbo.Clients");
            DropIndex("dbo.OfferClients", new[] { "Client_NationalId" });
            DropIndex("dbo.PackageClients", new[] { "Client_NationalId" });
            DropIndex("dbo.ClientCars", new[] { "Client_NationalId" });
            DropPrimaryKey("dbo.OfferClients");
            DropPrimaryKey("dbo.PackageClients");
            DropPrimaryKey("dbo.ClientCars");
            DropPrimaryKey("dbo.Clients");
            AlterColumn("dbo.OfferClients", "Client_NationalId", c => c.Int(nullable: false));
            AlterColumn("dbo.PackageClients", "Client_NationalId", c => c.Int(nullable: false));
            AlterColumn("dbo.ClientCars", "Client_NationalId", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.Clients", "NationalId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.OfferClients", new[] { "Offer_ID", "Client_NationalId" });
            AddPrimaryKey("dbo.PackageClients", new[] { "Package_ID", "Client_NationalId" });
            AddPrimaryKey("dbo.ClientCars", new[] { "Client_NationalId", "Car_ID" });
            AddPrimaryKey("dbo.Clients", "NationalId");
            CreateIndex("dbo.OfferClients", "Client_NationalId");
            CreateIndex("dbo.PackageClients", "Client_NationalId");
            CreateIndex("dbo.ClientCars", "Client_NationalId");
            AddForeignKey("dbo.OfferClients", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
            AddForeignKey("dbo.PackageClients", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
            AddForeignKey("dbo.ClientCars", "Client_NationalId", "dbo.Clients", "NationalId", cascadeDelete: true);
        }
    }
}
