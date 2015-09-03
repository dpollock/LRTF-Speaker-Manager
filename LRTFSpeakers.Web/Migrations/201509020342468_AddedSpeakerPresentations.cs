namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSpeakerPresentations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryID = c.Int(nullable: false),
                        Track = c.String(),
                        TopicTitle = c.String(),
                        TopicDescription = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        Room = c.String(),
                        SessionNumber = c.Int(nullable: false),
                        MainSpeaker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Speakers", t => t.MainSpeaker_Id)
                .Index(t => t.MainSpeaker_Id);
            
            CreateTable(
                "dbo.Speakers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Photo = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Address = c.String(),
                        Address2 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Bio = c.String(),
                        Website = c.String(),
                        ShirtSize = c.String(),
                        AttendingSpeakerDinner = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presentations", "MainSpeaker_Id", "dbo.Speakers");
            DropIndex("dbo.Presentations", new[] { "MainSpeaker_Id" });
            DropTable("dbo.Speakers");
            DropTable("dbo.Presentations");
        }
    }
}
