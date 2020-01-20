using Microsoft.EntityFrameworkCore;
using PCOApi.Entity;

namespace PCOApi.Context
{
    public class UsuarioContext : DbContext
    {
        public UsuarioContext(DbContextOptions<UsuarioContext> options)
            : base(options)
        { }

        public DbSet<Usuario> Usuario { get; set; }
    }
}
