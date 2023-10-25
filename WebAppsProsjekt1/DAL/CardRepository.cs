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

    public async Task Create(Cardset cardset)
    {
        _db.Cardsets.Add(cardset);
        await _db.SaveChangesAsync();
    }

    public async Task Update(Cardset cardset)
    {
        _db.Cardsets.Update(cardset);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> Delete(int id)
    {
        var card = await _db.Cardsets.FindAsync(id);
        if (card == null)
        {
            return false;
        }

        _db.Cardsets.Remove(card);
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

}