namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedpropertiesforPostclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Post", "FilmId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Post", "FilmId");
        }
    }
}
