namespace WebAppsProsjekt1.Models;

public class FlashCard
{
    public int CardId { get; set; }
    public string frontText { get; set; }
    public string backtext { get; set; }
    public string? ImageUrl { get; set; }
}