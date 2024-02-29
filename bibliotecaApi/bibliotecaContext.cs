using bibliotecaApi.Modelo;
using Microsoft.EntityFrameworkCore;

namespace bibliotecaApi
{
    public class bibliotecaContext:DbContext
    {
        public bibliotecaContext(DbContextOptions<bibliotecaContext> opciones)
  : base(opciones) { }

        public DbSet<Categoria> categoria => Set<Categoria>();
        public DbSet<Libro> libro=> Set<Libro>();
    }
}
