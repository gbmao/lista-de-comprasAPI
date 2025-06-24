using lista_de_comprasAPI.Data;
using lista_de_comprasAPI.Dtos;
using lista_de_comprasAPI.Endpoints;


var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("Lista-de-comprasAPI");
builder.Services.AddSqlite<Lista_de_comprasContext>(connString);

var app = builder.Build();

app.MapProgramEndpoint();

app.MigrateDB();

app.Run();
