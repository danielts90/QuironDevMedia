using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.Models;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class CarrinhoController : Controller
    {
        private ProdutosRepositorio _repositorio = new ProdutosRepositorio();

        public RedirectToRouteResult Adicionar(int produtoId, string returnUrl)
        {
            var produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().AdicionarItem(produto, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult Remover(int produtoId, string returnUrl)
        {
            var produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                ObterCarrinho().RemoverItem(produto);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public ViewResult Index(string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = ObterCarrinho(),
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo()
        {
            var carrinho = ObterCarrinho();
            return PartialView(carrinho);
        }

        public ViewResult FecharPedido()
        {
            return View(new Pedido());
        }

        [HttpPost]
        public ViewResult FecharPedido(Pedido pedido)
        {
            var carrinho = ObterCarrinho();
            var email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.Escrever"] ?? "false")
            };

            var emailPedido = new EmailPedido(email);

            if(!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido, seu carrinho está vazio.");
            }

            if (ModelState.IsValid)
            {
                emailPedido.ProcessarPedido(carrinho, pedido);
                carrinho.LimparCarrinho();
                return View("PedidoConcluido");
            }
            else
            {
                return View(pedido);
            }
        }

        public ViewResult PedidoConcluido()
        {
            return View();
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