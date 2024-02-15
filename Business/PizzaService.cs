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

        public List<PizzaDTO> GetAll() => _pizzaRepository.GetAll();

        public PizzaDTO Get(int id) => _pizzaRepository.Get(id);

        public void Add(Pizza pizza) => _pizzaRepository.Add(pizza);

        public void Delete(int id) => _pizzaRepository.Delete(id);

        public void Update(Pizza pizza) => _pizzaRepository.Update(pizza);
    }
}
