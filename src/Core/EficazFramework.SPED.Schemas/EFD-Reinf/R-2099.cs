namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Fechamento dos eventos da série R-2000
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2099()
/// {
///     Versao = Versao.v2_01_02,
///     evtFechaEvPer = new EficazFramework.SPED.Schemas.EFD_Reinf.R2099EventoFechamentoPeriodo()
///     {
///         ideContri = new EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoContribuinte()
///         {
///             tpInsc = EficazFramework.SPED.Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         ideEvento = new IdentificacaoEventoFechamento()
///         {
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             tpAmb = EficazFramework.SPED.Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EficazFramework.SPED.Schemas.EFD_Reinf.EmissorEvento.AppContribuinte,
///             verProc = "2.2"
///         },
///         ideRespInf = new EficazFramework.SPED.Schemas.EFD_Reinf.IdentificacaoResponsavel()
///         {
///             nmResp = "Teste",
///             cpfResp = "07448448609",
///             telefone = "3535441511",
///             email = "contato@eficazctb.com.br"
///         },
///         infoFech = new EficazFramework.SPED.Schemas.EFD_Reinf.R2099InformacoesFechamento()
///         {
///             evtServTm = SimNao.Nao,
///             evtServPr = SimNao.Nao,
///             evtAquis = SimNao.Nao
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2099 : Evento, INotifyPropertyChanged
{
    private R2099EventoFechamentoPeriodo evtFechaEvPerField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2099EventoFechamentoPeriodo evtFechaEvPer
    {
        get => evtFechaEvPerField;

        set
        {
            evtFechaEvPerField = value;
            RaisePropertyChanged(nameof(evtFechaEvPer));
        }
    }

    /// <exclude />
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#", Order = 1)]
    public SignatureType Signature
    {
        get => signatureField;

        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }


    // Evento Members
    /// <exclude />
    public override void GeraEventoID()
    {
        evtFechaEvPerField.id = string.Format("ID{0}{1}{2}", (int)(evtFechaEvPerField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ), evtFechaEvPerField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000", ReinfTimeStampUtils.GetTimeStampIDForEvent());
    }

    /// <exclude />
    public override string ContribuinteCNPJ()
    {
        return evtFechaEvPer.ideContri.nrInsc;
    }


    // IXmlSignableDocument Members
    /// <exclude />
    public override string TagToSign => "Reinf";
    /// <exclude />
    public override string TagId => "evtFechaEvPer";
    /// <exclude />
    public override bool EmptyURI => true;
    /// <exclude />
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude />
    public override XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(R2099), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtFechamento/{Versao}", IsNullable = false });
    }
}


/// <exclude />
public partial class R2099EventoFechamentoPeriodo : EfdReinfBindableObject
{
    private IdentificacaoEventoFechamento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private IdentificacaoResponsavel ideRespInfField;
    private R2099InformacoesFechamento infoFechField;
    private string idField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoEventoFechamento ideEvento
    {
        get => ideEventoField;

        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
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
            RaisePropertyChanged(nameof(ideContri));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IdentificacaoResponsavel ideRespInf
    {
        get => ideRespInfField;

        set
        {
            ideRespInfField = value;
            RaisePropertyChanged(nameof(ideRespInf));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public R2099InformacoesFechamento infoFech
    {
        get => infoFechField;

        set
        {
            infoFechField = value;
            RaisePropertyChanged(nameof(infoFech));
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
            RaisePropertyChanged(nameof(id));
        }
    }
}


/// <exclude />
public partial class R2099InformacoesFechamento : EfdReinfBindableObject
{
    private SimNao evtServTmField = SimNao.Nao;
    private SimNao evtServPrField = SimNao.Nao;
    private SimNao evtAssDespRecField = SimNao.Nao;
    private SimNao evtAssDespRepField = SimNao.Nao;
    private SimNao evtComProdField = SimNao.Nao;
    private SimNao evtCPRBField = SimNao.Nao;
    private SimNao evtAquisField = SimNao.Nao;
    private SimNao evtPgtosField = SimNao.Nao;
    private bool evtPgtosFieldSpecified = false;
    private string compSemMovtoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public SimNao evtServTm
    {
        get => evtServTmField;

        set
        {
            evtServTmField = value;
            RaisePropertyChanged(nameof(evtServTm));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public SimNao evtServPr
    {
        get => evtServPrField;

        set
        {
            evtServPrField = value;
            RaisePropertyChanged(nameof(evtServPr));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public SimNao evtAssDespRec
    {
        get => evtAssDespRecField;

        set
        {
            evtAssDespRecField = value;
            RaisePropertyChanged(nameof(evtAssDespRec));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public SimNao evtAssDespRep
    {
        get => evtAssDespRepField;

        set
        {
            evtAssDespRepField = value;
            RaisePropertyChanged(nameof(evtAssDespRep));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public SimNao evtComProd
    {
        get => evtComProdField;

        set
        {
            evtComProdField = value;
            RaisePropertyChanged(nameof(evtComProd));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public SimNao evtCPRB
    {
        get => evtCPRBField;

        set
        {
            evtCPRBField = value;
            RaisePropertyChanged(nameof(evtCPRB));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public SimNao evtAquis
    {
        get => evtAquisField;

        set
        {
            evtAquisField = value;
            RaisePropertyChanged(nameof(evtAquis));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public SimNao evtPgtos
    {
        get => evtPgtosField;

        set
        {
            evtPgtosField = value;
            RaisePropertyChanged(nameof(evtPgtos));
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool evtPgtosSpecified
    {
        get => evtPgtosFieldSpecified;

        set
        {
            evtPgtosFieldSpecified = value;
            RaisePropertyChanged(nameof(evtPgtosSpecified));
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 8)]
    public string compSemMovto
    {
        get => compSemMovtoField;

        set
        {
            compSemMovtoField = value;
            RaisePropertyChanged(nameof(compSemMovto));
        }
    }
}