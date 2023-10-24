using System;
using WebAppsProsjekt1.Models;

namespace WebAppsProsjekt1.DAL;

public interface ICardRepository
{
    Task<IEnumerable<Cardset>> GetAll();
    Task<Cardset?> GetCardById(int id);
    Task Create(Cardset cardset);
    Task Update(Cardset cardset);
    Task<bool> Delete(int id);
}

