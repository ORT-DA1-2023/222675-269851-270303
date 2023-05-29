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
                        Name = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.FigureEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Radius = c.Int(nullable: false),
                        Client_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ClientEntities", t => t.Client_Name)
                .Index(t => t.Client_Name);
            
            CreateTable(
                "dbo.MaterialEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                        Blur = c.Int(nullable: false),
                        ClientEntity_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Name)
                .Index(t => t.ClientEntity_Name);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        ClientEntity_Name = c.String(maxLength: 128),
                        FigureEntity_Name = c.String(maxLength: 128),
                        MaterialEntity_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Name)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Name)
                .ForeignKey("dbo.FigureEntities", t => t.FigureEntity_Name)
                .ForeignKey("dbo.MaterialEntities", t => t.MaterialEntity_Name)
                .Index(t => t.ClientEntity_Name)
                .Index(t => t.FigureEntity_Name)
                .Index(t => t.MaterialEntity_Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", "MaterialEntity_Name", "dbo.MaterialEntities");
            DropForeignKey("dbo.ModelEntities", "FigureEntity_Name", "dbo.FigureEntities");
            DropForeignKey("dbo.ModelEntities", "ClientEntity_Name", "dbo.ClientEntities");
            DropForeignKey("dbo.MaterialEntities", "ClientEntity_Name", "dbo.ClientEntities");
            DropForeignKey("dbo.FigureEntities", "Client_Name", "dbo.ClientEntities");
            DropIndex("dbo.ModelEntities", new[] { "MaterialEntity_Name" });
            DropIndex("dbo.ModelEntities", new[] { "FigureEntity_Name" });
            DropIndex("dbo.ModelEntities", new[] { "ClientEntity_Name" });
            DropIndex("dbo.MaterialEntities", new[] { "ClientEntity_Name" });
            DropIndex("dbo.FigureEntities", new[] { "Client_Name" });
            DropTable("dbo.ModelEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.FigureEntities");
            DropTable("dbo.ClientEntities");
        }
    }
}
