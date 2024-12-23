using Business.Commands;
using Domain.Interfaces;
using MediatR;

namespace Business.Handlers
{
    public class CreateCommandHandler : IRequestHandler<CreateCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public CreateCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Unit> Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            await _pessoaRepository.AddPessoa(request.Pessoa);
            return Unit.Value;
        }
    }

}
