namespace TetePizza.Model;

public class Pedidos
{
    public int IdOrder { get; set; }
    public List<Pizza> Pizzas { get; set; } = new List<Pizza>();
    public double Price{ get; set; }
    public string? User { get; set; }
}