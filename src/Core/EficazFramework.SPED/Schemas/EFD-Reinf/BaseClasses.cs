using System.IO;

namespace EficazFramework.SPED.Schemas.EFD_Reinf
{

    #region IEfdReinfEvt Abstraction for API Usage

    public static class ReinfTimeStampUtils
    {
        public static Dictionary<string, int> TimestampDict { get; private set; } = new Dictionary<string, int>();

        public static string GetTimeStampIDForEvent()
        {
            int ID = 1;
            string timeString = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
            if (TimestampDict.ContainsKey(timeString))
            {
                ID = TimestampDict[timeString] + 1;
                TimestampDict[timeString] = ID;
            }
            else
            {
                TimestampDict.Add(timeString, 1);
            }

            return string.Format("{0}{1:00000}", timeString, ID);
        }
    }

    public abstract class IEfdReinfEvt : IXmlSignableDocument
    {
        [XmlIgnore]
        public Versao Versao { get; set; } = Versao.v2_01_01;

        // Base Members
        private XmlSerializer sSerializer;

        /// <summary>
        /// Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando <see cref="IEfdReinfEvt"/>
        /// </summary>
        public abstract XmlSerializer DefineSerializer();

        /// <summary>
        /// Gera uma ID única para o Evento a ser enviado para o portal do SPED.
        /// Cada tipo de evento da EFD-Reinf possui sua forma de geração.
        /// </summary>
        public abstract void GeraEventoID();

        /// <summary>
        /// Retorna o CNPJ do Contribuinte titular do evento.
        /// </summary>
        /// <returns></returns>
        public abstract string ContribuinteCNPJ();



        // IXmlSignableDocument Members

        /// <summary>
        /// Especifica qual Tag do XML do evento deve ser assinada por Certificado Digital
        /// </summary>
        public abstract string TagToSign { get; }

        /// <summary>
        /// Retorna a ID do evento, criada pelo método <see cref="GeraEventoID"/>
        /// </summary>
        public abstract string TagId { get; }

        /// <summary>
        /// Informa se a Uri de referência da Tag assinada deve ser vazia, ou se deve ser formada conforme especificações do Manual Técnico.
        /// </summary>
        public abstract bool EmptyURI { get; }

        /// <summary>
        /// Informa se o XML deve ser assinado utilizando criptografia SHA256.
        /// </summary>
        public abstract bool SignAsSHA256 { get; }



        // Implemented Members

        /// <summary>
        /// Substitui o método ToString() de object para retornar o resultado do método <see cref="Serialize"/>
        /// </summary>
        /// <returns></returns>
        public override string ToString() =>
            Serialize();

        /// <summary>
        /// Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML.
        /// </summary>
        /// <returns>string XML value</returns>
        public string Serialize()
        {
            System.IO.StreamReader streamReader = null;
            System.IO.MemoryStream memoryStream = null;
            try
            {
                memoryStream = new System.IO.MemoryStream();
                sSerializer = DefineSerializer();
                using (var xmlwriter = XmlWriter.Create(memoryStream, new XmlWriterSettings()
                {
                    Indent = true,
                   
                }))
                {
                    sSerializer.Serialize(xmlwriter, this);
                }
                memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
                streamReader = new System.IO.StreamReader(memoryStream);
                return streamReader.ReadToEnd();
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }

                if (memoryStream != null)
                {
                    memoryStream.Dispose();
                }
            }
        }

        /// <summary>
        /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
        /// </summary>
        /// <returns></returns>
        public IEfdReinfEvt Deserialize(string xmlContent)
        {
            sSerializer = DefineSerializer();
            return Deserialize(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlContent))) as IEfdReinfEvt;
        }

        /// <summary>
        /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
        /// </summary>
        /// <returns></returns>
        public IEfdReinfEvt Deserialize(System.IO.Stream xmlStream)
        {
            sSerializer = DefineSerializer();
            var result = sSerializer.Deserialize(xmlStream);
            return result as IEfdReinfEvt;
        }

    }

    #endregion

    #region Generic

    /// <summary>
    /// Identificação de Período (iniValid e fimValid)
    /// </summary>
    public partial class ReinfEvtIdePeriodo : object, INotifyPropertyChanged
    {
        // , [Namespace]:="http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/v1_05_01"
        private string iniValidField;
        private string fimValidField;

        /// <summary>
        /// AAAA-MM
        /// </summary>
        [XmlElement(Order = 0)]
        public string iniValid
        {
            get
            {
                return iniValidField;
            }

            set
            {
                iniValidField = value;
                RaisePropertyChanged("iniValid");
            }
        }

        /// <summary>
        /// AAAA-MM
        /// </summary>
        [XmlElement(Order = 1)]
        public string fimValid
        {
            get
            {
                return fimValidField;
            }

            set
            {
                fimValidField = value;
                RaisePropertyChanged("fimValid");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// Identificação do evento (Ambiente, Emissor e Versao)
    /// </summary>
    public partial class ReinfEvtIdeEvento : object, INotifyPropertyChanged
    {
        // , [Namespace]:="http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/v1_05_01"
        private Ambiente tpAmbField;
        private EmissorEvento procEmiField;
        private string verProcField;

        /// <remarks/>
        [XmlElement(Order = 0)]
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
        [XmlElement(Order = 1)]
        public EmissorEvento procEmi
        {
            get
            {
                return procEmiField;
            }

            set
            {
                procEmiField = value;
                RaisePropertyChanged("procEmi");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string verProc
        {
            get
            {
                return verProcField;
            }

            set
            {
                verProcField = value;
                RaisePropertyChanged("verProc");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// Identificação do contribuinte
    /// </summary>
    public partial class ReinfEvtIdeContri : object, INotifyPropertyChanged
    {
        private PersonalidadeJuridica tpInscField;
        private string nrInscField;
        private ReinfEvtRetIdeContriInfoComplContri infoComplContriField = null;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public PersonalidadeJuridica tpInsc
        {
            get
            {
                return tpInscField;
            }

            set
            {
                tpInscField = value;
                RaisePropertyChanged("tpInsc");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string nrInsc
        {
            get
            {
                return nrInscField;
            }

            set
            {
                nrInscField = value;
                RaisePropertyChanged("nrInsc");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public ReinfEvtRetIdeContriInfoComplContri infoComplContri
        {
            get
            {
                return infoComplContriField;
            }

            set
            {
                infoComplContriField = value;
                RaisePropertyChanged("infoComplContri");
            }
        }

        public string NumeroInscricaoTag()
        {
            return Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    public partial class ReinfEvtRetIdeContriInfoComplContri : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string natJurField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
        public string natJur
        {
            get
            {
                return this.natJurField;
            }
            set
            {
                this.natJurField = value;
                this.RaisePropertyChanged("natJur");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// Tabela 6 do Anexo IV: Relação de Serviços para registros R-2010 e R-2020s
    /// </summary>
    public class R2xxx_TabelaServicos : Dictionary<string, string>
    {
        public R2xxx_TabelaServicos()
        {
            Add("--", "Não Aplicável");
            Add("100000001", "100000001 - Limpeza, conservação ou zeladoria");
            Add("100000002", "100000002 - Vigilância ou segurança");
            Add("100000003", "100000003 - Construção civil");
            Add("100000004", "100000004 - Serviços de natureza rural");
            Add("100000005", "100000005 - Digitação");
            Add("100000006", "100000006 - Preparação de dados para processamento");
            Add("100000007", "100000007 - Acabamento");
            Add("100000008", "100000008 - Embalagem");
            Add("100000009", "100000009 - Acondicionamento");
            Add("100000010", "100000010 - Cobrança");
            Add("100000011", "100000011 - Coleta ou reciclagem de lixo ou de resíduos");
            Add("100000012", "100000012 - Copa");
            Add("100000013", "100000013 - Hotelaria");
            Add("100000014", "100000014 - Corte ou ligação de serviços públicos");
            Add("100000015", "100000015 - Distribuição");
            Add("100000016", "100000016 - Treinamento e ensino");
            Add("100000017", "100000017 - Entrega de contas e de documentos");
            Add("100000018", "100000018 - Ligação de medidores");
            Add("100000019", "100000019 - Leitura de medidores");
            Add("100000020", "100000020 - Manutenção de instalações, de máquinas ou de equipamentos");
            Add("100000021", "100000021 - Montagem");
            Add("100000022", "100000022 - Operação de máquinas, de equipamentos e de veículos");
            Add("100000023", "100000023 - Operação de pedágio ou de terminal de transporte");
            Add("100000024", "100000024 - Operação de transporte de passageiros");
            Add("100000025", "100000025 - Portaria, recepção ou ascensorista");
            Add("100000026", "100000026 - Recepção, triagem ou movimentação de materiais");
            Add("100000027", "100000027 - Promoção de vendas ou de eventos");
            Add("100000028", "100000028 - Secretaria e expediente");
            Add("100000029", "100000029 - Saúde");
            Add("100000030", "100000030 - Telefonia ou telemarketing");
            Add("100000031", "100000031 - Trabalho temporário na forma da Lei nº 6.019, de janeiro de 1974");
        }
    }

    /// <summary>
    /// Identificação do Evento (Indicador de Retificação, Número Recibo Retif., Período Apuração, Ambiente, Emissor e Versão) (R-2010, R-2020, R-2040 e R-2060)
    /// </summary>
    public partial class ReinfEvtIdeEvento_R20xx : object, INotifyPropertyChanged
    {
        private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
        private string nrReciboField;
        private string perApurField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
        private string verProcField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public IndicadorRetificacao indRetif
        {
            get
            {
                return indRetifField;
            }

            set
            {
                indRetifField = value;
                RaisePropertyChanged("indRetif");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string nrRecibo
        {
            get
            {
                return nrReciboField;
            }

            set
            {
                nrReciboField = value;
                RaisePropertyChanged("nrRecibo");
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "gYearMonth", Order = 2)]
        public string perApur
        {
            get
            {
                return perApurField;
            }

            set
            {
                perApurField = value;
                RaisePropertyChanged("perApur");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
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
        [XmlElement(Order = 4)]
        public EmissorEvento procEmi
        {
            get
            {
                return procEmiField;
            }

            set
            {
                procEmiField = value;
                RaisePropertyChanged("procEmi");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 5)]
        public string verProc
        {
            get
            {
                return verProcField;
            }

            set
            {
                verProcField = value;
                RaisePropertyChanged("verProc");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <summary>
    /// Identificação do Evento (Período Apuracao, Ambiente, Emissor e Versao)
    /// </summary>
    public partial class ReinfEvtIdeEventoPeriodicoFechamento : object, INotifyPropertyChanged
    {
        private string perApurField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
        private string verProcField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string perApur
        {
            get
            {
                return perApurField;
            }

            set
            {
                perApurField = value;
                RaisePropertyChanged("perApur");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
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
        [XmlElement(Order = 2)]
        public EmissorEvento procEmi
        {
            get
            {
                return procEmiField;
            }

            set
            {
                procEmiField = value;
                RaisePropertyChanged("procEmi");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string verProc
        {
            get
            {
                return verProcField;
            }

            set
            {
                verProcField = value;
                RaisePropertyChanged("verProc");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    public partial class ReinfEvtFechaEvPerIdeRespInf : object, INotifyPropertyChanged
    {
        private string nmRespField;
        private string cpfRespField;
        private string telefoneField;
        private string emailField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public string nmResp
        {
            get
            {
                return nmRespField;
            }

            set
            {
                nmRespField = value;
                RaisePropertyChanged("nmResp");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string cpfResp
        {
            get
            {
                return cpfRespField;
            }

            set
            {
                cpfRespField = value;
                RaisePropertyChanged("cpfResp");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string telefone
        {
            get
            {
                return telefoneField;
            }

            set
            {
                telefoneField = value;
                RaisePropertyChanged("telefone");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string email
        {
            get
            {
                return emailField;
            }

            set
            {
                emailField = value;
                RaisePropertyChanged("email");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged != null)
            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }


    #endregion

    #region #xmlsign

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureType : INotifyPropertyChanged
    {
        private SignedInfoType signedInfoField;
        private SignatureValueType signatureValueField;
        private KeyInfoType keyInfoField;
        private string idField;

        public SignatureType() : base()
        {
            keyInfoField = new KeyInfoType();
            signatureValueField = new SignatureValueType();
            signedInfoField = new SignedInfoType();
        }

        public SignedInfoType SignedInfo
        {
            get
            {
                return signedInfoField;
            }

            set
            {
                if (signedInfoField is null || signedInfoField.Equals(value) != true)
                {
                    signedInfoField = value;
                    OnPropertyChanged("SignedInfo");
                }
            }
        }

        public SignatureValueType SignatureValue
        {
            get
            {
                return signatureValueField;
            }

            set
            {
                if (signatureValueField is null || signatureValueField.Equals(value) != true)
                {
                    signatureValueField = value;
                    OnPropertyChanged("SignatureValue");
                }
            }
        }

        public KeyInfoType KeyInfo
        {
            get
            {
                return keyInfoField;
            }

            set
            {
                if (keyInfoField is null || keyInfoField.Equals(value) != true)
                {
                    keyInfoField = value;
                    OnPropertyChanged("KeyInfo");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoType : INotifyPropertyChanged
    {
        private SignedInfoTypeCanonicalizationMethod canonicalizationMethodField;
        private SignedInfoTypeSignatureMethod signatureMethodField;
        private ReferenceType referenceField;
        private string idField;

        public SignedInfoType() : base()
        {
            referenceField = new ReferenceType();
            signatureMethodField = new SignedInfoTypeSignatureMethod();
            canonicalizationMethodField = new SignedInfoTypeCanonicalizationMethod();
        }

        public SignedInfoTypeCanonicalizationMethod CanonicalizationMethod
        {
            get
            {
                return canonicalizationMethodField;
            }

            set
            {
                if (canonicalizationMethodField is null || canonicalizationMethodField.Equals(value) != true)
                {
                    canonicalizationMethodField = value;
                    OnPropertyChanged("CanonicalizationMethod");
                }
            }
        }

        public SignedInfoTypeSignatureMethod SignatureMethod
        {
            get
            {
                return signatureMethodField;
            }

            set
            {
                if (signatureMethodField is null || signatureMethodField.Equals(value) != true)
                {
                    signatureMethodField = value;
                    OnPropertyChanged("SignatureMethod");
                }
            }
        }

        public ReferenceType Reference
        {
            get
            {
                return referenceField;
            }

            set
            {
                if (referenceField is null || referenceField.Equals(value) != true)
                {
                    referenceField = value;
                    OnPropertyChanged("Reference");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoTypeCanonicalizationMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public SignedInfoTypeCanonicalizationMethod() : base()
        {
            algorithmField = "http://www.w3.org/TR/2001/REC-xml-c14n-20010315";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignedInfoTypeSignatureMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public SignedInfoTypeSignatureMethod() : base()
        {
            algorithmField = "http://www.w3.org/2000/09/xmldsig#rsa-sha1";
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ReferenceType : INotifyPropertyChanged
    {
        private List<TransformType> transformsField;
        private ReferenceTypeDigestMethod digestMethodField;
        private byte[] digestValueField;
        private string idField;
        private string uRIField;
        private string typeField;

        public ReferenceType() : base()
        {
            digestMethodField = new ReferenceTypeDigestMethod();
            transformsField = new List<TransformType>();
        }

        [XmlArrayItem("Transform", IsNullable = false)]
        public List<TransformType> Transforms
        {
            get
            {
                return transformsField;
            }

            set
            {
                if (transformsField is null || transformsField.Equals(value) != true)
                {
                    transformsField = value;
                    OnPropertyChanged("Transforms");
                }
            }
        }

        public ReferenceTypeDigestMethod DigestMethod
        {
            get
            {
                return digestMethodField;
            }

            set
            {
                if (digestMethodField is null || digestMethodField.Equals(value) != true)
                {
                    digestMethodField = value;
                    OnPropertyChanged("DigestMethod");
                }
            }
        }

        [XmlElement(DataType = "base64Binary")]
        public byte[] DigestValue
        {
            get
            {
                return digestValueField;
            }

            set
            {
                if (digestValueField is null || digestValueField.Equals(value) != true)
                {
                    digestValueField = value;
                    OnPropertyChanged("DigestValue");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        public string URI
        {
            get
            {
                return uRIField;
            }

            set
            {
                if (uRIField is null || uRIField.Equals(value) != true)
                {
                    uRIField = value;
                    OnPropertyChanged("URI");
                }
            }
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Type
        {
            get
            {
                return typeField;
            }

            set
            {
                if (typeField is null || typeField.Equals(value) != true)
                {
                    typeField = value;
                    OnPropertyChanged("Type");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class TransformType : INotifyPropertyChanged
    {
        private List<string> xPathField;
        private TTransformURI algorithmField;

        public TransformType() : base()
        {
            xPathField = new List<string>();
        }

        [XmlElement("XPath")]
        public List<string> XPath
        {
            get
            {
                return xPathField;
            }

            set
            {
                if (xPathField is null || xPathField.Equals(value) != true)
                {
                    xPathField = value;
                    OnPropertyChanged("XPath");
                }
            }
        }

        [XmlAttribute()]
        public TTransformURI Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public enum TTransformURI
    {

        /// <remarks/>
        [XmlEnum("http://www.w3.org/2000/09/xmldsig#enveloped-signature")]
        httpwwww3org200009xmldsigenvelopedsignature,

        /// <remarks/>
        [XmlEnum("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")]
        httpwwww3orgTR2001RECxmlc14n20010315
    }

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class ReferenceTypeDigestMethod : INotifyPropertyChanged
    {
        private string algorithmField;

        public ReferenceTypeDigestMethod() : base()
        {
            algorithmField = "http://www.w3.org/2001/04/xmlenc#sha256"; // "http://www.w3.org/2000/09/xmldsig#sha1"
        }

        [XmlAttribute(DataType = "anyURI")]
        public string Algorithm
        {
            get
            {
                return algorithmField;
            }

            set
            {
                if (algorithmField is null || algorithmField.Equals(value) != true)
                {
                    algorithmField = value;
                    OnPropertyChanged("Algorithm");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class SignatureValueType : INotifyPropertyChanged
    {
        private string idField;
        private byte[] valueField;

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
                }
            }
        }

        [XmlText(DataType = "base64Binary")]
        public byte[] Value
        {
            get
            {
                return valueField;
            }

            set
            {
                if (valueField is null || valueField.Equals(value) != true)
                {
                    valueField = value;
                    OnPropertyChanged("Value");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class KeyInfoType : INotifyPropertyChanged
    {
        private X509DataType x509DataField;
        private string idField;

        public KeyInfoType() : base()
        {
            x509DataField = new X509DataType();
        }

        public X509DataType X509Data
        {
            get
            {
                return x509DataField;
            }

            set
            {
                if (x509DataField is null || x509DataField.Equals(value) != true)
                {
                    x509DataField = value;
                    OnPropertyChanged("X509Data");
                }
            }
        }

        [XmlAttribute(DataType = "ID")]
        public string Id
        {
            get
            {
                return idField;
            }

            set
            {
                if (idField is null || idField.Equals(value) != true)
                {
                    idField = value;
                    OnPropertyChanged("Id");
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

    [System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18033")]
    [Serializable()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public partial class X509DataType : INotifyPropertyChanged
    {
        private byte[] x509CertificateField;

        [XmlElement(DataType = "base64Binary")]
        public byte[] X509Certificate
        {
            get
            {
                return x509CertificateField;
            }

            set
            {
                if (x509CertificateField is null || x509CertificateField.Equals(value) != true)
                {
                    x509CertificateField = value;
                    OnPropertyChanged("X509Certificate");
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

    #endregion
}