using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using NykantIS.Models;
using NykantIS.Models.Email;
using NykantIS.Services;

namespace NykantIS.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class ForgotPasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IMailService _mailService;

        public ForgotPasswordModel(UserManager<ApplicationUser> userManager, IRazorViewToStringRenderer razorViewToStringRenderer, IMailService mailService)
        {
            _userManager = userManager;
            _razorViewToStringRenderer = razorViewToStringRenderer;
            _mailService = mailService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required]
            [EmailAddress]
            public string Email { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(Input.Email);
                if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return RedirectToPage("./ForgotPasswordConfirmation");
                }

                // For more information on how to enable account confirmation and password reset please 
                // visit https://go.microsoft.com/fwlink/?LinkID=532713
                var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ResetPassword",
                    pageHandler: null,
                    values: new { area = "Identity", code },
                    protocol: Request.Scheme);

                var resetPasswordModel = new ResetPasswordEmailModel(HtmlEncoder.Default.Encode(callbackUrl));
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ResetPasswordEmail.cshtml", resetPasswordModel);

                var request = new EmailRequest
                {
                    ToEmail = Input.Email,
                    Body = body,
                    Subject = "Password nulstillelse"
                };

                await _mailService.SendEmailAsync(request);

                return RedirectToPage("./ForgotPasswordConfirmation");
            }

            return Page();
        }
    }
}
