using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class SubGrupoCategoriasViewModel
    {
        public SubGrupo SubGrupo { get; set; }
        public IEnumerable<Categoria> Categorias { get; set; }
    }
}