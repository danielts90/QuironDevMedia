using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class VitrineController : Controller
    {
        private ProdutosRepositorio _repositorio = new ProdutosRepositorio();
        public int produtosPorPagina = 12;
      
        //public ViewResult ListaProdutos(string categoria, int pagina = 1)
        //{
        //    var model = new ProdutosViewModel()
        //    {
        //        Produtos = _repositorio.Produtos
        //             .Where(p => categoria == null || p.Categoria.Trim() == categoria)
        //             .OrderBy(p => p.Descricao)
        //             .Skip((pagina - 1) * produtosPorPagina)
        //             .Take(produtosPorPagina),

        //        Paginacao = new Paginacao()
        //        {
        //            PaginaAtual = pagina,
        //            ItensPorPagina = produtosPorPagina,
        //            ItensTotal = categoria == null ? _repositorio.Produtos.Count() : _repositorio.Produtos.Where(p => p.Categoria.Trim() == categoria).Count()
        //        },
        //        CategoriaAtual = categoria
        //    };

        //    return View(model);
        //}

        public ViewResult ListaProdutos(string categoria, int pagina = 1)
        {
            var model = new ProdutosViewModel();

            var rdn = new Random();

            if(categoria != null)
            {
                model.Produtos = _repositorio.Produtos
                    .Where(p => p.Categoria == categoria)
                    .OrderBy(x => rdn.Next()).ToList();
            }
            else
            {
                model.Produtos = _repositorio.Produtos
                    .OrderBy(x => rdn.Next())
                    .Take(produtosPorPagina).ToList();
            }

            return View(model);
        }

        [Route("Vitrine/ObterImagem/{produtoId}")]
        public FileContentResult ObterImagem(int produtoId)
        {
            var prod = _repositorio.Produtos.FirstOrDefault(x => x.ProdutoId == produtoId);

            if (prod != null)
            {
                return File(prod.Imagem, prod.ImageMimeType);
            }
            return null;

        }

        [Route("DetalhesProduto/{id}/{produto}")]
        public ViewResult Detalhes(int id)
        {
            var produto = _repositorio.ObterProduto(id);
            return View(produto);
        }
    }
}