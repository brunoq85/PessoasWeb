using Microsoft.AspNetCore.Mvc;
using PessoasWeb.Core.Entities;
using PessoasWeb.Core.Interfaces;

namespace PessoasWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IPessoaRepository _pessoaRepository;

        public PessoasController(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        [HttpGet("GetPessoas")]
        public async Task<ActionResult<IEnumerable<Pessoa>>> Get()
        {
            var pessoas = await _pessoaRepository.GetPessoasAsync();

            return Ok(pessoas);
        }

        [HttpGet("GetPessoaByNome/{nome}")]
        public async Task<ActionResult<Pessoa>> GetByNome(string nome)
        {
            var pessoa = await _pessoaRepository.GetPessoasByNomeAsync(nome);

            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpPost("AddPessoa")]
        public async Task<ActionResult> AddPessoa([FromBody] Pessoa pessoa)
        {
            await _pessoaRepository.AddPessoaAsync(pessoa);
            return Ok();
        }

        [HttpPut("UpdatePessoa/{id}")]
        public async Task<ActionResult> UpdatePessoa(int id, [FromBody] Pessoa pessoa)
        {
            if(id != pessoa.Id) return BadRequest();
            await _pessoaRepository.UpdatePessoaAsync(pessoa);
            return Ok();
        }

        [HttpDelete("RemovePessoa/{id}")]
        public async Task<ActionResult> UpdatePessoa(int id)
        {
            await _pessoaRepository.RemovePessoaAsync(id);
            return Ok();
        }
    }
}
