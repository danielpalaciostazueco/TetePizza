using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TetePizza.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    IdUser = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameUser = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressUser = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.IdUser);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    IdOrder = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.IdOrder);
                    table.ForeignKey(
                        name: "FK_Pedidos_Usuarios_Usuario",
                        column: x => x.Usuario,
                        principalTable: "Usuarios",
                        principalColumn: "IdUser",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PedidosIdOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pizzas_Pedidos_PedidosIdOrder",
                        column: x => x.PedidosIdOrder,
                        principalTable: "Pedidos",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateTable(
                name: "Ingredientes",
                columns: table => new
                {
                    IdIngredient = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameIngredient = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Calories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiryDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Origin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    NutritionalInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsGlutenFree = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredientes", x => x.IdIngredient);
                    table.ForeignKey(
                        name: "FK_Ingredientes_Pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "Pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Name", "PedidosIdOrder", "Price" },
                values: new object[,]
                {
                    { 1, "Classic Italian", null, 7.02m },
                    { 2, "Vegetariana", null, 6.77m },
                    { 3, "Pepperoni", null, 9.12m },
                    { 4, "8 Quesos", null, 10.50m }
                });

            migrationBuilder.InsertData(
                table: "Ingredientes",
                columns: new[] { "IdIngredient", "Calories", "ExpiryDate", "IsGlutenFree", "NameIngredient", "NutritionalInfo", "Origin", "PizzaId", "Price", "Quantity", "Type" },
                values: new object[,]
                {
                    { 1, "Cada Tomate contiene dos 22 calorías.", "2024-02-20", true, "Tomate", "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", "Andalucía", 1, 0.22m, 2, "Fruta" },
                    { 2, "Aproximadamente 200 calorías por cada 100 gramos de prosciutto.", "2024-02-22", false, "Prosciutto", "Rico en grasas saludables y proteínas.", "Italia", 1, 1.3m, 3, "Carne" },
                    { 3, "Aproximadamente 110 calorías por cada 28 gramos de queso Parmesano.", "2024-02-25", true, "Queso Parmesano", "Alto contenido de calcio y proteínas.", "Italia", 1, 2.5m, 4, "Lácteo" },
                    { 4, "No tiene calorías.", "2024-03-01", true, "Aceite de Oliva", "Rico en grasas saludables.", "Región Mediterránea", 1, 3.0m, 1, "Condimento" },
                    { 5, "Cada tomate contiene aproximadamente 22 calorías.", "2024-02-20", true, "Tomate", "Beneficioso para la salud debido a la variedad de nutrientes y compuestos bioactivos que ofrece.", "Andalucía", 2, 0.22m, 2, "Fruta" },
                    { 6, "Aproximadamente 7 calorías por cada taza de espinacas.", "2024-02-18", true, "Espinaca", "Rica en vitaminas y minerales, baja en calorías.", "Local", 2, 0.3m, 1, "Vegetal" },
                    { 7, "Aproximadamente 11 calorías por cada 100 gramos de champiñones.", "2024-02-15", true, "Champiñones", "Buena fuente de proteínas, vitaminas y minerales.", "Cultivados", 2, 0.25m, 2, "Hongos" },
                    { 8, "Cada Tomate contiene dos 22 calorías.", "2024-02-20", true, "Tomate", "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", "Andalucía", 3, 0.22m, 2, "Fruta" },
                    { 9, "Aproximadamente 250 calorías por cada 100 gramos de pepperoni.", "2024-02-22", false, "Pepperoni", "Rico en grasas y proteínas, pero consumir con moderación debido a su contenido calórico.", "Estados Unidos", 3, 1.5m, 3, "Carne" },
                    { 10, "Aporta insignificantes calorías.", "2024-02-10", true, "Oregano", "Aporta sabor y aroma a la pizza, sin calorías significativas.", "Mediterráneo", 3, 0.1m, 1, "Hierba" },
                    { 11, "Cada Tomate contiene dos 22 calorías.", "2024-02-20", true, "Tomate", "Consumir tomates es beneficioso para la salud debido a la amplia variedad de nutrientes y compuestos bioactivos que ofrecen.", "Andalucía", 4, 0.22m, 2, "Fruta" },
                    { 12, "Aproximadamente 80 calorías por cada 28 gramos de queso mozzarella.", "2024-02-25", true, "Queso Mozzarella", "Bajo contenido de grasa y alto contenido de proteínas y calcio.", "Italia", 4, 2.0m, 3, "Lácteo" },
                    { 13, "Aproximadamente 110 calorías por cada 28 gramos de queso cheddar.", "2024-02-25", true, "Queso Cheddar", "Sabor fuerte y color naranja distintivo.", "Inglaterra", 4, 1.5m, 2, "Lácteo" },
                    { 14, "Aproximadamente 101 calorías por cada 28 gramos de queso Gouda.", "2024-02-25", true, "Queso Gouda", "Sabor suave y cremoso.", "Países Bajos", 4, 1.8m, 2, "Lácteo" },
                    { 15, "Aproximadamente 95 calorías por cada 28 gramos de queso Brie.", "2024-02-25", true, "Queso Brie", "Textura suave y sabor a nuez.", "Francia", 4, 2.2m, 2, "Lácteo" },
                    { 16, "Aproximadamente 66 calorías por cada 28 gramos de queso Roquefort.", "2024-02-25", true, "Queso Roquefort", "Sabor fuerte y textura desmenuzable.", "Francia", 4, 3.5m, 2, "Lácteo" },
                    { 17, "Aproximadamente 117 calorías por cada 28 gramos de queso Gruyere.", "2024-02-25", true, "Queso Gruyere", "Sabor a nuez y textura cremosa.", "Suiza", 4, 2.6m, 2, "Lácteo" },
                    { 18, "Aproximadamente 98 calorías por cada 28 gramos de queso Emmental.", "2024-02-25", true, "Queso Emmental", "Sabor suave y textura elástica.", "Suiza", 4, 2.3m, 2, "Lácteo" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredientes_PizzaId",
                table: "Ingredientes",
                column: "PizzaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_Usuario",
                table: "Pedidos",
                column: "Usuario");

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PedidosIdOrder",
                table: "Pizzas",
                column: "PedidosIdOrder");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredientes");

            migrationBuilder.DropTable(
                name: "Pizzas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
