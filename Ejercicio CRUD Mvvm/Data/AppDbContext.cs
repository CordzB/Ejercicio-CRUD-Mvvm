using Microsoft.EntityFrameworkCore;
using Ejercicio_CRUD_Mvvm.Models;

namespace Ejercicio_CRUD_Mvvm.Data
{
    public class AppDbContext : DbContext
    {
        private readonly string _databasePath;

        public AppDbContext(string databasePath)
        {
            _databasePath = databasePath;
        }

        public DbSet<Proveedor> Proveedores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_databasePath}");
        }
    }
}
