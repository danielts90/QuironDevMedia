using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class QuironUserManager : UserManager<Cliente>
    {
        public QuironUserManager(IUserStore<Cliente> store) : base(store) { }

        public static QuironUserManager Create(IdentityFactoryOptions<QuironUserManager> options, IOwinContext context)
        {
            var userManager = new QuironUserManager(new UserStore<Cliente>(new EfDbContext()));

            return userManager;
        }
    }
}