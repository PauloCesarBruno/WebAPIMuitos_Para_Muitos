using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPIMuitos_Para_MuitosDomain.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo Obrigatório !")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="Entre 03 e 100 Caracteres !")]
        [Display(Name ="Nome do Grupo")]
        public String GrupoNome { get; set; }

        public ICollection <Usuario> Usuarios { get; set; }
    }
}
