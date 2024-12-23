using Business.Commands;
using Domain.Interfaces;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Handlers
{
    public class UpdateCommandHandler : IRequestHandler<UpdateCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public UpdateCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Unit> Handle(UpdateCommand request, CancellationToken cancellationToken)
        {
            await _pessoaRepository.UpdatePessoa(request.Pessoa, request.Pessoa.Telefones.ToList());
            return Unit.Value; 
        }
    }
}
