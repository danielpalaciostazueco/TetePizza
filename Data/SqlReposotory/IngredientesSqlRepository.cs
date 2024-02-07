/*using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using TetePizza.Model;

namespace TetePizza.Data;

public class IngredientesSqlRepository : IIngredientesRepository
{

    private readonly string _connectionString;

    public IngredientesSqlRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public Ingredientes Get(int IdIngredient)
    {

        var ingredientes = new Ingredientes();
        try
        {


            using (var connection = new SqlConnection(_connectionString))
            {
                var Ingredientes = new Ingredientes();
                connection.Open();
                var sqlString = "SELECT IdIngredient,PizzaId,NameIngredient,Type,Quantity,Calories,ExpiryDate,Origin,Price,NutritionalInfo,IsGlutenFree"
                + " FROM Ingredientes WHERE IdIngredient = " + IdIngredient;
                var command = new SqlCommand(sqlString, connection);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Ingredientes = new Ingredientes()
                        {
                            IdIngredient = Convert.ToInt32(reader["IdIngredient"]),
                            PizzaId = Convert.ToInt32(reader["PizzaId"]),
                            NameIngredient = (reader["NameIngredient"]).ToString(),
                            Type = (reader["Type"]).ToString(),
                            Quantity = Convert.ToInt32(reader["Quantity"]),
                            Calories = (reader["Calories"]).ToString(),
                            ExpiryDate = (reader["ExpiryDate"]).ToString(),
                            Origin = (reader["Origin"]).ToString(),
                            Price = (decimal)(reader["Price"]),
                            NutritionalInfo = (reader["NutritionalInfo"]).ToString(),
                            IsGlutenFree = Convert.ToBoolean(reader["IsGlutenFree"])
                        };
                        reader.Close();
                    }
                }
                return Ingredientes;
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al obtener el ingrediente", ex);
        }
    }

    public List<Ingredientes> GetAll()
    {
        List<Ingredientes> ingredients = new List<Ingredientes>();

        using (var connection = new SqlConnection(_connectionString))
        {
            connection.Open();

            var sqlString = "SELECT IdIngredient, NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree FROM Ingredientes";
            var command = new SqlCommand(sqlString, connection);

            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Ingredientes ingredient = new Ingredientes
                    {
                        IdIngredient = Convert.ToInt32(reader["IdIngredient"]),
                        NameIngredient = reader["NameIngredient"].ToString(),
                        Type = reader["Type"].ToString(),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Calories = reader["Calories"].ToString(),
                        ExpiryDate = reader["ExpiryDate"].ToString(),
                        Origin = reader["Origin"].ToString(),
                        Price = (decimal)(reader["Price"]),
                        NutritionalInfo = reader["NutritionalInfo"].ToString(),
                        IsGlutenFree = Convert.ToBoolean(reader["IsGlutenFree"])
                    };

                    ingredients.Add(ingredient);
                }
            }
        }

        return ingredients;
    }

    public void Add(Ingredientes ingredient)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlString = "INSERT INTO Ingredientes (NameIngredient, Type, Quantity, Calories, ExpiryDate, Origin, Price, NutritionalInfo, IsGlutenFree) VALUES (@NameIngredient, @Type, @Quantity, @Calories, @ExpiryDate, @Origin, @Price, @NutritionalInfo, @IsGlutenFree)";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                command.Parameters.AddWithValue("@ExpiryDate", ingredient.ExpiryDate);
                command.Parameters.AddWithValue("@Origin", ingredient.Origin);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@NutritionalInfo", ingredient.NutritionalInfo);
                command.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al agregar el ingrediente", ex);
        }
    }


    public void Update(Ingredientes ingredient)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlString = "UPDATE Ingredientes SET NameIngredient = @NameIngredient, Type = @Type, Quantity = @Quantity, Calories = @Calories, ExpiryDate = @ExpiryDate, Origin = @Origin, Price = @Price, NutritionalInfo = @NutritionalInfo, IsGlutenFree = @IsGlutenFree WHERE IdIngredient = @IdIngredient";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@IdIngredient", ingredient.IdIngredient);
                command.Parameters.AddWithValue("@NameIngredient", ingredient.NameIngredient);
                command.Parameters.AddWithValue("@Type", ingredient.Type);
                command.Parameters.AddWithValue("@Quantity", ingredient.Quantity);
                command.Parameters.AddWithValue("@Calories", ingredient.Calories);
                command.Parameters.AddWithValue("@ExpiryDate", ingredient.ExpiryDate);
                command.Parameters.AddWithValue("@Origin", ingredient.Origin);
                command.Parameters.AddWithValue("@Price", ingredient.Price);
                command.Parameters.AddWithValue("@NutritionalInfo", ingredient.NutritionalInfo);
                command.Parameters.AddWithValue("@IsGlutenFree", ingredient.IsGlutenFree);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al actualizar el ingrediente", ex);
        }
    }

    public void Delete(int IdIngredient)
    {
        try
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var sqlString = "DELETE FROM Ingredientes WHERE IdIngredient = @IdIngredient";
                var command = new SqlCommand(sqlString, connection);
                command.Parameters.AddWithValue("@IdIngredient", IdIngredient);
                command.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Error al eliminar el ingrediente", ex);
        }
    }
}
*/