using Domain.DTO.User;
using Domain.Forms.User;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mappers
{
    public static class UserMapper
    {

        public static UserDto ToUserDTO(this UserModel model)
        {
            return new UserDto(
                model.Id,
                model.Firstname,
                model.Lastname,
                model.Email,
                model.Birthdate
                );
        }

        public static IEnumerable<UserDto> ToUserDtoList(this IEnumerable<UserModel> models)
        {
            foreach (var model in models)
            {
                yield return model.ToUserDTO();
            }
        }

        public static UserModel ToUserModel(this CreateUserForm createForm)
        {
            return new UserModel(
                createForm.Firstname,
                createForm.Lastname,
                createForm.Email,
                createForm.Password,
                createForm.Birthdate
                );
        }

    }
}
