using Business.Querys;
using Domain.Entities;
using Domain.Interfaces;

using MediatR;

namespace Business.Handlers
{
    public class GetPessoaByCpfQueryHandler : IRequestHandler<GetPessoaByCpfQuery, Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetPessoaByCpfQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> Handle(GetPessoaByCpfQuery request, CancellationToken cancellationToken)
        {
            return await _pessoaRepository.GetPessoaByCPF(request.CPF);
        }
    }
}
