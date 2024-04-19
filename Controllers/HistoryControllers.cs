using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemRiwi.Data;
using SystemRiwi.Models;

namespace SystemRiwi.Controllers
{
    [Authorize]
    public class HistoryController : Controller
    {
        public readonly SystemRiwiContext _context;

        public HistoryController(SystemRiwiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var id_user = HttpContext.Request.Cookies["id"];
            ViewBag.Id = id_user;

            var userName = HttpContext.Request.Cookies["Name"];
            ViewBag.Name = userName;

            var userLastname = HttpContext.Request.Cookies["LastName"];
            ViewBag.LastName = userLastname;

            var userGender = HttpContext.Request.Cookies["Gender"];
            ViewBag.Gender = userGender;

            var Photo = HttpContext.Request.Cookies["img_user"];
            ViewBag.Photo = Photo;

            var userOccupation = HttpContext.Request.Cookies["Occupation"];
            ViewBag.Occupation = userOccupation;
            ViewBag.History = await _context.History.ToListAsync(); 
            return View();
        }
        [HttpPost]
        public IActionResult CreateHistory(History H)
        {
            return RedirectToAction("Index");
        }


    }
}