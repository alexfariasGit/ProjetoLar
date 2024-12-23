using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
    public class Telefone
    {
        public long TelefoneID { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }

        public long PessoaID { get; set; }

        public Pessoa? Pessoa { get; set; }
    }
}
