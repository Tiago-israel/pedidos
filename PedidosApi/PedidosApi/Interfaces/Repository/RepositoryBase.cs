using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Interfaces
{
    public interface RepositoryBase<T> where T : Modelo 
    {
         T Salvar(T entity);
         void Editar(Guid id, T entity);
         void Excluir(Guid id);
         IEnumerable<T> BuscarTodos();
         T buscarPorId(Guid id);
    }
}
