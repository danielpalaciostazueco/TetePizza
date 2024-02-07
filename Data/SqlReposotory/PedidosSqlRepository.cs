/*
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TetePizza.Model;

namespace TetePizza.Data
{
    public class PedidosSqlRepository : IPedidosRepository
    {
        private readonly string _connectionString;

        public PedidosSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public Pedidos Get(int id)
        {
            var pedido = new Pedidos();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT IdOrder, Price FROM Pedidos WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pedido.IdOrder = Convert.ToInt32(reader["IdOrder"]);
                        pedido.Price = (decimal)reader["Price"];
                    }
                }
            }

            return pedido;
        }

        public void Add(Pedidos pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "INSERT INTO Pedidos (Price) VALUES (@Price); SELECT SCOPE_IDENTITY();";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Price", pedido.Price);

                int newOrderId = Convert.ToInt32(command.ExecuteScalar());

                pedido.IdOrder = newOrderId;
            }
        }

        public void Update(Pedidos pedido)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "UPDATE Pedidos SET Price = @Price WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", pedido.IdOrder);
                command.Parameters.AddWithValue("@Price", pedido.Price);

                command.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "DELETE FROM Pedidos WHERE IdOrder = @Id";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@Id", id);

                command.ExecuteNonQuery();
            }
        }

        public List<Pedidos> GetAll()
        {
            var pedidos = new List<Pedidos>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT IdOrder, Price FROM Pedidos";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var pedido = new Pedidos
                        {
                            IdOrder = Convert.ToInt32(reader["IdOrder"]),
                            Price = (decimal)reader["Price"]
                        };

                        pedidos.Add(pedido);
                    }
                }
            }

            return pedidos;
        }
    }
}
*/
