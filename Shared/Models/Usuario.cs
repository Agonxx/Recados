using Shared.Enums;

namespace Shared.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime CriadoEm{ get; set; } = DateTime.Now;
        public EGenero Genero { get; set; } = EGenero.Masculino;
    }

    public class RotasUsuario
    {
        public const string Cadastrar = "Cadastrar";
        public const string Autenticar = "Autenticar";
        public const string Teste = "Teste";
    }
}
