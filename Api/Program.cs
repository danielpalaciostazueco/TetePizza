using TetePizza.Services;
using TetePizza.Controllers;
using TetePizza.Model;
using TetePizza.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ServerDB");
// Agrega servicios al contenedor.
builder.Services.AddControllers();
// Obtén más información sobre cómo configurar Swagger/OpenAPI en https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registra los servicios antes de llamar a builder.Build()
builder.Services.AddScoped<PedidosController>();
builder.Services.AddScoped<PedidosService>();
builder.Services.AddScoped<IPedidosRepository, PedidosSqlRepository>(serviceProvider =>
new PedidosSqlRepository(connectionString));

builder.Services.AddScoped<PizzaController>();
builder.Services.AddScoped<PizzaService>();
builder.Services.AddScoped<IPizzaRepository, PizzaSqlRepository>(serviceProvider =>
new PizzaSqlRepository(connectionString));

builder.Services.AddScoped<IngredientesController>();
builder.Services.AddScoped<IngredientesService>();
builder.Services.AddScoped<IIngredientesRepository, IngredientesSqlRepository>(serviceProvider =>
new IngredientesSqlRepository(connectionString));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
