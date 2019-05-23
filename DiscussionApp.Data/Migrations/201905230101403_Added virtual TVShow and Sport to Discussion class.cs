namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedvirtualTVShowandSporttoDiscussionclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussion", "SportId", c => c.Int(nullable: false));
            CreateIndex("dbo.Discussion", "TelevisionId");
            CreateIndex("dbo.Discussion", "SportId");
            AddForeignKey("dbo.Discussion", "SportId", "dbo.Sport", "SportId", cascadeDelete: true);
            AddForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow", "TelevisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow");
            DropForeignKey("dbo.Discussion", "SportId", "dbo.Sport");
            DropIndex("dbo.Discussion", new[] { "SportId" });
            DropIndex("dbo.Discussion", new[] { "TelevisionId" });
            DropColumn("dbo.Discussion", "SportId");
        }
    }
}
