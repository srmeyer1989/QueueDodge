namespace QueueDodge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11212015 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Characters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CharacterName = c.String(),
                        RegionID = c.Int(nullable: false),
                        RealmID = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        RaceID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                        FactionID = c.Int(nullable: false),
                        SpecID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .ForeignKey("dbo.Factions", t => t.FactionID)
                .ForeignKey("dbo.Races", t => t.RaceID)
                .ForeignKey("dbo.Realms", t => t.RealmID)
                .ForeignKey("dbo.Regions", t => t.RegionID)
                .ForeignKey("dbo.Specializations", t => t.SpecID)
                .Index(t => t.RegionID)
                .Index(t => t.RealmID)
                .Index(t => t.RaceID)
                .Index(t => t.ClassID)
                .Index(t => t.FactionID)
                .Index(t => t.SpecID);
            
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        ClassID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .Index(t => t.ClassID);
            
            CreateTable(
                "dbo.Factions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        FactionID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Factions", t => t.FactionID)
                .Index(t => t.FactionID);
            
            CreateTable(
                "dbo.Realms",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                        Slug = c.String(),
                        RegionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Regions", t => t.RegionID)
                .Index(t => t.RegionID);
            
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        ID = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.LadderChanges",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        LadderComparisonID = c.Int(nullable: false),
                        PreviousRequestID = c.Int(nullable: false),
                        CurrentRequestID = c.Int(nullable: false),
                        Bracket = c.String(),
                        Name = c.String(),
                        RealmID = c.Int(nullable: false),
                        RegionID = c.Int(nullable: false),
                        PreviousFaction = c.Int(nullable: false),
                        DetectedFaction = c.Int(nullable: false),
                        PreviousRace = c.Int(nullable: false),
                        DetectedRace = c.Int(nullable: false),
                        PreviousClass = c.Int(nullable: false),
                        DetectedClass = c.Int(nullable: false),
                        PreviousSpec = c.Int(nullable: false),
                        DetectedSpec = c.Int(nullable: false),
                        PreviousRanking = c.Int(nullable: false),
                        PreviousRating = c.Int(nullable: false),
                        DetectedRanking = c.Int(nullable: false),
                        DetectedRating = c.Int(nullable: false),
                        PreviousSeasonWins = c.Int(nullable: false),
                        DetectedSeasonWins = c.Int(nullable: false),
                        PreviousSeasonLosses = c.Int(nullable: false),
                        DetectedSeasonLosses = c.Int(nullable: false),
                        PreviousWeeklyLosses = c.Int(nullable: false),
                        DetectedWeeklyLosses = c.Int(nullable: false),
                        PreviousWeeklyWins = c.Int(nullable: false),
                        DetectedWeeklyWins = c.Int(nullable: false),
                        PreviousGenderID = c.Int(nullable: false),
                        DetectedGenderID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.LeaderboardComparisons", t => t.LadderComparisonID)
                .ForeignKey("dbo.Realms", t => t.RealmID)
                .Index(t => t.LadderComparisonID)
                .Index(t => t.RealmID);
            
            CreateTable(
                "dbo.LeaderboardComparisons",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CurrentRequestID = c.Int(nullable: false),
                        PreviousRequestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Requests", t => t.CurrentRequestID)
                .ForeignKey("dbo.Requests", t => t.PreviousRequestID)
                .Index(t => t.CurrentRequestID)
                .Index(t => t.PreviousRequestID);
            
            CreateTable(
                "dbo.Requests",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestType = c.String(),
                        RequestDate = c.DateTime(nullable: false),
                        RegionID = c.Int(nullable: false),
                        Locale = c.String(),
                        Url = c.String(),
                        Duration = c.Double(nullable: false),
                        Bracket = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Leaderboards",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RequestID = c.Int(nullable: false),
                        Bracket = c.String(),
                        RegionID = c.Int(nullable: false),
                        Ranking = c.Int(nullable: false),
                        Rating = c.Int(nullable: false),
                        Name = c.String(),
                        RealmID = c.Int(nullable: false),
                        RealmName = c.String(),
                        RealmSlug = c.String(),
                        RaceID = c.Int(nullable: false),
                        ClassID = c.Int(nullable: false),
                        SpecID = c.Int(nullable: false),
                        FactionID = c.Int(nullable: false),
                        GenderID = c.Int(nullable: false),
                        SeasonWins = c.Int(nullable: false),
                        SeasonLosses = c.Int(nullable: false),
                        WeeklyWins = c.Int(nullable: false),
                        WeeklyLosses = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Classes", t => t.ClassID)
                .ForeignKey("dbo.Factions", t => t.FactionID)
                .ForeignKey("dbo.Races", t => t.RaceID)
                .ForeignKey("dbo.Realms", t => t.RealmID)
                .ForeignKey("dbo.Regions", t => t.RegionID)
                .ForeignKey("dbo.Requests", t => t.RequestID)
                .ForeignKey("dbo.Specializations", t => t.SpecID)
                .Index(t => t.RequestID)
                .Index(t => t.RegionID)
                .Index(t => t.RealmID)
                .Index(t => t.RaceID)
                .Index(t => t.ClassID)
                .Index(t => t.SpecID)
                .Index(t => t.FactionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Leaderboards", "SpecID", "dbo.Specializations");
            DropForeignKey("dbo.Leaderboards", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.Leaderboards", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Leaderboards", "RealmID", "dbo.Realms");
            DropForeignKey("dbo.Leaderboards", "RaceID", "dbo.Races");
            DropForeignKey("dbo.Leaderboards", "FactionID", "dbo.Factions");
            DropForeignKey("dbo.Leaderboards", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.LadderChanges", "RealmID", "dbo.Realms");
            DropForeignKey("dbo.LadderChanges", "LadderComparisonID", "dbo.LeaderboardComparisons");
            DropForeignKey("dbo.LeaderboardComparisons", "PreviousRequestID", "dbo.Requests");
            DropForeignKey("dbo.LeaderboardComparisons", "CurrentRequestID", "dbo.Requests");
            DropForeignKey("dbo.Characters", "SpecID", "dbo.Specializations");
            DropForeignKey("dbo.Characters", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Characters", "RealmID", "dbo.Realms");
            DropForeignKey("dbo.Realms", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Characters", "RaceID", "dbo.Races");
            DropForeignKey("dbo.Races", "FactionID", "dbo.Factions");
            DropForeignKey("dbo.Characters", "FactionID", "dbo.Factions");
            DropForeignKey("dbo.Characters", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Specializations", "ClassID", "dbo.Classes");
            DropIndex("dbo.Leaderboards", new[] { "FactionID" });
            DropIndex("dbo.Leaderboards", new[] { "SpecID" });
            DropIndex("dbo.Leaderboards", new[] { "ClassID" });
            DropIndex("dbo.Leaderboards", new[] { "RaceID" });
            DropIndex("dbo.Leaderboards", new[] { "RealmID" });
            DropIndex("dbo.Leaderboards", new[] { "RegionID" });
            DropIndex("dbo.Leaderboards", new[] { "RequestID" });
            DropIndex("dbo.LeaderboardComparisons", new[] { "PreviousRequestID" });
            DropIndex("dbo.LeaderboardComparisons", new[] { "CurrentRequestID" });
            DropIndex("dbo.LadderChanges", new[] { "RealmID" });
            DropIndex("dbo.LadderChanges", new[] { "LadderComparisonID" });
            DropIndex("dbo.Realms", new[] { "RegionID" });
            DropIndex("dbo.Races", new[] { "FactionID" });
            DropIndex("dbo.Specializations", new[] { "ClassID" });
            DropIndex("dbo.Characters", new[] { "SpecID" });
            DropIndex("dbo.Characters", new[] { "FactionID" });
            DropIndex("dbo.Characters", new[] { "ClassID" });
            DropIndex("dbo.Characters", new[] { "RaceID" });
            DropIndex("dbo.Characters", new[] { "RealmID" });
            DropIndex("dbo.Characters", new[] { "RegionID" });
            DropTable("dbo.Leaderboards");
            DropTable("dbo.Requests");
            DropTable("dbo.LeaderboardComparisons");
            DropTable("dbo.LadderChanges");
            DropTable("dbo.Regions");
            DropTable("dbo.Realms");
            DropTable("dbo.Races");
            DropTable("dbo.Factions");
            DropTable("dbo.Specializations");
            DropTable("dbo.Classes");
            DropTable("dbo.Characters");
        }
    }
}
