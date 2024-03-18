using Microsoft.EntityFrameworkCore;
using Shared.Enums;
using Shared.Models;

namespace Recados.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Recado> Recados { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SetarConfigRecado();
            modelBuilder.Seed();
        }
    }

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Usuario>().HasData(new Usuario[]
            {
                new Usuario {
                    Id = 1,
                    Nome = "Rafael",
                    Email ="Rafael@gmail.com",
                    Genero = EGenero.Masculino
                },
                new Usuario
                {
                    Id = 2,
                    Nome = "Fernando",
                    Email ="Fernando@gmail.com",
                    Genero = EGenero.Masculino
                }
            });

            modelBuilder.Entity<Recado>().HasData(new Recado[]
            {
                new Recado {
                    Id = 1,
                    UsuarioId = 1,
                    Titulo = "Título Recado 1",
                    Mensagem = "Mensagem Recado 1"
                },
                new Recado
                {
                    Id = 2,
                    UsuarioId = 1,
                    Titulo = "Título Recado 2",
                    Mensagem = "Mensagem Recado 2"
                },
                 new Recado {
                    Id = 3,
                    UsuarioId = 1,
                    Titulo = "Título Recado 3",
                    Mensagem = "Mensagem Recado 3"
                },
                new Recado
                {
                    Id = 4,
                    UsuarioId = 2,
                    Titulo = "Título Recado 4",
                    Mensagem = "Mensagem Recado 4"
                }
            });
        }
    }
}
