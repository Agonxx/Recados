using Microsoft.EntityFrameworkCore;
using Recados.API.Data;
using Shared.Dtos;
using Shared.Models;

namespace Recados.API.Repositorys
{
    public class RecadoRepository
    {
        private DataContext _database;

        public RecadoRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<List<RecadoDto>> BuscarTodosRecados()
        {
            var recados = await (from recado in _database.Recados
                                 select new RecadoDto
                                 {
                                     Id = recado.Id,
                                     UsuarioId = recado.UsuarioId,
                                     Titulo = recado.Titulo,
                                     Mensagem = recado.Mensagem
                                 }).ToListAsync();

            return recados;
        }
        public async Task<List<RecadoDto>> BuscarRecadosByUserId(int usuarioId)
        {
            var recados = await (from recado in _database.Recados
                                 where recado.UsuarioId == usuarioId
                                 select new RecadoDto
                                 {
                                     Id = recado.Id,
                                     UsuarioId = usuarioId,
                                     Titulo = recado.Titulo,
                                     Mensagem = recado.Mensagem
                                 }).ToListAsync();

            return recados;
        }

        public async Task<int> CadastrarRecado(RecadoDto recadoObj)
        {
            Recado novoRecado = new()
            {
                UsuarioId = recadoObj.UsuarioId,
                Titulo = recadoObj.Titulo,
                Mensagem = recadoObj.Mensagem
            };

            await _database.AddAsync(novoRecado);
            await _database.SaveChangesAsync();

            return novoRecado.Id;
        }
    }
}
