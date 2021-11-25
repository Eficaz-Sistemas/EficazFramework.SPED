
namespace EficazFramework.SPED.Schemas.EFD_Contribuicoes
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum TipoEscritur
    {
        Original = 0,
        Retificadora = 1
    }

    public enum SituacaoEspecial
    {
        [System.ComponentModel.Description("Abertura")]
        Abertura = 0,
        [System.ComponentModel.Description("Cisão")]
        Cisao = 1,
        [System.ComponentModel.Description("Fusão")]
        Fusao = 2,
        [System.ComponentModel.Description("Incorporação")]
        Incorporacao = 3,
        [System.ComponentModel.Description("Encerramento")]
        Encerramento = 4,
        [System.ComponentModel.Description("")]
        Vazio = 99
    }

    public enum IndicadorNaturezaPJ
    {
        [System.ComponentModel.Description("Pessoa Jurídica em Geral")]
        PessoaJuridicaGeral = 0,
        [System.ComponentModel.Description("Sociedade Cooperativa")]
        SociedadeJuridicaCooperativa = 1,
        [System.ComponentModel.Description("Entidade Sujeita ao PIS/Pasep Exclusivamente pela Folha de Salários")]
        EntidadeSujeitaPISPasepExclusivamenteFolhaSalários = 2,
        [System.ComponentModel.Description("Pessoa Jurídica em Geral - SCP")]
        PessoaJuridicaGeralParticipanteSCP = 3,
        [System.ComponentModel.Description("Sociedade Cooperativa - SCP")]
        SociedadeJuridicaCooperativaSCP = 4,
        [System.ComponentModel.Description("Sociedade em Conta Participação")]
        SociedadeContaParticipacao = 5
    }

    public enum IndicadorTipoAtividadePreponderante
    {
        [System.ComponentModel.Description("0 - Industrial ou Equiparado")]
        IndustrialEquiparadoIndustrial = 0,
        [System.ComponentModel.Description("1 - Prestador de Serviços")]
        PrestadorServicos = 1,
        [System.ComponentModel.Description("2 - Atividade de Comércio")]
        AtividadeComercio = 2,
        [System.ComponentModel.Description("3 - Pessoas Jurídicas conf. Lei 9.718")]
        PessoasJuridicasLei9718 = 3,
        [System.ComponentModel.Description("4 - Atividade Imobiliária")]
        AtividadeImobiliaria = 4,
        [System.ComponentModel.Description("9 - Outros")]
        Outros = 9
    }

    public enum CodigoIncidenciaTributaria
    {
        Escrituracaodeoperacoescomincidenciaexclusivamentenoregimenaocumulativo = 1,
        Escrituracaodeoperacoescomincidenciaexclusivamentenoregimecumulativo = 2,
        Escrituracaodeoperacoescomincidencianosregimesnaocumulativoecumulativo = 3
    }

    public enum MetodoApropriacaoEnum
    {
        MetodoApropriacaoDireta = 1,
        MetododeRateioProporcional = 2
    }

    public enum TipoContribuicaoEnum
    {
        ApuracaodaContribuicaoAliquotaBasica = 1,
        ApuracaodaContribuicaoAliquotaEspecificas = 2
    }

    public enum CriterioEscrituracaoApuracao
    {
        RegimeCaixaF500 = 1,
        RegimeCompetenciaF550 = 2,
        RegimeCompetenciaACDeF = 9
    }

    public enum RegimeApuracaoCPRB
    {
        ContribuicaoPrevidenciariaExclusivamenteRecBruta = 1,
        ContribuicaoPrevidenciariaBaseRecBrutaeRemuneracoesIncIeII = 2
    }

    public enum CodigoTabelaIncidencia
    {
        TabelaI = 1,
        TabelaII = 2,
        TabelaIII = 3,
        TabelaIV = 4,
        TabelaV = 5,
        TabelaVI = 6,
        TabelaVII = 7,
        TabelaVIII = 8,
        TabelaIX = 9,
        TabelaX = 10,
        TabelaXI = 11,
        TabelaXII = 12,
        TabelaXIII = 13
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorTipoOperacao
    {
        ServicoContratadoEstabelecimento = 0,
        ServicoPrestadoEstabelecimento = 1
    }

    public enum IndicadorOrigemProcesso
    {
        JusticaFederal = 1,
        SecretariaRFB = 3,
        Outros = 9
    }

    public enum LocalExecucaoServico
    {
        ExecutadoPais = 0,
        ExecutadoExterior = 1
    }

    public enum IndicadorOrigemCredito
    {
        OperacaoMercadoInterno = 0,
        OperacaoImportacao = 1
    }

    public enum IndicadorOrigemCreditoAtivoImobilizado
    {
        AquisicaoMercadoInterno = 0,
        AquisicaoMercadoExterno = 1
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorApuracaoContribuicoes
    {
        ApuracaoBaseRegistroConsolidacao = 1,
        ApuracaoBaseRegistroIndividualizado = 2
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorTipoOperacaoBlocoD
    {
        Aquisicao = 0
    }

    public enum IndicadorNaturezaFrete
    {
        OperacaoVendasOnusSuportadoEstabelecimentoVendedor = 0,
        OperacaoVendasOnusSuportadoAdquirente = 1,
        OperacaoComprasMateriasPrimasGeradorCredito = 2,
        OperacaoComprasBensRevendaMatPrimaNaoGeradorCredito = 3,
        TransferenciaProdutosAcabadosEntreEstabelecimentoPj = 4,
        TransferenciaProdutosElaboracaoEntreEstabelecimentoPj = 5,
        Outras = 9
    }

    public enum IndicadorTipoReceita
    {
        ReceitaPropria_ServicosPrestados = 0,
        ReceitaPropria_CobrancaDebitos = 1,
        ReceitaPropria_VendaServicoPrePago = 2,
        ReceitaPropria_VendaServicoPrePagoPeriodo = 3,
        OutrasReceitasProprias = 4,
        ReceitaPropria_Cofaturamento = 5,
        ReceitaPropria_ServicosFaturar = 6,
        OutrasReceitasPropriasNaoCumulativa = 7,
        OutrasReceitasTerceiros = 8,
        OutrasReceitas = 9
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorTipoOperacaoF
    {
        OperacaoRepresentativaAquisCustosDespEncargRecIncPisCofins = 0,
        OperacaoRepresentativaRecAufSujPgtoContPisCofins = 1,
        OperacaoRepresentativaRecAufNSujPgtoContPisCofins = 2
    }

    public enum IdentificacaoBensGrupoAtivoImobilizado
    {
        EdificacoesBenfeitoriasImoveisProprios = 1,
        EdificacoesBenfeitoriasImoveisTerceiros = 2,
        Instalacoes = 3,
        Maquinas = 4,
        Equipamentos = 5,
        Veiculo = 6,
        Outros = 9
    }

    public enum IndicadorUtilizacaoBensAtivoImobilizado
    {
        ProducaoBensDestinadosVenda = 1,
        PrestacaoServicos = 2,
        LocacaoTerceiros = 3,
        Outros = 9
    }

    public enum IndicadorNumeroParcelas
    {
        Integral = 1,
        DozeMeses = 2,
        VinteQuatroMeses = 3,
        QuarentaOitoMeses = 4,
        SeisMeses = 5,
        OutraPeriodicidadeLei = 9
    }

    public enum IndicadorTipoOperacaoImob
    {
        VendaVistaUnidadeConcluida = 1,
        VendaPrazoUnidadeConcluida = 2,
        VendaVistaUnidadeConstrucao = 3,
        VendaPrazoUnidadeConstrucao = 4,
        Outras = 5
    }

    public enum IndicadorTipoUnidadeImobiliariaVendida
    {
        TerrenoAdquiridoVenda = 1,
        TerrenoDecorrenteLoteamento = 2,
        LoteOriundoDesmembramentoTerreno = 3,
        UnidadeResultanteIncorporacaoImobiliaria = 4,
        PredioConstruidoEmConstrucaoVenda = 5,
        Outras = 6
    }

    public enum IndicadoNaturezaEspecEmpreend
    {
        Consorcio = 1,
        SCP = 2,
        IncorporacaoCondominio = 3,
        Outras = 4
    }

    public enum IndicadorComposicaoReceitaPeriodo
    {
        Clientes = 1,
        AdministradoraCartaoCredito = 2,
        TituloCreditoDuplicata = 3,
        DocumentoFiscal = 4,
        ItemVendido = 5,
        Outros = 99
    }

    public enum IndicadorNatRetFonte
    {
        RetencaoOrgaoAutarquiasFundacoesFederais = 1,
        RetencaoOutrasEntidadesAdministracaoPublicaFederal = 2,
        RetencaoPessoasJuridicasDireitoPrivado = 3,
        RecolhimentoSociedadeCooperativa = 4,
        RetencaoFabricanteMaquinasVeiculos = 5,
        OutrasRetencoes = 99
    }

    public enum IndicadorNaturezaReceita
    {
        ReceitaNaturezaNaoCumulativa = 0,
        ReceitaNaturezaCumulativa = 1
    }

    public enum IndicadorCondicaoPJDeclarante
    {
        BeneficiariaRetencao = 0,
        ResponsavelRecolhimento = 1
    }

    public enum IndicadorOrigemDeducoesDiversas
    {
        CreditoPresumidoMedicamentos = 1,
        CreditoAdmitidoRegimeCumulativoBebibasFrias = 2,
        ContribuicaoPagaPeloSubstTribut = 3,
        SubstTribNaoOcorrenciaFatoGerador = 4,
        OutrasDeducoes = 9
    }

    public enum IndicadorNatDeducao
    {
        DeducaoNaturezaNaoCumulativa = 0,
        DeducaoNaturezaCumulativa = 1
    }

    public enum IndicadorNaturezaEventoSucessao
    {
        Incorporacao = 1,
        Fusao = 2,
        CisaoTotal = 3,
        CisaoParcial = 4,
        Outros = 99
    }
    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IdentificaoOperacaoPeriodo
    {
        ExclusivamenteOperacoesInstFinanceiras = 1,
        ExclusivamenteOperacoesSegurosPrivados = 2,
        ExclusivamenteOperacoesPrevidenciaComplementar = 3,
        ExclusivamenteOperacoesCapitalizacao = 4,
        ExclusivamenteOperacoesPlanosAssistenciaSaude = 5,
        RealizouOperacoesReferenteMaisIndicadoresAcima = 6
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorCreditoOriundo
    {
        OperacoesProprias = 0,
        EventoIncorporacaoCisaoFusao = 1
    }

    public enum IndicadorCredDispPeriodo
    {
        UtilizacaoValorTotal = 0,
        UtilizacaoValorParcial = 1
    }

    public enum IndicadorTipoAjuste
    {
        AjusteReducao = 0,
        AjusteAcrescimo = 1
    }

    public enum IndicadorTipoSociedadeCooperativa
    {
        CooperativaProducaoAgropecuaria = 1,
        CooperativaConsumo = 2,
        CooperativaCredito = 3,
        CooperativaEletrificacaoRural = 4,
        CooperativaTransporteRodoviarioCargas = 5,
        CooperativaMedicos = 6,
        Outras = 9
    }

    public enum NaturezaCreditoDiferido
    {
        CreditoAliquotaBasica = 1,
        CreditoAliquotaDiferenciada = 2,
        CreditoAliquotaUnidadeProduto = 3,
        CreditoPresumidoAgroindustria = 4
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorTipoAjusteBlocoP
    {
        AjusteReducao = 0,
        AjusteAcrescimo = 1
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum IndicadorNaturezaAcaoJudicialJF
    {
        DecisaoJudicialTransitadaJulgadoFavorPJ = 1,
        DecisaoJudicialNaoTransitadaJulgadoFavorPJ = 2,
        DecisaoJudicialOriundaLiminarMandadoSeguranca = 3,
        DecisaoJudicialOriundaLiminarMedidaCautelar = 4,
        DecisaoJudicialOriundaAntecipacaoTutela = 5,
        DecisaoJudicialVinculadaDepositoAdmOuJudMontanteIntegral = 6,
        MedidaJudicialPJNaoAutor = 7,
        SumulaVinculanteAprovadaSTF = 8,
        Outros = 99
    }

    public enum IndicadorNaturezaAcaoProcAdmSRFB
    {
        ProcessoAdministrativoConsulta = 1,
        DespachoDescisorio = 2,
        AtoDeclaratorioExecutivo = 3,
        AtoDeclaratorioInterpretativo = 4,
        DecisaoAdministrativaDRJouCARF = 5,
        AutoInfracao = 6,
        Outros = 99
    }

    public enum IndicadorOrigemCreditoBloco1
    {
        CreditoDecorrenteOperacoesProprias = 1,
        CreditoTransferidoPJsucedida = 2
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public enum NaturezaBaseCalculo
    {
        [System.ComponentModel.Description("01 - Aquisição de bens para revenda")]
        AquisBensRevenda = 1,
        [System.ComponentModel.Description("02 - Aquisição de bens utilizados como insumo")]
        AquisBensInsumo = 2,
        [System.ComponentModel.Description("03 - Aquisição de serviços utilizados como insumo")]
        AquisServicosInsumo = 3,
        [System.ComponentModel.Description("04 - Energia elétrica e térmica, inclusive sob a forma de vapor")]
        EnEletrica = 4,
        [System.ComponentModel.Description("05 - Aluguéis de prédios")]
        AlugueisPredios = 5,
        [System.ComponentModel.Description("06 - Aluguéis de máquinas e equipamentos")]
        AlugueisMaqEquip = 6,
        [System.ComponentModel.Description("07 - Armazenagem de mercadoria e frete na operação de venda")]
        ArmFreteOpVenda = 7,
        [System.ComponentModel.Description("08 - Contraprestações de arrendamento mercantil")]
        ContrPrestArrendMercantil = 8,
        [System.ComponentModel.Description("09 - Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito sobre encargos de depreciação)")]
        MaqEquipImob_CreditoDepreciacao = 9,
        [System.ComponentModel.Description("10 -Máquinas, equipamentos e outros bens incorporados ao ativo imobilizado (crédito com base no valor de aquisição)")]
        MaqEquipImob_CreditoAquisicao = 10,
        [System.ComponentModel.Description("11 - Amortização e Depreciação de edificações e benfeitorias em imóveis")]
        AmortDeprecEdificacoesBenfImoveis = 11,
        [System.ComponentModel.Description("12 - Devolução de Vendas Sujeitas à Incidência Não-Cumulativa")]
        DevVendasNaoCumulativas = 12,
        [System.ComponentModel.Description("13 - Outras Operações com Direito a Crédito (inclusive os créditos presumidos sobre receitas)")]
        OutOpDireitoCredito = 13,
        [System.ComponentModel.Description("14 - Atividade de Transporte de Cargas – Subcontratação")]
        OpTransporteCargas = 14,
        [System.ComponentModel.Description("15 - Atividade Imobiliária – Custo Incorrido de Unidade Imobiliária")]
        Imobiliaria_CustoIncorrido = 15,
        [System.ComponentModel.Description("16 - Atividade Imobiliária – Custo Orçado de unidade não concluída")]
        Imobiliaria_CustoOrcao = 16,
        [System.ComponentModel.Description("17 - Atividade de Prestação de Serviços de Limpeza, Conservação e Manutenção – vale-transporte, vale-refeição ou vale-alimentação, fardamento ou uniforme.")]
        LimpezaConservacao = 17,
        [System.ComponentModel.Description("18 - Estoque de abertura de bensW")]
        EstoqueAbertura = 18
    }

    public enum ContribuicaoSocialApurada
    {
        [System.ComponentModel.Description("01 - Contribuição não-cumulativa apurada a alíquota básica")]
        NCumulativaAliqBasica = 1,
        [System.ComponentModel.Description("02 - Contribuição não-cumulativa apurada a alíquotas diferenciadas")]
        NCumulativaAliqDiferenciada = 2,
        [System.ComponentModel.Description("03 - Contribuição não-cumulativa apurada a alíquota por unidade de medida de produto")]
        NCumulativaAliqUnidade = 3,
        [System.ComponentModel.Description("04 - Contribuição não-cumulativa apurada a alíquota básica - Atividade Imobiliária")]
        NCumulativaAliqBasicaImobiliaria = 4,
        [System.ComponentModel.Description("31 - Contribuição apurada por substituição tributária")]
        SubstituicaoTributaria = 31,
        [System.ComponentModel.Description("32 - Contribuição apurada por substituição tributária - Vendas à Zona Franca de Manaus")]
        SubstTributZonaFranca = 32,
        [System.ComponentModel.Description("51 - Contribuição cumulativa apurada a alíquota básica")]
        CumulativaAliqBasica = 51,
        [System.ComponentModel.Description("52 - Contribuição cumulativa apurada a alíquotas diferenciadas")]
        CumulativaAliqDiferenciada = 52,
        [System.ComponentModel.Description("53 - Contribuição cumulativa apurada a alíquota por unidade de medida de produto")]
        CumulativaAliqUnidade = 53,
        [System.ComponentModel.Description("54 - Contribuição cumulativa apurada a alíquota básica - Atividade Imobiliária")]
        CumulativaAliqBasicaImobiliaria = 54,
        [System.ComponentModel.Description("70 - Contribuição apurada da Atividade Imobiliária - RET")]
        CumulativaAliqBasicaImobiliariaRET = 70,
        [System.ComponentModel.Description("71 - Contribuição apurada de SCP - Incidência Não Cumulativa")]
        SCPNaoCumulativa = 71,
        [System.ComponentModel.Description("72 - Contribuição apurada de SCP - Incidência Cumulativa")]
        SCPCumulativa = 72,
        [System.ComponentModel.Description("99  - Contribuição para o PIS/Pasep - Folha de Salários")]
        FolhaSalarios = 99
    }


    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}