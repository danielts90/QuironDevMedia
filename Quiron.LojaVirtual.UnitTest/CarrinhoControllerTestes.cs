using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Web.Controllers;
using System.Linq;
using System.Web.Mvc;
using Quiron.LojaVirtual.Web.Models;

namespace Quiron.LojaVirtual.UnitTest
{
    [TestClass]
    public class CarrinhoControllerTestes
    {
        [TestMethod]
        public void AdicionarItemCarrinho()
        {
            Produto produto = new Produto
            {
                ProdutoId = 1,
                Nome = "Teste1"
            };

            Produto produto2 = new Produto
            {
                ProdutoId = 2,
                Nome = "Teste2"
            };

            Carrinho carrinho = new Carrinho();
            carrinho.AdicionarItem(produto, 3);

            CarrinhoController controller = new CarrinhoController();
            //controller.Adicionar(carrinho, 2, string.Empty);

            Assert.AreEqual(carrinho.ItensCarrinho.Count(), 1);
            Assert.AreEqual(carrinho.ItensCarrinho.ToArray()[0].Produto.ProdutoId, 1);
        }

        [TestMethod]
        public void Adiciono_Produto_Carrinho_Volta_Para_Categoria()
        {
            //Carrinho carrinho = new Carrinho();
            //CarrinhoController controller = new CarrinhoController();

            ////RedirectToRouteResult result = controller.Adicionar(carrinho, 2, "minhaUrl");

            //Assert.AreEqual(result.RouteValues["action"], "Index");
            //Assert.AreEqual(result.RouteValues["returnUrl"], "minhaUrl");

        }

        [TestMethod]
        public void Posso_Ver_Conteudo_Carrinho()
        {
            var carrinho = new Carrinho();
            var carrinhoController = new CarrinhoController();

            var resultado = (CarrinhoViewModel)carrinhoController.Index(carrinho, "minhaUrl").ViewData.Model;

            Assert.AreSame(resultado.Carrinho, carrinho);

            Assert.AreEqual(resultado.ReturnUrl, "minhaUrl");


        }
    }
}
