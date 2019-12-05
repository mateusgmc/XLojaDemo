using XLojaDemoWebApi.Interfaces;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(XLojaDemoDbContext context) :
            base(context)
        {
        }
    }
}
