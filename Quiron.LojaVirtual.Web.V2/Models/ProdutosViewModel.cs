using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class ProdutosViewModel
    {
        public List<Dominio.Entidade.ProdutoVitrine> Produtos { get; set; }
        public string Titulo { get; set; }

    }
}