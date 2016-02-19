namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialnew : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VehicleOwners",
                c => new
                    {
                        Vehicle_OwnerId = c.Int(nullable: false, identity: true),
                        OwnerName = c.String(),
                    })
                .PrimaryKey(t => t.Vehicle_OwnerId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleID = c.Int(nullable: false, identity: true),
                        Vehicle_OwnerId = c.Int(),
                        Vehicle_TypeId = c.Int(),
                        vehicleType = c.Int(nullable: false),
                        RegNr = c.String(nullable: false),
                        Color = c.String(),
                        ParkingIn = c.DateTime(),
                        ParkingOut = c.DateTime(),
                        ParkingSpaceNr = c.Int(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleID)
                .ForeignKey("dbo.VehicleOwners", t => t.Vehicle_OwnerId)
                .ForeignKey("dbo.Vehicle_Type", t => t.Vehicle_TypeId)
                .Index(t => t.Vehicle_OwnerId)
                .Index(t => t.Vehicle_TypeId);
            
            CreateTable(
                "dbo.Vehicle_Type",
                c => new
                    {
                        Vehicle_TypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Vehicle_TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "Vehicle_TypeId", "dbo.Vehicle_Type");
            DropForeignKey("dbo.Vehicles", "Vehicle_OwnerId", "dbo.VehicleOwners");
            DropIndex("dbo.Vehicles", new[] { "Vehicle_TypeId" });
            DropIndex("dbo.Vehicles", new[] { "Vehicle_OwnerId" });
            DropTable("dbo.Vehicle_Type");
            DropTable("dbo.Vehicles");
            DropTable("dbo.VehicleOwners");
        }
    }
}
