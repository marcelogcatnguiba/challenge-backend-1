namespace ApiVideos.Application.Context;

public class ApiVideosContext(DbContextOptions<ApiVideosContext> options) : DbContext(options)
{
    public DbSet<VideosEntity> Videos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideosEntity>()
            .HasData(
                new VideosEntity
                {
                    Id = 1,
                    Titulo = "Madrugada dos Mortos",
                    Descricao = "Madrugada com gente morta",
                    Url = "http://madrugadadosmortos.com.br" 
                },
                new VideosEntity
                {
                    Id = 2,
                    Titulo = "A volta dos que nao foram",
                    Descricao = "Parecem que foi mais nao voltaram",
                    Url = "http://fuievoltei.com.br"
                }
            );
    }
}
