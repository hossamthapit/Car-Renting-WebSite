namespace Garage1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MIG1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Brand = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        NumberOfCars = c.Int(nullable: false),
                        PriceForDay = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        NationalId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Country = c.String(),
                        City = c.String(),
                        Street = c.String(),
                        Phone = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.NationalId);
            
            CreateTable(
                "dbo.Packages",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Period = c.Int(nullable: false),
                        Available = c.Boolean(nullable: false),
                        Notes = c.String(),
                        RentDate = c.DateTime(nullable: false),
                        PriceForDay = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Notes = c.String(),
                        Discount = c.Double(nullable: false),
                        Limit = c.Int(nullable: false),
                        Car_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Cars", t => t.Car_ID)
                .Index(t => t.Car_ID);
            
            CreateTable(
                "dbo.ClientCars",
                c => new
                    {
                        Client_NationalId = c.Int(nullable: false),
                        Car_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_NationalId, t.Car_ID })
                .ForeignKey("dbo.Clients", t => t.Client_NationalId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_ID, cascadeDelete: true)
                .Index(t => t.Client_NationalId)
                .Index(t => t.Car_ID);
            
            CreateTable(
                "dbo.PackageCars",
                c => new
                    {
                        Package_ID = c.Int(nullable: false),
                        Car_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Package_ID, t.Car_ID })
                .ForeignKey("dbo.Packages", t => t.Package_ID, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_ID, cascadeDelete: true)
                .Index(t => t.Package_ID)
                .Index(t => t.Car_ID);
            
            CreateTable(
                "dbo.PackageClients",
                c => new
                    {
                        Package_ID = c.Int(nullable: false),
                        Client_NationalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Package_ID, t.Client_NationalId })
                .ForeignKey("dbo.Packages", t => t.Package_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_NationalId, cascadeDelete: true)
                .Index(t => t.Package_ID)
                .Index(t => t.Client_NationalId);
            
            CreateTable(
                "dbo.OfferClients",
                c => new
                    {
                        Offer_ID = c.Int(nullable: false),
                        Client_NationalId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Offer_ID, t.Client_NationalId })
                .ForeignKey("dbo.Offers", t => t.Offer_ID, cascadeDelete: true)
                .ForeignKey("dbo.Clients", t => t.Client_NationalId, cascadeDelete: true)
                .Index(t => t.Offer_ID)
                .Index(t => t.Client_NationalId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.OfferClients", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.OfferClients", "Offer_ID", "dbo.Offers");
            DropForeignKey("dbo.PackageClients", "Client_NationalId", "dbo.Clients");
            DropForeignKey("dbo.PackageClients", "Package_ID", "dbo.Packages");
            DropForeignKey("dbo.PackageCars", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.PackageCars", "Package_ID", "dbo.Packages");
            DropForeignKey("dbo.ClientCars", "Car_ID", "dbo.Cars");
            DropForeignKey("dbo.ClientCars", "Client_NationalId", "dbo.Clients");
            DropIndex("dbo.OfferClients", new[] { "Client_NationalId" });
            DropIndex("dbo.OfferClients", new[] { "Offer_ID" });
            DropIndex("dbo.PackageClients", new[] { "Client_NationalId" });
            DropIndex("dbo.PackageClients", new[] { "Package_ID" });
            DropIndex("dbo.PackageCars", new[] { "Car_ID" });
            DropIndex("dbo.PackageCars", new[] { "Package_ID" });
            DropIndex("dbo.ClientCars", new[] { "Car_ID" });
            DropIndex("dbo.ClientCars", new[] { "Client_NationalId" });
            DropIndex("dbo.Offers", new[] { "Car_ID" });
            DropTable("dbo.OfferClients");
            DropTable("dbo.PackageClients");
            DropTable("dbo.PackageCars");
            DropTable("dbo.ClientCars");
            DropTable("dbo.Offers");
            DropTable("dbo.Packages");
            DropTable("dbo.Clients");
            DropTable("dbo.Cars");
        }
    }
}
