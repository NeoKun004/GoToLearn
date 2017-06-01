using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoToLearn.Dtos
{
    public class TrainerDto
    {
        public int Id { get; set; }
        public string Login { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Country { get; set; }
        public string Diploma { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        [Display(Name = "Field of expertise")]
        public byte FieldId { get; set; }

        [Display(Name = "Date of birth")]

        public DateTime? Birthdate { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }


        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }
    }
}