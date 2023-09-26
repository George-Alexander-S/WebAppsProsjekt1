namespace WebAppsProsjekt1.Models;

public class Cardset
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public string UserId { get; set; }
    public List<FlashCard>? FlashCards { get; set; }

    public Cardset(string Name, string UserId, List<FlashCard> FlashCards)
    {
        this.Name = Name;
        this.UserId = UserId;
        this.FlashCards = FlashCards;
    }
}