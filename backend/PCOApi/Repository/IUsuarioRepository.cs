using PCOApi.Entity;
using PCOApi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PCOApi.Repository
{
    public interface IUsuarioRepository : IRepositoryUsuarioContext<Usuario>
    {
        Task<bool> AutenticarUsuario(string userName);
    }
}
