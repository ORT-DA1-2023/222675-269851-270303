namespace renderRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LogEntities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RenderTimeInSeconds = c.Int(nullable: false),
                        RenderDate = c.DateTime(nullable: false),
                        TimeWindowSinceLastRender = c.String(),
                        NumberElementsInScene = c.Int(nullable: false),
                        Name = c.String(),
                        ClientEntity_Id = c.Int(),
                        SceneEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClientEntities", t => t.ClientEntity_Id)
                .ForeignKey("dbo.SceneEntities", t => t.SceneEntity_Id)
                .Index(t => t.ClientEntity_Id)
                .Index(t => t.SceneEntity_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LogEntities", "SceneEntity_Id", "dbo.SceneEntities");
            DropForeignKey("dbo.LogEntities", "ClientEntity_Id", "dbo.ClientEntities");
            DropIndex("dbo.LogEntities", new[] { "SceneEntity_Id" });
            DropIndex("dbo.LogEntities", new[] { "ClientEntity_Id" });
            DropTable("dbo.LogEntities");
        }
    }
}
