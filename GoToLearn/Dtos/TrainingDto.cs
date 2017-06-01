using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GoToLearn.Models;

namespace GoToLearn.Dtos
{
    public class TrainingDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }


        public FieldDto Field { get; set; }
        [Required]
        [Display(Name = "Field")]
        public byte FieldId { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime TrainingDate { get; set; }
        public string Level { get; set; }
        public string Discription { get; set; }

        [Display(Name = "Duration in hours")]
        [Range(1, 5)]
        public int Duration { get; set; }


    }
}