using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.CNAB240;

/// <summary>
/// Registro de Header de Arquivo
/// </summary>
public class Registro0 : Primitives.Registro
{
    public Registro0() : base("0")
    {
    }

    public Registro0(string linha, string versao) : base(linha, versao)
    {
    }

    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        // writer.Append("10") '1
        writer.Append(CodigoBanco.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 1
        writer.Append(LoteDeServico.ToFixedLenghtString(4, Escrituracao._builder, Alignment.Left, "0")); // 2
        writer.Append('0'); // 3
        writer.Append("      "); // 4
        if (CodigoBanco == "341") // ITAU (unico ate agora que discrimimna a versao
        {
            writer.Append(VersaoLayoutArquivo.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 5
        }
        else
        {
            writer.Append("   ");
        }

        writer.Append(TipoInscricao.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Right, " ")); // 6
        writer.Append(CNPJ.ToFixedLenghtString(14, Escrituracao._builder, Alignment.Right, " ")); // 7
        writer.Append(Convenio.ToFixedLenghtString(20, Escrituracao._builder, Alignment.Right, " ")); // 8
        writer.Append(Agencia.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 12
        writer.Append(AgenciaDV.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, " ")); // 13
        writer.Append(Conta.ToFixedLenghtString(12, Escrituracao._builder, Alignment.Left, "0")); // 14
        writer.Append(ContaDV.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, " ")); // 15
        writer.Append(DAC.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 16
        writer.Append(NomeEmpresa.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 14
        writer.Append(NomeBanco.ToFixedLenghtString(30, Escrituracao._builder, Alignment.Right, " ")); // 15
        writer.Append("          "); // 16
        writer.Append(ArquivoCodigo.ToFixedLenghtString(1, Escrituracao._builder, Alignment.Left, "0")); // 17
        writer.Append(DataGeracaoArquivo.ToSintegraString(Extensions.DateFormat.DDMMAAAA)); // 18
        writer.Append(HoraGeracaoArquivo.ToSintegraString(TimeFormat.HHMMSS)); // 19
        writer.Append(NumeroSequencialArquivo.ToFixedLenghtString(6, Escrituracao._builder, Alignment.Left, "0")); // 20
        writer.Append(VersaoCNAB.ToFixedLenghtString(3, Escrituracao._builder, Alignment.Left, "0")); // 21
        writer.Append(UnidadeDensidade.ToFixedLenghtString(5, Escrituracao._builder, Alignment.Left, "0")); // 22
        if (CodigoBanco != "001")
        {
            writer.Append("".ToFixedLenghtString(69, Escrituracao._builder, Alignment.Right, " ")); // 23
        }
        else
        {
            writer.Append("".ToFixedLenghtString(54, Escrituracao._builder, Alignment.Right, " ")); // 23
            writer.Append("000000000000000");
        } // 23 Banco do Brasil nao aceita brancos, precisa preencher com zeros

        return writer.ToString();
    }

    public override void LeParametros(string[] data)
    {
        string linha = data[0];
        CodigoBanco = linha[..3].Trim();
        LoteDeServico = linha.Substring(3, 4).Trim();
        VersaoLayoutArquivo = linha.Substring(14, 3).Trim();
        TipoInscricao = linha.Substring(17, 1).Trim();
        CNPJ = linha.Substring(18, 14).Trim();
        Convenio = linha.Substring(32, 20).Trim();
        Agencia = linha.Substring(52, 5).Trim();
        Conta = linha.Substring(58, 12).Trim();
        DAC = linha.Substring(71, 1).Trim();
        NomeEmpresa = linha.Substring(72, 30).Trim();
        NomeBanco = linha.Substring(102, 30).Trim();
        ArquivoCodigo = linha.Substring(142, 1).Trim();
        DataGeracaoArquivo = linha.Substring(143, 8).Trim().ToDate(Extensions.DateFormat.DDMMAAAA);
        HoraGeracaoArquivo = linha.Substring(151, 6).Trim().ToTime(TimeFormat.HHMMSS);
        UnidadeDensidade = linha.Substring(166, 5).Trim();
    }

    public string CodigoBanco { get; set; }
    public string LoteDeServico { get; set; } = "0000";
    public string VersaoLayoutArquivo { get; set; } = "104";
    /// <summary>
    /// 1 = CPF
    /// 2 = CNPJ [Default]
    /// </summary>
    public string TipoInscricao { get; set; } = "2";
    public string CNPJ { get; set; }
    public string Convenio { get; set; }
    public string Agencia { get; set; }
    public string AgenciaDV { get; set; }
    public string Conta { get; set; }
    public string ContaDV { get; set; }
    public string DAC { get; set; }
    public string NomeEmpresa { get; set; }
    public string NomeBanco { get; set; }
    /// <summary>
    /// 1 = Remessa [Default]
    /// 2 = Retorno
    /// </summary>
    public string ArquivoCodigo { get; set; } = "1";
    public DateTime? DataGeracaoArquivo { get; set; }
    public TimeSpan? HoraGeracaoArquivo { get; set; }
    public string NumeroSequencialArquivo { get; set; } = "000000";
    public string VersaoCNAB { get; set; } = "103";
    public string UnidadeDensidade { get; set; } = "00000";
}
