namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedMatchupinSportclasstocombineHomeandAwayteamsintostring : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Sport", "Matchup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sport", "Matchup", c => c.String());
        }
    }
}
