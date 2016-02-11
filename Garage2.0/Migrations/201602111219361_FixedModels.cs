namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "Owner", c => c.String());
            AddColumn("dbo.Vehicles", "RegNr", c => c.String());
            AddColumn("dbo.Vehicles", "ParkingIn", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "ParkingOut", c => c.DateTime(nullable: false));
            AddColumn("dbo.Vehicles", "ParkingSpaceNr", c => c.Int(nullable: false));
            AddColumn("dbo.Vehicles", "Reserved", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "Reserved");
            DropColumn("dbo.Vehicles", "ParkingSpaceNr");
            DropColumn("dbo.Vehicles", "ParkingOut");
            DropColumn("dbo.Vehicles", "ParkingIn");
            DropColumn("dbo.Vehicles", "RegNr");
            DropColumn("dbo.Vehicles", "Owner");
        }
    }
}
