using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR
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
        public string CPF { get; set; } = null;
        public string Nome { get; set; } = null;
        public SituacaoInicioPeriodo IndicadorSitInicioPeriodo { get; set; } = SituacaoInicioPeriodo.Regular;
        public SituacaoEspecial SituacaoEspecial { get; set; } = SituacaoEspecial.Normal;
        public DateTime? DataSituacaoEspecial { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }

        public override string EscreveLinha()
        {
            var writer = new System.Text.StringBuilder();
            writer.Append("0000|LCDPR|"); // 1 e 2
            writer.Append(Versao + "|"); // 3
            writer.Append(CPF + "|"); // 4
            writer.Append(Nome + "|"); // 5
            writer.Append((int)IndicadorSitInicioPeriodo + "|"); // 6
            writer.Append((int)SituacaoEspecial + "|"); // 7
            writer.Append(DataSituacaoEspecial.ToSpedString() + "|"); // 8
            writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DDMMAAAA) + "|"); // 9
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.DDMMAAAA)); // 10
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