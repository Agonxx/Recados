using Microsoft.AspNetCore.Mvc;
using Recados.API.Repositorys;
using Shared.Dtos;
using Shared.Models;
using Shared.Utils;

namespace Recados.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecadoController : ControllerBase
    {
        private readonly RecadoRepository _recadoRepository;
        private readonly ILogger _logger;

        public RecadoController(ILogger<RecadoController> logger, RecadoRepository recadoRepository)
        {
            _recadoRepository = recadoRepository;
            _logger = logger;
        }

        [HttpGet(RotasRecado.BuscarTodosRecados)]
        public async Task<IActionResult> BuscarTodosRecados()
        {
            var recados = await _recadoRepository.BuscarTodosRecados();
            return Ok(recados);
        }
        
        [HttpGet(RotasRecado.BuscarRecadosByUserId)]
        public async Task<IActionResult> BuscarRecadosByUserId([FromQuery] int usuarioId)
        {
            var recados = await _recadoRepository.BuscarRecadosByUserId(usuarioId);
            return Ok(recados);
        }

        [HttpPost(RotasRecado.CadastrarRecado)]
        public async Task<IActionResult> CadastrarRecado([FromBody] RecadoDto recadoObj)
        {
            var novoRecadoId = await _recadoRepository.CadastrarRecado(recadoObj);

            return Ok(novoRecadoId > 0 ? "Novo recado adicionado com sucesso" : "Recado não registrado");
        }
    }
}
