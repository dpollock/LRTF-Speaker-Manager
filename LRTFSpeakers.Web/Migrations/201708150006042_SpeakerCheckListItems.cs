namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SpeakerCheckListItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "HasInitialEmail", c => c.Boolean(nullable: false));
            AddColumn("dbo.Speakers", "HasHotelHandled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Speakers", "HasConfirmedWebsiteDetails", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "HasConfirmedWebsiteDetails");
            DropColumn("dbo.Speakers", "HasHotelHandled");
            DropColumn("dbo.Speakers", "HasInitialEmail");
        }
    }
}
