using DesafioWebAPI.Data;
using DesafioWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private PessoaContext _context;
        public PessoaController(PessoaContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult CadastroPessoa([FromBody]Pessoa pessoa)
        {
            _context.pessoas.Add(pessoa);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaPessoaId), new {id = pessoa.Id }, pessoa);
        }

        [HttpGet]
        public IEnumerable<Pessoa> RecuperarPessoa()
        {
           return _context.pessoas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaPessoaId(int id)
        {
           Pessoa pessoa = _context.pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            {
                if(pessoa!= null)
                {
                    return Ok(pessoa);
                }
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaPessoa(int id, [FromBody] Pessoa pessoaAtualizada)
        {
            Pessoa pessoa = _context.pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if(pessoa == null)
            {
                return NotFound();
            }
            pessoa.Nome = pessoaAtualizada.Nome;
            pessoa.Cpf = pessoaAtualizada.Cpf;
            pessoa.Sexo = pessoaAtualizada.Sexo;
            pessoa.Telefone = pessoaAtualizada.Telefone;
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaPessoa(int id)
        {
            Pessoa pessoa = _context.pessoas.FirstOrDefault(pessoa => pessoa.Id == id);
            if (pessoa == null)
            {
                return NotFound();
            }
            _context.Remove(pessoa);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
