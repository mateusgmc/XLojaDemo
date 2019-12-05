using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Configurations
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Login).HasMaxLength(200);
            builder.Property(u => u.Senha).HasMaxLength(200);
            builder.Property(u => u.Cargo).HasMaxLength(100);
        }
    }
}
