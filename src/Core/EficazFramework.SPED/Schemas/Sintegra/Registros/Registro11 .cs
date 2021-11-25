using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.Sintegra;

public class Registro11 : Primitives.Registro
{
    public Registro11(string linha, string versao) : base(linha, versao)
    {
    }

    public Registro11() : base("11")
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("11"); // 1
        writer.Append(Logradouro.ToFixedLenghtString(34, Escrituracao._builder, Alignment.Right, " ")); // 2
        writer.Append(Numero.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 3
        writer.Append(Complemento.ToFixedLenghtString(22, Escrituracao._builder, Alignment.Right, " ")); // 4
        writer.Append(Bairro.ToFixedLenghtString(15, Escrituracao._builder, Alignment.Right, " ")); // 5
        writer.Append(CEP.ToFixedLenghtString(8, Escrituracao._builder, Alignment.Left, "0")); // 6
        writer.Append(NomeContato.ToFixedLenghtString(28, Escrituracao._builder, Alignment.Right, " ")); // 7
        writer.Append(Telefone.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 7
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        Logradouro = linha.Substring(2, 34).Trim();
        Numero = linha.Substring(36, 5).Trim();
        Complemento = linha.Substring(41, 22).Trim();
        Bairro = linha.Substring(63, 15).Trim();
        CEP = linha.Substring(78, 8).Trim();
        NomeContato = linha.Substring(86, 28).Trim();
        NomeContato = linha.Substring(114, 12).Trim();
    }

    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string CEP { get; set; }
    public string NomeContato { get; set; }
    public string Telefone { get; set; }
}
