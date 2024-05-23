using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class ContainsAtSignAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string email = value.ToString();
                if (!email.Contains("@"))
                {
                    return new ValidationResult("Email must contain the '@' symbol.");
                }
            }
            return ValidationResult.Success;
        }
    }
}