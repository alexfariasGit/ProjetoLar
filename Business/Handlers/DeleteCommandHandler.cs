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
    public class DeleteCommandHandler : IRequestHandler<DeleteCommand>
    {
        private readonly IPessoaRepository _pessoaRepository;

        public DeleteCommandHandler(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<Unit> Handle(DeleteCommand request, CancellationToken cancellationToken)
        {
            await _pessoaRepository.DeletePessoa(request.ID);
            return Unit.Value; 
        }
    }
}
