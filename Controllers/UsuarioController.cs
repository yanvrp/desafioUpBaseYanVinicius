using api_ead.Models;
using api_ead.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api_ead.Controllers
{
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly UsuarioRepository _usuarioRepository;
        public UsuarioController(Context context)
        {
            _usuarioRepository = new UsuarioRepository(context);

        }


        [HttpGet("login")]
        public async Task<ActionResult<Usuario>> Login([FromBody] Usuario usuario)
        {
            if (User == null)
            {
                return BadRequest("Dados de usuário inválidos.");
            }

            //var user = await _context.tbUsuario.FirstOrDefaultAsync(u => u.email == usuario.email);
            var user = _usuarioRepository.Login(usuario);


            if (user == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            if (usuario.senha != user.senha)
            {
                return Unauthorized("Senha incorreta.");
            }

            return usuario;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<string>> Cadastro([FromBody]Usuario usuarioNovo)
        {
            if (usuarioNovo == null)
            {
                return BadRequest("Dados de cadastro inválidos.");
            }

            var result = _usuarioRepository.Cadastro(usuarioNovo);

            return result.ToString();
        }

    }
}
