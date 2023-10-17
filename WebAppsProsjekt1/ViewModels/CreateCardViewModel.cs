using WebAppsProsjekt1.Models;
namespace WebAppsProsjekt1.ViewModels;

public class CreateCardViewModel
{
    public int csid { get; set; }
    public FlashCard flashCard { get; set; } = default!;

}