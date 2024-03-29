#region using
using SistemaCRUD.API.Data.Cidade;
using SistemaCRUD.API.Data.Cidade.Interface;
using SistemaCRUD.API.Data.Connection;
using SistemaCRUD.API.Data.Connection.Interface;
using SistemaCRUD.API.Data.Empresa;
using SistemaCRUD.API.Data.Empresa.Interface;
using SistemaCRUD.API.Data.Estado;
using SistemaCRUD.API.Data.Estado.Interfaces;
using SistemaCRUD.API.Data.Produto;
using SistemaCRUD.API.Data.Produto.Interfaces;
using SistemaCRUD.API.Repositorio.Cidade;
using SistemaCRUD.API.Repositorio.Cidade.Interface;
using SistemaCRUD.API.Repositorio.Empresa;
using SistemaCRUD.API.Repositorio.Empresa.Interface;
using SistemaCRUD.API.Repositorio.Estado;
using SistemaCRUD.API.Repositorio.Estado.Interface;
using SistemaCRUD.API.Repositorio.Produto;
using SistemaCRUD.API.Repositorio.Produto.Interfaces;
using SistemaCRUD.API.Service.Cidade;
using SistemaCRUD.API.Service.Cidade.Interface;
using SistemaCRUD.API.Service.Empresa;
using SistemaCRUD.API.Service.Empresa.Interface;
using SistemaCRUD.API.Service.Estado;
using SistemaCRUD.API.Service.Estado.Interface;
using SistemaCRUD.API.Service.Produto;
using SistemaCRUD.API.Service.Produto.Interface;
using System.Data.SqlClient;
using System.Text.Json.Serialization;
#endregion
var builder = WebApplication.CreateBuilder(args);


#region Inje��o
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

#region Empresa
builder.Services.AddScoped<IEmpresa, EmpresaCommands>();
builder.Services.AddScoped<IRepositorioEmpresa, RepositorioEmpresa>();
builder.Services.AddScoped<IServiceEmpresa, ServiceEmpresa>();
#endregion

#region Produto
builder.Services.AddScoped<IProduto, ProdutoCommands>();
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<IServiceProduto, ServiceProduto>();
#endregion

#endregion

#region CORS
builder.Services.AddCors();
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

app.UseCors(c =>
{
    c.AllowAnyHeader();
    c.AllowAnyOrigin();
    c.AllowAnyMethod();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
