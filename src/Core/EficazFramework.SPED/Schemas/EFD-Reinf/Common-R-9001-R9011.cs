namespace EficazFramework.SPED.Schemas.EFD_Reinf;


/// <summary>
/// Identificacao do estabelecimento com seus totais
/// </summary>
public partial class TotalSerieR2000 : EfdReinfBindableObject
{
    private TotalizadorR2010 rTomField;
    private TotalizadorR2020 rPrestField;
    private TotalizadorR2030eR2040[] rRecRepADField;
    private TotalizadorR2050[] rComlField;
    private TotalizadorR2055[] rAquisField;
    private TotalizadorR2060[] rCPRBField;
    private TotalizadorR3010 rRecEspetDespField;


    /// <summary>
    /// Totalizador do evento R-2010
    /// </summary>
    public TotalizadorR2010 RTom
    {
        get => rTomField;
        set
        {
            rTomField = value;
            RaisePropertyChanged(nameof(RTom));
        }
    }

    /// <summary>
    /// Totalizador do evento R-2020
    /// </summary>
    public TotalizadorR2020 RPrest
    {
        get => rPrestField;
        set
        {
            rPrestField = value;
            RaisePropertyChanged(nameof(RPrest));
        }
    }

    /// <summary>
    /// Totalizador dos eventos R-2030 e R-2040
    /// </summary>
    [XmlElement("RRecRepAD")]
    public TotalizadorR2030eR2040[] RRecRepAD
    {
        get => rRecRepADField;
        set
        {
            rRecRepADField = value;
            RaisePropertyChanged(nameof(RRecRepAD));
        }
    }

    /// <summary>
    /// Totalizador do evento R-2050
    /// </summary>
    [XmlElement("RComl")]
    public TotalizadorR2050[] RComl
    {
        get => rComlField;
        set
        {
            rComlField = value;
            RaisePropertyChanged(nameof(RComl));
        }
    }

    /// <summary>
    /// Totalizador do evento R-2055
    /// </summary>
    [XmlElement("RAquis")]
    public TotalizadorR2055[] RAquis
    {
        get => rAquisField;
        set
        {
            rAquisField = value;
            RaisePropertyChanged(nameof(RAquis));
        }
    }

    /// <summary>
    /// Totalizador do evento R-2060
    /// </summary>
    [XmlElement("RCPRB")]
    public TotalizadorR2060[] RCPRB
    {
        get => rCPRBField;
        set
        {
            rCPRBField = value;
            RaisePropertyChanged(nameof(RCPRB));
        }
    }

    /// <summary>
    /// Totalizador do evento R-3010
    /// </summary>
    public TotalizadorR3010 RRecEspetDesp
    {
        get => rRecEspetDespField;
        set
        {
            rRecEspetDespField = value;
            RaisePropertyChanged(nameof(RRecEspetDesp));
        }
    }
}


/// <summary>
/// Totalizador do evento R-2010
/// </summary>
public partial class TotalizadorR2010 : EfdReinfBindableObject
{
    private string cnpjPrestadorField;
    private string cnoField;
    private string vlrTotalBaseRetField;
    private TotalizadorR2010InfoRetencoes[] infoCRTomField;

    [XmlElement()]
    public string cnpjPrestador
    {
        get => cnpjPrestadorField;
        set
        {
            cnpjPrestadorField = value;
            RaisePropertyChanged(nameof(cnpjPrestador));
        }
    }

    [XmlElement()]
    public string cno
    {
        get => cnoField;
        set
        {
            cnoField = value;
            RaisePropertyChanged(nameof(cno));
        }
    }

    [XmlElement()]
    public string vlrTotalBaseRet
    {
        get => vlrTotalBaseRetField;
        set
        {
            vlrTotalBaseRetField = value;
            RaisePropertyChanged(nameof(vlrTotalBaseRet));
        }
    }

    /// <summary>
    /// Informacoes de retencoes sobre servicos
    /// </summary>
    [XmlElement("infoCRTom")]
    public TotalizadorR2010InfoRetencoes[] infoCRTom
    {
        get => infoCRTomField;
        set
        {
            infoCRTomField = value;
            RaisePropertyChanged(nameof(infoCRTom));
        }
    }
}


public partial class TotalizadorR2010InfoRetencoes : EfdReinfBindableObject
{
    private string cRTomField;
    private string vlrCRTomField;
    private string vlrCRTomSuspField;

    /// <summary>
    /// Código de Receita
    /// </summary>
    [XmlElement()]
    public string CRTom
    {
        get => cRTomField;

        set
        {
            cRTomField = value;
            RaisePropertyChanged(nameof(CRTom));
        }
    }

    [Obsolete("Renomeado para vlrCRTom na versão 2.01.02 B")]
    [XmlElement("VlrCRTom")]
    public string VlrCRTom_1_05_01
    {
        get => vlrCRTomField;
        set
        {
            vlrCRTomField = value;
            RaisePropertyChanged(nameof(VlrCRTom_1_05_01));
        }
    }

    public string vlrCRTom
    {
        get => vlrCRTomField;
        set
        {
            vlrCRTomField = value;
            RaisePropertyChanged(nameof(vlrCRTom));
        }
    }

    [Obsolete("Renomeado para vlrCRTom na versão 2.01.02 B")]
    [XmlElement("VlrCRTomSusp")]
    public string VlrCRTomSusp_1_05_01
    {
        get => vlrCRTomSuspField;
        set
        {
            vlrCRTomSuspField = value;
            RaisePropertyChanged("VlrCRTomSusp");
        }
    }

    public string vlrCRTomSusp
    {
        get => vlrCRTomSuspField;
        set
        {
            vlrCRTomSuspField = value;
            RaisePropertyChanged("VlrCRTomSusp");
        }
    }
}


/// <summary>
/// Totalizador do evento R-2020
/// </summary>
public partial class TotalizadorR2020 : EfdReinfBindableObject
{
    private byte tpInscTomadorField;
    private string nrInscTomadorField;
    private string vlrTotalBaseRetField;
    private string vlrTotalRetPrincField;
    private string vlrTotalRetAdicField;
    private string vlrTotalNRetPrincField;
    private string vlrTotalNRetAdicField;

    /// <remarks/>
    [XmlElement()]
    public byte tpInscTomador
    {
        get => tpInscTomadorField;
        set
        {
            tpInscTomadorField = value;
            RaisePropertyChanged(nameof(tpInscTomador));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string nrInscTomador
    {
        get => nrInscTomadorField;
        set
        {
            nrInscTomadorField = value;
            RaisePropertyChanged(nameof(nrInscTomador));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrTotalBaseRet
    {
        get => vlrTotalBaseRetField;
        set
        {
            vlrTotalBaseRetField = value;
            RaisePropertyChanged(nameof(vlrTotalBaseRet));
        }
    }

    /// <remarks/>
    [XmlElement (   )]
    public string vlrTotalRetPrinc
    {
        get => vlrTotalRetPrincField;
        set
        {
            vlrTotalRetPrincField = value;
            RaisePropertyChanged(nameof(vlrTotalRetPrinc));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrTotalRetAdic
    {
        get => vlrTotalRetAdicField;
        set
        {
            vlrTotalRetAdicField = value;
            RaisePropertyChanged(nameof(vlrTotalRetAdic));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrTotalNRetPrinc
    {
        get => vlrTotalNRetPrincField;
        set
        {
            vlrTotalNRetPrincField = value;
            RaisePropertyChanged(nameof(vlrTotalNRetPrinc));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrTotalNRetAdic
    {
        get => vlrTotalNRetAdicField;
        set
        {
            vlrTotalNRetAdicField = value;
            RaisePropertyChanged(nameof(vlrTotalNRetAdic));
        }
    }
}


/// <summary>
/// Totalizador dos eventos R-2030 e R-2040
/// </summary>
public partial class TotalizadorR2030eR2040 : EfdReinfBindableObject
{
    private string cnpjAssocDespField;
    private string vlrTotalRepField;
    private string cRRecRepADField;
    private string vlrCRRecRepADField;
    private string vlrCRRecRepADSuspField;

    /// <remarks/>
    [XmlElement()]
    public string cnpjAssocDesp
    {
        get => cnpjAssocDespField;
        set
        {
            cnpjAssocDespField = value;
            RaisePropertyChanged(nameof(cnpjAssocDesp));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrTotalRep
    {
        get => vlrTotalRepField;
        set
        {
            vlrTotalRepField = value;
            RaisePropertyChanged(nameof(vlrTotalRep));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string CRRecRepAD
    {
        get => cRRecRepADField;
        set
        {
            cRRecRepADField = value;
            RaisePropertyChanged(nameof(CRRecRepAD));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRRecRepAD
    {
        get => vlrCRRecRepADField;
        set
        {
            vlrCRRecRepADField = value;
            RaisePropertyChanged(nameof(vlrCRRecRepAD));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRRecRepADSusp
    {
        get => vlrCRRecRepADSuspField;
        set
        {
            vlrCRRecRepADSuspField = value;
            RaisePropertyChanged(nameof(vlrCRRecRepADSusp));
        }
    }
}


/// <summary>
/// Totalizador do evento R-2050
/// </summary>
public partial class TotalizadorR2050 : EfdReinfBindableObject
{
    private string cRComlField;
    private string vlrCRComlField;
    private string vlrCRComlSuspField;

    /// <remarks/>
    [XmlElement()]
    public string CRComl
    {
        get => cRComlField;

        set
        {
            cRComlField = value;
            RaisePropertyChanged(nameof(CRComl));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRComl
    {
        get => vlrCRComlField;

        set
        {
            vlrCRComlField = value;
            RaisePropertyChanged(nameof(vlrCRComl));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRComlSusp
    {
        get => vlrCRComlSuspField;

        set
        {
            vlrCRComlSuspField = value;
            RaisePropertyChanged(nameof(vlrCRComlSusp));
        }
    }
}


/// <summary>
/// Totalizador do evento R-2055
/// </summary>
public partial class TotalizadorR2055 : EfdReinfBindableObject
{

    private string cRAquisField;
    private string vlrCRAquisField;
    private string vlrCRAquisSuspField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement()]
    public string CRAquis
    {
        get => cRAquisField;
        set
        {
            cRAquisField = value;
            RaisePropertyChanged(nameof(CRAquis));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement()]
    public string vlrCRAquis
    {
        get => vlrCRAquisField;
        set
        {
            vlrCRAquisField = value;
            RaisePropertyChanged(nameof(vlrCRAquis));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement()]
    public string vlrCRAquisSusp
    {
        get => vlrCRAquisSuspField;
        set
        {
            vlrCRAquisSuspField = value;
            RaisePropertyChanged(nameof(vlrCRAquisSusp));
        }
    }
}


/// <summary>
/// Totalizador do evento R-2060
/// </summary>
public partial class TotalizadorR2060 : EfdReinfBindableObject
{
    private string cRCPRBField;
    private string vlrCRCPRBField;
    private string vlrCRCPRBSuspField;

    /// <remarks/>
    [XmlElement()]
    public string CRCPRB
    {
        get => cRCPRBField;
        set
        {
            cRCPRBField = value;
            RaisePropertyChanged(nameof(CRCPRB));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRCPRB
    {
        get => vlrCRCPRBField;
        set
        {
            vlrCRCPRBField = value;
            RaisePropertyChanged(nameof(vlrCRCPRB));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRCPRBSusp
    {
        get => vlrCRCPRBSuspField;
        set
        {
            vlrCRCPRBSuspField = value;
            RaisePropertyChanged(nameof(vlrCRCPRBSusp));
        }
    }
}


/// <summary>
/// Totalizador do evento R-3010
/// </summary>
public partial class TotalizadorR3010 : EfdReinfBindableObject
{
    private string cRRecEspetDespField;
    private string vlrReceitaTotalField;
    private string vlrCRRecEspetDespField;
    private string vlrCRRecEspetDespSuspField;

    /// <remarks/>
    [XmlElement()]
    public string CRRecEspetDesp
    {
        get => cRRecEspetDespField;
        set
        {
            cRRecEspetDespField = value;
            RaisePropertyChanged(nameof(CRRecEspetDesp));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrReceitaTotal
    {
        get => vlrReceitaTotalField;
        set
        {
            vlrReceitaTotalField = value;
            RaisePropertyChanged(nameof(vlrReceitaTotal));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRRecEspetDesp
    {
        get => vlrCRRecEspetDespField;
        set
        {
            vlrCRRecEspetDespField = value;
            RaisePropertyChanged(nameof(vlrCRRecEspetDesp));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string vlrCRRecEspetDespSusp
    {
        get => vlrCRRecEspetDespSuspField;
        set
        {
            vlrCRRecEspetDespSuspField = value;
            RaisePropertyChanged(nameof(vlrCRRecEspetDespSusp));
        }
    }
}