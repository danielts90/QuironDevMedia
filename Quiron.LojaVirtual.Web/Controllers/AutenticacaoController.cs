using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System.Web.Mvc;
using System.Web.Security;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio = new AdministradoresRepositorio();
        // GET: Autenticacao
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View(new Administrador());
        }

        [HttpPost]
        public ActionResult Login(Administrador administrador, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var admin = _repositorio.ObterAdministrador(administrador);

                if(admin != null)
                {
                    if(!Equals(administrador.Senha, admin.Senha))
                    {
                        ModelState.AddModelError("","Senha inválida");
                    }
                    else
                    {
                        FormsAuthentication.SetAuthCookie(admin.Login, false);

                        if (Url.IsLocalUrl(returnUrl)
                        && returnUrl.Length > 1
                        && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//"))
                            return Redirect(returnUrl);
                        else
                            return Redirect("/Administrativo/Produto/Index");

                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuário não localizado");
                }
            }
            return View(new Administrador());
        }
    }
}