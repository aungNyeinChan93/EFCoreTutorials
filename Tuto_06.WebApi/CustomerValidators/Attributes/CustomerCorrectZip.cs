using Database2.Models;
using System.ComponentModel.DataAnnotations;

namespace Tuto_06.WebApi.CustomerValidators.Attributes
{
    public class CustomerCorrectZip :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            //return base.IsValid(value, validationContext);
            var customer = validationContext.ObjectInstance as Customer;
            if(customer!.PostalCode is null)
            {
                return new ValidationResult("fail");
            }
            return ValidationResult.Success;
        }
    }
}
