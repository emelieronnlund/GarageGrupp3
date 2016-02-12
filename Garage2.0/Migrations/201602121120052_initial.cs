namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Color = c.String(),
                        Owner = c.String(),
                        RegNr = c.String(),
                        ParkingIn = c.DateTime(),
                        ParkingOut = c.DateTime(),
                        ParkingSpaceNr = c.Int(nullable: false),
                        Reserved = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Vehicles");
        }
    }
}
