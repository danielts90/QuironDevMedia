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
        private MenuRepositorio _menuRepositorio = new MenuRepositorio();

        // GET: Nav
        public ActionResult Index()
        {
            var produtos = _repositorio.ObterProdutosVitrine();
            _model = new ProdutosViewModel { Produtos = produtos };
            return View(_model);
        }

        [Route("nav/{id}/{marca}")]
        public ActionResult ObterProdutosPorMarca(string id, string marca)
        {
            var produtos = _repositorio.ObterProdutosVitrine(marca: marca);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = marca };

            return View("Navegacao", _model);
        }

        [Route("nav/times/{id}/{clube}")]
        public ActionResult ObterProdutosPorClubes(string id, string clube)
        {
            var produtos = _repositorio.ObterProdutosVitrine(linha: id);
            var _model = new ProdutosViewModel { Produtos = produtos, Titulo = clube };
            return View("Navegacao", _model);
        }

        [Route("nav/genero/{id}/{genero}")]
        public ActionResult ObterProdutosPorGenero(string id, string genero)
        {
            var produtos = _repositorio.ObterProdutosVitrine(genero: genero);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = genero };

            return View("Navegacao", _model);
        }

        [ChildActionOnly]
        [OutputCache(Duration =3600, VaryByParam ="*")]
        public ActionResult TenisCategoria()
        {
            var categorias = _menuRepositorio.ObterTenisCategoira();
            var subGrupo = _menuRepositorio.SubGrupoTenis();

            var model = new SubGrupoCategoriasViewModel
            {
                Categorias = categorias,
                SubGrupo = subGrupo
            };
            return PartialView("_TenisCategoria", model);
        }

        [Route("calcados/{subGrupoCodigo}/tenis/{categoriaCodigo}/{categoriaDescricao}")]
        public ActionResult ObterTenisPorCategoria(string subGrupoCodigo, string categoriaCodigo, string categoriaDescricao)
        {
            var produtos = _repositorio.ObterProdutosVitrine(categoriaCodigo, subgrupo: subGrupoCodigo);
            _model = new ProdutosViewModel { Produtos = produtos, Titulo = categoriaDescricao.ToUpper() };
            return View("_Navegacao", _model);
        }

    }
}