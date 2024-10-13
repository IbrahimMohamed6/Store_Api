using Microsoft.AspNetCore.Identity;
using Store.Data.Entities.Identity;
using Store.Services.Services.TokenService;
using Store.Services.Services.UserServices.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenServices _tokenServices;

        public UserService(SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,ITokenServices tokenServices)
        {
            _signInManager = signInManager;
           _userManager = userManager;
            _tokenServices = tokenServices;
        }


        public async Task<UserDto> Login(LoginDto input)
        {
            var User = await _userManager.FindByEmailAsync(input.Email);
            if (User == null)
                return null;
            var Result=await _signInManager.CheckPasswordSignInAsync(User,input.Password,false);

            if (!Result.Succeeded)
                throw new Exception("Login Faild ");
            return new UserDto
            {
                Id = Guid.Parse(User.Id),
                DisplayName = User.Displayname,
                Email = User.Email,
                Token = _tokenServices.GenerateToken(User)

            };
        }

        public async Task<UserDto> Register(RegisterDto input)
        {
            var User = await _userManager.FindByEmailAsync(input.Email);
            if (User is not null)
                return null;
            var appUser = new AppUser
            {
                Displayname = input.DisplayName,
                Email = input.Email,
                UserName = input.DisplayName,
            };
            var Result=await _userManager.CreateAsync(appUser,input.Password);
            if (!Result.Succeeded)
                throw new Exception(Result.Errors.Select(X=>X.Description).FirstOrDefault());

            return new UserDto
            {
                Id = Guid.Parse(appUser.Id),
                DisplayName = appUser.Displayname,
                Email = appUser.Email,
                Token = _tokenServices.GenerateToken(appUser)

            };


        }

      

    }
}
