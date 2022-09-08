using Microsoft.AspNetCore.Mvc;

namespace meet_room.Controllers;

public class HomeController: Controller
{
    public async Task<IActionResult> Index()
    {
        return View();
    }
}