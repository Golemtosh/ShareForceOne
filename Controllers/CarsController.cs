using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShareForceOne.Data;
using ShareForceOne.Models;

namespace ShareForceOne.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var cars = from c in _context.Cars
                       where c.CarCreator == User.FindFirstValue(ClaimTypes.NameIdentifier)
                       select c;

            return View(cars);
        }

        public IActionResult AddCar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddCar([Bind("CarRegNumber,CarBrand,CarBrandModel,CarFuelConsumption")] CarModel carModel)
        {
            string decimalFix = carModel.CarFuelConsumption.ToString();
            if (decimalFix.Contains(","))
            {
                decimalFix.Replace(",", ".");
                carModel.CarFuelConsumption = Convert.ToDecimal(decimalFix);
            }

            if (ModelState.IsValid)
            {

              
                carModel.CarCreator = User.FindFirstValue(ClaimTypes.NameIdentifier);
                _context.Add(carModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(nameof(Index));
        }
    }
}