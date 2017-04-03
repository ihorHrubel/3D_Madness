namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DModels", "Url", c => c.String());
            AddColumn("dbo.Purchases", "ApplicationUserId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Purchases", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Purchases", "ApplicationUserId");
            DropColumn("dbo.DModels", "Url");
        }
    }
}
