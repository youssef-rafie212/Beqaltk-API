using Core.Domain.Entities;
using Core.DTO.AccountDtos;
using Core.Enums;
using Core.Services_contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GroceryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IJwtServices _jwtServices;
        private readonly IEmailSender _emailSender;

        public AccountsController(
             UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager,
             RoleManager<ApplicationRole> roleManager,
             IJwtServices jwtServices,
             IEmailSender emailSender
        )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _jwtServices = jwtServices;
            _emailSender = emailSender;
        }

        [Route("[action]")]
        [HttpPost]
        [Authorize("NoAuthenticated")]
        public async Task<IActionResult> Signup(SignupDto signupDto)
        {
            ApplicationUser user = new()
            {
                UserName = signupDto.Username,
                Email = signupDto.Email,
                PhoneNumber = signupDto.Phone
            };

            IdentityResult result = await _userManager.CreateAsync(user, signupDto.Password!);

            if (result.Succeeded)
            {
                if (signupDto.AppRole == AppRoles.User)
                {
                    if (await _roleManager.FindByNameAsync(AppRoles.User.ToString()) != null)
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.User.ToString());
                    }
                    else
                    {
                        ApplicationRole userRole = new() { Name = AppRoles.User.ToString() };
                        await _roleManager.CreateAsync(userRole);
                        await _userManager.AddToRoleAsync(user, AppRoles.User.ToString());
                    }
                }
                else
                {
                    if (await _roleManager.FindByNameAsync(AppRoles.Admin.ToString()) != null)
                    {
                        await _userManager.AddToRoleAsync(user, AppRoles.Admin.ToString());
                    }
                    else
                    {
                        ApplicationRole adminRole = new() { Name = AppRoles.Admin.ToString() };
                        await _roleManager.CreateAsync(adminRole);
                        await _userManager.AddToRoleAsync(user, AppRoles.Admin.ToString());
                    }
                }

                // TODO: Create a cart
                // TODO: Create a favourites list

                return Ok(await _jwtServices.GetJwtToken(user));
            }
            else
            {
                string errors = string.Join(" ,\n", result.Errors.Select(e => e.Description));
                return Problem(errors, statusCode: 400);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize("NoAuthenticated")]
        public async Task<IActionResult> Signin(SigninDto signinDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signinDto.Username!, signinDto.Password!, false, false);

            if (result.Succeeded)
            {
                ApplicationUser? user = await _userManager.FindByNameAsync(signinDto.Username!);

                if (user == null)
                {
                    return Problem("No user found with these credentials.", statusCode: 400);
                }

                return Ok(await _jwtServices.GetJwtToken(user));
            }
            else
            {
                return Problem("Login failed, try again with the correct credentials", statusCode: 400);
            }
        }

        [HttpPost]
        [Route("forgot-password")]
        [Authorize("NoAuthenticated")]
        public async Task<IActionResult> ForgotPassowrd(ForgotPasswordDto forgotPasswordDto)
        {
            try
            {
                ApplicationUser? user = await _userManager.FindByEmailAsync(forgotPasswordDto.Email!);

                if (user == null) return Problem("Email doesn't exist", statusCode: 400);

                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                string message = $"Your reset code : {resetToken}\n Go back to the app and enter this code and your new password";
                await _emailSender.SendEmailAsync(forgotPasswordDto.Email!, "Your beqaltk account password Reset", message);

                return Ok("An email was sent to your account to reset your password!");
            }
            catch
            {
                return Problem("Failed to send the email to your account please try again later!", statusCode: 500);
            }
        }

        [HttpPost]
        [Route("reset-password")]
        [Authorize("NoAuthenticated")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto resetPasswordDto)
        {
            ApplicationUser? user = await _userManager.FindByEmailAsync(resetPasswordDto.Email!);

            if (user == null) return Problem("This email doesn't exist.");

            IdentityResult result = await _userManager.ResetPasswordAsync(
                user,
                resetPasswordDto.ResetToken!,
                resetPasswordDto.NewPassword!
            );

            if (result.Succeeded)
            {
                return Ok(await _jwtServices.GetJwtToken(user));
            }
            else
            {
                string errors = string.Join(" ,\n", result.Errors.Select(e => e.Description));
                return Problem(errors, statusCode: 400);
            }
        }

        [HttpPost]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Signout()
        {
            string token = HttpContext.Request.Headers["Authorization"]!.ToString().Split(" ")[1];
            await _jwtServices.AddExpiredToken(token);

            return Ok("User signed out.");
        }

        [HttpGet]
        [Route("[action]")]
        [Authorize]
        public async Task<IActionResult> Me()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            if (user == null) return Unauthorized();
            return Ok(user);
        }
    }
}