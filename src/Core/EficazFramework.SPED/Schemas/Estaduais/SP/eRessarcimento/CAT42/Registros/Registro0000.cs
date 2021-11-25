using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42;

/// <summary>
/// Abertura do Arquivo Digital e Identificação do Contribuinte
/// </summary>
/// <remarks></remarks>
public class Registro0000 : Primitives.Registro
{
    public DateTime? Periodo { get; set; }
    public string RazaoSocial { get; set; }
    public string CNPJ { get; set; }
    public string InscricaoEstadual { get; set; }
    public string CodigoMunicipio { get; set; }
    public VersaoLayout VersaoLayout { get; set; } = VersaoLayout.versao_1100;
    public Finalidade Finalidade { get; set; } = Finalidade.RemessaRegular;

    public Registro0000() : base("0000")
    {
    }

    public Registro0000(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0000|");
        writer.Append(string.Format("{0:MMyyyy}", Periodo) + "|");
        writer.Append(RazaoSocial.RemoveAccents() + "|");
        writer.Append(CNPJ + "|");
        writer.Append(InscricaoEstadual + "|");
        writer.Append(CodigoMunicipio + "|");
        writer.Append(string.Format("{0:00}", (int)VersaoLayout) + "|");
        writer.Append(string.Format("{0:00}", (int)Finalidade));
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
