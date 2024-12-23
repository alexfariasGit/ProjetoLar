using Business.Querys;
using Domain.Entities;
using Domain.Interfaces;

using MediatR;

namespace Business.Handlers
{
    public class GetAllPessoasQueryHandler : IRequestHandler<GetAllPessoasQuery, List<Pessoa>>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetAllPessoasQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<List<Pessoa>> Handle(GetAllPessoasQuery request, CancellationToken cancellationToken)
        {
            return await _pessoaRepository.GetAllPessoas();
        }
    }
}
