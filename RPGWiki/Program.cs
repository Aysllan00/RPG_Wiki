using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPGWiki.EndPoints;
using RPGWiki.Shared.Data.BD;
using RPGWiki.Shared.Data.Models;
using RPGWiki.Shared.Models;
using RPGWiki_Console;
using System.Text.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddIdentityApiEndpoints<AccessUser>()
                .AddEntityFrameworkStores<RPGWikiContext>();

builder.Services.AddAuthorization();

builder.Services.AddDbContext<RPGWikiContext>();
builder.Services.AddTransient<DAL<Jogador>>();
builder.Services.AddTransient<DAL<Personagem>>(); 
builder.Services.AddTransient<DAL<Missao>>();
builder.Services.AddTransient<DAL<Equipamento>>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseAuthorization();

app.AddEndPointsJogador();
app.AddPointsPersonagem();
app.AddEndPointsMissao();
app.AddEndPointsEquipamento();

app.MapGroup("auth").MapIdentityApi<AccessUser>().WithTags("Authorization");

app.MapPost("auth/logout", async ([FromServices] SignInManager<AccessUser> signInManager) =>{

    await signInManager.SignOutAsync();
    return Results.Ok();
}).RequireAuthorization().WithTags("Authorization");

app.UseSwagger();
app.UseSwaggerUI();
app.Run();