using Quiron.LojaVirtual.Dominio.Entidade;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Infraestrutura
{
    public class CarrinhoModelBinder : System.Web.Mvc.IModelBinder
    {
        private const string SessionKey = "Carrinho";
        public object BindModel(ControllerContext controllerContext, System.Web.Mvc.ModelBindingContext bindingContext)
        {
            //Obter Carrinho da sessão
            Carrinho carrinho = null;

            if(controllerContext.HttpContext.Session != null)
            {
                carrinho = (Carrinho)controllerContext.HttpContext.Session[SessionKey];
            }

            //Criar o carrinho 
            if(carrinho == null)
            {
                carrinho = new Carrinho();

                if(controllerContext.HttpContext.Session != null)
                {
                    controllerContext.HttpContext.Session[SessionKey] = carrinho;
                }
            }

            return carrinho;

        }
    }
}