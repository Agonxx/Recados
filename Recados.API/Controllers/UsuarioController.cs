using Microsoft.AspNetCore.Mvc;
using Recados.API.Repositorys;
using Shared.Dtos;
using Shared.Models;
using Shared.Utils;

namespace Recados.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        private readonly ILogger _logger;

        public UsuarioController(ILogger<UsuarioController> logger, UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _logger = logger;
        }

        [HttpPost(RotasUsuario.Cadastrar)]
        public async Task<IActionResult> Cadastrar([FromBody] UsuarioDto usuarioObj)
        {
            var novoUsuario = await _usuarioRepository.Cadastrar(usuarioObj);
            return Ok(novoUsuario is null ? "Não foi possivel cadastrar o usuário" : novoUsuario);
        }

        [HttpPost(RotasUsuario.Autenticar)]
        public async Task<IActionResult> Autenticar([FromBody] UsuarioDto usuarioObj)
        {
            var autenticado = await _usuarioRepository.Autenticar(usuarioObj);
            return Ok(autenticado ? "Login efetuado com sucesso" :"Login/Senha inválidos!");
        }
    }
}
