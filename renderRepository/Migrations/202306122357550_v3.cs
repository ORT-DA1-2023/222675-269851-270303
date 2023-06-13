namespace renderRepository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.LogEntities", "SceneEntity_Id", "dbo.SceneEntities");
            DropIndex("dbo.LogEntities", new[] { "SceneEntity_Id" });
            AddColumn("dbo.LogEntities", "NumberElements", c => c.Int(nullable: false));
            DropColumn("dbo.LogEntities", "NumberElementsInScene");
            DropColumn("dbo.LogEntities", "SceneEntity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LogEntities", "SceneEntity_Id", c => c.Int());
            AddColumn("dbo.LogEntities", "NumberElementsInScene", c => c.Int(nullable: false));
            DropColumn("dbo.LogEntities", "NumberElements");
            CreateIndex("dbo.LogEntities", "SceneEntity_Id");
            AddForeignKey("dbo.LogEntities", "SceneEntity_Id", "dbo.SceneEntities", "Id");
        }
    }
}
