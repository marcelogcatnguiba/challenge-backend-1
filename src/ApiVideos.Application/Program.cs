using ApiVideos.Application.Configuration;
using ApiVideos.Application.Endpoint.All;
using ApiVideos.Application.Repository.Categoria;
using ApiVideos.Application.Repository.Videos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApiVideosContext>(x => x.UseSqlite("Data Source=DbVideos.db"));
builder.Services.CreateDatabase();

builder.Services.AddScoped<IRepository<VideosEntity>, VideosRepository>();
builder.Services.AddScoped<IRepository<CategoriaEntity>, CategoriaRepository>();

builder.Services.AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapEndpoins();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

await app.RunAsync();
