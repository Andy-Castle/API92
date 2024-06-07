using API92.Context;
using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace API92.Services
{
    public class AutorServices : IAutorServices
    {

        private readonly ApplicationDBContext _context;

        public AutorServices(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> Response = new List<Autor>();

                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new { }, commandType: CommandType.StoredProcedure);

                Response = result.ToList();


                return new Response<List<Autor>>(Response);


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor i)
        {
            try
            {

                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);


            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Editar(Autor i)
        {
            try
            {

                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spEditarAutor", new { i.PkAutor, i.Nombre, i.Nacionalidad }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Eliminar(Autor i)
        {
            try
            {

                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spEliminarAutor", new { i.PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);

            }
        }

        public async Task<Response<Autor>> GetById(Autor i)
        {
            try
            {
                Autor result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spBuscarAutorId", new { i.PkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Sucedio un error" + ex.Message);
            }
        }
    }
}               
