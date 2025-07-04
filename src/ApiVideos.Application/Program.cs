using ApiVideos.Application.Configuration;
using ApiVideos.Application.Context;
using ApiVideos.Application.Endpoint.All;
using ApiVideos.Application.Entities;
using ApiVideos.Application.Repository.Interface.Base;
using ApiVideos.Application.Repository.Videos;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiVideosContext>(x => x.UseSqlite("Data Source=DbVideos.db"), ServiceLifetime.Singleton);
builder.Services.CreateDatabase();

builder.Services.AddScoped<IRepository<VideosEntity>, VideosRepository>();
var app = builder.Build();

app.MapEndpoins();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

await app.RunAsync();
