using GoToLearn.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoToLearn.ViewModels
{
    public class TrainingFormViewModel
    {
        
        
            public IEnumerable<Field> Fields { get; set; }

            public int? Id { get; set; }

            [Required]
            [StringLength(255)]
            public string Title { get; set; }

            [Display(Name = "Field")]
            [Required]
            public byte? FieldId { get; set; }

            [Display(Name = "Date Added")]
            [Required]
            public DateTime? DateAdded { get; set; }
            [Display(Name = "Date Added")]
            [Required]
            public DateTime TrainingDate { get; set; }

            [Display(Name = "Duration in hours")]
            [Range(1, 5)]
            [Required]
            public int Duration { get; set; }

            [Required]
            [StringLength(255)]
            [Display(Name = "Description")]
            public string Description { get; set; }
            public string Name
            {
                get
                {
                    return Id != 0 ? "Edit Movie" : "New Movie";
                }
            }

            public TrainingFormViewModel()
            {
                Id = 0;
            }

            public TrainingFormViewModel(Training training)
            {
                Id = training.Id;
                Title = training.Title;
                DateAdded = training.DateAdded;
                Duration = training.Duration;
                FieldId = training.FieldId;
                Description = training.Discription;
            }
        }
    
}