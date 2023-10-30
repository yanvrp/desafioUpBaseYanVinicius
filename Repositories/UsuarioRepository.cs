using api_ead.Models;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace api_ead.Repositories
{
    public class UsuarioRepository
    {
        private readonly Context _context;
        public UsuarioRepository(Context contexto)
        {
            _context = contexto;
        }

        public Usuario Login(Usuario usuario)
        {
            return _context.tbUsuario.FirstOrDefault(t => t.userName == usuario.userName);
        }

        public string Cadastro(Usuario usuario)
        {
            var emailExistente =_context.tbUsuario.FirstOrDefault(t => t.email == usuario.email);
            var userExistente = _context.tbUsuario.FirstOrDefault(t => t.userName == usuario.userName);

            if (emailExistente != null && userExistente != null)
                return "User e Email já existentes!";
            else if (emailExistente != null)
                return "Email já cadastrado!";
            else if (userExistente != null)
                return "User já cadastrado!";
            else
                try
                {
                    _context.tbUsuario.Add(usuario);
                    _context.SaveChanges();
                }
                catch (MySqlException ex)
                {
                    return "Erro" + ex.Message;
                }

            return "Sucesso";
        }
    }
}
