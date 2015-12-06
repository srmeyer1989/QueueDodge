namespace QueueDodge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FUCK4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.LadderChanges", "RealmID");
            AddForeignKey("dbo.LadderChanges", "RealmID", "dbo.Realms", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LadderChanges", "RealmID", "dbo.Realms");
            DropIndex("dbo.LadderChanges", new[] { "RealmID" });
        }
    }
}
