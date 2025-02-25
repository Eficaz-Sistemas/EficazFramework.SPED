using System.Collections.Generic;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;


/// <summary>
/// Identificação das Unidades de Medida
/// </summary>
/// <remarks></remarks>
public class Registro0200 : Primitives.Registro
{
    public Registro0200() : base("0200")
    {
    }

    public Registro0200(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoItem { get; set; } = null; // tamanho 60'
    public string DescricaoItem { get; set; } = null;
    public string CodigoBarra { get; set; } = null;
    public string CodigoItemAnterior { get; set; } = null; // tamanho 60'
    public string UnidadeMedida { get; set; } = null; // tamanho 6'
    public EFD_ICMS_IPI.TipoItem TipoItem { get; set; } = EFD_ICMS_IPI.TipoItem.Outras;
    public string CodigoNCM { get; set; } = null; // tamanho 8'
    public string CodigoEXTIPI { get; set; } = null; // tamanho 3'
    public string CodigoGenero { get; set; } = null; // tamanho 2'
    public string CodigoServicoAnexoI { get; set; } = null; // tamanho 5'
    public double? AliquotaICMSInterno { get; set; }
    public List<Registro0205> Registros0205 { get; set; } = new List<Registro0205>();
    public Registro0206 Registro0206 { get; set; } = null;
    public Registro0208 Registro0208 { get; set; } = null;

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0200|");
        writer.Append(CodigoItem + "|");
        writer.Append(DescricaoItem + "|");
        writer.Append(CodigoBarra + "|");
        writer.Append(CodigoItemAnterior + "|");
        writer.Append(UnidadeMedida + "|");
        // Daniel veja como funciona o string format para dar formato a numeros e datas; "00" estava gerando "0" e o validador recusou
        writer.Append(string.Format("{0:00}", (int)TipoItem) + "|");
        writer.Append(CodigoNCM + "|");
        writer.Append(CodigoEXTIPI + "|");
        writer.Append(CodigoGenero + "|");
        writer.Append(CodigoServicoAnexoI + "|");
        writer.Append(AliquotaICMSInterno + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoItem = data[2];
        DescricaoItem = data[3];
        CodigoBarra = data[4];
        CodigoItemAnterior = data[5];
        UnidadeMedida = data[6];
        TipoItem = (EFD_ICMS_IPI.TipoItem)data[7].ToEnum<EFD_ICMS_IPI.TipoItem>(EFD_ICMS_IPI.TipoItem.Outras);
        CodigoNCM = data[8];
        CodigoEXTIPI = data[9];
        CodigoGenero = data[10];
        CodigoServicoAnexoI = data[11];
        AliquotaICMSInterno = data[12].ToNullableDouble();
    }
}
