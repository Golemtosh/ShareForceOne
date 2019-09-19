using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareForceOne.Data;
using Microsoft.AspNetCore.Identity;
using ShareForceOne.Models;

namespace ShareForceOne.Controllers
{
    public class JoinTripController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JoinTripController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var trips = from c in _context.JoinTripModel
                       where c.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)
                       select c;

            return View(trips);
            
        }

        public IActionResult JoinTrip(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.aTripId = id;  
            ViewBag.loggedInUser = userId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> JoinTrip(JoinTripModel joinTrip)
        {

            if (ModelState.IsValid)
            {             
                _context.Add(joinTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "User");
        }

    }
}