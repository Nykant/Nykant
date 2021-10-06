using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using NykantIS.Models;
using NykantIS.Services;
using NykantIS.Models.ViewModels;

namespace NykantIS.Areas.Identity.Pages.Account.Manage
{
    [AutoValidateAntiforgeryToken]
    public partial class EmailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailService _mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;

        public EmailModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IMailService _mailService,
            IRazorViewToStringRenderer _razorViewToStringRenderer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this._mailService = _mailService;
            this._razorViewToStringRenderer = _razorViewToStringRenderer;
        }

        public string Username { get; set; }

        [Display(Name = "Nuværende email")]
        public string Email { get; set; }

        public bool IsEmailConfirmed { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Ny email feltet skal udfyldes.")]
            [EmailAddress(ErrorMessage = "Dette er ikke en gyldig email.")]
            [Display(Name = "Ny email")]
            public string NewEmail { get; set; }
        }

        private async Task LoadAsync(ApplicationUser user)
        {
            var email = await _userManager.GetEmailAsync(user);
            Email = email;

            IsEmailConfirmed = await _userManager.IsEmailConfirmedAsync(user);
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostChangeEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var email = await _userManager.GetEmailAsync(user);
            if (Input.NewEmail != email)
            {
                var userId = await _userManager.GetUserIdAsync(user);
                var code = await _userManager.GenerateChangeEmailTokenAsync(user, Input.NewEmail);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Page(
                    "/Account/ConfirmEmailChange",
                    pageHandler: null,
                    values: new { area = "Identity", userId = userId, email = Input.NewEmail, code = code },
                    protocol: Request.Scheme);

                var confirmEmailChangeModel = new UrlEmailModel(callbackUrl);
                string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmailChangeEmail.cshtml", confirmEmailChangeModel);

                var request = new EmailRequest
                {
                    ToEmail = email,
                    Body = body,
                    Subject = "Bekræftelse for email ændring"
                };

                await _mailService.SendEmailAsync(request);

                StatusMessage = "Bekræftelse for at ændre email er sendt. Tjek din email.";
                return RedirectToPage();
            }

            StatusMessage = "Din email er uændret.";
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostSendVerificationEmailAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }

            var userId = await _userManager.GetUserIdAsync(user);
            var email = await _userManager.GetEmailAsync(user);
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var callbackUrl = Url.Page(
                "/Account/ConfirmEmail",
                pageHandler: null,
                values: new { area = "Identity", userId = userId, code = code },
                protocol: Request.Scheme);

            var confirmAccountModel = new UrlEmailModel(HtmlEncoder.Default.Encode(callbackUrl));
            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);

            var request = new EmailRequest
            {
                ToEmail = email,
                Body = body,
                Subject = "Konto bekræftelses email"
            };

            await _mailService.SendEmailAsync(request);

            StatusMessage = "Konto bekræftelse sendt. Tjek din email.";
            return RedirectToPage();
        }
    }
}
