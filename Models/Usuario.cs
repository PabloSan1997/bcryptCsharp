

namespace ejemploUsuario.Models
{
    public class Usuario
    {
        public string Name { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
