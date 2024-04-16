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
            return View(await _context.Users.ToListAsync());
        }

    }
}