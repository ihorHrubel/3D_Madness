namespace WebApplication2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DataMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Purchases", "Busket_Id", "dbo.Buskets");
            DropIndex("dbo.Purchases", new[] { "Busket_Id" });
            DropTable("dbo.Buskets");
            DropTable("dbo.Purchases");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Purchases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.Int(nullable: false),
                        DModelId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Busket_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Buskets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Purchases", "Busket_Id");
            AddForeignKey("dbo.Purchases", "Busket_Id", "dbo.Buskets", "Id");
        }
    }
}
