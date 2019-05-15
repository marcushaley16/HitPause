namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedquotepropertyfromFilmclass : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Film", "Quote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Film", "Quote", c => c.String());
        }
    }
}
