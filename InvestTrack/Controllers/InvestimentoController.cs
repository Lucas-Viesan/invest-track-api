using InvestTrack.Dtos;
using InvestTrack.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace InvestTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvestimentoController : ControllerBase
    {
        private InvestimentoService _service;

        public InvestimentoController(InvestimentoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> PostInvestimentos(CriarInvestimentoDto investimentoDto)
        {
            var investimento = await _service.CriarInvestimento(investimentoDto);

            return Created("", investimento);
        }

        [HttpGet("{id}")]
        public IActionResult GetInvestimento(int id) 
        { 
            var investimento = _service.RecuperarInvestimentoPorId(id);
            if (investimento == null)
            {
                return NotFound();
            }
            return Ok(investimento);
        }


        [HttpPut("{id}")]
        public IActionResult PutInvestimentos( int invest, [FromBody] AtualizaInvestimentoDto atualizacao)
        {
            var investimento = _service.AtualizarInvestimento(invest, atualizacao);
            if (investimento != null) {
                return Ok(investimento);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteInvestimentos( int id)
        {
           _service.DeletarInvestimento(id);
            return NoContent();
        }


    }
}
