namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LRTFNotes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Speakers", "LRTFNotes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Speakers", "LRTFNotes");
        }
    }
}
