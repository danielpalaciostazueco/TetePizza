using TetePizza.Model;
using Microsoft.EntityFrameworkCore;

namespace TetePizza.Data
{
    public class PedidosEfrRepository : IPedidosRepository
    {
        private readonly TetePizzaAppContext _context;

        public PedidosEfrRepository(TetePizzaAppContext context)
        {
            _context = context;
        }

        public PedidosDTO Get(int Id)
        {
            var PedidoDTO = _context.Pedidos
                  .Where(id => id.IdOrder == Id)
                  .Select(p => new PedidosDTO
                  {
                      idOrder = p.IdOrder,
                      IdUser = p.User.IdUser,
                      NameUser = p.User.NameUser,
                      Pizzas = p.Pizzas.Select(pizza => new PizzaDTO
                      {
                          PizzaId = pizza.Id,
                          Nombre = pizza.Name,
                          Ingredientes = pizza.Ingredients.Select(i => new IngredientesDTO
                          {
                              IngredienteId = i.IdIngredient,
                              Nombre = i.NameIngredient,
                          }).ToList()
                      }).ToList()
                  })
                  .FirstOrDefault();
            return PedidoDTO;
        }

        public void Add(Pedidos pedido)
        {
            var exist = _context.Pedidos.Any(p => p.IdOrder == pedido.IdOrder);
            if (exist == null)
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
            }
            else
            {
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
            }
        }

        public List<PedidosDTO> GetAll()
        {
            var pedido = _context.Pedidos.Include(p => p.Pizzas).ToList();
            var pedidosDTO = pedido.Select(p => new PedidosDTO
            {
                idOrder = p.IdOrder,
                IdUser = p.User.IdUser,
                NameUser = p.User.NameUser,
                Pizzas = p.Pizzas.Select(pizza => new PizzaDTO
                {
                    PizzaId = pizza.Id,
                    Nombre = pizza.Name,
                    Ingredientes = pizza.Ingredients.Select(i => new IngredientesDTO
                    {
                        IngredienteId = i.IdIngredient,
                        Nombre = i.NameIngredient,
                    }).ToList()
                }).ToList()
            }).ToList();
            return pedidosDTO;
        }

        public void Update(Pedidos pedido)
        {
            var exist = _context.Pedidos.Any(p => p.IdOrder == pedido.IdOrder);
            if (exist != null)
            {
                _context.Pedidos.Update(pedido);
                _context.SaveChanges();
            }
            else
            {
                _context.Pedidos.Add(pedido);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var exist = _context.Pedidos.Any(pedido => pedido.IdOrder == id);
            if (exist != null)
            {
                var pedido = _context.Pedidos.Find(id);
                _context.Pedidos.Remove(pedido);
                _context.SaveChanges();
            }
        }
    }
}