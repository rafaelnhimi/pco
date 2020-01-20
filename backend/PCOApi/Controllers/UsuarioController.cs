using Microsoft.AspNetCore.Mvc;
using PCOApi.Models;
using PCOApi.Services;
using System.Threading.Tasks;

namespace PCOApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Autenticar(LoginModel model)
        {
            var resposta = await _usuarioService.AutenticarUsuario(model.UserName);

            return Ok(resposta);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(string userName)
        {
            var resposta = await _usuarioService.RegistrarUsuario(userName);

            return Ok(resposta);
        }
    }
}
