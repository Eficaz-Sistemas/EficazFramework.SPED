namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Retenção de contribuição previdenciária – serviços prestados
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2020()
/// {
///     Versao = Versao.v2_01_02,
///     evtServPrest = new R2020EventoServicoPrestado()
///     {
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = _cnpj.Substring(0, 8)
///         },
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         },
///         infoServPrest = new R2020ServicoPrestado()
///         {
///             ideEstabPrest = new R2020IdentificacaoEstabPrestacao()
///             {
///                 tpInscEstabPrest = PersonalidadeJuridica.CNPJ,
///                 nrInscEstabPrest = "12345678000100",
///                 ideTomador = new R2020IdentificacaoTomadorServico()
///                 {
///                     tpInscTomador = PersonalidadeJuridica.CNPJ,
///                     nrInscTomador = "61918769000188",
///                     vlrTotalBruto = "600,00",
///                     vlrTotalBaseRet = "600,00",
///                     vlrTotalRetPrinc = "66,00",
///                     indObra = IndicadorObra.NaoSujeitoCEI,
///                     nfs = new()
///                     {
///                         new R2010eR2020Nfs()
///                         {
///                             serie = "0",
///                             numDocto = "719",
///                             dtEmissaoNF = new DateTime(DateTime.Now.Year, DateTime.Now.Date.AddMonths(-1).Month, 2),
///                             vlrBruto = "600,00",
///                             infoTpServ = new()
///                             {
///                                 new R2010eR2020InformacaoServico()
///                                 {
///                                     tpServico = "100000001",
///                                     vlrBaseRet = "600,00",
///                                     vlrRetencao = "66,00"
///                                 }
///                             }
///                         }
///                     }
///                 }
///             }
///         },
///     }
/// };
/// ```
/// </example>
[Serializable()]
public partial class R2020 : Evento
{
    private R2020EventoServicoPrestado evtServPrestField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2020EventoServicoPrestado evtServPrest
    {
        get => evtServPrestField;

        set
        {
            evtServPrestField = value;
            RaisePropertyChanged("evtServPrest");
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
        evtServPrestField.id = $"ID{(int)(evtServPrestField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtServPrestField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtServPrest.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtServPrest";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2020), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtPrestadorServicos/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2020EventoServicoPrestado : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R2020ServicoPrestado infoServPrestField;
    private string idField;

    /// <remarks/>
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
    public R2020ServicoPrestado infoServPrest
    {
        get => infoServPrestField;

        set
        {
            infoServPrestField = value;
            RaisePropertyChanged("infoServPrest");
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
public partial class R2020ServicoPrestado : EfdReinfBindableObject
{
    private R2020IdentificacaoEstabPrestacao ideEstabPrestField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2020IdentificacaoEstabPrestacao ideEstabPrest
    {
        get => ideEstabPrestField;

        set
        {
            ideEstabPrestField = value;
            RaisePropertyChanged("ideEstabPrest");
        }
    }
}


/// <exclude />
public partial class R2020IdentificacaoEstabPrestacao : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabPrestField;
    private string nrInscEstabPrestField;
    private R2020IdentificacaoTomadorServico ideTomadorField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscEstabPrest
    {
        get => tpInscEstabPrestField;

        set
        {
            tpInscEstabPrestField = value;
            RaisePropertyChanged("tpInscEstabPrest");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscEstabPrest
    {
        get => nrInscEstabPrestField;

        set
        {
            nrInscEstabPrestField = value;
            RaisePropertyChanged("nrInscEstabPrest");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public R2020IdentificacaoTomadorServico ideTomador
    {
        get => ideTomadorField;

        set
        {
            ideTomadorField = value;
            RaisePropertyChanged("ideTomador");
        }
    }
}


/// <exclude />
public partial class R2020IdentificacaoTomadorServico : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscTomadorField;
    private string nrInscTomadorField;
    private IndicadorObra indObraField;
    private string vlrTotalBrutoField;
    private string vlrTotalBaseRetField;
    private string vlrTotalRetPrincField;
    private string vlrTotalRetAdicField;
    private string vlrTotalNRetPrincField;
    private string vlrTotalNRetAdicField;
    private List<R2010eR2020Nfs> nfsField = new();
    private List<R2010eR2020ProcessoRelacionado> infoProcRetPrField = new();
    private List<R2010eR2020ProcessoRelacionadoAdic> infoProcRetAdField = new();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInscTomador
    {
        get => tpInscTomadorField;

        set
        {
            tpInscTomadorField = value;
            RaisePropertyChanged("tpInscTomador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInscTomador
    {
        get => nrInscTomadorField;

        set
        {
            nrInscTomadorField = value;
            RaisePropertyChanged("nrInscTomador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public IndicadorObra indObra
    {
        get => indObraField;

        set
        {
            indObraField = value;
            RaisePropertyChanged("indObra");
        }
    }

    [XmlIgnore()]
    public string indObra_Str
    {
        get
        {
            switch (indObra)
            {
                case IndicadorObra.NaoSujeitoCEI:
                    {
                        return "Não é obra ou não está sujeito a Matrícula CEI";
                    }

                case IndicadorObra.Obra_Parcial:
                    {
                        return "Obra - Empreitada Parcial";
                    }

                case IndicadorObra.Obra_Total:
                    {
                        return "Obra - Empreitada Total";
                    }
            }

            return null;
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalBruto
    {
        get => vlrTotalBrutoField;

        set
        {
            vlrTotalBrutoField = value;
            RaisePropertyChanged("vlrTotalBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrTotalBaseRet
    {
        get => vlrTotalBaseRetField;

        set
        {
            vlrTotalBaseRetField = value;
            RaisePropertyChanged("vlrTotalBaseRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrTotalRetPrinc
    {
        get => vlrTotalRetPrincField;

        set
        {
            vlrTotalRetPrincField = value;
            RaisePropertyChanged("vlrTotalRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotalRetAdic
    {
        get => vlrTotalRetAdicField;

        set
        {
            vlrTotalRetAdicField = value;
            RaisePropertyChanged("vlrTotalRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public string vlrTotalNRetPrinc
    {
        get => vlrTotalNRetPrincField;

        set
        {
            vlrTotalNRetPrincField = value;
            RaisePropertyChanged("vlrTotalNRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 8)]
    public string vlrTotalNRetAdic
    {
        get => vlrTotalNRetAdicField;

        set
        {
            vlrTotalNRetAdicField = value;
            RaisePropertyChanged("vlrTotalNRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement("nfs", Order = 9)]
    public List<R2010eR2020Nfs> nfs
    {
        get => nfsField;

        set
        {
            nfsField = value;
            RaisePropertyChanged("nfs");
        }
    }

    /// <remarks/>
    [XmlElement("infoProcRetPr", Order = 10)]
    public List<R2010eR2020ProcessoRelacionado> infoProcRetPr
    {
        get => infoProcRetPrField;

        set
        {
            infoProcRetPrField = value;
            RaisePropertyChanged("infoProcRetPr");
        }
    }

    /// <remarks/>s
    [XmlElement("infoProcRetAd", Order = 11)]
    public List<R2010eR2020ProcessoRelacionadoAdic> infoProcRetAd
    {
        get => infoProcRetAdField;

        set
        {
            infoProcRetAdField = value;
            RaisePropertyChanged("infoProcRetAd");
        }
    }
}