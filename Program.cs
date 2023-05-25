using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using systemquchooch.Servicios.Contrato;
using systemquchooch.Servicios.Implementacion;


using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;


var builder = WebApplication.CreateBuilder(args);

// Registrar la implementación de UsuarioService en el contenedor de servicios
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
//INYECCION DE DEPENDENCIA
builder.Services.AddDbContext<QuchoochContext>(options => //CONSTRUYENDO UN OBJETO DE TIPO QUCHOOCHCONTEXT
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuchoochContext"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniaciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
    });

//Contexco para generar el pedf
builder.Services.AddDbContext<QuchoochContext>();
builder.Services.AddControllersWithViews(option =>
{
    option.Filters.Add(
        new ResponseCacheAttribute
        {
            NoStore= true,
            Location = ResponseCacheLocation.None,
        }
        );
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");


IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/windows");




app.Run();

