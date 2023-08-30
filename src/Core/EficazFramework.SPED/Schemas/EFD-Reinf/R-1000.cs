namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Informações do contribuinte
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R1000()
/// {
///     Versao = Versao.v2_01_02,
///     evtInfoContri = new R1000_EventoInfoContribuinte()
///     {
///         ideEvento = new IdentificacaoEvento()
///         {
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             procEmi = EmissorEvento.AppContribuinte,
///             verProc = "2.2"
///         },
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         infoContri = new R1000EventoInfoContribuinte()
///         {
///             Item = new R1000Inclusao() // R1000Alteracao() ou R1000Exclusao()
///             {
///                 idePeriodo = new IdentificacaoPeriodo()
///                 {
///                     iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
///                 },
///                 infoCadastro = new R1000InfoCadastro()
///                 {
///                     classTrib = "99",
///                     indEscrituracao = ObrigatoriedadeECD.EntregaECD,
///                     indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
///                     indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
///                     indSitPJ = SituacaoPessoaJuridica.Normal,
///                     indSitPJSpecified = true,
///                     contato = new R1000InfoCadastroContato()
///                     {
///                         nmCtt = "Pierre de Fermat",
///                         cpfCtt = "47363361886",
///                         foneFixo = "3535441234",
///                         email = "suporte@eficazcs.com.br"
///                     },
///                     softHouse = new R1000InfoCadastroSoftwareHouse()
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R1000 : Evento
{
    private R1000EventoInfoContribuinte evtInfoContriField;
    private SignatureType signatureField;

    /// <summary>
    /// Evento de informacoes do contribuinte.
    /// </summary>
    [XmlElement(Order = 0)]
    public R1000EventoInfoContribuinte evtInfoContri
    {
        get => evtInfoContriField;
        set
        {
            evtInfoContriField = value;
            RaisePropertyChanged("evtInfoContri");
        }
    }

    /// <exclude/>
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
    /// <exclude/>
    public override void GeraEventoID() =>
        evtInfoContri.id = $"ID{(int)(evtInfoContriField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{ evtInfoContriField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtInfoContri.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtInfoContri";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R1000), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/{Versao}", IsNullable = false});
}


/// <exclude />
public partial class R1000EventoInfoContribuinte : EfdReinfBindableObject
{
    private IdentificacaoEvento ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R1000InfoContribuinte infoContriField;
    private string idField;

    /// <summary>
    /// Identificação do evento
    /// </summary>
    /// <example>
    /// '''csharp
    /// evento.evtInfoContri.ideEvento = new ReinfEvtIdeEvento()
    /// {
    ///     tpAmb = Ambiente.ProducaoRestrita_DadosReais,
    ///     procEmi = EmissorEvento.AppContribuinte,
    ///     verProc = "2.2"
    /// };
    /// '''
    /// </example>
    [XmlElement(Order = 0)]
    public IdentificacaoEvento ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged("ideEvento");
        }
    }

    /// <summary>
    /// Identificação do contribuinte. Mais informações em <see cref="IdentificacaoContribuinte"/>.
    /// </summary>
    /// <example>
    /// '''csharp
    /// evento.evtInfoContri.ideContri = new ReinfEvtIdeContri()
    /// {
    ///     tpInsc = PersonalidadeJuridica.CNPJ,
    ///     nrInsc = "12345678"
    /// };
    /// '''
    /// </example>
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
    /// Informações do contribuinte.
    /// Instanciar conforme a natureza do evento:
    /// <list type="bullet">
    /// <item><description>Inclusão: <see cref="R1000Inclusao"/></description></item>
    /// <item><description>Alteração: <see cref="R1000Alteracao"/></description></item>
    /// <item><description>Exclusão: <see cref="R1000Exclusao"/></description></item>
    /// </list>
    /// </summary>
    /// <example>
    /// '''csharp
    /// evento.evtInfoContri.infoContri = new R1000_InfoContri()
    /// {
    ///     Item = new R1000_Inclusao()
    ///     {
    ///         idePeriodo = new ReinfEvtIdePeriodo()
    ///         {
    ///             iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
    ///         },
    ///         infoCadastro = new R1000_InfoCadastro()
    ///         {
    ///             classTrib = "99",
    ///             indEscrituracao = ObrigatoriedadeECD.EntregaECD,
    ///             indDesoneracao = DesoneracaoCPRB.NaoAplicavel,
    ///             indAcordoIsenMulta = AcordoInternacionalIsencaoMulta.SemAcordo,
    ///             indSitPJ = SituacaoPessoaJuridica.Normal,
    ///             indSitPJSpecified = true,
    ///             contato = new R1000_InfoCadastro_Contato()
    ///             {
    ///                 nmCtt = "Pierre de Fermat",
    ///                 cpfCtt = "47363361886",
    ///                 foneFixo = "3535441234",
    ///                 email = "suporte@eficazcs.com.br"
    ///             },
    ///             softHouse = new R1000_InfoCadastro_SoftwareHouse()
    ///         }
    ///     }
    /// };   
    ///  '''
    /// </example>
    [XmlElement(Order = 2)]
    public R1000InfoContribuinte infoContri
    {
        get => infoContriField;
        set
        {
            infoContriField = value;
            RaisePropertyChanged("infoContri");
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
}


/// <exclude />
public partial class R1000InfoContribuinte : EfdReinfBindableObject
{
    private object itemField;

    /// <remarks/>
    [XmlElement("alteracao", typeof(R1000Alteracao), Order = 0)]
    [XmlElement("exclusao", typeof(R1000Exclusao), Order = 0)]
    [XmlElement("inclusao", typeof(R1000Inclusao), Order = 0)]
    public object Item
    {
        get => itemField;
        set
        {
            itemField = value;
            RaisePropertyChanged("Item");
        }
    }
}


// Alteração:
/// <exclude />
public partial class R1000Alteracao : EfdReinfBindableObject
{
    private IdentificacaoPeriodo idePeriodoField;
    private R1000InfoCadastro infoCadastroField;
    private IdentificacaoPeriodo novaValidadeField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoPeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public R1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IdentificacaoPeriodo novaValidade
    {
        get => novaValidadeField;
        set
        {
            novaValidadeField = value;
            RaisePropertyChanged("novaValidade");
        }
    }
}


// Exclusão:
/// <exclude />
public partial class R1000Exclusao : EfdReinfBindableObject
{
    private IdentificacaoPeriodo idePeriodoField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoPeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }
}


// Inclusão:
/// <exclude />
public partial class R1000Inclusao : EfdReinfBindableObject
{
    private IdentificacaoPeriodo idePeriodoField;
    private R1000InfoCadastro infoCadastroField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IdentificacaoPeriodo idePeriodo
    {
        get => idePeriodoField;
        set
        {
            idePeriodoField = value;
            RaisePropertyChanged("idePeriodo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public R1000InfoCadastro infoCadastro
    {
        get => infoCadastroField;
        set
        {
            infoCadastroField = value;
            RaisePropertyChanged("infoCadastro");
        }
    }
}


/// <exclude />
public partial class R1000InfoCadastroEFR : EfdReinfBindableObject
{
    private string ideEFRField;
    private string cnpjEFRField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string ideEFR
    {
        get => ideEFRField;
        set
        {
            ideEFRField = value;
            RaisePropertyChanged("ideEFR");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cnpjEFR
    {
        get => cnpjEFRField;
        set
        {
            cnpjEFRField = value;
            RaisePropertyChanged("cnpjEFR");
        }
    }
}


// R1000 Common:
/// <exclude />
public partial class R1000InfoCadastro : EfdReinfBindableObject
{
    private string classTribField;
    private ObrigatoriedadeECD indEscrituracaoField;
    private DesoneracaoCPRB indDesoneracaoField;
    private AcordoInternacionalIsencaoMulta indAcordoIsenMultaField = AcordoInternacionalIsencaoMulta.SemAcordo;
    private SituacaoPessoaJuridica indSitPJField;
    private bool indSitPJFieldSpecified = false;
    private R1000InfoCadastroContato contatoField;
    private R1000InfoCadastroSoftwareHouse softHouseField;
    private R1000InfoCadastroEFR infoEFRField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string classTrib
    {
        get => classTribField;
        set
        {
            classTribField = value;
            RaisePropertyChanged("classTrib");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public ObrigatoriedadeECD indEscrituracao
    {
        get => indEscrituracaoField;
        set
        {
            indEscrituracaoField = value;
            RaisePropertyChanged("indEscrituracao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public DesoneracaoCPRB indDesoneracao
    {
        get => indDesoneracaoField;
        set
        {
            indDesoneracaoField = value;
            RaisePropertyChanged("indDesoneracao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public AcordoInternacionalIsencaoMulta indAcordoIsenMulta
    {
        get => indAcordoIsenMultaField;
        set
        {
            indAcordoIsenMultaField = value;
            RaisePropertyChanged("indAcordoIsenMulta");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public SituacaoPessoaJuridica indSitPJ
    {
        get => indSitPJField;
        set
        {
            indSitPJField = value;
            RaisePropertyChanged("indSitPJ");
        }
    }

    /// <remarks/>
    [XmlIgnore()]
    public bool indSitPJSpecified
    {
        get => indSitPJFieldSpecified;
        set
        {
            indSitPJFieldSpecified = value;
            RaisePropertyChanged("indSitPJSpecified");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public R1000InfoCadastroContato contato
    {
        get => contatoField;
        set
        {
            contatoField = value;
            RaisePropertyChanged("contato");
        }
    }

    /// <remarks/>
    [XmlElement("softHouse", Order = 6)]
    public R1000InfoCadastroSoftwareHouse softHouse
    {
        get => softHouseField;
        set
        {
            softHouseField = value;
            RaisePropertyChanged("softHouse");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public R1000InfoCadastroEFR infoEFR
    {
        get => infoEFRField;
        set
        {
            infoEFRField = value;
            RaisePropertyChanged("infoEFR");
        }
    }
}


/// <exclude />
public partial class R1000InfoCadastroContato : EfdReinfBindableObject
{
    private string nmCttField;
    private string cpfCttField;
    private string foneFixoField;
    private string foneCelField;
    private string emailField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nmCtt
    {
        get => nmCttField;
        set
        {
            nmCttField = value;
            RaisePropertyChanged("nmCtt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cpfCtt
    {
        get => cpfCttField;
        set
        {
            cpfCttField = value;
            RaisePropertyChanged("cpfCtt");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string foneFixo
    {
        get => foneFixoField;
        set
        {
            foneFixoField = value;
            RaisePropertyChanged("foneFixo");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string foneCel
    {
        get => foneCelField;
        set
        {
            foneCelField = value;
            RaisePropertyChanged("foneCel");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string email
    {
        get => emailField;
        set
        {
            emailField = value;
            RaisePropertyChanged("email");
        }
    }
}


/// <exclude />
public partial class R1000InfoCadastroSoftwareHouse : EfdReinfBindableObject
{
    private string cnpjSoftHouseField = "19574916000183";
    private string nmRazaoField = "EFICAZ SISTEMAS DE GESTÃO E INTELIGÊNCIA TRIBUTÁRIA LTDA - ME";
    private string nmContField = "DANIEL LUCINDO BASILIO";
    private string telefoneField = "16981282669";
    private string emailField = "contato@eficazcs.com.br";

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjSoftHouse
    {
        get => cnpjSoftHouseField;
        set
        {
            cnpjSoftHouseField = value;
            RaisePropertyChanged("cnpjSoftHouse");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nmRazao
    {
        get => nmRazaoField;
        set
        {
            nmRazaoField = value;
            RaisePropertyChanged("nmRazao");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string nmCont
    {
        get => nmContField;
        set
        {
            nmContField = value;
            RaisePropertyChanged("nmCont");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string telefone
    {
        get => telefoneField;
        set
        {
            telefoneField = value;
            RaisePropertyChanged("telefone");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string email
    {
        get => emailField;
        set
        {
            emailField = value;
            RaisePropertyChanged("email");
        }
    }
}