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

        public ProntuariosService(ICadPacientesService cadPacientesService, ICadMedicosService cadMedicosService)
        {
            _cadPacienteService = cadPacientesService;
            _cadMedicoService = cadMedicosService;
        }

        public async Task<ProntuariosViewModel> CriarProntuarioPorId(ProntuariosInputModel model)
        {
            var pacientes = await _cadPacienteService.GetAll();
            var medicos = await _cadMedicoService.GetAll();

            var pacienteViewModel = pacientes.FirstOrDefault(p => p.Nome == model.Paciente);
            var pacienteViewModelByCode = pacientes.FirstOrDefault(p => p.Id == Guid.Parse(model.Paciente));

            var medicoViewModel = medicos.FirstOrDefault(m => m.Nome == model.Medico);

            if (pacienteViewModelByCode == null || medicoViewModel == null)
            {
                return null; // Tratar o caso em que o paciente ou médico não foi encontrado
            }

            var paciente = new CadPacientes(pacienteViewModelByCode.Nome, pacienteViewModelByCode.CPF);
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

        public async Task<ProntuariosViewModel> CriarProntuarioPoNome(ProntuariosInputModel model)
        {
            var pacientes = await _cadPacienteService.GetAll();
            var medicos = await _cadMedicoService.GetAll();

            var pacienteViewModel = pacientes.FirstOrDefault(p => p.Nome == model.Paciente);
            var pacienteViewModelByCode = pacientes.FirstOrDefault(p => p.Id == Guid.Parse(model.Paciente));

            var medicoViewModel = medicos.FirstOrDefault(m => m.Nome == model.Medico);

            if (pacienteViewModelByCode == null || medicoViewModel == null)
            {
                return null; // Tratar o caso em que o paciente ou médico não foi encontrado
            }

            var paciente = new CadPacientes(pacienteViewModelByCode.Nome, pacienteViewModelByCode.CPF);
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
