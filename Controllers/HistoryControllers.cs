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
        public IActionResult Create()
        {
            var id_user = HttpContext.Request.Cookies["id"];

            var HistoryNew = new History{
            EntryTime = DateTime.Now,
            User_id = int.Parse(id_user)
            };
            _context.History.Add(HistoryNew);
            _context.SaveChanges();                
            return RedirectToAction("Index");
        }
        
        public IActionResult CheckOut(int id)
        {
            var test = _context.History.FirstOrDefault(x =>x.Id ==id);
       
            test.ExitTime = DateTime.Now;

            
            _context.History.Update(test);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}