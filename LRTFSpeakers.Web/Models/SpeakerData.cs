using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
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
        
        public virtual List<Presentation> Presentations { get; set; }
        public string Twitter { get; set; }
        public string Company { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public string LinkedIn { get; set; }

        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
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
}