using Database2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Database2.ValidationAttributes
{
    internal class CustomerZipCode : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var customer = validationContext.ObjectInstance as Customer;

            if (customer!.PostalCode is null)
            {
                return new ValidationResult("Fail");
            }
            return ValidationResult.Success;
        }
    }
}
