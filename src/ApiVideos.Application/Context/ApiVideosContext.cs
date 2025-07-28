using ApiVideos.Application.Entities.Usuario;

namespace ApiVideos.Application.Context;

public class ApiVideosContext(DbContextOptions<ApiVideosContext> options) : DbContext(options)
{
    public DbSet<VideoEntity> Videos { get; set; }
    public DbSet<CategoriaEntity> Categorias { get; set; }
    public DbSet<UsuarioEntity> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<VideoEntity>()
            .HasOne(x => x.Categoria)
            .WithMany(x => x.Videos)
            .HasForeignKey(x => x.CategoriaId);

        modelBuilder.Entity<VideoEntity>()
            .Property(x => x.CategoriaId)
            .HasDefaultValue(1L);

        modelBuilder.Entity<CategoriaEntity>()
            .HasData(
                new CategoriaEntity
                {
                    Id = 1,
                    Titulo = "Livre",
                    Cor = "Azul"
                },
                new CategoriaEntity
                {
                    Id = 2,
                    Titulo = "Terror",
                    Cor = "Vermelho"
                }
            );

        modelBuilder.Entity<VideoEntity>()
            .HasData(
                new VideoEntity
                {
                    Id = 1,
                    Titulo = "Madrugada dos Mortos",
                    Descricao = "Madrugada com gente morta",
                    Url = "http://madrugadadosmortos.com.br",

                    CategoriaId = 1
                },
                new VideoEntity
                {
                    Id = 2,
                    Titulo = "A volta dos que nao foram",
                    Descricao = "Parecem que foi mais nao voltaram",
                    Url = "http://fuievoltei.com.br",

                    CategoriaId = 2
                }
            );

        modelBuilder.Entity<UsuarioEntity>()
            .HasData(
                new UsuarioEntity { Id = 1, Email = "admin@admin.com", Senha = "admin" }
            );
    }
}
