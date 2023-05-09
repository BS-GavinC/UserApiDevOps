using APIUserDevOps.Helpers;
using BLL.Interfaces;
using Domain.DTO.Jwt;
using Domain.DTO.User;
using Domain.Forms.User;
using Domain.Mappers;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIUserDevOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        private readonly JwtHelper _JwtHelper;

        public UserController(IUserService userService, JwtHelper jwtHelper)
        {
            _userService = userService;
            _JwtHelper = jwtHelper;
        }

        /// <summary>
        /// UserId obtenu via l'authentification du l'utilisateur (via le JWT Bearer)
        /// </summary>
        private int? UserId
        {
            get
            {
                string? tokenId = User?.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
                return (tokenId is null) ? null : int.Parse(tokenId);
            }
        }


        [HttpGet]
        [AllowAnonymous] // Déactive l'attirubte [Authorize] de la classe
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
        [AllowAnonymous]
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
        [Authorize(Roles = "Admin")]
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
        public IActionResult ChangePassword([FromBody] ChangePasswordForm changePwdForm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // Check UserId in authentification (by JWT)
            if (UserId is null)
            {
                return Forbid();
            }

            if (_userService.ChangePassword((int)UserId, changePwdForm.Password))
            {
                return NoContent();
            }

            return BadRequest();
        }

        [HttpPost("login")]
        [AllowAnonymous]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(JwtDto))]
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

            UserModel? userModel = _userService.GetById((int)userId);

            if (userModel is null)
            {
                return Problem(statusCode: StatusCodes.Status500InternalServerError);
            }
            string token = _JwtHelper.CreateToken(userModel);

            // Envoi d'un JWT avec les informations de l'utilisateur
            return Ok(new JwtDto() { Token = token });
        }

    }
}
