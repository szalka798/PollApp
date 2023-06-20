using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PollApp.Application.Helpers;
using PollApp.Application.Models.User;
using PollApp.DataAccess.Identity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace PollApp.Application.Services
{

    public interface IUserService
    {
        public Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel);
        public Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel);
    }
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager, IMapper mapper, SignInManager<ApplicationUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<LoginResponseModel> LoginAsync(LoginUserModel loginUserModel)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == loginUserModel.Username);
            if (user == null)
                throw new Exception();

            var signInResult = await _signInManager.PasswordSignInAsync(user, loginUserModel.Password, false, false);
            if (!signInResult.Succeeded)
                throw new Exception();

            var token = JwtHelper.GenerateToken(user, _configuration);

            return new LoginResponseModel
            {
                Token = token
            };
        }

        public async Task<CreateUserResponseModel> CreateAsync(CreateUserModel createUserModel)
        {
            var user = _mapper.Map<ApplicationUser>(createUserModel);

            var result = await _userManager.CreateAsync(user, createUserModel.Password);

            if (!result.Succeeded) throw new Exception();


            return new CreateUserResponseModel
            {
            };
        }

    }
}
