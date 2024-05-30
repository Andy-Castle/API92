using API92.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace API92.Services
{
    public class UsuarioServices: IUsuarioServices
    {
        private readonly ApplicationDBContext _context;
        public UsuarioServices(ApplicationDBContext context)
        {
            _context = context;
            
            
        }

        public async Task<Response<List<Usuario>>> GetUsuarios()
        {
            try
            {
                List<Usuario> response = await _context.Usuarios.ToListAsync();

                return new Response<List<Usuario>>(response, "Esta es la lista");


            } catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
   
        }

        public async Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request)
        {
            try
            {
                Usuario usuario = new Usuario()
                {
                    Nombre = request.Nombre,
                    UserName = request.UserName,
                    Password = request.Password,
                    FkRol = request.FkRol
                };

                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request, "Usuario creado");

            }catch(Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }


        }

        
    }
}
