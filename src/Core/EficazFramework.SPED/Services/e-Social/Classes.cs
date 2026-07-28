using System.IO;

namespace EficazFramework.SPED.Services.eSocial;

/// <summary>
/// Classe base utilizada nas requests dos serviços REST (assíncronos) do e-Social
/// </summary>
[Serializable()]
public partial class Request : Schemas.eSocial.ESocialBindableObject
{
    [XmlIgnore]
    public VersaoRest Versao { get; set; } = VersaoRest.v1_1_1;

    private EnvioLoteEventos envioLoteEventosField;
    
    [XmlElement(Order = 0)]
    public EnvioLoteEventos envioLoteEventos
    {
        get => envioLoteEventosField;
        set
        {
            envioLoteEventosField = value;
            RaisePropertyChanged(nameof(envioLoteEventos));
        }
    }

    private XmlSerializer sSerializer;

    // Serialization Members
    private XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(Request), new XmlRootAttribute("eSocial")
        {
            Namespace = $"http://www.esocial.gov.br/schema/lote/eventos/envio/{Versao}",
            IsNullable = false
        });
    }


    /// <summary>
    /// Escreve o conteúdo da instância no formato XML
    /// </summary>
    public string Write()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer = DefineSerializer();
            using (var xmlwriter = System.Xml.XmlWriter.Create(memoryStream, new XmlWriterSettings() { Indent = true }))
            {
                sSerializer.Serialize(xmlwriter, this);
            }
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }


    /// <summary>
    /// Retorna a instância de <see cref="Request"/> desserializada do conteúdo XML
    /// </summary>
    public Request Read(string xmlContent)
    {
        sSerializer = DefineSerializer();
        return Read(new MemoryStream(Encoding.UTF8.GetBytes(xmlContent))) as Request;
    }

    /// <summary>
    /// Retorna a instância de <see cref="Request"/> desserializada do conteúdo XML
    /// </summary>
    public Request Read(Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as Request;
    }
}


/// <exclude />
public partial class EnvioLoteEventos : Schemas.eSocial.ESocialBindableObject
{
    private Schemas.eSocial.Empregador ideEmpregadorField;
    private Schemas.eSocial.IdeTransmissor ideTransmissorField;
    private List<TArquivoEsocial> eventosField;
    private int grupoField;

    [XmlElement(Order = 0)]
    public Schemas.eSocial.Empregador ideEmpregador
    {
        get => ideEmpregadorField;
        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged(nameof(ideEmpregador));
        }
    }

    [XmlElement(Order = 1)]
    public Schemas.eSocial.IdeTransmissor ideTransmissor
    {
        get => ideTransmissorField;
        set
        {
            ideTransmissorField = value;
            RaisePropertyChanged(nameof(ideTransmissor));
        }
    }

    [XmlArray(Order = 2)]
    [XmlArrayItem("evento", IsNullable = false)]
    public List<TArquivoEsocial> eventos
    {
        get => eventosField;
        set
        {
            eventosField = value;
            RaisePropertyChanged(nameof(eventos));
        }
    }

    [XmlAttribute()]
    public int grupo
    {
        get => grupoField;
        set
        {
            grupoField = value;
            RaisePropertyChanged(nameof(grupo));
        }
    }
}



/// <exclude />
[Serializable()]
public partial class TArquivoEsocial : Schemas.eSocial.ESocialBindableObject
{
    private XElement anyField;
    private string idField;

    [XmlAnyElement(Order = 0)]
    public XElement Any
    {
        get => anyField;
        set
        {
            anyField = value;
            RaisePropertyChanged(nameof(Any));
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }
}


/// <summary>
/// Classe base utilizada nas responses dos serviços REST (assíncronos) da EFD-Reinf
[Serializable()]
public partial class Response : Schemas.eSocial.ESocialBindableObject
{
    [XmlIgnore]
    public VersaoRest Versao { get; set; } = VersaoRest.v1_3_0;


    private RetornoLoteEventos retornoLoteEventosAssincronoField;
    public RetornoLoteEventos retornoLoteEventosAssincrono
    {
        get => retornoLoteEventosAssincronoField;
        set
        {
            retornoLoteEventosAssincronoField = value;
            RaisePropertyChanged(nameof(retornoLoteEventosAssincrono));
        }
    }


    private XmlSerializer sSerializer;

    // Serialization Members
    private XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(Response), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/retornoLoteEventosAssincrono/{Versao}",
            IsNullable = false
        });
    }


    /// <summary>
    /// Escreve o conteúdo da instância no formato XML
    /// </summary>
    /// <param name="schemaName"></param>
    public string Write()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer = DefineSerializer();
            using (var xmlwriter = System.Xml.XmlWriter.Create(memoryStream, new XmlWriterSettings() { Indent = true }))
            {
                sSerializer.Serialize(xmlwriter, this);
            }
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }


    /// <summary>
    /// Retorna a instância de <see cref="Response"/> desserializada do conteúdo XML
    /// </summary>
    public Response Read(string xmlContent)
    {
        sSerializer = DefineSerializer();
        return Read(new MemoryStream(Encoding.UTF8.GetBytes(xmlContent))) as Response;
    }

    /// <summary>
    /// Retorna a instância de <see cref="Response"/> desserializada do conteúdo XML
    /// </summary>
    public Response Read(Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as Response;
    }
}


/// <summary>
/// Retorno (response) dos eventos da API Assíncrona
/// </summary>
public partial class RetornoLoteEventos : Schemas.eSocial.ESocialBindableObject
{
    private Schemas.eSocial.IdentificacaoCadastro ideContribuinteField;
    private StatusRetorno statusField;
    private RecepcaoEnvio dadosRecepcaoLoteField;
    private ProcessamentoEvento dadosProcessamentoLoteField;
    private LoteEventosRetorno retornoEventosField;

    public Schemas.eSocial.IdentificacaoCadastro ideContribuinte
    {
        get => ideContribuinteField;
        set
        {
            ideContribuinteField = value;
            RaisePropertyChanged(nameof(ideContribuinte));
        }
    }

    public StatusRetorno status
    {
        get => statusField;
        set
        {
            statusField = value;
            RaisePropertyChanged(nameof(status));
        }
    }

    public RecepcaoEnvio dadosRecepcaoLote
    {
        get => dadosRecepcaoLoteField;
        set
        {
            dadosRecepcaoLoteField = value;
            RaisePropertyChanged(nameof(dadosRecepcaoLote));
        }
    }

    public ProcessamentoEvento dadosProcessamentoLote
    {
        get => dadosProcessamentoLoteField;
        set
        {
            dadosProcessamentoLoteField = value;
            RaisePropertyChanged(nameof(dadosProcessamentoLote));
        }
    }

    public LoteEventosRetorno retornoEventos
    {
        get => retornoEventosField;
        set
        {
            retornoEventosField = value;
            RaisePropertyChanged(nameof(retornoEventos));
        }
    }
}


public partial class StatusRetorno : Schemas.eSocial.ESocialBindableObject  
{
    private string cdRespostaField;
    private string descRespostaField;
    private RegistroOcorrenciaRetorno[] dadosRegistroOcorrenciaLoteField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cdResposta
    {
        get => cdRespostaField;
        set
        {
            cdRespostaField = value;
            RaisePropertyChanged(nameof(cdResposta));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string descResposta
    {
        get => descRespostaField;
        set
        {
            descRespostaField = value;
            RaisePropertyChanged(nameof(descResposta));
        }
    }

    /// <remarks/>
    [XmlArray(Order = 2)]
    [XmlArrayItem("ocorrencias", IsNullable = false)]
    public RegistroOcorrenciaRetorno[] dadosRegistroOcorrenciaLote
    {
        get => dadosRegistroOcorrenciaLoteField;
        set
        {
            dadosRegistroOcorrenciaLoteField = value;
            RaisePropertyChanged(nameof(dadosRegistroOcorrenciaLote));
        }
    }
}


public partial class RegistroOcorrenciaRetorno : Schemas.eSocial.ESocialBindableObject
{
    private string tipoField;
    private string localizacaoErroAvisoField;
    private string codigoField;
    private string descricaoField;

    /// <remarks/>
    [XmlElement(DataType = "integer")]
    public string tipo
    {
        get => tipoField;
        set
        {
            tipoField = value;
            RaisePropertyChanged(nameof(tipo));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string localizacaoErroAviso
    {
        get => localizacaoErroAvisoField;
        set
        {
            localizacaoErroAvisoField = value;
            RaisePropertyChanged(nameof(localizacaoErroAviso));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string localizacao
    {
        get => localizacaoErroAvisoField;
        set
        {
            localizacaoErroAvisoField = value;
            RaisePropertyChanged(nameof(localizacao));
        }
    }


    /// <remarks/>
    [XmlElement()]
    public string codigo
    {
        get => codigoField;
        set
        {
            codigoField = value;
            RaisePropertyChanged(nameof(codigo));
        }
    }

    /// <remarks/>
    [XmlElement()]
    public string descricao
    {
        get => descricaoField;
        set
        {
            descricaoField = value;
            RaisePropertyChanged(nameof(descricao));
        }
    }
}


public partial class RecepcaoEnvio : Schemas.eSocial.ESocialBindableObject
{

    private DateTimeOffset dhRecepcaoField;
    private string versaoAplicativoRecepcaoField;
    private string protocoloEnvioField;

    /// <remarks/>
    public DateTimeOffset dhRecepcao
    {
        get => dhRecepcaoField;
        set
        {
            dhRecepcaoField = value;
            RaisePropertyChanged(nameof(dhRecepcao));
        }
    }

    /// <remarks/>
    public string versaoAplicativoRecepcao
    {
        get => versaoAplicativoRecepcaoField;
        set
        {
            versaoAplicativoRecepcaoField = value;
            RaisePropertyChanged(nameof(versaoAplicativoRecepcao));
        }
    }

    /// <remarks/>
    public string protocoloEnvio
    {
        get => protocoloEnvioField;
        set
        {
            protocoloEnvioField = value;
            RaisePropertyChanged(nameof(protocoloEnvio));
        }
    }
}


public partial class ProcessamentoEvento : Schemas.eSocial.ESocialBindableObject
{

    private string versaoAplicativoProcessamentoLoteField;

    /// <remarks/>
    public string versaoAplicativoProcessamentoLote
    {
        get => versaoAplicativoProcessamentoLoteField;
        set
        {
            versaoAplicativoProcessamentoLoteField = value;
            RaisePropertyChanged(nameof(versaoAplicativoProcessamentoLote));
        }
    }
}


public partial class LoteEventosRetorno : Schemas.eSocial.ESocialBindableObject
{

    private LoteEventoRetornoInfo[] eventoField;

    [System.Xml.Serialization.XmlElement("evento")]
    public LoteEventoRetornoInfo[] evento
    {
        get => eventoField;
        set
        {
            eventoField = value;
            RaisePropertyChanged(nameof(evento));
        }
    }
}


public partial class LoteEventoRetornoInfo : Schemas.eSocial.ESocialBindableObject
{
#warning "Alterar para totalizadores do e-Social"
    private XElement rawXmlField;
    private Schemas.EFD_Reinf.R9001 retornoEventoInfoField;
    private Schemas.EFD_Reinf.R9011 retornoEventoFechamentoInfoField;
    private Schemas.EFD_Reinf.R9005 retornoEventoRetInfoField;
    private Schemas.EFD_Reinf.R9015 retornoEventoFechamentoRetInfoField;
    private string idField;
    private bool evtDuplField;
    private bool evtDuplFieldSpecified;

    [XmlElement("retornoEvento")]
    public XElement RawXml
    {
        get => rawXmlField;
        set
        {
            rawXmlField = value;
            RaisePropertyChanged(nameof(RawXml));
        }
    }


    /// <summary>
    /// Retorno do envio dos eventos da série R-2000 (exceto fechamento)
    /// </summary>
    [XmlIgnore]
    public Schemas.EFD_Reinf.R9001 retornoEventoInfo => retornoEventoInfoField;

    /// <summary>
    /// Retorno do envio do evento de Fechamento R-2099
    /// </summary>
    [XmlIgnore]
    public Schemas.EFD_Reinf.R9011 retornoEventoFechamentoInfo => retornoEventoFechamentoInfoField;

    /// <summary>
    /// Retorno do envio dos eventos da série R-4000 (exceto fechamento)
    /// </summary>
    [XmlIgnore]
    public Schemas.EFD_Reinf.R9005 retornoEventoRetInfo => retornoEventoRetInfoField;

    /// <summary>
    /// Retorno do envio do eventos de fechamento R-4099
    /// </summary>
    [XmlIgnore]
    public Schemas.EFD_Reinf.R9015 retornoEventoFechamentoRetInfo => retornoEventoFechamentoRetInfoField;



    [System.Xml.Serialization.XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(Id));
        }
    }

    [System.Xml.Serialization.XmlAttribute()]
    public bool evtDupl
    {
        get => evtDuplField;
        set
        {
            evtDuplField = value;
            RaisePropertyChanged(nameof(evtDupl));
        }
    }

    [System.Xml.Serialization.XmlIgnore()]
    public bool evtDuplSpecified
    {
        get => evtDuplFieldSpecified;
        set
        {
            evtDuplFieldSpecified = value;
            RaisePropertyChanged(nameof(evtDuplSpecified));
        }
    }



    internal void ParseXml(Schemas.EFD_Reinf.Versao versao)
    {
        // Dim xml_string As String
        var stringWriter = new StringWriter();
        var xmlWriter = System.Xml.XmlWriter.Create(stringWriter);
        rawXmlField.WriteTo(xmlWriter);
        xmlWriter.Flush();
        string xml_string = stringWriter.ToString();
        xmlWriter.Dispose();
        try
        {
            stringWriter.Dispose();
        }
        catch
        {
        } // ex As Exception

        switch (rawXmlField?.Descendants()?.First()?.Name.LocalName ?? "")
        {
            case "evtTotal":
                {
                    var total = Activator.CreateInstance<Schemas.EFD_Reinf.R9001>();
                    total.Versao = versao;
                    retornoEventoInfoField = (Schemas.EFD_Reinf.R9001)total.Read(xml_string);
                    break;
                }

            case "evtTotalContrib":
                {
                    var total = Activator.CreateInstance<Schemas.EFD_Reinf.R9011>();
                    total.Versao = versao;
                    retornoEventoFechamentoInfoField = (Schemas.EFD_Reinf.R9011)total.Read(xml_string);
                    break;
                }

            case "evtRet":
                {
                    var total = Activator.CreateInstance<Schemas.EFD_Reinf.R9005>();
                    total.Versao = versao;
                    retornoEventoRetInfoField = (Schemas.EFD_Reinf.R9005)total.Read(xml_string);
                    break;
                }

            case "evtRetCons":
                {
                    // R-9015
                    var total = Activator.CreateInstance<Schemas.EFD_Reinf.R9015>();
                    total.Versao = versao;
                    retornoEventoFechamentoRetInfoField = (Schemas.EFD_Reinf.R9015)total.Read(xml_string);
                    break;
                }

        }
    }
}