using lista_de_comprasAPI.Dtos;
using lista_de_comprasAPI.Endpoints;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapProgramEndpoint();

app.Run();
