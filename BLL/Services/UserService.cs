using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool ChangePassword(int id, string password)
        {
            return _userRepository.ChangePassword(id, password);
        }

        public UserModel? Create(UserModel user)
        {
            return _userRepository.Create(user);
        }

        public bool Delete(int id)
        {
            return _userRepository.Delete(id);
        }

        public List<UserModel> GetAll()
        {
            return _userRepository.GetAll();
        }

        public UserModel? GetById(int id)
        {
            return _userRepository.GetById(id);
        }
    }
}
