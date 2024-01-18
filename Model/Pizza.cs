namespace TetePizza.Model;

public class Pizza {

    public int Id{ get; set;}

    public string? Name { get; set; }

    public double Price {get; set;}

    public List<Ingredientes> Ingredients {get; set;}

}