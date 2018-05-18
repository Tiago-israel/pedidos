using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Interfaces.Services
{
    public interface IBaseService<T>
    {
        T BuscarPorId(Guid Id);
        IEnumerable<T> BuscarTodos();
        T Salvar(T entity);
        void Editar(Guid Id, T entity);
        void Excluir(Guid Id);
    }
}
