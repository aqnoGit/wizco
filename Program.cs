using System.Text.Json.Serialization;
using GerenciadorDePedidos.Data;
using GerenciadorDePedidos.Repository;
using GerenciadorDePedidos.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>{options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => { c.UseInlineDefinitionsForEnums(); });

var connectionString = builder.Configuration.GetConnectionString("AppDbConnectionString");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddScoped<IGerenciadorDePedidosService, GerenciadorDePedidosService>(); 
builder.Services.AddScoped<IGerenciadorDePedidos, GerenciadorDePedidosRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
