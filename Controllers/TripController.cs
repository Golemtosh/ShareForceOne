﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareForceOne.Data;
using ShareForceOne.Models;
using ShareForceOne.Controllers;

namespace ShareForceOne.Controllers
{
    public class TripController : Controller
    {
        string carList;
        private readonly ApplicationDbContext _context;

        public TripController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TripDetails(int id)
        {
            var trip = _context.TripModel.Find(id);
            return View(trip);           
        }

        public IActionResult ListTrips()
        {
            var trips = from c in _context.TripModel select c;
            return View(trips);
        }

        public IActionResult TripCreate()
        {
            var cars = from c in _context.Cars
                       where c.CarCreator == User.FindFirstValue(ClaimTypes.NameIdentifier)
                       select c;

            foreach (var item in cars)
            {
                carList += "<option value="+item.CarId+">" + item.CarBrand + " " + item.CarBrandModel + " " + item.CarRegNumber + "</option>";
            }
            ViewBag.carList = carList;
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

        // DELETE       
        public async Task<IActionResult> AdminDeleteTrip(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.TripModel.FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // Delete
        [HttpPost, ActionName("AdminDeleteTrip")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trip = await _context.TripModel.FindAsync(id);
            _context.TripModel.Remove(trip);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(AdminListTrips));
        }

        // FUNCTIONS
        public static string GetLatFromId(string lat)
        {
            string latiuder = lat.Substring(1, 7);
            return latiuder;
        }
        public static string GetLonFromId(string lon)
        {
            var longsplit = lon.Trim().Split(",");
            string longitude = longsplit[1].ToString().Substring(0, 6);
            return longitude;
        }

        
    }
}