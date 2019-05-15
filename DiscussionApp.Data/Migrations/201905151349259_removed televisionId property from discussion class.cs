namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedtelevisionIdpropertyfromdiscussionclass : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discussion", "SportId", "dbo.Sport");
            DropIndex("dbo.Discussion", new[] { "SportId" });
            RenameColumn(table: "dbo.Discussion", name: "SportId", newName: "Sport_SportId");
            AlterColumn("dbo.Discussion", "Sport_SportId", c => c.Int());
            CreateIndex("dbo.Discussion", "Sport_SportId");
            AddForeignKey("dbo.Discussion", "Sport_SportId", "dbo.Sport", "SportId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Discussion", "Sport_SportId", "dbo.Sport");
            DropIndex("dbo.Discussion", new[] { "Sport_SportId" });
            AlterColumn("dbo.Discussion", "Sport_SportId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Discussion", name: "Sport_SportId", newName: "SportId");
            CreateIndex("dbo.Discussion", "SportId");
            AddForeignKey("dbo.Discussion", "SportId", "dbo.Sport", "SportId", cascadeDelete: true);
        }
    }
}
