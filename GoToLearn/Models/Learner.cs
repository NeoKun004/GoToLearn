using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoToLearn.Models
{
    public class Learner
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public string Sex { get; set; }
        public string Country { get; set; }
        public string Level { get; set; }
        public int PhoneNumber { get; set; }

        [Display(Name = "Date of birth")]
        [Min18YearIfAMember]
        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}