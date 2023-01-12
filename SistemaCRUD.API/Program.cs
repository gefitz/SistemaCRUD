using SistemaCRUD.API.Data.Cidade;
using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Connection;
using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Estado;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Repositorio.Cidade;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Estado;
using SistemaCRUD.API.Repositorio.Estado.Interface;
using SistemaCRUD.API.Service;
using SistemaCRUD.API.Service.Cidade;
using SistemaCRUD.API.Service.Cidade.Interface;
using SistemaCRUD.API.Service.Interface;
using System.Data.SqlClient;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


#region Injeção
var connection = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IConnection,Connection>(opc => new Connection(connection, new SqlConnection()));
#region Estado
builder.Services.AddScoped<IEstado, EstadoCommand>();
builder.Services.AddScoped<IRepositorioEstado, RepositorioEstado>();
builder.Services.AddScoped<IServiceEstado, ServiceEstado>();
#endregion

#region Cidade
builder.Services.AddScoped<ICidade, CidadeCommands>();
builder.Services.AddScoped<IRepositorioCidade, RepositorioCidade>();
builder.Services.AddScoped<IServiceCidade, ServiceCidade>();
#endregion

#endregion

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
