using ConsultorioMedico.Aplicacao.InterfacesServices;

namespace ConsultorioMedico.Aplicacao.InputModels
{
    public class ProntuariosInputModel
    {
        public string Medico { get; set; }
        public string Paciente { get; set; }
        public string TextoProntuario { get; set; }

    }
}
