using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DiegoEscola.Web.Models
{
    public class Aluno
    {
        [Key]
        public int IdAluno { get; set; }

        [Required(ErrorMessage = "Nome do Aluno é obrigatório")]
        [Display(Name = "Nome do Aluno")]
        [MaxLength(100)]
        [MinLength(10)]
        public string NomeAluno { get; set; }

        [Required(ErrorMessage = "Data de Nascimento é obrigatório")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Escola é obrigatório")]
        [Display(Name = "Escola")]
        public int IdEscola { get; set; }

        public virtual Escola Escola { get; set; }

        public bool EhMaiorIdade()
        {
            if (DateTime.Now.Year - this.DataNascimento.Year < 18)
                return false;

            return true;
        }
        public bool AlunoExistente(IEnumerable<Aluno> alunos)
        {
            if (alunos.Where(a => a.NomeAluno == this.NomeAluno && a.IdAluno != this.IdAluno).Count() > 0)
                return true;
            return false;
        }
        public bool Validar(IEnumerable<Aluno> alunos)
        {
            if (this.AlunoExistente(alunos))
                throw new Exception("Aluno já existe, informe outro nome");

            if (!this.EhMaiorIdade())
                throw new Exception("Aluno é menor de idade");

            return true;
        }
    }
}
