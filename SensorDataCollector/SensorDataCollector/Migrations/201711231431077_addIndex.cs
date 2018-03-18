namespace SensorDataCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ApiKeys", "KeyHash", name: "ApiHash");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ApiKeys", "ApiHash");
        }
    }
}
