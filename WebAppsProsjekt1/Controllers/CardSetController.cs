using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;
using WebAppsProsjekt1.ViewModels;
using Microsoft.AspNetCore.Authorization;
using WebAppsProsjekt1.DAL;


namespace WebAppsProsjekt1.Controllers;

public class CardSetController : Controller
{

    private readonly ICardRepository _cardRepository;

    public CardSetController(ICardRepository cardRepository)
    {
        _cardRepository = cardRepository;
    }

    public async Task<ActionResult> Table()
    {
        //var cardset = GetCardsets();
        //var cardListViwModel = new CardListViwModel(cardset, "Table");
        //return View(cardListViwModel);

        var cardsets = await _cardRepository.GetAll();
        var cardListViewModel = new CardListViwModel(cardsets, "Table");
        return View(cardListViewModel);

    }

    public async Task<IActionResult> Details(int id)
    {
        var cardset = await _cardRepository.GetCardById(id);
        if (cardset == null)
            return BadRequest("Card not found. ");
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
             
            await _cardRepository.Create(card);
            return RedirectToAction(nameof(Table));
        }
        return View(card);
    }


    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Edit(int id)
    {
        var card = await _cardRepository.GetCardById(id);
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
            await _cardRepository.Update(card);
            return RedirectToAction(nameof(Table));
        }
        return View(card);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var card = await _cardRepository.GetCardById(id);
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
        await _cardRepository.Delete(id);
        return RedirectToAction(nameof(Table));
        //var card = await _cardDbContext.Cardsets.FindAsync(id);
        //if (card == null)
        //{
        //    return NotFound();
        //}
        //_cardDbContext.Cardsets.Remove(card);
        //_cardDbContext.SaveChanges();
        //return RedirectToAction(nameof(Table));
    }

}

