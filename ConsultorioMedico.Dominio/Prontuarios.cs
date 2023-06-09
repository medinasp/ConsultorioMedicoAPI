namespace ConsultorioMedico
{
    public class Prontuarios : EntityBase
    {
        public string TextoProntuario {get; private set;}
        public CadMedicos Medico { get; private set; }
        public CadPacientes Paciente { get; private set; }

        public Prontuarios(CadMedicos medico, CadPacientes paciente, string textoProntuario) : base(paciente.Nome, paciente.CPF)
        {
            Medico = medico;
            Paciente = paciente;
            TextoProntuario = textoProntuario;
        }

        public void Excluir()
        {
            Ativo = false;
        }

        public void Update(string textoProntuario)
        {
            TextoProntuario = textoProntuario;
        }

    }
}
