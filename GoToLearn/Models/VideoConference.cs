using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoToLearn.Models
{
    public class VideoConference
    {
        public VideoConference()
        {
            ChatMessages = new List<ChatMessages>();
        }
        public int Id { get; set; }
        public string ConferenceName { get; set; }
        public virtual ICollection<ChatMessages> ChatMessages { get; set; }
    }
}