using Quiron.LojaVirtual.Dominio.Entidade;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class CarrinhoViewModel
    {
        public Carrinho Carrinho { get; set; }
        public string ReturnUrl { get; set; } 
    }
}