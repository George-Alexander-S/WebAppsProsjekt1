using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace WebAppsProsjekt1.Controllers;

public class FlashCardController : Controller
{
    private readonly CardDbContext _cardDbContext;

    public FlashCardController(CardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }
    /*public IActionResult FlashCardTable()
    {
        var flashcards = new List<FlashCard>();
        var flashcard1 = new FlashCard();
        var flashcard2 = new FlashCard();
        var flashcard3 = new FlashCard();
        flashcard1.FlashcardId = 1;
        flashcard1.FrontText = "Forside 1";
        flashcard1.BackText = "Bakside 1";
        flashcard2.FlashcardId = 2;
        flashcard2.FrontText = "Forside 2";
        flashcard2.BackText = "Bakside 2";
        flashcard3.FlashcardId = 3;
        flashcard3.FrontText = "Forside 3";
        flashcard3.BackText = "Bakside 3";
        flashcards.Add(flashcard1);
        flashcards.Add(flashcard2);
        flashcards.Add(flashcard3);

        ViewBag.CurrentViewName = "Flashcards";
        return View(flashcards);
    } */

    public async Task<ActionResult> FlashCardTable()
    {
        List<FlashCard> cards = await _cardDbContext.FlashCards.ToListAsync();
        return View(cards);

    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CreateCard()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> CreateCard(FlashCard flashcard)
    {
        if (ModelState.IsValid)
        {
            _cardDbContext.FlashCards.Add(flashcard); //referst do database 
            await _cardDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(FlashCardTable));
        }
        return View(flashcard);
    }
    
    
}