using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class ProdutosRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Produto> Produtos
        {
            get { return _context.Produtos; }
        }

        //Salvar Produto - Alterar Produto 
        public void Salvar(Produto produto)
        {
            //Salvar
            if(produto.ProdutoId == 0)
            {
                _context.Produtos.Add(produto);
            }
            //Editar
            else
            {
                var prod = _context.Produtos.Find(produto.ProdutoId);
                if(prod != null)
                {
                    prod.Categoria = produto.Categoria;
                    prod.Descricao = produto.Descricao;
                    prod.Nome = produto.Nome;
                    prod.Preco = produto.Preco;
                }
                
            }
            _context.SaveChanges();
        }

        public Produto Excluir(int produtoId)
        {
            var prod = _context.Produtos.Find(produtoId);
            if(prod != null)
            {
                _context.Produtos.Remove(prod);
                _context.SaveChanges();
            }
            return prod;
        }
    }
}
