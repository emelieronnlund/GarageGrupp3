namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "ParkingIn", c => c.DateTime());
            AlterColumn("dbo.Vehicles", "ParkingOut", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "ParkingOut", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vehicles", "ParkingIn", c => c.DateTime(nullable: false));
        }
    }
}
