using SistemaCRUD.MVC.Service.Cidade;
using SistemaCRUD.MVC.Service.Cidade.Interface;
using SistemaCRUD.MVC.Service.Empresa;
using SistemaCRUD.MVC.Service.Empresa.Interface;
using SistemaCRUD.MVC.Service.Estado;
using SistemaCRUD.MVC.Service.Estado.Interface;

var builder = WebApplication.CreateBuilder(args);

//Injeção de Depedencia
#region Injeção
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient("ApiCRUD", c =>{
    c.BaseAddress = new Uri(builder.Configuration["ApiSistemCRUD"]);
});
#region Estado
builder.Services.AddScoped<IServiceCidade, ServiceCidade>();
builder.Services.AddScoped<IServiceEstado, ServiceEstado>();
builder.Services.AddScoped<IServiceEmpresa, ServiceEmpresa>();
#endregion
#endregion

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
