using Database2.Models;
using System.ComponentModel.DataAnnotations;

namespace Tuto_06.WebApi.CustomerValidators.Attributes
{
    public class CustomeAttribute :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Customer? customer = validationContext.ObjectInstance as Customer;

            if(customer is null)
            {
                return new ValidationResult("Validation fail");
            };

            if(customer.CustomerId is null)
            {
                return new ValidationResult("Customer Id fields is required");
            };

            return ValidationResult.Success;

        }
    }
}
