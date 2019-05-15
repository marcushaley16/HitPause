namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Removedlimitationsonnumberofcharactersonfilmsynopses : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Film", "Synopsis", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Film", "Synopsis", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
