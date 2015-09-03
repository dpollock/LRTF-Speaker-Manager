namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PresTweak : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Presentations", "SessionNumber", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Presentations", "SessionNumber", c => c.Int(nullable: false));
        }
    }
}
