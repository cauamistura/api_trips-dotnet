using Microsoft.AspNetCore.Mvc;
using Uniciv.Api.Models;
using Uniciv.Api.Repositories;

namespace Uniciv.Api.Controllers
{
    public class FundoCapitalController : Controller
    {
        private readonly IFundoCapitalRepository _repository;

        public FundoCapitalController(IFundoCapitalRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet("/v1/fundoscapital")]
        public IActionResult ListarFundos() => Ok(_repository.ListarFundos());

        [HttpGet("/v1/fundoscapital/{id}")]
        public IActionResult ObterFundo(Guid id)
        {
            var fundo = _repository.ObterPorId(id);
            if (fundo == null)
                return NotFound();
            return Ok(fundo);
        }

        [HttpPost("/v1/fundoscapital")]
        public IActionResult AdicionarFundos([FromBody] FundoCapital fundoCapital)
        {
            _repository.Adicionar(fundoCapital);    
            return Ok();
        }

        [HttpPut("/v1/fundoscapital/{id}")]
        public IActionResult AtualizarFundos(Guid id, [FromBody] FundoCapital fundoCapital)
        {
            var fundo = _repository.ObterPorId(id);
            if (fundo == null)
                return NotFound();
            fundo.Nome = fundoCapital.Nome;
            fundo.ValorAtual = fundoCapital.ValorAtual;
            fundo.ValorNecessario = fundoCapital.ValorNecessario;
            fundo.DataResgate = fundoCapital.DataResgate;
            _repository.Alterar(fundo);
            return Ok();
        }

        [HttpDelete("/v1/fundoscapital/{id}")]
        public IActionResult DeletarFundos(Guid id)
        {
            var fundo = _repository.ObterPorId(id);
            if (fundo == null)
                return NotFound();
            _repository.RemoverFundo(fundo);
            return Ok();
        }
    }
}