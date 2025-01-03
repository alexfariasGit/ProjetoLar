﻿using Domain.Entities;
using MediatR;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Querys
{
    public class GetPessoaByIDQuery : IRequest<Pessoa>
    {
        public long ID { get; set; }
    }
}
