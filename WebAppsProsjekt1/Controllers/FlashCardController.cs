using Microsoft.AspNetCore.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers;

public class FlashCardController : Controller
{

    public IActionResult FlashCardTable()
    {
        var flashcards = new List<FlashCard>();
        var flashcard1 = new FlashCard(1, "Denne teksten er foran", "Denne teksten er bak");
        
        flashcards.Add(flashcard1);

        ViewBag.CurrentViewName = "Flashcards";
        return View(flashcards);
    }
    
    public IActionResult CreateCard()
    {
        return View();
    }
}