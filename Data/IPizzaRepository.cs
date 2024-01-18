using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Data
{
    public interface IPizzaRepository
    {
     List<Pizza> GetAll();
     Pizza Get(int Ingredients);
     void Add(Pizza pizza);
     void Delete(int i);
     void Update(Pizza pizza);
    }
}
