namespace QueueDodge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FUCK5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Requests", "Bracket", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Requests", "Bracket");
        }
    }
}
