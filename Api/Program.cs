using TetePizza.Services;
using TetePizza.Controllers;
using TetePizza.Model;
using TetePizza.Data;

var builder = WebApplication.CreateBuilder(args);

// Agrega servicios al contenedor.
builder.Services.AddControllers();
// Obtén más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra los servicios antes de llamar a builder.Build()
builder.Services.AddScoped<PedidosController>();
builder.Services.AddScoped <PedidosService>();
builder.Services.AddSingleton<IPedidosRepository, PedidosRepository>();

builder.Services.AddScoped<PizzaController>();
builder.Services.AddScoped< PizzaService>();
builder.Services.AddSingleton<IPizzaRepository, PizzaRepository>();

builder.Services.AddScoped<IngredientesController>();
builder.Services.AddScoped<IngredientesService>();
builder.Services.AddSingleton<IIngredientesRepository, IngredientesRepository>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
