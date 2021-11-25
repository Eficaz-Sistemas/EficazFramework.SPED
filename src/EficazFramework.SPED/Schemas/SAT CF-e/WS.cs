using System;
using System.Diagnostics;
using System.Xml.Linq;

namespace EficazFramework.SPED.Schemas.SAT_CFe
{


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consAtiva : object, System.ComponentModel.INotifyPropertyChanged
    {
        private Ambiente tpAmbField;
        private string cUFField;
        private string cNPJField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public Ambiente tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string CNPJ
        {
            get
            {
                return cNPJField;
            }

            set
            {
                cNPJField = value;
                RaisePropertyChanged("CNPJ");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consAtualiza : object, System.ComponentModel.INotifyPropertyChanged
    {
        private Ambiente tpAmbField;
        private string verSoftField;
        private string cUFField;
        private string xServField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public Ambiente tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string verSoft
        {
            get
            {
                return verSoftField;
            }

            set
            {
                verSoftField = value;
                RaisePropertyChanged("verSoft");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string xServ
        {
            get
            {
                return xServField;
            }

            set
            {
                xServField = value;
                RaisePropertyChanged("xServ");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class configAss : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string tpAmbField;
        private string cUFField;
        private string cNPJvalueField;
        private string signACField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string CNPJvalue
        {
            get
            {
                return cNPJvalueField;
            }

            set
            {
                cNPJvalueField = value;
                RaisePropertyChanged("CNPJvalue");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string signAC
        {
            get
            {
                return signACField;
            }

            set
            {
                signACField = value;
                RaisePropertyChanged("signAC");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consStat : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string tpAmbField;
        private string cUFField;
        private string xServField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private consStatStatus statusField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string xServ
        {
            get
            {
                return xServField;
            }

            set
            {
                xServField = value;
                RaisePropertyChanged("xServ");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public consStatStatus status
        {
            get
            {
                return statusField;
            }

            set
            {
                statusField = value;
                RaisePropertyChanged("status");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class consStatStatus : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string tipoLanField;
        private string lanIPField;
        private string lanMACField;
        private string lanMASKField;
        private string lanGWField;
        private string lanDNS1Field;
        private string lanDNS2Field;
        private string statLanField;
        private string nBatField;
        private string mtTotalField;
        private string mtUsadaField;
        private string datahoraField;
        private string verSoftField;
        private string verLayField;
        private string ultimoCFeField;
        private string listaInicialField;
        private string listafinalField;
        private string dhTransmissaoField;
        private string dhComunicacaoField;
        private string cERT_EMISSAOField;
        private string cERT_VENCIMENTOField;
        private string eSTADO_OPERACAOField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string tipoLan
        {
            get
            {
                return tipoLanField;
            }

            set
            {
                tipoLanField = value;
                RaisePropertyChanged("tipoLan");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string lanIP
        {
            get
            {
                return lanIPField;
            }

            set
            {
                lanIPField = value;
                RaisePropertyChanged("lanIP");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string lanMAC
        {
            get
            {
                return lanMACField;
            }

            set
            {
                lanMACField = value;
                RaisePropertyChanged("lanMAC");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string lanMASK
        {
            get
            {
                return lanMASKField;
            }

            set
            {
                lanMASKField = value;
                RaisePropertyChanged("lanMASK");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string lanGW
        {
            get
            {
                return lanGWField;
            }

            set
            {
                lanGWField = value;
                RaisePropertyChanged("lanGW");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string lanDNS1
        {
            get
            {
                return lanDNS1Field;
            }

            set
            {
                lanDNS1Field = value;
                RaisePropertyChanged("lanDNS1");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public string lanDNS2
        {
            get
            {
                return lanDNS2Field;
            }

            set
            {
                lanDNS2Field = value;
                RaisePropertyChanged("lanDNS2");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 7)]
        public string statLan
        {
            get
            {
                return statLanField;
            }

            set
            {
                statLanField = value;
                RaisePropertyChanged("statLan");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 8)]
        public string nBat
        {
            get
            {
                return nBatField;
            }

            set
            {
                nBatField = value;
                RaisePropertyChanged("nBat");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 9)]
        public string mtTotal
        {
            get
            {
                return mtTotalField;
            }

            set
            {
                mtTotalField = value;
                RaisePropertyChanged("mtTotal");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 10)]
        public string mtUsada
        {
            get
            {
                return mtUsadaField;
            }

            set
            {
                mtUsadaField = value;
                RaisePropertyChanged("mtUsada");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 11)]
        public string datahora
        {
            get
            {
                return datahoraField;
            }

            set
            {
                datahoraField = value;
                RaisePropertyChanged("datahora");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 12)]
        public string verSoft
        {
            get
            {
                return verSoftField;
            }

            set
            {
                verSoftField = value;
                RaisePropertyChanged("verSoft");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 13)]
        public string verLay
        {
            get
            {
                return verLayField;
            }

            set
            {
                verLayField = value;
                RaisePropertyChanged("verLay");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 14)]
        public string ultimoCFe
        {
            get
            {
                return ultimoCFeField;
            }

            set
            {
                ultimoCFeField = value;
                RaisePropertyChanged("ultimoCFe");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 15)]
        public string listaInicial
        {
            get
            {
                return listaInicialField;
            }

            set
            {
                listaInicialField = value;
                RaisePropertyChanged("listaInicial");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 16)]
        public string listafinal
        {
            get
            {
                return listafinalField;
            }

            set
            {
                listafinalField = value;
                RaisePropertyChanged("listafinal");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 17)]
        public string dhTransmissao
        {
            get
            {
                return dhTransmissaoField;
            }

            set
            {
                dhTransmissaoField = value;
                RaisePropertyChanged("dhTransmissao");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 18)]
        public string dhComunicacao
        {
            get
            {
                return dhComunicacaoField;
            }

            set
            {
                dhComunicacaoField = value;
                RaisePropertyChanged("dhComunicacao");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 19)]
        public string CERT_EMISSAO
        {
            get
            {
                return cERT_EMISSAOField;
            }

            set
            {
                cERT_EMISSAOField = value;
                RaisePropertyChanged("CERT_EMISSAO");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 20)]
        public string CERT_VENCIMENTO
        {
            get
            {
                return cERT_VENCIMENTOField;
            }

            set
            {
                cERT_VENCIMENTOField = value;
                RaisePropertyChanged("CERT_VENCIMENTO");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 21)]
        public string ESTADO_OPERACAO
        {
            get
            {
                return eSTADO_OPERACAOField;
            }

            set
            {
                eSTADO_OPERACAOField = value;
                RaisePropertyChanged("ESTADO_OPERACAO");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class certifica : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string tpAmbField;
        private string cUFField;
        private string optField;
        private string itemField;
        private ItemChoiceType1 itemElementNameField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string opt
        {
            get
            {
                return optField;
            }

            set
            {
                optField = value;
                RaisePropertyChanged("opt");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("CRT", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlElement("CSR", typeof(string), Order = 3)]
        [System.Xml.Serialization.XmlChoiceIdentifier("ItemElementName")]
        public string Item
        {
            get
            {
                return itemField;
            }

            set
            {
                itemField = value;
                RaisePropertyChanged("Item");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        [System.Xml.Serialization.XmlIgnore()]
        public ItemChoiceType1 ItemElementName
        {
            get
            {
                return itemElementNameField;
            }

            set
            {
                itemElementNameField = value;
                RaisePropertyChanged("ItemElementName");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 7)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consCmd : object, System.ComponentModel.INotifyPropertyChanged
    {
        private Ambiente tpAmbField;
        private string cUFField;
        private string xServField;
        private consCmdComando comandoField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private decimal versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public Ambiente tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string xServ
        {
            get
            {
                return xServField;
            }

            set
            {
                xServField = value;
                RaisePropertyChanged("xServ");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public consCmdComando comando
        {
            get
            {
                return comandoField;
            }

            set
            {
                comandoField = value;
                RaisePropertyChanged("comando");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 6)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public decimal versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    public partial class consCmdComando : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string[] statusField;
        private string idCmdField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement("status", Order = 0)]
        public string[] status
        {
            get
            {
                return statusField;
            }

            set
            {
                statusField = value;
                RaisePropertyChanged("status");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string idCmd
        {
            get
            {
                return idCmdField;
            }

            set
            {
                idCmdField = value;
                RaisePropertyChanged("idCmd");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consGestao : object, System.ComponentModel.INotifyPropertyChanged
    {
        private Ambiente tpAmbField;
        private string cUFField;
        private consGestaoParametroGestao parametroGestaoField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public Ambiente tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public consGestaoParametroGestao parametroGestao
        {
            get
            {
                return parametroGestaoField;
            }

            set
            {
                parametroGestaoField = value;
                RaisePropertyChanged("parametroGestao");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string Versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("Versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class envLog : object, System.ComponentModel.INotifyPropertyChanged
    {
        private Ambiente tpAmbField;
        private string cUFField;
        private string logField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public Ambiente tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string log
        {
            get
            {
                return logField;
            }

            set
            {
                logField = value;
                RaisePropertyChanged("log");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 5)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [System.ComponentModel.DesignerCategory("code")]
    [System.Xml.Serialization.XmlType(AnonymousType = true)]
    [System.Xml.Serialization.XmlRoot(Namespace = "", IsNullable = false)]
    public partial class consParam : object, System.ComponentModel.INotifyPropertyChanged
    {
        private string tpAmbField;
        private string cUFField;
        private string nSegField;
        private string dhEnvioField;
        private string nserieSATField;
        private string versaoField;
        private XElement[] anyAttrField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 0)]
        public string tpAmb
        {
            get
            {
                return tpAmbField;
            }

            set
            {
                tpAmbField = value;
                RaisePropertyChanged("tpAmb");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 1)]
        public string cUF
        {
            get
            {
                return cUFField;
            }

            set
            {
                cUFField = value;
                RaisePropertyChanged("cUF");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 2)]
        public string nSeg
        {
            get
            {
                return nSegField;
            }

            set
            {
                nSegField = value;
                RaisePropertyChanged("nSeg");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 3)]
        public string dhEnvio
        {
            get
            {
                return dhEnvioField;
            }

            set
            {
                dhEnvioField = value;
                RaisePropertyChanged("dhEnvio");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElement(Order = 4)]
        public string nserieSAT
        {
            get
            {
                return nserieSATField;
            }

            set
            {
                nserieSATField = value;
                RaisePropertyChanged("nserieSAT");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttribute()]
        public string versao
        {
            get
            {
                return versaoField;
            }

            set
            {
                versaoField = value;
                RaisePropertyChanged("versao");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAnyAttribute()]
        public XElement[] AnyAttr
        {
            get
            {
                return anyAttrField;
            }

            set
            {
                anyAttrField = value;
                RaisePropertyChanged("AnyAttr");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
}