namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
[System.Xml.Serialization.XmlRootAttribute("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01", IsNullable=false)]
public partial class R4010 : IEfdReinfEvt, INotifyPropertyChanged {
    
    private ReinfEvtRetPF evtRetPFField;
    private SignatureType signatureField;
    
    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtRetPF evtRetPF {
        get {
            return this.evtRetPFField;
        }
        set {
            this.evtRetPFField = value;
            this.RaisePropertyChanged("evtRetPF");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature {
        get {
            return this.signatureField;
        }
        set {
            this.signatureField = value;
            this.RaisePropertyChanged("Signature");
        }
    }


    // IEfdReinfEvt Members
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
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4010));
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPF : object, System.ComponentModel.INotifyPropertyChanged {
    
    private ReinfEvtIdeEvento_R40xx ideEventoField;
    private ReinfEvtIdeContri ideContriField;
    private ReinfEvtRetPFIdeEstab ideEstabField;
    private string idField;

    /// <summary>
    /// Informações básicas do evento, como Período (AAAA-MM), ambiente (Produção, Homologação), 
    /// e indicador de retificação (substituição)
    /// </summary>
    [XmlElement(Order = 0)]
    public ReinfEvtIdeEvento_R40xx ideEvento {
        get {
            return this.ideEventoField;
        }
        set {
            this.ideEventoField = value;
            this.RaisePropertyChanged("ideEvento");
        }
    }

    /// <summary>
    /// Identificação do Contribuite (pagador)
    /// Utilizar sempre os dados da Matriz
    /// </summary>
    [XmlElement(Order = 1)]
    public ReinfEvtIdeContri ideContri {
        get {
            return this.ideContriField;
        }
        set {
            this.ideContriField = value;
            this.RaisePropertyChanged("ideContri");
        }
    }

    /// <summary>
    /// Identificação do estabelecimento (pagador)
    /// Neste caso utilizar o CNPJ que realiza o pagamento (Seja ele matrix ou filial)
    /// </summary>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPFIdeEstab ideEstab {
        get {
            return this.ideEstabField;
        }
        set {
            this.ideEstabField = value;
            this.RaisePropertyChanged("ideEstab");
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string id {
        get {
            return this.idField;
        }
        set {
            this.idField = value;
            this.RaisePropertyChanged("id");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Identificação do Evento (Indicador de Retificação, Número Recibo Retif., Período Apuração, Ambiente, Emissor e Versão) (R-2010, R-2020, R-2040 e R-2060)
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true)]
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
        get
        {
            return indRetifField;
        }

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
        get
        {
            return nrReciboField;
        }

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
        get
        {
            return perApurField;
        }

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
        get
        {
            return tpAmbField;
        }

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
        get
        {
            return procEmiField;
        }

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
        get
        {
            return verProcField;
        }

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

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstab : object, System.ComponentModel.INotifyPropertyChanged
{

    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;

    private ReinfEvtRetPFIdeEstabIdeBenef ideBenefField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get
        {
            return this.tpInscEstabField;
        }
        set
        {
            this.tpInscEstabField = value;
            this.RaisePropertyChanged("tpInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstab
    {
        get
        {
            return this.nrInscEstabField;
        }
        set
        {
            this.nrInscEstabField = value;
            this.RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetPFIdeEstabIdeBenef ideBenef
    {
        get
        {
            return this.ideBenefField;
        }
        set
        {
            this.ideBenefField = value;
            this.RaisePropertyChanged("ideBenef");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
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
    public string cpfBenef {
        get {
            return this.cpfBenefField;
        }
        set {
            this.cpfBenefField = value;
            this.RaisePropertyChanged("cpfBenef");
        }
    }

    /// <summary>
    /// Nome do Beneficiário recebedor dos Rendimentos
    /// </summary>
    [XmlElement(Order = 1)]
    public string nmBenef {
        get {
            return this.nmBenefField;
        }
        set {
            this.nmBenefField = value;
            this.RaisePropertyChanged("nmBenef");
        }
    }

    /// <summary>
    /// Listagem dos dependentes do Beneficiário (quando aplicável),
    /// utilizados na dedução de IRRF
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideDep", Order = 2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeDep> ideDep {
        get {
            return this.ideDepField;
        }
        set {
            this.ideDepField = value;
            this.RaisePropertyChanged("ideDep");
        }
    }

    /// <summary>
    /// Listagem dos pagamentos ao beneficiário
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("idePgto", Order = 3)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgto> idePgto {
        get {
            return this.idePgtoField;
        }
        set {
            this.idePgtoField = value;
            this.RaisePropertyChanged("idePgto");
        }
    }

    /// <summary>
    /// Informações sobre a(s) Operadora(s) de Saúde, caso tenham sido abatidas
    /// despesas médicas no Rendimento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideOpSaude", Order = 4)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaude> ideOpSaude {
        get {
            return this.ideOpSaudeField;
        }
        set {
            this.ideOpSaudeField = value;
            this.RaisePropertyChanged("ideOpSaude");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeDep : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfDepField;
    private RelacaoDependencia relDepField = RelacaoDependencia.Conjuge;
    private string descrDepField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep {
        get {
            return this.cpfDepField;
        }
        set {
            this.cpfDepField = value;
            this.RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public RelacaoDependencia relDep {
        get {
            return this.relDepField;
        }
        set {
            this.relDepField = value;
            this.RaisePropertyChanged("relDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descrDep {
        get {
            return this.descrDepField;
        }
        set {
            this.descrDepField = value;
            this.RaisePropertyChanged("descrDep");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgto : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string natRendField;
    private string observField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto> infoPgtoField = new();

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer", Order = 0)]
    public string natRend {
        get {
            return this.natRendField;
        }
        set {
            this.natRendField = value;
            this.RaisePropertyChanged("natRend");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string observ {
        get {
            return this.observField;
        }
        set {
            this.observField = value;
            this.RaisePropertyChanged("observ");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoPgto", Order = 2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgto> infoPgto {
        get {
            return this.infoPgtoField;
        }
        set {
            this.infoPgtoField = value;
            this.RaisePropertyChanged("infoPgto");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
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
    public System.DateTime DataFatoGerador {
        get {
            return this.dtFGField;
        }
        set {
            this.dtFGField = value;
            this.RaisePropertyChanged("DataFatoGerador");
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
    public string compFP {
        get {
            return this.compFPField;
        }
        set {
            this.compFPField = value;
            this.RaisePropertyChanged("compFP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string indDecTerc {
        get {
            return this.indDecTercField;
        }
        set {
            this.indDecTercField = value;
            this.RaisePropertyChanged("indDecTerc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrRendBruto {
        get {
            return this.vlrRendBrutoField;
        }
        set {
            this.vlrRendBrutoField = value;
            this.RaisePropertyChanged("vlrRendBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRendTrib {
        get {
            return this.vlrRendTribField;
        }
        set {
            this.vlrRendTribField = value;
            this.RaisePropertyChanged("vlrRendTrib");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrIR {
        get {
            return this.vlrIRField;
        }
        set {
            this.vlrIRField = value;
            this.RaisePropertyChanged("vlrIR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string indRRA {
        get {
            return this.indRRAField;
        }
        set {
            this.indRRAField = value;
            this.RaisePropertyChanged("indRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public IndicadorFciScp? indFciScp {
        get {
            return this.indFciScpField;
        }
        set {
            this.indFciScpField = value;
            this.RaisePropertyChanged("indFciScp");
        }
    }
    public bool ShouldSerializeindFciScp() => indFciScp.HasValue;

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string nrInscFciScp {
        get {
            return this.nrInscFciScpField;
        }
        set {
            this.nrInscFciScpField = value;
            this.RaisePropertyChanged("nrInscFciScp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public string percSCP {
        get {
            return this.percSCPField;
        }
        set {
            this.percSCPField = value;
            this.RaisePropertyChanged("percSCP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string indJud {
        get {
            return this.indJudField;
        }
        set {
            this.indJudField = value;
            this.RaisePropertyChanged("indJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 11)]
    public string paisResidExt {
        get {
            return this.paisResidExtField;
        }
        set {
            this.paisResidExtField = value;
            this.RaisePropertyChanged("paisResidExt");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("detDed", Order = 12)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed> detDed {
        get {
            return this.detDedField;
        }
        set {
            this.detDedField = value;
            this.RaisePropertyChanged("detDed");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("rendIsento", Order = 13)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento> rendIsento {
        get {
            return this.rendIsentoField;
        }
        set {
            this.rendIsentoField = value;
            this.RaisePropertyChanged("rendIsento");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 14)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRet {
        get {
            return this.infoProcRetField;
        }
        set {
            this.infoProcRetField = value;
            this.RaisePropertyChanged("infoProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 15)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA infoRRA {
        get {
            return this.infoRRAField;
        }
        set {
            this.infoRRAField = value;
            this.RaisePropertyChanged("infoRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 16)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJud {
        get {
            return this.infoProcJudField;
        }
        set {
            this.infoProcJudField = value;
            this.RaisePropertyChanged("infoProcJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 17)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExt {
        get {
            return this.infoPgtoExtField;
        }
        set {
            this.infoPgtoExtField = value;
            this.RaisePropertyChanged("infoPgtoExt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDeducaoField;
    private SimNao infoEntidField = SimNao.Nao;
    private string nrInscPrevCompField;
    private string vlrPatrocFunpField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen> benefPenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorTipoDeducaoPrevidenciaria indTpDeducao {
        get {
            return this.indTpDeducaoField;
        }
        set {
            this.indTpDeducaoField = value;
            this.RaisePropertyChanged("indTpDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDeducao {
        get {
            return this.vlrDeducaoField;
        }
        set {
            this.vlrDeducaoField = value;
            this.RaisePropertyChanged("vlrDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public SimNao infoEntid {
        get {
            return this.infoEntidField;
        }
        set {
            this.infoEntidField = value;
            this.RaisePropertyChanged("infoEntid");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string nrInscPrevComp {
        get {
            return this.nrInscPrevCompField;
        }
        set {
            this.nrInscPrevCompField = value;
            this.RaisePropertyChanged("nrInscPrevComp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrPatrocFunp {
        get {
            return this.vlrPatrocFunpField;
        }
        set {
            this.vlrPatrocFunpField = value;
            this.RaisePropertyChanged("vlrPatrocFunp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order=5)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen> benefPen {
        get {
            return this.benefPenField;
        }
        set {
            this.benefPenField = value;
            this.RaisePropertyChanged("benefPen");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfDepField;
    private string vlrDepenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep {
        get {
            return this.cpfDepField;
        }
        set {
            this.cpfDepField = value;
            this.RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDepen {
        get {
            return this.vlrDepenField;
        }
        set {
            this.vlrDepenField = value;
            this.RaisePropertyChanged("vlrDepen");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoIsencaoPF tpIsencaoField;
    private string vlrIsentoField;  
    private string descRendimentoField;
    private System.DateTime? dtLaudoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoIsencaoPF tpIsencao {
        get {
            return this.tpIsencaoField;
        }
        set {
            this.tpIsencaoField = value;
            this.RaisePropertyChanged("tpIsencao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrIsento {
        get {
            return this.vlrIsentoField;
        }
        set {
            this.vlrIsentoField = value;
            this.RaisePropertyChanged("vlrIsento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descRendimento {
        get {
            return this.descRendimentoField;
        }
        set {
            this.descRendimentoField = value;
            this.RaisePropertyChanged("descRendimento");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType="date", Order = 3)]
    public System.DateTime? dtLaudo {
        get {
            return this.dtLaudoField;
        }
        set {
            this.dtLaudoField = value;
            this.RaisePropertyChanged("dtLaudo");
        }
    }
    public bool ShouldSerializedtLaudo() => dtLaudo.HasValue;


    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
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
    public TipoProcesso tpProcRet {
        get {
            return this.tpProcRetField;
        }
        set {
            this.tpProcRetField = value;
            this.RaisePropertyChanged("tpProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRet {
        get {
            return this.nrProcRetField;
        }
        set {
            this.nrProcRetField = value;
            this.RaisePropertyChanged("nrProcRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSusp {
        get {
            return this.codSuspField;
        }
        set {
            this.codSuspField = value;
            this.RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrNRetido {
        get {
            return this.vlrNRetidoField;
        }
        set {
            this.vlrNRetidoField = value;
            this.RaisePropertyChanged("vlrNRetido");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrDepJud {
        get {
            return this.vlrDepJudField;
        }
        set {
            this.vlrDepJudField = value;
            this.RaisePropertyChanged("vlrDepJud");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrCmpAnoCal {
        get {
            return this.vlrCmpAnoCalField;
        }
        set {
            this.vlrCmpAnoCalField = value;
            this.RaisePropertyChanged("vlrCmpAnoCal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrCmpAnoAnt {
        get {
            return this.vlrCmpAnoAntField;
        }
        set {
            this.vlrCmpAnoAntField = value;
            this.RaisePropertyChanged("vlrCmpAnoAnt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrRendSusp {
        get {
            return this.vlrRendSuspField;
        }
        set {
            this.vlrRendSuspField = value;
            this.RaisePropertyChanged("vlrRendSusp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dedSusp", Order=8)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp> dedSusp {
        get {
            return this.dedSuspField;
        }
        set {
            this.dedSuspField = value;
            this.RaisePropertyChanged("dedSusp");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorTipoDeducaoPrevidenciaria indTpDeducaoField;
    private string vlrDedSuspField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen> benefPenField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorTipoDeducaoPrevidenciaria indTpDeducao {
        get {
            return this.indTpDeducaoField;
        }
        set {
            this.indTpDeducaoField = value;
            this.RaisePropertyChanged("indTpDeducao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDedSusp {
        get {
            return this.vlrDedSuspField;
        }
        set {
            this.vlrDedSuspField = value;
            this.RaisePropertyChanged("vlrDedSusp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen> benefPen {
        get {
            return this.benefPenField;
        }
        set {
            this.benefPenField = value;
            this.RaisePropertyChanged("benefPen");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfDepField;
    private string vlrDepenSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep {
        get {
            return this.cpfDepField;
        }
        set {
            this.cpfDepField = value;
            this.RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDepenSusp {
        get {
            return this.vlrDepenSuspField;
        }
        set {
            this.vlrDepenSuspField = value;
            this.RaisePropertyChanged("vlrDepenSusp");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
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
    public TipoProcesso tpProcRRA {
        get {
            return this.tpProcRRAField;
        }
        set {
            this.tpProcRRAField = value;
            this.RaisePropertyChanged("tpProcRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProcRRA {
        get {
            return this.nrProcRRAField;
        }
        set {
            this.nrProcRRAField = value;
            this.RaisePropertyChanged("nrProcRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorOrigemDosRecursos indOrigRec {
        get {
            return this.indOrigRecField;
        }
        set {
            this.indOrigRecField = value;
            this.RaisePropertyChanged("indOrigRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string descRRA {
        get {
            return this.descRRAField;
        }
        set {
            this.descRRAField = value;
            this.RaisePropertyChanged("descRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public int? qtdMesesRRA {
        get {
            return this.qtdMesesRRAField;
        }
        set {
            this.qtdMesesRRAField = value;
            this.RaisePropertyChanged("qtdMesesRRA");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string cnpjOrigRecurso {
        get {
            return this.cnpjOrigRecursoField;
        }
        set {
            this.cnpjOrigRecursoField = value;
            this.RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJud despProcJud {
        get {
            return this.despProcJudField;
        }
        set {
            this.despProcJudField = value;
            this.RaisePropertyChanged("despProcJud");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas {
        get {
            return this.vlrDespCustasField;
        }
        set {
            this.vlrDespCustasField = value;
            this.RaisePropertyChanged("vlrDespCustas");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados {
        get {
            return this.vlrDespAdvogadosField;
        }
        set {
            this.vlrDespAdvogadosField = value;
            this.RaisePropertyChanged("vlrDespAdvogados");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv> ideAdv {
        get {
            return this.ideAdvField;
        }
        set {
            this.ideAdvField = value;
            this.RaisePropertyChanged("ideAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscAdvField;
    
    private string nrInscAdvField;
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv {
        get {
            return this.tpInscAdvField;
        }
        set {
            this.tpInscAdvField = value;
            this.RaisePropertyChanged("tpInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv {
        get {
            return this.nrInscAdvField;
        }
        set {
            this.nrInscAdvField = value;
            this.RaisePropertyChanged("nrInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv {
        get {
            return this.vlrAdvField;
        }
        set {
            this.vlrAdvField = value;
            this.RaisePropertyChanged("vlrAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrProcField;
    private IndicadorOrigemDosRecursos indOrigRecField;
    private string cnpjOrigRecursoField;
    private string descField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrProc {
        get {
            return this.nrProcField;
        }
        set {
            this.nrProcField = value;
            this.RaisePropertyChanged("nrProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public IndicadorOrigemDosRecursos indOrigRec {
        get {
            return this.indOrigRecField;
        }
        set {
            this.indOrigRecField = value;
            this.RaisePropertyChanged("indOrigRec");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cnpjOrigRecurso {
        get {
            return this.cnpjOrigRecursoField;
        }
        set {
            this.cnpjOrigRecursoField = value;
            this.RaisePropertyChanged("cnpjOrigRecurso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string desc {
        get {
            return this.descField;
        }
        set {
            this.descField = value;
            this.RaisePropertyChanged("desc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud despProcJud {
        get {
            return this.despProcJudField;
        }
        set {
            this.despProcJudField = value;
            this.RaisePropertyChanged("despProcJud");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJud : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string vlrDespCustasField;
    private string vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrDespCustas {
        get {
            return this.vlrDespCustasField;
        }
        set {
            this.vlrDespCustasField = value;
            this.RaisePropertyChanged("vlrDespCustas");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrDespAdvogados {
        get {
            return this.vlrDespAdvogadosField;
        }
        set {
            this.vlrDespAdvogadosField = value;
            this.RaisePropertyChanged("vlrDespAdvogados");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv", Order=2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdv {
        get {
            return this.ideAdvField;
        }
        set {
            this.ideAdvField = value;
            this.RaisePropertyChanged("ideAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscAdvField;
    private string nrInscAdvField;
    private string vlrAdvField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscAdv {
        get {
            return this.tpInscAdvField;
        }
        set {
            this.tpInscAdvField = value;
            this.RaisePropertyChanged("tpInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscAdv {
        get {
            return this.nrInscAdvField;
        }
        set {
            this.nrInscAdvField = value;
            this.RaisePropertyChanged("nrInscAdv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrAdv {
        get {
            return this.vlrAdvField;
        }
        set {
            this.vlrAdvField = value;
            this.RaisePropertyChanged("vlrAdv");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt : object, System.ComponentModel.INotifyPropertyChanged {
    
    private IndicadorNIF indNIFField;
    private string nifBenefField;
    private string frmTributField;
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExtField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorNIF indNIF {
        get {
            return this.indNIFField;
        }
        set {
            this.indNIFField = value;
            this.RaisePropertyChanged("indNIF");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nifBenef {
        get {
            return this.nifBenefField;
        }
        set {
            this.nifBenefField = value;
            this.RaisePropertyChanged("nifBenef");
        }
    }

    /// <summary>
    /// Utilizar opções disponíveis em <see cref="IndicadoresIRRF"/> (static)
    /// </summary>
    /// <remarks/>
    [XmlElement(Order = 2)]
    public string frmTribut {
        get {
            return this.frmTributField;
        }
        set {
            this.frmTributField = value;
            this.RaisePropertyChanged("frmTribut");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExt {
        get {
            return this.endExtField;
        }
        set {
            this.endExtField = value;
            this.RaisePropertyChanged("endExt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
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
    public string dscLograd {
        get {
            return this.dscLogradField;
        }
        set {
            this.dscLogradField = value;
            this.RaisePropertyChanged("dscLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrLograd {
        get {
            return this.nrLogradField;
        }
        set {
            this.nrLogradField = value;
            this.RaisePropertyChanged("nrLograd");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string complem {
        get {
            return this.complemField;
        }
        set {
            this.complemField = value;
            this.RaisePropertyChanged("complem");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string bairro {
        get {
            return this.bairroField;
        }
        set {
            this.bairroField = value;
            this.RaisePropertyChanged("bairro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string cidade {
        get {
            return this.cidadeField;
        }
        set {
            this.cidadeField = value;
            this.RaisePropertyChanged("cidade");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string estado {
        get {
            return this.estadoField;
        }
        set {
            this.estadoField = value;
            this.RaisePropertyChanged("estado");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string codPostal {
        get {
            return this.codPostalField;
        }
        set {
            this.codPostalField = value;
            this.RaisePropertyChanged("codPostal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string telef {
        get {
            return this.telefField;
        }
        set {
            this.telefField = value;
            this.RaisePropertyChanged("telef");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaude : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string nrInscField;
    private string regANSField;
    private string vlrSaudeField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb> infoReembField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl> infoDependPlField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrInsc {
        get {
            return this.nrInscField;
        }
        set {
            this.nrInscField = value;
            this.RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string regANS {
        get {
            return this.regANSField;
        }
        set {
            this.regANSField = value;
            this.RaisePropertyChanged("regANS");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrSaude {
        get {
            return this.vlrSaudeField;
        }
        set {
            this.vlrSaudeField = value;
            this.RaisePropertyChanged("vlrSaude");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoReemb", Order=3)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb> infoReemb {
        get {
            return this.infoReembField;
        }
        set {
            this.infoReembField = value;
            this.RaisePropertyChanged("infoReemb");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoDependPl", Order=4)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl> infoDependPl {
        get {
            return this.infoDependPlField;
        }
        set {
            this.infoDependPlField = value;
            this.RaisePropertyChanged("infoDependPl");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscField = PersonalidadeJuridica.CNPJ;
    private string nrInscField;
    private string vlrReembField;
    private string vlrReembAntField;

    /// <remarks/>
    [XmlElement(Order=0)]
    public PersonalidadeJuridica tpInsc {
        get {
            return this.tpInscField;
        }
        set {
            this.tpInscField = value;
            this.RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order=1)]
    public string nrInsc {
        get {
            return this.nrInscField;
        }
        set {
            this.nrInscField = value;
            this.RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order=2)]
    public string vlrReemb {
        get {
            return this.vlrReembField;
        }
        set {
            this.vlrReembField = value;
            this.RaisePropertyChanged("vlrReemb");
        }
    }

    /// <remarks/>
    [XmlElement(Order=3)]
    public string vlrReembAnt {
        get {
            return this.vlrReembAntField;
        }
        set {
            this.vlrReembAntField = value;
            this.RaisePropertyChanged("vlrReembAnt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl : object, System.ComponentModel.INotifyPropertyChanged {
    
    private string cpfDepField;
    
    private string vlrSaudeField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep> infoReembDepField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cpfDep {
        get {
            return this.cpfDepField;
        }
        set {
            this.cpfDepField = value;
            this.RaisePropertyChanged("cpfDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrSaude {
        get {
            return this.vlrSaudeField;
        }
        set {
            this.vlrSaudeField = value;
            this.RaisePropertyChanged("vlrSaude");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoReembDep", Order = 2)]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep> infoReembDep {
        get {
            return this.infoReembDepField;
        }
        set {
            this.infoReembDepField = value;
            this.RaisePropertyChanged("infoReembDep");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.8.3928.0")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.reinf.esocial.gov.br/schemas/evt4010PagtoBeneficiarioPF/v2_01_01")]
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep : object, System.ComponentModel.INotifyPropertyChanged {
    
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private string vlrReembField;
    private string vlrReembAntField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc {
        get {
            return this.tpInscField;
        }
        set {
            this.tpInscField = value;
            this.RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc {
        get {
            return this.nrInscField;
        }
        set {
            this.nrInscField = value;
            this.RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrReemb {
        get {
            return this.vlrReembField;
        }
        set {
            this.vlrReembField = value;
            this.RaisePropertyChanged("vlrReemb");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrReembAnt {
        get {
            return this.vlrReembAntField;
        }
        set {
            this.vlrReembAntField = value;
            this.RaisePropertyChanged("vlrReembAnt");
        }
    }
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}
