using System.Threading.Tasks;

namespace PCOApi.Services
{
    public interface IUsuarioService
    {
        Task<bool> AutenticarUsuario(string userName);
        Task<bool> RegistrarUsuario(string userName);
    }
}
