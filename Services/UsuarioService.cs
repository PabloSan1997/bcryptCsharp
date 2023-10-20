using BCrypt.Net;
using ejemploUsuario.Models;

namespace ejemploUsuario.Services
{
    public class UsuarioService : IUsuarioService
    {
        ContextoUsuario context;
        public UsuarioService(ContextoUsuario cn)
        {
            context = cn;
        }
        public IEnumerable<Usuario> GetUsuarios()
        {
            return context.usuarios;
        }
        public async Task AddNewUsuario(Usuario nuevoUsuario)
        {
            nuevoUsuario.Password = BCrypt.Net.BCrypt.EnhancedHashPassword(nuevoUsuario.Password, 5);
            context.usuarios.Add(nuevoUsuario);
            await context.SaveChangesAsync();
        }
        public string InicioSecion(UsuarioInicio miUsuario)
        {
            var ver = context.usuarios.Count(p => p.Email == miUsuario.Email);
            if (ver == 0)
            {
                return "No tiene permiso para entrar";
            }
            var checar = context.usuarios.Where(p=>p.Email==miUsuario.Email).ToList();
            var conta = checar.ElementAt(0);
            var des = BCrypt.Net.BCrypt.EnhancedVerify(miUsuario.Password, conta.Password);

            if (des) return "Puede PAsar";
            return "No puede pasar";

        }
    }
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        Task AddNewUsuario(Usuario nuevoUsuario);
        string InicioSecion(UsuarioInicio miUsuario);

    }
    public class Respuesta
    {
        public string Usuario { get; set; }
        public bool Pasas { get; set; }
        public Respuesta(string usuario, bool pasas) {
            Usuario = usuario;
            Pasas = pasas;
        }
    }
}

