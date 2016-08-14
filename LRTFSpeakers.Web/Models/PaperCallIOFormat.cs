using System.Collections.Generic;

namespace LRTFSpeakers.Web.Models
{
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
        public string @abstract { get; set; }
        public string description { get; set; }
        public string notes { get; set; }
        public string audience_level { get; set; }
        public List<string> tag_list { get; set; }
        public double rating { get; set; }
    }
}