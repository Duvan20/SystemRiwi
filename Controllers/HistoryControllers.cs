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
            return View(await _context.History.ToListAsync());
        }
    }
}