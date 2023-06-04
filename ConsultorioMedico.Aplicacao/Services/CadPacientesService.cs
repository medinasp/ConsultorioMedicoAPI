using ConsultorioMedico.Aplicacao.InputModels;
using ConsultorioMedico.Aplicacao.InterfacesServices;
using ConsultorioMedico.Aplicacao.ViewModels;

namespace ConsultorioMedico.Aplicacao.Services
{
    public class CadPacientesService : ICadPacientesService
    {
        private static readonly List<CadPacientes> _cadPacientesList = new List<CadPacientes>();

        public async Task<CadPacientesViewModel> Add(CadPacientesInputModel model)
        {
            var cadPacientes = model.ToEntity();
            _cadPacientesList.Add(cadPacientes);

            var viewModel = new CadPacientesViewModel
            {
                Id = cadPacientes.Id,
                Nome = cadPacientes.Nome,
                CPF = cadPacientes.CPF
            };
            return await Task.FromResult(viewModel);

        }

        public async Task<IEnumerable<CadPacientesViewModel>> GetActives()
        {
            var activeCadPacientes = _cadPacientesList.Where(m => m.Ativo);
            var viewModels = activeCadPacientes.Select(m => new CadPacientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<IEnumerable<CadPacientesViewModel>> GetAll()
        {
            var viewModels = _cadPacientesList.Select(m => new CadPacientesViewModel
            {
                Id = m.Id,
                Nome = m.Nome,
                CPF = m.CPF
            });

            return await Task.FromResult(viewModels);
        }

        public async Task<CadPacientesViewModel> GetByCode(string code)
        {
            if (!Guid.TryParse(code, out var guid))
                return null;

            var cadPacientes = _cadPacientesList.FirstOrDefault(m => m.Id == guid);
            if (cadPacientes == null)
                return null;

            var cadPacientesViewModel = new CadPacientesViewModel
            {
                Id = cadPacientes.Id,
                Nome = cadPacientes.Nome,
                CPF = cadPacientes.CPF
            };

            return await Task.FromResult(cadPacientesViewModel);
        }

        public async Task<bool> HardDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadPacientes = _cadPacientesList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadPacientes == null)
                return false;

            _cadPacientesList.Remove(cadPacientes);

            return true;

        }

        public async Task<bool> SoftDelete(string id)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadPacientes = _cadPacientesList.FirstOrDefault(m => m.Id == guid && m.Ativo);
            if (cadPacientes == null)
                return false;

            cadPacientes.Excluir();

            return true;
        }

        public async Task<bool> Update(string id, CadPacientesInputModel model)
        {
            if (!Guid.TryParse(id, out var guid))
                return false;

            var cadPacientes = _cadPacientesList.FirstOrDefault(m => m.Id.ToString() == id);

            if (cadPacientes == null)
                return false;

            cadPacientes.Update(model.Nome, model.CPF);
            return true;
        }
    }

}
