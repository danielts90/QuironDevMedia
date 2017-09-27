using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidade;
using Quiron.LojaVirtual.Dominio.Entidade.Vitrine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastMapper;


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

        public Modalidade ModalidadeCasual()
        {
            const string CODIGOMODALIDADE = "0001";
            return _context.Modalidades.FirstOrDefault(m => m.ModalidadeCodigo == CODIGOMODALIDADE);
        }

        public IEnumerable<SubGrupoDto> ObterCasualSubgrupo()
        {
            var subGrupos = new[] {"0001","0102","0103","0738","0084","0921" };
            var query = from s in _context.SubGrupos
                        .Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                        .Select(s => new { s.SubGrupoCodigo, s.SubGrupoDescricao })
                        .Distinct()
                        .OrderBy(s => s.SubGrupoDescricao)
                        select new
                        {
                            s.SubGrupoCodigo,
                            s.SubGrupoDescricao
                        };
            return query.Project().To<SubGrupoDto>().ToList();

        }

        public Categoria Suplemento()
        {
            var CATEGORIA_SUPLEMENTOS = "0008";
            return _context.Categorias.FirstOrDefault(s => s.CategoriaCodigo == CATEGORIA_SUPLEMENTOS);
        }

        public IEnumerable<SubGrupo> ObterSuplementos()
        {
            var subGrupos = new[]
            { "0162","0381","0557","0564","0565","1082","1083","1084","1085"};
            return _context.SubGrupos.Where(s => subGrupos.Contains(s.SubGrupoCodigo))
                .Where(s => s.GrupoCodigo == "0012")
                .OrderBy(s => s.SubGrupoDescricao);
        }
    }
}
