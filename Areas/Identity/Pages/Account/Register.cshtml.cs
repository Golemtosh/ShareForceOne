﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ShareForceOne.Models;

namespace ShareForceOne.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "Must provide first name.")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 characters.")]
            [DisplayName("First name")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Must provide a last name.")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "Must be between 2 and 50 characters.")]
            [DisplayName("Last name")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Must provide a gender.")]
            [DisplayName("Gender")]
            public string Gender { get; set; }

            [Required(ErrorMessage = "Must provide a valid phone number.")]
            [DisplayName("Phone number")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Must provide a city.")]
            [DisplayName("City")]
            public string City { get; set; }

            [Required(ErrorMessage = "Must provide a valid Email.")]
            [DisplayName("Email")]
            [DataType(DataType.EmailAddress)]
            public string Email { get; set; }

            [Compare(nameof(Email), ErrorMessage = "Emails do NOT match")]
            [DisplayName("Confirm email")]
            public string ConfirmEmail { get; set; }

            [Required(ErrorMessage = "Must provide a valid password.")]
            [DisplayName("Password")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Compare(nameof(Password), ErrorMessage = "Passwords do NOT match")]
            [DisplayName("Confirm password")]
            public string ConfirmPassword { get; set; }
        }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = Input.Email, Email = Input.Email };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { userId = user.Id, code = code },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
