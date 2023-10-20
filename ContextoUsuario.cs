using ejemploUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace ejemploUsuario
{
    public class ContextoUsuario : DbContext
    {
        public DbSet<Usuario> usuarios { get; set; }
        public ContextoUsuario(DbContextOptions<ContextoUsuario> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(p => {
                p.ToTable("users");
                p.HasKey(p=>p.IdUsuario);
                p.HasAlternateKey(p=>p.Email);
                p.Property(p => p.Name).IsRequired();
                p.Property(p => p.Password).IsRequired();
            });
        }
    }
}
