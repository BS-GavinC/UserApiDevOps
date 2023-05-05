using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel
    {

        private static int _id = 0;

        private static int NewId { get
            {
                _id++;
                return _id; 
            }
        }

        public UserModel(string firstname, string lastname, string email, string password, DateTime birthdate)
        {
            Id = NewId;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            Birthdate = birthdate;
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthdate { get; set; }

    }
}
