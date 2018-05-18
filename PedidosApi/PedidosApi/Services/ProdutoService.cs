using PedidosApi.Interfaces.Repository;
using PedidosApi.Interfaces.Services;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public Produto BuscarPorId(Guid Id)
        {
            return _produtoRepository.buscarPorId(Id);
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            return _produtoRepository.BuscarTodos();
        }

        public void Editar(Guid Id, Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid Id)
        {
            _produtoRepository.Excluir(Id);
        }

        public Produto Salvar(Produto entity)
        {
            return _produtoRepository.Salvar(entity);
        }
    }
}
