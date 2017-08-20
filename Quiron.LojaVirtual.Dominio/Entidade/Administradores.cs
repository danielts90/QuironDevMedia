using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiron.LojaVirtual.Dominio.Entidade
{
    public class Administradores
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage ="Digite o login")]
        [Display(Name ="Login")]
        public string Login { get; set; }
        [Required(ErrorMessage ="Digite a senha")]
        [Display(Name ="Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public DateTime UltimoAcesso { get; set; }
    }
}
