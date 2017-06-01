using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoToLearn.Models
{
    public class ChatMessages
    {
        public int Id { get; set; }
        public string Message { get; set; }

        public VideoConference VideoConferenceId { get; set; }
    }
}