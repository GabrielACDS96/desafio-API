using desafio_sequence_target.Classes;
using desafio_sequence_target.Data;
using desafio_sequence_target.InputModel;
using Microsoft.AspNetCore.Mvc;

namespace desafio_sequence_target.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesafioController : ControllerBase
    {
        private readonly DesafioRepository DesafioRepository;
        public DesafioController(DesafioRepository desafioRepository)
        {
            DesafioRepository = desafioRepository;
        }

        [HttpGet]
        public dynamic Get([FromQuery]DateTime? dataInicial, [FromQuery]DateTime? dataFinal)
        {
            return DesafioRepository.Obter(dataInicial, dataFinal);
        }

        [HttpPost]
        public dynamic Post([FromBody]DesafioInputModel desafioInputModel)
        {
            var desafio = new Desafio(desafioInputModel.Sequence, desafioInputModel.Target);
            DesafioRepository.Adicionar(desafio);
            return Ok(desafio.Solucionar());
        }
    }
}
