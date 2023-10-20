using ejemploUsuario.Models;
using ejemploUsuario.Services;
using Microsoft.AspNetCore.Mvc;

namespace ejemploUsuario.Controllers
{

    [ApiController]
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        IUsuarioService usuarioService;
        public UsuarioController(IUsuarioService servicio)
        {
            usuarioService = servicio;
        }
        [HttpGet]
        [Route("[action]")]
        public IActionResult Conectar([FromServices] ContextoUsuario co)
        {
            co.Database.EnsureCreated();
            return Ok("Conectado a la base de datos");
        }
        [HttpGet]
        public IActionResult Get()
        {
            var valores = usuarioService.GetUsuarios();
            return Ok(valores);
        }
        [HttpPost]
        public IActionResult Post([FromBody] Usuario nuevoUsuario)
        {
            usuarioService.AddNewUsuario(nuevoUsuario);
            MensajeMostrar mensaje = new("Usuario agregado con exito");
            return Ok(mensaje);
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult Inicio([FromBody] UsuarioInicio ver)
        {
            var texto = usuarioService.InicioSecion(ver);
            return Ok(texto);
        }
    }
    public class MensajeMostrar
    {
        public string Mensaje { get; set; }
        public MensajeMostrar(string mensaje)
        {
            Mensaje = mensaje;
        }
    }
}


