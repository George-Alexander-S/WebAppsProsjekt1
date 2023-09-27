using Microsoft.AspNetCore.Mvc;

namespace WebAppsProsjekt1.Controllers;

public class FlashCardController : Controller
{
    public IActionResult CreateCard()
    {
        return View();
    }
}