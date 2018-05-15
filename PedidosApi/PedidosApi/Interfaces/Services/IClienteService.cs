using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Interfaces.Services
{
    public interface IClienteService
    {
        Cliente BuscarPorId(Guid Id);
        IEnumerable<Cliente> BuscarTodos();
        void Salvar(Cliente cliente);
        void Editar(Guid Id, Cliente cliente);
        void Excluir(Guid Id);
    }
}
