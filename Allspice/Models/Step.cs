namespace Allspice.Models
{
  public class Step
  {
    public int Id { get; set; }
    public int? Position { get; set; }
    public string Body { get; set; }
    public int RecipeId { get; set; }
  }
}