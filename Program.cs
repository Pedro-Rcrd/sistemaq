using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//INYECCION DE DEPENDENCIA
builder.Services.AddDbContext<QuchoochContext>(options => //CONSTRUYENDO UN OBJETO DE TIPO QUCHOOCHCONTEXT
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuchoochContext"));
});

//Contexco para generar el pedf
builder.Services.AddDbContext<QuchoochContext>();

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

IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/windows");


app.Run();

