namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Tabela de processos administrativos/judiciais
/// </summary>
[Serializable()]
public partial class R1070 : Evento, INotifyPropertyChanged
{
    private ReinfEvtTabProcesso evtTabProcessoField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtTabProcesso evtTabProcesso
    {
        get => evtTabProcessoField;

        set
        {
            evtTabProcessoField = value;
            RaisePropertyChanged("evtTabProcesso");
        }
    }

    /// <remarks/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
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
        evtTabProcessoField.id = string.Format("ID{0}{1}{2}", (int)(evtTabProcessoField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtTabProcessoField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    public override string ContribuinteCNPJ()
    {
        return evtTabProcesso.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    public override string TagToSign => "Reinf";
    public override string TagId => "evtTabProcesso";
    public override bool EmptyURI => true;
    public override bool SignAsSHA256 => true;


    // PropertyChanged Members
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName)
    {
        var propertyChanged = PropertyChanged;
        if (propertyChanged != null)
        {
            propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    // Serialization Members
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R1070), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTabProcesso/{Versao}", IsNullable = false });
    }

}


/// <exclude />
public partial class ReinfEvtTabProcesso : object, INotifyPropertyChanged
{
    private ReinfEvtTabProcessoIdeEvento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private ReinfEvtTabProcessoInfoProcesso infoProcessoField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtTabProcessoIdeEvento ideEvento
    {
        get => ideEventoField;

        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <remarks/>
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

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtTabProcessoInfoProcesso infoProcesso
    {
        get => infoProcessoField;

        set
        {
            infoProcessoField = value;
            RaisePropertyChanged("infoProcesso");
        }
    }

    /// <remarks/>
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


// Identificação do Evento:
/// <exclude />
public partial class ReinfEvtTabProcessoIdeEvento : object, INotifyPropertyChanged
{
    private Ambiente tpAmbField;
    private EmissorEvento procEmiField;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
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
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
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


// Informação do Processo:
/// <exclude />
public partial class ReinfEvtTabProcessoInfoProcesso : object, INotifyPropertyChanged
{
    private object itemField;

    /// <remarks/>
    [XmlElement("alteracao", typeof(ReinfEvtTabProcessoInfoProcessoAlteracao), Order = 0)]
    [XmlElement("exclusao", typeof(ReinfEvtTabProcessoInfoProcessoExclusao), Order = 0)]
    [XmlElement("inclusao", typeof(ReinfEvtTabProcessoInfoProcessoInclusao), Order = 0)]
    public object Item
    {
        get => itemField;

        set
        {
            itemField = value;
            RaisePropertyChanged("Item");
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


// Alteração:
/// <exclude />
public partial class ReinfEvtTabProcessoInfoProcessoAlteracao : object, INotifyPropertyChanged
{
    private ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcesso ideProcessoField;
    private ReinfEvtTabProcessoInfoProcessoAlteracaoNovaValidade novaValidadeField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcesso ideProcesso
    {
        get => ideProcessoField;

        set
        {
            ideProcessoField = value;
            RaisePropertyChanged("ideProcesso");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ReinfEvtTabProcessoInfoProcessoAlteracaoNovaValidade novaValidade
    {
        get => novaValidadeField;

        set
        {
            novaValidadeField = value;
            RaisePropertyChanged("novaValidade");
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
public partial class ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcesso : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string iniValidField;
    private string fimValidField;
    private IndicadorAuditoria indAutoriaField;
    private ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoInfoSusp[] infoSuspField;
    private ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoDadosProcJud dadosProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;

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
        get => nrProcField;

        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string iniValid
    {
        get => iniValidField;

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 3)]
    public string fimValid
    {
        get => fimValidField;

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public IndicadorAuditoria indAutoria
    {
        get => indAutoriaField;

        set
        {
            indAutoriaField = value;
            RaisePropertyChanged("indAutoria");
        }
    }

    /// <remarks/>
    [XmlElement("infoSusp", Order = 5)]
    public ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoInfoSusp[] infoSusp
    {
        get => infoSuspField;

        set
        {
            infoSuspField = value;
            RaisePropertyChanged("infoSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoDadosProcJud dadosProcJud
    {
        get => dadosProcJudField;

        set
        {
            dadosProcJudField = value;
            RaisePropertyChanged("dadosProcJud");
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
public partial class ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoInfoSusp : object, INotifyPropertyChanged
{
    private string codSuspField;
    private string indSuspField;
    private DateTime dtDecisaoField;
    private string indDepositoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
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
    [XmlElement(Order = 1)]
    public string indSusp
    {
        get => indSuspField;

        set
        {
            indSuspField = value;
            RaisePropertyChanged("indSusp");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtDecisao
    {
        get => dtDecisaoField;

        set
        {
            dtDecisaoField = value;
            RaisePropertyChanged("dtDecisao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string indDeposito
    {
        get => indDepositoField;

        set
        {
            indDepositoField = value;
            RaisePropertyChanged("indDeposito");
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
public partial class ReinfEvtTabProcessoInfoProcessoAlteracaoIdeProcessoDadosProcJud : object, INotifyPropertyChanged
{
    private string ufVaraField;
    private string codMunicField;
    private string idVaraField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ufVara
    {
        get => ufVaraField;

        set
        {
            ufVaraField = value;
            RaisePropertyChanged("ufVara");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string codMunic
    {
        get => codMunicField;

        set
        {
            codMunicField = value;
            RaisePropertyChanged("codMunic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string idVara
    {
        get => idVaraField;

        set
        {
            idVaraField = value;
            RaisePropertyChanged("idVara");
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
public partial class ReinfEvtTabProcessoInfoProcessoAlteracaoNovaValidade : object, INotifyPropertyChanged
{
    private string iniValidField;
    private string fimValidField;

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 0)]
    public string iniValid
    {
        get => iniValidField;

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 1)]
    public string fimValid
    {
        get => fimValidField;

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
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


// Exclusão:
/// <exclude />
public partial class ReinfEvtTabProcessoInfoProcessoExclusao : object, INotifyPropertyChanged
{
    private ReinfEvtTabProcessoInfoProcessoExclusaoIdeProcesso ideProcessoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtTabProcessoInfoProcessoExclusaoIdeProcesso ideProcesso
    {
        get => ideProcessoField;

        set
        {
            ideProcessoField = value;
            RaisePropertyChanged("ideProcesso");
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
public partial class ReinfEvtTabProcessoInfoProcessoExclusaoIdeProcesso : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string iniValidField;
    private string fimValidField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;

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
        get => nrProcField;

        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string iniValid
    {
        get => iniValidField;

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 3)]
    public string fimValid
    {
        get => fimValidField;

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
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


// Inclusão:
/// <exclude />
public partial class ReinfEvtTabProcessoInfoProcessoInclusao : object, INotifyPropertyChanged
{
    private ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcesso ideProcessoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcesso ideProcesso
    {
        get => ideProcessoField;

        set
        {
            ideProcessoField = value;
            RaisePropertyChanged("ideProcesso");
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
public partial class ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcesso : object, INotifyPropertyChanged
{
    private TipoProcesso tpProcField;
    private string nrProcField;
    private string iniValidField;
    private string fimValidField;
    private IndicadorAuditoria indAutoriaField;
    private ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoInfoSusp[] infoSuspField;
    private ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoDadosProcJud dadosProcJudField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public TipoProcesso tpProc
    {
        get => tpProcField;

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
        get => nrProcField;

        set
        {
            nrProcField = value;
            RaisePropertyChanged("nrProc");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string iniValid
    {
        get => iniValidField;

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(DataType = "gYearMonth", Order = 3)]
    public string fimValid
    {
        get => fimValidField;

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public IndicadorAuditoria indAutoria
    {
        get => indAutoriaField;

        set
        {
            indAutoriaField = value;
            RaisePropertyChanged("indAutoria");
        }
    }

    /// <remarks/>
    [XmlElement("infoSusp", Order = 5)]
    public ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoInfoSusp[] infoSusp
    {
        get => infoSuspField;

        set
        {
            infoSuspField = value;
            RaisePropertyChanged("infoSusp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoDadosProcJud dadosProcJud
    {
        get => dadosProcJudField;

        set
        {
            dadosProcJudField = value;
            RaisePropertyChanged("dadosProcJud");
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
public partial class ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoInfoSusp : object, INotifyPropertyChanged
{
    private string codSuspField;
    private string indSuspField;
    private DateTime dtDecisaoField;
    private string indDepositoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
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
    [XmlElement(Order = 1)]
    public string indSusp
    {
        get => indSuspField;

        set
        {
            indSuspField = value;
            RaisePropertyChanged("indSusp");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "date", Order = 2)]
    public DateTime dtDecisao
    {
        get => dtDecisaoField;

        set
        {
            dtDecisaoField = value;
            RaisePropertyChanged("dtDecisao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string indDeposito
    {
        get => indDepositoField;

        set
        {
            indDepositoField = value;
            RaisePropertyChanged("indDeposito");
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
public partial class ReinfEvtTabProcessoInfoProcessoInclusaoIdeProcessoDadosProcJud : object, INotifyPropertyChanged
{
    private string ufVaraField;
    private string codMunicField;
    private string idVaraField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ufVara
    {
        get => ufVaraField;

        set
        {
            ufVaraField = value;
            RaisePropertyChanged("ufVara");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string codMunic
    {
        get => codMunicField;

        set
        {
            codMunicField = value;
            RaisePropertyChanged("codMunic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string idVara
    {
        get => idVaraField;

        set
        {
            idVaraField = value;
            RaisePropertyChanged("idVara");
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
