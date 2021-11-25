using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.ECF
{

    /// <summary>
    /// Abertura do Arquivo Digital e Identificação do Empresário ou da Sociedade
    /// </summary>
    /// <remarks></remarks>
    public class Registro0000 : Primitives.Registro
    {
        public Registro0000() : base("0000")
        {
        }

        public Registro0000(string linha, string versao) : base(linha, versao)
        {
        }

        // Campos
        public string CNPJ { get; set; } = null;
        public string NomeEmpresarial { get; set; } = null;
        public SituacaoInicioPeriodo IndicadorSitInicioPeriodo { get; set; } = SituacaoInicioPeriodo.Regular;
        public SituacaoEspecial SituacaoEspecial { get; set; } = SituacaoEspecial.NaoAplicavel;
        public double? PatrimonioRemanescente { get; set; }
        public DateTime? DataSituacaoEspecial { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        /// <summary>
        /// Valores válidos:
        /// S - ECF Retificadora
        /// N - ECF Original
        /// F - ECF Original com mudança de forma de tributação
        /// </summary>
        public bool Retificadora { get; set; } = false;
        public string ReciboRetificacao { get; set; } = null;
        public TipoECF TipoECF { get; set; } = TipoECF.NaoSCP;
        public string CodigoSCP { get; set; } = null;

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("|0000|LECF|"); // 1 e 2
            writer.Append(Versao + "|"); // 3
            writer.Append(CNPJ + "|"); // 4
            writer.Append(NomeEmpresarial + "|"); // 5
            writer.Append((int)IndicadorSitInicioPeriodo + "|"); // 6
            writer.Append((int)SituacaoEspecial + "|"); // 7
            writer.Append(string.Format("{0:F4}", PatrimonioRemanescente) + "|"); // 8
            writer.Append(DataSituacaoEspecial.ToSpedString() + "|"); // 9
            writer.Append(DataInicial.ToSpedString() + "|"); // 10
            writer.Append(DataFinal.ToSpedString() + "|"); // 11
            if (Retificadora)
                writer.Append("S|");
            else
                writer.Append("N|"); // 3
            writer.Append(ReciboRetificacao + "|"); // 13
            writer.Append((int)TipoECF + "|"); // 14
            writer.Append(CodigoSCP + "|"); // 15
            return writer.ToString();
        }

        public override void LeParametros(string[] data)
        {
            // Me.DataInicial = data(3).ToDate
            // Me.DataFinal = data(4).ToDate
            // Me.NomeEmpresarialPJ = data(5)
            // Me.CNPJ = data(6)
            // Me.UF = data(7)
            // Me.IEPj = data(8)
            // Me.CodMunicipio = data(9)
            // Me.InscMunicipal = data(10)
            // Me.IndicadorSitEspecial = data(11)
            // Me.IndicadorSitInicioPeriodo = data(12)
            // Me.IndicadorExistNire = data(13).ToEnum(Of IndicadorExistNire)(IndicadorExistNire.EmpresaPossuiRegistroJunta)
            // Me.IndicadorFinalidadeEscrit = data(14).ToEnum(Of IndicadorFinalidadeEscrit)(IndicadorFinalidadeEscrit.Original)
            // Me.CodigoHash = data(15)
            // Me.IndicadorGrandePorte = data(16).ToEnum(Of IndicadorGrandePorte)(IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria)
            // Me.IndicadorTipoECD = data(17).ToEnum(Of IndicadorTipoECD)(IndicadorTipoECD.ECDempresaNaoParticipanteSCP)
            // Me.IdentificacaoSCP = data(18)
            // If data(19) = "S" Then
            // Me.IdentificacaoMoedaFuncional = True
            // Else
            // Me.IdentificacaoMoedaFuncional = False
            // End If
            // If data(20) = "S" Then
            // Me.EscritContConsolidades = True
            // Else
            // Me.EscritContConsolidades = False
            // End If
        }
    }
}