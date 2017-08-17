using Remotion.Utilities;

namespace LRTFSpeakers.Web.Models
{
    public class SpeakerIndexVM
    {
        public string FullName { get; set; }
        public string PhotoUrl { get; set; }
        public string CityState { get; set; }
        public string Twitter { get; set; }
        public string Website { get; set; }
        public string Notes { get; set; }

        public string ShirtSize { get; set; }
        public bool AttendingSpeakerDinner { get; set; }

        public bool HasInitialEmail { get; set; }
        public bool HasHotelHandled { get; set; }
        public bool HasConfirmedWebsiteDetails { get; set; }

        public int TotalPresentations { get; set; }
        public int TotalAccepted { get; set; }
        public int SpeakerId { get; set; }
        public string LRTFNotes { get; set; }
    }
}