using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Pedido
    {
        [Required(ErrorMessage="Informe seu nome")]
        [Display(Name="Nome do Cliente")]
        public string  NomeCliente { get; set; }
        [Display(Name="Cep: ")]
        public int? Cep { get; set; }

        [Required(ErrorMessage ="Informe o seu endereço")]
        [Display(Name ="Endereço")]
        public string Endereco { get; set; }

        [Display(Name ="Complemento: ")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "Informe a sua cidade")]
        [Display(Name = "Cidade: ")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "Informe o seu bairro")]
        [Display(Name = "Bairro: ")]
        public string Bairro { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Informe o seu e-mail")]
        [EmailAddress(ErrorMessage ="E-mail invalido")]
        public string Email { get; set; }

        [Display(Name ="Estado: ")]
        public string Estado { get; set; }

        public bool EmbrulhaPresente { get; set; }

    }
}
