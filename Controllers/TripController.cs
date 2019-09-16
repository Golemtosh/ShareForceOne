using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareForceOne.Data;
using ShareForceOne.Models;

namespace ShareForceOne.Controllers
{
    public class TripController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TripCreate()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TripDBCreate(TripModel tripModel)
        {
            if (ModelState.IsValid)
            {
                tripModel.TripCreator = User.FindFirstValue(ClaimTypes.NameIdentifier);                
                _context.Add(tripModel);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index", "User");
            }

            return View(nameof(Index));
        }

        public IActionResult AdminListTrips()
        {
            var trips = from c in _context.TripModel
                       
                       select c;

            return View(trips);
        }

    }
}