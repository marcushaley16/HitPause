namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UncommentedTelevisionIdinDiscussionclassandeverythingneeded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discussion", "TelevisionId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Discussion", "TelevisionId");
        }
    }
}
