namespace ConsultorioMedico
{
    public class Prontuario : EntityBase
    {
        public string TextoProntuario {get; private set;}
        public CadMedicos Medico { get; private set; }
        public CadPacientes Paciente { get; private set; }

        public Prontuario(CadMedicos medico, CadPacientes paciente, string textoProntuario) : base(paciente.Nome, paciente.CPF)
        {
            Medico = medico;
            Paciente = paciente;
            TextoProntuario = textoProntuario;
        }


    }
}
