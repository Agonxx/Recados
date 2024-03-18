using Microsoft.EntityFrameworkCore;
using Recados.API.Data;
using Shared.Dtos;
using Shared.Models;
using Shared.Utils;

namespace Recados.API.Repositorys
{
    public class UsuarioRepository
    {
        private DataContext _database;

        public UsuarioRepository(DataContext context)
        {
            _database = context;
        }

        public async Task<Usuario> Cadastrar(UsuarioDto usuarioObj)
        {
            var listaEmails = await _database.Usuarios.Select(w => w.Email).ToListAsync();

            if (listaEmails.Any(email => MetodosString.Compara(email, usuarioObj.Email, true)))
                return null;

            Usuario novoUsuario = new()
            {
                Nome = usuarioObj.Nome,
                Email = usuarioObj.Email,
                Genero = usuarioObj.Genero,
                Senha = usuarioObj.Senha,
                CriadoEm = DateTime.Now,
            };

            await _database.Usuarios.AddAsync(novoUsuario);
            await _database.SaveChangesAsync();

            return novoUsuario;
        }

        public async Task<bool> Autenticar(UsuarioDto usuarioObj)
        {
            var usuarioDB = await _database.Usuarios.Where(w => w.Email == usuarioObj.Email).FirstOrDefaultAsync();
            return usuarioDB != null && usuarioDB.Senha == usuarioObj.Senha;
        }
    }
}
