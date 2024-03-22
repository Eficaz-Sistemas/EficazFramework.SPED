using EficazFramework.SPED.Extensions;

namespace EficazFramework.SPED.Schemas.NFe;

public partial class InformacoesTransporte : INotifyPropertyChanged
{
    private ModalidadeFrete modFreteField;
    private Transportadora transportaField;
    private TransporteRetencaoICMS retTranspField;
    // Private itemsField As List(Of Object)
    // Private itemsElementNameField As List(Of FormaTransporte)
    private List<VolumeTransportado> volField;
    private Veiculo _veicField;
    private List<Veiculo> _reboques;
    private string _vagao;
    private string _balsa;

    [XmlElement("modFrete")]
    public ModalidadeFrete Modalidade
    {
        get => modFreteField;
        set
        {
            if (modFreteField.Equals(value) != true)
            {
                modFreteField = value;
                OnPropertyChanged(nameof(Modalidade));
            }
        }
    }

    [XmlElement("transporta")]
    public Transportadora Transportadora
    {
        get => transportaField;
        set
        {
            if (transportaField is null || transportaField.Equals(value) != true)
            {
                transportaField = value;
                OnPropertyChanged(nameof(Transportadora));
            }
        }
    }

    [XmlElement("retTransp")]
    public TransporteRetencaoICMS RetancaoICMS
    {
        get => retTranspField;
        set
        {
            if (retTranspField is null || retTranspField.Equals(value) != true)
            {
                retTranspField = value;
                OnPropertyChanged("Operacao");
            }
        }
    }

    // // AUTO GENERATED AND NOT WORKED... Will be mapped manually:

    // <System.Xml.Serialization.XmlElementAttribute("balsa", GetType(String)), _
    // System.Xml.Serialization.XmlElementAttribute("reboque", GetType(Veiculo)), _
    // System.Xml.Serialization.XmlElementAttribute("vagao", GetType(String)), _
    // System.Xml.Serialization.XmlElementAttribute("veicTransp", GetType(Veiculo)), _
    // System.Xml.Serialization.XmlChoiceIdentifierAttribute("FormaTransporteCampos")> _
    // Public Property FormaTransporte() As List(Of Object)
    // Get
    // Return Me.itemsField
    // End Get
    // Set(value As List(Of Object))
    // If ((Me.itemsField Is Nothing) _
    // OrElse (itemsField.Equals(value) <> True)) Then
    // Me.itemsField = value
    // Me.OnPropertyChanged("FormaTransporte")
    // End If
    // End Set
    // End Property

    // <System.Xml.Serialization.XmlElementAttribute("FormaTransporteCampos"), _
    // System.Xml.Serialization.XmlIgnoreAttribute()> _
    // Public Property FormaTransporteCampos() As FormaTransporte() 'List(Of FormaTransporte)
    // Get
    // Return Me.itemsElementNameField.ToArray
    // End Get
    // Set(value As FormaTransporte())
    // If ((Me.itemsElementNameField Is Nothing) _
    // OrElse (itemsElementNameField.Equals(value) <> True)) Then
    // Me.itemsElementNameField = value.ToList
    // Me.OnPropertyChanged("FormaTransporteCampos")
    // End If
    // End Set
    // End Property

    // // Fixed Values:

    [XmlElement("veicTransp", IsNullable = false)]
    public Veiculo Veiculo
    {
        get => _veicField;
        set
        {
            _veicField = value;
            if (transportaField is null || transportaField.Equals(value) != true)
            {
                _veicField = value;
                OnPropertyChanged(nameof(Veiculo));
            }
        }
    }

    [XmlElement("reboque", IsNullable = false)]
    public List<Veiculo> Reboques
    {
        get => _reboques;
        set
        {
            if (_reboques is null || _reboques.Equals(value) != true)
            {
                _reboques = value;
                OnPropertyChanged(nameof(Reboques));
            }
        }
    }

    [XmlElement("vagao", IsNullable = false)]
    public string Vagao
    {
        get => _vagao;
        set
        {
            if (_balsa is null || _vagao.Equals(value) != true)
            {
                _vagao = value;
                OnPropertyChanged(nameof(Vagao));
            }
        }
    }

    [XmlElement("balsa", IsNullable = false)]
    public string Balsa
    {
        get => _balsa;
        set
        {
            if (_balsa is null || _balsa.Equals(value) != true)
            {
                _balsa = value;
                OnPropertyChanged(nameof(Balsa));
            }
        }
    }

    [XmlElement("vol")]
    public List<VolumeTransportado> Volumes
    {
        get => volField;
        set
        {
            if (volField is null || volField.Equals(value) != true)
            {
                volField = value;
                OnPropertyChanged(nameof(Volumes));
            }
        }
    }

    public string Placa
    {
        get
        {
            if (Veiculo != null)
            {
                return Veiculo.Placa;
            }

            if (Reboques.Count > 0)
            {
                return Reboques[0].Placa;
            }

            if (Balsa != null)
            {
                return Balsa;
            }

            return null;
        }
    }

    public string PlacaUF
    {
        get
        {
            if (Veiculo != null)
            {
                return Veiculo.UF.ToString();
            }

            if (Reboques.Count > 0)
            {
                return Reboques[0].UF.ToString();
            }

            if (Balsa != null)
            {
                return Balsa;
            }

            return null;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Transportadora : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string xNomeField;
    private string ieField;
    private string xEnderField;
    private string xMunField;
    private Estado ufField;
    private bool ufFieldSpecified;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("TransportadoraPersonalidadeJuridica")]
    public string CNPJ_CPF
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(CNPJ_CPF));
            }
        }
    }

    [XmlIgnore()]
    public string CNPJ_CPFFormatado => CNPJ_CPF?.FormatRFBDocument() ?? null;

    [XmlIgnore()]
    public PersonalidadeJuridica TransportadoraPersonalidadeJuridica
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TransportadoraPersonalidadeJuridica));
            }
        }
    }

    [XmlElement("xNome")]
    public string RazaoSocial
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(RazaoSocial));
            }
        }
    }

    [XmlElement("IE")]
    public string InscricaoEstadual
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(InscricaoEstadual));
            }
        }
    }

    [XmlElement("xEnder")]
    public string Endereco
    {
        get => xEnderField;
        set
        {
            if (xEnderField is null || xEnderField.Equals(value) != true)
            {
                xEnderField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    [XmlElement("xMun")]
    public string Municipio
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(Municipio));
            }
        }
    }

    public Estado UF
    {
        get => ufField;
        set
        {
            if (ufField.Equals(value) != true)
            {
                ufField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    [XmlIgnore()]
    public string IEFormatado => InscricaoEstadual?.FormatIE(UF.ToString()) ?? null;

    [XmlIgnore()]
    public bool UFSpecified
    {
        get => ufFieldSpecified;
        set
        {
            if (ufFieldSpecified.Equals(value) != true)
            {
                ufFieldSpecified = value;
                OnPropertyChanged(nameof(UFSpecified));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Veiculo : INotifyPropertyChanged
{
    private string placaField;
    private Estado ufField;
    private string rNTCField;

    [XmlElement("placa")]
    public string Placa
    {
        get => placaField;
        set
        {
            if (placaField is null || placaField.Equals(value) != true)
            {
                placaField = value;
                OnPropertyChanged(nameof(Placa));
            }
        }
    }

    [XmlElement("UF")]
    public Estado UF
    {
        get => ufField;
        set
        {
            if (ufField.Equals(value) != true)
            {
                ufField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    [XmlElement("RNTC")]
    public string RNTC
    {
        get => rNTCField;
        set
        {
            if (rNTCField is null || rNTCField.Equals(value) != true)
            {
                rNTCField = value;
                OnPropertyChanged(nameof(RNTC));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TransporteRetencaoICMS : INotifyPropertyChanged
{
    private double? vServField;
    private double? vBCRetField;
    private double? pICMSRetField;
    private double? vICMSRetField;
    private string cFOPField;
    private string cMunFGField;

    [XmlElement("vServ")]
    public double? ValorServico
    {
        get => vServField;
        set
        {
            if (vServField is null || vServField.Equals(value) != true)
            {
                vServField = value;
                OnPropertyChanged(nameof(ValorServico));
            }
        }
    }

    public bool ShouldSerializeValorServico() => ValorServico.HasValue;


    [XmlElement("vBCRet")]
    public double? BaseDeCalculo
    {
        get => vBCRetField;
        set
        {
            if (vBCRetField is null || vBCRetField.Equals(value) != true)
            {
                vBCRetField = value;
                OnPropertyChanged(nameof(BaseDeCalculo));
            }
        }
    }

    public bool ShouldSerializeBaseDeCalculo() => BaseDeCalculo.HasValue;


    [XmlElement("pICMSRet")]
    public double? Aliquota
    {
        get => pICMSRetField;
        set
        {
            if (pICMSRetField is null || pICMSRetField.Equals(value) != true)
            {
                pICMSRetField = value;
                OnPropertyChanged(nameof(Aliquota));
            }
        }
    }

    public bool ShouldSerializeAliquota() => Aliquota.HasValue;


    [XmlElement("vICMSRet")]
    public double? ValorICMS
    {
        get => vICMSRetField;
        set
        {
            if (vICMSRetField is null || vICMSRetField.Equals(value) != true)
            {
                vICMSRetField = value;
                OnPropertyChanged(nameof(ValorICMS));
            }
        }
    }

    public bool ShouldSerializeValorICMS() => ValorICMS.HasValue;


    public string CFOP
    {
        get => cFOPField;
        set
        {
            if (cFOPField is null || cFOPField.Equals(value) != true)
            {
                cFOPField = value;
                OnPropertyChanged(nameof(CFOP));
            }
        }
    }

    [XmlElement("cMunFG")]
    public string CodigoMunicipioFatoGerador
    {
        get => cMunFGField;
        set
        {
            if (cMunFGField is null || cMunFGField.Equals(value) != true)
            {
                cMunFGField = value;
                OnPropertyChanged(nameof(CodigoMunicipioFatoGerador));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class VolumeTransportado : INotifyPropertyChanged
{
    private double? qVolField;
    private string espField;
    private string marcaField;
    private string nVolField;
    private double? pesoLField;
    private double? pesoBField;
    private List<VolumeLacres> lacresField;

    public double? qVol
    {
        get => qVolField;
        set
        {
            if (qVolField is null || qVolField.Equals(value) != true)
            {
                qVolField = value;
                OnPropertyChanged(nameof(qVol));
            }
        }
    }

    public string esp
    {
        get => espField;
        set
        {
            if (espField is null || espField.Equals(value) != true)
            {
                espField = value;
                OnPropertyChanged(nameof(esp));
            }
        }
    }

    public string marca
    {
        get => marcaField;
        set
        {
            if (marcaField is null || marcaField.Equals(value) != true)
            {
                marcaField = value;
                OnPropertyChanged(nameof(marca));
            }
        }
    }

    public string nVol
    {
        get => nVolField;
        set
        {
            if (nVolField is null || nVolField.Equals(value) != true)
            {
                nVolField = value;
                OnPropertyChanged(nameof(nVol));
            }
        }
    }

    [XmlIgnore()]
    public double? pesoL
    {
        get => pesoLField;
        set
        {
            if (pesoLField is null || pesoLField.Equals(value) != true)
            {
                pesoLField = value;
                OnPropertyChanged(nameof(pesoL));
            }
        }
    }

    [XmlElement("pesoL")]
    public string pesoLXml
    {
        get => $"{pesoLField:#0.000}".Replace(',', '.');
        set
        {
            if (pesoLField is null || pesoLField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains('.') & !value.Contains(','))
                            value += "00";
                        pesoLField = double.Parse(value) / 100d;
                    }
                    else
                    {
                        pesoLField = default;
                    }
                }
                else
                {
                    pesoLField = default;
                }

                OnPropertyChanged(nameof(pesoL));
            }
        }
    }

    public bool ShouldSerializepesoLXml() => pesoLField.HasValue;

    [XmlIgnore()]
    public double? pesoB
    {
        get => pesoBField;
        set
        {
            if (pesoBField is null || pesoBField.Equals(value) != true)
            {
                pesoBField = value;
                OnPropertyChanged(nameof(pesoB));
            }
        }
    }

    [XmlElement("pesoB")]
    public string pesoBLXml
    {
        get => $"{pesoBField:#0.000}".Replace(',', '.');
        set
        {
            if (pesoBField is null || pesoBField.Equals(value) != true)
            {
                if (value != null)
                {
                    if (double.TryParse(value, out double noresult))
                    {
                        if (!value.Contains('.') & !value.Contains(','))
                            value += "00";
                        pesoBField = double.Parse(value) / 100d;
                    }
                    else
                    {
                        pesoBField = default;
                    }
                }
                else
                {
                    pesoBField = default;
                }

                OnPropertyChanged(nameof(pesoB));
            }
        }
    }

    public bool ShouldSerializepesoBLXml() => pesoBField.HasValue;


    [XmlElement("lacres")]
    public List<VolumeLacres> lacres
    {
        get => lacresField;
        set
        {
            if (lacresField is null || lacresField.Equals(value) != true)
            {
                lacresField = value;
                OnPropertyChanged(nameof(lacres));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class VolumeLacres : INotifyPropertyChanged
{
    private string nLacreField;

    public string nLacre
    {
        get => nLacreField;
        set
        {
            if (nLacreField is null || nLacreField.Equals(value) != true)
            {
                nLacreField = value;
                OnPropertyChanged(nameof(nLacre));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
