using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIMuitos_Para_MuitosDomain.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Entre 03 e 100 Caracteres !")]
        [Display(Name = "Nome")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Campo Obrigatório !")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Máximo 100 Caracteres !")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage ="O Email não possui um Formato Valido !")]
        public String Email { get; set; }

        public ICollection<Grupo> Grupos { get; set; }
    }
}
