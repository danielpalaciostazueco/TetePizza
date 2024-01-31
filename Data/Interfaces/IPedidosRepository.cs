using System.Dynamic;
using TetePizza.Model;

namespace TetePizza.Data
{
    public interface IPedidosRepository
    {
        Pedidos Get(int id);
        void Add(Pedidos pedido);
        void Update(Pedidos pedidos);

        void Delete(int id);

        List<Pedidos> GetAll();
    }
}
