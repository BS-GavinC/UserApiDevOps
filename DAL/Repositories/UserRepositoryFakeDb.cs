﻿using DAL.Context;
using DAL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class UserRepositoryFakeDb : IUserRepository
    {
        public bool ChangePassword(int id, string password)
        {
            UserModel? user = FakeDb.Users.FirstOrDefault(x => x?.Id == id, null);

            if (user is null)
            {
                return false;
            }

            user.Password = password;

            return true;
        }

        public UserModel? Create(UserModel user)
        {
            FakeDb.Users.Add(user);
            return user;
        }

        public bool Delete(int id)
        {
            UserModel? user = FakeDb.Users.FirstOrDefault(x => x?.Id == id, null);

            if (user is null)
            {
                return false;
            }

            FakeDb.Users.Remove(user);

            return true;

        }

        public List<UserModel> GetAll()
        {
            return FakeDb.Users;
        }

        public UserModel? GetById(int id)
        {
            return FakeDb.Users.SingleOrDefault(x => x?.Id == id, null);
        }


    }
}