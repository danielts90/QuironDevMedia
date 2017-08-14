using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio = new ProdutosRepositorio();
        // GET: Carrinho
        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            var produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            var produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        private Carrinho ObterCarrinho()
        {
            var carrinho = (Carrinho)Session["Carrinho"];

            if(carrinho == null)
            {
                carrinho = new Carrinho();
                Session["Carrinho"] = carrinho;
            }
            return carrinho;
        }

    }
}