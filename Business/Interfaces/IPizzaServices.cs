using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Services
{
    public interface IPizzaService
    {
        void Add(Pizza pizza);
        Pizza Get(int id);
        void Delete(int id);
        List<Pizza> GetAll();
        void Update(Pizza pizza);
    }
}
