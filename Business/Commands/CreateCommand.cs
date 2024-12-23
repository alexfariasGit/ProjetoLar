using Domain.Entities;
using MediatR;

namespace Business.Commands
{
    public class CreateCommand : IRequest<Unit>
    {
        public Pessoa Pessoa { get; set; }
    }

}
