namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedDiscussionpropertyTitletoDiscussionTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussion", "DiscussionTitle", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Discussion", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discussion", "Title", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Discussion", "DiscussionTitle");
        }
    }
}
