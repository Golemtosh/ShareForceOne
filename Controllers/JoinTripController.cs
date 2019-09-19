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

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult JoinTrip(int id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewBag.aTripId = id;  
            ViewBag.loggedInUser = userId;
            return View();
        }
    }
}