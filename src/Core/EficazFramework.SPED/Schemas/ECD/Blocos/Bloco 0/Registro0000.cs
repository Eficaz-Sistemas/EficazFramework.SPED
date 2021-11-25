using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.ECD;

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
    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; }
    public string NomeEmpresarialPJ { get; set; } = null;
    public string CNPJ { get; set; } = null;
    public string UF { get; set; } = null;
    public string IEPj { get; set; } = null;
    public string CodMunicipio { get; set; } = null;
    public string InscMunicipal { get; set; } = null;
    public string IndicadorSitEspecial { get; set; } = null;
    public string IndicadorSitInicioPeriodo { get; set; } = null;
    public IndicadorExistNire IndicadorExistNire { get; set; } = IndicadorExistNire.EmpresaPossuiRegistroJunta;
    public IndicadorFinalidadeEscrit IndicadorFinalidadeEscrit { get; set; } = IndicadorFinalidadeEscrit.Original;
    public string CodigoHash { get; set; } = null;
    public IndicadorGrandePorte IndicadorGrandePorte { get; set; } = IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria;
    public IndicadorTipoECD IndicadorTipoECD { get; set; } = IndicadorTipoECD.ECDempresaNaoParticipanteSCP;
    public string IdentificacaoSCP { get; set; } = null;
    public bool IdentificacaoMoedaFuncional { get; set; } = false;
    public bool EscritContConsolidades { get; set; } = false;
    // layout 8.00
    public bool IndicadorCentralizada { get; set; } = false;
    public bool IndicadorMudancaPlanoContas { get; set; } = false;
    public int CodigoPlanoContasReferencial { get; set; } = default;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0000|LECD|");
        writer.Append(DataInicial.ToSpedString() + "|");
        writer.Append(DataFinal.ToSpedString() + "|");
        writer.Append(NomeEmpresarialPJ + "|");
        writer.Append(CNPJ + "|");
        writer.Append(UF + "|");
        writer.Append(IEPj + "|");
        writer.Append(CodMunicipio + "|");
        writer.Append(InscMunicipal + "|");
        writer.Append(IndicadorSitEspecial + "|");
        writer.Append(IndicadorSitInicioPeriodo + "|");
        writer.Append(((int)IndicadorExistNire).ToString() + "|");
        writer.Append(((int)IndicadorFinalidadeEscrit).ToString() + "|");
        writer.Append(CodigoHash + "|");
        writer.Append(((int)IndicadorGrandePorte).ToString() + "|");
        writer.Append(((int)IndicadorTipoECD).ToString() + "|");
        writer.Append(IdentificacaoSCP + "|");
        if (IdentificacaoMoedaFuncional == true)
            writer.Append("S|");
        else
            writer.Append("N|");
        if (EscritContConsolidades == true)
            writer.Append("S|");
        else
            writer.Append("N|");
        if (Conversions.ToInteger(Versao) / 100d >= 8d)
        {
            if (IndicadorCentralizada == true)
                writer.Append("0|");
            else
                writer.Append("1|");
            if (IndicadorMudancaPlanoContas == true)
                writer.Append("1|");
            else
                writer.Append("0|");
            writer.Append(CodigoPlanoContasReferencial + "|");
        }

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        DataInicial = data[3].ToDate();
        DataFinal = data[4].ToDate();
        NomeEmpresarialPJ = data[5];
        CNPJ = data[6];
        UF = data[7];
        IEPj = data[8];
        CodMunicipio = data[9];
        InscMunicipal = data[10];
        IndicadorSitEspecial = data[11];
        IndicadorSitInicioPeriodo = data[12];
        IndicadorExistNire = (IndicadorExistNire)data[13].ToEnum<IndicadorExistNire>(IndicadorExistNire.EmpresaPossuiRegistroJunta);
        IndicadorFinalidadeEscrit = (IndicadorFinalidadeEscrit)data[14].ToEnum<IndicadorFinalidadeEscrit>(IndicadorFinalidadeEscrit.Original);
        CodigoHash = data[15];
        IndicadorGrandePorte = (IndicadorGrandePorte)data[16].ToEnum<IndicadorGrandePorte>(IndicadorGrandePorte.EmpresaNaoSujeitaAuditoria);
        IndicadorTipoECD = (IndicadorTipoECD)data[17].ToEnum<IndicadorTipoECD>(IndicadorTipoECD.ECDempresaNaoParticipanteSCP);
        IdentificacaoSCP = data[18];
        if (data[19] == "S")
            IdentificacaoMoedaFuncional = true;
        else
            IdentificacaoMoedaFuncional = false;
        if (data[20] == "S")
            EscritContConsolidades = true;
        else
            EscritContConsolidades = false;
        int result = 0;
        if (int.TryParse(Versao, out result) == false)
            return;
        if (Conversions.ToInteger(Versao) / 100d >= 8d)
        {
            if (data[21] == "0")
                IndicadorCentralizada = true;
            else
                EscritContConsolidades = false;
            if (data[22] == "1")
                IndicadorMudancaPlanoContas = true;
            else
                EscritContConsolidades = false;
            CodigoPlanoContasReferencial = (int)data[23].ToNullableInteger();
        }
    }
}
