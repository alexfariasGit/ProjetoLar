using Business.Commands;
using Business.Querys;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using System.Text.Json;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PessoaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePessoa([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Dados inválidos");
            var command = new CreateCommand
            {
                Pessoa = pessoa
            };

            await _mediator.Send(command);

            return CreatedAtAction(nameof(GetPessoaByIDQuery), new { ID = command.Pessoa.CPF }, command.Pessoa);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPessoaByID(long id)
        {
            var query = new GetPessoaByIDQuery { ID = id };

            var pessoa = await _mediator.Send(query);

            if (pessoa == null)
                return NotFound("Pessoa não encontrada");

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles, // Desabilitar referências circulares
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(pessoa, options);
            return Ok(json);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPessoas()
        {
            var query = new GetAllPessoasQuery();

            var pessoas = await _mediator.Send(query);

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles, 
                WriteIndented = true
            };

            var json = JsonSerializer.Serialize(pessoas, options);


            return Ok(json);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePessoa([FromBody] Pessoa pessoa)
        {
            if (pessoa == null)
                return BadRequest("Dados inválidos");
            var command = new UpdateCommand
            {
                Pessoa = pessoa
            };

            await _mediator.Send(command);

            return NoContent(); 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePessoa(long id)
        {
            if (id == 0)
                return BadRequest("Dados inválidos");

                await _mediator.Send(new DeleteCommand { ID = id });

                return NoContent();
        }
    }
}
