namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "PloneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "PloneNumber", c => c.String());
        }
    }
}
