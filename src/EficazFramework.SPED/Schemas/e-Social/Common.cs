using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace EficazFrameworkCore.SPED.Schemas.eSocial
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public class eSocialTimeStampUtils
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

    public abstract class IeSocialEvt
    {
        private XmlSerializer sSerializer; // New System.Xml.Serialization.XmlSerializer(GetType(EnvioLoteEventos))

        public abstract XmlSerializer DefineSerializer();
        public abstract void GeraEventoID();
        public abstract object GetEventoID();
        public abstract string ContribuinteCNPJ();

        /// <summary>
        /// Serializes current TNfeProc object into an XML document
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
                sSerializer.Serialize(memoryStream, this);
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

        public virtual async Task SaveToAsync(System.IO.Stream target)
        {
            if (target is null)
                throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
            var streamWriter = new System.IO.StreamWriter(target);
            try
            {
                string xmlString = Serialize();
                await streamWriter.WriteLineAsync(xmlString);
                await streamWriter.FlushAsync();
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                }
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Identificação do Empregador, titular do Evento
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class TEmpregador : object, INotifyPropertyChanged
    {
        private PersonalidadeJuridica tpInscField;
        private string nrInscField;

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

        public string NumeroInscricaoTag()
        {
            string inscrFinal = nrInsc;
            if (inscrFinal.Length < 8)
                inscrFinal = Extensions.String.ToFixedLenghtString(inscrFinal, 8, Extensions.Alignment.Left, "0");
            if (tpInsc == PersonalidadeJuridica.CNPJ)
                inscrFinal = inscrFinal.Substring(0, 8);
            return Extensions.String.ToFixedLenghtString(inscrFinal, 14, Extensions.Alignment.Right, "0");
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
    /// Identificação do Evento, com Ambiente, Processo Emissor e Versão
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class TIdeCadastro : object, INotifyPropertyChanged
    {
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
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
    /// Identificação do Evento Períodico
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class TIdeEveFopagMensal : object, INotifyPropertyChanged
    {
        private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
        private string nrReciboField;
        private IndicadorApuracao indApuracaoField = IndicadorApuracao.Mensal;
        private string perApurField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
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
        [XmlElement(Order = 2)]
        public IndicadorApuracao indApuracao
        {
            get
            {
                return indApuracaoField;
            }

            set
            {
                indApuracaoField = value;
                RaisePropertyChanged("indApuracao");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
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
        [XmlElement(Order = 4)]
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
        [XmlElement(Order = 5)]
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
        [XmlElement(Order = 6)]
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
    /// Identificação do Evento Não Períodico
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TIdeEveTrab : object, INotifyPropertyChanged
    {
        private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
        private string nrReciboField;
        private Ambiente tpAmbField = Ambiente.Producao;
        private EmissorEvento procEmiField = EmissorEvento.AppEmpregador;
        private string verProcField;

        /// <remarks/>
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
    /// Informação do Período (inicial e final, formato AAAA-MM)
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    public partial class TIdePeriodo : object, INotifyPropertyChanged
    {
        private string iniValidField;
        private string fimValidField;

        /// <remarks/>
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

        /// <remarks/>
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
    /// Identificação do Transmissor
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType()]
    public partial class TIdeTransmissor : object, INotifyPropertyChanged
    {
        private PersonalidadeJuridica tpInscField;
        private string nrInscField;

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
    /// Resultado dos servidores do eSocial após Invoke do Envio de Lote de Eventos
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoEnvio/v1_1_0")]
    public partial class TStatusEnvio : object, INotifyPropertyChanged
    {
        private int cdRespostaField;
        private string descRespostaField;
        private List<TOcorrenciasOcorrencia> ocorrenciasField = new List<TOcorrenciasOcorrencia>();

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int cdResposta
        {
            get
            {
                return cdRespostaField;
            }

            set
            {
                cdRespostaField = value;
                RaisePropertyChanged("cdResposta");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string descResposta
        {
            get
            {
                return descRespostaField;
            }

            set
            {
                descRespostaField = value;
                RaisePropertyChanged("descResposta");
            }
        }

        /// <remarks/>
        [XmlArray("ocorrencias", Order = 2)]
        [XmlArrayItem("ocorrencia")]
        public List<TOcorrenciasOcorrencia> ocorrencias
        {
            get
            {
                return ocorrenciasField;
            }

            set
            {
                ocorrenciasField = value;
                RaisePropertyChanged("ocorrencias");
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
    /// Resultado dos servidores do eSocial após Invoke da Consulta de Lote de Eventos
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoProcessamento/v1_3_0")]
    public partial class TStatusConsulta : object, INotifyPropertyChanged
    {
        private int cdRespostaField;
        private string descRespostaField;
        private int tempoEstimadoConclusaoField;
        private bool tempoEstimadoConclusaoFieldSpecified;
        private List<TOcorrenciasOcorrencia> ocorrenciasField = new List<TOcorrenciasOcorrencia>();

        /// <remarks/>
        [XmlElement(Order = 0)]
        public int cdResposta
        {
            get
            {
                return cdRespostaField;
            }

            set
            {
                cdRespostaField = value;
                RaisePropertyChanged("cdResposta");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string descResposta
        {
            get
            {
                return descRespostaField;
            }

            set
            {
                descRespostaField = value;
                RaisePropertyChanged("descResposta");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public int tempoEstimadoConclusao
        {
            get
            {
                return tempoEstimadoConclusaoField;
            }

            set
            {
                tempoEstimadoConclusaoField = value;
                RaisePropertyChanged("tempoEstimadoConclusao");
            }
        }

        /// <remarks/>
        [XmlIgnore()]
        public bool tempoEstimadoConclusaoSpecified
        {
            get
            {
                return tempoEstimadoConclusaoFieldSpecified;
            }

            set
            {
                tempoEstimadoConclusaoFieldSpecified = value;
                RaisePropertyChanged("tempoEstimadoConclusaoSpecified");
            }
        }

        /// <remarks/>
        [XmlArray("ocorrencias", Order = 3)]
        [XmlArrayItem("ocorrencia")]
        public List<TOcorrenciasOcorrencia> ocorrencias
        {
            get
            {
                return ocorrenciasField;
            }

            set
            {
                ocorrenciasField = value;
                RaisePropertyChanged("ocorrencias");
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
    /// Detalhamento da ocorrência do Status
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public partial class TOcorrenciasOcorrencia : object, INotifyPropertyChanged
    {
        private int codigoField;
        private string descricaoField;
        private byte tipoField;
        private string localizacaoField;

        public int codigo
        {
            get
            {
                return codigoField;
            }

            set
            {
                codigoField = value;
                RaisePropertyChanged("codigo");
            }
        }

        public string descricao
        {
            get
            {
                return descricaoField;
            }

            set
            {
                descricaoField = value;
                RaisePropertyChanged("descricao");
            }
        }

        public byte tipo
        {
            get
            {
                return tipoField;
            }

            set
            {
                tipoField = value;
                RaisePropertyChanged("tipo");
            }
        }

        public string localizacao
        {
            get
            {
                return localizacaoField;
            }

            set
            {
                localizacaoField = value;
                RaisePropertyChanged("localizacao");
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
    /// Dados da recepção do serviço solicitado
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoEnvio/v1_1_0")]
    public partial class TDadosRecepcao : object, INotifyPropertyChanged
    {
        private DateTime dhRecepcaoField;
        private string versaoAplicativoRecepcaoField;
        private string protocoloEnvioField;

        /// <remarks/>
        [XmlElement(Order = 0)]
        public DateTime dhRecepcao
        {
            get
            {
                return dhRecepcaoField;
            }

            set
            {
                dhRecepcaoField = value;
                RaisePropertyChanged("dhRecepcao");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string versaoAplicativoRecepcao
        {
            get
            {
                return versaoAplicativoRecepcaoField;
            }

            set
            {
                versaoAplicativoRecepcaoField = value;
                RaisePropertyChanged("versaoAplicativoRecepcao");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string protocoloEnvio
        {
            get
            {
                return protocoloEnvioField;
            }

            set
            {
                protocoloEnvioField = value;
                RaisePropertyChanged("protocoloEnvio");
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
    /// Dados da recepção do serviço solicitado informado em RetornoEvento
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "")]
    public partial class TDadosRecepcaoRetornoEvento : object, INotifyPropertyChanged
    {
        private Ambiente tpAmbField = Ambiente.Producao;
        private DateTime dhRecepcaoField;
        private string versaoAplicativoRecepcaoField;
        private string protocoloEnvioField;

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
        public DateTime dhRecepcao
        {
            get
            {
                return dhRecepcaoField;
            }

            set
            {
                dhRecepcaoField = value;
                RaisePropertyChanged("dhRecepcao");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string versaoAppRecepcao
        {
            get
            {
                return versaoAplicativoRecepcaoField;
            }

            set
            {
                versaoAplicativoRecepcaoField = value;
                RaisePropertyChanged("versaoAppRecepcao");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public string protocoloEnvioLote
        {
            get
            {
                return protocoloEnvioField;
            }

            set
            {
                protocoloEnvioField = value;
                RaisePropertyChanged("protocoloEnvioLote");
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
    /// Dados do processamento informado em RetornoEvento
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "")]
    public partial class TProcessamentoRetornoEvento : object, INotifyPropertyChanged
    {
        private int cdRespostaField;
        private string descRespostaField;
        private string versaoAplicativoRecepcaoField;
        private DateTime dhRecepcaoField;
        private List<TOcorrenciasOcorrencia> ocorrenciasField = new List<TOcorrenciasOcorrencia>();


        /// <remarks/>
        [XmlElement(Order = 0)]
        public int cdResposta
        {
            get
            {
                return cdRespostaField;
            }

            set
            {
                cdRespostaField = value;
                RaisePropertyChanged("cdResposta");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 1)]
        public string descResposta
        {
            get
            {
                return descRespostaField;
            }

            set
            {
                descRespostaField = value;
                RaisePropertyChanged("descResposta");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 2)]
        public string versaoAppProcessamento
        {
            get
            {
                return versaoAplicativoRecepcaoField;
            }

            set
            {
                versaoAplicativoRecepcaoField = value;
                RaisePropertyChanged("versaoAppProcessamento");
            }
        }

        /// <remarks/>
        [XmlElement(Order = 3)]
        public DateTime dhProcessamento
        {
            get
            {
                return dhRecepcaoField;
            }

            set
            {
                dhRecepcaoField = value;
                RaisePropertyChanged("dhProcessamento");
            }
        }

        /// <remarks/>
        [XmlArray("ocorrencias", Order = 4)]
        [XmlArrayItem("ocorrencia")]
        public List<TOcorrenciasOcorrencia> ocorrencias
        {
            get
            {
                return ocorrenciasField;
            }

            set
            {
                ocorrenciasField = value;
                RaisePropertyChanged("ocorrencias");
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
    /// Endereço no Brasil
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCode("xsd", "4.6.1055.0")]
    [Serializable()]
    [DebuggerStepThrough()]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://www.esocial.gov.br/schema/evt/evtAdmissao/v02_05_00")]
    public partial class TEnderecoBrasil : object, INotifyPropertyChanged
    {
        private string tpLogradField;
        private string dscLogradField;
        private string nrLogradField;
        private string complementoField;
        private string bairroField;
        private string cepField;
        private string codMunicField;
        private UFCadastro ufField;

        /// <remarks/>
        public string tpLograd
        {
            get
            {
                return tpLogradField;
            }

            set
            {
                tpLogradField = value;
                RaisePropertyChanged("tpLograd");
            }
        }

        /// <remarks/>
        public string dscLograd
        {
            get
            {
                return dscLogradField;
            }

            set
            {
                dscLogradField = value;
                RaisePropertyChanged("dscLograd");
            }
        }

        /// <remarks/>
        public string nrLograd
        {
            get
            {
                return nrLogradField;
            }

            set
            {
                nrLogradField = value;
                RaisePropertyChanged("nrLograd");
            }
        }

        /// <remarks/>
        public string complemento
        {
            get
            {
                return complementoField;
            }

            set
            {
                complementoField = value;
                RaisePropertyChanged("complemento");
            }
        }

        /// <remarks/>
        public string bairro
        {
            get
            {
                return bairroField;
            }

            set
            {
                bairroField = value;
                RaisePropertyChanged("bairro");
            }
        }

        /// <remarks/>
        public string cep
        {
            get
            {
                return cepField;
            }

            set
            {
                cepField = value;
                RaisePropertyChanged("cep");
            }
        }

        /// <remarks/>
        [XmlElement(DataType = "integer")]
        public string codMunic
        {
            get
            {
                return codMunicField;
            }

            set
            {
                codMunicField = value;
                RaisePropertyChanged("codMunic");
            }
        }

        /// <remarks/>
        public UFCadastro uf
        {
            get
            {
                return ufField;
            }

            set
            {
                ufField = value;
                RaisePropertyChanged("uf");
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}