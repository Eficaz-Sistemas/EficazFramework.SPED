namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Retenção no recebimento
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R4080()
/// {
///     Versao = Versao.v2_01_02,
///     evtRetRec = new R4080EventoRetRecebimento()
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
///         ideEstab = new R4080IdentificacaoEstabelecimento()
///         {
///             tpInscEstab = PersonalidadeJuridica.CNPJ,
///             nrInscEstab = "34785515000166",
///             ideFont = new R4080IdentificacaoFontePagadora()
///             {
///                 // identificação do beneficiário
///                 cnpjFont = "10608025000126",
///                 // pagamento (1:1, diferentemente ao apresentado em R-4010
///                 ideRend = new()
///                 {
///                     // identificação do recebimento
///                     new R4080IdentificacaoRendimento()
///                     {
///                         // Utilizar a tabela 01, do Anexo I do Manual
///                         natRend = "20001", // Remuneração de Serviços de auditoria;
///                         observ = "Serviços de Propaganda e Publicidade",
/// 
///                         // informações do recebimento
///                         infoRec = new()
///                         {
///                             new R4080InfoRecebimento()
///                             {
///                                 DataFatoGerador = System.DateTime.Now,
///                                 vlrBruto = 152725.25M.ToString("f2"),
///                                 vlrBaseIR = 152725.25M.ToString("f2"),
///                                 vlrIR = 2290.88M.ToString("f2")
///                             },
///                         }
///                     },
///                 }
///             }
///         }
///     }
/// };
/// ```
/// </example>
[System.SerializableAttribute()]
public partial class R4080 : Evento
{

    private R4080EventoRetRecebimento evtRetRecField;
    private SignatureType signatureField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public R4080EventoRetRecebimento evtRetRec
    {
        get => evtRetRecField;
        set
        {
            evtRetRecField = value;
            RaisePropertyChanged(nameof(evtRetRec));
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
            RaisePropertyChanged(nameof(Signature));
        }
    }


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtRetRec";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Evento Members
    /// <exclude/>
    public override void GeraEventoID() =>
        evtRetRecField.id = $"ID{(int)(evtRetRecField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtRetRecField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";


    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtRetRecField.ideContri.nrInsc;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R4080), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evt4080RetencaoRecebimento/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R4080EventoRetRecebimento : EfdReinfBindableObject
{

    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R4080IdentificacaoEstabelecimento ideEstabField;
    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public IdentificacaoEventoPeriodico ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
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
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public R4080IdentificacaoEstabelecimento ideEstab
    {
        get => ideEstabField;
        set
        {
            ideEstabField = value;
            RaisePropertyChanged(nameof(ideEstab));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttributeAttribute(DataType = "ID")]
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
public partial class R4080IdentificacaoEstabelecimento : EfdReinfBindableObject
{

    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private R4080IdentificacaoFontePagadora ideFontField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public PersonalidadeJuridica tpInscEstab
    {
        get => tpInscEstabField;
        set
        {
            tpInscEstabField = value;
            RaisePropertyChanged(nameof(tpInscEstab));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string nrInscEstab
    {
        get => nrInscEstabField;
        set
        {
            nrInscEstabField = value;
            RaisePropertyChanged(nameof(nrInscEstab));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public R4080IdentificacaoFontePagadora ideFont
    {
        get => ideFontField;
        set
        {
            ideFontField = value;
            RaisePropertyChanged(nameof(ideFont));
        }
    }
}


/// <exclude />
public partial class R4080IdentificacaoFontePagadora : EfdReinfBindableObject
{

    private string cnpjFontField;
    private List<R4080IdentificacaoRendimento> ideRendField;

    /// <summary>
    /// CNPJ da Fonte Pagadora do Rendimento
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public string cnpjFont
    {
        get => cnpjFontField;
        set
        {
            cnpjFontField = value;
            RaisePropertyChanged(nameof(cnpjFont));
        }
    }

    /// <summary>
    /// Listagem de Identificação dos Rendimentos
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute("ideRend", Order = 1)]
    public List<R4080IdentificacaoRendimento> ideRend
    {
        get => ideRendField;
        set
        {
            ideRendField = value;
            RaisePropertyChanged(nameof(ideRend));
        }
    }
}


/// <summary>
/// Identificação do Rendimento
/// </summary>
/// <exclude />
public partial class R4080IdentificacaoRendimento : EfdReinfBindableObject
{

    private string natRendField;
    private string observField;
    private List<R4080InfoRecebimento> infoRecField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer", Order = 0)]
    public string natRend
    {
        get => natRendField;
        set
        {
            natRendField = value;
            RaisePropertyChanged(nameof(natRend));
        }
    }

    /// <summary>
    /// Informações relativas ao recebimento do rendimento.
    /// </summary>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string observ
    {
        get => observField;
        set
        {
            observField = value;
            RaisePropertyChanged(nameof(observ));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoRec", Order = 2)]
    public List<R4080InfoRecebimento> infoRec
    {
        get => infoRecField;
        set
        {
            infoRecField = value;
            RaisePropertyChanged(nameof(infoRec));
        }
    }
}

/// <summary>
/// Informações relativas ao recebimento do rendimento.
/// </summary>
/// <exclude />
public partial class R4080InfoRecebimento : EfdReinfBindableObject
{
    private System.DateTime dtFGField;
    private string vlrBrutoField;
    private string vlrBaseIRField;
    private string vlrIRField;
    private List<R4040e4080InfoProcessoRelacionado> infoProcRetField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("dtFG", DataType = "date", Order = 0)]
    public System.DateTime DataFatoGerador
    {
        get => dtFGField;
        set
        {
            dtFGField = value;
            RaisePropertyChanged(nameof(DataFatoGerador));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string vlrBruto
    {
        get => vlrBrutoField;
        set
        {
            vlrBrutoField = value;
            RaisePropertyChanged(nameof(vlrBruto));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public string vlrBaseIR
    {
        get => vlrBaseIRField;
        set
        {
            vlrBaseIRField = value;
            RaisePropertyChanged(nameof(vlrBaseIR));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public string vlrIR
    {
        get => vlrIRField;
        set
        {
            vlrIRField = value;
            RaisePropertyChanged(nameof(vlrIR));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("infoProcRet", Order = 4)]
    public List<R4040e4080InfoProcessoRelacionado> infoProcRet
    {
        get => infoProcRetField;
        set
        {
            infoProcRetField = value;
            RaisePropertyChanged(nameof(infoProcRet));
        }
    }
}
