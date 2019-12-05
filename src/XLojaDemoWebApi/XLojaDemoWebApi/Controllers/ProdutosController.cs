using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using XLojaDemoWebApi.Interfaces;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutosController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpGet]
        public IEnumerable<Produto> GetAll()
        {
            return _produtoRepository.GetAll();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _produtoRepository.Delete(x => x.Id == id);
        }

        [HttpPost]
        public void Add(Produto produto)
        {
            _produtoRepository.Add(produto);
        }

        [HttpPut]
        public void AddOrUpdate(Produto produto)
        {
            _produtoRepository.AddOrUpdate(produto);
        }
    }
}