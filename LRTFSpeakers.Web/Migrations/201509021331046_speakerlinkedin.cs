namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class speakerlinkedin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "LinkedIn", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "LinkedIn");
        }
    }
}
