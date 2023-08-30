namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiário pessoa física
/// </summary>
/// <example>
/// ```csharp
/// // Rendimento Isento:
/// var evento = new R4010()
/// {
///     evtRetPF = new R4010EventoRetencaoPf()
///     {
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideEstab = new R4010IdentificacaoEstabelecimentoPf()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideBenef = new R4010IdentificacaoBeneficiarioPf()
///             {
///                 // identificação do beneficiário
///                 cpfBenef = "47363361886",
///                 nmBenef = "Pierre de Fermat",
///                 // listagem de pagamentos
///                 idePgto = new()
///                 {
///                     // identificação do pagamento
///                     new R4010IdentificacaoPagtoPf()
///                     {
///                         // informações do pagamento
///                         // Utilizar a tabela 01, do Anexo I do Manual
///                         natRend = "12001", // Lucro e dividendo
///                         observ = "Lucros do exercício de 2021",
///                         infoPgto = new()
///                         {
///                             new R4010InfoPagtoPf()
///                             {
///                                 DataFatoGerador = System.DateTime.Now,
///                                 vlrRendBruto = 152725.25M.ToString("f2"),
///                                 // desmembramento da parte isenta dos rendimentos (que neste caso é todo isento)
///                                 rendIsento = new()
///                                 {
///                                     new R4010InfoRendIsento()
///                                     {
///                                         vlrIsento = 152725.25M.ToString("f2"),
///                                         descRendimento = "Lucros do exercício de 2021"
///                                     }
///                                 }
///                             },
///                         },
///                     },
///                 }
///             }
///         }
///     }
/// };
/// 
/// // Rendimento Tributável:
/// var evento = new R4010()
/// {
///     evtRetPF = new R4010EventoRetencaoPf()
///     {
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = "2022-08",
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "6.0"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "34785515000166",
///         },
///         ideEstab = new R4010IdentificacaoEstabelecimentoPf()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideBenef = new R4010IdentificacaoBeneficiarioPf()
///             {
///                 // identificação do beneficiário
///                 cpfBenef = "47363361886",
///                 nmBenef = "Pierre de Fermat",
///                 // listagem de pagamentos
///                 idePgto = new()
///                 {
///                     // identificação do pagamento
///                     new R4010IdentificacaoPagtoPf()
///                     {
///                         // Utilizar a tabela 01, do Anexo I do Manual
///                         natRend = "10001", // Lucro e dividendo
///                         observ = "Algum rendimento sem vínculo empregatício", // na verdade, não imagino que exista esta possibilidade
///                         // informações do pagamento
///                         infoPgto = new()
///                         {
///                             new R4010InfoPagtoPf()
///                             {
///                                 DataFatoGerador = System.DateTime.Now,
///                                 vlrRendBruto = 750.ToString("f2"),
///                                 vlrRendTrib = 750.ToString("f2"),
///                                 vlrIR = 112.5.ToString("f2")
///                             },
///                         },
///                     },
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[System.SerializableAttribute()]
public partial class R4010 : Evento
{
    private R4010EventoRetencaoPf evtRetPFField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R4010EventoRetencaoPf evtRetPF
    {
        get => evtRetPFField;
        set
        {
            evtRetPFField = value;
            RaisePropertyChanged("evtRetPF");
        }
    }

    /// <exclude/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
        }
    }


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtRetPFField.id = $"ID{(int)(evtRetPFField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtRetPFField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtRetPFField.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtRetPF";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R4010), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/{Versao}", IsNullable = false });
}

/// <exclude />
public partial class R4010EventoRetencaoPf : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R4010IdentificacaoEstabelecimentoPf ideEstabField;
    private string idField;

    /// <summary>
    /// Informações básicas do evento, como Período (AAAA-MM), ambiente (Produção, Homologação), 
    /// e indicador de retificação (substituição)
    /// </summary>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <summary>
    /// Identificação do Contribuite (pagador)
    /// Utilizar sempre os dados da Matriz
    /// </summary>
    [XmlElement(Order = 1)]
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;
        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <summary>
    /// Identificação do estabelecimento (pagador)
    /// Neste caso utilizar o CNPJ que realiza o pagamento (Seja ele matrix ou filial)
    /// </summary>
    [XmlElement(Order = 2)]
    public R4010IdentificacaoEstabelecimentoPf ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged("id");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoEstabelecimentoPf : R4010eR4020IdentificacaoEstabelecimentoBase
{
    private R4010IdentificacaoBeneficiarioPf ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R4010IdentificacaoBeneficiarioPf ideBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged("ideBenef");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoBeneficiarioPf : EfdReinfBindableObject
{

    private string cpfBenefField;
    private string nmBenefField;
    private List<R4010IdentificacaoDependente> ideDepField = new();
    private List<R4010IdentificacaoPagtoPf> idePgtoField = new();
    private List<R4010IdentificacaoOpSaude> ideOpSaudeField = new();

    /// <summary>
    /// CPF do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 0)]
    public string cpfBenef
    {
        get => cpfBenefField;
        set
        {
            cpfBenefField = value;
            RaisePropertyChanged("cpfBenef");
        }
    }

    /// <summary>
    /// Nome do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 1)]
    public string nmBenef
    {
        get => nmBenefField;
        set
        {
            nmBenefField = value;
            RaisePropertyChanged("nmBenef");
        }
    }

    /// <summary>
    /// Listagem dos dependentes do Beneficiário (quando aplicável),
    /// utilizados na dedução de IRRF
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideDep", Order = 2)]
    public List<R4010IdentificacaoDependente> ideDep
    {
        get => ideDepField;
        set
        {
            ideDepField = value;
            RaisePropertyChanged("ideDep");
        }
    }

    /// <summary>
    /// Listagem dos pagamentos ao beneficiário
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("idePgto", Order = 3)]
    public List<R4010IdentificacaoPagtoPf> idePgto
    {
        get => idePgtoField;
        set
        {
            idePgtoField = value;
            RaisePropertyChanged("idePgto");
        }
    }

    /// <summary>
    /// Informações sobre a(s) Operadora(s) de Saúde, caso tenham sido abatidas
    /// despesas médicas no Rendimento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideOpSaude", Order = 4)]
    public List<R4010IdentificacaoOpSaude> ideOpSaude
    {
        get => ideOpSaudeField;
        set
        {
            ideOpSaudeField = value;
            RaisePropertyChanged("ideOpSaude");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoDependente : EfdReinfBindableObject
{

    private string cpfDepField;
    private RelacaoDependencia relDepField = RelacaoDependencia.Conjuge;
    private string descrDepField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public RelacaoDependencia relDep
    {
        get => relDepField;
        set
        {
            relDepField = value;
            RaisePropertyChanged("relDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descrDep
    {
        get => descrDepField;
        set
        {
            descrDepField = value;
            RaisePropertyChanged("descrDep");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoPagtoPf : R4010eR4020IdentificacaoPagtoBase
{
    private List<R4010InfoPagtoPf> infoPgtoField = new();

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 2)]
    public List<R4010InfoPagtoPf> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }
}

/// <exclude />
public partial class R4010InfoPagtoPf : EfdReinfBindableObject
{
    private System.DateTime dtFGField;
    private string compFPField;
    private string indDecTercField;
    private string vlrRendBrutoField;
    private string vlrRendTribField;
    private string vlrIRField;
    private string indRRAField;
    private IndicadorFciScp? indFciScpField;
    private string nrInscFciScpField;
    private string percSCPField;
    private string indJudField;
    private string paisResidExtField;
    private List<R4010DetalhamentoDeducao> detDedField;
    private List<R4010InfoRendIsento> rendIsentoField;
    private List<R4010InfoProcessoRetencao> infoProcRetField;
    private R4010InfomacaoRRA infoRRAField;
    private R4010eR4020InfomacaoProcessoJudic infoProcJudField;
    private R4010InfoPagtoResExt infoPgtoExtField;

    /// <summary>
    /// Informar a data do fato gerador, ou, em caso de fato não tributável mas de 
    /// informação obrigatória conforme legislação vigente, a data do pagamento ou
    /// crédito, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação:</b> A data informada deve estar compreendida no período de apuração
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato
    /// AAAA-MM-DD.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType = "date", Order = 0)]
    public System.DateTime DataFatoGerador
    {
        get => dtFGField;
        set
        {
            dtFGField = value;
            RaisePropertyChanged("DataFatoGerador");
        }
    }

    /// <summary>
    /// Informar a competência a que se refere os rendimentos.<br/><br/>
    /// <b>Validação:</b> Informação permitida apenas se a natureza de rendimento
    /// informada em { natRend } for do grupo 10 da Tabela 01 ou se constar "S" na
    /// coluna "13°" da mesma tabela.
    /// <br/>Se informado, não pode ser superior à data atual e deve estar no formato:<br/>
    /// a) AAAA, se {indDecTerc} = [S];<br/>
    /// b) AAAA-MM, nos demais casos
    /// </summary>
    [XmlElement(Order = 1)]
    public string compFP
    {
        get => compFPField;
        set
        {
            compFPField = value;
            RaisePropertyChanged("compFP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string indDecTerc
    {
        get => indDecTercField;
        set
        {
            indDecTercField = value;
            RaisePropertyChanged("indDecTerc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrRendBruto
    {
        get => vlrRendBrutoField;
        set
        {
            vlrRendBrutoField = value;
            RaisePropertyChanged("vlrRendBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRendTrib
    {
        get => vlrRendTribField;
        set
        {
            vlrRendTribField = value;
            RaisePropertyChanged("vlrRendTrib");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrIR
    {
        get => vlrIRField;
        set
        {
            vlrIRField = value;
            RaisePropertyChanged("vlrIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string indRRA
    {
        get => indRRAField;
        set
        {
            indRRAField = value;
            RaisePropertyChanged("indRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public IndicadorFciScp? indFciScp
    {
        get => indFciScpField;
        set
        {
            indFciScpField = value;
            RaisePropertyChanged("indFciScp");
        }
    }
    public bool ShouldSerializeindFciScp() => indFciScp.HasValue;

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string nrInscFciScp
    {
        get => nrInscFciScpField;
        set
        {
            nrInscFciScpField = value;
            RaisePropertyChanged("nrInscFciScp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string percSCP
    {
        get => percSCPField;
        set
        {
            percSCPField = value;
            RaisePropertyChanged("percSCP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string indJud
    {
        get => indJudField;
        set
        {
            indJudField = value;
            RaisePropertyChanged("indJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 11)]
    public string paisResidExt
    {
        get => paisResidExtField;
        set
        {
            paisResidExtField = value;
            RaisePropertyChanged("paisResidExt");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("detDed", Order = 12)]
    public List<R4010DetalhamentoDeducao> detDed
    {
        get => detDedField;
        set
        {
            detDedField = value;
            RaisePropertyChanged("detDed");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("rendIsento", Order = 13)]
    public List<R4010InfoRendIsento> rendIsento
    {
        get => rendIsentoField;
        set
        {
            rendIsentoField = value;
            RaisePropertyChanged("rendIsento");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 14)]
    public List<R4010InfoProcessoRetencao> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged("infoProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 15)]
    public R4010InfomacaoRRA infoRRA
    {
        get => infoRRAField;
        set
        {
            infoRRAField = value;
            RaisePropertyChanged("infoRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 16)]
    public R4010eR4020InfomacaoProcessoJudic infoProcJud
    {
        get => infoProcJudField;
        set
        {
            infoProcJudField = value;
            RaisePropertyChanged("infoProcJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 17)]
    public R4010InfoPagtoResExt infoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged("infoPgtoExt");
        }
    }
}

/// <exclude />
public partial class R4010DetalhamentoDeducao : EfdReinfBindableObject
{
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDeducaoField;
    private SimNao infoEntidField = SimNao.Nao;
    private string nrInscPrevCompField;
    private string vlrPatrocFunpField;
    private List<R4010BeneficiarioDeducao> benefPenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorTipoDeducaoPrevidenciaria indTpDeducao
    {
        get => indTpDeducaoField;
        set
        {
            indTpDeducaoField = value;
            RaisePropertyChanged("indTpDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDeducao
    {
        get => vlrDeducaoField;
        set
        {
            vlrDeducaoField = value;
            RaisePropertyChanged("vlrDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public SimNao infoEntid
    {
        get => infoEntidField;
        set
        {
            infoEntidField = value;
            RaisePropertyChanged("infoEntid");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string nrInscPrevComp
    {
        get => nrInscPrevCompField;
        set
        {
            nrInscPrevCompField = value;
            RaisePropertyChanged("nrInscPrevComp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrPatrocFunp
    {
        get => vlrPatrocFunpField;
        set
        {
            vlrPatrocFunpField = value;
            RaisePropertyChanged("vlrPatrocFunp");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order = 5)]
    public List<R4010BeneficiarioDeducao> benefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged("benefPen");
        }
    }
}

/// <exclude />
public partial class R4010BeneficiarioDeducao : EfdReinfBindableObject
{
    private string cpfDepField;
    private string vlrDepenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDepen
    {
        get => vlrDepenField;
        set
        {
            vlrDepenField = value;
            RaisePropertyChanged("vlrDepen");
        }
    }
}

/// <exclude />
public partial class R4010InfoRendIsento : EfdReinfBindableObject
{
    private TipoIsencaoPF tpIsencaoField;
    private string vlrIsentoField;
    private string descRendimentoField;
    private System.DateTime? dtLaudoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoIsencaoPF tpIsencao
    {
        get => tpIsencaoField;
        set
        {
            tpIsencaoField = value;
            RaisePropertyChanged("tpIsencao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrIsento
    {
        get => vlrIsentoField;
        set
        {
            vlrIsentoField = value;
            RaisePropertyChanged("vlrIsento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descRendimento
    {
        get => descRendimentoField;
        set
        {
            descRendimentoField = value;
            RaisePropertyChanged("descRendimento");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "date", Order = 3)]
    public System.DateTime? dtLaudo
    {
        get => dtLaudoField;
        set
        {
            dtLaudoField = value;
            RaisePropertyChanged("dtLaudo");
        }
    }
    public bool ShouldSerializedtLaudo() => dtLaudo.HasValue;
}

/// <summary>
/// Informações de processos relacionados a não retenção de tributos ou a depósitos judiciais.
/// </summary>
/// <exclude />
public partial class R4010InfoProcessoRetencao : EfdReinfBindableObject
{
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrNRetidoField;
    private string vlrDepJudField;
    private string vlrCmpAnoCalField;
    private string vlrCmpAnoAntField;
    private string vlrRendSuspField;
    private List<R4010DetalhamentoDedSuspensa> dedSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged("tpProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged("nrProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrNRetido
    {
        get => vlrNRetidoField;
        set
        {
            vlrNRetidoField = value;
            RaisePropertyChanged("vlrNRetido");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrDepJud
    {
        get => vlrDepJudField;
        set
        {
            vlrDepJudField = value;
            RaisePropertyChanged("vlrDepJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrCmpAnoCal
    {
        get => vlrCmpAnoCalField;
        set
        {
            vlrCmpAnoCalField = value;
            RaisePropertyChanged("vlrCmpAnoCal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrCmpAnoAnt
    {
        get => vlrCmpAnoAntField;
        set
        {
            vlrCmpAnoAntField = value;
            RaisePropertyChanged("vlrCmpAnoAnt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrRendSusp
    {
        get => vlrRendSuspField;
        set
        {
            vlrRendSuspField = value;
            RaisePropertyChanged("vlrRendSusp");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dedSusp", Order = 8)]
    public List<R4010DetalhamentoDedSuspensa> dedSusp
    {
        get => dedSuspField;
        set
        {
            dedSuspField = value;
            RaisePropertyChanged("dedSusp");
        }
    }
}

/// <exclude />
public partial class R4010DetalhamentoDedSuspensa : EfdReinfBindableObject
{
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDedSuspField;
    private List<R4010DetalhamentoDedSuspensaInfoBenef> benefPenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorTipoDeducaoPrevidenciaria indTpDeducao
    {
        get => indTpDeducaoField;
        set
        {
            indTpDeducaoField = value;
            RaisePropertyChanged("indTpDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDedSusp
    {
        get => vlrDedSuspField;
        set
        {
            vlrDedSuspField = value;
            RaisePropertyChanged("vlrDedSusp");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order = 2)]
    public List<R4010DetalhamentoDedSuspensaInfoBenef> benefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged("benefPen");
        }
    }
}

/// <exclude />
public partial class R4010DetalhamentoDedSuspensaInfoBenef : EfdReinfBindableObject
{

    private string cpfDepField;
    private string vlrDepenSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDepenSusp
    {
        get => vlrDepenSuspField;
        set
        {
            vlrDepenSuspField = value;
            RaisePropertyChanged("vlrDepenSusp");
        }
    }
}

/// <exclude />
public partial class R4010InfomacaoRRA : EfdReinfBindableObject
{
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string descRRAField;
    private int? qtdMesesRRAField;
    private string cnpjOrigRecursoField;
    private R4010eR4020DespesasAdvogado despProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProcRRA
    {
        get => tpProcRRAField;
        set
        {
            tpProcRRAField = value;
            RaisePropertyChanged("tpProcRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRRA
    {
        get => nrProcRRAField;
        set
        {
            nrProcRRAField = value;
            RaisePropertyChanged("nrProcRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorOrigemDosRecursos indOrigRec
    {
        get => indOrigRecField;
        set
        {
            indOrigRecField = value;
            RaisePropertyChanged("indOrigRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string descRRA
    {
        get => descRRAField;
        set
        {
            descRRAField = value;
            RaisePropertyChanged("descRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public int? qtdMesesRRA
    {
        get => qtdMesesRRAField;
        set
        {
            qtdMesesRRAField = value;
            RaisePropertyChanged("qtdMesesRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string cnpjOrigRecurso
    {
        get => cnpjOrigRecursoField;
        set
        {
            cnpjOrigRecursoField = value;
            RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public R4010eR4020DespesasAdvogado despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged("despProcJud");
        }
    }
}

///<summary>
///Informações complementares relativas a pagamentos a residente fiscal no exterior
///</summary>
/// <exclude />
public partial class R4010InfoPagtoResExt : EfdReinfBindableObject
{
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;

    private R4010e4020EnderecoResExterior endExtField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorNIF indNIF
    {
        get => indNIFField;
        set
        {
            indNIFField = value;
            RaisePropertyChanged("indNIF");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nifBenef
    {
        get => nifBenefField;
        set
        {
            nifBenefField = value;
            RaisePropertyChanged("nifBenef");
        }
    }

    /// <summary>
    /// Utilizar opções disponíveis em <see cref="IndicadoresIRRF"/> (static)
    /// </summary>
    /// <remarks/>
    [XmlElement(Order = 2)]
    public string frmTribut
    {
        get => frmTributField;
        set
        {
            frmTributField = value;
            RaisePropertyChanged("frmTribut");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public R4010e4020EnderecoResExterior endExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged("endExt");
        }
    }
}

/// <exclude />
public partial class R4010IdentificacaoOpSaude : EfdReinfBindableObject
{
    private string nrInscField;
    private string regANSField;
    private string vlrSaudeField;
    private List<R4010OpSaudeInfoReemb> infoReembField;
    private List<R4010OpSaudeInfoDependente> infoDependPlField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string regANS
    {
        get => regANSField;
        set
        {
            regANSField = value;
            RaisePropertyChanged("regANS");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrSaude
    {
        get => vlrSaudeField;
        set
        {
            vlrSaudeField = value;
            RaisePropertyChanged("vlrSaude");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoReemb", Order = 3)]
    public List<R4010OpSaudeInfoReemb> infoReemb
    {
        get => infoReembField;
        set
        {
            infoReembField = value;
            RaisePropertyChanged("infoReemb");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoDependPl", Order = 4)]
    public List<R4010OpSaudeInfoDependente> infoDependPl
    {
        get => infoDependPlField;
        set
        {
            infoDependPlField = value;
            RaisePropertyChanged("infoDependPl");
        }
    }
}

/// <exclude />
public partial class R4010OpSaudeInfoReemb : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private string vlrReembField;
    private string vlrReembAntField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrReemb
    {
        get => vlrReembField;
        set
        {
            vlrReembField = value;
            RaisePropertyChanged("vlrReemb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrReembAnt
    {
        get => vlrReembAntField;
        set
        {
            vlrReembAntField = value;
            RaisePropertyChanged("vlrReembAnt");
        }
    }
}

/// <exclude />
public partial class R4010OpSaudeInfoDependente : EfdReinfBindableObject
{
    private string cpfDepField;

    private string vlrSaudeField;

    private List<R4010OpSaudeReembolsoDependente> infoReembDepField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep
    {
        get => cpfDepField;
        set
        {
            cpfDepField = value;
            RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrSaude
    {
        get => vlrSaudeField;
        set
        {
            vlrSaudeField = value;
            RaisePropertyChanged("vlrSaude");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoReembDep", Order = 2)]
    public List<R4010OpSaudeReembolsoDependente> infoReembDep
    {
        get => infoReembDepField;
        set
        {
            infoReembDepField = value;
            RaisePropertyChanged("infoReembDep");
        }
    }
}

/// <exclude />
public partial class R4010OpSaudeReembolsoDependente : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string vlrReembField;
    private string vlrReembAntField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrReemb
    {
        get => vlrReembField;
        set
        {
            vlrReembField = value;
            RaisePropertyChanged("vlrReemb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrReembAnt
    {
        get => vlrReembAntField;
        set
        {
            vlrReembAntField = value;
            RaisePropertyChanged("vlrReembAnt");
        }
    }
}