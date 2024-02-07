using TetePizza.Model;
using Microsoft.EntityFrameworkCore;

namespace TetePizza.Data
{
    public class PizzaEfrRepository : IPizzaRepository
    {
        private readonly TetePizzaAppContext _context;

        public PizzaEfrRepository(TetePizzaAppContext context)
        {
            _context = context;
        }

        public List<Pizza> GetAll()
        {
            return _context.Pizzas.ToList();
            SaveChanges();
        }

        public Pizza Get(int Id)
        {
            return _context.Pizzas.FirstOrDefault(pizza => pizza.Id == Id);
            SaveChanges();
        }


        public void Add(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            SaveChanges();
        }


        public void Delete(int id)
        {
            var pizza = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
            }
            SaveChanges();
        }

        public void Update(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            SaveChanges();
        }



        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}