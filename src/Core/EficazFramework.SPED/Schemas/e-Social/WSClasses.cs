using System.IO;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <summary>
/// Envio dos eventos
/// </summary>
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1")]
[System.Xml.Serialization.XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1", IsNullable = false)]
public partial class EnvioLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private eSocialEnvioLoteEventos envioLoteEventosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public eSocialEnvioLoteEventos envioLoteEventos
    {
        get
        {
            return envioLoteEventosField;
        }

        set
        {
            envioLoteEventosField = value;
            RaisePropertyChanged("envioLoteEventos");
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


    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(EnvioLoteEventos));

    public static EnvioLoteEventos LoadFromXDocument(XDocument instance)
    {
        // Dim stringWriter As New StringWriter()
        // Dim settings As New Xml.XmlWriterSettings With {.Indent = True, .WriteEndDocumentOnClose = True, .CloseOutput = True}
        // Dim xmlWriter As Xml.XmlWriter = Xml.XmlWriter.Create(stringWriter, settings)  'With {.Formatting = Formatting.Indented, .Indentation = 2}
        // instance.Save(xmlWriter)
        // Dim result_str As String = stringWriter.ToString
        // stringWriter.Dispose()
        return Deserialize(instance.ToString());
    }


    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref EnvioLoteEventos obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref EnvioLoteEventos obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static EnvioLoteEventos Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (EnvioLoteEventos)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        catch (Exception ex)
        {
            Debug.WriteLine(ex.ToString());
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }

        return null;
    }

    public static EnvioLoteEventos Deserialize(Stream s)
    {
        return (EnvioLoteEventos)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref EnvioLoteEventos obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref EnvioLoteEventos obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static EnvioLoteEventos LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<EnvioLoteEventos> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Retorno ao chamado de envio dos eventos
/// </summary>
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoEnvio/v1_1_0")]
[System.Xml.Serialization.XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoEnvio/v1_1_0", IsNullable = false)]
public partial class RetornoLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private RetornoEnvioLoteEventos retornoEnvioLoteEventosField;

    [System.Xml.Serialization.XmlIgnore]
    public EnvioLoteEventos DadosEnvio { get; set; } = null;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public RetornoEnvioLoteEventos retornoEnvioLoteEventos
    {
        get
        {
            return retornoEnvioLoteEventosField;
        }

        set
        {
            retornoEnvioLoteEventosField = value;
            RaisePropertyChanged("retornoEnvioLoteEventos");
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

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RetornoLoteEventos));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref RetornoLoteEventos obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoLoteEventos obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoLoteEventos Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (RetornoLoteEventos)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static RetornoLoteEventos Deserialize(Stream s)
    {
        return (RetornoLoteEventos)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref RetornoLoteEventos obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref RetornoLoteEventos obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoLoteEventos LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<RetornoLoteEventos> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class eSocialEnvioLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private Empregador ideEmpregadorField;
    private IdeTransmissor ideTransmissorField;
    private eSocialEnvioLoteEventosEventos eventosField;
    private int grupoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public Empregador ideEmpregador
    {
        get
        {
            return ideEmpregadorField;
        }

        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 1)]
    public IdeTransmissor ideTransmissor
    {
        get
        {
            return ideTransmissorField;
        }

        set
        {
            ideTransmissorField = value;
            RaisePropertyChanged("ideTransmissor");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 2, Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1")]
    public eSocialEnvioLoteEventosEventos eventos
    {
        get
        {
            return eventosField;
        }

        set
        {
            eventosField = value;
            RaisePropertyChanged("eventos");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute()]
    public int grupo
    {
        get
        {
            return grupoField;
        }

        set
        {
            grupoField = value;
            RaisePropertyChanged("grupo");
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

public partial class eSocialEnvioLoteEventosEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private List<ArquivoEsocial> eventoField = new List<ArquivoEsocial>();

    /// <remarks/>
    [System.Xml.Serialization.XmlElement("evento", Order = 0)]
    public List<ArquivoEsocial> evento
    {
        get
        {
            return eventoField;
        }

        set
        {
            eventoField = value;
            RaisePropertyChanged("evento");
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

public partial class ArquivoEsocial : object, System.ComponentModel.INotifyPropertyChanged
{
    private XElement anyField;
    private string idField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElement(Order = 0)]
    public XElement Any
    {
        get
        {
            return anyField;
        }

        set
        {
            anyField = value;
            RaisePropertyChanged("Any");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("Id");
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

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ArquivoEsocial));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref ArquivoEsocial obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ArquivoEsocial obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ArquivoEsocial Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ArquivoEsocial)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static ArquivoEsocial Deserialize(Stream s)
    {
        return (ArquivoEsocial)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref ArquivoEsocial obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref ArquivoEsocial obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ArquivoEsocial LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<ArquivoEsocial> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class RetornoEnvioLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private Empregador ideEmpregadorField;
    private IdeTransmissor ideTransmissorField;
    private StatusEnvio statusField;
    private DadosRecepcao dadosRecepcaoLoteField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public Empregador ideEmpregador
    {
        get
        {
            return ideEmpregadorField;
        }

        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 1)]
    public IdeTransmissor ideTransmissor
    {
        get
        {
            return ideTransmissorField;
        }

        set
        {
            ideTransmissorField = value;
            RaisePropertyChanged("ideTransmissor");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 2)]
    public StatusEnvio status
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
    [System.Xml.Serialization.XmlElement(Order = 3)]
    public DadosRecepcao dadosRecepcaoLote
    {
        get
        {
            return dadosRecepcaoLoteField;
        }

        set
        {
            dadosRecepcaoLoteField = value;
            RaisePropertyChanged("dadosRecepcaoLote");
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

/// <summary>
/// Consulta de lote de eventos
/// </summary>
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/consulta/retornoProcessamento/v1_0_0")]
[System.Xml.Serialization.XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/consulta/retornoProcessamento/v1_0_0", IsNullable = false)]
public partial class ConsultaLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private eSocialConsultaLoteEventos consultaLoteEventosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public eSocialConsultaLoteEventos consultaLoteEventos
    {
        get
        {
            return consultaLoteEventosField;
        }

        set
        {
            consultaLoteEventosField = value;
            RaisePropertyChanged("consultaLoteEventos");
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

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(ConsultaLoteEventos));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref ConsultaLoteEventos obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ConsultaLoteEventos obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ConsultaLoteEventos Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ConsultaLoteEventos)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static ConsultaLoteEventos Deserialize(Stream s)
    {
        return (ConsultaLoteEventos)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref ConsultaLoteEventos obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref ConsultaLoteEventos obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ConsultaLoteEventos LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<ConsultaLoteEventos> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

/// <summary>
/// Retorno á consulta de lote de eventos
/// </summary>
[Serializable()]
[System.Xml.Serialization.XmlType(AnonymousType = true, Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoProcessamento/v1_3_0")]
[System.Xml.Serialization.XmlRoot("eSocial", Namespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoProcessamento/v1_3_0", IsNullable = false)]
public partial class RetornoConsultaLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private RetornoProcessamentoLoteEventos retornoProcessamentoLoteEventosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public RetornoProcessamentoLoteEventos retornoProcessamentoLoteEventos
    {
        get
        {
            return retornoProcessamentoLoteEventosField;
        }

        set
        {
            retornoProcessamentoLoteEventosField = value;
            RaisePropertyChanged("retornoProcessamentoLoteEventos");
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

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(RetornoConsultaLoteEventos));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref RetornoConsultaLoteEventos obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoConsultaLoteEventos obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoConsultaLoteEventos Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (RetornoConsultaLoteEventos)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static RetornoConsultaLoteEventos Deserialize(Stream s)
    {
        return (RetornoConsultaLoteEventos)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref RetornoConsultaLoteEventos obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref RetornoConsultaLoteEventos obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoConsultaLoteEventos LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<RetornoConsultaLoteEventos> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

public partial class eSocialConsultaLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private string protocoloEnvioField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
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

public partial class RetornoProcessamentoLoteEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private Empregador ideEmpregadorField;
    private IdeTransmissor ideTransmissorField;
    private StatusConsulta statusField;
    private DadosRecepcao dadosRecepcaoLoteField;
    private DadosProcessamento dadosProcessamentoLoteField;
    private RetornoProcessamentoLoteEventosRetornoEventos retornoEventosField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public Empregador ideEmpregador
    {
        get
        {
            return ideEmpregadorField;
        }

        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 1)]
    public IdeTransmissor ideTransmissor
    {
        get
        {
            return ideTransmissorField;
        }

        set
        {
            ideTransmissorField = value;
            RaisePropertyChanged("ideTransmissor");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 2)]
    public StatusConsulta status
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
    [System.Xml.Serialization.XmlElement(Order = 3)]
    public DadosRecepcao dadosRecepcaoLote
    {
        get
        {
            return dadosRecepcaoLoteField;
        }

        set
        {
            dadosRecepcaoLoteField = value;
            RaisePropertyChanged("dadosRecepcaoLote");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 4)]
    public DadosProcessamento dadosProcessamentoLote
    {
        get
        {
            return dadosProcessamentoLoteField;
        }

        set
        {
            dadosProcessamentoLoteField = value;
            RaisePropertyChanged("dadosProcessamentoLote");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 5)]
    public RetornoProcessamentoLoteEventosRetornoEventos retornoEventos
    {
        get
        {
            return retornoEventosField;
        }

        set
        {
            retornoEventosField = value;
            RaisePropertyChanged("retornoEventos");
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

public partial class DadosProcessamento : object, System.ComponentModel.INotifyPropertyChanged
{
    private string versaoAplicativoProcessamentoLoteField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public string versaoAplicativoProcessamentoLote
    {
        get
        {
            return versaoAplicativoProcessamentoLoteField;
        }

        set
        {
            versaoAplicativoProcessamentoLoteField = value;
            RaisePropertyChanged("versaoAplicativoProcessamentoLote");
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

public partial class RetornoProcessamentoLoteEventosRetornoEventos : object, System.ComponentModel.INotifyPropertyChanged
{
    private RetornoProcessamentoLoteEventosRetornoEventosEvento[] eventoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement("evento", Order = 0)]
    public RetornoProcessamentoLoteEventosRetornoEventosEvento[] evento
    {
        get
        {
            return eventoField;
        }

        set
        {
            eventoField = value;
            RaisePropertyChanged("evento");
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

public partial class RetornoProcessamentoLoteEventosRetornoEventosEvento : object, System.ComponentModel.INotifyPropertyChanged
{
    // tag eSocial


    private XElement retornoEventoField;
    private RetornoProcessamentoLoteEventosRetornoEventosEventoTot[] totField;
    private string idField;
    private bool evtDuplField;
    private bool evtDuplFieldSpecified;

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public XElement retornoEvento
    {
        get
        {
            return retornoEventoField;
        }

        set
        {
            retornoEventoField = value;
            RaisePropertyChanged("retornoEvento");
        }
    }

    public eSocialRetornoEvento Result()
    {
        var stringWriter = new StringWriter();
        var xmlWriter = System.Xml.XmlWriter.Create(stringWriter);
        retornoEvento.FirstNode.NextNode.WriteTo(xmlWriter);
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

        xml_string = xml_string.Replace(" xmlns=\"http://www.esocial.gov.br/schema/evt/retornoEvento/v1_2_0\"", "");
        xml_string = xml_string.Replace(" xmlns=\"http://www.esocial.gov.br/schema/evt/retornoEvento/v1_2_1\"", "");
        return eSocialRetornoEvento.Deserialize(xml_string);
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement("tot", Order = 1)]
    public RetornoProcessamentoLoteEventosRetornoEventosEventoTot[] tot
    {
        get
        {
            return totField;
        }

        set
        {
            totField = value;
            RaisePropertyChanged("tot");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("Id");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute()]
    public bool evtDupl
    {
        get
        {
            return evtDuplField;
        }

        set
        {
            evtDuplField = value;
            RaisePropertyChanged("evtDupl");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlIgnore()]
    public bool evtDuplSpecified
    {
        get
        {
            return evtDuplFieldSpecified;
        }

        set
        {
            evtDuplFieldSpecified = value;
            RaisePropertyChanged("evtDuplSpecified");
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

public partial class RetornoProcessamentoLoteEventosRetornoEventosEventoTot : object, System.ComponentModel.INotifyPropertyChanged
{
    private XElement anyField;
    private string tipoField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAnyElement(Order = 0)]
    public XElement Any
    {
        get
        {
            return anyField;
        }

        set
        {
            anyField = value;
            RaisePropertyChanged("Any");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute()]
    public string tipo
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

public partial class eSocialRetornoEvento : object, System.ComponentModel.INotifyPropertyChanged
{
    private string idField;
    private Empregador ideEmpregadorField;
    private DadosRecepcaoRetornoEvento recepcaoield;
    private ProcessamentoRetornoEvento processamentoField;
    private eSocialRetornoEventoRecibo reciboField;

    /// <remarks/>
    [System.Xml.Serialization.XmlAttribute(DataType = "ID")]
    public string Id
    {
        get
        {
            return idField;
        }

        set
        {
            idField = value;
            RaisePropertyChanged("Id");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 0)]
    public Empregador ideEmpregador
    {
        get
        {
            return ideEmpregadorField;
        }

        set
        {
            ideEmpregadorField = value;
            RaisePropertyChanged("ideEmpregador");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 1)]
    public DadosRecepcaoRetornoEvento recepcao
    {
        get
        {
            return recepcaoield;
        }

        set
        {
            recepcaoield = value;
            RaisePropertyChanged("recepcao");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 2)]
    public ProcessamentoRetornoEvento processamento
    {
        get
        {
            return processamentoField;
        }

        set
        {
            processamentoField = value;
            RaisePropertyChanged("processamento");
        }
    }

    /// <remarks/>
    [System.Xml.Serialization.XmlElement(Order = 3)]
    public eSocialRetornoEventoRecibo recibo
    {
        get
        {
            return reciboField;
        }

        set
        {
            reciboField = value;
            RaisePropertyChanged("recibo");
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

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private static System.Xml.Serialization.XmlSerializer sSerializer = new System.Xml.Serialization.XmlSerializer(typeof(eSocialRetornoEvento));

    /// <summary>
    /// Serializes current TNfeProc object into an XML document
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
    {
        StreamReader streamReader = null;
        MemoryStream memoryStream = null;
        try
        {
            memoryStream = new MemoryStream();
            sSerializer.Serialize(memoryStream, this);
            memoryStream.Seek(0L, SeekOrigin.Begin);
            streamReader = new StreamReader(memoryStream);
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
    /// Deserializes workflow markup into an TNfeProc object
    /// </summary>
    /// <param name="xml">string workflow markup to deserialize</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanDeserialize(string xml, ref eSocialRetornoEvento obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref eSocialRetornoEvento obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static eSocialRetornoEvento Deserialize(string xml)
    {
        StringReader stringReader = null;
        try
        {
            stringReader = new StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (eSocialRetornoEvento)sSerializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CabecalhoMensagem)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static eSocialRetornoEvento Deserialize(Stream s)
    {
        return (eSocialRetornoEvento)sSerializer.Deserialize(s);
    }


    /// <summary>
    /// Serializes current TNfeProc object into file
    /// </summary>
    /// <param name="target">target stream of outupt xml file</param>
    /// <param name="exception">output Exception value if failed</param>
    /// <returns>true if can serialize and save into file; otherwise, false</returns>
    public virtual bool CanSaveToFile(Stream target, ref Exception exception)
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

    public virtual void SaveTo(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
        try
        {
            string xmlString = Serialize();
            // Dim xmlFile As System.IO.FileInfo = New System.IO.FileInfo(fileName)
            // streamWriter = xmlFile.CreateText
            streamWriter.WriteLine(xmlString);
            streamWriter.Flush();
        }
        finally
        {
            if (streamWriter != null)
            {
                streamWriter.Dispose();
            }
        }
    }

    public virtual async void SaveToAsync(Stream target)
    {
        if (target is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Save_NullStreamExceptionMessage);
        var streamWriter = new StreamWriter(target);
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


    /// <summary>
    /// Deserializes xml markup from file into an TNfeProc object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TNfeProc object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(Stream source, ref eSocialRetornoEvento obj, ref Exception exception)
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

    public static bool CanLoadFrom(Stream source, ref eSocialRetornoEvento obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static eSocialRetornoEvento LoadFrom(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = sr.ReadToEnd();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<eSocialRetornoEvento> LoadFromAsync(Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            // sr.Close()
            // file.Close()
            return Deserialize(xmlString);
        }
        finally
        {
            if (source != null)
            {
                source.Dispose();
            }

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */

}

public partial class eSocialRetornoEventoRecibo : object, System.ComponentModel.INotifyPropertyChanged
{
    private string nrReciboField;
    private string hashield;

    [System.Xml.Serialization.XmlElement(Order = 0)]
    public string nrRecibo
    {
        get
        {
            return nrReciboField;
        }

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("Id");
        }
    }

    [System.Xml.Serialization.XmlElement(Order = 1)]
    public string hash
    {
        get
        {
            return hashield;
        }

        set
        {
            hashield = value;
            RaisePropertyChanged("hash");
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



/// <summary>
/// Resultado dos servidores do eSocial após Invoke do Envio de Lote de Eventos
/// </summary>
public partial class StatusEnvio : object, INotifyPropertyChanged
{
    private int cdRespostaField;
    private string descRespostaField;
    private List<DetalhamentoOcorrencia> ocorrenciasField = new List<DetalhamentoOcorrencia>();

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
    public List<DetalhamentoOcorrencia> ocorrencias
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
public partial class StatusConsulta : object, INotifyPropertyChanged
{
    private int cdRespostaField;
    private string descRespostaField;
    private int tempoEstimadoConclusaoField;
    private bool tempoEstimadoConclusaoFieldSpecified;
    private List<DetalhamentoOcorrencia> ocorrenciasField = new List<DetalhamentoOcorrencia>();

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
    public List<DetalhamentoOcorrencia> ocorrencias
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
public partial class DetalhamentoOcorrencia : object, INotifyPropertyChanged
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
public partial class DadosRecepcao : object, INotifyPropertyChanged
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
public partial class DadosRecepcaoRetornoEvento : object, INotifyPropertyChanged
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
public partial class ProcessamentoRetornoEvento : object, INotifyPropertyChanged
{
    private int cdRespostaField;
    private string descRespostaField;
    private string versaoAplicativoRecepcaoField;
    private DateTime dhRecepcaoField;
    private List<DetalhamentoOcorrencia> ocorrenciasField = new List<DetalhamentoOcorrencia>();


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
    public List<DetalhamentoOcorrencia> ocorrencias
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
