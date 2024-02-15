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

        public List<PizzaDTO> GetAll()
        {
            var pizzas = _context.Pizzas.Include(p => p.Ingredients).ToList();
            var PizzasDTO = pizzas.Select(p => new PizzaDTO
            {
                PizzaId = p.Id,
                Nombre = p.Name,
                Ingredientes = p.Ingredients.Select(i => new IngredientesDTO
                {
                    IngredienteId = i.IdIngredient,
                    Nombre = i.NameIngredient,
                }).ToList()
            }).ToList();
            return PizzasDTO;
        }

        public PizzaDTO Get(int Id)
        {
            var pizzasDTO = _context.Pizzas
                .Where(id => id.Id == Id)
                .Select(p => new PizzaDTO
                {
                    PizzaId = p.Id,
                    Nombre = p.Name,
                    Ingredientes = p.Ingredients.Select(i => new IngredientesDTO
                    {
                        IngredienteId = i.IdIngredient,
                        Nombre = i.NameIngredient,
                    }).ToList()
                })
                .FirstOrDefault();
            return pizzasDTO;
        }

        public void Add(Pizza pizza)
        {
            var exist = _context.Pizzas.Any(p => p.Id == pizza.Id);
            if (exist == null)
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();

            }
            else
            {
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();
            }

        }

        public void Delete(int id)
        {
            var exist = _context.Pizzas.Any(pizza => pizza.Id == id);
            if (exist != null)
            {
                var pizzas = _context.Pizzas.FirstOrDefault(pizza => pizza.Id == id);
                _context.Pizzas.Remove(pizzas);
                _context.SaveChanges();
            }
        }

        public void Update(Pizza pizza)
        {
            var exist = _context.Pizzas.Any(p => p.Id == pizza.Id);
            if (exist != null)
            {
                _context.Pizzas.Update(pizza);
                _context.SaveChanges();

            }
            else
            {
                _context.Pizzas.Add(pizza);
                _context.SaveChanges();
            }
        }
    }
}
