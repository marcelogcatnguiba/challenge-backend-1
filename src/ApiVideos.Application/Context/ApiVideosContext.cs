namespace ApiVideos.Application.Context;

public class ApiVideosContext(DbContextOptions<ApiVideosContext> options) : DbContext(options)
{
    public DbSet<VideosEntity> Videos { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideosEntity>()
            .HasOne(x => x.Categoria)
            .WithMany(x => x.Videos);

        modelBuilder.Entity<CategoriaEntity>()
            .HasData(
                new CategoriaEntity
                {
                    Id = 1,
                    Titulo = "Terror",
                    Cor = "Azul"
                },
                new CategoriaEntity
                {
                    Id = 2,
                    Titulo = "Susto",
                    Cor = "Vermelho"
                }
            );

        modelBuilder.Entity<VideosEntity>()
            .HasData(
                new VideosEntity
                {
                    Id = 1,
                    Titulo = "Madrugada dos Mortos",
                    Descricao = "Madrugada com gente morta",
                    Url = "http://madrugadadosmortos.com.br",

                    CategoriaId = 1
                },
                new VideosEntity
                {
                    Id = 2,
                    Titulo = "A volta dos que nao foram",
                    Descricao = "Parecem que foi mais nao voltaram",
                    Url = "http://fuievoltei.com.br",

                    CategoriaId = 2
                }
            );
    }
}
