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
  

    public async Task<ActionResult> FlashCardTable(int id)
    {
        var cards = await _cardDbContext.FlashCards.Where(c => c.CardsetId == id).ToListAsync();
        
        return View(cards);

    }
    
    [HttpGet]
    public IActionResult CreateCard(int id)
    {
        var createCardViewModel = new CreateCardViewModel();
        createCardViewModel.csid = id;
        return View(createCardViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCard(FlashCard flashCard)
    {
        try
        {
            var cardset = _cardDbContext.Cardsets.Find(flashCard.CardsetId);
            if (cardset == null)
            {
                return BadRequest();
            }

            var newCard = new FlashCard
            {
                CardsetId = flashCard.CardsetId,
                Cardset = cardset,
                FrontText = flashCard.FrontText,
                BackText = flashCard.BackText,
                ImageUrl = flashCard.ImageUrl
            };
            _cardDbContext.FlashCards.Add(newCard);
            await _cardDbContext.SaveChangesAsync();
            return RedirectToAction("CreateCard", "FlashCard", new { id = flashCard.CardsetId});
        }
        catch
        {
            return BadRequest("OrderItem creation failed.");
        }
    }
    
    
}