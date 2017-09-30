using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Cliente : IdentityUser
    {
        [Required]
        public virtual TelefoneCliente Telefone { get; set; }
        [Required]
        public virtual DocumentoCliente Documento { get; set; }
        [Required]
        public virtual EnderecoCliente Endereco { get; set; }
    }
}
