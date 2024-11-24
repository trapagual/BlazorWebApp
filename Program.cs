using BlazorWebApp.Components;
using BlazorWebApp.Repositorios;
using BlazorWebApp.Repositorios.Interfaces;


var builder = WebApplication.CreateBuilder(args);

/*
 NIVELES DE LOGGING
 ==================
 TRACE: Muy detallado eventos técnicos. Se usa para diagnóstico detallado. No se usa en Producción.
 DEBUG: Como TRACE, algo menos detallado. Para depuración. No en Producción
    ej: logger.LogDebug("Información de depuración");
 INFORMATION: flujo general de la app, eventos de inicio, cierre, y otros procesos importantes
 WARNING: situación inesperada o algo que puede provocar problemas. Merece atención
 ERROR: fallo en la aplicación o evento que requiere atención.
 CRITICAL: situaciones críticas que requieren atención inmediata.
*/ 

/*
 *  ENTORNOS
 *  ========
 *  DE MENOS A MÁS (el de abajo sobre escribe al de arriba)
 *  appsettings.json  <-- PRO
 *  appsettings.<entorno>.json <-- ENTORNO (según launchSettings.json)
 *  App secrets (secrets.json) -- Solo en modo desarrollo (Development) 
 *      Ruta: %APPDATA%\Microsoft\UserSecrets
 *  Variables de entorno
 *  Línea de comandos
 *  --FALTAN COSAS AQUÍ--
*/

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// registro de un servicio de ejemplo como Singleton
builder.Services.AddSingleton<IMiServicio, MiServicio>();

// registro de un servicio de ejemplo como Scoped
// builder.Services.AddScoped<IOtherService, OtherService>;

// OJO si tenemos que registrar servicios como en este ejemplo
// el registro debe ir ANTES de este .Build()
var app = builder.Build();






// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
