using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;
using EficazFrameworkCore.Extensions;

namespace EficazFrameworkCore.SPED.Schemas.NFe
{
    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class InformacoesTransporte : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public InformacoesTransporte() : base()
        {
            volField = new List<VolumeTransportado>();
            // Me.itemsElementNameField = New List(Of FormaTransporte)()
            // Me.itemsField = New List(Of Object)()
            retTranspField = new TransporteRetencaoICMS();
            transportaField = new Transportadora();
            _reboques = new List<Veiculo>();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("modFrete")]
        public ModalidadeFrete Modalidade
        {
            get
            {
                return modFreteField;
            }

            set
            {
                if (modFreteField.Equals(value) != true)
                {
                    modFreteField = value;
                    OnPropertyChanged("Modalidade");
                }
            }
        }

        [XmlElement("transporta")]
        public Transportadora Transportadora
        {
            get
            {
                return transportaField;
            }

            set
            {
                if (transportaField is null || transportaField.Equals(value) != true)
                {
                    transportaField = value;
                    OnPropertyChanged("Transportadora");
                }
            }
        }

        [XmlElement("retTransp")]
        public TransporteRetencaoICMS RetancaoICMS
        {
            get
            {
                return retTranspField;
            }

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
            get
            {
                return _veicField;
            }

            set
            {
                _veicField = value;
                if (transportaField is null || transportaField.Equals(value) != true)
                {
                    _veicField = value;
                    OnPropertyChanged("Veiculo");
                }
            }
        }

        [XmlElement("reboque", IsNullable = false)]
        public List<Veiculo> Reboques
        {
            get
            {
                return _reboques;
            }

            set
            {
                if (_reboques is null || _reboques.Equals(value) != true)
                {
                    _reboques = value;
                    OnPropertyChanged("Reboques");
                }
            }
        }

        [XmlElement("vagao", IsNullable = false)]
        public string Vagao
        {
            get
            {
                return _vagao;
            }

            set
            {
                if (_balsa is null || _vagao.Equals(value) != true)
                {
                    _vagao = value;
                    OnPropertyChanged("Vagao");
                }
            }
        }

        [XmlElement("balsa", IsNullable = false)]
        public string Balsa
        {
            get
            {
                return _balsa;
            }

            set
            {
                if (_balsa is null || _balsa.Equals(value) != true)
                {
                    _balsa = value;
                    OnPropertyChanged("Balsa");
                }
            }
        }

        [XmlElement("vol")]
        public List<VolumeTransportado> Volumes
        {
            get
            {
                return volField;
            }

            set
            {
                if (volField is null || volField.Equals(value) != true)
                {
                    volField = value;
                    OnPropertyChanged("Volume");
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

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Transportadora : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string itemField;
        private PersonalidadeJuridica itemElementNameField;
        private string xNomeField;
        private string ieField;
        private string xEnderField;
        private string xMunField;
        private Estado ufField;
        private bool ufFieldSpecified;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("CNPJ", typeof(string))]
        [XmlElement("CPF", typeof(string))]
        [XmlChoiceIdentifier("TransportadoraPersonalidadeJuridica")]
        public string CNPJ_CPF
        {
            get
            {
                return itemField;
            }

            set
            {
                if (itemField is null || itemField.Equals(value) != true)
                {
                    itemField = value;
                    OnPropertyChanged("CNPJ_CPF");
                }
            }
        }

        [XmlIgnore()]
        public string CNPJ_CPFFormatado
        {
            get
            {
                if (CNPJ_CPF != null)
                {
                    return CNPJ_CPF.FormatRFBDocument();
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlIgnore()]
        public PersonalidadeJuridica TransportadoraPersonalidadeJuridica
        {
            get
            {
                return itemElementNameField;
            }

            set
            {
                if (itemElementNameField.Equals(value) != true)
                {
                    itemElementNameField = value;
                    OnPropertyChanged("TransportadoraPersonalidadeJuridica");
                }
            }
        }

        [XmlElement("xNome")]
        public string RazaoSocial
        {
            get
            {
                return xNomeField;
            }

            set
            {
                if (xNomeField is null || xNomeField.Equals(value) != true)
                {
                    xNomeField = value;
                    OnPropertyChanged("RazaoSocial");
                }
            }
        }

        [XmlElement("IE")]
        public string InscricaoEstadual
        {
            get
            {
                return ieField;
            }

            set
            {
                if (ieField is null || ieField.Equals(value) != true)
                {
                    ieField = value;
                    OnPropertyChanged("InscricaoEstadual");
                }
            }
        }

        [XmlElement("xEnder")]
        public string Endereco
        {
            get
            {
                return xEnderField;
            }

            set
            {
                if (xEnderField is null || xEnderField.Equals(value) != true)
                {
                    xEnderField = value;
                    OnPropertyChanged("Endereco");
                }
            }
        }

        [XmlElement("xMun")]
        public string Municipio
        {
            get
            {
                return xMunField;
            }

            set
            {
                if (xMunField is null || xMunField.Equals(value) != true)
                {
                    xMunField = value;
                    OnPropertyChanged("Municipio");
                }
            }
        }

        public Estado UF
        {
            get
            {
                return ufField;
            }

            set
            {
                if (ufField.Equals(value) != true)
                {
                    ufField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        [XmlIgnore()]
        public string IEFormatado
        {
            get
            {
                if (InscricaoEstadual != null)
                {
                    return InscricaoEstadual.FormatIE(UF.ToString());
                }
                else
                {
                    return null;
                }
            }
        }

        [XmlIgnore()]
        public bool UFSpecified
        {
            get
            {
                return ufFieldSpecified;
            }

            set
            {
                if (ufFieldSpecified.Equals(value) != true)
                {
                    ufFieldSpecified = value;
                    OnPropertyChanged("UFSpecified");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class Veiculo : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private string placaField;
        private Estado ufField;
        private string rNTCField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("placa")]
        public string Placa
        {
            get
            {
                return placaField;
            }

            set
            {
                if (placaField is null || placaField.Equals(value) != true)
                {
                    placaField = value;
                    OnPropertyChanged("Placa");
                }
            }
        }

        [XmlElement("UF")]
        public Estado UF
        {
            get
            {
                return ufField;
            }

            set
            {
                if (ufField.Equals(value) != true)
                {
                    ufField = value;
                    OnPropertyChanged("UF");
                }
            }
        }

        [XmlElement("RNTC")]
        public string RNTC
        {
            get
            {
                return rNTCField;
            }

            set
            {
                if (rNTCField is null || rNTCField.Equals(value) != true)
                {
                    rNTCField = value;
                    OnPropertyChanged("RNTC");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class TransporteRetencaoICMS : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? vServField;
        private double? vBCRetField;
        private double? pICMSRetField;
        private double? vICMSRetField;
        private string cFOPField;
        private string cMunFGField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        [XmlElement("vServ")]
        public double? ValorServico
        {
            get
            {
                return vServField;
            }

            set
            {
                if (vServField is null || vServField.Equals(value) != true)
                {
                    vServField = value;
                    OnPropertyChanged("ValorServico");
                }
            }
        }

        [XmlElement("vBCRet")]
        public double? BaseDeCalculo
        {
            get
            {
                return vBCRetField;
            }

            set
            {
                if (vBCRetField is null || vBCRetField.Equals(value) != true)
                {
                    vBCRetField = value;
                    OnPropertyChanged("BaseDeCalculo");
                }
            }
        }

        [XmlElement("pICMSRet")]
        public double? Aliquota
        {
            get
            {
                return pICMSRetField;
            }

            set
            {
                if (pICMSRetField is null || pICMSRetField.Equals(value) != true)
                {
                    pICMSRetField = value;
                    OnPropertyChanged("Aliquota");
                }
            }
        }

        [XmlElement("vICMSRet")]
        public double? ValorICMS
        {
            get
            {
                return vICMSRetField;
            }

            set
            {
                if (vICMSRetField is null || vICMSRetField.Equals(value) != true)
                {
                    vICMSRetField = value;
                    OnPropertyChanged("ValorICMS");
                }
            }
        }

        public string CFOP
        {
            get
            {
                return cFOPField;
            }

            set
            {
                if (cFOPField is null || cFOPField.Equals(value) != true)
                {
                    cFOPField = value;
                    OnPropertyChanged("CFOP");
                }
            }
        }

        [XmlElement("cMunFG")]
        public string CodigoMunicipioFatoGerador
        {
            get
            {
                return cMunFGField;
            }

            set
            {
                if (cMunFGField is null || cMunFGField.Equals(value) != true)
                {
                    cMunFGField = value;
                    OnPropertyChanged("CodigoMunicipioFatoGerador");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class VolumeTransportado : INotifyPropertyChanged
    {

        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public VolumeTransportado() : base()
        {
            lacresField = new List<VolumeLacres>();
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        private double? qVolField;
        private string espField;
        private string marcaField;
        private string nVolField;
        private double? pesoLField;
        private double? pesoBField;
        private List<VolumeLacres> lacresField;


        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public double? qVol
        {
            get
            {
                return qVolField;
            }

            set
            {
                if (qVolField is null || qVolField.Equals(value) != true)
                {
                    qVolField = value;
                    OnPropertyChanged("qVol");
                }
            }
        }

        public string esp
        {
            get
            {
                return espField;
            }

            set
            {
                if (espField is null || espField.Equals(value) != true)
                {
                    espField = value;
                    OnPropertyChanged("esp");
                }
            }
        }

        public string marca
        {
            get
            {
                return marcaField;
            }

            set
            {
                if (marcaField is null || marcaField.Equals(value) != true)
                {
                    marcaField = value;
                    OnPropertyChanged("marca");
                }
            }
        }

        public string nVol
        {
            get
            {
                return nVolField;
            }

            set
            {
                if (nVolField is null || nVolField.Equals(value) != true)
                {
                    nVolField = value;
                    OnPropertyChanged("nVol");
                }
            }
        }

        public double? pesoL
        {
            get
            {
                return pesoLField;
            }

            set
            {
                if (pesoLField is null || pesoLField.Equals(value) != true)
                {
                    pesoLField = value;
                    OnPropertyChanged("pesoL");
                }
            }
        }

        public double? pesoB
        {
            get
            {
                return pesoBField;
            }

            set
            {
                if (pesoBField is null || pesoBField.Equals(value) != true)
                {
                    pesoBField = value;
                    OnPropertyChanged("pesoB");
                }
            }
        }

        [XmlElement("lacres")]
        public List<VolumeLacres> lacres
        {
            get
            {
                return lacresField;
            }

            set
            {
                if (lacresField is null || lacresField.Equals(value) != true)
                {
                    lacresField = value;
                    OnPropertyChanged("lacres");
                }
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public event PropertyChangedEventHandler PropertyChanged;

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
        /* TODO ERROR: Skipped RegionDirectiveTrivia */
        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public partial class VolumeLacres : INotifyPropertyChanged
    {
        private string nLacreField;

        public string nLacre
        {
            get
            {
                return nLacreField;
            }

            set
            {
                if (nLacreField is null || nLacreField.Equals(value) != true)
                {
                    nLacreField = value;
                    OnPropertyChanged("nLacre");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}