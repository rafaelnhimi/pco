using PCOApi.Context;
using PCOApi.Entity;
using PCOApi.Repository;
using System;
using System.Threading.Tasks;

namespace PCOApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly UsuarioContext _context;

        public UsuarioService(IUsuarioRepository usuarioRepository, UsuarioContext context)
        {
            _usuarioRepository = usuarioRepository;
            _context = context;
        }

        public async Task<bool> AutenticarUsuario(string userName)
        {
            try
            {
                var resposta = await _usuarioRepository.AutenticarUsuario(userName);
                return resposta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public async Task<bool> RegistrarUsuario(string userName)
        {
            var usuario = new Usuario(userName);

            try
            {
                await _usuarioRepository.AddAsync(usuario);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }

        }
    }
}
