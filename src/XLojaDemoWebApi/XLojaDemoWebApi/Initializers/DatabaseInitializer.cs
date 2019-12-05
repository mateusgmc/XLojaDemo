using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Initializers
{
    public static class DatabaseInitializer
    {
        public static void Initialize(XLojaDemoDbContext dbContext)
        {
            dbContext.Database.EnsureCreated();
            if (!dbContext.Usuarios.Any())
            {
                dbContext.Usuarios.Add(new Usuario
                {
                    Nome = "Mateus Costa",
                    Cargo = "Operador de Caixa",
                    Foto = "menu_user.png"
                });
                dbContext.SaveChanges();
            }
        }
    }
}
