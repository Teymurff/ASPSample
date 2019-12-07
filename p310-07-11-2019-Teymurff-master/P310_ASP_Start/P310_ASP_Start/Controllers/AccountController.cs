using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using P310_ASP_Start.DAL;
using P310_ASP_Start.Models;
using Microsoft.AspNetCore.Identity.UI.Pages.Account.Internal;
using P310_ASP_Start.ViewModels;
using Microsoft.AspNetCore.Identity.UI.Services;
using P310_ASP_Start.Services;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.AspNetCore.WebUtilities;

namespace P310_ASP_Start.Controllers
{
    public class AccountController : Controller
    {
        private readonly EliteContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailSender _emailSender;

        public AccountController(EliteContext context,
                                 UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 RoleManager<IdentityRole> roleManager,
                                 IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterModel registerModel)
        {
            if(!ModelState.IsValid)
            {
                return View(registerModel);
            }

            ApplicationUser user = registerModel;

            IdentityResult result = await _userManager.CreateAsync(user, registerModel.Password);//implicit    

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(registerModel);
            }

            //email confirmation
            //SMTP - Simple Mail Transfer Protocol

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

            await _emailSender.SendEmailAsync(registerModel.Email, "Confirm your mail",
            $"Confirm your account by following to " +
                $"<a href='{HtmlEncoder.Default.Encode($"http://localhost:55750/Account/ConfirmEmail?token={codeEncoded}&userId={user.Id}")}'>" +
                "this link" +
                $"</a>"
            );

            return View("VerifyEmail");
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if(user != null)
            {
                var codeDecodedBytes = WebEncoders.Base64UrlDecode(token);
                var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

                IdentityResult result = await _userManager.ConfirmEmailAsync(user, codeDecoded);

                if(result.Succeeded)
                {
                    return View();
                }
            }

            return View("FailedConfirmation");
        }

        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signin(UserLoginModel userLoginModel)
        {
            if(!ModelState.IsValid)
            {
                return View(userLoginModel);
            }

            ApplicationUser user = await _userManager.FindByEmailAsync(userLoginModel.EmailOrUsername);

            if(user == null)
            {
                user = await _userManager.FindByNameAsync(userLoginModel.EmailOrUsername);
            }

            if(user == null)
            {
                ModelState.AddModelError("", "Email or password is invalid");
                return View(userLoginModel);
            }

            if(!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Your email is not confirmed yet. Please, check your email.");
                return View(userLoginModel);
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginModel.Password, userLoginModel.RememberMe, false);

            if(result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Email or password is invalid");
            return View(userLoginModel);
        }

        public IActionResult Signout()
        {
            _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if(user == null)
            {
                ViewBag.EmailError = "Email doesn't exist in our database";
                return View();
            }

            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            byte[] tokenGeneratedBytes = Encoding.UTF8.GetBytes(token);
            var codeEncoded = WebEncoders.Base64UrlEncode(tokenGeneratedBytes);

            await _emailSender.SendEmailAsync(email, "Reset password",
            $"Follow the link to reset your password " +
                $"<a href='{HtmlEncoder.Default.Encode($"http://localhost:55750/Account/ResetPassword?token={codeEncoded}&userId={user.Id}")}'>" +
                "this link" +
                $"</a>"
            );

            return View("VerifyEmail");
        }

        public IActionResult ResetPassword(string token, string userId)
        {
            var model = new UserResetPasswordModel
            {
                Token = token,
                UserId = userId
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(UserResetPasswordModel userResetPasswordModel)
        {
            if(!ModelState.IsValid)
            {
                ModelState.AddModelError("", "New password is not valid");
                return View();
            }

            var user = await _userManager.FindByIdAsync(userResetPasswordModel.UserId);

            if(user == null)
            {
                ModelState.AddModelError("", "User not found");
                return View();
            }

            var codeDecodedBytes = WebEncoders.Base64UrlDecode(userResetPasswordModel.Token);
            var codeDecoded = Encoding.UTF8.GetString(codeDecodedBytes);

            var result = await _userManager.ResetPasswordAsync(user, codeDecoded, userResetPasswordModel.Password);

            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(userResetPasswordModel);
            }

            return RedirectToAction("Index", "Home");
        }


    }
}