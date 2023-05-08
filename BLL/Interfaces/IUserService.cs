using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IUserService
    {

        public List<UserModel> GetAll();

        public UserModel? GetById(int id);

        public UserModel? Create(UserModel user);

        public bool Delete(int id);

        public bool ChangePassword(int id, string password);

        public int? Login(string email,  string password);
    }
}
