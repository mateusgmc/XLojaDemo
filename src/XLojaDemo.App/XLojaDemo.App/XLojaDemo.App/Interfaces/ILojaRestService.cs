using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;
using XLojaDemo.App.Models;

namespace XLojaDemo.App.Interfaces
{
    public interface ILojaRestService
    {
        [Get("/XLojaDemoWebApi/api/produtos")]
        Task<IEnumerable<Produto>> GetProdutosAsync();

        [Delete("/XLojaDemoWebApi/api/produtos/{id}")]
        Task DeleteProdutoAsync(int id);

        [Post("/XLojaDemoWebApi/api/produtos")]
        Task AddProdutoAsync([Body] Produto produto);

        [Put("/XLojaDemoWebApi/api/produtos")]
        Task AddOrUpdateProdutoAsync([Body] Produto produto);

        [Get("/XLojaDemoWebApi/api/usuarios")]
        Task<IEnumerable<Usuario>> GetUsuariosAsync();
    }
}
