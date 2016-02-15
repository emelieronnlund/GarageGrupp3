namespace Garage2._0.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vehicles", "Owner", c => c.String(nullable: false));
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vehicles", "RegNr", c => c.String());
            AlterColumn("dbo.Vehicles", "Owner", c => c.String());
        }
    }
}
