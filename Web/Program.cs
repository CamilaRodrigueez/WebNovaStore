using Infraestructure.Core.Data;
using Microsoft.EntityFrameworkCore;
using Web.Handlers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


#region SQL SERVER Conecction
builder.Services.AddDbContext<DataContext>(opciones =>
{
    opciones.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStringSQLServer"));
});
#endregion

#region Dependency Injection
DependencyInyectionHandler.DependencyInyectionConfig(builder.Services);
#endregion

//#if DEBUG
//builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
//#endif
//Se agrega esta l�nea para los llamdos HTTP
builder.Services.AddHttpClient();
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
