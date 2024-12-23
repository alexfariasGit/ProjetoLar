using Data.Context;

using Domain.Entities;
using Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {
        private readonly ApplicationDbContext _context;

        public PessoaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pessoa> GetPessoaByCPF(string cpf)
        {
            return await _context.Pessoas.Include(p => p.Telefones).FirstOrDefaultAsync(p => p.CPF == cpf);
        }

        public async Task<Pessoa> GetPessoaByID(long ID)
        {
            return await _context.Pessoas.Include(p => p.Telefones).FirstOrDefaultAsync(p => p.PessoaID == ID);
        }
        public async Task<List<Pessoa>> GetAllPessoas()
        {
            return await _context.Pessoas.Include(p => p.Telefones).ToListAsync();
        }

        public async Task AddPessoa(Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            await _context.SaveChangesAsync();
        }


        public async Task UpdatePessoa(Pessoa pessoa, List<Telefone> telefone)
        {
            try
            {
                _context.Pessoas.Update(pessoa);

                var telefonesExistentes = await _context.Telefones
                    .Where(t => t.PessoaID == pessoa.PessoaID)
                    .ToListAsync();

                foreach (var telefoneExistente in telefonesExistentes)
                {
                    var telefoneNovo = telefone.FirstOrDefault(t => t.TelefoneID == telefoneExistente.TelefoneID);

                    if (telefoneNovo == null)
                    {
                        _context.Telefones.Remove(telefoneExistente);
                    }
                }

                foreach (var item in telefone)
                {
                    if (item.TelefoneID == 0) 
                    {
                        _context.Telefones.Add(item);
                    }
                    else
                    {
                        var telefoneExistente = await _context.Telefones
                            .FirstOrDefaultAsync(t => t.TelefoneID == item.TelefoneID);

                        if (telefoneExistente != null)
                        {
                            _context.Entry(telefoneExistente).CurrentValues.SetValues(item);
                        }
                        else
                        {
                            _context.Telefones.Update(item);
                        }
                    }
                }

                // Salvar as alterações no contexto
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new Exception("Pessoa não encontrada." + ex.Message);
            }

        }

        public async Task DeleteTelefone(long ID)
        {
            var telefone = await _context.Telefones.FirstOrDefaultAsync(p => p.TelefoneID == ID);

            if (telefone != null)
            {
                _context.Telefones.Remove(telefone);
                await _context.SaveChangesAsync();
            }

        }
        public async Task DeletePessoa(long ID)
        {
            var pessoa = await _context.Pessoas.FirstOrDefaultAsync(p => p.PessoaID == ID);

            if (pessoa != null)
            {
                _context.Pessoas.Remove(pessoa); 
                await _context.SaveChangesAsync(); 
            }
            
        }
    }

}
