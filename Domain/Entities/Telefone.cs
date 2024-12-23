using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Telefone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TelefoneID { get; set; }
        [Required]
        [StringLength(15)] 
        public string Numero { get; set; }

        [Required]
        [StringLength(20)] 
        public string Tipo { get; set; }

        public long PessoaID { get; set; }

        public Pessoa? Pessoa { get; set; }
    }

}
