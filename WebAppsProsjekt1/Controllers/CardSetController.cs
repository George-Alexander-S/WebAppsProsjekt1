using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;




namespace WebAppsProsjekt1.Controllers;

public class CardSetController : Controller
{

    private readonly CardDbContext _cardDbContext;

    public CardSetController(CardDbContext cardDbContext)
    {
        _cardDbContext = cardDbContext;
    }

    public async Task<ActionResult> Table()
    {
        //var cardset = GetCardsets();
        //var cardListViwModel = new CardListViwModel(cardset, "Table");
        //return View(cardListViwModel);

        List<Cardset> cardsets = await _cardDbContext.Cardsets.ToListAsync();
        var cardListViewModel = new CardListViwModel(cardsets, "Table");
        return View(cardListViewModel);

    }

    public async Task<IActionResult> Details(int id)
    {
        var cardset = await _cardDbContext.Cardsets.FirstOrDefaultAsync(i => i.CardSetId == id);
        if (cardset == null)
            return NotFound();
        return View(cardset);
    }


    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Cardset card)
    {
        if (ModelState.IsValid)
        {
            _cardDbContext.Cardsets.Add(card); //referst do database 
            await _cardDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }
        return View(card);
    }


    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var card = await _cardDbContext.Cardsets.FindAsync(id);
        if ( card == null)
        {
            return NotFound();
        }
        return View(card);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Cardset card)
    {
        if (ModelState.IsValid)
        {
            _cardDbContext.Cardsets.Update(card);
            await _cardDbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Table));
        }
        return View(card);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var card = await _cardDbContext.Cardsets.FindAsync(id);
        if (card == null)
        {
            return NotFound();
        }
        return View(card);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var card = await _cardDbContext.Cardsets.FindAsync(id);
        if (card == null)
        {
            return NotFound();
        }
        _cardDbContext.Cardsets.Remove(card);
        _cardDbContext.SaveChanges();
        return RedirectToAction(nameof(Table));
    }
    // gjøre den til Async?
    public IActionResult Play()
    {
        var cardset = new Cardset();
        cardset.CardSetId = 78;
        cardset.CardSetName = "Test";
        cardset.Description = "Test for play";
        var cardlist = new List<FlashCard>();
        cardset.CardList = cardlist;
        var card1 = new FlashCard(1, "Hva er meningen med livet?", "42");
        var card2 = new FlashCard(2, "Hva er klokka?", "Noe som viser tiden");
        cardlist.Add(card1);
        cardlist.Add(card2);
        
        ViewBag.CurrentViewName = "Test flashcard";
        return View(cardset);
    }

    //public List<Cardset> GetCardsets()
    //{

    //var card = new List<Cardset>();


    //var card1 = new Cardset();
    //card1.CardSetId = 1;
    //card1.CardSetName = "Nature";
    //card1.Description = "Learning about nature";


    //var card2 = new Cardset();
    //card2.CardSetId = 2;
    //card2.CardSetName = "Animals";
    //card2.Description = "Learning about Animals";


    //card.Add(card1);
    //card.Add(card2);
    //return card;


    //}

}

