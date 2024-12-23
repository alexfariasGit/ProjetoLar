using Domain.Entities;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands
{
    public class UpdateCommand : IRequest
    {
        public Pessoa Pessoa { get; set; }
    }
}
