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
         ViewData["Login"] = "display:none";
        return View();

    }

   
    //login
    [HttpPost]
    public IActionResult Index(string _Document, string _password)
    {
        var User_Correct = _context.Users.FirstOrDefault(p => p.Document == _Document );

        var Password_correct = _context.Users.FirstOrDefault(p => p.Password == _password);

        if( User_Correct != null && Password_correct != null){
           

            Response.Cookies.Append("Id",User_Correct.Id.ToString());
            Response.Cookies.Append("Name",User_Correct.Name.ToString());
            Response.Cookies.Append("LastName",User_Correct.LastName.ToString());
            Response.Cookies.Append("Gender",User_Correct.Gender.ToString());
            Response.Cookies.Append("Occupation",User_Correct.Occupation.ToString());
            Response.Cookies.Append("img_user",User_Correct.Photo.ToString());
            ViewData["Occupation"]=User_Correct.Occupation;
            return RedirectToAction("Index","Users");

        }else{
             TempData ["ErrorLogin"] = "Document or Password incorrect";
            return View();
        }
    }

    public IActionResult Create()
    {
         ViewData["Login"] = "display:none";
        return View();
    }


    [HttpPost]
    public IActionResult Register(User u)
    {
        _context.Users.Add(u);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
