
namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Tabela de Cadastro do Participante
    /// </summary>
    /// <remarks></remarks>

    public class Registro0150 : Primitives.Registro
    {
        public Registro0150() : base("0150")
        {
        }

        public Registro0150(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos'
        public string CodigoParticipante { get; set; } = null;
        public string NomeEmpresarial { get; set; } = null;
        public string CodigoPais { get; set; } = null;
        public string CNPJParticipante { get; set; } = null;
        public string CPFParticipante { get; set; } = null;
        public string NitPisPasepSus { get; set; } = null;
        public string UFParticipante { get; set; } = null;
        public string IEParticipante { get; set; } = null;
        public string IESTParticipante { get; set; } = null;
        public string CodMunicipio { get; set; } = null;
        public string InscMunicipal { get; set; } = null;
        public string InscSuframa { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0150|");
            writer.Append(CodigoParticipante + "|");
            writer.Append(NomeEmpresarial + "|");
            writer.Append(CodigoPais + "|");
            writer.Append(CNPJParticipante + "|");
            writer.Append(CPFParticipante + "|");
            writer.Append(NitPisPasepSus + "|");
            writer.Append(UFParticipante + "|");
            writer.Append(IEParticipante + "|");
            writer.Append(IESTParticipante + "|");
            writer.Append(CodMunicipio + "|");
            writer.Append(InscMunicipal + "|");
            writer.Append(InscSuframa + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            CodigoParticipante = data[2];
            NomeEmpresarial = data[3];
            CodigoPais = data[4];
            CNPJParticipante = data[5];
            CPFParticipante = data[6];
            NitPisPasepSus = data[7];
            UFParticipante = data[8];
            IEParticipante = data[9];
            IESTParticipante = data[10];
            CodMunicipio = data[11];
            InscMunicipal = data[12];
            InscSuframa = data[13];
        }
    }
}