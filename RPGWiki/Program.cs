using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPGWiki.EndPoints;
using RPGWiki.Shared.Data.BD;
using RPGWiki_Console;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options => options.SerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddDbContext<RPGWikiContext>();
builder.Services.AddTransient<DAL<Jogador>>();
builder.Services.AddTransient<DAL<Personagem>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.AddEndPointsJogador();
app.AddPointsPersonagem();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();