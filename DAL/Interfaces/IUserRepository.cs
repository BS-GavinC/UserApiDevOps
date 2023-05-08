using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {

        public List<UserModel> GetAll();

        public UserModel? GetById(int id);

        public UserModel? GetByEmail(string email);

        public UserModel? Create(UserModel user);

        public bool Delete(int id);

        public bool ChangePassword(int id, string password);

    }
}
