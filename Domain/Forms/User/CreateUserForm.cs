using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Forms.User
{
    public class CreateUserForm
    {

        [Required]
        [MinLength(2)]
        public string Firstname { get; set; }

        [Required]
        [MinLength(2)]
        public string Lastname { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*([^a-zA-Z\\d])).{8,}$")]
        public string Password { get; set; }

        [Required]
        public DateTime Birthdate { get; set; }

    }
}
