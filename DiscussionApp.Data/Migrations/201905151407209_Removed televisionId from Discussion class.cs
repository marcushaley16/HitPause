namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedtelevisionIdfromDiscussionclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow");
            DropIndex("dbo.Discussion", new[] { "TelevisionId" });
            RenameColumn(table: "dbo.Discussion", name: "TelevisionId", newName: "TVShow_TelevisionId");
            AlterColumn("dbo.Discussion", "TVShow_TelevisionId", c => c.Int());
            CreateIndex("dbo.Discussion", "TVShow_TelevisionId");
            AddForeignKey("dbo.Discussion", "TVShow_TelevisionId", "dbo.TVShow", "TelevisionId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussion", "TVShow_TelevisionId", "dbo.TVShow");
            DropIndex("dbo.Discussion", new[] { "TVShow_TelevisionId" });
            AlterColumn("dbo.Discussion", "TVShow_TelevisionId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Discussion", name: "TVShow_TelevisionId", newName: "TelevisionId");
            CreateIndex("dbo.Discussion", "TelevisionId");
            AddForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow", "TelevisionId", cascadeDelete: true);
        }
    }
}
