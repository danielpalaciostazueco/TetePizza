using Microsoft.EntityFrameworkCore;
using TetePizza.Model;
using System.Collections.Generic;
using System.Linq;

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
          
            return _context.Pizzas.Include(p => p.Ingredients).ToList();
        }

        public Pizza Get(int Id)
        {
            
            return _context.Pizzas.Include(p => p.Ingredients)
                                  .FirstOrDefault(pizza => pizza.Id == Id);
        }

        public void Add(Pizza pizza)
        {
            _context.Pizzas.Add(pizza);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pizza = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
            if (pizza != null)
            {
                _context.Pizzas.Remove(pizza);
                _context.SaveChanges();
            }
        }

        public void Update(Pizza pizza)
        {
            _context.Pizzas.Update(pizza);
            _context.SaveChanges();
        }
    }
}
