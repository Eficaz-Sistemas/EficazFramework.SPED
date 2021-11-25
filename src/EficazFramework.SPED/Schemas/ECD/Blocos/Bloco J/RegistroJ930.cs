using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECD
{

    /// <summary>
    /// Identificação dos Signatários da Escrituração
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ930 : Primitives.Registro
    {
        public RegistroJ930() : base("J930")
        {
        }

        // Campos'
        public string NomeSignatario { get; set; } = null;
        public string CPFOuCNPJ { get; set; } = null;
        public string QualificacaoAssinante { get; set; } = null;
        public string CodigodeQualificacaoAssinante { get; set; } = null;
        public string NumeroInscCRC { get; set; } = null;
        public string EmailSignatario { get; set; } = null;
        public string Fone { get; set; } = null;
        public string UFCRC { get; set; } = null;
        public string NumSequencialCRC { get; set; } = null;
        public DateTime? DataValidCRC { get; set; }
        public string IdentificacaoResponsavel { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J930|");
            writer.Append(NomeSignatario + "|");
            writer.Append(CPFOuCNPJ + "|");
            writer.Append(QualificacaoAssinante + "|");
            writer.Append(CodigodeQualificacaoAssinante + "|");
            writer.Append(NumeroInscCRC + "|");
            writer.Append(EmailSignatario + "|");
            writer.Append(Fone + "|");
            writer.Append(UFCRC + "|");
            writer.Append(NumSequencialCRC + "|");
            writer.Append(DataValidCRC.ToSpedString() + "|");
            writer.Append(IdentificacaoResponsavel + "|");
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            NomeSignatario = data[2];
            CPFOuCNPJ = data[3];
            QualificacaoAssinante = data[4];
            CodigodeQualificacaoAssinante = data[5];
            NumeroInscCRC = data[6];
            EmailSignatario = data[7];
            Fone = data[8];
            UFCRC = data[9];
            NumSequencialCRC = data[10];
            DataValidCRC = data[11].ToDate();
            IdentificacaoResponsavel = data[12];
        }
    }
}