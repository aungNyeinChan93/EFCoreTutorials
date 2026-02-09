using System.ComponentModel.DataAnnotations;
using Tuto_06.WebApi.CustomerValidators.Attributes;

namespace Tuto_06.WebApi.Models
{
    public class TestUser
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [TestUserPassword]
        public string Password { get; set; }
    }
}
