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

//Pedidos
builder.Services.AddScoped<PedidosController>();
builder.Services.AddScoped<PedidosService>();
builder.Services.AddDbContext<TetePizzaAppContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPedidosRepository, PedidosEfrRepository>();


//Pizza
builder.Services.AddScoped<PizzaController>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddDbContext<TetePizzaAppContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IPizzaRepository, PizzaEfrRepository>();

//Ingredientes
builder.Services.AddScoped<IngredientesController>();
builder.Services.AddScoped<IngredientesService>();
builder.Services.AddDbContext<TetePizzaAppContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IIngredientesRepository, IngredientesEfrRepository>();


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
