using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PedidosApi.Interfaces;
using PedidosApi.Interfaces.Services;
using PedidosApi.Models;
using PedidosApi.Repository;

namespace PedidosApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Clientes")]
    public class ClientesController : Controller
    {
        private readonly IHostingEnvironment _environment;
        private readonly IClienteService _clienteService;

        public ClientesController(IClienteService clienteService, IHostingEnvironment environment)
        {
            _environment = environment;
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public IActionResult buscarPorId(Guid Id)
        {
            var cliente = _clienteService.BuscarPorId(Id);
            return Ok(cliente);
        }

        [HttpGet()]
        public IActionResult buscarTodos() {
            var clientes = _clienteService.BuscarTodos();
            return Ok(clientes);
        }

        [HttpPost]
        public IActionResult salvar([FromBody]Cliente cliente)
        {
            var clienteDB = _clienteService.Salvar(cliente);
            return Ok(clienteDB);
        }

        [HttpPut("{id}")]
        public IActionResult Editar(Guid Id, [FromBody]Cliente cliente) {
            _clienteService.Editar(Id, cliente);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Excluir(Guid Id)
        {
            _clienteService.Excluir(Id);
            return Ok();
        }

        [HttpPost]
        [Route("upload/{id}")]
        public IActionResult UploadFoto(IFormFile file, Guid id)
        {
            var uploads = Path.Combine(_environment.WebRootPath, "uploads");
            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                {
                    file.CopyTo(fileStream);
                    var cliente = _clienteService.BuscarPorId(id);
                    cliente.Foto = file.FileName;
                    _clienteService.Editar(cliente.Id,cliente);
                    return Ok();
                }
            }
            return BadRequest();
        }

        [HttpGet()]
        [Route("download/{fileName}")]
        public IActionResult Download(String fileName) {
            if (fileName.Trim() != null) {
                var caminho = Path.Combine(_environment.WebRootPath+"\\uploads\\", fileName);
                var memory = new MemoryStream();
                using (var stream = new FileStream(caminho, FileMode.Open)) {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(caminho), Path.GetFileName(caminho));
            }
            return null;
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"}
            };
        }

    }
}