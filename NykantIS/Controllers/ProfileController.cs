using IdentityServer4;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using NykantIS.Models;
using NykantIS.Models.ViewModels;
using NykantIS.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace NykantIS.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public ProfileController(UserManager<ApplicationUser> userManager, IRazorViewToStringRenderer razorViewToStringRenderer,
            IMailService mailService, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [HttpGet]
        public async Task<IActionResult> PersonalInfo()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user != null)
            {
                ProfileVM profileVM = new ProfileVM
                {
                    Email = user.Email,
                    Username = user.UserName
                };

                return View(profileVM);
            }
            return RedirectToAction("Account", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> PostPersonalInfo(ProfileVM profileVM)
        {
            var user = await _userManager.GetUserAsync(User);
            bool updated_username = false;
            if (user.UserName != profileVM.Username)
            {
                user.UserName = profileVM.Username;
                updated_username = true;
            }
            if (user.Email != profileVM.Email) 
            {
                var result = await _userManager.SetEmailAsync(user, profileVM.Email);
                if (!result.Succeeded)
                {
                    return BadRequest();
                }
                else
                {
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    try
                    {
                        var confirmAccountModel = new ConfirmAccountEmailViewModel(HtmlEncoder.Default.Encode(callbackUrl));
                        string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);

                        var request = new EmailRequest
                        {
                            ToEmail = profileVM.Email,
                            Body = body,
                            Subject = "account confirmation email"
                        };

                        await _mailService.SendEmailAsync(request);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.Message);
                    }
                    await _userManager.UpdateAsync(user);
                    await _signInManager.SignOutAsync();
                    await HttpContext.SignOutAsync();

                    return NoContent();
                }
            }
            if (updated_username)
            {
                await _userManager.UpdateAsync(user);
                return NoContent();
            }
            
            return BadRequest();
        }
    }
}
