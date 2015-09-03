namespace LRTFSpeakers.Web.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SpeakerContext : DbContext
    {
        // Your context has been configured to use a 'SpeakerContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'LRTFSpeakers.Web.Models.SpeakerContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SpeakerContext' 
        // connection string in the application configuration file.
        public SpeakerContext()
            : base("name=SpeakerContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<SpeakerData> SpeakerDatas { get; set; }

        public virtual DbSet<Speaker> Speakers { get; set; }
        public virtual DbSet<Presentation> Presentations { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}