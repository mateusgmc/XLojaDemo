using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using XLojaDemoWebApi.Interfaces;
using XLojaDemoWebApi.Models;

namespace XLojaDemoWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }
    }
}