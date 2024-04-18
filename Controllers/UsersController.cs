using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SystemRiwi.Data;

namespace SystemRiwi.Controllers
{
    public class UsersController : Controller
    {
        public readonly SystemRiwiContext _context;
        public UsersController(SystemRiwiContext context)
        {
            _context = context;
        }


        //Listado de todos los usuarios
        public async Task <IActionResult>Index()
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

            return View(await _context.Users.ToListAsync());
        }

    }
}