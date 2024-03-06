namespace EficazFramework.SPED.Schemas.NFe;

/// <summary>
/// Esta classe representa o retorno de Cancelamento da NF-e por meio de Evento.
/// </summary>
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("procEventoNFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class ProcessoEvento : INotifyPropertyChanged, IXmlSpedDocument
{
    private Evento eventoField; // TEvento
    private EventoRetorno retEventoField; // TRetEvento
    private VersaoServicoEvento versaoField;
    private static XmlSerializer sSerializer;

    [XmlElement("evento")]
    public Evento Evento
    {
        get => eventoField;
        set
        {
            if (eventoField is null || eventoField.Equals(value) != true)
            {
                eventoField = value;
                OnPropertyChanged(nameof(Evento));
            }
        }
    }

    [XmlElement("retEvento")]
    public EventoRetorno EventoRetorno
    {
        get => retEventoField;
        set
        {
            if (retEventoField is null || retEventoField.Equals(value) != true)
            {
                retEventoField = value;
                OnPropertyChanged(nameof(EventoRetorno));
            }
        }
    }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoEvento Versao
    {
        get => versaoField;
        set
        {
            if (versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged(nameof(Versao));
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

    public XmlDocumentType DocumentType => XmlDocumentType.NFeEvent;

    [XmlIgnore()]
    public DateTime? DataEmissao => Evento.InformacaoEvento.EventoData;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.Evento.InformacaoEvento.Id
            if (Evento.InformacaoEvento.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(Evento.InformacaoEvento.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
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

    public static ProcessoEvento Deserialize(System.IO.Stream s)
    {
        return (ProcessoEvento)Serializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(System.IO.Stream target, ref Exception exception)
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

    public virtual async void SaveToAsync(System.IO.Stream target)
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
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoEvento obj, ref Exception exception)
    {
        exception = null;
        obj = default;
        try
        {
            obj = LoadFrom(source);
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

    public static ProcessoEvento LoadFrom(System.IO.Stream source)
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
            source?.Dispose();
            sr?.Dispose();
        }
    }

    public static async Task<ProcessoEvento> LoadFromAsync(System.IO.Stream source)
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
            source?.Dispose();

            sr?.Dispose();
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
                sr.Dispose();
        }
    }
}