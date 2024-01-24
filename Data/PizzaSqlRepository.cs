using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text.Json;
using System.Data.SqlClient;
using System.Data;
using TetePizza.Model;

namespace TetePizza.Data
{
    public class PizzaSqlRepository : IPizzaRepository
    {
        private readonly string _connectionString;

        public PizzaSqlRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public  List<Pizza> GetAll() {
            var Pizza = new Pizza();
            List<Pizza> pizzas = new List<Pizza>();
             using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT idPizza, NamePizza, Price FROM Pizzas";
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pizza = new Pizza
                        {
                            Id= Convert.ToInt32(reader["idPizza"].ToString()),
                            Name = reader["NamePizza"].ToString(),
                            Price = (double)reader["Price"],
                        };
                        pizzas.Add(Pizza);
                    }
                }
            }
            return pizzas;
        }

        public  Pizza Get(int Id) {
             var Pizza = new Pizza();
             using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                var sqlString = "SELECT idPizza, NamePizza, Price FROM Pizzas=" + Id;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pizza = new Pizza
                        {
                            Id= Convert.ToInt32(reader["idPizza"].ToString()),
                            Name = reader["NamePizza"].ToString(),
                            Price = (double)reader["Price"],
                        };
                    }
                }
            }
            return Pizza;
        }

        public void Add(Pizza pizza)
        {
           
        }

        public void Delete(int IdIngredient)
        {
           
        }

        public void Update(Pizza pizza)
        {
            
        }
    }
}