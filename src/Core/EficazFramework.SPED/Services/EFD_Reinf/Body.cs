using System.IO;

namespace EficazFramework.SPED.Services.EFD_Reinf;

/// <summary>
/// Classe base utilizada nas requests e responses dos serviços REST (assíncronos) da EFD-Reinf
[Serializable()]
public partial class Body : Schemas.EFD_Reinf.EfdReinfBindableObject
{
    [XmlIgnore]
    public VersaoRest Versao { get; set; } = VersaoRest.v1_00_00;


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


    private RetornoLoteEventos retornoLoteEventosAssincronoField;
    [XmlElement(Order = 1)]
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
    private XmlSerializer DefineSerializer(BodySchemaName schemaName)
    {
        return new XmlSerializer(typeof(Body), new XmlRootAttribute("Reinf")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/{schemaName}/{Versao}",
            IsNullable = false
        });
    }


    /// <summary>
    /// Escreve o conteúdo da instância no formato XML
    /// </summary>
    /// <param name="schemaName"></param>
    public string Write(BodySchemaName schemaName)
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer = DefineSerializer(schemaName);
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
    /// Retorna a instância de <see cref="Body"/> desserializada do conteúdo XML
    /// </summary>
    public Body Read(string xmlContent, BodySchemaName schemaName)
    {
        sSerializer = DefineSerializer(schemaName);
        return Read(new MemoryStream(Encoding.UTF8.GetBytes(xmlContent)), schemaName) as Body;
    }

    /// <summary>
    /// Retorna a instância de <see cref="Body"/> desserializada do conteúdo XML
    /// </summary>
    public Body Read(Stream xmlStream, BodySchemaName schemaName)
    {
        sSerializer = DefineSerializer(schemaName);
        var result = sSerializer.Deserialize(xmlStream);
        return result as Body;
    }
}


public partial class EnvioLoteEventos : Schemas.EFD_Reinf.EfdReinfBindableObject
{
    private Schemas.EFD_Reinf.IdentificacaoContribuinte ideContribuinteField;
    private LoteEventos loteEventosField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public Schemas.EFD_Reinf.IdentificacaoContribuinte ideContribuinte
    {
        get => ideContribuinteField;
        set
        {
            ideContribuinteField = value;
            RaisePropertyChanged(nameof(ideContribuinte));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public LoteEventos eventos
    {
        get => loteEventosField;
        set
        {
            loteEventosField = value;
            RaisePropertyChanged(nameof(eventos));
        }
    }
}


public partial class LoteEventos : Schemas.EFD_Reinf.EfdReinfBindableObject
{
    private List<ConteudoReinf> eventoField;

    /// <remarks/>
    [XmlElement("eventos", Order = 0)]
    public List<ConteudoReinf> eventos
    {
        get => eventoField;
        set
        {
            eventoField = value;
            RaisePropertyChanged(nameof(eventos));
        }
    }
}


[Serializable()]
public partial class ConteudoReinf : Schemas.EFD_Reinf.EfdReinfBindableObject
{
    [XmlIgnore]
    public VersaoRest Versao { get; set; } = VersaoRest.v1_00_00;


    private XElement anyField;
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


    private string idField;
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


    // Serialization Members
    private XmlSerializer sSerializer;
    private XmlSerializer DefineSerializer()
    {
        return new XmlSerializer(typeof(ConteudoReinf), new XmlRootAttribute("evento")
        {
            Namespace = $"http://www.reinf.esocial.gov.br/schemas/envioLoteEventosAssincrono/{Versao}",
            IsNullable = false
        });
    }


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

    public ConteudoReinf Read(string xmlContent)
    {
        sSerializer = DefineSerializer();
        return Read(new MemoryStream(Encoding.UTF8.GetBytes(xmlContent))) as ConteudoReinf;
    }

    public ConteudoReinf Read(Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as ConteudoReinf;
    }
}


/// <summary>
/// Retorno (response) dos eventos da API Assíncrona
/// </summary>
public partial class RetornoLoteEventos : Schemas.EFD_Reinf.EfdReinfBindableObject
{
    private Schemas.EFD_Reinf.IdentificacaoContribuinte ideContribuinteField;
    private StatusRetorno statusField;
    private RecepcaoEnvio dadosRecepcaoLoteField;
    private ProcessamentoEvento dadosProcessamentoLoteField;
    private LoteEventosRetorno retornoEventosField;

    public Schemas.EFD_Reinf.IdentificacaoContribuinte ideContribuinte
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


public partial class StatusRetorno : Schemas.EFD_Reinf.EfdReinfBindableObject
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


public partial class RegistroOcorrenciaRetorno : Schemas.EFD_Reinf.EfdReinfBindableObject
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


public partial class RecepcaoEnvio : Schemas.EFD_Reinf.EfdReinfBindableObject
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


public partial class ProcessamentoEvento : Schemas.EFD_Reinf.EfdReinfBindableObject
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


public partial class LoteEventosRetorno : Schemas.EFD_Reinf.EfdReinfBindableObject
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


public partial class LoteEventoRetornoInfo : Schemas.EFD_Reinf.EfdReinfBindableObject
{

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

        switch (rawXmlField.Descendants().First().Name.LocalName ?? "" ?? "")
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