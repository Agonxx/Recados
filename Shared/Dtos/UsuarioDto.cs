using Shared.Enums;

namespace Shared.Dtos
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public EGenero Genero { get; set; } = EGenero.Masculino;
    }
}
