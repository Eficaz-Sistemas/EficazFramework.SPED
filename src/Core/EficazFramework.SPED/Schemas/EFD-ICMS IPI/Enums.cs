using System;

namespace EficazFramework.SPED.Schemas.EFD_ICMS_IPI;

#region Bloco0

public enum Perfil
{
    [System.ComponentModel.Description("Perfil A")]
    A = 0,
    [System.ComponentModel.Description("Perfil B")]
    B = 1,
    [System.ComponentModel.Description("Perfil C")]
    C = 2
}

public enum CampoAlterado
{
    ID = 2,
    Nome = 3,
    CodigoPais = 4,
    CNPJ = 5,
    CPF = 6,
    CodigoMunicipio = 8,
    Suframa = 9,
    Endereco = 10,
    Numero = 11,
    Complemento = 12,
    Bairro = 13
}

public enum TipoItem
{
    [System.ComponentModel.Description("00 - Mercadoria para Revenda")]
    MercadoriaRevenda = 0,
    [System.ComponentModel.Description("01 - Matéria-Prima")]
    MateriaPrima = 1,
    [System.ComponentModel.Description("02 - Embalagem")]
    Embalagem = 2,
    [System.ComponentModel.Description("03 - Produto em Processo")]
    ProdutoEmProcesso = 3,
    [System.ComponentModel.Description("04 - Produto Acabado")]
    ProdutoAcabado = 4,
    [System.ComponentModel.Description("05 - Subproduto")]
    Subproduto = 5,
    [System.ComponentModel.Description("06 - Produto Intermediário")]
    ProdutoIntermediario = 6,
    [System.ComponentModel.Description("07 - Material de Uso e Consumo")]
    UsoConsumo = 7,
    [System.ComponentModel.Description("08 - Ativo Imobilizado")]
    AtivoImobilizado = 8,
    [System.ComponentModel.Description("09 - Serviços")]
    Servicos = 9,
    [System.ComponentModel.Description("10 - Outros Insumos")]
    OutrosInsumos = 10,
    [System.ComponentModel.Description("99 - Outras")]
    Outras = 99
}

public enum TipoMercadoriaImobilizado
{
    Bem = 1,
    Componente = 2,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

public enum CentroDeCusto
{
    [System.ComponentModel.Description("Área Operacional")]
    Com_AreaOperacional = 1,
    [System.ComponentModel.Description("Área Administrativa")]
    Com_AreaAdmin = 2,
    [System.ComponentModel.Description("Área Produtiva")]
    Ind_AreaProdutiva = 3,
    [System.ComponentModel.Description("Área de Apoio à Produção")]
    Ind_AreaApoioProd = 4,
    [System.ComponentModel.Description("Área Administrativa")]
    Ind_AreaAdmin = 5,
    [System.ComponentModel.Description("Enum_NotAnOption")]
    [System.Xml.Serialization.XmlIgnore()]
    NA = 999
}

public enum TipoDeAtividade
{
    [System.ComponentModel.Description("00 - Industrial - Transformação")]
    Industrial_Transformacao = 0,
    [System.ComponentModel.Description("01 - Industrial - Beneficiamento")]
    Industrial_Beneficiamento = 1,
    [System.ComponentModel.Description("02 - Industrial - Montagem")]
    Industrial_Montagem = 2,
    [System.ComponentModel.Description("03 - Industrial - Acondicionamento ou Reacondicionamento")]
    Industrial_Acond_Reacond = 3,
    [System.ComponentModel.Description("04 - Industrial - Renovação ou Recondicionamento")]
    Industrial_Renovacao_Recond = 4,
    [System.ComponentModel.Description("05 - Equiparado a industrial - Por opção")]
    Equiparado_Industrial = 5,
    [System.ComponentModel.Description("06 - Equiparado a industrial - Importação Direta")]
    Equiparado_Industrial_ImportacaoDireta = 6,
    [System.ComponentModel.Description("07 - Equiparado a industrial - Por lei específica")]
    Equiparado_Industrial_PorLei = 7,
    [System.ComponentModel.Description("08 - Equiparado a industrial - Não enquadrado nos códigos 05, 06 ou 07")]
    Equiparado_Industrial_DifAnteriores = 8,
    [System.ComponentModel.Description("09 - Outros")]
    Outros = 9
}

#endregion

#region Bloco C

public enum IndicadorOperacaoServicos
{
    Aquisicao = 0,
    Prestacao = 1
}

public enum IndicadorTipoDeducao
{
    Compensacao_ISS_CalculadoMaior = 0,
    Beneficio_Fiscal_Incentivo_Cultura = 1,
    Decisao_Administrativa_Judicial = 2,
    Outros = 9
}

public enum IndicadorOrigemProcessoServico
{
    Sefin = 0,
    Justica_Federal = 1,
    Justica_Estadual = 2,
    Outros = 9
}

public enum IndicadorHabilitacao
{
    ProfissionalHabilitado = 0,
    ProfissionalNaoHabilitadado = 1
}

public enum IndicadorEscolaridade
{
    NivelSuperior = 0,
    NivelMedio = 1
}

public enum IndicadorParticipacaoSocietaria
{
    Socio = 0,
    NaoSocio = 1
}

public enum IndicadorOperacao
{
    [System.ComponentModel.Description("Entrada")]
    Entrada = 0,
    [System.ComponentModel.Description("Saída")]
    Saida = 1
}

public enum IndicadorEmitente
{
    [System.ComponentModel.Description("Emissão Própria")]
    Propria = 0,
    [System.ComponentModel.Description("Emissão por Terceiros")]
    Terceiros = 1,
    [System.ComponentModel.Description("Não Aplicável")]
    NaoAplicavel = 99
}

public enum SituacaoDocumento
{
    [System.ComponentModel.Description("00 - Documento Regular")]
    Regular = 0,
    [System.ComponentModel.Description("01 - Escrituração extemporânea de documento regular")]
    RegularExtemporaneo = 1,
    [System.ComponentModel.Description("02 - Documento Cancelado")]
    Cancelado = 2,
    [System.ComponentModel.Description("03 - Escrituração extemporânea de documento cancelado")]
    CanceladoExtemporaneo = 3,
    [System.ComponentModel.Description("04 - NF-e, NFC-e ou CT-e - denegado")]
    Denegado = 4,
    [System.ComponentModel.Description("05 - NF-e, NFC-e ou CT-e - Numeração inutilizada")]
    Inutilizado = 5,
    [System.ComponentModel.Description("06 - Documento Fiscal Complementar")]
    Complementar = 6,
    [System.ComponentModel.Description("07 - Escrituração extemporânea de documento complementar")]
    ComplementarExtemporaneo = 7,
    [System.ComponentModel.Description("08 - Documento Fiscal emitido com base em Regime Especial ou Norma Específica")]
    RegimeEspecial = 8,
    [System.ComponentModel.Description("99 - Pendente")]
    Pendente = 99
}

public enum IndicadorPagamento
{
    [System.ComponentModel.Description("À Vista")]
    Vista = 0,
    [System.ComponentModel.Description("À Prazo")]
    Prazo = 1,
    [System.ComponentModel.Description("Outros")]
    Outros = 2
}

public enum IndicadorFrete
{
    [System.ComponentModel.Description("Por conta do Emitente")]
    Emitente = 0,
    [System.ComponentModel.Description("Por conta do Destinatário / Remetente")]
    Destinatario_Remetente = 1,
    [System.ComponentModel.Description("Por conta de Terceiros")]
    Terceiros = 2,
    [System.ComponentModel.Description("Sem cobrança de frete")]
    SemFrete = 9
}

public enum CodigoConsumoEnEletricaOuGas
{
    [System.ComponentModel.Description("Comercial")]
    Comercial = 1,
    [System.ComponentModel.Description("Consumo Próprio")]
    ConsumoProprio = 2,
    [System.ComponentModel.Description("Iluminação Pública")]
    IluminacaoPublica = 3,
    [System.ComponentModel.Description("Industrial")]
    Industrial = 4,
    [System.ComponentModel.Description("Poder Público")]
    PoderPublico = 5,
    [System.ComponentModel.Description("Residencial")]
    Residencial = 6,
    [System.ComponentModel.Description("Rural")]
    Rural = 7,
    [System.ComponentModel.Description("Serviço Público")]
    ServicoPublico = 8
}

public enum TipoLigacaoEnEletrica
{
    [System.ComponentModel.Description("Monifásico")]
    Monifasico = 1,
    [System.ComponentModel.Description("Bifásico")]
    Bifasico = 2,
    [System.ComponentModel.Description("Trifásico")]
    Trifasico = 3
}

public enum GrupoTensao
{
    [System.ComponentModel.Description("A1 - Alta Tensão (230kV ou mais)")]
    A1 = 1,
    [System.ComponentModel.Description("A2 - Alta Tensão (88kV a 138kV)")]
    A2 = 2,
    [System.ComponentModel.Description("A3 - Alta Tensão (69kV)")]
    A3 = 3,
    [System.ComponentModel.Description("A3a - Alta Tensão (30kV a 44kV)")]
    A3a = 4,
    [System.ComponentModel.Description("A4 - Alta Tensão (2,3kV a 25kV)")]
    A4 = 5,
    [System.ComponentModel.Description("AS - Alta Tensão Subterrâneo")]
    AS = 6,
    [System.ComponentModel.Description("B1 - Residencial")]
    B1 = 7,
    [System.ComponentModel.Description("B1 - Residencial (Baixa Renda)")]
    B1_BaixaRenda = 8,
    [System.ComponentModel.Description("B2 - Rural")]
    B2 = 9,
    [System.ComponentModel.Description("B2 - Cooperativa de Eletrificação Rural")]
    B2_CoopEletrif = 10,
    [System.ComponentModel.Description("B2 - Serviço Público de Irrigação")]
    B2_ServicoPublico = 11,
    [System.ComponentModel.Description("B3 - Demais Classes")]
    B3 = 12,
    [System.ComponentModel.Description("B4 - Iluminação Pública (Rede de Distribuição)")]
    B4a = 13,
    [System.ComponentModel.Description("B4 - Iluminação Pública (Bulbp de Lâmpada)")]
    B4b = 14
}

public enum IndicadorPeriodoIPI
{
    Mensal = 0,
    Decendial = 1
}

public enum IndicadorTipoOperacao
{
    [System.ComponentModel.Description("CombustiveleLubrificantes")]
    CombustiveleLubrificantes = 0,
    [System.ComponentModel.Description("LeasingVeiculosFaturamentoDireto")]
    LeasingVeiculosFaturamentoDireto = 1
}

public enum IndicadorOrigemProcesso
{
    [System.ComponentModel.Description("0 - SEFAZ")]
    SEFAZ = 0,
    [System.ComponentModel.Description("1 - Justiça Federal")]
    JusticaFederal = 1,
    [System.ComponentModel.Description("2 - Justiça Estadual")]
    JusticaEstadua = 2,
    [System.ComponentModel.Description("3 - SECEX/SRF")]
    SECEX_SRF = 3,
    [System.ComponentModel.Description("9 - Outros")]
    Outros = 4
}

public enum CodigoModeloDocArrec
{
    [System.ComponentModel.Description("0 - Documento estadual de arrecadação")]
    DAE = 0,
    [System.ComponentModel.Description("1 - GNRE")]
    GNRE = 1
}

public enum IndicadorTipoTransporte
{
    [System.ComponentModel.Description("0 - Rodoviário")]
    Rodoviario = 0,
    [System.ComponentModel.Description("1 - Ferroviário")]
    Ferroviario = 1,
    [System.ComponentModel.Description("2 - Rodo-Ferroviário")]
    Rodo_Ferroviario = 2,
    [System.ComponentModel.Description("3 - Aquaviário")]
    Aquaviario = 3,
    [System.ComponentModel.Description("4 - Dutoviário")]
    Dutoviario = 4,
    [System.ComponentModel.Description("5 - Aéreo")]
    Aereo = 5,
    [System.ComponentModel.Description("9 - Outros")]
    Outros = 9
}

public enum FinalidadeEmissaoDoc
{
    Normal = 1,
    Substituicao = 2,
    NormalComAjuste = 3
}

public enum IndicadorDestinatario
{
    ContribuinteICMS = 1,
    ContribIsentoICMS = 2,
    NaoContribuinte = 3
}

public enum DocumentoImportacao
{
    [System.ComponentModel.Description("0 - Declaração de Importação")]
    Declaracao_Importacao = 0,
    [System.ComponentModel.Description("1 - Declaração Simplificada de Importação")]
    Declar_Simp_Importacao = 1
}

public enum IndicadorTituloCredito
{
    [System.ComponentModel.Description("00 - Duplicata")]
    Duplicata = 0,
    [System.ComponentModel.Description("01 - Cheque")]
    Cheque = 1,
    [System.ComponentModel.Description("02 - Promissória")]
    Promissoria = 2,
    [System.ComponentModel.Description("03 - Recibo")]
    Recibo = 3,
    [System.ComponentModel.Description("99 - Outros (Descrever)")]
    Outros_Descrever = 99
}

public enum ResponsavelRetencaoST
{
    RemetenteDireto = 1,
    RemetenteIndireto = 2,
    ProprioDeclarante = 3
}

public enum MotimoRessarcimentoST
{
    VendaOutraUF = 1,
    SaidaIsencaoNaoIncidencia = 2,
    PerdaDeterioracao = 3,
    FurtoRoubo = 4,
    Outros = 9
}

public enum ModeloDocumentoArrecadacaoC176
{
    DAE = 0,
    GNRE = 1
}

public enum TipoC420
{
    TributadoICMS = 0,
    [Obsolete("Esta opção entrou em desuso com o fim dos ECF / MDF.")]
    TributadoICMS_X_Totalizadores = 1,
    TributadoISSQN = 2,
    [Obsolete("Esta opção entrou em desuso com o fim dos ECF / MDF.")]
    TributadoISSQN_X_Totalizadores = 3,
    ST = 4,
    Isento = 5,
    NaoIncidencia = 6,
    ST_ISSQN = 7,
    Isento_ISSQN = 8,
    NaoIncidencia_ISSQN = 9,
    OperacoesNaoFiscais = 10,
    Desconto_ICMS = 11,
    Desconto_ISSQN = 12,
    Desconto_OperacoesNaoFiscais = 13,
    Acrescimo_ICMS = 14,
    Acrescimo_ISSQN = 15,
    Acrescimo_OperacoesNaoFiscais = 16,
    Cancelamento_ICMS = 17,
    Cancelamento_ISSQN = 18,
    Cancelamento_OperacoesNaoFiscais = 19,
    IOF = 20,
    NaoSei = 99
}

public enum CodRespRetStC180
{
    Remetente_Direto = 1,
    Remetente_Indireto = 2,
    Proprio_Declarante = 3
}

public enum CodigoDocArrecadC180
{
    Documento_Estadual = 0,
    GNRE = 1
}

public enum IndicadorTipoCalculoST
{
    Base_Calculo_Preco = 0,
    Base_Calculo_MVA = 1,
    Base_Calculo_Lista_Negativa = 2,
    Base_Calculo_Lista_Positiva = 3,
    Base_Calculo_Lista_Neutra = 4
}

public enum TipoProduto
{
    Similar = 0,
    Generico = 1,
    Etico_Marca = 2
}

public enum IndicadorTipoArmaFogo
{
    UsoPermitido = 0,
    UsoRestrito = 1
}

public enum IndicadorTipoOperacaoVeiculo
{
    Venda_Concessionaria = 0,
    Faturamento_Direto = 1,
    Venda_Direta = 2,
    Venda_da_Concessionaria = 3,
    Outros = 9
}

#endregion

#region Bloco D

public enum IndicadorOperacaoTransporte
{
    [System.ComponentModel.Description("Aquisição")]
    Aquisicao = 0,
    [System.ComponentModel.Description("Prestação")]
    Prestacao = 1
}

public enum TipoAssinanteComunincacao
{
    [System.ComponentModel.Description("Comercial / Industrial")]
    Comercial_Industrial = 1,
    [System.ComponentModel.Description("Poder Público")]
    PoderPublico = 2,
    [System.ComponentModel.Description("Residencial / Pessoa Física")]
    Residencial_PessoaFisica = 3,
    [System.ComponentModel.Description("Público")]
    Publico = 4,
    [System.ComponentModel.Description("Semi-Público")]
    SemiPublico = 5,
    [System.ComponentModel.Description("Outros")]
    Outros = 6
}

#endregion

#region Bloco E

public enum IndicadorMovimentoST_Difal
{
    [System.ComponentModel.Description("Sem Operações")]
    SemOperacoes = 0,
    [System.ComponentModel.Description("Com Operações")]
    ComOperacoes = 1
}

#endregion

#region Bloco G

public enum TipoMovimentoCIAP
{
    /// <summary>
    /// Saldo Inicial de Bens Imobilizados
    /// </summary>
    SI_SaldoInicial = 0,
    /// <summary>
    /// Imobilização de Bem Individual
    /// </summary>
    IM_ImobIndividual = 1,
    /// <summary>
    /// Imobilização em Andamento - Componente
    /// </summary>
    IA_ImobEmAndamento = 2,
    /// <summary>
    /// Conclusão de Imobilização em Andamento - Bem Resultante
    /// </summary>
    CI_ConclusaoImobAndamento = 3,
    /// <summary>
    /// Imobilização oriunda do Ativo Circulante
    /// </summary>
    MC_ImobAtivoCirculante = 4,
    /// <summary>
    /// Baixa do bem - Fim do período de apropriação
    /// </summary>
    BA_BaixaBemFimApropriacao = 5,
    /// <summary>
    /// Alienação ou Transferência
    /// </summary>
    AT_AlienacaoTransf = 6,
    /// <summary>
    /// Perecimento, Extravio ou Deterioração
    /// </summary>
    PE_PerecExtravioDeterior = 7,
    /// <summary>
    /// Outras Saídas do Imobilizado
    /// </summary>
    OT_OutrasSaidas = 8
}

#endregion

#region Bloco H

public enum MotivoInventario
{
    [System.ComponentModel.Description("No final do período")]
    FinalPeriodo = 1,
    [System.ComponentModel.Description("Na mudança de forma de tributação da mercadoria (ICMS)")]
    MudancaICMSItem = 2,
    [System.ComponentModel.Description("Na soliticação da baixa cadastral, paralisação temporária e outras situações")]
    Baixa_Paralisacao_Outras = 3,
    [System.ComponentModel.Description("Na alteração de regime de pagamento - condição do contribuinte")]
    AlteracaoRegimePagto = 4,
    [System.ComponentModel.Description("Por determinação do fisco")]
    DeterminacaoFisco = 5
}

public enum IndicadorPropriedade
{
    [System.ComponentModel.Description("Item de propriedade do informante e em seu poder")]
    InformanteEmPoder = 0,
    [System.ComponentModel.Description("Item de propriedade do informante em posse de terceiros")]
    InformanteEmTerceiros = 1,
    [System.ComponentModel.Description("Item de propriedade de terceiros em posse do informante")]
    TerceirosEmPoder = 2,
    [System.ComponentModel.Description("Item de propriedade do informante, em seu poder ou em posse de terceiros")]
    InformanteGeral = 99
}

#endregion

#region Bloco I

public enum IndicadorMedicao1350
{
    Analogico = 0,
    Digital = 1
}
