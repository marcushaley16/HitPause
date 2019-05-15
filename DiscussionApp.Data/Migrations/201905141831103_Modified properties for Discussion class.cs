namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedpropertiesforDiscussionclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussion", "FilmId", c => c.Int(nullable: false));
            AddColumn("dbo.Discussion", "TelevisionId", c => c.Int(nullable: false));
            AddColumn("dbo.Discussion", "SportId", c => c.Int(nullable: false));
            CreateIndex("dbo.Discussion", "FilmId");
            CreateIndex("dbo.Discussion", "TelevisionId");
            CreateIndex("dbo.Discussion", "SportId");
            AddForeignKey("dbo.Discussion", "FilmId", "dbo.Film", "FilmId", cascadeDelete: true);
            AddForeignKey("dbo.Discussion", "SportId", "dbo.Sport", "SportId", cascadeDelete: true);
            AddForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow", "TelevisionId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussion", "TelevisionId", "dbo.TVShow");
            DropForeignKey("dbo.Discussion", "SportId", "dbo.Sport");
            DropForeignKey("dbo.Discussion", "FilmId", "dbo.Film");
            DropIndex("dbo.Discussion", new[] { "SportId" });
            DropIndex("dbo.Discussion", new[] { "TelevisionId" });
            DropIndex("dbo.Discussion", new[] { "FilmId" });
            DropColumn("dbo.Discussion", "SportId");
            DropColumn("dbo.Discussion", "TelevisionId");
            DropColumn("dbo.Discussion", "FilmId");
        }
    }
}
