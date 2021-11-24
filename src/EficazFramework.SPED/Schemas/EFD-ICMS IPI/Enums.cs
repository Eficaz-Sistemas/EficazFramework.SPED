using System;

namespace EficazFrameworkCore.SPED.Schemas.EFD_ICMS_IPI
{

    #region Bloco0

    public enum Perfil
    {
        [Attributes.DisplayName("Perfil A")]
        A = 0,
        [Attributes.DisplayName("Perfil B")]
        B = 1,
        [Attributes.DisplayName("Perfil C")]
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
        [Attributes.DisplayName("00 - Mercadoria para Revenda")]
        MercadoriaRevenda = 0,
        [Attributes.DisplayName("01 - Matéria-Prima")]
        MateriaPrima = 1,
        [Attributes.DisplayName("02 - Embalagem")]
        Embalagem = 2,
        [Attributes.DisplayName("03 - Produto em Processo")]
        ProdutoEmProcesso = 3,
        [Attributes.DisplayName("04 - Produto Acabado")]
        ProdutoAcabado = 4,
        [Attributes.DisplayName("05 - Subproduto")]
        Subproduto = 5,
        [Attributes.DisplayName("06 - Produto Intermediário")]
        ProdutoIntermediario = 6,
        [Attributes.DisplayName("07 - Material de Uso e Consumo")]
        UsoConsumo = 7,
        [Attributes.DisplayName("08 - Ativo Imobilizado")]
        AtivoImobilizado = 8,
        [Attributes.DisplayName("09 - Serviços")]
        Servicos = 9,
        [Attributes.DisplayName("10 - Outros Insumos")]
        OutrosInsumos = 10,
        [Attributes.DisplayName("99 - Outras")]
        Outras = 99
    }

    public enum TipoMercadoriaImobilizado
    {
        Bem = 1,
        Componente = 2,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    public enum CentroDeCusto
    {
        [Attributes.DisplayName("Área Operacional")]
        Com_AreaOperacional = 1,
        [Attributes.DisplayName("Área Administrativa")]
        Com_AreaAdmin = 2,
        [Attributes.DisplayName("Área Produtiva")]
        Ind_AreaProdutiva = 3,
        [Attributes.DisplayName("Área de Apoio à Produção")]
        Ind_AreaApoioProd = 4,
        [Attributes.DisplayName("Área Administrativa")]
        Ind_AreaAdmin = 5,
        [Attributes.DisplayName("Enum_NotAnOption")]
        [System.Xml.Serialization.XmlIgnore()]
        NA = 999
    }

    public enum TipoDeAtividade
    {
        [Attributes.DisplayName("00 - Industrial - Transformação")]
        Industrial_Transformacao = 0,
        [Attributes.DisplayName("01 - Industrial - Beneficiamento")]
        Industrial_Beneficiamento = 1,
        [Attributes.DisplayName("02 - Industrial - Montagem")]
        Industrial_Montagem = 2,
        [Attributes.DisplayName("03 - Industrial - Acondicionamento ou Reacondicionamento")]
        Industrial_Acond_Reacond = 3,
        [Attributes.DisplayName("04 - Industrial - Renovação ou Recondicionamento")]
        Industrial_Renovacao_Recond = 4,
        [Attributes.DisplayName("05 - Equiparado a industrial - Por opção")]
        Equiparado_Industrial = 5,
        [Attributes.DisplayName("06 - Equiparado a industrial - Importação Direta")]
        Equiparado_Industrial_ImportacaoDireta = 6,
        [Attributes.DisplayName("07 - Equiparado a industrial - Por lei específica")]
        Equiparado_Industrial_PorLei = 7,
        [Attributes.DisplayName("08 - Equiparado a industrial - Não enquadrado nos códigos 05, 06 ou 07")]
        Equiparado_Industrial_DifAnteriores = 8,
        [Attributes.DisplayName("09 - Outros")]
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
        [Attributes.DisplayName("Entrada")]
        Entrada = 0,
        [Attributes.DisplayName("Saída")]
        Saida = 1
    }

    public enum IndicadorEmitente
    {
        [Attributes.DisplayName("Emissão Própria")]
        Propria = 0,
        [Attributes.DisplayName("Emissão por Terceiros")]
        Terceiros = 1,
        [Attributes.DisplayName("Não Aplicável")]
        NaoAplicavel = 99
    }

    public enum SituacaoDocumento
    {
        [Attributes.DisplayName("00 - Documento Regular")]
        Regular = 0,
        [Attributes.DisplayName("01 - Escrituração extemporânea de documento regular")]
        RegularExtemporaneo = 1,
        [Attributes.DisplayName("02 - Documento Cancelado")]
        Cancelado = 2,
        [Attributes.DisplayName("03 - Escrituração extemporânea de documento cancelado")]
        CanceladoExtemporaneo = 3,
        [Attributes.DisplayName("04 - NF-e, NFC-e ou CT-e - denegado")]
        Denegado = 4,
        [Attributes.DisplayName("05 - NF-e, NFC-e ou CT-e - Numeração inutilizada")]
        Inutilizado = 5,
        [Attributes.DisplayName("06 - Documento Fiscal Complementar")]
        Complementar = 6,
        [Attributes.DisplayName("07 - Escrituração extemporânea de documento complementar")]
        ComplementarExtemporaneo = 7,
        [Attributes.DisplayName("08 - Documento Fiscal emitido com base em Regime Especial ou Norma Específica")]
        RegimeEspecial = 8,
        [Attributes.DisplayName("99 - Pendente")]
        Pendente = 99
    }

    public enum IndicadorPagamento
    {
        [Attributes.DisplayName("À Vista")]
        Vista = 0,
        [Attributes.DisplayName("À Prazo")]
        Prazo = 1,
        [Attributes.DisplayName("Outros")]
        Outros = 2
    }

    public enum IndicadorFrete
    {
        [Attributes.DisplayName("Por conta do Emitente")]
        Emitente = 0,
        [Attributes.DisplayName("Por conta do Destinatário / Remetente")]
        Destinatario_Remetente = 1,
        [Attributes.DisplayName("Por conta de Terceiros")]
        Terceiros = 2,
        [Attributes.DisplayName("Sem cobrança de frete")]
        SemFrete = 9
    }

    public enum CodigoConsumoEnEletricaOuGas
    {
        [Attributes.DisplayName("Comercial")]
        Comercial = 1,
        [Attributes.DisplayName("Consumo Próprio")]
        ConsumoProprio = 2,
        [Attributes.DisplayName("Iluminação Pública")]
        IluminacaoPublica = 3,
        [Attributes.DisplayName("Industrial")]
        Industrial = 4,
        [Attributes.DisplayName("Poder Público")]
        PoderPublico = 5,
        [Attributes.DisplayName("Residencial")]
        Residencial = 6,
        [Attributes.DisplayName("Rural")]
        Rural = 7,
        [Attributes.DisplayName("Serviço Público")]
        ServicoPublico = 8
    }

    public enum TipoLigacaoEnEletrica
    {
        [Attributes.DisplayName("Monifásico")]
        Monifasico = 1,
        [Attributes.DisplayName("Bifásico")]
        Bifasico = 2,
        [Attributes.DisplayName("Trifásico")]
        Trifasico = 3
    }

    public enum GrupoTensao
    {
        [Attributes.DisplayName("A1 - Alta Tensão (230kV ou mais)")]
        A1 = 1,
        [Attributes.DisplayName("A2 - Alta Tensão (88kV a 138kV)")]
        A2 = 2,
        [Attributes.DisplayName("A3 - Alta Tensão (69kV)")]
        A3 = 3,
        [Attributes.DisplayName("A3a - Alta Tensão (30kV a 44kV)")]
        A3a = 4,
        [Attributes.DisplayName("A4 - Alta Tensão (2,3kV a 25kV)")]
        A4 = 5,
        [Attributes.DisplayName("AS - Alta Tensão Subterrâneo")]
        AS = 6,
        [Attributes.DisplayName("B1 - Residencial")]
        B1 = 7,
        [Attributes.DisplayName("B1 - Residencial (Baixa Renda)")]
        B1_BaixaRenda = 8,
        [Attributes.DisplayName("B2 - Rural")]
        B2 = 9,
        [Attributes.DisplayName("B2 - Cooperativa de Eletrificação Rural")]
        B2_CoopEletrif = 10,
        [Attributes.DisplayName("B2 - Serviço Público de Irrigação")]
        B2_ServicoPublico = 11,
        [Attributes.DisplayName("B3 - Demais Classes")]
        B3 = 12,
        [Attributes.DisplayName("B4 - Iluminação Pública (Rede de Distribuição)")]
        B4a = 13,
        [Attributes.DisplayName("B4 - Iluminação Pública (Bulbp de Lâmpada)")]
        B4b = 14
    }

    public enum IndicadorPeriodoIPI
    {
        Mensal = 0,
        Decendial = 1
    }

    public enum IndicadorTipoOperacao
    {
        [Attributes.DisplayName("CombustiveleLubrificantes")]
        CombustiveleLubrificantes = 0,
        [Attributes.DisplayName("LeasingVeiculosFaturamentoDireto")]
        LeasingVeiculosFaturamentoDireto = 1
    }

    public enum IndicadorOrigemProcesso
    {
        [Attributes.DisplayName("0 - SEFAZ")]
        SEFAZ = 0,
        [Attributes.DisplayName("1 - Justiça Federal")]
        JusticaFederal = 1,
        [Attributes.DisplayName("2 - Justiça Estadual")]
        JusticaEstadua = 2,
        [Attributes.DisplayName("3 - SECEX/SRF")]
        SECEX_SRF = 3,
        [Attributes.DisplayName("9 - Outros")]
        Outros = 4
    }

    public enum CodigoModeloDocArrec
    {
        [Attributes.DisplayName("0 - Documento estadual de arrecadação")]
        DAE = 0,
        [Attributes.DisplayName("1 - GNRE")]
        GNRE = 1
    }

    public enum IndicadorTipoTransporte
    {
        [Attributes.DisplayName("0 - Rodoviário")]
        Rodoviario = 0,
        [Attributes.DisplayName("1 - Ferroviário")]
        Ferroviario = 1,
        [Attributes.DisplayName("2 - Rodo-Ferroviário")]
        Rodo_Ferroviario = 2,
        [Attributes.DisplayName("3 - Aquaviário")]
        Aquaviario = 3,
        [Attributes.DisplayName("4 - Dutoviário")]
        Dutoviario = 4,
        [Attributes.DisplayName("5 - Aéreo")]
        Aereo = 5,
        [Attributes.DisplayName("9 - Outros")]
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
        [Attributes.DisplayName("0 - Declaração de Importação")]
        Declaracao_Importacao = 0,
        [Attributes.DisplayName("1 - Declaração Simplificada de Importação")]
        Declar_Simp_Importacao = 1
    }

    public enum IndicadorTituloCredito
    {
        [Attributes.DisplayName("00 - Duplicata")]
        Duplicata = 0,
        [Attributes.DisplayName("01 - Cheque")]
        Cheque = 1,
        [Attributes.DisplayName("02 - Promissória")]
        Promissoria = 2,
        [Attributes.DisplayName("03 - Recibo")]
        Recibo = 3,
        [Attributes.DisplayName("99 - Outros (Descrever)")]
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
        [Obsolete]
        TributadoICMS_X_Totalizadores = 1,
        TributadoISSQN = 2,
        [Obsolete]
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
        [Attributes.DisplayName("Aquisição")]
        Aquisicao = 0,
        [Attributes.DisplayName("Prestação")]
        Prestacao = 1
    }

    public enum TipoAssinanteComunincacao
    {
        [Attributes.DisplayName("Comercial / Industrial")]
        Comercial_Industrial = 1,
        [Attributes.DisplayName("Poder Público")]
        PoderPublico = 2,
        [Attributes.DisplayName("Residencial / Pessoa Física")]
        Residencial_PessoaFisica = 3,
        [Attributes.DisplayName("Público")]
        Publico = 4,
        [Attributes.DisplayName("Semi-Público")]
        SemiPublico = 5,
        [Attributes.DisplayName("Outros")]
        Outros = 6
    }

    #endregion

    #region Bloco E

    public enum IndicadorMovimentoST_Difal
    {
        [Attributes.DisplayName("Sem Operações")]
        SemOperacoes = 0,
        [Attributes.DisplayName("Com Operações")]
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
        [Attributes.DisplayName("No final do período")]
        FinalPeriodo = 1,
        [Attributes.DisplayName("Na mudança de forma de tributação da mercadoria (ICMS)")]
        MudancaICMSItem = 2,
        [Attributes.DisplayName("Na soliticação da baixa cadastral, paralisação temporária e outras situações")]
        Baixa_Paralisacao_Outras = 3,
        [Attributes.DisplayName("Na alteração de regime de pagamento - condição do contribuinte")]
        AlteracaoRegimePagto = 4,
        [Attributes.DisplayName("Por determinação do fisco")]
        DeterminacaoFisco = 5
    }

    public enum IndicadorPropriedade
    {
        [Attributes.DisplayName("Item de propriedade do informante e em seu poder")]
        InformanteEmPoder = 0,
        [Attributes.DisplayName("Item de propriedade do informante em posse de terceiros")]
        InformanteEmTerceiros = 1,
        [Attributes.DisplayName("Item de propriedade de terceiros em posse do informante")]
        TerceirosEmPoder = 2,
        [Attributes.DisplayName("Item de propriedade do informante, em seu poder ou em posse de terceiros")]
        InformanteGeral = 99
    }

    #endregion

    #region Bloco I

    public enum IndicadorMedicao1350
    {
        Analogico = 0,
        Digital = 1
    }

    #endregion

}