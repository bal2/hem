using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HADU.hem.Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace HADU.hem.HemWeb.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "{0} må fylles ut")]
            [EmailAddress]
            [Display(Name = "E-post")]
            public string Email { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [StringLength(100, ErrorMessage = "{0} må være mellom {2} og {1} tegn langt.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Passord")]
            public string Password { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Password)]
            [Display(Name = "Gjenta passord")]
            [Compare("Password", ErrorMessage = "Passordene er ikke like")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [StringLength(50, ErrorMessage = "{0} må være mellom {2} og {1} tegn langt.", MinimumLength = 2)]
            [DataType(DataType.Text)]
            [RegularExpression("[a-zA-ZæøåÆØÅ0-9]+", ErrorMessage = "{0} kan bare inneholde bokstaver og tall")]
            [Display(Name = "Kallenavn")]
            public string Nickname { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Text)]
            [Display(Name = "Fornavn")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Text)]
            [Display(Name = "Etternavn")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Date)]
            [Display(Name = "Fødselsdato")]
            public DateTime BirthDate { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Telefonnummer")]
            public string Phone { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Text)]
            [Display(Name = "Addresse")]
            public string Address { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Addresselinje 2")]
            public string Address2 { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Text)]
            [RegularExpression("([0-9]*)", ErrorMessage = "{0} kan bare inneholde tall")]
            [Display(Name = "Postnummer")]
            public string Zip { get; set; }

            [Required(ErrorMessage = "{0} må fylles ut")]
            [DataType(DataType.Text)]
            [Display(Name = "Poststed")]
            public string City { get; set; }

            [DataType(DataType.Text)]
            [Display(Name = "Foresattes navn")]
            public string GuardianName { get; set; }

            [DataType(DataType.PhoneNumber)]
            [Display(Name = "Foresattes telefonnummer")]
            public string GuardianPhone { get; set; }
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
                var user = new ApplicationUser
                {
                    Email = Input.Email,
                    Nickname = Input.Nickname,
                    FirstName = Input.FirstName,
                    LastName = Input.LastName,
                    BirthDate = Input.BirthDate,
                    Phone = Input.Phone,
                    Address = Input.Address,
                    Address2 = Input.Address2,
                    Zip = Input.Zip,
                    City = Input.City,
                    GuardianName = Input.GuardianName,
                    GuardianPhone = Input.GuardianPhone
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

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
