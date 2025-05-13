using Microsoft.AspNetCore.Mvc;
using Mvc.Models.User;

namespace Mvc.Controllers;

public class UserController : Controller
{
    
    [HttpGet]
    public IActionResult UserProfile()
    {
        return View();
    }

    [HttpPost]
    public IActionResult UserProfile(string name, string email)
    {
        var user = new UserViewModel()
        {
            name = name,
            Email = email
        };
        return View(user);
    }
    
}