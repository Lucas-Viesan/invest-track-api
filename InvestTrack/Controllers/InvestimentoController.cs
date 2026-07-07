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
    }
}
