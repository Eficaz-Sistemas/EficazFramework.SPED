namespace EficazFramework.SPED.Schemas.EFD_Reinf;

/// <summary>
/// Evento totalizador por contribuinte. Retorno do fechamento da série R-4000.
/// </summary>
[Serializable()]
public partial class R9015 : EventoRetorno
{
    private R9015EventoRetornoTotal evtRetConsField;
    private SignatureType signatureField;

    [XmlElement()]
    public R9015EventoRetornoTotal evtRetCons
    {
        get => evtRetConsField;
        set
        {
            evtRetConsField = value;
            RaisePropertyChanged(nameof(evtRetCons));
        }
    }

    /// <exclude/>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            signatureField = value;
            RaisePropertyChanged(nameof(Signature));
        }
    }

    /// <exclude/>
    public override string ContribuinteCNPJ() =>
        evtRetCons.ideContri.nrInsc;

    // Serialization Members
    /// <exclude/>
    public override XmlSerializer DefineSerializer() =>
        new XmlSerializer(typeof(R9015), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/evtRetCons/{Versao}",
            IsNullable = false
        });
}


/// <summary>
/// Evento Totalizador - Retorno dos eventos da série R-4000, exceto pelo fechamento e/ou reabertura (R-4099)
/// </summary>
public partial class R9015EventoRetornoTotal : EventoRetornoTotal
{
    private R9015InfoTotal infoCR_CNRField;
    private R9015InfoTotal infoTotalCRField;

    /// <summary>
    /// Informacoes relativas as Totalizadores Pela Natureza do Rendimento
    /// </summary>
    [XmlElement()]
    public R9015InfoTotal infoCR_CNR
    {
        get => infoCR_CNRField;
        set
        {
            infoCR_CNRField = value;
            RaisePropertyChanged(nameof(infoCR_CNR));
        }
    }

    /// <summary>
    /// Informacoes consolidadas dos tributos da empresa
    /// </summary>
    [XmlElement()]
    public R9015InfoTotal infoTotalCR
    {
        get => infoTotalCRField;
        set
        {
            infoTotalCRField = value;
            RaisePropertyChanged(nameof(infoTotalCR));
        }
    }

}


public partial class R9015InfoTotal : EfdReinfBindableObject
{
    private uint indExistInfoField;
    private uint identEscritDCTFField;
    private ApuracaoTributoR4000Fechamento[] totApurMenField;
    private ApuracaoTributoR4000Fechamento[] totApurQuiField;
    private ApuracaoTributoR4000Fechamento[] totApurDecField;
    private ApuracaoTributoR4000Fechamento[] totApurSemField;
    private ApuracaoTributoR4000Fechamento[] totApurDiaField;

    public uint indExistInfo
    {
        get => indExistInfoField;
        set
        {
            indExistInfoField = value;
            RaisePropertyChanged(nameof(indExistInfo));
        }
    }

    public uint identEscritDCTF
    {
        get => identEscritDCTFField;
        set
        {
            identEscritDCTFField = value;
            RaisePropertyChanged(nameof(identEscritDCTF));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao mensal
    /// </summary>
    [XmlElement("totApurMen")]
    public ApuracaoTributoR4000Fechamento[] TotalApuracaoMensal
    {
        get => totApurMenField;
        set
        {
            totApurMenField = value;
            RaisePropertyChanged(nameof(TotalApuracaoMensal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao quinzenal
    /// </summary>
    [XmlElement("totApurQui")]
    public ApuracaoTributoR4000Fechamento[] TotalApuracaoQuinzenal
    {
        get => totApurQuiField;
        set
        {
            totApurQuiField = value;
            RaisePropertyChanged(nameof(TotalApuracaoQuinzenal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao decendial
    /// </summary>
    [XmlElement("totApurDec")]
    public ApuracaoTributoR4000Fechamento[] TotalApuracaoDecendial
    {
        get => totApurDecField;
        set
        {
            totApurDecField = value;
            RaisePropertyChanged(nameof(TotalApuracaoDecendial));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao semanal
    /// </summary>
    [XmlElement("totApurSem")]
    public ApuracaoTributoR4000Fechamento[] TotalApuracaoSemanal
    {
        get => totApurSemField;
        set
        {
            totApurSemField = value;
            RaisePropertyChanged(nameof(TotalApuracaoSemanal));
        }
    }

    /// <summary>
    /// Bases e tributos com periodo de apuracao diária
    /// </summary>
    [XmlElement("totApurDia")]
    public ApuracaoTributoR4000Fechamento[] TotalApuracaoDiaria
    {
        get => totApurDiaField;
        set
        {
            totApurDiaField = value;
            RaisePropertyChanged(nameof(TotalApuracaoDiaria));
        }
    }

}