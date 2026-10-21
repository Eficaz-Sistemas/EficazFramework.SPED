using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.CTe;

[Serializable()]
[XmlType(TypeName = "consSitCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = true)]
public partial class PedidoConsultaSituacaoCTe
{
    [XmlElement("tpAmb")]
    public NFe.Ambiente Ambiente { get; set; }

    [XmlElement("xServ")]
    public string TipoServico { get; set; } = "CONSULTAR";

    [XmlElement("chCTe")]
    public string Chave { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoConsulta versao { get; set; }

    private static XmlSerializer Serializer { get; set; }


    /// <summary>
    /// Serializes current TEnvEvento object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(PedidoConsultaSituacaoCTe));
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    /// <summary>
    /// Semelhante À Function Serialize, porém já retorna o resultado
    /// em uma instância de XmlDocument, agilizando o processo de assinatura
    /// digital dos eventos.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }


    public static PedidoConsultaSituacaoCTe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (PedidoConsultaSituacaoCTe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoConsultaSituacaoCTe Deserialize(System.IO.Stream s) => (PedidoConsultaSituacaoCTe)Serializer.Deserialize(s);
}


[Serializable()]
[XmlType(TypeName = "retConsSitCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = true)]
public partial class RetornoConsultaSituacaoCTe
{
    [XmlElement("tpAmb")]
    public NFe.Ambiente Ambiente { get; set; }

    public string verAplic { get; set; }

    [XmlElement("cStat")]
    public string RetornoCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string RetornoDescricao { get; set; }

    [XmlElement("cUF")]
    public NFe.OrgaoIBGE UF { get; set; }

    [XmlElement("protCTe")]
    public TProtCTe ProtocoloCTe { get; set; }

    public ObservableCollection<ProcessoEvento> procEventoCTe { get; set; } = [];

    public string versao { get; set; }

    private static XmlSerializer Serializer { get; set; }


    /// <summary>
    /// Serializes current TEnvEvento object into an XML document
    /// </summary>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaSituacaoCTe));
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    /// <summary>
    /// Semelhante À Function Serialize, porém já retorna o resultado
    /// em uma instância de XmlDocument, agilizando o processo de assinatura
    /// digital dos eventos.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }


    public static RetornoConsultaSituacaoCTe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            Serializer ??= new XmlSerializer(typeof(RetornoConsultaSituacaoCTe));
            return (RetornoConsultaSituacaoCTe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoConsultaSituacaoCTe Deserialize(System.IO.Stream s) => (RetornoConsultaSituacaoCTe)Serializer.Deserialize(s);
}


public partial class TProtCTe
{
    public TProtCTeInfProt infProt { get; set; } = new();

    public SignatureType Signature { get; set; } = new();

    public string versao { get; set; }
}

public partial class TRetCancCTe
{
    public TRetCancCTeInfCanc infCanc { get; set; } = new();

    public SignatureType Signature { get; set; }

    public string versao { get; set; }
}

public partial class TRetCancCTeInfCanc
{
    public NFe.Ambiente tpAmb { get; set; }

    public NFe.OrgaoIBGE cUF { get; set; }

    public string verAplic { get; set; }

    public string cStat { get; set; }

    public string xMotivo { get; set; }

    public string chCTe { get; set; }

    public DateTime? dhRecbto { get; set; }

    [XmlIgnore()]
    public bool dhRecbtoSpecified { get; set; }

    public string nProt { get; set; }

    public string Id { get; set; }
}


[Serializable()]
[XmlType(TypeName = "procEventoCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = true)]
public partial class ProcessoEvento : INotifyPropertyChanged, IXmlSpedDocument
{
    private Evento eventoCTeField;
    private RetornoEvento retEventoCTeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public ProcessoEvento() : base()
    {
        retEventoCTeField = new RetornoEvento();
        eventoCTeField = new Evento();
    }

    public Evento eventoCTe
    {
        get => eventoCTeField;
        set
        {
            if (eventoCTeField is null || eventoCTeField.Equals(value) != true)
            {
                eventoCTeField = value;
                OnPropertyChanged(nameof(eventoCTe));
            }
        }
    }

    public RetornoEvento retEventoCTe
    {
        get => retEventoCTeField;
        set
        {
            if (retEventoCTeField is null || retEventoCTeField.Equals(value) != true)
            {
                retEventoCTeField = value;
                OnPropertyChanged(nameof(retEventoCTe));
            }
        }
    }

    [XmlAttribute("versao")]
    public string versao
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged(nameof(versao));
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(ProcessoEvento));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeEvent;

    [XmlIgnore()]
    public DateTime? DataEmissao => eventoCTe.infEvento.dhEvento;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            if (eventoCTe.infEvento.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(eventoCTe.infEvento.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    /// <summary>
    /// Serializes current TEnvEvento object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    /// <summary>
    /// Semelhante À Function Serialize, porém já retorna o resultado
    /// em uma instância de XmlDocument, agilizando o processo de assinatura
    /// digital dos eventos.
    /// </summary>
    /// <returns></returns>
    /// <remarks></remarks>
    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Deserializes workflow markup into an TEnvEvento object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref ProcessoEvento obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = Deserialize(xml);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanDeserialize(string xml, ref ProcessoEvento obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoEvento Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (ProcessoEvento)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoEvento Deserialize(System.IO.Stream s) => 
        (ProcessoEvento)Serializer.Deserialize(s);


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveTo(System.IO.Stream target, ref Exception exception)
    {
        exception = null;
        try
        {
            SaveTo(target);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }

    public virtual void SaveTo(System.IO.Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new System.IO.StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            streamWriter?.Dispose();
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
            streamWriter?.Dispose();
        }
    }


    /// <summary>
    /// Deserializes xml markup from file into an TEnvEvento object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoEvento obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = LoadFrom(source, false);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoEvento obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoEvento LoadFrom(System.IO.Stream source, bool close_stream = true)
    {
        // Dim file As System.IO.FileStream = Nothing
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            sr = new System.IO.StreamReader(source);
            string xmlString = sr.ReadToEnd();
            return Deserialize(xmlString);
        }
        finally
        {
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<ProcessoEvento> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            return Deserialize(xmlString);
        }
        finally
        {
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}


[Serializable()]
[XmlType(TypeName = "eventoCTe", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = true)]
public partial class Evento : INotifyPropertyChanged, IXmlSpedDocument
{
    private TEventoInfEvento infEventoField;
    private SignatureType signatureField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public Evento() : base()
    {
        infEventoField = new TEventoInfEvento();
    }

    public TEventoInfEvento infEvento
    {
        get => infEventoField;
        set
        {
            if (infEventoField is null || infEventoField.Equals(value) != true)
            {
                infEventoField = value;
                OnPropertyChanged("infEvento");
            }
        }
    }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get => signatureField;
        set
        {
            if (signatureField is null || signatureField.Equals(value) != true)
            {
                signatureField = value;
                OnPropertyChanged("Signature");
            }
        }
    }

    [XmlAttribute("versao")]
    public string versao
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged("versao");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(Evento));

            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeEvent2;

    public DateTime? DataEmissao => infEvento.dhEvento;

    public string Chave => infEvento.chCTe;

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => 
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Serializes current TEnvEvento object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public virtual string Serialize()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            Serializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, System.IO.SeekOrigin.Begin);
            streamReader = new System.IO.StreamReader(memoryStream);
            return streamReader.ReadToEnd();
        }
        finally
        {
            streamReader?.Dispose();
            memoryStream?.Dispose();
        }
    }

    /// <summary>
    /// Semelhante À Function Serialize, porém já retorna o resultado
    /// em uma instância de XmlDocument, agilizando o processo de assinatura
    /// digital dos eventos.
    /// </summary>
    public virtual XmlDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = new XmlDocument();
            doc.LoadXml(str);
            return doc;
        }
        else
        {
            return null;
        }
    }

    /// <summary>
    /// Deserializes workflow markup into an TEnvEvento object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref Evento obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = Deserialize(xml);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanDeserialize(string xml, ref Evento obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static Evento Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (Evento)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static Evento Deserialize(System.IO.Stream s) => (Evento)Serializer.Deserialize(s);


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveTo(System.IO.Stream target, ref Exception exception)
    {
        exception = null;
        try
        {
            SaveTo(target);
            return true;
        }
        catch (Exception e)
        {
            exception = e;
            return false;
        }
    }

    public virtual void SaveTo(System.IO.Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new System.IO.StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            streamWriter?.Dispose();
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
            streamWriter?.Dispose();
        }
    }


    /// <summary>
    /// Deserializes xml markup from file into an TEnvEvento object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref Evento obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = LoadFrom(source, false);
            return true;
        }
        catch (Exception ex)
        {
            exception = ex;
            return false;
        }
    }

    public static bool CanLoadFrom(System.IO.Stream source, ref Evento obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static Evento LoadFrom(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            sr = new System.IO.StreamReader(source);
            string xmlString = sr.ReadToEnd();
            return Deserialize(xmlString);
        }
        finally
        {
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<Evento> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            return Deserialize(xmlString);
        }
        finally
        {
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}


[XmlType(TypeName = "TEventoInfEvento", Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TEventoInfEvento
{
    [XmlElement("cOrgao")]
    public NFe.OrgaoIBGE cOrgao { get; set; }

    [XmlElement("tpAmb")]
    public NFe.Ambiente tpAmb { get; set; }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string CNPJ_CPF { get; set; }

    [XmlIgnore]
    public PersonalidadeJuridica7 ItemElementName { get; set; }

    /// <summary>
    /// Atalho para <see cref="CNPJ_CPF"/> quando o autor do evento é pessoa jurídica
    /// </summary>
    [XmlIgnore]
    public string CNPJ
    {
        get => ItemElementName == PersonalidadeJuridica7.CNPJ ? CNPJ_CPF : null;
        set
        {
            CNPJ_CPF = value;
            ItemElementName = PersonalidadeJuridica7.CNPJ;
        }
    }

    [XmlElement("chCTe")]
    public string chCTe { get; set; }

    [XmlIgnore]
    public DateTime? dhEvento { get; set; }

    [XmlElement("dhEvento")]
    public string dhEventoXml
    {
        get => dhEvento?.ToString("yyyy-MM-ddTHH:mm:sszzz");
        set => dhEvento = string.IsNullOrEmpty(value) ? null : DateTimeOffset.Parse(value).DateTime;
    }

    [XmlElement("tpEvento")]
    public string tpEvento { get; set; }

    [XmlElement("nSeqEvento")]
    public string nSeqEvento { get; set; }

    [XmlElement("detEvento")]
    public TEventoInfEventoDetEvento detEvento { get; set; } = new();

    [XmlAttribute("Id")]
    public string Id { get; set; }
}

[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TEventoInfEventoDetEvento
{
    [XmlAnyElement()]
    public XElement Any { get; set; }

    [XmlAttribute("versaoEvento")]
    public string versaoEvento { get; set; }
}

[Serializable()]
[XmlType(TypeName = "TRetEvento", Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("retEventoCTe", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = true)]
public partial class RetornoEvento : IXmlSpedDocument
{
    private static XmlSerializer sSerializer;

    [XmlElement("infEvento")]
    public TRetEventoInfEvento infEvento { get; set; } = new();

    [XmlElement("Signature", Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature { get; set; }

    [XmlAttribute("versao")]
    public string versao { get; set; }

    private static XmlSerializer Serializer => sSerializer ??= new XmlSerializer(typeof(RetornoEvento));

    [XmlIgnore]
    public XmlDocumentType DocumentType => XmlDocumentType.CTeEvent2;

    [XmlIgnore]
    public DateTime? DataEmissao => DateTime.TryParse(infEvento?.dhRegEvento, out var d) ? d : null;

    [XmlIgnore]
    public string Chave => infEvento?.chCTe;

    public virtual string Serialize()
    {
        using var ms = new System.IO.MemoryStream();
        Serializer.Serialize(ms, this);
        ms.Seek(0L, System.IO.SeekOrigin.Begin);
        return new System.IO.StreamReader(ms).ReadToEnd();
    }

    public static RetornoEvento Deserialize(string xml)
    {
        using var sr = new System.IO.StringReader(xml);
        return (RetornoEvento)Serializer.Deserialize(System.Xml.XmlReader.Create(sr));
    }

    public static RetornoEvento Deserialize(System.IO.Stream s) => (RetornoEvento)Serializer.Deserialize(s);
}

[XmlType(TypeName = "TRetEventoInfEvento", Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TRetEventoInfEvento
{
    [XmlElement("tpAmb")]
    public NFe.Ambiente tpAmb { get; set; }

    [XmlElement("verAplic")]
    public string verAplic { get; set; }

    [XmlElement("cOrgao")]
    public NFe.OrgaoIBGE cOrgao { get; set; }

    [XmlElement("cStat")]
    public string cStat { get; set; }

    [XmlElement("xMotivo")]
    public string xMotivo { get; set; }

    [XmlElement("chCTe")]
    public string chCTe { get; set; }

    [XmlElement("tpEvento")]
    public string tpEvento { get; set; }

    [XmlElement("xEvento")]
    public string xEvento { get; set; }

    [XmlElement("nSeqEvento")]
    public string nSeqEvento { get; set; }

    [XmlElement("dhRegEvento")]
    public string dhRegEvento { get; set; }

    [XmlElement("nProt")]
    public string nProt { get; set; }

    [XmlAttribute("Id")]
    public string Id { get; set; }
}
