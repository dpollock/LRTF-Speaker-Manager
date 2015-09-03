namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerMoreFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "Twitter", c => c.String());
            AddColumn("dbo.Speakers", "Company", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "Company");
            DropColumn("dbo.Speakers", "Twitter");
        }
    }
}
