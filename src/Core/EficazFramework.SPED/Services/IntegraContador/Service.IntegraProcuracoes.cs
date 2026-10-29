using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraProcuracoes;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// PROCURACOES / OBTERPROCURACAO41: obtém as procurações eletrônicas entre o outorgante e o outorgado (procurador),
    /// com a data de expiração e os sistemas de cada uma.
    /// </summary>
    /// <param name="contribuinte">Contribuinte da requisição.</param>
    /// <param name="dados">Outorgante e outorgado (ver <see cref="ObterProcuracao.Criar"/>).</param>
    /// <param name="opcoes">Opções da requisição.</param>
    /// <param name="ct">Token de cancelamento.</param>
    /// <exception cref="ArgumentNullException">Dados de entrada não informados.</exception>
    public virtual Task<RespostaIntegraContador<List<Procuracao>>> ProcuracoesObterAsync(
        Identificacao contribuinte,
        ObterProcuracao dados,
        OpcoesRequisicao? opcoes = null,
        CancellationToken ct = default)
    {
        if (dados is null)
            throw new ArgumentNullException(nameof(dados), "O outorgante e o outorgado não foram informados.");

        return ExecutarAsync<ObterProcuracao, List<Procuracao>>(Catalogo.Procuracoes.ObterProcuracao, contribuinte, dados, opcoes, ct);
    }
}
