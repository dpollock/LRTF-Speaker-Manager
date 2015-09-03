namespace LRTFSpeakers.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SpeakerDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryID = c.Int(nullable: false),
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
                        Track = c.String(),
                        TopicTitle = c.String(),
                        TopicDescription = c.String(),
                        Bio = c.String(),
                        Website = c.String(),
                        ShirtSize = c.String(),
                        Comments = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SpeakerDatas");
        }
    }
}
