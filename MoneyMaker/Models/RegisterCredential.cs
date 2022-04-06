using System.ComponentModel.DataAnnotations;

namespace MoneyMaker.Models
{
    public class RegisterCredential
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
}