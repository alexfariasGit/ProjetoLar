using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Pessoa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public long PessoaID { get; set; }

        [Required]
        [StringLength(11)] 
        public string CPF { get; set; }

        [Required]
        [StringLength(100)] 
        public string Nome { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; } 

        [Required]
        public bool Ativo { get; set; } 
        public ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    }

}
