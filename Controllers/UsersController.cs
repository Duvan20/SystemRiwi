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

        public  async Task<IActionResult> Users()
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


        public IActionResult Search(string SearchString)
        {
            var Search = _context.Users.AsQueryable();

            if(!string.IsNullOrEmpty(SearchString)){
                Search =  Search.Where(x => x.Name.Contains(SearchString) || x.LastName.Contains(SearchString) || x.Gender.Contains(SearchString) || x.Occupation.Contains(SearchString) || x.Document.Contains(SearchString) || x.document_type.Contains(SearchString));

            }
            return View("Users",Search.ToList());
            

            

        }

    }
}