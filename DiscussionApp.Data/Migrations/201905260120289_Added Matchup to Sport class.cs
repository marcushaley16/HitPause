namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMatchuptoSportclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sport", "Matchup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sport", "Matchup");
        }
    }
}
