using Microsoft.EntityFrameworkCore;
using TetePizza.Model;
using Microsoft.Extensions.Configuration;

namespace TetePizza.Data
{
    public class TetePizzaAppContext : DbContext
    {

        public TetePizzaAppContext(DbContextOptions<TetePizzaAppContext> options)
            : base(options)
        {

        }

        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredientes> Ingredientes { get; set; }
        public DbSet<Pedidos> Pedidos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>().HasData(
                new Pizza { Id = 1, Name = "Classic Italian", Price = 7.02m },
                new Pizza { Id = 2, Name = "Vegetariana", Price = 6.77m },
                new Pizza { Id = 3, Name = "Pepperoni", Price = 9.12m },
                new Pizza { Id = 4, Name = "8 Quesos", Price = 10.50m }
            );
            modelBuilder.Entity<Ingredientes>().HasData(

                new Ingredientes { IdIngredient = 1, PizzaId = 1, NameIngredient = "Tomate", Type = "Fruta", Quantity = 2, Calories = "Cada Tomate contiene dos 22 calorías.", ExpiryDate = "2024-02-20", Origin = "Andalucía", Price = 0.22m, NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 2, PizzaId = 1, NameIngredient = "Prosciutto", Type = "Carne", Quantity = 3, Calories = "Aproximadamente 200 calorías por cada 100 gramos de prosciutto.", ExpiryDate = "2024-02-22", Origin = "Italia", Price = 1.3m, NutritionalInfo = "Rico en grasas saludables y proteínas.", IsGlutenFree = false },
                new Ingredientes { IdIngredient = 3, PizzaId = 1, NameIngredient = "Queso Parmesano", Type = "Lácteo", Quantity = 4, Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso Parmesano.", ExpiryDate = "2024-02-25", Origin = "Italia", Price = 2.5m, NutritionalInfo = "Alto contenido de calcio y proteínas.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 4, PizzaId = 1, NameIngredient = "Aceite de Oliva", Type = "Condimento", Quantity = 1, Calories = "No tiene calorías.", ExpiryDate = "2024-03-01", Origin = "Región Mediterránea", Price = 3.0m, NutritionalInfo = "Rico en grasas saludables.", IsGlutenFree = true },

                new Ingredientes { IdIngredient = 5, PizzaId = 2, NameIngredient = "Tomate", Type = "Fruta", Quantity = 2, Calories = "Cada tomate contiene aproximadamente 22 calorías.", ExpiryDate = "2024-02-20", Origin = "Andalucía", Price = 0.22m, NutritionalInfo = "Beneficioso para la salud debido a la variedad de nutrientes y compuestos bioactivos que ofrece.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 6, PizzaId = 2, NameIngredient = "Espinaca", Type = "Vegetal", Quantity = 1, Calories = "Aproximadamente 7 calorías por cada taza de espinacas.", ExpiryDate = "2024-02-18", Origin = "Local", Price = 0.3m, NutritionalInfo = "Rica en vitaminas y minerales, baja en calorías.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 7, PizzaId = 2, NameIngredient = "Champiñones", Type = "Hongos", Quantity = 2, Calories = "Aproximadamente 11 calorías por cada 100 gramos de champiñones.", ExpiryDate = "2024-02-15", Origin = "Cultivados", Price = 0.25m, NutritionalInfo = "Buena fuente de proteínas, vitaminas y minerales.", IsGlutenFree = true },

                new Ingredientes { IdIngredient = 8, PizzaId = 3, NameIngredient = "Tomate", Type = "Fruta", Quantity = 2, Calories = "Cada Tomate contiene dos 22 calorías.", ExpiryDate = "2024-02-20", Origin = "Andalucía", Price = 0.22m, NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 9, PizzaId = 3, NameIngredient = "Pepperoni", Type = "Carne", Quantity = 3, Calories = "Aproximadamente 250 calorías por cada 100 gramos de pepperoni.", ExpiryDate = "2024-02-22", Origin = "Estados Unidos", Price = 1.5m, NutritionalInfo = "Rico en grasas y proteínas, pero consumir con moderación debido a su contenido calórico.", IsGlutenFree = false },
                new Ingredientes { IdIngredient = 10, PizzaId = 3, NameIngredient = "Oregano", Type = "Hierba", Quantity = 1, Calories = "Aporta insignificantes calorías.", ExpiryDate = "2024-02-10", Origin = "Mediterráneo", Price = 0.1m, NutritionalInfo = "Aporta sabor y aroma a la pizza, sin calorías significativas.", IsGlutenFree = true },

                new Ingredientes { IdIngredient = 11, PizzaId = 4, NameIngredient = "Tomate", Type = "Fruta", Quantity = 2, Calories = "Cada Tomate contiene dos 22 calorías.", ExpiryDate = "2024-02-20", Origin = "Andalucía", Price = 0.22m, NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 12, PizzaId = 4, NameIngredient = "Queso Mozzarella", Type = "Lácteo", Quantity = 3, Calories = "Aproximadamente 80 calorías por cada 28 gramos de queso mozzarella.", ExpiryDate = "2024-02-25", Origin = "Italia", Price = 2.0m, NutritionalInfo = "Bajo contenido de grasa y alto contenido de proteínas y calcio.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 13, PizzaId = 4, NameIngredient = "Queso Cheddar", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso cheddar.", ExpiryDate = "2024-02-25", Origin = "Inglaterra", Price = 1.5m, NutritionalInfo = "Sabor fuerte y color naranja distintivo.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 14, PizzaId = 4, NameIngredient = "Queso Gouda", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 101 calorías por cada 28 gramos de queso Gouda.", ExpiryDate = "2024-02-25", Origin = "Países Bajos", Price = 1.8m, NutritionalInfo = "Sabor suave y cremoso.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 15, PizzaId = 4, NameIngredient = "Queso Brie", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 95 calorías por cada 28 gramos de queso Brie.", ExpiryDate = "2024-02-25", Origin = "Francia", Price = 2.2m, NutritionalInfo = "Textura suave y sabor a nuez.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 16, PizzaId = 4, NameIngredient = "Queso Roquefort", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 66 calorías por cada 28 gramos de queso Roquefort.", ExpiryDate = "2024-02-25", Origin = "Francia", Price = 3.5m, NutritionalInfo = "Sabor fuerte y textura desmenuzable.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 17, PizzaId = 4, NameIngredient = "Queso Gruyere", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 117 calorías por cada 28 gramos de queso Gruyere.", ExpiryDate = "2024-02-25", Origin = "Suiza", Price = 2.6m, NutritionalInfo = "Sabor a nuez y textura cremosa.", IsGlutenFree = true },
                new Ingredientes { IdIngredient = 18, PizzaId = 4, NameIngredient = "Queso Emmental", Type = "Lácteo", Quantity = 2, Calories = "Aproximadamente 98 calorías por cada 28 gramos de queso Emmental.", ExpiryDate = "2024-02-25", Origin = "Suiza", Price = 2.3m, NutritionalInfo = "Sabor suave y textura elástica.", IsGlutenFree = true }
            );
        }
    }
}
