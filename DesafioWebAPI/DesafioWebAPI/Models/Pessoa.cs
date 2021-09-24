using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.Models
{
    public class Pessoa : Endereco
    {
        [Key]
        [Required]
        public int  Id { get; set; }

        [Required(ErrorMessage ="O campo NOME é obrigatorio")]        
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo CPF é obrigatorio")]
        public int  Cpf { get; set; }

        [Required(ErrorMessage = "O campo SEXO é obrigatorio")]
        public string Sexo { get; set; }       

        [Required(ErrorMessage = "o Campo TELEFONE é obrigatorio")]        
        public int Telefone { get; set; }
      
    }
}
