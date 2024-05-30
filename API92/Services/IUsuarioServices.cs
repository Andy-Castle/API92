using Domain.Entities;

namespace API92.Services
{
    public interface IUsuarioServices
    {

        public Task<Response<List<Usuario>>> GetUsuarios();

        public Task<Response<UsuariosResponse>> CrearUsuario(UsuariosResponse request);

    }
}
