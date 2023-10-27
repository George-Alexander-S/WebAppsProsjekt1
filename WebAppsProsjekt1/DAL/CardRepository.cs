using System;
using Microsoft.EntityFrameworkCore;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.DAL;

public class CardRepository : ICardRepository
{
    private readonly CardDbContext _db;

    public CardRepository(CardDbContext db)
    {
        _db = db;

    }

    public async Task<IEnumerable<Cardset>> GetAll()
    {
        return await _db.Cardsets.ToListAsync();
    }

    public async Task<Cardset?> GetCardsetById(int id)
    {
        return await _db.Cardsets.FindAsync(id);
    }

    //Create function for Cardset
    public async Task Create(Cardset cardset)
    {
        _db.Cardsets.Add(cardset);
        await _db.SaveChangesAsync();
    }

    //Update function for Cardset
    public async Task Update(Cardset cardset)
    {
        _db.Cardsets.Update(cardset);
        await _db.SaveChangesAsync();
    }

    //Delete function for Cardset
    public async Task<bool> Delete(int id)
    {
        var cardset = await _db.Cardsets.FindAsync(id);
        if (cardset == null)
        {
            return false;
        }

        _db.Cardsets.Remove(cardset);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task AddCard(FlashCard flashCard)
    {
        _db.FlashCards.Add(flashCard);
        await _db.SaveChangesAsync();
        
    }

    public async Task<List<FlashCard>> GetCardsByCardsetId(int id)
    {
        return await _db.FlashCards.Where(c => c.CardsetId == id).ToListAsync();
    }

    public async Task<FlashCard?> GetFlashcardByFlashcardId(int id)
    {
        return await _db.FlashCards.FindAsync(id);
    }
    
    //The FlashCard parameter object must contain a FlashcardId value matching that of a FlashCard in the database, otherwise a new FlashCard is added (functionally becoming the AddCard method).
    public async Task EditCard(FlashCard flashCard)
    {
        _db.FlashCards.Update(flashCard);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> DeleteCard(int id)
    {
        var flashCard = await _db.FlashCards.FindAsync(id);
        if (flashCard == null)
        {
            return false;
        }

        _db.FlashCards.Remove(flashCard);
        await _db.SaveChangesAsync();
        return true;
    }
}