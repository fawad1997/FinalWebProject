using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalWebProject.Models;
using Microsoft.AspNetCore.Authorization;
using FinalWebProject.Data;
using Microsoft.EntityFrameworkCore;

namespace FinalWebProject.Controllers
{
    public class HomeController : Controller
    {
        [TempData]
        public string StatusMessage { get; set; }

        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Articles.ToListAsync());
        }
        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";
            var model = new ContactUs { StatusMessage = StatusMessage };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Contact(ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                StatusMessage = "Message has been Sent";
                return RedirectToAction(nameof(Contact));
            }
            var model = new ContactUs { StatusMessage = StatusMessage };
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
