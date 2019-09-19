using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ShareForceOne.Data;
using ShareForceOne.Models;
using ShareForceOne.Controllers;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace ShareForceOne.Controllers
{
    public class UserController : Controller
    {
        

        private readonly ApplicationDbContext _context;

        public UserManager<ApplicationUser> UserMgr { get; }
        public SignInManager<ApplicationUser> SignInMgr { get; }

        public UserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, ApplicationDbContext context)
        {
            UserMgr = userManager;
            SignInMgr = signInManager;
            _context = context;
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

            //// Kod som kan användas för att skapa en testanvändare. 
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

        public IActionResult AdminListUsers()
        {

            var users = from c in _context.Users select c;
            var userList = new List<UserViewModel>();
            foreach (var item in users)
            {
                var userModel = new UserViewModel();

                
                userModel.FirstName = item.FirstName;
                userModel.LastName = item.LastName;
                userModel.Gender = item.Gender;
                userModel.PhoneNumber = item.PhoneNumber;
                userModel.City = item.City;
                userModel.Email = item.Email;
                userModel.ConfirmEmail = item.Email;
                userModel.Password = "Not Avaiable";
                userModel.ConfirmPassword = "Not Avaiable";

                userList.Add(userModel);
            }

            return View(userList);
        }

        // DELETE      
        public async Task<IActionResult> AdminDeleteUser(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = from c in _context.Users select c;
            foreach (var item in users)
            {
                if(item.Email == id)
                {
                    var userModel = new UserViewModel();

                    userModel.FirstName = item.FirstName;
                    userModel.LastName = item.LastName;
                    userModel.Gender = item.Gender;
                    userModel.PhoneNumber = item.PhoneNumber;
                    userModel.City = item.City;
                    userModel.Email = item.Email;
                    userModel.ConfirmEmail = item.Email;
                    userModel.Password = "Not Avaiable";
                    userModel.ConfirmPassword = "Not Avaiable";

                    return View(userModel);
                }                
            }

            return NotFound();
        }

        // Delete
        [HttpPost, ActionName("AdminDeleteUser")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            string identityId = null;

            var users = from c in _context.Users select c;
            
            foreach (var item in users)
            {
                if (item.Email == id)
                {
                    identityId = item.Id;                   
                }
            }

            if(identityId != null)
            {
                var user = await _context.Users.FindAsync(identityId);
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(AdminListUsers));
            }

            return NotFound();

        }

        

        
    }

    
}