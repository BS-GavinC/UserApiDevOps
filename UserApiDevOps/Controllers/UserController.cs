using BLL.Interfaces;
using Domain.DTO.User;
using Domain.Forms.User;
using Domain.Mappers;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUserDevOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDto>> GetAll()
        {
            return Ok(_userService.GetAll().ToUserDtoList());
        }

        [HttpGet("{id:int}")]
        public ActionResult<UserDto> GetById(int id)
        {
            UserModel? model = _userService.GetById(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model.ToUserDTO());

        }

        [HttpPost("register")]
        public ActionResult<UserDto> Create(CreateUserForm createForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UserModel? user = _userService.Create(createForm.ToUserModel());

            if (user == null) return BadRequest();



            return Created($"/api/user/{user.Id}", user);

            
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (_userService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPatch]
        public IActionResult ChangePassword(int id, ChangePasswordForm changePwdForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (_userService.ChangePassword(id, changePwdForm.Password))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUserForm loginForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int? userId = _userService.Login(loginForm.Email, loginForm.Password);

            if(userId is null)
            {
                return Problem(
                    detail: "Credential invalide",
                    statusCode: 400
                );
            }

            // TODO Change this to use JWT ;)
            return Ok(userId);
        }

    }
}
