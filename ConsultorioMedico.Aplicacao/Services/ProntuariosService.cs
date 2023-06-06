using ConsultorioMedico.Aplicacao.InputModels;
using ConsultorioMedico.Aplicacao.InterfacesServices;
using ConsultorioMedico.Aplicacao.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultorioMedico.Aplicacao.Services
{
    public class ProntuariosService : IProntuariosService
    {

        private readonly ICadPacientesService _cadPacienteService;
        private readonly ICadMedicosService _cadMedicoService;
        private static readonly List<CadPacientes> _cadPacientesList = new List<CadPacientes>();

        public ProntuariosService(ICadPacientesService cadPacientesService, ICadMedicosService cadMedicosService)
        {
            _cadPacienteService = cadPacientesService;
            _cadMedicoService = cadMedicosService;
        }

        public async Task<ProntuariosViewModel> CriarProntuario(ProntuariosInputModel model)
        {
            var pacienteViewModel = await _cadPacienteService.GetByCode(model.Paciente);
            var medicoViewModel = await _cadMedicoService.GetByCode(model.Medico);
            var cadPacientes = _cadPacientesList.FirstOrDefault(m => m.Nome == model.Paciente);

            if (pacienteViewModel == null || medicoViewModel == null)
            {
                return null; // Tratar o caso em que o paciente ou médico não foi encontrado
            }

            var paciente = new CadPacientes(pacienteViewModel.Nome, pacienteViewModel.CPF);
            var medico = new CadMedicos(medicoViewModel.Nome, medicoViewModel.CPF, medicoViewModel.Especialidade);

            var prontuario = new Prontuarios(medico, paciente, model.TextoProntuario);

            var prontuarioViewModel = new ProntuariosViewModel
            {
                IdPaciente = paciente.Id,
                NomePaciente = paciente.Nome,
                CPFPaciente = paciente.CPF,
                IdMedico = medico.Id,
                NomeMedico = medico.Nome,
                CPFMedico = medico.CPF,
                EspecialidadeMedico = medico.Especialidade,
                TextoProntuario = prontuario.TextoProntuario
            };

            return prontuarioViewModel;
        }


        public Task<ProntuariosViewModel> ConsultarProntuarioPorIdMedico(string code)
        {
            throw new NotImplementedException();
        }

        public Task<ProntuariosViewModel> ConsultarProntuarioPorIdPaciente(string code)
        {
            throw new NotImplementedException();
        }

        public Task<bool> EditarProntuario(string id, ProntuariosInputModel model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverProntuarioHard(string id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> RemoverProntuarioSoft(string id)
        {
            throw new NotImplementedException();
        }
    }
}
