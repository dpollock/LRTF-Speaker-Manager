namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDayField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Presentations", "Day", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Presentations", "Day");
        }
    }
}
