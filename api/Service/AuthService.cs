using api.Dtos.Auth;
using api.Interface;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Service
{

    public class AuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly EmailService _emailService;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService, EmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _emailService = emailService;
        }

        public async Task<IdentityResult> Register(CreateUserDto createUserDto)
        {
            var user = new User
            {
                UserName = createUserDto.Email,
                Email = createUserDto.Email,
                // first_name = createUserDto.FirstName,
                // last_name = createUserDto.LastName,
                EmailConfirmed = true
            };

            return await _userManager.CreateAsync(user, createUserDto.Password);
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new Exception("Invalid login attempt.");
            }

            return _tokenService.GenerateToken(user);
        }

        public async Task ForgotPassword(ForgotPasswordDto forgotPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email);

            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = "reset-password-link";

            await _emailService.SendPasswordResetLink(user.Email!, resetLink);
        }

        public async Task<IdentityResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            var user = await _userManager.FindByEmailAsync(resetPasswordDto.Email);

            if (user == null)
            {
                throw new Exception("Invalid user.");
            }

            return await _userManager.ResetPasswordAsync(user, resetPasswordDto.Token, resetPasswordDto.NewPassword);
        }

    }
}