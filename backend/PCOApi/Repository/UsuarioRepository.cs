using Microsoft.EntityFrameworkCore;
using PCOApi.Context;
using PCOApi.Entity;
using PCOApi.Utils;
using System.Threading.Tasks;

namespace PCOApi.Repository
{
    public class UsuarioRepository : RepositoryUsuarioContext<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(UsuarioContext context) : base(context)
        {

        }

        public async Task<bool> AutenticarUsuario(string login)
        {
            return await _context.Usuario.AnyAsync(p => p.Login.ToLower() == login.ToLower());
        }
    }
}
