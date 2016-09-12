namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeslot : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentations", "IsTimeSlotLocked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presentations", "IsTimeSlotLocked");
        }
    }
}
