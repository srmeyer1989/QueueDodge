namespace QueueDodge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableshrink : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Leaderboards", "ClassID", "dbo.Classes");
            DropForeignKey("dbo.Leaderboards", "FactionID", "dbo.Factions");
            DropForeignKey("dbo.Leaderboards", "RaceID", "dbo.Races");
            DropForeignKey("dbo.Leaderboards", "RealmID", "dbo.Realms");
            DropForeignKey("dbo.Leaderboards", "RegionID", "dbo.Regions");
            DropForeignKey("dbo.Leaderboards", "RequestID", "dbo.Requests");
            DropForeignKey("dbo.Leaderboards", "SpecID", "dbo.Specializations");
            DropIndex("dbo.Leaderboards", new[] { "RequestID" });
            DropIndex("dbo.Leaderboards", new[] { "RegionID" });
            DropIndex("dbo.Leaderboards", new[] { "RealmID" });
            DropIndex("dbo.Leaderboards", new[] { "RaceID" });
            DropIndex("dbo.Leaderboards", new[] { "ClassID" });
            DropIndex("dbo.Leaderboards", new[] { "SpecID" });
            DropIndex("dbo.Leaderboards", new[] { "FactionID" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Leaderboards", "FactionID");
            CreateIndex("dbo.Leaderboards", "SpecID");
            CreateIndex("dbo.Leaderboards", "ClassID");
            CreateIndex("dbo.Leaderboards", "RaceID");
            CreateIndex("dbo.Leaderboards", "RealmID");
            CreateIndex("dbo.Leaderboards", "RegionID");
            CreateIndex("dbo.Leaderboards", "RequestID");
            AddForeignKey("dbo.Leaderboards", "SpecID", "dbo.Specializations", "ID");
            AddForeignKey("dbo.Leaderboards", "RequestID", "dbo.Requests", "ID");
            AddForeignKey("dbo.Leaderboards", "RegionID", "dbo.Regions", "ID");
            AddForeignKey("dbo.Leaderboards", "RealmID", "dbo.Realms", "ID");
            AddForeignKey("dbo.Leaderboards", "RaceID", "dbo.Races", "ID");
            AddForeignKey("dbo.Leaderboards", "FactionID", "dbo.Factions", "ID");
            AddForeignKey("dbo.Leaderboards", "ClassID", "dbo.Classes", "ID");
        }
    }
}
