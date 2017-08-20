using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.Controllers
{
    public class AutenticacaoController : Controller
    {
        private AdministradoresRepositorio _repositorio = new AdministradoresRepositorio();
        // GET: Autenticacao
        public ActionResult Index()
        {
            return View();
        }

        public void  Login()
        {
            var administrador = new Administrador();
            administrador.Login = "admin";

            _repositorio.ObterAdministrador(administrador)
        }
    }
}