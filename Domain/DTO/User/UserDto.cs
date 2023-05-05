using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO.User
{
    public class UserDto
    {
        public UserDto(int id, string firstname, string lastname, string email, DateTime birthdate)
        {
            Id = id;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Birthdate = birthdate;
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public DateTime Birthdate { get; set; }
    }
}
