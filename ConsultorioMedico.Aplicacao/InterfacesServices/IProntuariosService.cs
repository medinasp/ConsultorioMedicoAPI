using ConsultorioMedico.Aplicacao.InputModels;
using ConsultorioMedico.Aplicacao.ViewModels;

namespace ConsultorioMedico.Aplicacao.InterfacesServices
{
    public interface IProntuariosService
    {
        Task<ProntuariosViewModel> CriarProntuario(ProntuariosInputModel model);
        Task<ProntuariosViewModel> ConsultarProntuarioPorIdMedico(string code);
        Task<ProntuariosViewModel> ConsultarProntuarioPorIdPaciente(string code);
        Task<bool> EditarProntuario(string id, ProntuariosInputModel model);
        Task<bool> RemoverProntuarioSoft(string id);
        Task<bool> RemoverProntuarioHard(string id);

    }
}
