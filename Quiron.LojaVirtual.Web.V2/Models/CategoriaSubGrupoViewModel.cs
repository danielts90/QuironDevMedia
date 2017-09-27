using Quiron.LojaVirtual.Dominio.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class CategoriaSubGrupoViewModel
    {
        public Categoria Categoria { get; set; }
        public IEnumerable<SubGrupo> SubGrupos { get; set; }
    }
}