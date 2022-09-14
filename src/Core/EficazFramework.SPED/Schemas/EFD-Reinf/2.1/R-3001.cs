namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
[XmlRoot("Reinf", Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01", IsNullable = false)]
public partial class R3010 : IEfdReinfEvt, INotifyPropertyChanged
{
    private ReinfEvtEspDesportivo evtEspDesportivoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtEspDesportivo evtEspDesportivo
    {
        get
        {
            return evtEspDesportivoField;
        }

        set
        {
            evtEspDesportivoField = value;
            RaisePropertyChanged("evtEspDesportivo");
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }

        set
        {
            signatureField = value;
            RaisePropertyChanged("Signature");
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

    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R3010));
    }

    public override void GeraEventoID()
    {
        // Me.evtTabProcessoField.id = String.Format("ID{0}{1}{2}", If(Me.evtTabProcessoField?.ideContri?.tpInsc, "1"), If(Me.evtTabProcessoFields?.ideContri?.NumeroInscricaoTag, "00000000000000"), ReinfTimeStampUtils.GetTimeStampIDForEvent)
    }

    public override string ContribuinteCNPJ()
    {
        return evtEspDesportivo.ideContri.nrInsc;
    }
}


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivo : object, INotifyPropertyChanged
{
    private ReinfEvtEspDesportivoIdeEvento ideEventoField;
    private ReinfEvtEspDesportivoIdeContri ideContriField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtEspDesportivoIdeEvento ideEvento
    {
        get
        {
            return ideEventoField;
        }

        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtEspDesportivoIdeContri ideContri
    {
        get
        {
            return ideContriField;
        }

        set
        {
            ideContriField = value;
            RaisePropertyChanged("ideContri");
        }
    }

    /// <remarks/>
    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("id");
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


// Identificação Evento:
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeEvento : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private DateTime dtApuracaoField;
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
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtApuracao
    {
        get
        {
            return dtApuracaoField;
        }

        set
        {
            dtApuracaoField = value;
            RaisePropertyChanged("dtApuracao");
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


// Identificação Contribuinte:
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private ReinfEvtEspDesportivoIdeContriIdeEstab[] ideEstabField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get
        {
            return tpInscField;
        }

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
        get
        {
            return nrInscField;
        }

        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement("ideEstab", Order = 2)]
    public ReinfEvtEspDesportivoIdeContriIdeEstab[] ideEstab
    {
        get
        {
            return ideEstabField;
        }

        set
        {
            ideEstabField = value;
            RaisePropertyChanged("ideEstab");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstab : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private ReinfEvtEspDesportivoIdeContriIdeEstabBoletim[] boletimField;
    private ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotal receitaTotalField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get
        {
            return tpInscEstabField;
        }

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
        get
        {
            return nrInscEstabField;
        }

        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged("nrInscEstab");
        }
    }

    /// <remarks/>
    [XmlElement("boletim", Order = 2)]
    public ReinfEvtEspDesportivoIdeContriIdeEstabBoletim[] boletim
    {
        get
        {
            return boletimField;
        }

        set
        {
            boletimField = value;
            RaisePropertyChanged("boletim");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotal receitaTotal
    {
        get
        {
            return receitaTotalField;
        }

        set
        {
            receitaTotalField = value;
            RaisePropertyChanged("receitaTotal");
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


// Identificação Evento:
[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstabBoletim : object, INotifyPropertyChanged
{
    private string nrBoletimField;
    private TipoCompeticao tpCompeticaoField;
    private CategoriaEvento categEventoField;
    private string modDesportivaField;
    private string nomeCompeticaoField;
    private string cnpjMandanteField;
    private string cnpjVisitanteField;
    private string nomeVisitanteField;
    private string pracaDesportivaField;
    private uint codMunicField;
    private bool codMunicFieldSpecified;
    private string ufField;
    private uint qtdePagantesField;
    private uint qtdeNaoPagantesField;
    private ReinfEvtEspDesportivoIdeContriIdeEstabBoletimReceitaIngressos[] receitaIngressosField;
    private ReinfEvtEspDesportivoIdeContriIdeEstabBoletimOutrasReceitas[] outrasReceitasField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nrBoletim
    {
        get
        {
            return nrBoletimField;
        }

        set
        {
            nrBoletimField = value;
            RaisePropertyChanged("nrBoletim");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public TipoCompeticao tpCompeticao
    {
        get
        {
            return tpCompeticaoField;
        }

        set
        {
            tpCompeticaoField = value;
            RaisePropertyChanged("tpCompeticao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public CategoriaEvento categEvento
    {
        get
        {
            return categEventoField;
        }

        set
        {
            categEventoField = value;
            RaisePropertyChanged("categEvento");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string modDesportiva
    {
        get
        {
            return modDesportivaField;
        }

        set
        {
            modDesportivaField = value;
            RaisePropertyChanged("modDesportiva");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string nomeCompeticao
    {
        get
        {
            return nomeCompeticaoField;
        }

        set
        {
            nomeCompeticaoField = value;
            RaisePropertyChanged("nomeCompeticao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string cnpjMandante
    {
        get
        {
            return cnpjMandanteField;
        }

        set
        {
            cnpjMandanteField = value;
            RaisePropertyChanged("cnpjMandante");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string cnpjVisitante
    {
        get
        {
            return cnpjVisitanteField;
        }

        set
        {
            cnpjVisitanteField = value;
            RaisePropertyChanged("cnpjVisitante");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string nomeVisitante
    {
        get
        {
            return nomeVisitanteField;
        }

        set
        {
            nomeVisitanteField = value;
            RaisePropertyChanged("nomeVisitante");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string pracaDesportiva
    {
        get
        {
            return pracaDesportivaField;
        }

        set
        {
            pracaDesportivaField = value;
            RaisePropertyChanged("pracaDesportiva");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 9)]
    public uint codMunic
    {
        get
        {
            return codMunicField;
        }

        set
        {
            codMunicField = value;
            RaisePropertyChanged("codMunic");
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool codMunicSpecified
    {
        get
        {
            return codMunicFieldSpecified;
        }

        set
        {
            codMunicFieldSpecified = value;
            RaisePropertyChanged("codMunicSpecified");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 10)]
    public string uf
    {
        get
        {
            return ufField;
        }

        set
        {
            ufField = value;
            RaisePropertyChanged("uf");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 11)]
    public uint qtdePagantes
    {
        get
        {
            return qtdePagantesField;
        }

        set
        {
            qtdePagantesField = value;
            RaisePropertyChanged("qtdePagantes");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 12)]
    public uint qtdeNaoPagantes
    {
        get
        {
            return qtdeNaoPagantesField;
        }

        set
        {
            qtdeNaoPagantesField = value;
            RaisePropertyChanged("qtdeNaoPagantes");
        }
    }

    /// <remarks/>
    [XmlElement("receitaIngressos", Order = 13)]
    public ReinfEvtEspDesportivoIdeContriIdeEstabBoletimReceitaIngressos[] receitaIngressos
    {
        get
        {
            return receitaIngressosField;
        }

        set
        {
            receitaIngressosField = value;
            RaisePropertyChanged("receitaIngressos");
        }
    }

    /// <remarks/>
    [XmlElement("outrasReceitas", Order = 14)]
    public ReinfEvtEspDesportivoIdeContriIdeEstabBoletimOutrasReceitas[] outrasReceitas
    {
        get
        {
            return outrasReceitasField;
        }

        set
        {
            outrasReceitasField = value;
            RaisePropertyChanged("outrasReceitas");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstabBoletimReceitaIngressos : object, INotifyPropertyChanged
{
    private TipoIngressoCompeticao tpIngressoField;
    private string descIngrField;
    private uint qtdeIngrVendaField;
    private uint qtdeIngrVendidosField;
    private uint qtdeIngrDevField;
    private string precoIndivField;
    private string vlrTotalField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoIngressoCompeticao tpIngresso
    {
        get
        {
            return tpIngressoField;
        }

        set
        {
            tpIngressoField = value;
            RaisePropertyChanged("tpIngresso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string descIngr
    {
        get
        {
            return descIngrField;
        }

        set
        {
            descIngrField = value;
            RaisePropertyChanged("descIngr");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public uint qtdeIngrVenda
    {
        get
        {
            return qtdeIngrVendaField;
        }

        set
        {
            qtdeIngrVendaField = value;
            RaisePropertyChanged("qtdeIngrVenda");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public uint qtdeIngrVendidos
    {
        get
        {
            return qtdeIngrVendidosField;
        }

        set
        {
            qtdeIngrVendidosField = value;
            RaisePropertyChanged("qtdeIngrVendidos");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public uint qtdeIngrDev
    {
        get
        {
            return qtdeIngrDevField;
        }

        set
        {
            qtdeIngrDevField = value;
            RaisePropertyChanged("qtdeIngrDev");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string precoIndiv
    {
        get
        {
            return precoIndivField;
        }

        set
        {
            precoIndivField = value;
            RaisePropertyChanged("precoIndiv");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotal
    {
        get
        {
            return vlrTotalField;
        }

        set
        {
            vlrTotalField = value;
            RaisePropertyChanged("vlrTotal");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstabBoletimOutrasReceitas : object, INotifyPropertyChanged
{
    private TipoReceitaCompeticao tpReceitaField;
    private string vlrReceitaField;
    private string descReceitaField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoReceitaCompeticao tpReceita
    {
        get
        {
            return tpReceitaField;
        }

        set
        {
            tpReceitaField = value;
            RaisePropertyChanged("tpReceita");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrReceita
    {
        get
        {
            return vlrReceitaField;
        }

        set
        {
            vlrReceitaField = value;
            RaisePropertyChanged("vlrReceita");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string descReceita
    {
        get
        {
            return descReceitaField;
        }

        set
        {
            descReceitaField = value;
            RaisePropertyChanged("descReceita");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotal : object, INotifyPropertyChanged
{
    private string vlrReceitaTotalField;
    private string vlrCPField;
    private string vlrCPSuspTotalField;
    private string vlrReceitaClubesField;
    private string vlrRetParcField;
    private ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotalInfoProc[] infoProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string vlrReceitaTotal
    {
        get
        {
            return vlrReceitaTotalField;
        }

        set
        {
            vlrReceitaTotalField = value;
            RaisePropertyChanged("vlrReceitaTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrCP
    {
        get
        {
            return vlrCPField;
        }

        set
        {
            vlrCPField = value;
            RaisePropertyChanged("vlrCP");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrCPSuspTotal
    {
        get
        {
            return vlrCPSuspTotalField;
        }

        set
        {
            vlrCPSuspTotalField = value;
            RaisePropertyChanged("vlrCPSuspTotal");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrReceitaClubes
    {
        get
        {
            return vlrReceitaClubesField;
        }

        set
        {
            vlrReceitaClubesField = value;
            RaisePropertyChanged("vlrReceitaClubes");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrRetParc
    {
        get
        {
            return vlrRetParcField;
        }

        set
        {
            vlrRetParcField = value;
            RaisePropertyChanged("vlrRetParc");
        }
    }

    /// <remarks/>
    [XmlElement("infoProc", Order = 5)]
    public ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotalInfoProc[] infoProc
    {
        get
        {
            return infoProcField;
        }

        set
        {
            infoProcField = value;
            RaisePropertyChanged("infoProc");
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


[System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
[Serializable()]
[DebuggerStepThrough()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.reinf.esocial.gov.br/schemas/evtEspDesportivo/v2_01_01")]
public partial class ReinfEvtEspDesportivoIdeContriIdeEstabReceitaTotalInfoProc : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string codSuspField;
    private string vlrCPSuspField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get
        {
            return tpProcField;
        }

        set
        {
            tpProcField = value;
            RaisePropertyChanged("tpProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrProc
    {
        get
        {
            return nrProcField;
        }

        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codSusp
    {
        get
        {
            return codSuspField;
        }

        set
        {
            codSuspField = value;
            RaisePropertyChanged("codSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrCPSusp
    {
        get
        {
            return vlrCPSuspField;
        }

        set
        {
            vlrCPSuspField = value;
            RaisePropertyChanged("vlrCPSusp");
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
