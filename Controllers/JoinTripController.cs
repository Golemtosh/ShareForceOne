using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShareForceOne.Data;
using Microsoft.AspNetCore.Identity;
using ShareForceOne.Models;
using System.Net;
using Microsoft.EntityFrameworkCore;

namespace ShareForceOne.Controllers
{
    public class JoinTripController : Controller
    {
        private readonly ApplicationDbContext _context;

        public JoinTripController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult AdminJoinTripList()
        {
            var joinTrip = from c in _context.JoinTripModel select c;
            return View(joinTrip);
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

                string sendsmstext = "Namn har joinat din resa med meddelande: " + joinTrip.JoinTripNotes;
                // Test
                try
                {
                    SendSMS(sendsmstext);

                }
                catch (Exception e)
                {
                    
                }
                // Test

                return RedirectToAction("Index", "User");
            }

            return RedirectToAction("Index", "User");
        }
        public async void SendSMS(string message)
        {

            string url = "https://se-1.cellsynt.net/sms.php?username=tomasslattman&password=X1TwBSG1&destination=0046701750045&originatortype=numeric&originator=46700456456&charset=UTF-8&text=" + message;
            
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "application/json";
                request.ContentLength = url.Length;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
           
        }



        // DELETE       
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.JoinTripModel.FirstOrDefaultAsync(m => m.joinTripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var trip = await _context.JoinTripModel.FindAsync(id);
            _context.JoinTripModel.Remove(trip);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }



    }
}