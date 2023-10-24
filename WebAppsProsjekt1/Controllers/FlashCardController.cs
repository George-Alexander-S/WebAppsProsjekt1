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
  

    public async Task<ActionResult> FlashCardTable(int id)
    {
        var cardset = await _cardDbContext.Cardsets.FirstOrDefaultAsync(c => c.CardSetId == id);
        if (cardset == null)
            return NotFound();
        return View(cardset);
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CreateCard(int id)
    {
        var createCardViewModel = new CreateCardViewModel();
        createCardViewModel.csid = id;
        return View(createCardViewModel);
    }

    [HttpPost]
    [Authorize]
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

    [HttpGet("/GetCards")]
    public async Task<IActionResult> GetCards(int id)
    {
        List<FlashCard> cards = await _cardDbContext.FlashCards.Where(c => c.CardsetId == id).ToListAsync();
        return Json(cards);
    }
    
    
}