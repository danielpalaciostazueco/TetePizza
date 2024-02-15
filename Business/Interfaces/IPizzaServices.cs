using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Services
{
    public interface IPizzaService
    {
        void Add(Pizza pizza);
        PizzaDTO Get(int id);
        void Delete(int id);
        List<PizzaDTO> GetAll();
        void Update(Pizza pizza);
    }
}
