using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
        public List<Pizza> GetAll()
        {
            List<Pizza> pizzas = new List<Pizza>();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sqlString = "SELECT IdPizza, NamePizza, Price FROM Pizzas";
                    var command = new SqlCommand(sqlString, connection);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var pizza = new Pizza
                            {
                                Id = Convert.ToInt32(reader["IdPizza"]),
                                Name = reader["NamePizza"].ToString(),
                                Price = (decimal)reader["Price"],
                                Ingredients = new List<Ingredientes>() // Inicializa la lista de ingredientes
                            };

                            // Agrega la pizza a la lista de pizzas
                            pizzas.Add(pizza);
                        }

                        // Cierra el DataReader de la primera consulta antes de continuar
                        reader.Close();
                    }

                    // Ahora, consulta los ingredientes para todas las pizzas
                    var ingredientsSql = "SELECT p.IdPizza, i.IdIngredient, i.NameIngredient, i.Type, i.Quantity, i.Calories, i.ExpiryDate, i.Origin, i.Price, i.NutritionalInfo, i.IsGlutenFree " +
                                         "FROM Pizzas p " +
                                         "INNER JOIN Ingredientes i ON p.IdPizza = i.PizzaId " +
                                         "ORDER BY p.IdPizza";

                    var ingredientsCommand = new SqlCommand(ingredientsSql, connection);

                    using (var ingredientsReader = ingredientsCommand.ExecuteReader())
                    {
                        while (ingredientsReader.Read())
                        {
                            var pizzaId = Convert.ToInt32(ingredientsReader["IdPizza"]);
                            var pizza = pizzas.FirstOrDefault(p => p.Id == pizzaId);

                            if (pizza != null)
                            {
                                var ingredient = new Ingredientes
                                {
                                    IdIngredient = Convert.ToInt32(ingredientsReader["IdIngredient"]),
                                    NameIngredient = ingredientsReader["NameIngredient"].ToString(),
                                    Type = ingredientsReader["Type"].ToString(),
                                    Quantity = Convert.ToInt32(ingredientsReader["Quantity"]),
                                    Calories = ingredientsReader["Calories"].ToString(),
                                    ExpiryDate = ingredientsReader["ExpiryDate"].ToString(),
                                    Origin = ingredientsReader["Origin"].ToString(),
                                    Price = (decimal)ingredientsReader["Price"],
                                    NutritionalInfo = ingredientsReader["NutritionalInfo"].ToString(),
                                    IsGlutenFree = Convert.ToBoolean(ingredientsReader["IsGlutenFree"])
                                };

                                // Agrega el ingrediente a la lista de ingredientes de la pizza correspondiente
                                pizza.Ingredients.Add(ingredient);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw;
            }
            return pizzas;
        }


        public Pizza Get(int Id)
        {
            var pizza = new Pizza();
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sqlString = "SELECT IdPizza, NamePizza, Price FROM Pizzas WHERE IdPizza = @Id";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@Id", Id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            pizza = new Pizza
                            {
                                Id = Convert.ToInt32(reader["IdPizza"]),
                                Name = reader["NamePizza"].ToString(),
                                Price = (decimal)reader["Price"],
                                Ingredients = new List<Ingredientes>() // Inicializa la lista de ingredientes
                            };
                            reader.Close();
                        }
                    }

                    // Ahora, consulta los ingredientes para esta pizza
                    var ingredientsSql = "SELECT IdIngredient, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree " +
                                         "FROM Ingredientes " +
                                         "WHERE PizzaId = @PizzaId";
                    var ingredientsCommand = new SqlCommand(ingredientsSql, connection);
                    ingredientsCommand.Parameters.AddWithValue("@PizzaId", pizza.Id);

                    using (var ingredientsReader = ingredientsCommand.ExecuteReader())
                    {
                        while (ingredientsReader.Read())
                        {
                            var ingredient = new Ingredientes
                            {
                                IdIngredient = Convert.ToInt32(ingredientsReader["IdIngredient"]),
                                NameIngredient = ingredientsReader["NameIngredient"].ToString(),
                                Type = ingredientsReader["Type"].ToString(),
                                Quantity = Convert.ToInt32(ingredientsReader["Quantity"]),
                                Calories = ingredientsReader["Calories"].ToString(),
                                ExpiryDate = ingredientsReader["ExpiryDate"].ToString(),
                                Origin = ingredientsReader["Origin"].ToString(),
                                Price = (decimal)ingredientsReader["Price"],
                                NutritionalInfo = ingredientsReader["NutritionalInfo"].ToString(),
                                IsGlutenFree = Convert.ToBoolean(ingredientsReader["IsGlutenFree"])
                            };

                            // Agrega el ingrediente a la lista de ingredientes de la pizza
                            pizza.Ingredients.Add(ingredient);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw;
            }
            return pizza;
        }

        public void Add(Pizza pizza)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Comienza una transacción para asegurarte de que ambas operaciones (pizza e ingredientes) se completen correctamente o ninguna.
                    using (var transaction = connection.BeginTransaction())
                    {
                        // Inserta la pizza en la tabla "Pizzas"
                        var insertPizzaSql = "INSERT INTO Pizzas (NamePizza, Price) VALUES (@NamePizza, @Price); SELECT SCOPE_IDENTITY()";
                        var insertPizzaCommand = new SqlCommand(insertPizzaSql, connection, transaction);
                        insertPizzaCommand.Parameters.AddWithValue("@NamePizza", pizza.Name);
                        insertPizzaCommand.Parameters.AddWithValue("@Price", pizza.Price);

                        // Obtiene el ID de la pizza recién insertada
                        var pizzaId = Convert.ToInt32(insertPizzaCommand.ExecuteScalar());

                        // Inserta los ingredientes en la tabla "Ingredientes" asociados a la pizza por su ID
                        foreach (var ingredient in pizza.Ingredients)
                        {
                            var insertIngredientSql = "INSERT INTO Ingredientes (PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree) " +
                                                      "VALUES (@PizzaId, @NameIngredient, @Type, @Quantity, @Calories, @ExpiryDate, @Origin, @Price, @NutritionalInfo, @IsGlutenFree)";
                            var insertIngredientCommand = new SqlCommand(insertIngredientSql, connection, transaction);
                            insertIngredientCommand.Parameters.AddWithValue("@PizzaId", pizzaId);
                            insertIngredientCommand.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                            insertIngredientCommand.Parameters.AddWithValue("@Type", ingredient.Type);
                            insertIngredientCommand.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                            insertIngredientCommand.Parameters.AddWithValue("@Calories", ingredient.Calories);
                            insertIngredientCommand.Parameters.AddWithValue("@ExpiryDate", ingredient.ExpiryDate);
                            insertIngredientCommand.Parameters.AddWithValue("@Origin", ingredient.Origin);
                            insertIngredientCommand.Parameters.AddWithValue("@Price", ingredient.Price);
                            insertIngredientCommand.Parameters.AddWithValue("@NutritionalInfo", ingredient.NutritionalInfo);
                            insertIngredientCommand.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);

                            insertIngredientCommand.ExecuteNonQuery();
                        }

                        // Confirma la transacción
                        transaction.Commit();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Maneja la excepción de SQL Server aquí, puedes registrarla o realizar acciones específicas si es necesario.
                // Por ejemplo: LogError(ex);
                throw;
            }
            catch (Exception ex)
            {
                // Maneja otras excepciones aquí, puedes registrarlas o realizar acciones específicas si es necesario.
                // Por ejemplo: LogError(ex);
                throw;
            }
        }

        public void Delete(int Id)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();
                    var sqlString = "DELETE FROM Pizzas WHERE idPizza = @idPizza";
                    var command = new SqlCommand(sqlString, connection);
                    command.Parameters.AddWithValue("@idPizza", Id);

                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                // Manejar o registrar la excepción SQL específica
                throw;
            }
            catch (Exception ex)
            {
                // Manejar o registrar excepciones generales
                throw;
            }
        }
        public void Update(Pizza pizza)
        {
            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    // Actualiza los datos de la pizza en la tabla Pizzas
                    var updatePizzaSql = "UPDATE Pizzas SET NamePizza = @NamePizza, Price = @Price WHERE IdPizza = @IdPizza";
                    var updatePizzaCommand = new SqlCommand(updatePizzaSql, connection);
                    updatePizzaCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                    updatePizzaCommand.Parameters.AddWithValue("@NamePizza", pizza.Name);
                    updatePizzaCommand.Parameters.AddWithValue("@Price", pizza.Price);
                    updatePizzaCommand.ExecuteNonQuery();

                    // Borra todos los ingredientes de la pizza de la tabla Ingredientes
                    var deleteIngredientsSql = "DELETE FROM Ingredientes WHERE PizzaId = @IdPizza";
                    var deleteIngredientsCommand = new SqlCommand(deleteIngredientsSql, connection);
                    deleteIngredientsCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                    deleteIngredientsCommand.ExecuteNonQuery();

                    // Inserta los nuevos ingredientes en la tabla Ingredientes
                    foreach (var ingredient in pizza.Ingredients)
                    {
                        var insertIngredientSql = "INSERT INTO Ingredientes (PizzaId, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree) " +
                                                  "VALUES (@IdPizza, @NameIngredient, @Type, @Quantity, @Calories, @ExpiryDate, @Origin, @Price, @NutritionalInfo, @IsGlutenFree)";
                        var insertIngredientCommand = new SqlCommand(insertIngredientSql, connection);
                        insertIngredientCommand.Parameters.AddWithValue("@IdPizza", pizza.Id);
                        insertIngredientCommand.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                        insertIngredientCommand.Parameters.AddWithValue("@Type", ingredient.Type);
                        insertIngredientCommand.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                        insertIngredientCommand.Parameters.AddWithValue("@Calories", ingredient.Calories);
                        insertIngredientCommand.Parameters.AddWithValue("@ExpiryDate", ingredient.ExpiryDate);
                        insertIngredientCommand.Parameters.AddWithValue("@Origin", ingredient.Origin);
                        insertIngredientCommand.Parameters.AddWithValue("@Price", ingredient.Price);
                        insertIngredientCommand.Parameters.AddWithValue("@NutritionalInfo", ingredient.NutritionalInfo);
                        insertIngredientCommand.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);
                        insertIngredientCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción o registrarla
                throw;
            }
        }

    }
}