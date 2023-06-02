namespace renderRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FigureEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        Radius = c.Double(nullable: false),
                        ClientEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => new { t.Name, t.ClientId })
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .Index(t => t.ClientEntity_Id);
            
            CreateTable(
                "dbo.MaterialEntities",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                        Blur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.ClientId })
                .ForeignKey("dbo.ClientEntities", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ClientId = c.String(nullable: false, maxLength: 128),
                        Client_Id = c.Int(),
                        FigureEntity_Name = c.String(maxLength: 128),
                        FigureEntity_ClientId = c.String(maxLength: 128),
                        MaterialEntity_Id = c.Int(),
                        MaterialEntity_ClientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Name, t.ClientId })
                .ForeignKey("dbo.ClientEntities", t => t.Client_Id)
                .ForeignKey("dbo.FigureEntities", t => new { t.FigureEntity_Name, t.FigureEntity_ClientId })
                .ForeignKey("dbo.MaterialEntities", t => new { t.MaterialEntity_Id, t.MaterialEntity_ClientId })
                .Index(t => t.Client_Id)
                .Index(t => new { t.FigureEntity_Name, t.FigureEntity_ClientId })
                .Index(t => new { t.MaterialEntity_Id, t.MaterialEntity_ClientId });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", new[] { "MaterialEntity_Id", "MaterialEntity_ClientId" }, "dbo.MaterialEntities");
            DropForeignKey("dbo.ModelEntities", new[] { "FigureEntity_Name", "FigureEntity_ClientId" }, "dbo.FigureEntities");
            DropForeignKey("dbo.ModelEntities", "Client_Id", "dbo.ClientEntities");
            DropForeignKey("dbo.MaterialEntities", "Id", "dbo.ClientEntities");
            DropForeignKey("dbo.FigureEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropIndex("dbo.ModelEntities", new[] { "MaterialEntity_Id", "MaterialEntity_ClientId" });
            DropIndex("dbo.ModelEntities", new[] { "FigureEntity_Name", "FigureEntity_ClientId" });
            DropIndex("dbo.ModelEntities", new[] { "Client_Id" });
            DropIndex("dbo.MaterialEntities", new[] { "Id" });
            DropIndex("dbo.FigureEntities", new[] { "ClientEntity_Id" });
            DropTable("dbo.ModelEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.FigureEntities");
            DropTable("dbo.ClientEntities");
        }
    }
}
