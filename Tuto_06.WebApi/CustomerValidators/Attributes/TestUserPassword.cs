using System.ComponentModel.DataAnnotations;
using Tuto_06.WebApi.Models;

namespace Tuto_06.WebApi.CustomerValidators.Attributes
{
    public class TestUserPassword:ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var testUser = validationContext.ObjectInstance as TestUser;

            if(testUser!.Password.Length >5)
            {
                return new ValidationResult("Fail");
            };

            return ValidationResult.Success;
        }
    }
}
