﻿namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_1;

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
    
    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
    
    protected void RaisePropertyChanged(string propertyName) {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null)) {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R4010));
    }

    public override void GeraEventoID()
    {
        evtRetPFField.id = string.Format("ID{0}{1}{2}", (int)(evtRetPFField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtRetPFField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtRetPFField.ideContri.nrInsc;
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

    /// <remarks/>
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
    
    /// <remarks/>
    public ReinfEvtIdeContri ideContri {
        get {
            return this.ideContriField;
        }
        set {
            this.ideContriField = value;
            this.RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtRetPFIdeEstab ideEstab {
        get {
            return this.ideEstabField;
        }
        set {
            this.ideEstabField = value;
            this.RaisePropertyChanged("ideEstab");
        }
    }

    /// <remarks/>
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

    private byte tpInscEstabField;
    private string nrInscEstabField;

    private ReinfEvtRetPFIdeEstabIdeBenef ideBenefField;

    /// <remarks/>
    public byte tpInscEstab
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

    /// <remarks/>
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

    /// <remarks/>
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

    /// <remarks/>
    [XmlElement(Order = 2)]
    [System.Xml.Serialization.XmlElementAttribute("ideDep")]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdeDep> ideDep {
        get {
            return this.ideDepField;
        }
        set {
            this.ideDepField = value;
            this.RaisePropertyChanged("ideDep");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    [System.Xml.Serialization.XmlElementAttribute("idePgto")]
    public List<ReinfEvtRetPFIdeEstabIdeBenefIdePgto> idePgto {
        get {
            return this.idePgtoField;
        }
        set {
            this.idePgtoField = value;
            this.RaisePropertyChanged("idePgto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    [System.Xml.Serialization.XmlElementAttribute("ideOpSaude")]
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
    [XmlElement(Order = 0)]
    [System.Xml.Serialization.XmlElementAttribute(DataType="integer")]
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
    [XmlElement(Order = 2)]
    [System.Xml.Serialization.XmlElementAttribute("infoPgto")]
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
    private decimal? vlrRendBrutoField;
    private decimal? vlrRendTribField;
    private decimal? vlrIRField;
    private string indRRAField;
    private IndicadorFciScp? indFciScpField;
    private string nrInscFciScpField;
    private decimal? percSCPField;
    private string indJudField;
    private string paisResidExtField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDed> detDedField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoRendIsento> rendIsentoField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet> infoProcRetField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRA infoRRAField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJud infoProcJudField;
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExt infoPgtoExtField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType ="date")]
    public System.DateTime DataFatoGerador {
        get {
            return this.dtFGField;
        }
        set {
            this.dtFGField = value;
            this.RaisePropertyChanged("DataFatoGerador");
        }
    }

    /// <remarks/>
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
    public decimal? vlrRendBruto {
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
    public decimal? vlrRendTrib {
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
    public decimal? vlrIR {
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
    public decimal? percSCP {
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
    [System.Xml.Serialization.XmlElementAttribute("detDed")]
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
    [System.Xml.Serialization.XmlElementAttribute("rendIsento")]
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
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet")]
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
    private decimal? vlrDeducaoField;
    private SimNao infoEntidField = SimNao.Nao;
    private string nrInscPrevCompField;
    private decimal? vlrPatrocFunpField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoDetDedBenefPen> benefPenField;
    
    /// <remarks/>
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
    public decimal? vlrDeducao {
        get {
            return this.vlrDeducaoField;
        }
        set {
            this.vlrDeducaoField = value;
            this.RaisePropertyChanged("vlrDeducao");
        }
    }
    
    /// <remarks/>
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
    public decimal? vlrPatrocFunp {
        get {
            return this.vlrPatrocFunpField;
        }
        set {
            this.vlrPatrocFunpField = value;
            this.RaisePropertyChanged("vlrPatrocFunp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen")]
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
    private decimal? vlrDepenField;
    
    /// <remarks/>
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
    public decimal? vlrDepen {
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
    
    private TipoIsencao tpIsencaoField;
    private decimal? vlrIsentoField;  
    private string descRendimentoField;
    private System.DateTime? dtLaudoField;
    private bool dtLaudoFieldSpecified;
    
    /// <remarks/>
    public TipoIsencao tpIsencao {
        get {
            return this.tpIsencaoField;
        }
        set {
            this.tpIsencaoField = value;
            this.RaisePropertyChanged("tpIsencao");
        }
    }
    
    /// <remarks/>
    public decimal? vlrIsento {
        get {
            return this.vlrIsentoField;
        }
        set {
            this.vlrIsentoField = value;
            this.RaisePropertyChanged("vlrIsento");
        }
    }
    
    /// <remarks/>
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
    [System.Xml.Serialization.XmlElementAttribute(DataType="date")]
    public System.DateTime? dtLaudo {
        get {
            return this.dtLaudoField;
        }
        set {
            this.dtLaudoField = value;
            this.RaisePropertyChanged("dtLaudo");
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
public partial class ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRet : object, System.ComponentModel.INotifyPropertyChanged {
    
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private decimal? vlrNRetidoField;
    private decimal? vlrDepJudField;
    private decimal? vlrCmpAnoCalField;
    private decimal? vlrCmpAnoAntField;
    private decimal? vlrRendSuspField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSusp> dedSuspField;
    
    /// <remarks/>
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
    public decimal? vlrNRetido {
        get {
            return this.vlrNRetidoField;
        }
        set {
            this.vlrNRetidoField = value;
            this.RaisePropertyChanged("vlrNRetido");
        }
    }
    
    /// <remarks/>
    public decimal? vlrDepJud {
        get {
            return this.vlrDepJudField;
        }
        set {
            this.vlrDepJudField = value;
            this.RaisePropertyChanged("vlrDepJud");
        }
    }
    
    /// <remarks/>
    public decimal? vlrCmpAnoCal {
        get {
            return this.vlrCmpAnoCalField;
        }
        set {
            this.vlrCmpAnoCalField = value;
            this.RaisePropertyChanged("vlrCmpAnoCal");
        }
    }
    
    /// <remarks/>
    public decimal? vlrCmpAnoAnt {
        get {
            return this.vlrCmpAnoAntField;
        }
        set {
            this.vlrCmpAnoAntField = value;
            this.RaisePropertyChanged("vlrCmpAnoAnt");
        }
    }
    
    /// <remarks/>
    public decimal? vlrRendSusp {
        get {
            return this.vlrRendSuspField;
        }
        set {
            this.vlrRendSuspField = value;
            this.RaisePropertyChanged("vlrRendSusp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dedSusp")]
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
    private decimal? vlrDedSuspField;
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcRetDedSuspBenefPen> benefPenField;
    
    /// <remarks/>
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
    public decimal? vlrDedSusp {
        get {
            return this.vlrDedSuspField;
        }
        set {
            this.vlrDedSuspField = value;
            this.RaisePropertyChanged("vlrDedSusp");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("benefPen")]
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
    private decimal? vlrDepenSuspField;
    
    /// <remarks/>
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
    public decimal? vlrDepenSusp {
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
    
    private decimal? vlrDespCustasField;
    private decimal? vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoRRADespProcJudIdeAdv> ideAdvField;
    
    /// <remarks/>
    public decimal? vlrDespCustas {
        get {
            return this.vlrDespCustasField;
        }
        set {
            this.vlrDespCustasField = value;
            this.RaisePropertyChanged("vlrDespCustas");
        }
    }
    
    /// <remarks/>
    public decimal? vlrDespAdvogados {
        get {
            return this.vlrDespAdvogadosField;
        }
        set {
            this.vlrDespAdvogadosField = value;
            this.RaisePropertyChanged("vlrDespAdvogados");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv")]
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
    private decimal? vlrAdvField;
    
    /// <remarks/>
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
    public decimal? vlrAdv {
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
    
    private decimal? vlrDespCustasField;
    private decimal? vlrDespAdvogadosField;
    
    private List<ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoProcJudDespProcJudIdeAdv> ideAdvField;
    
    /// <remarks/>
    public decimal? vlrDespCustas {
        get {
            return this.vlrDespCustasField;
        }
        set {
            this.vlrDespCustasField = value;
            this.RaisePropertyChanged("vlrDespCustas");
        }
    }
    
    /// <remarks/>
    public decimal? vlrDespAdvogados {
        get {
            return this.vlrDespAdvogadosField;
        }
        set {
            this.vlrDespAdvogadosField = value;
            this.RaisePropertyChanged("vlrDespAdvogados");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("ideAdv")]
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
    private decimal? vlrAdvField;
    
    /// <remarks/>
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
    public decimal? vlrAdv {
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
    
    private byte indNIFField;
    private string nifBenefField;
    private string frmTributField;
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdePgtoInfoPgtoInfoPgtoExtEndExt endExtField;
    
    /// <remarks/>
    public byte indNIF {
        get {
            return this.indNIFField;
        }
        set {
            this.indNIFField = value;
            this.RaisePropertyChanged("indNIF");
        }
    }
    
    /// <remarks/>
    public string nifBenef {
        get {
            return this.nifBenefField;
        }
        set {
            this.nifBenefField = value;
            this.RaisePropertyChanged("nifBenef");
        }
    }
    
    /// <remarks/>
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
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb[] infoReembField;
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl[] infoDependPlField;
    
    /// <remarks/>
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
    [System.Xml.Serialization.XmlElementAttribute("infoReemb")]
    public ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoReemb[] infoReemb {
        get {
            return this.infoReembField;
        }
        set {
            this.infoReembField = value;
            this.RaisePropertyChanged("infoReemb");
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoDependPl")]
    public ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPl[] infoDependPl {
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
    
    private byte tpInscField;
    
    private string nrInscField;
    
    private string vlrReembField;
    
    private string vlrReembAntField;
    
    /// <remarks/>
    public byte tpInsc {
        get {
            return this.tpInscField;
        }
        set {
            this.tpInscField = value;
            this.RaisePropertyChanged("tpInsc");
        }
    }
    
    /// <remarks/>
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
    
    private ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep[] infoReembDepField;
    
    /// <remarks/>
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
    [System.Xml.Serialization.XmlElementAttribute("infoReembDep")]
    public ReinfEvtRetPFIdeEstabIdeBenefIdeOpSaudeInfoDependPlInfoReembDep[] infoReembDep {
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
    
    private byte tpInscField;
    
    private string nrInscField;
    
    private string vlrReembField;
    
    private string vlrReembAntField;
    
    /// <remarks/>
    public byte tpInsc {
        get {
            return this.tpInscField;
        }
        set {
            this.tpInscField = value;
            this.RaisePropertyChanged("tpInsc");
        }
    }
    
    /// <remarks/>
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