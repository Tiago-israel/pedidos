using PedidosApi.Interfaces.Repository;
using PedidosApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PedidosApi.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly DataContext _dataContext;

        public ProdutoRepository(DataContext dataContext) {
            _dataContext = dataContext;
        }

        public Produto buscarPorId(Guid id)
        {
            var produto = _dataContext.Produtos.FirstOrDefault(x => x.Id == id);
            return produto;
        }

        public IEnumerable<Produto> BuscarTodos()
        {
            var produtos = _dataContext.Produtos.ToList();
            return produtos;
        }

        public void Editar(Guid id, Produto entity)
        {
            throw new NotImplementedException();
        }

        public void Excluir(Guid id)
        {
            var produto = this.buscarPorId(id);
            _dataContext.Produtos.Remove(produto);
            _dataContext.SaveChanges();
        }

        public Produto Salvar(Produto entity)
        {
            try
            {
                _dataContext.Produtos.Add(entity);
                _dataContext.SaveChanges();
                entity = this.buscarPorId(entity.Id);
                return entity;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
