using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetPessoaByID(long ID);
        Task<Pessoa> GetPessoaByCPF(string cpf);
        Task<List<Pessoa>> GetAllPessoas();
        Task AddPessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa, List<Telefone> tel);
        Task DeletePessoa(long ID);
        Task DeleteTelefone(long ID);
    }
}
