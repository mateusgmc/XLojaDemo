using Microsoft.EntityFrameworkCore;
using XLojaDemoWebApi.Configurations;

namespace XLojaDemoWebApi.Models
{
    public class XLojaDemoDbContext : DbContext
    {
        public XLojaDemoDbContext(DbContextOptions<XLojaDemoDbContext> options) :
            base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
        }
    }
}
