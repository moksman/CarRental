using CarRental.Application.Configuration;
using CarRental.Core;
using CarRental.Infrastructure;
using CarRental.Server.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.FluentUI.AspNetCore.Components;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddControllers();

// Add services to the container.
builder.Services
    .AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services
    .AddMemoryCache();
    //.AddResponseCompression(o => { o.EnableForHttps = true; });

//Configure CarRental application specific features
builder.Services
    .ConfigureDomainServices()
    .ConfigureApplicationLayer()
    .ConfigurePersistance(builder.Configuration)
    .AddData();


builder.Services.AddAuthorization();
builder.Services.AddIdentityApiEndpoints<IdentityUser>();

builder.Services.AddFluentUIComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app
    //.UseResponseCompression() // * Compression, read to mitigate security issues BREACH, CRIME https://www.milanjovanovic.tech/blog/response-compression-in-
    .UseHttpsRedirection()
    .UseStaticFiles()
    .UseAntiforgery();

app.MapIdentityApi<IdentityUser>();

app
    .MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode();

app.MapControllers();

app.Run();
