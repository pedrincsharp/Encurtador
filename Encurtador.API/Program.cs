using Encurtador.Application.Services;
using Encurtador.Application.Services.Interfaces;
using Encurtador.Infra.Database;
using Encurtador.Infra.Repositories;
using Encurtador.Infra.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services
    .AddScoped<ISiteRepository, SiteRepository>()
    .AddScoped<ISiteService, SiteService>()
    .AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("Teste"));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "Doc"));
}

app.UseHttpsRedirection();

app.MapGet("/{shortCode}", async (
    string shortCode,
    ISiteService siteService
) =>
{
    var site = await siteService.GetSite(shortCode);

    if (site == null)
        return Results.NotFound();

    var url = site.UrlOrigin;

    if (!url.StartsWith("http://") && !url.StartsWith("https://"))
        url = $"https://{url}";

    return Results.Redirect(url, permanent: true);
});

app.MapPost("/api/sites", async (
    string url,
    ISiteService siteService
) =>
{
    var site = await siteService.CreateSite(url);

    if (site == null)
        return Results.BadRequest();

    return Results.Created("", site);
});

app.MapDelete("/api/sites/{shortCode}", async (
    string shortCode,
    ISiteService siteService
) =>
{
    await siteService.DeleteSite(shortCode);
    return Results.Ok();
});

app.MapGet("/api/sites", async (
    ISiteService siteService
) =>
{
    var sites = await siteService.GetAll();
    return Results.Ok(sites);
});

app.Run();
