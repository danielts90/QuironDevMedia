using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Entidade.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Repositorio
{
    public class MenuRepositorio
    {
        private EfDbContext _context = new EfDbContext();
        public IEnumerable<Categoria> ObterCategorias()
        {
            return _context.Categorias.OrderBy(c => c.CategoriaDescricao);
        }

        public IEnumerable<MarcaVitrine> ObterMarcas()
        {
            return _context.MarcaVitrine.OrderBy(c => c.MarcaDescricao);
        }

        public IEnumerable<ClubesNacionais> ObterClubesNacionais()
        {
            return _context.ClubesNacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<ClubesInternacionais> ObterClubesInternacionais()
        {
            return _context.ClubesInternacionais.OrderBy(c => c.LinhaDescricao);
        }

        public IEnumerable<Categoria> ObterTenisCategoira()
        {
            var categorias = new[] { "0005", "0082", "0112", "0010", "0006", "0063" };
            return _context.Categorias.Where(c => categorias.Contains(c.CategoriaCodigo)).OrderBy(c => c.CategoriaDescricao);
        }

        public SubGrupo SubGrupoTenis()
        {
            return _context.SubGrupos.FirstOrDefault(s => s.SubGrupoCodigo == "0084");
        }
    }
}
