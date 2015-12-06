namespace QueueDodge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FUCK3 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Realms", "Type");
            DropColumn("dbo.Realms", "Status");
            DropColumn("dbo.Realms", "Population");
            DropColumn("dbo.Realms", "Queue");
            DropColumn("dbo.Realms", "Battlegroup");
            DropColumn("dbo.Realms", "Locale");
            DropColumn("dbo.Realms", "Timezone");
            DropColumn("dbo.Realms", "WintergraspArea");
            DropColumn("dbo.Realms", "WintergraspControllingFaction");
            DropColumn("dbo.Realms", "WintergraspStatus");
            DropColumn("dbo.Realms", "TolBaradArea");
            DropColumn("dbo.Realms", "TolBaradControllingFaction");
            DropColumn("dbo.Realms", "TolBaradStatus");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Realms", "TolBaradStatus", c => c.Int());
            AddColumn("dbo.Realms", "TolBaradControllingFaction", c => c.Int());
            AddColumn("dbo.Realms", "TolBaradArea", c => c.Int());
            AddColumn("dbo.Realms", "WintergraspStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Realms", "WintergraspControllingFaction", c => c.Int(nullable: false));
            AddColumn("dbo.Realms", "WintergraspArea", c => c.Int(nullable: false));
            AddColumn("dbo.Realms", "Timezone", c => c.String());
            AddColumn("dbo.Realms", "Locale", c => c.String());
            AddColumn("dbo.Realms", "Battlegroup", c => c.String());
            AddColumn("dbo.Realms", "Queue", c => c.Boolean(nullable: false));
            AddColumn("dbo.Realms", "Population", c => c.String());
            AddColumn("dbo.Realms", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Realms", "Type", c => c.String());
        }
    }
}
