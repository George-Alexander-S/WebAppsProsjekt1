namespace WebAppsProsjekt1.Models;

public class FlashCard
{
    public int CardId { get; set; }
    public string FrontText { get; set; }
    public string BackText { get; set; }
    public string? ImageUrl { get; set; }

    public FlashCard(int CardId, string FrontText, string BackText)
    {
        this.CardId = CardId;
        this.FrontText = FrontText;
        this.BackText = BackText;
    }
}