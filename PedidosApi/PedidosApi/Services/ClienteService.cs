using PedidosApi.Interfaces;
using PedidosApi.Interfaces.Services;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public Cliente Salvar(Cliente cliente) {
            return _clienteRepository.Salvar(cliente);
        }

        public void Editar(Guid Id,Cliente cliente)
        {
            _clienteRepository.Editar(Id,cliente);
        }

        public IEnumerable<Cliente> BuscarTodos() {
            return _clienteRepository.BuscarTodos();
        }

        public Cliente BuscarPorId(Guid Id)
        {
            return _clienteRepository.buscarPorId(Id);
        }

        public void Excluir(Guid Id) {
            _clienteRepository.Excluir(Id);
        }

       
    }
}
