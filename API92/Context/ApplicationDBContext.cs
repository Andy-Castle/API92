using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace API92.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options) { }


        public DbSet<Usuario> Usuarios {  get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Insertar en la tabla usuario
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario
                {
                    PkUsuario = 1,
                    Nombre = "Andy",
                    UserName = "Masquerade",
                    Password = "12345",
                    FkRol = 1
                });

            //Insertar en la tabla rol
            modelBuilder.Entity<Rol>().HasData(
                new Rol
                {
                    PkRol = 1,
                    Nombre = "sa"
                });
        }


        //ASP .net core web api
        //Esto se ejecuta en la consola de nuggets
        //add-migration Example
        //update-database
        //Remove-Migration
        //Esto de abajo son los nuggets
        //entity.core
        //sqlserver
        //tools
        //En Solución hay que agregar Nuevo Proyecto llamado Domain


    }
}
