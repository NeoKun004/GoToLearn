using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoToLearn.Models
{
    public class Field
    {
        public byte Id { get; set; }

        
        [StringLength(255)]
        public string Name { get; set; }
    }
}