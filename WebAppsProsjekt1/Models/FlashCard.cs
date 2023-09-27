namespace WebAppsProsjekt1.Models;

public class FlashCard
{
    public int CardId { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public string? ImageUrl { get; set; }

    public FlashCard(int cardId, string frontText, string backText)
    {
        this.CardId = cardId;
        this.FrontText = frontText;
        this.BackText = backText;
    }
}