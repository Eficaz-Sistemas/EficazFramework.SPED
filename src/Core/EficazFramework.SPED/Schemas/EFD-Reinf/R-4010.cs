namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Pagamentos/créditos a beneficiário pessoa física
/// </summary>
[System.SerializableAttribute()]
public partial class R4010 : Evento, INotifyPropertyChanged {
    
    private ReinfEvtRetPF evtRetPFField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtRetPF evtRetPF
    {
        get => evtRetPFField;
        set
        {
            evtRetPFField = value;
            RaisePropertyChanged("evtRetPF");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#", Order = 1)]
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
    public override void GeraEventoID()
    {
        evtRetPFField.id = string.Format("ID{0}{1}{2}", (int)(evtRetPFField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRetPFField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtRetPFField.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtRetPF";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // PropertyChanged Members
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4010), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/{Versao}", IsNullable = false });
    }
}

/// <exclude />
public partial class ReinfEvtRetPF : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtRetPFIdeEstab ideEstabField;
    private string idField;

    /// <summary>
    /// Informações básicas do evento, como Período (AAAA-MM), ambiente (Produção, Homologação), 
    /// e indicador de retificação (substituição)
    /// </summary>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento_R40xx ideEvento
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
    public ReinfEvtRetPFIdeEstab ideEstab
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

}

/// <summary>
/// Identificação do Evento (Indicador de Retificação, Número Recibo Retif., Período Apuração, Ambiente, Emissor e Versão) (R-2010, R-2020, R-2040 e R-2060)
/// </summary>

/// <exclude />
public partial class ReinfEvtIdeEvento_R40xx : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorRetificacao indRetif
    {
        get => indRetifField;

        set
        {
            indRetifField = value;
            RaisePropertyChanged("indRetif");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecibo
    {
        get => nrReciboField;

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("nrRecibo");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string perApur
    {
        get => perApurField;

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public Ambiente tpAmb
    {
        get => tpAmbField;

        set
        {
            tpAmbField = value;
            RaisePropertyChanged("tpAmb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public EmissorEvento procEmi
    {
        get => procEmiField;

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string verProc
    {
        get => verProcField;

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstab : object, System.ComponentModel.INotifyPropertyChanged
{

    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;

    private ReinfEvtRetPFIdeEstabIdeBenef ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get => tpInscEstabField;
        set
        {
            tpInscEstabField = value;
            RaisePropertyChanged("tpInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstab
    {
        get => nrInscEstabField;
        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPFIdeEstabIdeBenef ideBenef
    {
        get => ideBenefField;
        set
        {
            ideBenefField = value;
            RaisePropertyChanged("ideBenef");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenef : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfBenefField;
    private string nmBenefField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeDep> ideDepField = new();
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgto> idePgtoField = new();
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaude> ideOpSaudeField = new();

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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeDep> ideDep
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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgto> idePgto
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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaude> ideOpSaude
    {
        get => ideOpSaudeField;
        set
        {
            ideOpSaudeField = value;
            RaisePropertyChanged("ideOpSaude");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeDep : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string natRendField;
    private string observField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto> infoPgtoField = new();

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order = 0)]
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged("natRend");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string observ
    {
        get => observField;
        set
        {
            observField = value;
            RaisePropertyChanged("observ");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto> infoPgto
    {
        get => infoPgtoField;
        set
        {
            infoPgtoField = value;
            RaisePropertyChanged("infoPgto");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto : object, System.ComponentModel.INotifyPropertyChanged {
    
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
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed> detDedField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento> rendIsentoField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRetField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA infoRRAField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJudField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExtField;

    /// <summary>
    /// Informar a data do fato gerador, ou, em caso de fato não tributável mas de 
    /// informação obrigatória conforme legislação vigente, a data do pagamento ou
    /// crédito, no formato AAAA-MM-DD. <br/><br/>
    /// <b>Validação:</b> A data informada deve estar compreendida no período de apuração
    /// ao qual se refere o arquivo, conforme informado em(perApur}, no formato
    /// AAAA-MM-DD.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType ="date", Order = 0)]
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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed> detDed
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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento> rendIsento
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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRet
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
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA infoRRA
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
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJud
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
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExt
    {
        get => infoPgtoExtField;
        set
        {
            infoPgtoExtField = value;
            RaisePropertyChanged("infoPgtoExt");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDeducaoField;
    private SimNao infoEntidField = SimNao.Nao;
    private string nrInscPrevCompField;
    private string vlrPatrocFunpField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen> benefPenField;

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
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order=5)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen> benefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged("benefPen");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento : object, System.ComponentModel.INotifyPropertyChanged {
    
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
    [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order = 3)]
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


    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrNRetidoField;
    private string vlrDepJudField;
    private string vlrCmpAnoCalField;
    private string vlrCmpAnoAntField;
    private string vlrRendSuspField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp> dedSuspField;

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
    [System.Xml.Serialization.XmlElementAttribute("dedSusp", Order=8)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp> dedSusp
    {
        get => dedSuspField;
        set
        {
            dedSuspField = value;
            RaisePropertyChanged("dedSusp");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDedSuspField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen> benefPenField;

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
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen> benefPen
    {
        get => benefPenField;
        set
        {
            benefPenField = value;
            RaisePropertyChanged("benefPen");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoProcesso tpProcRRAField;
    private string nrProcRRAField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string descRRAField;
    private int? qtdMesesRRAField;
    private string cnpjOrigRecursoField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJud despProcJudField;

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
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged("despProcJud");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas
    {
        get => vlrDespCustasField;
        set
        {
            vlrDespCustasField = value;
            RaisePropertyChanged("vlrDespCustas");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados
    {
        get => vlrDespAdvogadosField;
        set
        {
            vlrDespAdvogadosField = value;
            RaisePropertyChanged("vlrDespAdvogados");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv> ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged("ideAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscAdvField;
    
    private string nrInscAdvField;
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv
    {
        get => tpInscAdvField;
        set
        {
            tpInscAdvField = value;
            RaisePropertyChanged("tpInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv
    {
        get => nrInscAdvField;
        set
        {
            nrInscAdvField = value;
            RaisePropertyChanged("nrInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv
    {
        get => vlrAdvField;
        set
        {
            vlrAdvField = value;
            RaisePropertyChanged("vlrAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrProcField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string cnpjOrigRecursoField;
    private string descField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrProc
    {
        get => nrProcField;
        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
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
    [XmlElement(Order = 3)]
    public string desc
    {
        get => descField;
        set
        {
            descField = value;
            RaisePropertyChanged("desc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJud
    {
        get => despProcJudField;
        set
        {
            despProcJudField = value;
            RaisePropertyChanged("despProcJud");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas
    {
        get => vlrDespCustasField;
        set
        {
            vlrDespCustasField = value;
            RaisePropertyChanged("vlrDespCustas");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados
    {
        get => vlrDespAdvogadosField;
        set
        {
            vlrDespAdvogadosField = value;
            RaisePropertyChanged("vlrDespAdvogados");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdv
    {
        get => ideAdvField;
        set
        {
            ideAdvField = value;
            RaisePropertyChanged("ideAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscAdvField;
    private string nrInscAdvField;
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv
    {
        get => tpInscAdvField;
        set
        {
            tpInscAdvField = value;
            RaisePropertyChanged("tpInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv
    {
        get => nrInscAdvField;
        set
        {
            nrInscAdvField = value;
            RaisePropertyChanged("nrInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv
    {
        get => vlrAdvField;
        set
        {
            vlrAdvField = value;
            RaisePropertyChanged("vlrAdv");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExtField;

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
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExt
    {
        get => endExtField;
        set
        {
            endExtField = value;
            RaisePropertyChanged("endExt");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string dscLogradField;
    private string nrLogradField;
    private string complemField;
    private string bairroField;
    private string cidadeField;
    private string estadoField;
    private string codPostalField;
    private string telefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string dscLograd
    {
        get => dscLogradField;
        set
        {
            dscLogradField = value;
            RaisePropertyChanged("dscLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrLograd
    {
        get => nrLogradField;
        set
        {
            nrLogradField = value;
            RaisePropertyChanged("nrLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string complem
    {
        get => complemField;
        set
        {
            complemField = value;
            RaisePropertyChanged("complem");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string bairro
    {
        get => bairroField;
        set
        {
            bairroField = value;
            RaisePropertyChanged("bairro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string cidade
    {
        get => cidadeField;
        set
        {
            cidadeField = value;
            RaisePropertyChanged("cidade");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string estado
    {
        get => estadoField;
        set
        {
            estadoField = value;
            RaisePropertyChanged("estado");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string codPostal
    {
        get => codPostalField;
        set
        {
            codPostalField = value;
            RaisePropertyChanged("codPostal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string telef
    {
        get => telefField;
        set
        {
            telefField = value;
            RaisePropertyChanged("telef");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaude : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrInscField;
    private string regANSField;
    private string vlrSaudeField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb> infoReembField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl> infoDependPlField;

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
    [System.Xml.Serialization.XmlElementAttribute("infoReemb", Order=3)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb> infoReemb
    {
        get => infoReembField;
        set
        {
            infoReembField = value;
            RaisePropertyChanged("infoReemb");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoDependPl", Order=4)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl> infoDependPl
    {
        get => infoDependPlField;
        set
        {
            infoDependPlField = value;
            RaisePropertyChanged("infoDependPl");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private string vlrReembField;
    private string vlrReembAntField;

    /// <remarks/>
    [XmlElement(Order=0)]
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
    [XmlElement(Order=1)]
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
    [XmlElement(Order=2)]
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
    [XmlElement(Order=3)]
    public string vlrReembAnt
    {
        get => vlrReembAntField;
        set
        {
            vlrReembAntField = value;
            RaisePropertyChanged("vlrReembAnt");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfDepField;
    
    private string vlrSaudeField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep> infoReembDepField;

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
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep> infoReembDep
    {
        get => infoReembDepField;
        set
        {
            infoReembDepField = value;
            RaisePropertyChanged("infoReembDep");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <exclude />
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep : object, System.ComponentModel.INotifyPropertyChanged {
    
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

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
