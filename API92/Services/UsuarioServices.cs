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

                //List<Usuario> response = await _context.Usuarios.Include(y=> y.Roles).ToListAsync();


                return new Response<List<Usuario>>(response, "Esta es la lista");


            } catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
   
        }

        public async Task<Response<Usuario>> GetById(int id)
        {
            try
            {
                Usuario? res = await _context.Usuarios.FirstOrDefaultAsync(user => user.PkUsuario == id);

                if (res == null)
                {
                    return new Response<Usuario>("Usuario no encontrado");
                }

                return new Response<Usuario>(res, "Usuario encontrado");

            }
            catch (Exception ex)
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

        //Hay que el Actualizar y acepte de esta forma del controller [HttpPut("{id}")]
        public async Task<Response<UsuariosResponse>> ActualizarUsuario(int id, UsuariosResponse request)
        {
            try
            {
                Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(user => user.PkUsuario == id);

                if (usuario == null)
                {
                    return new Response<UsuariosResponse>("Usuario no encontrado");
                }

                usuario.Nombre = request.Nombre;
                usuario.UserName = request.UserName;
                usuario.Password = request.Password;
                usuario.FkRol = request.FkRol;

                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(request, "Usuario actualizado");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }


        //Hay que el Eliminar y acepte de esta forma del controller [HttpDelete("{id}")]
        public async Task<Response<UsuariosResponse>> EliminarUsuario(int id)
        {
            try
            {
                Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(user => user.PkUsuario == id);

                if (usuario == null)
                {
                    return new Response<UsuariosResponse>("Usuario no encontrado");
                }

                _context.Usuarios.Remove(usuario);
                await _context.SaveChangesAsync();

                return new Response<UsuariosResponse>(null, "Usuario eliminado");
            }
            catch (Exception ex)
            {
                throw new Exception("Sucedió un error: " + ex.Message);
            }
        }



    }
}
