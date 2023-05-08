using BLL.Interfaces;
using DAL.Interfaces;
using Domain.Models;
using Isopoh.Cryptography.Argon2;
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

        public int? Login(string email, string password)
        {
            UserModel? user = _userRepository.GetByEmail(email);

            if (user is null)
                return null;

            if (!Argon2.Verify(user.Password, password))
                return null;

            return user.Id;
        }

        public bool ChangePassword(int id, string password)
        {
            return _userRepository.ChangePassword(id, Argon2.Hash(password));
        }

        public UserModel? Create(UserModel user)
        {
            UserModel userSecure = new UserModel(
                user.Firstname,
                user.Lastname,
                user.Email,
                Argon2.Hash(user.Password),
                user.Birthdate
            );

            return _userRepository.Create(userSecure);
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
