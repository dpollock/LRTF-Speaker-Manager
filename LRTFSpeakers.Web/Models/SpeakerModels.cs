using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Mvc;

namespace LRTFSpeakers.Web.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }

        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        public string Website { get; set; }
        public string ShirtSize { get; set; }
        public bool AttendingSpeakerDinner { get; set; }

        public bool HasInitialEmail { get; set; }
        public bool HasHotelHandled { get; set; }
        public bool HasConfirmedWebsiteDetails { get; set; }
        
        public virtual List<Presentation> Presentations { get; set; }
        public string Twitter { get; set; }
        public string Company { get; set; }

        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string LinkedIn { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DataType(DataType.MultilineText)]
        public string LRTFNotes { get; set; }
    }

    public class Presentation
    {
        public virtual Speaker MainSpeaker { get; set; }

        public int Id { get; set; }
        public int EntryID { get; set; }
        public string Track { get; set; }
        public string TopicTitle { get; set; }

        [AllowHtml]
        [DataType(DataType.MultilineText)]
        public string TopicDescription { get; set; }

        public DateTime CreatedOn { get; set; }

        public int? Day { get; set; }
        public string Room { get; set; }
        public int? SessionNumber { get; set; }

        public Status Status { get; set; }

        public bool IsPrimaryPres { get; set; }
        public bool IsTimeSlotLocked { get; set; }
    }

    public enum Status
    {
        Submitted,
        Accepted,
        Rejected,
        Backup,
        AwaitingAccepted,
        SpeakerDeclined
    }

    public class SpeakerData
    {
        public int Id { get; set; }
        public int EntryID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Track { get; set; }
        public string TopicTitle { get; set; }
        public string TopicDescription { get; set; }
        public string Bio { get; set; }
        public string Website { get; set; }
        public string ShirtSize { get; set; }
        public string Comments { get; set; }
        public DateTime CreatedOn { get; set; }
    }

    public class PaperCallIOFormat
    {

        public string name { get; set; }
        public string email { get; set; }
        public string avatar { get; set; }
        public string location { get; set; }
        public string bio { get; set; }
        public string twitter { get; set; }
        public string url { get; set; }
        public string organization { get; set; }
        public string shirt_size { get; set; }
        public string title { get; set; }
        public string @abstract { get; set; } //
        public string description { get; set; }
        public string notes { get; set; }
        public string audience_level { get; set; }
        public List<string> tag_list { get; set; }
        public double rating { get; set; }
        public bool confirmed { get; set; }
        public string state { get; set; }
        public DateTime created_at { get; set; }

    }
}