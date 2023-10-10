namespace WebAppsProsjekt1.Models;

public class FlashCard
{
    public int FlashcardId { get; set; }
    public string FrontText { get; set; } = String.Empty;
    public string BackText { get; set; } = String.Empty;
    public string? ImageUrl { get; set; }
}