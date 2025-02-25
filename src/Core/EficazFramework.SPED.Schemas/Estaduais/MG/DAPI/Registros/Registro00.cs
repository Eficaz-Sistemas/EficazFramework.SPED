using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.MG.DAPI;

/// <summary>
/// Identificação da DAPI
/// </summary>
public class Registro00 : Primitives.Registro
{
    public Registro00() : base("00")
    {
    }

    public Registro00(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("00"); // 1 Código Registro
        writer.Append(InscricaoEstadual.ToFixedLenghtString(13, Alignment.Left, "0"));
        writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD)); // 3 Competencia no Formato AAAAMMDD
        writer.Append(DataInicial.ToSintegraString(Extensions.DateFormat.DD)); // 4 Competencia no Formato DD
        writer.Append("D1"); // 5 Front-End DAPI
        if (!DapiSubstituta)
            writer.Append('N');
        else
            writer.Append('S');
        writer.Append("0000000000"); // 7 CAE - Nao utilizar
        writer.Append(RegimeRecolhimento);
        if (!RegimeEspecialFiscalizacao)
            writer.Append('N');
        else
            writer.Append('S');
        if (!RegimeEspecialFiscalizacao)
            writer.Append("00000000");
        else
            writer.Append(DataFinal.ToSintegraString(Extensions.DateFormat.AAAAMMDD));
        if (OptanteFundese)
            writer.Append('S');
        else
            writer.Append('N');
        if (DapiComMovimento)
            writer.Append('S');
        else
            writer.Append('N');
        if (DapiComMovimentoCafe)
            writer.Append('S');
        else
            writer.Append('N');
        writer.Append(CNAE.ToFixedLenghtString(7, Alignment.Left, "0"));
        writer.Append(CNAEDesmembramento.ToFixedLenghtString(2, Alignment.Left, "0"));
        writer.Append(TermoAceite);
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
    }

    public string InscricaoEstadual { get; set; } = null;
    public DateTime? DataFinal { get; set; } = default;
    public DateTime? DataInicial { get; set; } = default;
    public bool DapiSubstituta { get; set; } = false;
    /// <summary>
    /// Valor padrao: 1 - Debito e Credito
    /// 2 - Isento e Imune (nao aplicável)
    /// </summary>
    public int RegimeRecolhimento { get; set; } = 1;
    public bool RegimeEspecialFiscalizacao { get; set; } = false;
    public bool OptanteFundese { get; set; } = false;
    public bool DapiComMovimento { get; set; } = false;
    public bool DapiComMovimentoCafe { get; set; } = false;
    public string CNAE { get; set; } = null;
    public string CNAEDesmembramento { get; set; } = "0";
    public string TermoAceite { get; set; }
}
