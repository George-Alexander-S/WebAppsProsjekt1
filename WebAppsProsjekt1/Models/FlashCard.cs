namespace WebAppsProsjekt1.Models;

public class FlashCard
{
    public int FlashcardId { get; set; }
    public int CardsetId {  get; set; }
    // navigation property
    public Cardset Cardset { get; set; } = default!;
    public string FrontText { get; set; } = String.Empty;
    public string BackText { get; set; } = String.Empty;

    //Currently, display of images on flashcards is not supported, but the property exists.
    public string? ImageUrl { get; set; }
}