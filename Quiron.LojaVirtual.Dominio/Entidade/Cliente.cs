using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Cliente : IdentityUser
    {
        [NotMapped]
        public string Senha { get; set; }
        [Required]
        public string NomeCompleto { get; set; }

        [Required]
        public virtual TelefoneCliente Telefone { get; set; }
        [Required]
        public virtual DocumentoCliente Documento { get; set; }
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
