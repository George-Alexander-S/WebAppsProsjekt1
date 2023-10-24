using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;
using Microsoft.AspNetCore.Authorization;


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
    [Authorize]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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
    [Authorize]
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

}

