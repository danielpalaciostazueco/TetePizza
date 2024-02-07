using TetePizza.Services;
using TetePizza.Controllers;
using TetePizza.Model;
using TetePizza.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var isRunning = Environment.GetEnvironmentVariable("DOCKER_CONTAINER");
string keyString;
if (isRunning == "true")
{
    keyString = "ServerDB_Container";
}
else
{
    keyString = "ServerDB";
}
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();

// Obtén más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TetePizzaAppContext>(options =>
    options.UseSqlServer(connectionString));

//Pedidos
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<IPedidosRepository, PedidosEfrRepository>();

//Ingredientes
builder.Services.AddScoped<IngredientesService>();
builder.Services.AddScoped<IIngredientesRepository, IngredientesEfrRepository>();
//Pizza
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaEfrRepository>();


var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
