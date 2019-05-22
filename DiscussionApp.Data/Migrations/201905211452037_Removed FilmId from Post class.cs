namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedFilmIdfromPostclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Post", "FilmId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Post", "FilmId", c => c.Int(nullable: false));
        }
    }
}
