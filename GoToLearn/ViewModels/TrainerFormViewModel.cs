using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace GoToLearn.ViewModels
{
   
        public class TrainerFormViewModel
        {
            public IEnumerable<MembershipType> MembershipTypes { get; set; }
            public IEnumerable<Field> Fields { get; set; }
            [Display(Name = "Field")]
            [Required]
            public byte? FieldId { get; set; }
            public Trainer Trainer { get; set; }
        }
    
}