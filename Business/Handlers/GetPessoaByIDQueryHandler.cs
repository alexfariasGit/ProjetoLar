using Business.Querys;
using Domain.Entities;
using Domain.Interfaces;

using MediatR;

namespace Business.Handlers
{
    public class GetPessoaByIDQueryHandler : IRequestHandler<GetPessoaByIDQuery, Pessoa>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public GetPessoaByIDQueryHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Pessoa> Handle(GetPessoaByIDQuery request, CancellationToken cancellationToken)
        {
            return await _pessoaRepository.GetPessoaByID(request.ID);
        }
    }
}
