﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class UserModel
    {
        public UserModel(string firstname, string lastname, string email, string password, DateTime birthdate)
        {
            Id = -1;
            Firstname = firstname;
            Lastname = lastname;
            Email = email;
            Password = password;
            Birthdate = birthdate;
            IsAdmin = false;
        }

        public UserModel(int id, string firstname, string lastname, string email, string password, DateTime birthdate, bool isAdmin)
            :this(firstname, lastname, email, password, birthdate)
        {
            Id = id;
            IsAdmin = isAdmin;
        }

        public int Id { get; set; }

        public string Firstname { get; set; }

        public string Lastname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime Birthdate { get; set; }
        
        public bool IsAdmin { get; set; }

    }
}
