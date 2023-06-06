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

        [HttpPost]
        public async Task<IActionResult> CreateProntuario(ProntuariosInputModel inputModel)
        {
            var prontuarioViewModel = await _prontuariosService.CriarProntuario(inputModel);

            if (prontuarioViewModel == null)
            {
                return BadRequest("Paciente ou médico não encontrado.");
            }

            return Ok(prontuarioViewModel);
        }
    }
}
