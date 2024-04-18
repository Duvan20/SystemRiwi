using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SystemRiwi.Data;
using SystemRiwi.Models;

namespace SystemRiwi.Controllers;

public class HomeController : Controller
{
    public readonly SystemRiwiContext _context;

    public HomeController(SystemRiwiContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View();
    }

   
    //login
    [HttpPost]
    public IActionResult Index(string _Document, string _password)
    {
        var User_Correct = _context.Users.FirstOrDefault(p => p.Document == _Document );

        var Password_correct = _context.Users.FirstOrDefault(p => p.Password == _password);

        if( User_Correct != null && Password_correct != null){
            return RedirectToAction("Index","Users");
        }else{
             TempData ["ErrorLogin"] = "Document or Password incorrect";
            return View();
        }
    }

    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public IActionResult Register(User u)
    {
        _context.Users.Add(u);
        _context.SaveChanges();
        return View("Create");
    }
}
