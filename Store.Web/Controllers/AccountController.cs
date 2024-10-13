using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Data.Entities.Identity;
using Store.Services.HandleResponse;
using Store.Services.Services.UserServices;
using Store.Services.Services.UserServices.Dtos;

namespace Store.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(IUserService userService,
            UserManager<AppUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var User=await _userService.Login(loginDto);
            if (User == null)
                return BadRequest(new CustomExeption(400, "Email Is Not Esist"));
            return Ok(User);
        }

        [HttpPost]
        public async Task<ActionResult<UserDto>> Register(RegisterDto input)
        {
            var User = await _userService.Register(input);
            if (User == null)
                return BadRequest(new CustomExeption(400, "Email Alredy Esist"));
            return Ok(User);
        }
        [HttpGet]
        [Authorize]
        public async Task<UserDto> GetCurrentUserDtails()
        {
            var UserId = User?.FindFirst("UserId");
            var user=await _userManager.FindByIdAsync(UserId.Value);
            return new UserDto
            {
                Id = Guid.Parse(user.Id),
                DisplayName = user.Displayname,
                Email = user.Email,
            };

        }
    }
}
