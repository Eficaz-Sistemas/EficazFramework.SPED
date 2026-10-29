namespace EficazFramework.SPED.Schemas.IntegraContador;

/// <summary>
/// Tipo do número de identificação (NI) de contratante, autor do pedido de dados ou contribuinte.
/// </summary>
public enum TipoIdentificacao
{
    /// <summary>1 - CPF (11 dígitos).</summary>
    CPF = 1,
    /// <summary>2 - CNPJ (14 dígitos). Obrigatório para o contratante.</summary>
    CNPJ = 2,
    /// <summary>3 - Lote de CPFs separados por vírgula (Eventos de Atualização PF).</summary>
    LotePF = 3,
    /// <summary>4 - Lote de CNPJs separados por vírgula (Eventos de Atualização PJ).</summary>
    LotePJ = 4
}

/// <summary>
/// Endpoints (rotas POST) da API Integra Contador.
/// </summary>
public enum TipoEndpoint
{
    /// <summary>/Apoiar - serviços de apoio (ex.: AUTENTICAPROCURADOR, SITFIS protocolo). Não tarifado.</summary>
    Apoiar,
    /// <summary>/Consultar - consultas.</summary>
    Consultar,
    /// <summary>/Declarar - transmissão de declarações.</summary>
    Declarar,
    /// <summary>/Emitir - emissão de documentos (DAS, DARF, relatórios).</summary>
    Emitir,
    /// <summary>/Monitorar - monitoramento de eventos. Não tarifado.</summary>
    Monitorar
}

/// <summary>
/// Ambiente da API Integra Contador.
/// </summary>
public enum Ambiente
{
    /// <summary>Produção (gateway.apiserpro.serpro.gov.br/integra-contador).</summary>
    Producao,
    /// <summary>Demonstração (integra-contador-trial): token fixo, dados fictícios dos cenários de teste.</summary>
    Trial
}

/// <summary>
/// Modalidades de parcelamento do Simples Nacional e do MEI (Integra-Parcelamento).
/// </summary>
public enum ModalidadeParcelamento
{
    /// <summary>PARCSN - Parcelamento ordinário do Simples Nacional.</summary>
    PARCSN,
    /// <summary>PARCSN-ESP - Parcelamento especial do Simples Nacional.</summary>
    PARCSN_ESP,
    /// <summary>PERTSN - Programa Especial de Regularização Tributária do Simples Nacional.</summary>
    PERTSN,
    /// <summary>RELPSN - Programa de Reescalonamento do Pagamento de Débitos do Simples Nacional.</summary>
    RELPSN,
    /// <summary>PARCMEI - Parcelamento convencional do MEI.</summary>
    PARCMEI,
    /// <summary>PARCMEI-ESP - Parcelamento especial do MEI.</summary>
    PARCMEI_ESP,
    /// <summary>PERTMEI - Programa Especial de Regularização Tributária do MEI.</summary>
    PERTMEI,
    /// <summary>RELPMEI - Programa de Reescalonamento do Pagamento de Débitos do MEI.</summary>
    RELPMEI
}
