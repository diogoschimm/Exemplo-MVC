using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoEscola.Web.Models
{
    public class Escola
    {
        [Key]
        public int IdEscola { get; set; }

        [Required(ErrorMessage = "Nome da Escola é obrigatório")]
        [Display(Name = "Nome da Escola")]
        [MaxLength(100, ErrorMessage ="Tamanho máximo de 100")]
        [MinLength(10, ErrorMessage ="Tamanho mínimo de 10")]
        public string NomeEscola { get; set; }

        public virtual IEnumerable<Aluno> Alunos { get; set; }
    }
}
