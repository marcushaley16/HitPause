namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedpropertiesinDiscussionclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discussion", "Sport_SportId", "dbo.Sport");
            DropForeignKey("dbo.Discussion", "TVShow_TelevisionId", "dbo.TVShow");
            DropIndex("dbo.Discussion", new[] { "Sport_SportId" });
            DropIndex("dbo.Discussion", new[] { "TVShow_TelevisionId" });
            AlterColumn("dbo.Discussion", "Title", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Discussion", "Sport_SportId");
            DropColumn("dbo.Discussion", "TVShow_TelevisionId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discussion", "TVShow_TelevisionId", c => c.Int());
            AddColumn("dbo.Discussion", "Sport_SportId", c => c.Int());
            AlterColumn("dbo.Discussion", "Title", c => c.String(nullable: false, maxLength: 30));
            CreateIndex("dbo.Discussion", "TVShow_TelevisionId");
            CreateIndex("dbo.Discussion", "Sport_SportId");
            AddForeignKey("dbo.Discussion", "TVShow_TelevisionId", "dbo.TVShow", "TelevisionId");
            AddForeignKey("dbo.Discussion", "Sport_SportId", "dbo.Sport", "SportId");
        }
    }
}
