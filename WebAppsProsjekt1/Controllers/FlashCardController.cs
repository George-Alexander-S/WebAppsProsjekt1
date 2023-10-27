using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using WebAppsProsjekt1.DAL;

namespace WebAppsProsjekt1.Controllers;

public class FlashCardController : Controller
{
    private readonly ICardRepository _cardRepository;

    public FlashCardController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }
  

    public async Task<ActionResult> FlashCardTable(int id)
    {
        var card = await _cardRepository.GetCardsetById(id);
        if ( card == null)
        {
            return NotFound();
        }
        return View(card);
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
            var cardset = await _cardRepository.GetCardsetById(flashCard.CardsetId);
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
            await _cardRepository.AddCard(newCard);
            return RedirectToAction("CreateCard", "FlashCard", new { id = flashCard.CardsetId});
        }
        catch
        {
            return BadRequest("CreateCard action failed.");
        }
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> EditCard(int id)
    {
        var createCardViewModel = new CreateCardViewModel();
        createCardViewModel.flashCard = await _cardRepository.GetFlashcardByFlashcardId(id);
        if (createCardViewModel.flashCard == null)
        {
            return BadRequest("Flashcard not found");
        }
        createCardViewModel.csid = createCardViewModel.flashCard.CardsetId;
        return View(createCardViewModel);
    }

    [HttpPost]
    [Authorize]

    //The EditCard functions very similarly to CreateCard.
    //The main difference with Edit, is that the form in the View will supply a FlashcardId that already belongs to a FlashCard,
    //which allows the already existing row in the database to be updated, instead of creating a new row with an auto-incremented value for FlashcardId
    
    public async Task<IActionResult> EditCard(FlashCard flashCard)
    {
        try
        {
            var cardset = await _cardRepository.GetCardsetById(flashCard.CardsetId);
            if (cardset == null)
            {
                return BadRequest();
            }

            var newCard = new FlashCard
            {
                FlashcardId = flashCard.FlashcardId,
                CardsetId = flashCard.CardsetId,
                Cardset = cardset,
                FrontText = flashCard.FrontText,
                BackText = flashCard.BackText,
                ImageUrl = flashCard.ImageUrl
            };
            await _cardRepository.EditCard(newCard);
            return RedirectToAction("EditFlashCards", "CardSet", new { id = flashCard.CardsetId});
        }
        catch
        {
            return BadRequest("EditCard action failed.");
        }
    }

    //This method returns a list of all FlashCard objects in a given Cardset, converted to a JSON object. It is used by the carousel in the FlashCard/FlashCardTable view.

    [HttpGet("/GetCards")]
    public async Task<IActionResult> GetCards(int id)
    {
        List<FlashCard> cards = await _cardRepository.GetCardsByCardsetId(id);
        return Json(cards);
    }

    [Authorize]
    public async Task<ActionResult> DeleteCard(int cardId, int setId)
    {
        await _cardRepository.DeleteCard(cardId);
        return RedirectToAction("EditFlashCards", "CardSet", new { id = setId});
    }
}