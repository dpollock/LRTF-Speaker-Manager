namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SlidesLink : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentations", "SlidesURL", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presentations", "SlidesURL");
        }
    }
}
