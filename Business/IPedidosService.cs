using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Services
{
    public interface IPedidosService
    {
        void Add(Pedidos pedidos);
        Pedidos Get(int id);
        void AddPizzas(int id, List<Pizza> pizza);

    }
}
