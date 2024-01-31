using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Data
{
    public interface IPizzaRepository
    {
     List<Pizza> GetAll();
     Pizza Get(int Id);
     void Add(Pizza pizza);
     void Delete(int id);
     void Update(Pizza pizza);
    }
}
 