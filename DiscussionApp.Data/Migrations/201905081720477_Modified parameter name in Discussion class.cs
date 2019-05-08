namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedparameternameinDiscussionclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussion", "Comment", c => c.String());
            DropColumn("dbo.Discussion", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discussion", "Comments", c => c.String());
            DropColumn("dbo.Discussion", "Comment");
        }
    }
}
