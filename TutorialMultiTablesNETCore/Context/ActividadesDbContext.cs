using Microsoft.EntityFrameworkCore;
using TutorialMultiTablesNETCore.Models;

namespace TutorialMultiTablesNETCore.Context
{
    public class ActividadesDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<Instructor> Instructores { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public ActividadesDbContext(DbContextOptions<ActividadesDbContext> options) : base(options)
        {

        }
    }
}
