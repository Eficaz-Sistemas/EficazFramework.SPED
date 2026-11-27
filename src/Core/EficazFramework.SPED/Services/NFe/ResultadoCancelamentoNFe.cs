namespace EficazFramework.SPED.Services.NFe;

/// <summary>
/// Resultado do cancelamento de uma NF-e (<see cref="NFeService.CancelamentoAsync"/>).
/// </summary>
/// <param name="Retorno">Retorno do lote de eventos (retEnvEvento), com o cStat / xMotivo do evento em <c>ResultadoEventos</c>.</param>
/// <param name="ProcessoEventoXml">
/// <c>procEventoNFe</c> (evento assinado + retEvento) quando o evento foi homologado (cStat 135 ou 155); <c>null</c> se recusado.
/// </param>
public sealed record ResultadoCancelamentoNFe(Schemas.NFe.RetornoEnvioEvento Retorno, string ProcessoEventoXml)
{
    /// <summary>O evento de cancelamento foi homologado pela SEFAZ.</summary>
    public bool Homologado => ProcessoEventoXml is not null;
}
