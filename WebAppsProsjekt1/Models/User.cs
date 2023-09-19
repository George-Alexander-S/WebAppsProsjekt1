namespace WebAppsProsjekt1.Models;

public class User
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public List<Cardset>? Cardsets { get; set; }
}