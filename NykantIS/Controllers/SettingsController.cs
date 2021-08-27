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
    public class SettingsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMailService _mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public SettingsController(UserManager<ApplicationUser> userManager, IRazorViewToStringRenderer razorViewToStringRenderer,
            IMailService mailService, SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
        }

        [HttpGet]
        public async Task<IActionResult> ChangeEmail()
        {
            var user = await _userManager.GetUserAsync(User);
            if(user != null)
            {
                ChangeEmailVM changeEmailVM = new ChangeEmailVM
                {
                    Email = user.Email,
                    Username = user.UserName
                };

                return View(changeEmailVM);
            }
            return RedirectToAction("Account", "Login");
        }

        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailVM changeEmailVM)
        {
            try
            {
                var user = await _userManager.GetUserAsync(User);
                if (user.Email != changeEmailVM.Email)
                {
                    var prevUser = await _userManager.FindByEmailAsync(changeEmailVM.Email);
                    if (prevUser == null)
                    {
                        var result = await _userManager.SetEmailAsync(user, changeEmailVM.Email);
                        user.UserName = changeEmailVM.Email;

                        if (!result.Succeeded)
                        {
                            return Json("fail");
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


                            var confirmAccountModel = new ConfirmAccountEmailViewModel(HtmlEncoder.Default.Encode(callbackUrl));
                            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);

                            var request = new EmailRequest
                            {
                                ToEmail = changeEmailVM.Email,
                                Body = body,
                                Subject = "account confirmation email"
                            };

                            await _mailService.SendEmailAsync(request);
                        }

                        await _userManager.UpdateAsync(user);
                        await _signInManager.RefreshSignInAsync(user);
                        //await _signInManager.SignOutAsync();
                        //await HttpContext.SignOutAsync();

                        return Json("emailUpdated");
                    }
                    else
                    {
                        return Json("inUse");
                    }
                }
                else
                {
                    return Json("sameEmail");
                }
            }
            catch
            {
                return Json("fail");
            }
        }
    }
}
