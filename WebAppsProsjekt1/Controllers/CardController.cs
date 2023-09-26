using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.Controllers;

public class CardController : Controller
{
    public IActionResult Play()
    {
        var cardlist = new List<FlashCard>();
        var card1 = new FlashCard(1, "Hva er meningen med livet?", "42");
        var card2 = new FlashCard(2, "Hva er klokka?", "Noe som viser tiden");
        cardlist.Add(card1);
        cardlist.Add(card2);
        var cardset = new Cardset("Test", "007", cardlist);
        ViewBag.CurrentViewName = "Test flashcard";
        return View(cardset);
    }
}
