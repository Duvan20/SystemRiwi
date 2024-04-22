using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemRiwi.Data;
using SystemRiwi.Models;

namespace SystemRiwi.Controllers
{
    public class HistoryController : Controller
    {
        public readonly SystemRiwiContext _context;

        public HistoryController(SystemRiwiContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
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
            return View(await _context.History.ToListAsync());
        }

        [HttpPost]
        public IActionResult Create()
        {
            var Id = HttpContext.Request.Cookies["Id"];
            var NewHistory = new History{
                EntryTime = DateTime.Now,
                User_id = int.Parse(Id)
            };
            _context.History.Add(NewHistory);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        
        
    }
}