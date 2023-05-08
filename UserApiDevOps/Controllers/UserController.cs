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
        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserDto>))]
        public ActionResult<IEnumerable<UserDto>> GetAll()
        {
            return Ok(_userService.GetAll().ToUserDtoList());
        }

        [HttpGet("{id:int}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<UserDto> GetById([FromRoute] int id)
        {
            UserModel? model = _userService.GetById(id);

            if (model is null)
            {
                return NotFound();
            }

            return Ok(model.ToUserDTO());
        }

        [HttpPost("register")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserDto> Create([FromBody] CreateUserForm createForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            UserDto? user = _userService.Create(createForm.ToUserModel())?.ToUserDTO();

            if (user == null) return BadRequest();

            return Created($"/api/user/{user.Id}", user);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete([FromRoute] int id)
        {
            if (_userService.Delete(id))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPatch]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ChangePassword([FromRoute] int id, [FromBody] ChangePasswordForm changePwdForm)
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
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(int))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Login([FromBody] LoginUserForm loginForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            int? userId = _userService.Login(loginForm.Email, loginForm.Password);

            if (userId is null)
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
