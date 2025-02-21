using System.Collections.Generic;

namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes;

/// <summary>
/// Tabela de Cadastro de Estabelecimento
/// </summary>
/// <remarks></remarks>

public class Registro0140 : Primitives.Registro
{
    public Registro0140() : base("0140")
    {
    }

    public Registro0140(string linha, string versao) : base(linha, versao)
    {
    }

    // Campos'
    public string CodigoEstabelecimento { get; set; } = null; // tamanho 60'
    public string NomeEmpresarial { get; set; } = null; // tamanho 100'
    public string CNPJ { get; set; } = null;  // tamanho 14'
    public string UF { get; set; } = null; // tamanho 2'
    public string IE { get; set; } = null; // tamanho 14'
    public string CodicoMunicipioIBGE { get; set; } = null; // tamanho 7'
    public string InscricaoMunicipal { get; set; } = null;
    public string SUFRAMA { get; set; } = null;
    public Registro0145 Registro0145 { get; set; } = null;
    public List<Registro0150> Registros0150 { get; set; } = new List<Registro0150>();
    public List<Registro0190> Registros0190 { get; set; } = new List<Registro0190>();
    public List<Registro0200> Registros0200 { get; set; } = new List<Registro0200>();
    public List<Registro0400> Registros0400 { get; set; } = new List<Registro0400>();
    public List<Registro0450> Registros0450 { get; set; } = new List<Registro0450>();

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0140|");
        writer.Append(CodigoEstabelecimento + "|");
        writer.Append(NomeEmpresarial + "|");
        writer.Append(CNPJ + "|");
        writer.Append(UF + "|");
        writer.Append(IE + "|");
        writer.Append(CodicoMunicipioIBGE + "|");
        writer.Append(InscricaoMunicipal + "|");
        writer.Append(SUFRAMA + "|");
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        CodigoEstabelecimento = data[2];
        NomeEmpresarial = data[3];
        CNPJ = data[4];
        UF = data[5];
        IE = data[6];
        CodicoMunicipioIBGE = data[7];
        InscricaoMunicipal = data[8];
        SUFRAMA = data[9];
    }
}
