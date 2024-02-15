using TetePizza.Services;
using TetePizza.Controllers;
using TetePizza.Model;
using TetePizza.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var isRunningInDocker = Environment.GetEnvironmentVariable("DOCKER_CONTAINER") == "true";
var keyString = isRunningInDocker ? "ServerDB_Docker" : "ServerDB_Local";
var connectionString = builder.Configuration.GetConnectionString(keyString);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<TetePizzaAppContext>(options =>
    options.UseSqlServer(connectionString)
         .LogTo(Console.WriteLine, LogLevel.Information)
    );

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
