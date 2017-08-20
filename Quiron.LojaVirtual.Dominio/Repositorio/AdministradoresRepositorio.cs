using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class AdministradoresRepositorio
    {
        private readonly EfDbContext _context = new EfDbContext();

        public Administrador ObterAdministrador(Administrador adm)
        {
            return _context.Administradores.FirstOrDefault(a => a.Login == adm.Login);
        }
    }
}
