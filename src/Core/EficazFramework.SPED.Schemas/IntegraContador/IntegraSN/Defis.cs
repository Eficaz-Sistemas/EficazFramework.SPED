using System.Text.Json.Serialization;

namespace EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

// Os nomes dos campos seguem o schema de entrada da DEFIS (exemplos/schema.json), que diverge da tabela de campos
// em alguns pontos (ex.: codigoMunicipio x codMunicipio, prestacaoServicosComunicacao x prestacoesServicoComunicacao,
// mudancasOutroMunicipio x mudancaOutroMunicipio e naoOptante na raiz, e não dentro de empresa).

#region TRANSDECLARACAO141 - Transmitir declaração

/// <summary>
/// Entrada do serviço DEFIS / TRANSDECLARACAO141: transmissão da Declaração de Informações Socioeconômicas e Fiscais.
/// </summary>
/// <remarks>Qualquer declaração pendente de transmissão no ano-calendário é apagada.</remarks>
public sealed class TransmitirDeclaracaoDefis
{
    /// <summary>Ano-calendário.</summary>
    [JsonPropertyName("ano")]
    public int Ano { get; set; }

    /// <summary>Informações de situação especial.</summary>
    [JsonPropertyName("situacaoEspecial")]
    public SituacaoEspecial? SituacaoEspecial { get; set; }

    /// <summary>
    /// Resposta à pergunta sobre inatividade (obrigatória somente para ano-calendário anterior a 2025):
    /// 0 - atividades zeradas, responde NÃO; 1 - atividades zeradas, responde SIM; 2 - total das atividades maior que zero.
    /// </summary>
    [JsonPropertyName("inatividade")]
    public int? Inatividade { get; set; }

    /// <summary>Informações da empresa (matriz).</summary>
    [JsonPropertyName("empresa")]
    public EmpresaDefis Empresa { get; set; } = new();

    /// <summary>Informações de não optante.</summary>
    [JsonPropertyName("naoOptante")]
    public NaoOptanteDefis? NaoOptante { get; set; }
}

/// <summary>
/// Situação especial da DEFIS.
/// </summary>
public sealed class SituacaoEspecial
{
    /// <summary>
    /// Tipo do evento: 1 - Cisão parcial; 2 - Cisão total; 3 - Extinção; 4 - Fusão; 5 - Incorporação/Incorporada.
    /// </summary>
    [JsonPropertyName("tipoEvento")]
    public int TipoEvento { get; set; }

    /// <summary>Data do evento no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataEvento")]
    public int DataEvento { get; set; }
}

/// <summary>
/// Informações da empresa (matriz) na DEFIS.
/// </summary>
public sealed class EmpresaDefis
{
    /// <summary>Ganhos de capital.</summary>
    [JsonPropertyName("ganhoCapital")]
    public decimal GanhoCapital { get; set; }

    /// <summary>Quantidade de empregados no início do ano-calendário.</summary>
    [JsonPropertyName("qtdEmpregadoInicial")]
    public int QtdEmpregadoInicial { get; set; }

    /// <summary>Quantidade de empregados no final do ano-calendário.</summary>
    [JsonPropertyName("qtdEmpregadoFinal")]
    public int QtdEmpregadoFinal { get; set; }

    /// <summary>
    /// Lucro contábil apurado, caso a ME/EPP mantenha escrituração contábil e tenha evidenciado lucro superior ao limite legal.
    /// </summary>
    [JsonPropertyName("lucroContabil")]
    public decimal? LucroContabil { get; set; }

    /// <summary>Receita proveniente de exportação direta.</summary>
    [JsonPropertyName("receitaExportacaoDireta")]
    public decimal ReceitaExportacaoDireta { get; set; }

    /// <summary>Receitas provenientes de exportação por meio de comercial exportadora.</summary>
    [JsonPropertyName("comerciaisExportadoras")]
    public List<ComercialExportadora>? ComerciaisExportadoras { get; set; }

    /// <summary>Identificação e rendimentos dos sócios.</summary>
    [JsonPropertyName("socios")]
    public List<Socio> Socios { get; set; } = [];

    /// <summary>Percentual de participação em cotas em tesouraria no capital social da empresa.</summary>
    [JsonPropertyName("participacaoCotasTesouraria")]
    public decimal? ParticipacaoCotasTesouraria { get; set; }

    /// <summary>Total de ganhos líquidos auferidos em operações de renda variável.</summary>
    [JsonPropertyName("ganhoRendaVariavel")]
    public decimal GanhoRendaVariavel { get; set; }

    /// <summary>Doações à campanha eleitoral.</summary>
    [JsonPropertyName("doacoesCampanhaEleitoral")]
    public List<DoacaoCampanhaEleitoral>? DoacoesCampanhaEleitoral { get; set; }

    /// <summary>Estabelecimentos.</summary>
    [JsonPropertyName("estabelecimentos")]
    public List<EstabelecimentoDefis> Estabelecimentos { get; set; } = [];
}

/// <summary>
/// Receita de exportação por meio de comercial exportadora.
/// </summary>
public sealed class ComercialExportadora
{
    /// <summary>CNPJ completo da comercial exportadora.</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string CnpjCompleto { get; set; } = string.Empty;

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

/// <summary>
/// Identificação e rendimentos de um sócio.
/// </summary>
public sealed class Socio
{
    /// <summary>CPF do sócio, somente números.</summary>
    [JsonPropertyName("cpf")]
    public string Cpf { get; set; } = string.Empty;

    /// <summary>Rendimentos isentos pagos ao sócio pela empresa.</summary>
    [JsonPropertyName("rendimentosIsentos")]
    public decimal RendimentosIsentos { get; set; }

    /// <summary>Rendimentos tributáveis pagos ao sócio pela empresa.</summary>
    [JsonPropertyName("rendimentosTributaveis")]
    public decimal RendimentosTributaveis { get; set; }

    /// <summary>Percentual de participação do sócio no capital social no último dia do período abrangido.</summary>
    [JsonPropertyName("participacaoCapitalSocial")]
    public decimal ParticipacaoCapitalSocial { get; set; }

    /// <summary>Imposto de renda retido na fonte sobre os rendimentos pagos ao sócio.</summary>
    [JsonPropertyName("irRetidoFonte")]
    public decimal IrRetidoFonte { get; set; }
}

/// <summary>
/// Doação à campanha eleitoral.
/// </summary>
public sealed class DoacaoCampanhaEleitoral
{
    /// <summary>CNPJ do beneficiário.</summary>
    [JsonPropertyName("cnpjBeneficiario")]
    public string CnpjBeneficiario { get; set; } = string.Empty;

    /// <summary>Tipo de beneficiário: 1 - Candidato a cargo político eletivo; 2 - Comitê financeiro; 3 - Partido político.</summary>
    [JsonPropertyName("tipoBeneficiario")]
    public int TipoBeneficiario { get; set; }

    /// <summary>
    /// Forma de doação: 1 - Cheque; 2 - Outros títulos de crédito; 3 - Transferência eletrônica; 4 - Depósito em espécie;
    /// 5 - Dinheiro; 6 - Bens; 7 - Serviços.
    /// </summary>
    [JsonPropertyName("formaDoacao")]
    public int FormaDoacao { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

/// <summary>
/// Informação de não optante da DEFIS.
/// </summary>
public sealed class NaoOptanteDefis
{
    /// <summary>Administração tributária onde foi protocolado: 1 - Distrital; 2 - Estadual; 3 - Federal; 4 - Municipal.</summary>
    [JsonPropertyName("administracaoTributaria")]
    public int AdministracaoTributaria { get; set; }

    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipio")]
    public int CodigoMunicipio { get; set; }

    /// <summary>Número do processo.</summary>
    [JsonPropertyName("numeroProcesso")]
    public string NumeroProcesso { get; set; } = string.Empty;
}

/// <summary>
/// Estabelecimento da DEFIS.
/// </summary>
public sealed class EstabelecimentoDefis
{
    /// <summary>CNPJ completo do estabelecimento (somente números).</summary>
    [JsonPropertyName("cnpjCompleto")]
    public string CnpjCompleto { get; set; } = string.Empty;

    /// <summary>Estoque inicial do período (exclusivo de contribuintes do ICMS; os demais informam 0).</summary>
    [JsonPropertyName("estoqueInicial")]
    public decimal EstoqueInicial { get; set; }

    /// <summary>Estoque final do período (exclusivo de contribuintes do ICMS; os demais informam 0).</summary>
    [JsonPropertyName("estoqueFinal")]
    public decimal EstoqueFinal { get; set; }

    /// <summary>Saldo em caixa/banco no início do período.</summary>
    [JsonPropertyName("saldoCaixaInicial")]
    public decimal SaldoCaixaInicial { get; set; }

    /// <summary>Saldo em caixa/banco no final do período.</summary>
    [JsonPropertyName("saldoCaixaFinal")]
    public decimal SaldoCaixaFinal { get; set; }

    /// <summary>Aquisições de mercadorias para comercialização ou industrialização no mercado interno.</summary>
    [JsonPropertyName("aquisicoesMercadoInterno")]
    public decimal AquisicoesMercadoInterno { get; set; }

    /// <summary>Aquisições de mercadorias para comercialização ou industrialização por importação.</summary>
    [JsonPropertyName("importacoes")]
    public decimal Importacoes { get; set; }

    /// <summary>Total de entradas de mercadorias por transferência.</summary>
    [JsonPropertyName("totalEntradasPorTransferencia")]
    public decimal TotalEntradasPorTransferencia { get; set; }

    /// <summary>Total de saídas de mercadorias por transferência.</summary>
    [JsonPropertyName("totalSaidasPorTransferencia")]
    public decimal TotalSaidasPorTransferencia { get; set; }

    /// <summary>Total de devoluções de vendas.</summary>
    [JsonPropertyName("totalDevolucoesVendas")]
    public decimal TotalDevolucoesVendas { get; set; }

    /// <summary>Total de entradas (inclui aquisições no mercado interno, entradas por transferência e devoluções de vendas).</summary>
    [JsonPropertyName("totalEntradas")]
    public decimal TotalEntradas { get; set; }

    /// <summary>Total de devoluções de compras.</summary>
    [JsonPropertyName("totalDevolucoesCompras")]
    public decimal TotalDevolucoesCompras { get; set; }

    /// <summary>Total de despesas no período.</summary>
    [JsonPropertyName("totalDespesas")]
    public decimal TotalDespesas { get; set; }

    /// <summary>Operações interestaduais por UF.</summary>
    [JsonPropertyName("operacoesInterestaduais")]
    public List<OperacaoInterestadual>? OperacoesInterestaduais { get; set; }

    /// <summary>ISS retido na fonte no ano-calendário, por município.</summary>
    [JsonPropertyName("issRetidosFonte")]
    public List<ValorMunicipio>? IssRetidosFonte { get; set; }

    /// <summary>Prestações de serviços de comunicação.</summary>
    [JsonPropertyName("prestacaoServicosComunicacao")]
    public List<ValorMunicipio>? PrestacaoServicosComunicacao { get; set; }

    /// <summary>Mudanças de endereço do estabelecimento para outro município (uma por mudança).</summary>
    [JsonPropertyName("mudancasOutroMunicipio")]
    public List<MudancaOutroMunicipio>? MudancasOutroMunicipio { get; set; }

    /// <summary>
    /// Prestações de serviços de transporte intermunicipal/interestadual de cargas e passageiros (art. 17, VI, da LC 123).
    /// </summary>
    [JsonPropertyName("prestacoesServicoTransporte")]
    public List<ValorMunicipio>? PrestacoesServicoTransporte { get; set; }

    /// <summary>Informações opcionais sobre o estabelecimento.</summary>
    [JsonPropertyName("informacaoOpcional")]
    public InformacaoOpcional? InformacaoOpcional { get; set; }
}

/// <summary>
/// Operação interestadual por UF.
/// </summary>
public sealed class OperacaoInterestadual
{
    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Tipo de operação: 1 - Entrada; 2 - Saída.</summary>
    [JsonPropertyName("tipoOperacao")]
    public int TipoOperacao { get; set; }
}

/// <summary>
/// Valor por município (ISS retido na fonte, serviços de comunicação e de transporte, vendas por revendedor ambulante,
/// preparo de refeições, produção rural e aquisições).
/// </summary>
public sealed class ValorMunicipio
{
    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipio")]
    public int CodigoMunicipio { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }
}

/// <summary>
/// Mudança de endereço do estabelecimento para outro município.
/// </summary>
public sealed class MudancaOutroMunicipio
{
    /// <summary>UF de origem.</summary>
    [JsonPropertyName("ufOrigem")]
    public string UfOrigem { get; set; } = string.Empty;

    /// <summary>Código do município de origem (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipioOrigem")]
    public int CodigoMunicipioOrigem { get; set; }

    /// <summary>UF de destino.</summary>
    [JsonPropertyName("ufDestino")]
    public string UfDestino { get; set; } = string.Empty;

    /// <summary>Código do município de destino (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipioDestino")]
    public int CodigoMunicipioDestino { get; set; }

    /// <summary>Data da mudança no formato AAAAMMDD.</summary>
    [JsonPropertyName("dataMudanca")]
    public int DataMudanca { get; set; }

    /// <summary>Informações opcionais sobre a mudança no destino.</summary>
    [JsonPropertyName("informacaoOpcional")]
    public InformacaoOpcional? InformacaoOpcional { get; set; }
}

/// <summary>
/// Informações opcionais do estabelecimento (ou da mudança de município) na DEFIS.
/// </summary>
public sealed class InformacaoOpcional
{
    /// <summary>Saídas por transferência de mercadorias entre estabelecimentos do mesmo proprietário.</summary>
    [JsonPropertyName("saidaTransferenciaMercadoria")]
    public decimal? SaidaTransferenciaMercadoria { get; set; }

    /// <summary>Vendas por meio de revendedores ambulantes autônomos em outros municípios do mesmo estado.</summary>
    [JsonPropertyName("vendasRevendedorAmbulante")]
    public List<ValorMunicipio>? VendasRevendedorAmbulante { get; set; }

    /// <summary>Preparo e comercialização de refeições em municípios diferentes do município do estabelecimento.</summary>
    [JsonPropertyName("preparosComercializacaoRefeicoes")]
    public List<ValorMunicipio>? PreparosComercializacaoRefeicoes { get; set; }

    /// <summary>Produção rural ocorrida no território de mais de um município do estado.</summary>
    [JsonPropertyName("producoesRurais")]
    public List<ValorMunicipio>? ProducoesRurais { get; set; }

    /// <summary>Aquisição de mercadorias de produtores rurais não equiparados a comerciantes ou industriais.</summary>
    [JsonPropertyName("aquisicoesProdutoresRurais")]
    public List<ValorMunicipio>? AquisicoesProdutoresRurais { get; set; }

    /// <summary>Aquisição de mercadorias de contribuintes dispensados de inscrição, exceto produtor rural.</summary>
    [JsonPropertyName("aquisicoesDispensadosInscricao")]
    public List<ValorMunicipio>? AquisicoesDispensadosInscricao { get; set; }

    /// <summary>
    /// Autos de infração pagos ou com decisão administrativa irrecorrível (somente o valor da operação).
    /// </summary>
    [JsonPropertyName("autoInfracaoPago")]
    public decimal? AutoInfracaoPago { get; set; }

    /// <summary>Rateio de receita oriundo de regime especial concedido pela SEFAZ.</summary>
    [JsonPropertyName("rateiosReceitaRegimeEspecial")]
    public List<RateioRegimeEspecial>? RateiosReceitaRegimeEspecial { get; set; }

    /// <summary>Rateio de receita oriundo de decisão judicial.</summary>
    [JsonPropertyName("rateiosDecisaoJudicial")]
    public List<RateioDecisaoJudicial>? RateiosDecisaoJudicial { get; set; }

    /// <summary>Rateio de receita oriundo de outros rateios determinados pela SEFAZ.</summary>
    [JsonPropertyName("rateiosReceitaOutrosRateios")]
    public List<RateioOutrosRateios>? RateiosReceitaOutrosRateios { get; set; }
}

/// <summary>
/// Rateio de receita oriundo de regime especial concedido pela SEFAZ.
/// </summary>
public sealed class RateioRegimeEspecial
{
    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipio")]
    public int CodigoMunicipio { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Número do regime.</summary>
    [JsonPropertyName("numeroRegime")]
    public string NumeroRegime { get; set; } = string.Empty;
}

/// <summary>
/// Rateio de receita oriundo de decisão judicial.
/// </summary>
public sealed class RateioDecisaoJudicial
{
    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipio")]
    public int CodigoMunicipio { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Identificação da decisão.</summary>
    [JsonPropertyName("identificacaoDecisao")]
    public string IdentificacaoDecisao { get; set; } = string.Empty;
}

/// <summary>
/// Rateio de receita oriundo de outros rateios determinados pela SEFAZ.
/// </summary>
public sealed class RateioOutrosRateios
{
    /// <summary>UF.</summary>
    [JsonPropertyName("uf")]
    public string Uf { get; set; } = string.Empty;

    /// <summary>Código do município (tabela TOM).</summary>
    [JsonPropertyName("codigoMunicipio")]
    public int CodigoMunicipio { get; set; }

    /// <summary>Valor.</summary>
    [JsonPropertyName("valor")]
    public decimal Valor { get; set; }

    /// <summary>Origem da exigência.</summary>
    [JsonPropertyName("origemExigencia")]
    public string OrigemExigencia { get; set; } = string.Empty;
}

#endregion

#region CONSDECLARACAO142 / CONSULTIMADECREC143 / CONSDECREC144 - Consultas

/// <summary>
/// Entrada do serviço DEFIS / CONSULTIMADECREC143: última declaração transmitida no ano-calendário.
/// </summary>
public sealed class ConsultarUltimaDeclaracaoDefis
{
    /// <summary>Ano-calendário (dentro do período não decadente).</summary>
    [JsonPropertyName("ano")]
    public int Ano { get; set; }
}

/// <summary>
/// Entrada do serviço DEFIS / CONSDECREC144: declaração específica.
/// </summary>
public sealed class ConsultarDeclaracaoDefis
{
    /// <summary>Identificador da DEFIS (15 dígitos; texto no exemplo da documentação).</summary>
    [JsonPropertyName("idDefis")]
    public string IdDefis { get; set; } = string.Empty;
}

/// <summary>
/// Item do retorno do serviço DEFIS / CONSDECLARACAO142: declaração transmitida.
/// </summary>
public sealed class DeclaracaoDefis
{
    /// <summary>Ano-calendário da declaração transmitida.</summary>
    [JsonPropertyName("anoCalendario")]
    public int AnoCalendario { get; set; }

    /// <summary>Identificador da DEFIS transmitida.</summary>
    [JsonPropertyName("idDefis")]
    public string? IdDefis { get; set; }

    /// <summary>
    /// Tipo da declaração: 1 - Original Normal; 2 - Retificadora Normal; 3 - Original de Situação Especial;
    /// 4 - Retificadora de Situação Especial.
    /// </summary>
    [JsonPropertyName("tipo")]
    public int? Tipo { get; set; }

    /// <summary>Data e hora da transmissão no formato AAAAMMDDHHMMSS.</summary>
    [JsonPropertyName("dataHora")]
    public long? DataHora { get; set; }
}

/// <summary>
/// Retorno dos serviços DEFIS / TRANSDECLARACAO141, CONSULTIMADECREC143 e CONSDECREC144: declaração e recibo em PDF.
/// </summary>
public sealed class ReciboDefis
{
    /// <summary>PDF da declaração, em Base64.</summary>
    [JsonPropertyName("declaracaoPdf")]
    public string? DeclaracaoPdf { get; set; }

    /// <summary>PDF do recibo, em Base64.</summary>
    [JsonPropertyName("reciboPdf")]
    public string? ReciboPdf { get; set; }

    /// <summary>Identificador da DEFIS (não retornado no CONSDECREC144).</summary>
    [JsonPropertyName("idDefis")]
    public string? IdDefis { get; set; }
}

#endregion
