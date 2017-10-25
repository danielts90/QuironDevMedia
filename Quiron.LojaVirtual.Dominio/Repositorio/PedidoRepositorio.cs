using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class PedidoRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public IEnumerable<Pedido> ObterPedidos(string clienteId)
        {
            return _context.Pedidos.Where(p => p.ClienteId == clienteId)
                .Include(p => p.ProdutoPedido)
                .Include(p => p.ProdutoPedido.Select(pp => pp.Produto));
        }

        public Pedido ObterPedido(int id)
        {
            return _context.Pedidos.Where(p => p.Id == id)
                .Include(p => p.ProdutoPedido).FirstOrDefault();
        }

        public IEnumerable<QuironProduto> ObterProdutosPedido(int id)
        {
            return _context.Pedidos.Find(id).ProdutoPedido.Select(p => p.Produto);
        }

        public Pedido SalvarPedido(Pedido pedido)
        {
            var pedidoReturn = _context.Pedidos.Add(pedido);
            _context.SaveChanges();

            return pedidoReturn;
        }

        public void RemoverPedido(Pedido pedido)
        {
            _context.Pedidos.Remove(pedido);
            _context.SaveChanges();
        }
    }
}
