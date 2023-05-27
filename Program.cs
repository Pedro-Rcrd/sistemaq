using Microsoft.EntityFrameworkCore;
using systemquchooch.Models;

using systemquchooch.Servicios.Contrato;
using systemquchooch.Servicios.Implementacion;

//AÑADIR REFERENCIAS PARA TRABAJAR CON COOKIES
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//INYECCION DE DEPENDENCIA
builder.Services.AddDbContext<QuchoochContext>(options => //CONSTRUYENDO UN OBJETO DE TIPO QUCHOOCHCONTEXT
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuchoochContext"));
});

//login
//Esto permite usar los metodos creados dentro de cualquier controlador del proyecto
builder.Services.AddScoped<IUsuarioService, UsuarioService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Inicio/IniciarSesion";
        options.ExpireTimeSpan = TimeSpan.FromMinutes(20);

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

//Habilitar la utenticacion
app.UseAuthorization();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    pattern: "{controller=Inicio}/{action=IniciarSesion}/{id?}");


IWebHostEnvironment env = app.Environment;
Rotativa.AspNetCore.RotativaConfiguration.Setup(env.WebRootPath, "../Rotativa/windows");




app.Run();

