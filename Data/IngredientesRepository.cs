using TetePizza.Model;
using System.Collections.Generic;

namespace TetePizza.Data
{
    public class IngredientesRepository : IIngredientesRepository
    {
        private List<Ingredientes> Ingredientes { get; set; }
        private  int nextId = 1;

        public IngredientesRepository()
        {
            Ingredientes = new List<Ingredientes>
            {
                new Ingredientes
                {
                    IdIngredient = 0,
                    NameIngredient = "Tomate",
                    Type = "Fruta",
                    Quantity = 2,
                    Calories = "Cada Tomate contiene dos 22 calorías.",
                    ExpiryDate = "20/02/2024.",
                    Origin = "El tomate proviene de Andalucía",
                    Price = 0.22,
                    NutritionalInfo = "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 1,
                    NameIngredient = "Prosciutto",
                    Type = "Carne",
                    Quantity = 3,
                    Calories = "Aproximadamente 200 calorías por cada 100 gramos de prosciutto.",
                    ExpiryDate = "2024-02-22",
                    Origin = "Italia",
                    Price = 1.3,
                    NutritionalInfo = "Rico en grasas saludables y proteínas.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 2,
                    NameIngredient = "Queso Parmesano",
                    Type = "Lácteo",
                    Quantity = 4,
                    Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso Parmesano.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Italia",
                    Price = 2.5,
                    NutritionalInfo = "Alto contenido de calcio y proteínas.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 3,
                    NameIngredient = "Aceite de Oliva",
                    Type = "Condimento",
                    Quantity = 1,
                    Calories = "No tiene calorías.",
                    ExpiryDate = "2024-03-01",
                    Origin = "Región Mediterránea",
                    Price = 3.0,
                    NutritionalInfo = "Rico en grasas saludables.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 4,
                    NameIngredient = "Espinaca",
                    Type = "Vegetal",
                    Quantity = 1,
                    Calories = "Aproximadamente 7 calorías por cada taza de espinacas.",
                    ExpiryDate = "2024-02-18",
                    Origin = "Local",
                    Price = 0.3,
                    NutritionalInfo = "Rica en vitaminas y minerales, baja en calorías.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 5,
                    NameIngredient = "Champiñones",
                    Type = "Hongos",
                    Quantity = 2,
                    Calories = "Aproximadamente 11 calorías por cada 100 gramos de champiñones.",
                    ExpiryDate = "2024-02-15",
                    Origin = "Cultivados",
                    Price = 0.25,
                    NutritionalInfo = "Buena fuente de proteínas, vitaminas y minerales.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 6,
                    NameIngredient = "Pepperoni",
                    Type = "Carne",
                    Quantity = 2,
                    Calories = "Aproximadamente 250 calorías por cada 100 gramos de pepperoni.",
                    ExpiryDate = "2024-02-22",
                    Origin = "Estados Unidos",
                    Price = 1.5,
                    NutritionalInfo = "Rico en grasas y proteínas, pero consumir con moderación debido a su contenido calórico.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 7,
                    NameIngredient = "Oregano",
                    Type = "Hierba",
                    Quantity = 1,
                    Calories = "Aporta insignificantes calorías.",
                    ExpiryDate = "Indeterminada",
                    Origin = "Mediterráneo",
                    Price = 0.1,
                    NutritionalInfo = "Aporta sabor y aroma a la pizza, sin calorías significativas.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 8,
                    NameIngredient = "Aceitunas",
                    Type = "Fruta",
                    Quantity = 10,
                    Calories = "Aproximadamente 5 calorías por cada aceituna.",
                    ExpiryDate = "20/02/2024",
                    Origin = "Mediterráneo",
                    Price = 0.3,
                    NutritionalInfo = "Ricas en grasas saludables y antioxidantes.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 9,
                    NameIngredient = "Queso Mozzarella",
                    Type = "Lácteo",
                    Quantity = 3,
                    Calories = "Aproximadamente 80 calorías por cada 28 gramos de queso mozzarella.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Italia",
                    Price = 2.0,
                    NutritionalInfo = "Bajo contenido de grasa y alto contenido de proteínas y calcio.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 10,
                    NameIngredient = "Queso Cheddar",
                    Type = "Lácteo",
                    Quantity = 2,
                    Calories = "Aproximadamente 110 calorías por cada 28 gramos de queso cheddar.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Inglaterra",
                    Price = 1.5,
                    NutritionalInfo = "Sabor fuerte y color naranja distintivo.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 11,
                    NameIngredient = "Queso Gorgonzola",
                    Type = "Lácteo",
                    Quantity = 2,
                    Calories = "Aproximadamente 100 calorías por cada 28 gramos de queso gorgonzola.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Italia",
                    Price = 2.2,
                    NutritionalInfo = "Queso azul con sabor fuerte.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 12,
                    NameIngredient = "Queso Feta",
                    Type = "Lácteo",
                    Quantity = 2,
                    Calories = "Aproximadamente 80 calorías por cada 28 gramos de queso feta.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Grecia",
                    Price = 2.0,
                    NutritionalInfo = "Queso blanco y desmenuzable con sabor salado.",
                    IsGlutenFree = true
                },
                new Ingredientes
                {
                    IdIngredient = 13,
                    NameIngredient = "Queso Provolone",
                    Type = "Lácteo",
                    Quantity = 2,
                    Calories = "Aproximadamente 98 calorías por cada 28 gramos de queso provolone.",
                    ExpiryDate = "2024-02-25",
                    Origin = "Italia",
                    Price = 2.0,
                    NutritionalInfo = "Queso italiano semiduro con sabor suave.",
                    IsGlutenFree = true
                }
            };
        }

        public Ingredientes Get(int id) => Ingredientes.Find(i => i.IdIngredient == id);
        public List<Ingredientes> GetAll() => Ingredientes;
    }
}
