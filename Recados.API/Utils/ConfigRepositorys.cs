using Recados.API.Repositorys;

namespace Recados.API.Utils
{
    public static class ConfigRepositorys
    {
        public static void ConfigurarRepositorys(IServiceCollection services)
        {
            services.AddScoped<UsuarioRepository>();
            services.AddScoped<RecadoRepository>();
        }
    }
}
