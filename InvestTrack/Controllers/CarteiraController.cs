using InvestTrack.Dtos;
using InvestTrack.Service;
using Microsoft.AspNetCore.Mvc;

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

        [HttpDelete]
        public IActionResult ExcluirCarteira(int id)
        {
            _service.Excluir(id);
            return NoContent();
        }
    }
}
