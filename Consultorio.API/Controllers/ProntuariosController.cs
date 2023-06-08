using ConsultorioMedico.Aplicacao.InputModels;
using ConsultorioMedico.Aplicacao.InterfacesServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsultorioMedico.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProntuariosController : ControllerBase
    {
        private readonly IProntuariosService _prontuariosService;

        public ProntuariosController(IProntuariosService prontuariosService)
        {
            _prontuariosService = prontuariosService;
        }

        [HttpPost("create-prontuario-by-id")]
        public async Task<IActionResult> CreateProntuarioById(ProntuariosInputModel inputModel)
        {
            var prontuarioViewModel = await _prontuariosService.CriarProntuarioPorId(inputModel);

            if (prontuarioViewModel == null)
            {
                return BadRequest("Paciente ou médico não encontrado.");
            }

            return Ok(prontuarioViewModel);
        }

        [HttpPost("create-prontuario-by-name")]
        public async Task<IActionResult> CreateProntuarioByName(ProntuariosInputModel inputModel)
        {
            var prontuarioViewModel = await _prontuariosService.CriarProntuarioPorNome(inputModel);

            if (prontuarioViewModel == null)
            {
                return BadRequest("Paciente ou médico não encontrado.");
            }

            return Ok(prontuarioViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetByName(string name)
        {
            var prontuariosViewModel = await _prontuariosService.ConsultarProntuarioPorNomeMedico(name);
            return Ok(prontuariosViewModel);
        }


    }
}
