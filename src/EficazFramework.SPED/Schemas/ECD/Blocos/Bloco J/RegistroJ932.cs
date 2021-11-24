using System;
using EficazFrameworkCore.SPED.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.ECD
{

    /// <summary>
    /// Signatários do Termo de Verificação para Fins de Substituição da ECD
    /// </summary>
    /// <remarks></remarks>

    public class RegistroJ932 : Primitives.Registro
    {
        public RegistroJ932() : base("J932")
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

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|J932|");
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
        }
    }
}