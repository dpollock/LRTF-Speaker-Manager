namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class speakernotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "Notes");
        }
    }
}
