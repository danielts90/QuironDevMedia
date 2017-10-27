using Microsoft.AspNet.Identity;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using Quiron.LojaVirtual.Web.V2.Models;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Controllers
{
    public class CarrinhoController : Controller
    {
        private QuironProdutosRepositorio _repositorio = new QuironProdutosRepositorio();
        private ClientesRepositorio _clientesRepositorio = new ClientesRepositorio();
        private PedidoRepositorio _pedidoRepositorio = new PedidoRepositorio();
        public RedirectToRouteResult Adicionar(Carrinho carrinho, int quantidade,
                   string produto, string Cor, string Tamanho, string returnUrl)
        {
            QuironProduto prod = _repositorio.ObterProduto(produto, Cor, Tamanho);

            if (prod != null)
            {
                carrinho.AdicionarItem(prod, quantidade);

            }

            return RedirectToAction("Index", "Nav");

        }

        public RedirectToRouteResult Remover(Carrinho carrinho, int produtoId, string returnUrl)
        {
            var produto = _repositorio.Produtos
                .FirstOrDefault(p => p.ProdutoId == produtoId);

            if(produto != null)
            {
                carrinho.RemoverItem(produto);
            }
            return RedirectToAction("Index", "Nav");
        }

        public ViewResult Index(Carrinho carrinho, string returnUrl)
        {
            return View(new CarrinhoViewModel
            {
                Carrinho = carrinho,
                ReturnUrl = returnUrl
            });
        }

        public PartialViewResult Resumo(Carrinho carrinho)
        {
            return PartialView(carrinho);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult FecharPedido(Carrinho carrinho, Pedido pedido)
        {
            if(!carrinho.ItensCarrinho.Any())
            {
                ModelState.AddModelError("", "Não foi possível concluir o pedido");
            }
            
            if (ModelState.IsValid)
            {
                pedido.ProdutoPedido = new List<ProdutoPedido>();
                foreach (var item in pedido.ProdutoPedido)
                {
                    pedido.ProdutoPedido.Add(new ProdutoPedido()
                    {
                        Quantidade = item.Quantidade,
                        ProdutoId = item.ProdutoId
                    });
                }

                pedido.Pago = false;
                pedido = _pedidoRepositorio.SalvarPedido(pedido);
                return RedirectToAction("PedidoConcluido", new { pedidoId = pedido.Id });
            }
            else
            {
                return View(pedido);
            }
        }

        [Authorize]
        public ViewResult FecharPedido()
        {
            Pedido novoPedido = new Pedido();
            novoPedido.ClienteId = User.Identity.GetUserId();
            novoPedido.Cliente = _clientesRepositorio.ObterCliente(novoPedido.ClienteId);
            return View(novoPedido);
        }

        public ViewResult PedidoConcluido(Carrinho carrinho, int pedidoId )
        {
            EmailConfiguracoes email = new EmailConfiguracoes
            {
                EscreverArquivo = bool.Parse(ConfigurationManager.AppSettings["Email.Escrever"] ?? "false")
            };

            var pedido = _pedidoRepositorio.ObterPedido(pedidoId);

            var emailPedido = new EmailPedido(email);
            emailPedido.ProcessarPedido(carrinho, pedido);
            carrinho.LimparCarrinho();
            return View(pedido);
        }

        //private Carrinho ObterCarrinho()
        //{
        //    var carrinho = (Carrinho)Session["Carrinho"];

        //    if(carrinho == null)
        //    {
        //        carrinho = new Carrinho();
        //        Session["Carrinho"] = carrinho;
        //    }
        //    return carrinho;
        //}

    }
}