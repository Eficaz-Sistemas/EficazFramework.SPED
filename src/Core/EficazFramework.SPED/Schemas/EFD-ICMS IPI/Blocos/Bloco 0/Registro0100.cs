
namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

/// <summary>
/// Dados do Contabilista
/// </summary>
/// <remarks></remarks>
public class Registro0100 : Primitives.Registro
{
    public Registro0100() : base("0100")
    {
    }

    public Registro0100(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("|0100|"); // 1
        writer.Append(Nome + "|"); // 2
        writer.Append(CPF + "|"); // 3
        writer.Append(CRC + "|"); // 4
        writer.Append(CNPJ + "|"); // 5
        writer.Append(CEP + "|"); // 6
        writer.Append(Endereco + "|"); // 7
        writer.Append(Numero + "|"); // 8
        writer.Append(Complemento + "|"); // 9
        writer.Append(Bairro + "|"); // 10
        writer.Append(Fone + "|"); // 11
        writer.Append(Fax + "|"); // 12
        writer.Append(eMail + "|"); // 13
        writer.Append(CodigoMunicipio + "|"); // 14
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        Nome = data[2];
        CPF = data[3];
        CRC = data[4];
        CNPJ = data[5];
        CEP = data[6];
        Endereco = data[7];
        Numero = data[8];
        Complemento = data[9];
        Bairro = data[10];
        Fone = data[11];
        Fax = data[12];
        eMail = data[13];
        CodigoMunicipio = data[14];
    }

    public string Nome { get; set; } = null;
    public string CPF { get; set; } = null;
    public string CRC { get; set; } = null;
    public string CNPJ { get; set; } = null;
    public string CEP { get; set; } = null;
    public string Endereco { get; set; } = null;
    public string Numero { get; set; } = null;
    public string Complemento { get; set; } = null;
    public string Bairro { get; set; } = null;
    public string Fone { get; set; } = null;
    public string Fax { get; set; } = null;
    public string eMail { get; set; } = null;
    public string CodigoMunicipio { get; set; } = null;
}
