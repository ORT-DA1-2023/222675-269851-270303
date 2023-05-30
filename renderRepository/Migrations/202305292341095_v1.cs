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
                        Password = c.String(nullable: false),
                        RegisterDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.FigureEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false,maxLength: 128),
                        Radius = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.MaterialEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        Red = c.Int(nullable: false),
                        Green = c.Int(nullable: false),
                        Blue = c.Int(nullable: false),
                        Blur = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.Name)
                .Index(t => t.Name);
            
            CreateTable(
                "dbo.ModelEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 128),
                        FigureEntity_Id = c.Int(),
                        MaterialEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.Name)
                .ForeignKey("dbo.FigureEntities", t => t.FigureEntity_Id)
                .ForeignKey("dbo.MaterialEntities", t => t.MaterialEntity_Id)
                .Index(t => t.Name)
                .Index(t => t.FigureEntity_Id)
                .Index(t => t.MaterialEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ModelEntities", "MaterialEntity_Id", "dbo.MaterialEntities");
            DropForeignKey("dbo.ModelEntities", "FigureEntity_Id", "dbo.FigureEntities");
            DropForeignKey("dbo.ModelEntities", "Name", "dbo.ClientEntities");
            DropForeignKey("dbo.MaterialEntities", "Name", "dbo.ClientEntities");
            DropForeignKey("dbo.FigureEntities", "Name", "dbo.ClientEntities");
            DropIndex("dbo.ModelEntities", new[] { "MaterialEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "FigureEntity_Id" });
            DropIndex("dbo.ModelEntities", new[] { "Name" });
            DropIndex("dbo.MaterialEntities", new[] { "Name" });
            DropIndex("dbo.FigureEntities", new[] { "Name" });
            DropTable("dbo.ModelEntities");
            DropTable("dbo.MaterialEntities");
            DropTable("dbo.FigureEntities");
            DropTable("dbo.ClientEntities");
        }
    }
}
