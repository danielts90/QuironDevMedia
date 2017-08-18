using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Areas.Administrativo.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutosRepositorio _repositorio = new ProdutosRepositorio();
        
        public ActionResult Index()
        {
            var produtos = _repositorio.Produtos;
            return View(produtos);
        }

        public ViewResult Alterar(int produtoId)
        {
            var produto = _repositorio.Produtos.FirstOrDefault(p => p.ProdutoId == produtoId);
            return View(produto);
        }

        [HttpPost]
        public ActionResult Alterar(Produto produto)
        {
            if(ModelState.IsValid)
            {
                _repositorio.Salvar(produto);
                TempData["mensagem"] = string.Format("{0} o produto foi salvo com sucesso", produto.Nome);
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        public ViewResult NovoProduto()
        {
            return View("Alterar", new Produto());
        }

        //[HttpPost]
        //public ActionResult Excluir(int produtoId)
        //{
        //    var prod = _repositorio.Excluir(produtoId);
        //    if(prod != null)
        //    {
        //        TempData["mensagem"] = string.Format("{0} excluído com sucesso.", prod.Nome);
        //    }
        //    return RedirectToAction("Index");
        //}

        [HttpPost]
        public JsonResult Excluir(int produtoId)
        {
            string mensagem = string.Empty;
            var prod = _repositorio.Excluir(produtoId);
            if (prod != null)
            {
                mensagem = $"O produto {prod.Nome} foi excluído com sucesso!!!";
            }
            return Json(mensagem, JsonRequestBehavior.AllowGet);
        }


    }
}