using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShareForceOne.Models;

namespace ShareForceOne.Controllers
{
    public class UserController : Controller
    {
        public UserManager<ApplicationUser> UserMgr { get; }
        public SignInManager<ApplicationUser> SignInMgr { get; }

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            // Tar emot modellen som 'model' och kan då börja arbeta med den

            // Skapar en ny användare via ApplicationUser
            ApplicationUser user = new ApplicationUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.Email,
                Gender = model.Gender,
                PhoneNumber = model.PhoneNumber,
                City = model.City,
                Email = model.Email
            };

            // Skapar användaren. skickar in password här så den blir hashad i databasen. 
            IdentityResult result = await UserMgr.CreateAsync(user, model.Password);

            // Skickar användaren till User/Index
            return View(nameof(Index));



            //// Kod som kan användas för att skapa en etestanvändare. 
            //
            //// Letar upp om det finns en användare med namner Username
            //// Om inte FindByNameAsync hittar användaren Username så skapar den en testanvändare. 
            //
            //ApplicationUser user = await UserMgr.FindByNameAsync("Username");
            //
            //if(user == null)
            //{
            //    user = new ApplicationUser();
            //    user.FirstName = "FirstName";
            //    user.LastName = "LastName";
            //    user.UserName = "email@email.com";
            //    user.Gender = "SheMale";
            //    user.PhoneNumber = "0701234567";
            //    user.City = "Sundsvall";
            //    user.Email = "email@email.com";

            //    // Skapar en testanvändaren och sätter password till Qwerty1234!
            //    IdentityResult result = await UserMgr.CreateAsync(user, "Qwerty1234!");
            //}

        }
        
        public IActionResult SignUp()
        {
            return View(nameof(SignUp));
        }
        public IActionResult Index()
        {
            return View(nameof(Index));
        }


    }
}