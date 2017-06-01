using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GoToLearn.ViewModels
{
    public class RandomViewModel
    {
        public class RandomTrainingViewModel
        {
            public Training Training { get; set; }
            public List<Learner> Learners { get; set; }
        }
    }
}