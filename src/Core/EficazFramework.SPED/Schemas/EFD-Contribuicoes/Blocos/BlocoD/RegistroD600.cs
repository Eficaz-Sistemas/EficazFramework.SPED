using System;
using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Consolidação da Prestação de Serviços - Notas de Serviço de Comunicação
/// </summary>
/// <remarks></remarks>

public class RegistroD600 : Primitives.Registro
{
    public RegistroD600() : base("D600")
    {
    }

    public RegistroD600(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoModeloDocFiscal { get; set; } = null;
    public string CodigoMunicipioIBGE { get; set; } = null;
    public string SerieDocFiscal { get; set; } = null;
    public string SubSerieDocFiscal { get; set; } = null;
    public IndicadorTipoReceita IndicadorTipoReceita { get; set; } = IndicadorTipoReceita.OutrasReceitas;
    public long? QtdeDocsConsolidadosRegistro { get; set; }
    public DateTime? DataInicialDocsConsolidados { get; set; }
    public DateTime? DataFinalDocsConsolidados { get; set; }
    public double? VrTotalAcumDocsFiscais { get; set; }
    public double? VrAcumDescontos { get; set; }
    public double? VrAcumPrestServTribICMS { get; set; }
    public double? VrAcumPrestServNTribICMS { get; set; }
    public double? VrCobradosTerceiros { get; set; }
    public double? VrAcumDespAcessorias { get; set; }
    public double? VrAcumBCICMS { get; set; }
    public double? VrAcumICMS { get; set; }
    public double? VrPIS { get; set; }
    public double? VrCofins { get; set; }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|D600|");
        writer.Append(CodigoModeloDocFiscal + "|");
        writer.Append(CodigoMunicipioIBGE + "|");
        writer.Append(SerieDocFiscal + "|");
        writer.Append(SubSerieDocFiscal + "|");
        writer.Append(((int)IndicadorTipoReceita).ToString() + "|");
        writer.Append(QtdeDocsConsolidadosRegistro + "|");
        writer.Append(DataInicialDocsConsolidados + "|");
        writer.Append(DataFinalDocsConsolidados + "|");
        writer.Append(VrTotalAcumDocsFiscais + "|");
        writer.Append(VrAcumDescontos + "|");
        writer.Append(VrAcumPrestServTribICMS + "|");
        writer.Append(VrAcumPrestServNTribICMS + "|");
        writer.Append(VrCobradosTerceiros + "|");
        writer.Append(VrAcumDespAcessorias + "|");
        writer.Append(VrAcumBCICMS + "|");
        writer.Append(VrAcumICMS + "|");
        writer.Append(VrPIS + "|");
        writer.Append(VrCofins + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoModeloDocFiscal = data[2];
        CodigoMunicipioIBGE = data[3];
        SerieDocFiscal = data[4];
        SubSerieDocFiscal = data[5];
        IndicadorTipoReceita = (IndicadorTipoReceita)Conversions.ToInteger(data[6]);
        QtdeDocsConsolidadosRegistro = data[7].ToNullableLong();
        DataInicialDocsConsolidados = data[8].ToDate();
        DataFinalDocsConsolidados = data[9].ToDate();
        VrTotalAcumDocsFiscais = data[10].ToNullableDouble();
        VrAcumDescontos = data[11].ToNullableDouble();
        VrAcumPrestServTribICMS = data[12].ToNullableDouble();
        VrAcumPrestServNTribICMS = data[13].ToNullableDouble();
        VrCobradosTerceiros = data[14].ToNullableDouble();
        VrAcumDespAcessorias = data[15].ToNullableDouble();
        VrAcumBCICMS = data[16].ToNullableDouble();
        VrAcumICMS = data[17].ToNullableDouble();
        VrPIS = data[18].ToNullableDouble();
        VrCofins = data[19].ToNullableDouble();
    }
}
