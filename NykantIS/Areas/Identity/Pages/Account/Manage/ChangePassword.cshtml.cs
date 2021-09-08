﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NykantIS.Models;
namespace NykantIS.Areas.Identity.Pages.Account.Manage
{
    public class ChangePasswordModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<ChangePasswordModel> _logger;

        public ChangePasswordModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ChangePasswordModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        [TempData]
        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "The Email field is required.")]
            [DataType(DataType.Password)]
            [Display(Name = "Nuværende password")]
            public string OldPassword { get; set; }

            [Required(ErrorMessage = "Nyt password feltet skal udfyldes.")]
            [StringLength(100, ErrorMessage = "{0} skal mindst være {2} og maks {1} tegn langt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Nyt password")]
            public string NewPassword { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Bekræft nyt password")]
            [Compare("NewPassword", ErrorMessage = "det nye password og det bekræftende nye password, passer ikke.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            //var hasPassword = await _userManager.HasPasswordAsync(user);
            //if (!hasPassword)
            //{
            //    return RedirectToPage("./SetPassword");
            //}

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new { text = "invalid" });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return new JsonResult(new { userid = _userManager.GetUserId(User), text = "notExist" });
            }

            var changePasswordResult = await _userManager.ChangePasswordAsync(user, Input.OldPassword, Input.NewPassword);
            if (!changePasswordResult.Succeeded)
            {
                return new JsonResult(new { text = "failed", errormessage = changePasswordResult.Errors.First().Description });
            }

            await _signInManager.RefreshSignInAsync(user);
            //await _signInManager.SignOutAsync();
            //await HttpContext.SignOutAsync();

            _logger.LogInformation("User changed their password successfully.");

            return new JsonResult(new { text = "success" });
        }
    }
}
