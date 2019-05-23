namespace DiscussionApp.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discussion",
                c => new
                    {
                        DiscussionId = c.Guid(nullable: false),
                        CreatorId = c.Guid(nullable: false),
                        FilmId = c.Int(nullable: false),
                        TelevisionId = c.Int(nullable: false),
                        MediaType = c.Int(nullable: false),
                        DiscussionTitle = c.String(nullable: false, maxLength: 50),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.DiscussionId)
                .ForeignKey("dbo.Film", t => t.FilmId, cascadeDelete: true)
                .Index(t => t.FilmId);
            
            CreateTable(
                "dbo.Film",
                c => new
                    {
                        FilmId = c.Int(nullable: false, identity: true),
                        MediaType = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Director = c.String(nullable: false),
                        Writer = c.String(nullable: false),
                        Stars = c.String(nullable: false),
                        Cinematographer = c.String(nullable: false),
                        Editor = c.String(nullable: false),
                        Synopsis = c.String(nullable: false),
                        Genre1 = c.Int(nullable: false),
                        Genre2 = c.Int(nullable: false),
                        Year = c.String(nullable: false, maxLength: 4),
                        Released = c.Boolean(nullable: false),
                        Runtime = c.Int(nullable: false),
                        Rating = c.String(nullable: false, maxLength: 5),
                    })
                .PrimaryKey(t => t.FilmId);
            
            CreateTable(
                "dbo.Post",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        DiscussionId = c.Guid(nullable: false),
                        CreatorId = c.Guid(nullable: false),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        ModifiedUTC = c.DateTimeOffset(precision: 7),
                        Body = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Sport",
                c => new
                    {
                        SportId = c.Int(nullable: false, identity: true),
                        MediaType = c.Int(nullable: false),
                        League = c.Int(nullable: false),
                        HomeTeam = c.String(nullable: false),
                        AwayTeam = c.String(nullable: false),
                        Location = c.String(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Network = c.String(),
                        Score = c.String(),
                    })
                .PrimaryKey(t => t.SportId);
            
            CreateTable(
                "dbo.TVShow",
                c => new
                    {
                        TelevisionId = c.Int(nullable: false, identity: true),
                        MediaType = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        Creator = c.String(nullable: false),
                        Director = c.String(),
                        Writer = c.String(),
                        Stars = c.String(nullable: false),
                        Synopsis = c.String(nullable: false),
                        Genre1 = c.Int(nullable: false),
                        Genre2 = c.Int(nullable: false),
                        Network = c.String(nullable: false),
                        Released = c.Boolean(nullable: false),
                        Year = c.String(nullable: false),
                        DateAired = c.String(),
                        Runtime = c.Int(nullable: false),
                        Rating = c.String(nullable: false),
                        Cinematographer = c.String(),
                        Editor = c.String(),
                    })
                .PrimaryKey(t => t.TelevisionId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Discussion", "FilmId", "dbo.Film");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Discussion", new[] { "FilmId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.TVShow");
            DropTable("dbo.Sport");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Post");
            DropTable("dbo.Film");
            DropTable("dbo.Discussion");
        }
    }
}
