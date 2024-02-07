using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TetePizza.Model;

public class Ingredientes
{
    public Ingredientes() { }
    [Key]
    public int IdIngredient { get; set; }
    public string NameIngredient { get; set; }
    public int PizzaId { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public string Calories { get; set; }
    public string ExpiryDate { get; set; }
    public string Origin { get; set; }
    public decimal Price { get; set; }
    public string NutritionalInfo { get; set; }
    public bool IsGlutenFree { get; set; }
}