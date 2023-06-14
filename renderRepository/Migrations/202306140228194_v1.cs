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
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Radius = c.Double(nullable: false),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Z = c.Double(nullable: false),
                        ClientEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .Index(t => t.ClientEntity_Id);
            
            CreateTable(
                "dbo.MaterialEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                        Blur = c.Double(nullable: false),
                        ClientEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .Index(t => t.ClientEntity_Id);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Preview = c.Binary(),
                        ClientEntity_Id = c.Int(),
                        FigureEntity_Id = c.Int(),
                        MaterialEntity_Id = c.Int(),
                        SceneEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .ForeignKey("dbo.FigureEntities", t => t.FigureEntity_Id)
                .ForeignKey("dbo.MaterialEntities", t => t.MaterialEntity_Id)
                .ForeignKey("dbo.SceneEntities", t => t.SceneEntity_Id)
                .Index(t => t.ClientEntity_Id)
                .Index(t => t.FigureEntity_Id)
                .Index(t => t.MaterialEntity_Id)
                .Index(t => t.SceneEntity_Id);
            
            CreateTable(
                "dbo.SceneEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        LastModificationDate = c.DateTime(nullable: false),
                        LastRenderizationDate = c.DateTime(),
                        Preview = c.Binary(),
                        Aperture = c.Double(nullable: false),
                        LookFromX = c.Double(nullable: false),
                        LookFromY = c.Double(nullable: false),
                        LookFromZ = c.Double(nullable: false),
                        LookAtX = c.Double(nullable: false),
                        LookAtY = c.Double(nullable: false),
                        LookAtZ = c.Double(nullable: false),
                        Fov = c.Int(nullable: false),
                        LensRadius = c.Double(nullable: false),
                        ClientEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .Index(t => t.ClientEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", "SceneEntity_Id", "dbo.SceneEntities");
            DropForeignKey("dbo.SceneEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropForeignKey("dbo.ModelEntities", "MaterialEntity_Id", "dbo.MaterialEntities");
            DropForeignKey("dbo.ModelEntities", "FigureEntity_Id", "dbo.FigureEntities");
            DropForeignKey("dbo.ModelEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropForeignKey("dbo.MaterialEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropForeignKey("dbo.FigureEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropIndex("dbo.SceneEntities", new[] { "ClientEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "SceneEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "MaterialEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "FigureEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "ClientEntity_Id" });
            DropIndex("dbo.MaterialEntities", new[] { "ClientEntity_Id" });
            DropIndex("dbo.FigureEntities", new[] { "ClientEntity_Id" });
            DropTable("dbo.SceneEntities");
            DropTable("dbo.ModelEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.FigureEntities");
            DropTable("dbo.ClientEntities");
        }
    }
}
