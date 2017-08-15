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
    }
}