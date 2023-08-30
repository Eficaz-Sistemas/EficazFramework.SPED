namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Retenção de contribuição previdenciária - serviços tomados
/// </summary>
/// <example>
/// ```csharp
/// var evento = new R2010()
/// {
///     Versao = Versao.v2_01_02,
///     evtServTom = new R2010EventoServicoTomado()
///     {
///         ideContri = new IdentificacaoContribuinte()
///         {
///             tpInsc = PersonalidadeJuridica.CNPJ,
///             nrInsc = "12345678"
///         },
///         ideEvento = new IdentificacaoEventoPeriodico()
///         {
///             indRetif = IndicadorRetificacao.Original,
///             perApur = $"{DateTime.Now.AddMonths(-1):yyyy-MM}",
///             procEmi = EmissorEvento.AppContribuinte,
///             tpAmb = Ambiente.ProducaoRestrita_DadosReais,
///             verProc = "2.2"
///         },
///         infoServTom = new R2010ServicoTomado()
///         {
///             ideEstabObra = new R2010IdentificacaoEstabObra()
///             {
///                 tpInscEstab = PersonalidadeJuridica.CNPJ,
///                 nrInscEstab = "12345678000100",
///                 idePrestServ = new R2010IdentificacaoPrestServico()
///                 {
///                     cnpjPrestador = "61918769000188",
///                     vlrTotalBruto = "600,00",
///                     vlrTotalBaseRet = "600,00",
///                     vlrTotalRetPrinc = "66,00",
///                     indCPRB = IndicadorContribuinteCPRB.NaoContribuinte,
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
///         }
///     }
/// }
/// ```
/// </example>
[Serializable()]
public partial class R2010 : Evento
{
    private R2010EventoServicoTomado evtServTomField;
    private SignatureType signatureField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2010EventoServicoTomado evtServTom
    {
        get => evtServTomField;

        set
        {
            evtServTomField = value;
            RaisePropertyChanged("evtServTom");
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
        evtServTomField.id = $"ID{(int)(evtServTomField?.ideContri?.tpInsc ?? PersonalidadeJuridica.CNPJ)}{evtServTomField?.ideContri?.NumeroInscricaoTag() ?? "00000000000000"}{ReinfTimeStampUtils.GetTimeStampIDForEvent()}";

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtServTom.ideContri.nrInsc;


    // IXmlSignableDocument Members
    /// <exclude/>
    public override string TagToSign => "Reinf";
    /// <exclude/>
    public override string TagId => "evtServTom";
    /// <exclude/>
    public override bool EmptyURI => true;
    /// <exclude/>
    public override bool SignAsSHA256 => true;


    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new(typeof(R2010), new XmlRootAttribute("Reinf") { Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtTomadorServicos/{Versao}", IsNullable = false });
}


/// <exclude />
public partial class R2010EventoServicoTomado : EfdReinfBindableObject
{
    private IdentificacaoEventoPeriodico ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private R2010ServicoTomado infoServTomField;
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
    public R2010ServicoTomado infoServTom
    {
        get => infoServTomField;

        set
        {
            infoServTomField = value;
            RaisePropertyChanged("infoServTom");
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
public partial class R2010ServicoTomado : EfdReinfBindableObject
{
    private R2010IdentificacaoEstabObra ideEstabObraField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public R2010IdentificacaoEstabObra ideEstabObra
    {
        get => ideEstabObraField;

        set
        {
            ideEstabObraField = value;
            RaisePropertyChanged("ideEstabObra");
        }
    }
}


/// <exclude />
public partial class R2010IdentificacaoEstabObra : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscEstabField;
    private string nrInscEstabField;
    private IndicadorObra indObraField = IndicadorObra.NaoSujeitoCEI;
    private R2010IdentificacaoPrestServico idePrestServField;

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
    public IndicadorObra indObra
    {
        get => indObraField;

        set
        {
            indObraField = value;
            RaisePropertyChanged("indObra");
            RaisePropertyChanged("indObra_Str");
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
    public R2010IdentificacaoPrestServico idePrestServ
    {
        get => idePrestServField;

        set
        {
            idePrestServField = value;
            RaisePropertyChanged("idePrestServ");
        }
    }
}


/// <exclude />
public partial class R2010IdentificacaoPrestServico : EfdReinfBindableObject
{
    private string cnpjPrestadorField;
    private string vlrTotalBrutoField;
    private string vlrTotalBaseRetField;
    private string vlrTotalRetPrincField;
    private string vlrTotalRetAdicField;
    private string vlrTotalNRetPrincField;
    private string vlrTotalNRetAdicField;
    private IndicadorContribuinteCPRB indCPRBField;
    private List<R2010eR2020Nfs> nfsField = new List<R2010eR2020Nfs>();
    private List<R2010eR2020ProcessoRelacionado> infoProcRetPrField = new List<R2010eR2020ProcessoRelacionado>();
    private List<R2010eR2020ProcessoRelacionadoAdic> infoProcRetAdField = new List<R2010eR2020ProcessoRelacionadoAdic>();

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cnpjPrestador
    {
        get => cnpjPrestadorField;

        set
        {
            cnpjPrestadorField = value;
            RaisePropertyChanged("cnpjPrestador");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string vlrTotalBruto
    {
        get => vlrTotalBrutoField;

        set
        {
            vlrTotalBrutoField = value;
            // If Me.vlrTotalBrutoField.HasValue Then Me.vlrTotalBrutoField = Math.Round(Me.vlrTotalBrutoField.Value, 2)
            RaisePropertyChanged("vlrTotalBruto");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string vlrTotalBaseRet
    {
        get => vlrTotalBaseRetField;

        set
        {
            vlrTotalBaseRetField = value;
            // If Me.vlrTotalBaseRetField.HasValue Then Me.vlrTotalBaseRetField = Math.Round(Me.vlrTotalBaseRetField.Value, 2)
            RaisePropertyChanged("vlrTotalBaseRet");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string vlrTotalRetPrinc
    {
        get => vlrTotalRetPrincField;

        set
        {
            vlrTotalRetPrincField = value;
            // If Me.vlrTotalRetPrincField.HasValue Then Me.vlrTotalRetPrincField = Math.Round(Me.vlrTotalRetPrincField.Value, 2)
            RaisePropertyChanged("vlrTotalRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string vlrTotalRetAdic
    {
        get => vlrTotalRetAdicField;

        set
        {
            vlrTotalRetAdicField = value;
            // If Me.vlrTotalRetAdicField.HasValue Then Me.vlrTotalRetAdicField = Math.Round(Me.vlrTotalRetAdicField.Value, 2)
            RaisePropertyChanged("vlrTotalRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string vlrTotalNRetPrinc
    {
        get => vlrTotalNRetPrincField;

        set
        {
            vlrTotalNRetPrincField = value;
            // If Me.vlrTotalNRetPrincField.HasValue Then Me.vlrTotalNRetPrincField = Math.Round(Me.vlrTotalNRetPrincField.Value, 2)
            RaisePropertyChanged("vlrTotalNRetPrinc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 6)]
    public string vlrTotalNRetAdic
    {
        get => vlrTotalNRetAdicField;

        set
        {
            vlrTotalNRetAdicField = value;
            // If Me.vlrTotalNRetAdicField.HasValue Then Me.vlrTotalNRetAdicField = Math.Round(Me.vlrTotalNRetAdicField.Value, 2)
            RaisePropertyChanged("vlrTotalNRetAdic");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public IndicadorContribuinteCPRB indCPRB
    {
        get => indCPRBField;

        set
        {
            indCPRBField = value;
            RaisePropertyChanged("indCPRB");
            RaisePropertyChanged("indCPRB_Str");
        }
    }

    [XmlIgnore()]
    public string indCPRB_Str
    {
        get
        {
            switch (indCPRB)
            {
                case IndicadorContribuinteCPRB.Contribuinte:
                    {
                        return "Contribuinte";
                    }

                case IndicadorContribuinteCPRB.NaoContribuinte:
                    {
                        return "Não Contribuinte";
                    }
            }

            return null;
        }
    }

    /// <remarks/>
    [XmlElement("nfs", Order = 8)]
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
    [XmlElement("infoProcRetPr", Order = 9)]
    public List<R2010eR2020ProcessoRelacionado> infoProcRetPr
    {
        get => infoProcRetPrField;

        set
        {
            infoProcRetPrField = value;
            RaisePropertyChanged("infoProcRetPr");
        }
    }

    /// <remarks/>
    [XmlElement("infoProcRetAd", Order = 10)]
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