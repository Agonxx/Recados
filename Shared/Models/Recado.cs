using Microsoft.EntityFrameworkCore;
using Shared.Enums;

namespace Shared.Models
{
    public class Recado
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
    }

    public class RotasRecado
    {
        public const string BuscarRecadosByUserId = "BuscarRecadosByUserId";
        public const string BuscarTodosRecados = "BuscarTodosRecados";
        public const string CadastrarRecado = "CadastrarRecado";
    }

    public static class DBContextRecado
    {
        public static void SetarConfigRecado(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recado>(
                r =>
                {
                    r.HasOne<Usuario>()
                    .WithMany()
                    .HasForeignKey(x => x.UsuarioId)
                    .OnDelete(DeleteBehavior.NoAction);
                });
        }
    }
}
