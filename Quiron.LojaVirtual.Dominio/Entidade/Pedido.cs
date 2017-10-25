using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Key]
        public int Id { get; set; }

        public string ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public virtual Cliente Cliente { get; set; }

        public bool Pago { get; set; }

        public bool EmbrulhaPresente { get; set; }
        public virtual ICollection<ProdutoPedido> ProdutoPedido { get; set; }

    }
}
