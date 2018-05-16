using Microsoft.EntityFrameworkCore;
using PedidosApi.Interfaces;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly  DataContext _dataContext;
        
        public ClienteRepository(DataContext dataContext)
        {
           _dataContext = dataContext;
        }
        
        public Cliente buscarPorId(Guid id)
        {
           return _dataContext.Clientes.FirstOrDefault(c => c.Id == id);
        }

        public  IEnumerable<Cliente> BuscarTodos()
        {
            return _dataContext.Clientes.Include(c => c.Pedidos);
        }

        public  void Editar(Guid id, Cliente entity)
        {
            _dataContext.Clientes.Update(entity);
            _dataContext.SaveChanges();
        }

        public  void Excluir(Guid id)
        {
            var clienteDb = this.buscarPorId(id);
            if (clienteDb != null) {
                _dataContext.Clientes.Remove(clienteDb);
                _dataContext.SaveChanges();
            }
        }

        public  Cliente Salvar(Cliente entity)
        {
            try
            {
                _dataContext.Clientes.Add(entity);
                _dataContext.SaveChanges();
                return entity;
            }
            catch (Exception e) {
                throw new Exception();
            }
           
        }
    }
}
