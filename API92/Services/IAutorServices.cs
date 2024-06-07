using Domain.Entities;

namespace API92.Services
{
    public interface IAutorServices
    {
        public Task<Response<List<Autor>>> GetAutores();

        public Task<Response<Autor>> GetById(Autor i);

        public Task<Response<Autor>> Crear(Autor i);

        public Task<Response<Autor>> Editar(Autor i);

        public Task<Response<Autor>> Eliminar(Autor i);


    }
}
