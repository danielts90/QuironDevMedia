using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CategoriaController : Controller
    {
        private CategoriaRepositorio _repositorio = new CategoriaRepositorio();
       
        [OutputCache(Duration = 3600, Location = OutputCacheLocation.Server, VaryByParam = "none")]
        public JsonResult ObterEsportes()
        {
            var cat = _repositorio.ObterCategoria();
            var categorias = from c in cat
                             select new
                             {
                                 c.CategoriaDescricao,
                                 CategoriaDescricaoSeo = c.CategoriaDescricao.ToSeoUrl(),
                                 c.CategoriaCodigo
                             };
            return Json(categorias, JsonRequestBehavior.AllowGet);

        }
    }
}