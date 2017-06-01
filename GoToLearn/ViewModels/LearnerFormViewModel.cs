using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoToLearn.ViewModels
{
    public class LearnerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Learner Learner { get; set; }
    }
}