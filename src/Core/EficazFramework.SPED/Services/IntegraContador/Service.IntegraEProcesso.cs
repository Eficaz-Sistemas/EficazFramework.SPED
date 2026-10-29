using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraEProcesso;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// EPROCESSO / CONSPROCPORINTER271: consulta todos os processos em que o contribuinte é interessado.
    /// </summary>
    /// <param name="contribuinte">Contribuinte interessado.</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<List<Processo>>> EProcessoConsultarProcessosAsync(
        Identificacao contribuinte,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default) =>
        ExecutarAsync<object, List<Processo>>(Catalogo.EProcesso.ConsultarProcessos, contribuinte, (object?)null, opcoes, ct);
}
