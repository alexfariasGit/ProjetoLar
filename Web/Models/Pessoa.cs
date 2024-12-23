using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Pessoa
    {
        public long PessoaID { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public bool Ativo { get; set; }
        public List<Telefone> Telefones { get; set; } = new List<Telefone>();
    }
}
