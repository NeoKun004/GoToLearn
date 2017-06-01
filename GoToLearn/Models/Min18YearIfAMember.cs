using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GoToLearn.Models
{
    public class Min18YearIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var learner = (Learner)validationContext.ObjectInstance;
            if (learner.MembershipTypeId == MembershipType.Unknown || learner.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (learner.Birthdate == null)
                return new ValidationResult("Birthdate is required ");
            var age = DateTime.Today.Year - learner.Birthdate.Value.Year;
            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Learner must be at least 18 years old to go as a member");
        }
    }
}