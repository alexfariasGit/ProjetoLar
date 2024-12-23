using Domain.Entities;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Commands
{
    public class DeleteCommand : IRequest
    {
        public long ID { get; set; }
    }
}
