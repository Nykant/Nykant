using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NykantIS.Models;
using NykantIS.Models.ViewModels;
using NykantIS.Services;

namespace NykantIS.Areas.Identity.Pages.Account
{
    [AutoValidateAntiforgeryToken]
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IMailService _mailService;
        private readonly IRazorViewToStringRenderer _razorViewToStringRenderer;
        private readonly IConfiguration configuration;

        public RegisterModel(
            IRazorViewToStringRenderer razorViewToStringRenderer,
            IMailService mailService,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _mailService = mailService;
            _razorViewToStringRenderer = razorViewToStringRenderer;
            this.configuration = configuration;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }
        public string RedirectAction { get; set; }
        public string RedirectController { get; set; }
        public string BasePath { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Du mangler at udfylde din email")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }

            [Required]
            public string AcceptPrivacyPolicy { get; set; }
        }

        public async Task OnGetAsync(string redirectaction, string redirectcontroller, string returnUrl = null)
        {
            if (redirectaction == "Details")
            {
                redirectaction = "Index";
            }
            BasePath = configuration.GetSection("Urls")["mvc"];
            ReturnUrl = returnUrl;
            RedirectAction = redirectaction;
            RedirectController = redirectcontroller;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(Input.Email).Result;
                if(user == null)
                {
                    user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                    var result = await _userManager.CreateAsync(user, Input.Password);

                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        var claimsResult = _userManager.AddClaimsAsync(user, new Claim[]{
                            new Claim(JwtClaimTypes.Email, Input.Email)
                        }).Result;
                        if (!claimsResult.Succeeded)
                        {
                            throw new Exception(claimsResult.Errors.First().Description);
                        }

                        var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                        var callbackUrl = Url.Page(
                            "/Account/ConfirmEmail",
                            pageHandler: null,
                            values: new { area = "Identity", userId = user.Id, code = code},
                            protocol: Request.Scheme);

                        try
                        {
                            _logger.LogInformation("trying to render email -------------------");

                            var confirmAccountModel = new UrlEmailModel(HtmlEncoder.Default.Encode(callbackUrl));
                            string body = await _razorViewToStringRenderer.RenderViewToStringAsync("/Views/Shared/ConfirmEmail.cshtml", confirmAccountModel);

                            _logger.LogInformation("email rendered -------------------");

                            var request = new EmailRequest
                            {
                                ToEmail = Input.Email,
                                Body = body,
                                Subject = "Konto bekræftelse"
                            };

                            _logger.LogInformation("trying to send email -------------------");

                            await _mailService.SendEmailAsync(request);

                        }
                        catch (Exception e)
                        {
                            _logger.LogInformation($"{e.Message} -------------------");
                            return new JsonResult("emailError");
                        }

                        _logger.LogInformation("email sent -------------------");

                        return new JsonResult("success");
                    }
                    else
                    {
                        return new JsonResult(result);
                    }
                }
                else
                {
                    return new JsonResult("userExist");
                }
            }

            // If we got this far, something failed, redisplay form
            return new JsonResult("unknownError");
        }
    }
}
