using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PedidosApi.Models;

namespace PedidosApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly DataContext _dataContext;
        public ValuesController(DataContext dataContext) {
            _dataContext = dataContext;
        }

        // GET api/values
        //[HttpGet]
        //public List<Pedido> Get()
        //{
        //    var pedidos = _dataContext.Pedidos.ToList();
        //    pedidos.ForEach(p =>
        //    {
        //        p.Cliente = _dataContext.Clientes.Where(c => c.Id == p.IdCliente).FirstOrDefault();
        //    });
        //    return pedidos;
        //}

        [HttpGet]
        public IEnumerable<Cliente> Get()
        {
            return _dataContext.Clientes.Include(c => c.Pedidos);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Pedido value)
        {
            _dataContext.Pedidos.Update(value);
            _dataContext.SaveChanges();
            _dataContext.Dispose();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
