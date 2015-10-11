namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MarkPresAsPrimary : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentations", "IsPrimaryPres", c => c.Boolean(nullable: false, defaultValue: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presentations", "IsPrimaryPres");
        }
    }
}
