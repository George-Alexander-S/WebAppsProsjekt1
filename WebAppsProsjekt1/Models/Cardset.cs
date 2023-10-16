using System;
namespace WebAppsProsjekt1.Models;

public class Cardset
{
    public int CardSetId { get; set; }
    public string CardSetName { get; set; } = String.Empty; // declared with defail valus
    public string? Description { get; set; }
    public string? ImageUrl { get;  set; }
    // navigation property
    public virtual List<FlashCard> CardList {get; set;}

    
}