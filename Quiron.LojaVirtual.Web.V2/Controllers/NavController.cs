using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class NavController : Controller
    {
        ProdutoModeloRepositorio _repositorio = new ProdutoModeloRepositorio();
        private ProdutosViewModel _model = new ProdutosViewModel();
        // GET: Nav
        public ActionResult Index()
        {
            var produtos = _repositorio.ObterProdutosVitrine();
            _model = new ProdutosViewModel { Produtos = produtos };
            return View(_model);
        }

        public JsonResult TesteMetodoVitrine()
        {
            var produtos = _repositorio.ObterProdutosVitrine(categoria:"0083", marca:"1106");
               
            return Json(produtos, JsonRequestBehavior.AllowGet);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarcas(string id)
        {
            var _model = new ProdutosViewModel { Produtos = null };
            return View("Idex", _model);
        }
    }
}