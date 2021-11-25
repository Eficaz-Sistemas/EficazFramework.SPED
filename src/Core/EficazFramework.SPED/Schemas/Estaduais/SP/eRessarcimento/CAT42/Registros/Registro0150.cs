using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.SP.eRessarcimento.CAT42;

/// <summary>
/// Tabela de Cadastro do Participante
/// </summary>
/// <remarks></remarks>
public class Registro0150 : Primitives.Registro
{
    public string ID { get; set; }
    public string ID_CAE { get; set; }

    public string PK_TXT
    {
        get
        {
            if (!string.IsNullOrEmpty(CNPJ))
                return CNPJ;
            if (!string.IsNullOrEmpty(CPF))
                return CPF;
            return Nome;
        }
    }

    public string Nome { get; set; }
    public int CodigoPais { get; set; }
    public string CNPJ { get; set; }
    public string CPF { get; set; }
    public string InscricaoEstadual { get; set; }
    public string CodigoMunicipio { get; set; }

    public Registro0150() : base("0150")
    {
    }

    public Registro0150(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("0150|"); // texto fixo
        writer.Append(ID + "|");
        writer.Append(Nome.RemoveAccents() + "|");
        writer.Append(string.Format("{0:0000}", CodigoPais) + "|"); // 05 dígitos
        writer.Append(CNPJ + "|");
        writer.Append(CPF + "|");
        writer.Append(InscricaoEstadual + "|");
        writer.Append(string.Format("{0:0000000}", CodigoMunicipio)); // 07 dígitos
        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
    }
}
