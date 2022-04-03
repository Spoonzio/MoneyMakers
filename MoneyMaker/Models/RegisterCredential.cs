using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.Models
{
    public class RegisterCredential
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }
    }
}