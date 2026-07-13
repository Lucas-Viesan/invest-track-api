using InvestTrack.Dtos;
using InvestTrack.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace InvestTrack.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {
        private CarteiraService _service;

        public CarteiraController(CarteiraService carteiraService)
        {
            _service = carteiraService;
        }

        [HttpPost]
        public IActionResult CriarCarteira(CriarCarteiraDto carteiraDto)
        {
           var dto = _service.CriarCarteira(carteiraDto);
            return Created();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarCarteira(int id)
        {
           var carteira = await _service.BuscarCarteiraPorId(id);
            if (carteira == null) 
            {
                return NotFound();
            }
           return Ok(carteira);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirCarteira(int id)
        {
            await _service.Excluir(id);
            return NoContent();
        }
    }
}
