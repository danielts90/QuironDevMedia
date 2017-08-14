using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class TesteCarrinhoCompras
    {
        [TestMethod]
        public void AdicionarItensAoCarrinho()
        {
            var produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            var produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            var carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 2);
            carrinho.AdicionarItem(produto2, 3);

            ItemCarrinho[] itens = carrinho.ItensCarrinho.ToArray();

            Assert.AreEqual(itens.Length, 2);
            Assert.AreEqual(itens[0].Produto, produto1);
            Assert.AreEqual(itens[1].Produto, produto2);
        }

        [TestMethod]
        public void AdiconarProdutoExistenteAoCarrinho()
        {
            var produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            var produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            var carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 10);

            ItemCarrinho[] resultado = carrinho.ItensCarrinho
                .OrderBy(c => c.Produto.ProdutoId).ToArray();

            Assert.AreEqual(resultado.Length, 2);
            Assert.AreEqual(resultado[0].Quantidade, 11);
        }

        [TestMethod]
        public void RemoverItensCarrinho()
        {
            var produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1"
            };

            var produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2"
            };

            var produto3 = new Produto()
            {
                ProdutoId = 3,
                Nome = "Teste 3"
            };

            var carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 3);
            carrinho.AdicionarItem(produto3, 5);
            carrinho.AdicionarItem(produto2, 1);

            carrinho.RemoverItem(produto2);

            Assert.AreEqual(carrinho.ItensCarrinho.Where(c => c.Produto.ProdutoId == 2).Count(), 0);
            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 2);
        }

        [TestMethod]
        public void CalcularValorTotal()
        {
            var produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            var produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2", 
                Preco = 50M
            };

            var carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 4);

            var resultado = carrinho.ObterValorTotal();

            Assert.AreEqual(resultado, 550M);
        }

        [TestMethod]
        public void TestaLimparItensCarrinho()
        {
            var produto1 = new Produto()
            {
                ProdutoId = 1,
                Nome = "Teste 1",
                Preco = 100M
            };

            var produto2 = new Produto()
            {
                ProdutoId = 2,
                Nome = "Teste 2",
                Preco = 50M
            };

            var carrinho = new Carrinho();

            carrinho.AdicionarItem(produto1, 1);
            carrinho.AdicionarItem(produto2, 1);
            carrinho.AdicionarItem(produto1, 4);

            carrinho.LimparCarrinho();

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 0);

        }
    }
}
