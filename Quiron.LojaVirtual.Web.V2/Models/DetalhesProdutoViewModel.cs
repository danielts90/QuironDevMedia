using Quiron.LojaVirtual.Dominio.Dto;
using Quiron.LojaVirtual.Dominio.Entidade;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Quiron.LojaVirtual.Web.V2.Models
{
    public class DetalhesProdutoViewModel
    {
        public QuironProduto Produto { get; set; }
        public IEnumerable<Cor> Cores { get; set; }
        public IEnumerable<Tamanho> Tamanhos { get; set; }
        public BreadCrumbDto Breadcrumb { get; set; }
        public SelectList CoresList { get; set; }
        public SelectList TamanhoList { get; set; }
    }
}