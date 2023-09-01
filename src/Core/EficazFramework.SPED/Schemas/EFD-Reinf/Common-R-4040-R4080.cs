namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <exclude />
public partial class R4040e4080InfoProcessoRelacionado : EfdReinfBindableObject
{
    private TipoProcesso tpProcRetField;
    private string nrProcRetField;
    private string codSuspField;
    private string vlrBaseSuspIRField;
    private string vlrNIRField;
    private string vlrDepIRField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
    public TipoProcesso tpProcRet
    {
        get => tpProcRetField;
        set
        {
            tpProcRetField = value;
            RaisePropertyChanged(nameof(tpProcRet));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 1)]
    public string nrProcRet
    {
        get => nrProcRetField;
        set
        {
            nrProcRetField = value;
            RaisePropertyChanged(nameof(nrProcRet));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 2)]
    public string codSusp
    {
        get => codSuspField;
        set
        {
            codSuspField = value;
            RaisePropertyChanged(nameof(codSusp));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 3)]
    public string vlrBaseSuspIR
    {
        get => vlrBaseSuspIRField;
        set
        {
            vlrBaseSuspIRField = value;
            RaisePropertyChanged(nameof(vlrBaseSuspIR));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 4)]
    public string vlrNIR
    {
        get => vlrNIRField;
        set
        {
            vlrNIRField = value;
            RaisePropertyChanged(nameof(vlrNIR));
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Order = 5)]
    public string vlrDepIR
    {
        get => vlrDepIRField;
        set
        {
            vlrDepIRField = value;
            RaisePropertyChanged(nameof(vlrDepIR));
        }
    }
}
