using TetePizza.Model;
using TetePizza.Data;

namespace TetePizza.Services
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _pizzaRepository; 

        public PizzaService(IPizzaRepository pizzaRepository)
        {
            _pizzaRepository = pizzaRepository;
        }

        public List<Pizza> GetAll() => _pizzaRepository.GetAll();

        public Pizza? Get(int id) => _pizzaRepository.Get(id);

        public void Add(Pizza pizza) => _pizzaRepository.Add(pizza);

        public void Delete(int id) => _pizzaRepository.Delete(id);

        public void Update(Pizza pizza) => _pizzaRepository.Update(pizza);
    }
}
