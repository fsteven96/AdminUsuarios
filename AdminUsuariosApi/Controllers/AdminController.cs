using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AdminUsuariosApi.Models;
using AdminUsuariosApi.Data; 


namespace AdminUsuariosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("usuarios")]
        public async Task<IActionResult> GetUsuarios()
        {
            try
            {
                // Usamos Include para cargar las relaciones con Cargo y Departamento
                var usuarios = await _context.Users
                    .Include(u => u.Cargo) // Asumimos que User tiene una relación con Cargo
                    .Include(u => u.Departamento) // Asumimos que User tiene una relación con Departamento
                    .ToListAsync();

                // Si no se encuentra ningún usuario
                if (usuarios == null || !usuarios.Any())
                {
                    return NotFound("No se encontraron usuarios.");
                }

                // Devolver los usuarios con todos los campos, incluidas las relaciones
                return Ok(usuarios);
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolver un error genérico
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

         [HttpDelete("usuarios/{id}")]
        public async Task<IActionResult> EliminarUsuario(int id)
        {
     
            var usuario = await _context.Users.FindAsync(id);

      
            if (usuario == null)
            {
                return NotFound();
            }

      
            _context.Users.Remove(usuario);
            await _context.SaveChangesAsync();

        
            return NoContent(); // 204 No Content
        }

        // Crear usuario
        [HttpPost("usuarios")]
        public async Task<IActionResult> CrearUsuario([FromBody] User usuario)
        {
            _context.Users.Add(usuario);
            await _context.SaveChangesAsync();
            return Ok(usuario);
        }

        // Listar departamentos
        [HttpGet("departamentos")]
        public async Task<IActionResult> GetDepartamentos()
        {
            var deptos = await _context.Departamentos.ToListAsync();
            return Ok(deptos);
        }

        // Listar cargos
        [HttpGet("cargos")]
        public async Task<IActionResult> GetCargos()
        {
            var cargos = await _context.Cargos.ToListAsync();
            return Ok(cargos);
        }

       
        


        [HttpPut("usuarios/{id}")]
        public async Task<IActionResult> ActualizarUsuario(int id, [FromBody] User usuarioActualizado)
        {
            try
            {
                var usuarioExistente = await _context.Users.FindAsync(id);

                if (usuarioExistente == null)
                {
                    return NotFound(new { mensaje = "Usuario no encontrado" });
                }

                // Actualiza los campos del usuario existente
                usuarioExistente.Usuario = usuarioActualizado.Usuario;
                usuarioExistente.PrimerNombre = usuarioActualizado.PrimerNombre;
                usuarioExistente.SegundoNombre = usuarioActualizado.SegundoNombre;
                usuarioExistente.PrimerApellido = usuarioActualizado.PrimerApellido;
                usuarioExistente.SegundoApellido = usuarioActualizado.SegundoApellido;
                usuarioExistente.IdDepartamento = usuarioActualizado.IdDepartamento;
                usuarioExistente.IdCargo = usuarioActualizado.IdCargo;

                await _context.SaveChangesAsync();

                return Ok(usuarioExistente);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = "Error al actualizar el usuario", error = ex.Message });
            }
        }



    
    }

}

