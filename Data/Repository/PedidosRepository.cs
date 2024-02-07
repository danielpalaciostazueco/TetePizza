/*using TetePizza.Model;
using System.Collections.Generic;
using System.Linq;

namespace TetePizza.Data;

public class PedidosRepository : IPedidosRepository
{

    private  List<Pedidos> Pedidos { get; set; }
    private int nextId = 1;

    public  PedidosRepository()
    {
        Pedidos = new List<Pedidos>();
    }


    public Pedidos? Get(int id) => Pedidos.FirstOrDefault(p => p.IdOrder == id);

    public void Add(Pedidos pedido)
    {
        pedido.IdOrder = nextId++;
        Pedidos.Add(pedido);
    }

    public void Update(Pedidos pedido)
    {
        var index = Pedidos.FindIndex(p => p.IdOrder == pedido.IdOrder);
        if (index == -1)
            return;

        Pedidos[index] = pedido;
    }

    public void Delete(int id)
    {
        var index = Pedidos.FindIndex(p => p.IdOrder == id);
        if (index == -1)
            return;

        Pedidos.RemoveAt(index);
    }

    public List<Pedidos> GetAll() => Pedidos;

    
}*/