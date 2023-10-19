using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;

namespace WebAppsProsjekt1.Controllers;

public class FlashCardController : Controller
{
    private readonly CardDbContext _cardDbContext;

    public FlashCardController(CardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }
    

    public async Task<ActionResult> FlashCardTable()
    {
        List<FlashCard> cards = await _cardDbContext.FlashCards.ToListAsync();
        return View(cards);

    }
    
    [HttpGet]
    public IActionResult CreateCard()
    {
        return View();
    }

    [HttpPost]
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

    [HttpGet("/GetCards")]
    public async Task<IActionResult> GetCards()
    {
        List<FlashCard> cards = await _cardDbContext.FlashCards.ToListAsync();
        return Json(cards);
    }
    
    
}