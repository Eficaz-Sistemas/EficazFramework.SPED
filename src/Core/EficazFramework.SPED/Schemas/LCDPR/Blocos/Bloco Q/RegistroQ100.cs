using System;
using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.LCDPR;

/// <summary>
/// Demonstração da Atividade Rural
/// </summary>
/// <remarks>
/// Nível hierárquico - 2 <br/>
/// Ocorrência - 0:N
/// </remarks>
/// <registrosped/>
/// <example>
/// ```csharp
/// string _versao = "0013";
/// var regQ100 = new RegistroQ100(null, _versao)
/// {
///     DataMov = new System.DateTime(2021, 1, 1),
///     CodImovel = 1,
///     CodigoContaBanco = 1,
///     NumeroDoc = "123456",
///     TipoDocumento = TipoDocumento.NF,
///     Historico = "Pg. ref. aquisição de fertilizantes",
///     TerceiroID = "12345678900",
///     TipoLancamento = TipoLancamento.Despesa,
///     ValorSaida = 500d,
///     SaldoFinal = 500d,
///     SaldoFinal_Natureza = "N"
/// };
/// ```
/// </example>
public class RegistroQ100 : Primitives.Registro
{
    /// <exclude />
    public RegistroQ100() : base("Q100")
    {
    }

    /// <exclude />
    public RegistroQ100(string linha, string versao) : base(linha, versao)
    {
    }

    /// <inheritdoc/>
    public override string EscreveLinha()
    {
        var writer = new System.Text.StringBuilder();
        writer.Append("Q100|"); // 1
        writer.Append(DataMov.ToSpedString() + "|");  // 2
        writer.Append(CodImovel + "|");  // 3
        writer.Append(CodigoContaBanco + "|"); // 4
        writer.Append(NumeroDoc + "|"); // 5
        writer.Append((int)TipoDocumento + "|"); // 6
        writer.Append(Historico + "|"); // 7
        writer.Append(TerceiroID + "|"); // 8
        writer.Append((int)TipoLancamento + "|"); // 9
        writer.Append(ValorEntrada.ValueToString(2) + "|"); // 10
        writer.Append(ValorSaida.ValueToString(2) + "|"); // 11
        writer.Append(SaldoFinal.ValueToString(2) + "|"); // 12
        writer.Append(SaldoFinal_Natureza); // 13
        return writer.ToString();
    }

    /// <inheritdoc/>
    public override void LeParametros(string[] data)
    {
        DataMov = data[1].ToDate();
        CodImovel = data[2].ToNullableInteger();
        CodigoContaBanco = data[3];
        NumeroDoc = data[4];
        TipoDocumento = (TipoDocumento)data[5].ToEnum<TipoDocumento>(TipoDocumento.NF);
        Historico = data[6];
        TerceiroID = data[7];
        TipoLancamento = (TipoLancamento)data[8].ToEnum<TipoLancamento>(TipoLancamento.Despesa);
        ValorEntrada = data[9].ToNullableDouble();
        ValorSaida = data[10].ToNullableDouble();
        SaldoFinal = data[11].ToNullableDouble();
        SaldoFinal_Natureza = data[12];
    }

    /// <summary>
    /// Data de Entrada ou Saída dos Recursos
    /// </summary>
    public DateTime? DataMov { get; set; } = default;

    /// <summary>
    /// Código do Imóvel em <see cref="Registro0040.IDImovel"/>
    /// </summary>
    public int? CodImovel { get; set; } = default;

    /// <summary>
    /// Código da Conta Bancária em <see cref="Registro0050.CodigoContaBanco"/> <br/>
    /// Para pagamentos ou recebimentos em espécie, utilizar 000. <br/>
    /// Para numerários em trânsito, utilizar 999.
    /// </summary>
    public string CodigoContaBanco { get; set; } = null;

    /// <summary>
    /// Número do Documento
    /// </summary>
    public string NumeroDoc { get; set; } = "BR";

    /// <summary>
    /// Tipo de Documento: <br/>
    /// 1 - Nota Fiscal <br/>
    /// 2 – Fatura <br/>
    /// 3 – Recibo <br/>
    /// 4 – Contrato <br/>
    /// 5 - Folha de Pagamento <br/>
    /// 6 - Outros
    /// </summary>
    public TipoDocumento TipoDocumento { get; set; } = TipoDocumento.NF;

    /// <summary>
    /// Histórico do Lançamento
    /// </summary>
    public string Historico { get; set; } = null;

    /// <summary>
    /// CPF ou CNPJ do Terceiro. <br/>
    /// Caso <see cref="TipoDocumento"/> = <see cref="TipoDocumento.FolhaPagto"/>,
    /// utilizar o CPF do próprio declarante.
    /// </summary>
    public string TerceiroID { get; set; } = null;

    /// <summary>
    /// Tipo de Lançamento; <br/>
    /// 1 - Receita da Atividade Rural <br/>
    /// 2 - Despesas de custeio e investimentos <br/>
    /// 3 – Receita de produtos entregues no ano referente a adiantamento de recursos financeiro
    /// </summary>
    public TipoLancamento TipoLancamento { get; set; } = TipoLancamento.Despesa;

    /// <summary>
    /// Valor de Entrada dos Recursos
    /// </summary>
    public double? ValorEntrada { get; set; } = default;

    /// <summary>
    /// Valor de Saída dos Recursos
    /// </summary>
    public double? ValorSaida { get; set; } = default;

    /// <summary>
    /// Saldo Final
    /// </summary>
    public double? SaldoFinal { get; set; } = default;

    /// <summary>
    /// Natureza do Saldo Final [N/P]
    /// </summary>
    public string SaldoFinal_Natureza { get; set; } = null;
}
