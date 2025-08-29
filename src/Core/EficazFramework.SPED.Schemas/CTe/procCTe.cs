using EficazFramework.SPED.Extensions;
using System.Collections;
using System.Collections.ObjectModel;

namespace EficazFramework.SPED.Schemas.CTe;

[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("enviCTe", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class LoteCte : INotifyPropertyChanged, IXmlSpedDocument
{
    public LoteCte() : base()
    {
        cTeField = new CTe();
    }

    private CTe cTeField;
    private string idLoteField;
    private string versaoField;
    private static XmlSerializer sSerializer;


    public CTe CTe
    {
        get => cTeField;
        set
        {
            if (cTeField is null || cTeField.Equals(value) != true)
            {
                cTeField = value;
                OnPropertyChanged(nameof(CTe));
            }
        }
    }

    [XmlElement("idLote")]
    public string IdLote
    {
        get => idLoteField;
        set
        {
            if (idLoteField is null || idLoteField.Equals(value) != true)
            {
                idLoteField = value;
                OnPropertyChanged("idLote");
            }
        }
    }

    [XmlAttribute("versao")]
    public string Versao
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
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
            sSerializer ??= new XmlSerializer(typeof(LoteCte));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeLote;

    [XmlIgnore()]
    public DateTime? DataEmissao => CTe.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            if (CTe.Informacoes.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(CTe.Informacoes.Id, "[^0-9]", "");
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
    public static bool CanDeserialize(string xml, ref LoteCte obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref LoteCte obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static LoteCte Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (LoteCte)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static LoteCte Deserialize(System.IO.Stream s) =>
        (LoteCte) Serializer.Deserialize(s);

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
    public static bool CanLoadFrom(System.IO.Stream source, ref LoteCte obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref LoteCte obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static LoteCte LoadFrom(System.IO.Stream source)
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

    public static async Task<LoteCte> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
        catch (Exception inner_load)
        {
            Debug.WriteLine((string)inner_load.ToString());
            return null;
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
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("cteProc", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class ProcessoCTe : INotifyPropertyChanged, IXmlSpedDocument
{
    public ProcessoCTe() : base()
    {
        protCTeField = new ProtocoloAutorizacao();
        cTeField = new CTe();
    }

    private CTe cTeField;
    private ProtocoloAutorizacao protCTeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public CTe CTe
    {
        get => cTeField;
        set
        {
            if (cTeField is null || cTeField.Equals(value) != true)
            {
                cTeField = value;
                OnPropertyChanged(nameof(CTe));
            }
        }
    }

    [XmlElement("protCTe")]
    public ProtocoloAutorizacao ProtocoloAutorizacao
    {
        get => protCTeField;
        set
        {
            if (protCTeField is null || protCTeField.Equals(value) != true)
            {
                protCTeField = value;
                OnPropertyChanged(nameof(ProtocoloAutorizacao));
            }
        }
    }

    [XmlAttribute("versao")]
    public string Versao
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
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
            sSerializer ??= new XmlSerializer(typeof(ProcessoCTe));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeWithProtocol;

    [XmlIgnore()]
    public DateTime? DataEmissao => CTe.Informacoes.IdentificacaoOperacao.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.CTe.Informacoes.IdentificacaoOperacao.Chave
            if (CTe.Informacoes.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(CTe.Informacoes.Id, "[^0-9]", "");
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
    public static bool CanDeserialize(string xml, ref ProcessoCTe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ProcessoCTe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoCTe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (ProcessoCTe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoCTe Deserialize(System.IO.Stream s) =>
        (ProcessoCTe)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoCTe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoCTe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoCTe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
            if (source != null & close_stream == true)
            {
                source.Dispose();
            }

            sr?.Dispose();
        }
    }

    public static async Task<ProcessoCTe> LoadFromAsync(System.IO.Stream source)
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

    public static async Task<ProcessoCTe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            if (xmlString.Contains("<retCTeConsultaDFe"))
            {
                int startindex = xmlString.IndexOf("<procCTe");
                int length = xmlString.IndexOf("</procCTe>") - startindex + 11;
                xmlString = "<?xml version=" + '"' + "1.0" + '"' + "?>" + '\n' + xmlString.Substring(startindex, length).Replace("</procCTe>", "</cteProc>").Replace("<procCTe", "<cteProc xmlns=" + '"' + "http://www.portalfiscal.inf.br/cte" + '"');
                xmlString = xmlString.Replace("</cteProc><", "</cteProc>");
            }
            return Deserialize(xmlString);
        }
        catch (Exception inner_load)
        {
            /* TODO ERROR: Skipped IfDirectiveTrivia */
            Debug.WriteLine(inner_load.ToString());
            /* TODO ERROR: Skipped EndIfDirectiveTrivia */
            return null;
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
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("CTe", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class CTe : INotifyPropertyChanged, IXmlSpedDocument
{
    public CTe() : base()
    {
        signatureField = new SignatureType();
        infCteField = new InformacoesCTe();
    }

    private InformacoesCTe infCteField;
    private SignatureType signatureField;
    private static XmlSerializer sSerializer;


    [XmlElement("infCte")]
    public InformacoesCTe Informacoes
    {
        get => infCteField;
        set
        {
            if (infCteField is null || infCteField.Equals(value) != true)
            {
                infCteField = value;
                OnPropertyChanged(nameof(Informacoes));
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
                OnPropertyChanged(nameof(Signature));
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(CTe));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeWithoutProtocol;

    [XmlIgnore()]
    public DateTime? DataEmissao => Informacoes.IdentificacaoOperacao.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            if (Informacoes.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(Informacoes.Id, "[^0-9]", "");
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
    public static bool CanDeserialize(string xml, ref CTe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref CTe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static CTe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (CTe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static CTe Deserialize(System.IO.Stream s) =>
        (CTe)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref CTe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref CTe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static CTe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
            if (source != null & close_stream == true)
            {
                source.Dispose();
            }
            sr?.Dispose();
        }
    }

    public static async Task<CTe> LoadFromAsync(System.IO.Stream source)
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

    public static async Task<CTe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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


public partial class InformacoesCTe : INotifyPropertyChanged
{

    public InformacoesCTe() : base()
    {
        autXMLField = [];
        impField = new Impostos();
        vPrestField = new ValoresPrestacaoServico();
        destField = new Destinatario();
        recebField = new Recebedor();
        // Me.expedField = New Expedidor()
        remField = new Remetente();
        emitField = new Emitente();
        complField = new ComplementoCTe();
        ideField = new IdentificacaoOperacao();
    }

    private IdentificacaoOperacao ideField;
    private ComplementoCTe complField;
    private Emitente emitField;
    private Remetente remField;
    private Expedidor expedField;
    private Recebedor recebField;
    private Destinatario destField;
    private ValoresPrestacaoServico vPrestField;
    private Impostos impField;
    private object itemField;
    private object tomaField;
    private ObservableCollection<AutorizadoXML> autXMLField;
    private string versaoField;
    private string idField;
    private static XmlSerializer sSerializer;


    [XmlElement("ide")]
    public IdentificacaoOperacao IdentificacaoOperacao
    {
        get => ideField;
        set
        {
            if (ideField is null || ideField.Equals(value) != true)
            {
                ideField = value;
                OnPropertyChanged(nameof(IdentificacaoOperacao));
            }
        }
    }

    [XmlElement("compl")]
    public ComplementoCTe Complemento
    {
        get => complField;
        set
        {
            if (complField is null || complField.Equals(value) != true)
            {
                complField = value;
                OnPropertyChanged(nameof(Complemento));
            }
        }
    }

    [XmlElement("emit")]
    public Emitente Emitente
    {
        get => emitField;
        set
        {
            if (emitField is null || emitField.Equals(value) != true)
            {
                emitField = value;
                OnPropertyChanged(nameof(Emitente));
            }
        }
    }

    [XmlElement("toma3", typeof(TomadorTipo3))]
    [XmlElement("toma03", typeof(TomadorTipo03))]
    [XmlElement("toma4", typeof(TomadorTipo04))]
    [XmlElement("toma", typeof(CTeOS.Tomador))]
    public object Tomador
    {
        get => tomaField;
        set
        {
            if (tomaField is null || tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged(nameof(Tomador));
            }
        }
    }

    [XmlElement("rem")]
    public Remetente Remetente
    {
        get => remField;
        set
        {
            if (remField is null || remField.Equals(value) != true)
            {
                remField = value;
                OnPropertyChanged(nameof(Remetente));
            }
        }
    }

    /// <summary>
    /// Tomador do Serviço?
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("exped")]
    public Expedidor Expedidor
    {
        get => expedField;
        set
        {
            if (expedField is null || expedField.Equals(value) != true)
            {
                expedField = value;
                OnPropertyChanged(nameof(Expedidor));
            }
        }
    }

    [XmlElement("receb")]
    public Recebedor Recebedor
    {
        get => recebField;
        set
        {
            if (recebField is null || recebField.Equals(value) != true)
            {
                recebField = value;
                OnPropertyChanged(nameof(Recebedor));
            }
        }
    }

    [XmlElement("dest")]
    public Destinatario Destinatario
    {
        get => destField;
        set
        {
            if (destField is null || destField.Equals(value) != true)
            {
                destField = value;
                OnPropertyChanged(nameof(Destinatario));
            }
        }
    }

    [XmlElement("vPrest")]
    public ValoresPrestacaoServico Valores
    {
        get => vPrestField;
        set
        {
            if (vPrestField is null || vPrestField.Equals(value) != true)
            {
                vPrestField = value;
                OnPropertyChanged(nameof(Valores));
            }
        }
    }

    [XmlElement("imp")]
    public Impostos Impostos
    {
        get => impField;
        set
        {
            if (impField is null || impField.Equals(value) != true)
            {
                impField = value;
                OnPropertyChanged(nameof(Impostos));
            }
        }
    }

    [XmlIgnore()]
    public ICollection DocumentosReferenciados
    {
        get
        {
            if (Versao == "1.04")
            {
                return Remetente.DocumentosReferenciados;
            }
            else
            {
                var resultList = new List<object>();
                if (InformacaoCTePorTipo is InformacoesCteNormal)
                {
                    return ((InformacoesCteNormal)InformacaoCTePorTipo).infDoc.Items;
                }
                else if (InformacaoCTePorTipo is InformacoesCteAnulacao)
                {
                    resultList.Add((InformacoesCteAnulacao)InformacaoCTePorTipo);
                }
                else if (InformacaoCTePorTipo is InformacoesCteComplementado)
                {
                    resultList.Add((InformacoesCteComplementado)InformacaoCTePorTipo); // pra ler a chave
                }

                return resultList;
            }
        }
    }

    [XmlElement("infCTeNorm", typeof(InformacoesCteNormal))]
    [XmlElement("infCteAnu", typeof(InformacoesCteAnulacao))]
    [XmlElement("infCteComp", typeof(InformacoesCteComplementado))]
    public object InformacaoCTePorTipo
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(InformacaoCTePorTipo));
            }
        }
    }

    [XmlElement("autXML")]
    public ObservableCollection<AutorizadoXML> AutorizadosDownloadXML
    {
        get => autXMLField;
        set
        {
            if (autXMLField is null || autXMLField.Equals(value) != true)
            {
                autXMLField = value;
                OnPropertyChanged(nameof(AutorizadosDownloadXML));
            }
        }
    }

    [XmlAttribute("versao")]
    public string Versao
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged(nameof(Versao));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(InformacoesCTe));
            return sSerializer;
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
    public static bool CanDeserialize(string xml, ref InformacoesCTe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref InformacoesCTe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static InformacoesCTe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (InformacoesCTe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), InformacoesCTe)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static InformacoesCTe Deserialize(System.IO.Stream s) => (InformacoesCTe)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesCTe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref InformacoesCTe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static InformacoesCTe LoadFrom(System.IO.Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
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

    public static async Task<InformacoesCTe> LoadFromAsync(System.IO.Stream source)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
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

public partial class IdentificacaoOperacao : INotifyPropertyChanged
{

    private NFe.OrgaoIBGE cUFField;
    private string cCTField;
    private string cFOPField;
    private string natOpField;
    private FormaPagamento forPagField;
    private Modelo modField;
    private string serieField;
    private long? nCTField;
    private DateTime? dhEmiField;
    private FormatoImpressao tpImpField;
    private FormaEmissao tpEmisField;
    private string cDVField;
    private NFe.Ambiente tpAmbField;
    private TipoCTe tpCTeField;
    private ProcessoEmissao procEmiField;
    private string verProcField;
    private string refCTEField;
    private string cMunEnvField;
    private string xMunEnvField;
    private NFe.Estado uFEnvField;
    private ModalidadeTransporte modalField;
    private TiposServico tpServField;
    private string cMunIniField;
    private string xMunIniField;
    private NFe.Estado uFIniField;
    private string cMunFimField;
    private string xMunFimField;
    private NFe.Estado uFFimField;
    private Retira retiraField;
    private string xDetRetiraField;
    private object itemField;
    private DateTime? dhContField;
    private string xJustField;

    [XmlElement("cUF")]
    public NFe.OrgaoIBGE CodigoIBGE
    {
        get => cUFField;
        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged(nameof(CodigoIBGE));
            }
        }
    }

    [XmlElement("cCT")]
    public string Chave
    {
        get => cCTField;
        set
        {
            if (cCTField is null || cCTField.Equals(value) != true)
            {
                cCTField = value;
                OnPropertyChanged(nameof(Chave));
            }
        }
    }

    [XmlElement("CFOP")]
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

    [XmlElement("natOp")]
    public string NaturezaOperacao
    {
        get => natOpField;
        set
        {
            if (natOpField is null || natOpField.Equals(value) != true)
            {
                natOpField = value;
                OnPropertyChanged(nameof(NaturezaOperacao));
            }
        }
    }

    [XmlElement("forPag")]
    public FormaPagamento FormaPagamento
    {
        get => forPagField;
        set
        {
            if (forPagField.Equals(value) != true)
            {
                forPagField = value;
                OnPropertyChanged(nameof(FormaPagamento));
            }
        }
    }

    [XmlElement("mod")]
    public Modelo Modelo
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(Modelo));
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(Serie));
            }
        }
    }

    [XmlElement("nCT")]
    public long? Numero
    {
        get => nCTField;
        set
        {
            if (nCTField is null || nCTField.Equals(value) != true)
            {
                nCTField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    [XmlElement("dhEmi")]
    public DateTime? DataEmissao
    {
        get => dhEmiField;
        set
        {
            if (dhEmiField is null || dhEmiField.Equals(value) != true)
            {
                dhEmiField = value;
                OnPropertyChanged(nameof(DataEmissao));
            }
        }
    }

    public bool ShouldSerializeDataEmissao() => dhEmiField.HasValue;

    [XmlElement("tpImp")]
    public FormatoImpressao TipoImpressao
    {
        get => tpImpField;
        set
        {
            if (tpImpField.Equals(value) != true)
            {
                tpImpField = value;
                OnPropertyChanged(nameof(TipoImpressao));
            }
        }
    }

    [XmlElement("tpEmis")]
    public FormaEmissao FormaEmissao
    {
        get => tpEmisField;
        set
        {
            if (tpEmisField.Equals(value) != true)
            {
                tpEmisField = value;
                OnPropertyChanged(nameof(FormaEmissao));
            }
        }
    }

    [XmlElement("cDV")]
    public string DigitoVerificador
    {
        get => cDVField;
        set
        {
            if (cDVField is null || cDVField.Equals(value) != true)
            {
                cDVField = value;
                OnPropertyChanged("DigitoVerificado");
            }
        }
    }

    [XmlElement("tpAmb")]
    public NFe.Ambiente Ambiente
    {
        get => tpAmbField;
        set
        {
            if (tpAmbField.Equals(value) != true)
            {
                tpAmbField = value;
                OnPropertyChanged(nameof(Ambiente));
            }
        }
    }

    [XmlElement("tpCTe")]
    public TipoCTe Finalidade
    {
        get => tpCTeField;
        set
        {
            if (tpCTeField.Equals(value) != true)
            {
                tpCTeField = value;
                OnPropertyChanged("TipoCTe");
            }
        }
    }

    [XmlElement("procEmi")]
    public ProcessoEmissao ProcessoEmissao
    {
        get => procEmiField;
        set
        {
            if (procEmiField.Equals(value) != true)
            {
                procEmiField = value;
                OnPropertyChanged(nameof(ProcessoEmissao));
            }
        }
    }

    [XmlElement("verProc")]
    public string VersaoAplicativoEmissor
    {
        get => verProcField;
        set
        {
            if (verProcField is null || verProcField.Equals(value) != true)
            {
                verProcField = value;
                OnPropertyChanged(nameof(VersaoAplicativoEmissor));
            }
        }
    }

    [XmlElement("refCTE")]
    public string ChaveCteReferenciado
    {
        get => refCTEField;
        set
        {
            if (refCTEField is null || refCTEField.Equals(value) != true)
            {
                refCTEField = value;
                OnPropertyChanged(nameof(ChaveCteReferenciado));
            }
        }
    }

    [XmlElement("cMunEnv")]
    public string MunicipioEnvioCodigo
    {
        get => cMunEnvField;
        set
        {
            if (cMunEnvField is null || cMunEnvField.Equals(value) != true)
            {
                cMunEnvField = value;
                OnPropertyChanged(nameof(MunicipioEnvioCodigo));
            }
        }
    }

    [XmlElement("xMunEnv")]
    public string MunicipioEnvioNome
    {
        get => xMunEnvField;
        set
        {
            if (xMunEnvField is null || xMunEnvField.Equals(value) != true)
            {
                xMunEnvField = value;
                OnPropertyChanged(nameof(MunicipioEnvioNome));
            }
        }
    }

    [XmlElement("UFEnv")]
    public NFe.Estado UFEnvio
    {
        get => uFEnvField;
        set
        {
            if (uFEnvField.Equals(value) != true)
            {
                uFEnvField = value;
                OnPropertyChanged(nameof(UFEnvio));
            }
        }
    }

    [XmlElement("modal")]
    public ModalidadeTransporte Modalidade
    {
        get => modalField;
        set
        {
            if (modalField.Equals(value) != true)
            {
                modalField = value;
                OnPropertyChanged(nameof(Modalidade));
            }
        }
    }

    [XmlElement("tpServ")]
    public TiposServico TipoServico
    {
        get => tpServField;
        set
        {
            if (tpServField.Equals(value) != true)
            {
                tpServField = value;
                OnPropertyChanged(nameof(TipoServico));
            }
        }
    }

    [XmlElement("cMunIni")]
    public string MunicipioInicioCodigo
    {
        get => cMunIniField;
        set
        {
            if (cMunIniField is null || cMunIniField.Equals(value) != true)
            {
                cMunIniField = value;
                OnPropertyChanged(nameof(MunicipioInicioCodigo));
            }
        }
    }

    [XmlElement("xMunIni")]
    public string MunicipioInicioNome
    {
        get => xMunIniField;
        set
        {
            if (xMunIniField is null || xMunIniField.Equals(value) != true)
            {
                xMunIniField = value;
                OnPropertyChanged(nameof(MunicipioInicioNome));
            }
        }
    }

    [XmlElement("UFIni")]
    public NFe.Estado UFInicio
    {
        get => uFIniField;
        set
        {
            if (uFIniField.Equals(value) != true)
            {
                uFIniField = value;
                OnPropertyChanged(nameof(UFInicio));
            }
        }
    }

    [XmlElement("cMunFim")]
    public string MunicipioFimCodigo
    {
        get => cMunFimField;
        set
        {
            if (cMunFimField is null || cMunFimField.Equals(value) != true)
            {
                cMunFimField = value;
                OnPropertyChanged(nameof(MunicipioFimCodigo));
            }
        }
    }

    [XmlElement("xMunFim")]
    public string MunicipioFimNome
    {
        get => xMunFimField;
        set
        {
            if (xMunFimField is null || xMunFimField.Equals(value) != true)
            {
                xMunFimField = value;
                OnPropertyChanged(nameof(MunicipioFimNome));
            }
        }
    }

    [XmlElement("UFFim")]
    public NFe.Estado UFFim
    {
        get => uFFimField;
        set
        {
            if (uFFimField.Equals(value) != true)
            {
                uFFimField = value;
                OnPropertyChanged(nameof(UFFim));
            }
        }
    }

    [XmlElement("retira")]
    public Retira retira
    {
        get => retiraField;
        set
        {
            if (retiraField.Equals(value) != true)
            {
                retiraField = value;
                OnPropertyChanged(nameof(retira));
            }
        }
    }

    [XmlElement("xDetRetira")]
    public string xDetRetira
    {
        get => xDetRetiraField;
        set
        {
            if (xDetRetiraField is null || xDetRetiraField.Equals(value) != true)
            {
                xDetRetiraField = value;
                OnPropertyChanged(nameof(xDetRetira));
            }
        }
    }

    [XmlElement("toma3", typeof(TomadorTipo3))]
    [XmlElement("toma03", typeof(TomadorTipo03))]
    [XmlElement("toma4", typeof(TomadorTipo04))]
    [XmlElement("toma", typeof(CTeOS.Tomador))]
    public object Tomador
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Tomador));
            }
        }
    }

    [XmlElement("dhCont")]
    public DateTime? DataHoraContingencia
    {
        get => dhContField;
        set
        {
            if (dhContField is null || dhContField.Equals(value) != true)
            {
                dhContField = value;
                OnPropertyChanged(nameof(DataHoraContingencia));
            }
        }
    }

    public bool ShouldSerializeDataHoraContingencia() => dhContField.HasValue;

    [XmlElement("xJust")]
    public string JustificativaContingencia
    {
        get => xJustField;
        set
        {
            if (xJustField is null || xJustField.Equals(value) != true)
            {
                xJustField = value;
                OnPropertyChanged(nameof(JustificativaContingencia));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ProtocoloAutorizacao : INotifyPropertyChanged
{
    private TProtCTeInfProt infProtField;
    private SignatureType signatureField;
    private string versaoField;

    public ProtocoloAutorizacao() : base()
    {
        infProtField = new TProtCTeInfProt();
    }

    public TProtCTeInfProt infProt
    {
        get => infProtField;
        set
        {
            if (infProtField is null || infProtField.Equals(value) != true)
            {
                infProtField = value;
                OnPropertyChanged(nameof(infProt));
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
                OnPropertyChanged(nameof(Signature));
            }
        }
    }

    [XmlAttribute()]
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

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TProtCTeInfProt : INotifyPropertyChanged
{
    private NFe.Ambiente tpAmbField;
    private string verAplicField;
    private string chCTeField;
    private DateTime dhRecbtoField;
    private string nProtField;
    private byte[] digValField;
    private string cStatField;
    private string xMotivoField;
    private string idField;

    public NFe.Ambiente tpAmb
    {
        get => tpAmbField;
        set
        {
            if (tpAmbField.Equals(value) != true)
            {
                tpAmbField = value;
                OnPropertyChanged(nameof(tpAmb));
            }
        }
    }

    public string verAplic
    {
        get => verAplicField;
        set
        {
            if (verAplicField is null || verAplicField.Equals(value) != true)
            {
                verAplicField = value;
                OnPropertyChanged(nameof(verAplic));
            }
        }
    }

    public string chCTe
    {
        get => chCTeField;
        set
        {
            if (chCTeField is null || chCTeField.Equals(value) != true)
            {
                chCTeField = value;
                OnPropertyChanged(nameof(chCTe));
            }
        }
    }

    private string chave_codificada = null;

    [XmlIgnore]
    public string ChaveCTeCodificada => chave_codificada;

    private byte[] chaveArray;

    [XmlIgnore]
    public byte[] ChaveCTeCodificadaByte => chaveArray;

    public string ChaveCTeFormatada
    {
        get
        {
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i <= 10; i++)
            {
                builder.Append(chCTe.Substring(i * 4, 4));
                if (i < 10)
                {
                    builder.Append(" ");
                }
            }

            return builder.ToString();
        }
    }

    private byte[] _logo;

    [XmlIgnore()]
    public byte[] Logo
    {
        get => _logo;
        set
        {
            _logo = value;
            OnPropertyChanged(nameof(Logo));
        }
    }

    public DateTime dhRecbto
    {
        get => dhRecbtoField;
        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged(nameof(dhRecbto));
            }
        }
    }

    public string nProt
    {
        get => nProtField;
        set
        {
            if (nProtField is null || nProtField.Equals(value) != true)
            {
                nProtField = value;
                OnPropertyChanged(nameof(nProt));
            }
        }
    }

    [XmlElement(DataType = "base64Binary")]
    public byte[] digVal
    {
        get => digValField;
        set
        {
            if (digValField is null || digValField.Equals(value) != true)
            {
                digValField = value;
                OnPropertyChanged(nameof(digVal));
            }
        }
    }

    public string cStat
    {
        get => cStatField;
        set
        {
            if (cStatField is null || cStatField.Equals(value) != true)
            {
                cStatField = value;
                OnPropertyChanged(nameof(cStat));
            }
        }
    }

    public string xMotivo
    {
        get => xMotivoField;
        set
        {
            if (xMotivoField is null || xMotivoField.Equals(value) != true)
            {
                xMotivoField = value;
                OnPropertyChanged(nameof(xMotivo));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public void SetCodeBarRaw(string encodedString, byte[] encodedArray)
    {
        chave_codificada = encodedString;
        chaveArray = encodedArray;
    }
}

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
        get => signedInfoField;
        set
        {
            if (signedInfoField is null || signedInfoField.Equals(value) != true)
            {
                signedInfoField = value;
                OnPropertyChanged(nameof(SignedInfo));
            }
        }
    }

    public SignatureValueType SignatureValue
    {
        get => signatureValueField;
        set
        {
            if (signatureValueField is null || signatureValueField.Equals(value) != true)
            {
                signatureValueField = value;
                OnPropertyChanged(nameof(SignatureValue));
            }
        }
    }

    public KeyInfoType KeyInfo
    {
        get => keyInfoField;
        set
        {
            if (keyInfoField is null || keyInfoField.Equals(value) != true)
            {
                keyInfoField = value;
                OnPropertyChanged(nameof(KeyInfo));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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
        get => canonicalizationMethodField;
        set
        {
            if (canonicalizationMethodField is null || canonicalizationMethodField.Equals(value) != true)
            {
                canonicalizationMethodField = value;
                OnPropertyChanged(nameof(CanonicalizationMethod));
            }
        }
    }

    public SignedInfoTypeSignatureMethod SignatureMethod
    {
        get => signatureMethodField;
        set
        {
            if (signatureMethodField is null || signatureMethodField.Equals(value) != true)
            {
                signatureMethodField = value;
                OnPropertyChanged(nameof(SignatureMethod));
            }
        }
    }

    public ReferenceType Reference
    {
        get => referenceField;
        set
        {
            if (referenceField is null || referenceField.Equals(value) != true)
            {
                referenceField = value;
                OnPropertyChanged(nameof(Reference));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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
        get => algorithmField;
        set
        {
            if (algorithmField is null || algorithmField.Equals(value) != true)
            {
                algorithmField = value;
                OnPropertyChanged(nameof(Algorithm));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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
        get => algorithmField;
        set
        {
            if (algorithmField is null || algorithmField.Equals(value) != true)
            {
                algorithmField = value;
                OnPropertyChanged(nameof(Algorithm));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ReferenceType : INotifyPropertyChanged
{
    private ObservableCollection<TransformType> transformsField;
    private ReferenceTypeDigestMethod digestMethodField;
    private byte[] digestValueField;
    private string idField;
    private string uRIField;
    private string typeField;

    public ReferenceType() : base()
    {
        digestMethodField = new ReferenceTypeDigestMethod();
        transformsField = [];
    }

    [XmlArrayItem("Transform", IsNullable = false)]
    public ObservableCollection<TransformType> Transforms
    {
        get => transformsField;
        set
        {
            if (transformsField is null || transformsField.Equals(value) != true)
            {
                transformsField = value;
                OnPropertyChanged(nameof(Transforms));
            }
        }
    }

    public ReferenceTypeDigestMethod DigestMethod
    {
        get => digestMethodField;
        set
        {
            if (digestMethodField is null || digestMethodField.Equals(value) != true)
            {
                digestMethodField = value;
                OnPropertyChanged(nameof(DigestMethod));
            }
        }
    }

    [XmlElement(DataType = "base64Binary")]
    public byte[] DigestValue
    {
        get => digestValueField;
        set
        {
            if (digestValueField is null || digestValueField.Equals(value) != true)
            {
                digestValueField = value;
                OnPropertyChanged(nameof(DigestValue));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string URI
    {
        get => uRIField;
        set
        {
            if (uRIField is null || uRIField.Equals(value) != true)
            {
                uRIField = value;
                OnPropertyChanged(nameof(URI));
            }
        }
    }

    [XmlAttribute(DataType = "anyURI")]
    public string Type
    {
        get => typeField;
        set
        {
            if (typeField is null || typeField.Equals(value) != true)
            {
                typeField = value;
                OnPropertyChanged(nameof(Type));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TransformType : INotifyPropertyChanged
{
    private ObservableCollection<string> xPathField;
    private TTransformURI algorithmField;

    public TransformType() : base()
    {
        xPathField = [];
    }

    [XmlElement("XPath")]
    public ObservableCollection<string> XPath
    {
        get => xPathField;
        set
        {
            if (xPathField is null || xPathField.Equals(value) != true)
            {
                xPathField = value;
                OnPropertyChanged(nameof(XPath));
            }
        }
    }

    [XmlAttribute()]
    public TTransformURI Algorithm
    {
        get => algorithmField;
        set
        {
            if (algorithmField.Equals(value) != true)
            {
                algorithmField = value;
                OnPropertyChanged(nameof(Algorithm));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TTransformURI
{

    /// <remarks/>
    [XmlEnum("http://www.w3.org/2000/09/xmldsig#enveloped-signature")]
    httpwwww3org200009xmldsigenvelopedsignature,

    /// <remarks/>
    [XmlEnum("http://www.w3.org/TR/2001/REC-xml-c14n-20010315")]
    httpwwww3orgTR2001RECxmlc14n20010315
}

public partial class ReferenceTypeDigestMethod : INotifyPropertyChanged
{
    private string algorithmField;

    public ReferenceTypeDigestMethod() : base()
    {
        algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1";
    }

    [XmlAttribute(DataType = "anyURI")]
    public string Algorithm
    {
        get => algorithmField;
        set
        {
            if (algorithmField is null || algorithmField.Equals(value) != true)
            {
                algorithmField = value;
                OnPropertyChanged(nameof(Algorithm));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class SignatureValueType : INotifyPropertyChanged
{
    private string idField;
    private byte[] valueField;

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    [XmlText(DataType = "base64Binary")]
    public byte[] Value
    {
        get => valueField;
        set
        {
            if (valueField is null || valueField.Equals(value) != true)
            {
                valueField = value;
                OnPropertyChanged(nameof(Value));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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
        get => x509DataField;
        set
        {
            if (x509DataField is null || x509DataField.Equals(value) != true)
            {
                x509DataField = value;
                OnPropertyChanged(nameof(X509Data));
            }
        }
    }

    [XmlAttribute(DataType = "ID")]
    public string Id
    {
        get => idField;
        set
        {
            if (idField is null || idField.Equals(value) != true)
            {
                idField = value;
                OnPropertyChanged(nameof(Id));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class X509DataType : INotifyPropertyChanged
{
    private byte[] x509CertificateField;

    [XmlElement(DataType = "base64Binary")]
    public byte[] X509Certificate
    {
        get => x509CertificateField;
        set
        {
            if (x509CertificateField is null || x509CertificateField.Equals(value) != true)
            {
                x509CertificateField = value;
                OnPropertyChanged(nameof(X509Certificate));
            }
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TUnidCarga : INotifyPropertyChanged
{
    private TtipoUnidCarga tpUnidCargaField;
    private string idUnidCargaField;
    private ObservableCollection<TUnidCargaLacUnidCarga> lacUnidCargaField;
    private string qtdRatField;

    public TUnidCarga() : base()
    {
        lacUnidCargaField = [];
    }

    public TtipoUnidCarga tpUnidCarga
    {
        get => tpUnidCargaField;
        set
        {
            if (tpUnidCargaField.Equals(value) != true)
            {
                tpUnidCargaField = value;
                OnPropertyChanged(nameof(tpUnidCarga));
            }
        }
    }

    public string idUnidCarga
    {
        get => idUnidCargaField;
        set
        {
            if (idUnidCargaField is null || idUnidCargaField.Equals(value) != true)
            {
                idUnidCargaField = value;
                OnPropertyChanged(nameof(idUnidCarga));
            }
        }
    }

    [XmlElement("lacUnidCarga")]
    public ObservableCollection<TUnidCargaLacUnidCarga> lacUnidCarga
    {
        get => lacUnidCargaField;
        set
        {
            if (lacUnidCargaField is null || lacUnidCargaField.Equals(value) != true)
            {
                lacUnidCargaField = value;
                OnPropertyChanged(nameof(lacUnidCarga));
            }
        }
    }

    public string qtdRat
    {
        get => qtdRatField;
        set
        {
            if (qtdRatField is null || qtdRatField.Equals(value) != true)
            {
                qtdRatField = value;
                OnPropertyChanged(nameof(qtdRat));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TtipoUnidCarga
{

    /// <remarks/>
    [XmlEnum("1")]
    Item1,

    /// <remarks/>
    [XmlEnum("2")]
    Item2,

    /// <remarks/>
    [XmlEnum("3")]
    Item3,

    /// <remarks/>
    [XmlEnum("4")]
    Item4
}

public partial class TUnidCargaLacUnidCarga : INotifyPropertyChanged
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

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TUnidadeTransp : INotifyPropertyChanged
{
    private TtipoUnidTransp tpUnidTranspField;
    private string idUnidTranspField;
    private ObservableCollection<TUnidadeTranspLacUnidTransp> lacUnidTranspField;
    private ObservableCollection<TUnidCarga> infUnidCargaField;
    private string qtdRatField;

    public TUnidadeTransp() : base()
    {
        infUnidCargaField = [];
        lacUnidTranspField = [];
    }

    public TtipoUnidTransp tpUnidTransp
    {
        get => tpUnidTranspField;
        set
        {
            if (tpUnidTranspField.Equals(value) != true)
            {
                tpUnidTranspField = value;
                OnPropertyChanged(nameof(tpUnidTransp));
            }
        }
    }

    public string idUnidTransp
    {
        get => idUnidTranspField;
        set
        {
            if (idUnidTranspField is null || idUnidTranspField.Equals(value) != true)
            {
                idUnidTranspField = value;
                OnPropertyChanged(nameof(idUnidTransp));
            }
        }
    }

    [XmlElement("lacUnidTransp")]
    public ObservableCollection<TUnidadeTranspLacUnidTransp> lacUnidTransp
    {
        get => lacUnidTranspField;
        set
        {
            if (lacUnidTranspField is null || lacUnidTranspField.Equals(value) != true)
            {
                lacUnidTranspField = value;
                OnPropertyChanged(nameof(lacUnidTransp));
            }
        }
    }

    [XmlElement("infUnidCarga")]
    public ObservableCollection<TUnidCarga> infUnidCarga
    {
        get => infUnidCargaField;
        set
        {
            if (infUnidCargaField is null || infUnidCargaField.Equals(value) != true)
            {
                infUnidCargaField = value;
                OnPropertyChanged(nameof(infUnidCarga));
            }
        }
    }

    public string qtdRat
    {
        get => qtdRatField;
        set
        {
            if (qtdRatField is null || qtdRatField.Equals(value) != true)
            {
                qtdRatField = value;
                OnPropertyChanged(nameof(qtdRat));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TtipoUnidTransp
{

    /// <remarks/>
    [XmlEnum("1")]
    Item1,

    /// <remarks/>
    [XmlEnum("2")]
    Item2,

    /// <remarks/>
    [XmlEnum("3")]
    Item3,

    /// <remarks/>
    [XmlEnum("4")]
    Item4,

    /// <remarks/>
    [XmlEnum("5")]
    Item5,

    /// <remarks/>
    [XmlEnum("6")]
    Item6,

    /// <remarks/>
    [XmlEnum("7")]
    Item7
}

public partial class TUnidadeTranspLacUnidTransp : INotifyPropertyChanged
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

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ICMS : INotifyPropertyChanged
{
    private DetalhamentoICMS itemField;
    private Tributacao_ICMS_Identifier itemElementNameField;

    [XmlElement("ICMS00", typeof(DetalhamentoICMS))]
    [XmlElement("ICMS20", typeof(DetalhamentoICMS))]
    [XmlElement("ICMS45", typeof(DetalhamentoICMS))]
    [XmlElement("ICMS60", typeof(DetalhamentoICMS))]
    [XmlElement("ICMS90", typeof(DetalhamentoICMS))]
    [XmlElement("ICMSOutraUF", typeof(DetalhamentoICMS))]
    [XmlElement("ICMSSN", typeof(DetalhamentoICMS))]
    [XmlElement("CST00", typeof(DetalhamentoICMS))]
    [XmlElement("CST20", typeof(DetalhamentoICMS))]
    [XmlElement("CST45", typeof(DetalhamentoICMS))]
    [XmlElement("CST60", typeof(DetalhamentoICMS))]
    [XmlElement("CST90", typeof(DetalhamentoICMS))]
    [XmlChoiceIdentifier("TributacaoIndentifier")]
    public DetalhamentoICMS Tributacao
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public Tributacao_ICMS_Identifier TributacaoIndentifier
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(TributacaoIndentifier));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public class InftributosFederais : INotifyPropertyChanged
{
    private double? _vINSS;

    public double? vINSS
    {
        get => _vINSS;
        set
        {
            if (_vINSS is null || _vINSS.Equals(value) != true)
            {
                _vINSS = value;
                OnPropertyChanged(nameof(vINSS));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoICMS : INotifyPropertyChanged
{

    private NFe.CST_ICMS cSTField;
    private double? vBCField;
    private double? pRedBCField;
    private double? pICMSField;
    private double? vICMSField;
    private double? vBCSTRetField;
    private double? vICMSSTRetField;
    private double? pICMSSTRetField;
    private double? vCredField;
    private double? pRedBCOutraUFField;
    private double? vBCOutraUFField;
    private double? pICMSOutraUFField;
    private double? vICMSOutraUFField;
    private DetalhamentoICMSIndicadorSN indSNField;

    public NFe.CST_ICMS CST
    {
        get => cSTField;
        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged(nameof(CST));
            }
        }
    }

    public double? vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public bool ShouldSerializevBC() => vBCField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);

    public double? pRedBC
    {
        get => pRedBCField;
        set
        {
            if (pRedBCField is null || pRedBCField.Equals(value) != true)
            {
                pRedBCField = value;
                OnPropertyChanged(nameof(pRedBC));
            }
        }
    }

    public bool ShouldSerializepRedBC() => pRedBCField.HasValue & (CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);

    public double? pICMS
    {
        get => pICMSField;
        set
        {
            if (pICMSField is null || pICMSField.Equals(value) != true)
            {
                pICMSField = value;
                OnPropertyChanged(nameof(pICMS));
            }
        }
    }

    public bool ShouldSerializepICMS() => pICMSField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);

    public double? vICMS
    {
        get => vICMSField;
        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged(nameof(vICMS));
            }
        }
    }

    public bool ShouldSerializevICMS() => vICMSField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);

    public double? vBCSTRet
    {
        get => vBCSTRetField;
        set
        {
            if (vBCSTRetField is null || vBCSTRetField.Equals(value) != true)
            {
                vBCSTRetField = value;
                OnPropertyChanged(nameof(vBCSTRet));
            }
        }
    }

    public bool ShouldSerializevBCSTRet() => vBCSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;

    public double? vICMSSTRet
    {
        get => vICMSSTRetField;
        set
        {
            if (vICMSSTRetField is null || vICMSSTRetField.Equals(value) != true)
            {
                vICMSSTRetField = value;
                OnPropertyChanged(nameof(vICMSSTRet));
            }
        }
    }

    public bool ShouldSerializevICMSSTRet() => vICMSSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;

    public double? pICMSSTRet
    {
        get => pICMSSTRetField;
        set
        {
            if (pICMSSTRetField is null || pICMSSTRetField.Equals(value) != true)
            {
                pICMSSTRetField = value;
                OnPropertyChanged(nameof(pICMSSTRet));
            }
        }
    }

    public bool ShouldSerializepICMSSTRet() => pICMSSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;

    public double? vCred
    {
        get => vCredField;
        set
        {
            if (vCredField is null || vCredField.Equals(value) != true)
            {
                vCredField = value;
                OnPropertyChanged(nameof(vCred));
            }
        }
    }

    public bool ShouldSerializevCred() => vCredField.HasValue & (CST == NFe.CST_ICMS.CST_60 | CST == NFe.CST_ICMS.CST_90);

    public double? pRedBCOutraUF
    {
        get => pRedBCOutraUFField;
        set
        {
            if (pRedBCOutraUFField is null || pRedBCOutraUFField.Equals(value) != true)
            {
                pRedBCOutraUFField = value;
                OnPropertyChanged(nameof(pRedBCOutraUF));
            }
        }
    }

    public bool ShouldSerializepRedBCOutraUF() => pRedBCOutraUFField.HasValue;

    public string vBCOutraUF
    {
        get => vBCOutraUFField?.ToString();
        set
        {
            if (vBCOutraUFField is null || vBCOutraUFField.Equals(value) != true)
            {
                vBCOutraUFField = value.ToNullableDouble();
                OnPropertyChanged(nameof(vBCOutraUF));
            }
        }
    }

    public bool ShouldSerializevBCOutraUF() => vBCOutraUFField.HasValue;

    public string pICMSOutraUF
    {
        get => pICMSOutraUFField.ToString();
        set
        {
            if (pICMSOutraUFField is null || pICMSOutraUFField.Equals(value) != true)
            {
                pICMSOutraUFField = value.ToNullableDouble();
                OnPropertyChanged(nameof(pICMSOutraUF));
            }
        }
    }

    public bool ShouldSerializepICMSOutraUF() => pICMSOutraUFField.HasValue;

    public string vICMSOutraUF
    {
        get => vICMSOutraUFField.ToString();
        set
        {
            if (vICMSOutraUFField is null || vICMSOutraUFField.Equals(value) != true)
            {
                vICMSOutraUFField = value.ToNullableDouble();
                OnPropertyChanged(nameof(vICMSOutraUF));
            }
        }
    }

    public bool ShouldSerializevICMSOutraUF() => vICMSOutraUFField.HasValue;

    public DetalhamentoICMSIndicadorSN indSN
    {
        get => indSNField;
        set
        {
            if (indSNField.Equals(value) != true)
            {
                indSNField = value;
                OnPropertyChanged(nameof(indSN));
            }
        }
    }

    public bool ShouldSerializeindSN() => vCredField.HasValue == false & CST != NFe.CST_ICMS.CST_60 & CST != NFe.CST_ICMS.CST_90;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler PropertyChanged;
}

public partial class TEndReEnt : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string xNomeField;
    private string xLgrField;
    private string nroField;
    private string xCplField;
    private string xBairroField;
    private string cMunField;
    private string xMunField;
    private NFe.Estado ufField;

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string xLgr
    {
        get => xLgrField;
        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged(nameof(xLgr));
            }
        }
    }

    public string nro
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(nro));
            }
        }
    }

    public string xCpl
    {
        get => xCplField;
        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged(nameof(xCpl));
            }
        }
    }

    public string xBairro
    {
        get => xBairroField;
        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged(nameof(xBairro));
            }
        }
    }

    public string cMun
    {
        get => cMunField;
        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged(nameof(cMun));
            }
        }
    }

    public string xMun
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(xMun));
            }
        }
    }

    public NFe.Estado UF
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

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TEndeEmi : INotifyPropertyChanged
{
    private string xLgrField;
    private string nroField;
    private string xCplField;
    private string xBairroField;
    private string cMunField;
    private string xMunField;
    private string cEPField;
    private TUF_sem_EX ufField;
    private string foneField;

    public string xLgr
    {
        get => xLgrField;
        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged(nameof(xLgr));
            }
        }
    }

    public string nro
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(nro));
            }
        }
    }

    public string xCpl
    {
        get => xCplField;
        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged(nameof(xCpl));
            }
        }
    }

    public string xBairro
    {
        get => xBairroField;
        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged(nameof(xBairro));
            }
        }
    }

    public string cMun
    {
        get => cMunField;
        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged(nameof(cMun));
            }
        }
    }

    public string xMun
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(xMun));
            }
        }
    }

    public string CEP
    {
        get => cEPField;
        set
        {
            if (cEPField is null || cEPField.Equals(value) != true)
            {
                cEPField = value;
                OnPropertyChanged(nameof(CEP));
            }
        }
    }

    public TUF_sem_EX UF
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

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TUF_sem_EX
{

    /// <remarks/>
    AC,

    /// <remarks/>
    AL,

    /// <remarks/>
    AM,

    /// <remarks/>
    AP,

    /// <remarks/>
    BA,

    /// <remarks/>
    CE,

    /// <remarks/>
    DF,

    /// <remarks/>
    ES,

    /// <remarks/>
    GO,

    /// <remarks/>
    MA,

    /// <remarks/>
    MG,

    /// <remarks/>
    MS,

    /// <remarks/>
    MT,

    /// <remarks/>
    PA,

    /// <remarks/>
    PB,

    /// <remarks/>
    PE,

    /// <remarks/>
    PI,

    /// <remarks/>
    PR,

    /// <remarks/>
    RJ,

    /// <remarks/>
    RN,

    /// <remarks/>
    RO,

    /// <remarks/>
    RR,

    /// <remarks/>
    RS,

    /// <remarks/>
    SC,

    /// <remarks/>
    SE,

    /// <remarks/>
    SP,

    /// <remarks/>
    TO
}

public partial class Endereco : INotifyPropertyChanged
{
    private string xLgrField;
    private string nroField;
    private string xCplField;
    private string xBairroField;
    private string cMunField;
    private string xMunField;
    private string cEPField;
    private NFe.Estado ufField;
    private string cPaisField;
    private string xPaisField;
    private string fonefield;

    public string xLgr
    {
        get => xLgrField;
        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged(nameof(xLgr));
            }
        }
    }

    public string nro
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(nro));
            }
        }
    }

    public string xCpl
    {
        get => xCplField;
        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged(nameof(xCpl));
            }
        }
    }

    public string xBairro
    {
        get => xBairroField;
        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged(nameof(xBairro));
            }
        }
    }

    public string cMun
    {
        get => cMunField;
        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged(nameof(cMun));
            }
        }
    }

    public string xMun
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(xMun));
            }
        }
    }

    public string CEP
    {
        get => cEPField;
        set
        {
            if (cEPField is null || cEPField.Equals(value) != true)
            {
                cEPField = value;
                OnPropertyChanged(nameof(CEP));
                OnPropertyChanged(nameof(CEPFormatado));
            }
        }
    }

    public string CEPFormatado
    {
        get
        {
            if (CEP != null)
            {
                return CEP.FormatCEP();
            }
            else
            {
                return CEP;
            }
            // Return CEPFormatado
        }
    }

    public NFe.Estado UF
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

    public string cPais
    {
        get => cPaisField;
        set
        {
            if (cPaisField is null || cPaisField.Equals(value) != true)
            {
                cPaisField = value;
                OnPropertyChanged(nameof(cPais));
            }
        }
    }

    public string xPais
    {
        get => xPaisField;
        set
        {
            if (xPaisField is null || xPaisField.Equals(value) != true)
            {
                xPaisField = value;
                OnPropertyChanged(nameof(xPais));
            }
        }
    }

    public string fone
    {
        get => fonefield;
        set
        {
            if (fonefield is null || fonefield.Equals(value) != true)
            {
                fonefield = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public NFe.Endereco CloneToEnderecoNFe()
    {
        var ender = new NFe.Endereco();
        ender.Bairro = xBairro;
        ender.CEP = CEP;
        ender.Complemento = xCpl;
        ender.Logradouro = xLgr;
        ender.MunicipioCodigo = cMun;
        ender.MunicipioNome = xMun;
        ender.Numero = nro;
        ender.PaisCodigo = cPais;
        ender.PaisNome = xPais;
        ender.UF = UF;
        return ender;
    }
}

public partial class ComplementoCTe : INotifyPropertyChanged
{
    private string xCaracAdField;
    private string xCaracSerField;
    private string xEmiField;
    private TCTeInfCteComplFluxo fluxoField;
    private TCTeInfCteComplEntrega entregaField;
    private string origCalcField;
    private string destCalcField;
    private string xObsField;
    private ObservableCollection<TCTeInfCteComplObsCont> obsContField;
    private ObservableCollection<TCTeInfCteComplObsFisco> obsFiscoField;

    public ComplementoCTe() : base()
    {
        obsFiscoField = [];
        obsContField = [];
        entregaField = new TCTeInfCteComplEntrega();
        fluxoField = new TCTeInfCteComplFluxo();
    }

    public string xCaracAd
    {
        get => xCaracAdField;
        set
        {
            if (xCaracAdField is null || xCaracAdField.Equals(value) != true)
            {
                xCaracAdField = value;
                OnPropertyChanged(nameof(xCaracAd));
            }
        }
    }

    public string xCaracSer
    {
        get => xCaracSerField;
        set
        {
            if (xCaracSerField is null || xCaracSerField.Equals(value) != true)
            {
                xCaracSerField = value;
                OnPropertyChanged(nameof(xCaracSer));
            }
        }
    }

    public string xEmi
    {
        get => xEmiField;
        set
        {
            if (xEmiField is null || xEmiField.Equals(value) != true)
            {
                xEmiField = value;
                OnPropertyChanged(nameof(xEmi));
            }
        }
    }

    public TCTeInfCteComplFluxo fluxo
    {
        get => fluxoField;
        set
        {
            if (fluxoField is null || fluxoField.Equals(value) != true)
            {
                fluxoField = value;
                OnPropertyChanged(nameof(fluxo));
            }
        }
    }

    public TCTeInfCteComplEntrega Entrega
    {
        get => entregaField;
        set
        {
            if (entregaField is null || entregaField.Equals(value) != true)
            {
                entregaField = value;
                OnPropertyChanged(nameof(Entrega));
            }
        }
    }

    public string origCalc
    {
        get => origCalcField;
        set
        {
            if (origCalcField is null || origCalcField.Equals(value) != true)
            {
                origCalcField = value;
                OnPropertyChanged(nameof(origCalc));
            }
        }
    }

    public string destCalc
    {
        get => destCalcField;
        set
        {
            if (destCalcField is null || destCalcField.Equals(value) != true)
            {
                destCalcField = value;
                OnPropertyChanged(nameof(destCalc));
            }
        }
    }

    public string xObs
    {
        get => xObsField;
        set
        {
            if (xObsField is null || xObsField.Equals(value) != true)
            {
                xObsField = value;
                OnPropertyChanged(nameof(xObs));
            }
        }
    }

    [XmlElement("ObsCont")]
    public ObservableCollection<TCTeInfCteComplObsCont> ObsCont
    {
        get => obsContField;
        set
        {
            if (obsContField is null || obsContField.Equals(value) != true)
            {
                obsContField = value;
                OnPropertyChanged(nameof(ObsCont));
            }
        }
    }

    [XmlElement("ObsFisco")]
    public ObservableCollection<TCTeInfCteComplObsFisco> ObsFisco
    {
        get => obsFiscoField;
        set
        {
            if (obsFiscoField is null || obsFiscoField.Equals(value) != true)
            {
                obsFiscoField = value;
                OnPropertyChanged(nameof(ObsFisco));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteComplFluxo : INotifyPropertyChanged
{
    private string xOrigField;
    private ObservableCollection<TCTeInfCteComplFluxoPass> passField;
    private string xDestField;
    private string xRotaField;

    public TCTeInfCteComplFluxo() : base()
    {
        passField = [];
    }

    public string xOrig
    {
        get => xOrigField;
        set
        {
            if (xOrigField is null || xOrigField.Equals(value) != true)
            {
                xOrigField = value;
                OnPropertyChanged(nameof(xOrig));
            }
        }
    }

    [XmlElement("pass")]
    public ObservableCollection<TCTeInfCteComplFluxoPass> pass
    {
        get => passField;
        set
        {
            if (passField is null || passField.Equals(value) != true)
            {
                passField = value;
                OnPropertyChanged(nameof(pass));
            }
        }
    }

    public string xDest
    {
        get => xDestField;
        set
        {
            if (xDestField is null || xDestField.Equals(value) != true)
            {
                xDestField = value;
                OnPropertyChanged(nameof(xDest));
            }
        }
    }

    public string xRota
    {
        get => xRotaField;
        set
        {
            if (xRotaField is null || xRotaField.Equals(value) != true)
            {
                xRotaField = value;
                OnPropertyChanged(nameof(xRota));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteComplFluxoPass : INotifyPropertyChanged
{
    private string xPassField;

    public string xPass
    {
        get => xPassField;
        set
        {
            if (xPassField is null || xPassField.Equals(value) != true)
            {
                xPassField = value;
                OnPropertyChanged(nameof(xPass));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteComplEntrega : INotifyPropertyChanged
{
    private object itemField;
    private object item1Field;

    [XmlElement("comData", typeof(TCTeInfCteComplEntregaComData))]
    [XmlElement("noPeriodo", typeof(TCTeInfCteComplEntregaNoPeriodo))]
    [XmlElement("semData", typeof(TCTeInfCteComplEntregaSemData))]
    public object Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlElement("comHora", typeof(TCTeInfCteComplEntregaComHora))]
    [XmlElement("noInter", typeof(TCTeInfCteComplEntregaNoInter))]
    [XmlElement("semHora", typeof(TCTeInfCteComplEntregaSemHora))]
    public object Item1
    {
        get => item1Field;
        set
        {
            if (item1Field is null || item1Field.Equals(value) != true)
            {
                item1Field = value;
                OnPropertyChanged(nameof(Item1));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteComplEntregaComData : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaComDataTpPer tpPerField;
    private string dProgField;

    public TCTeInfCteComplEntregaComDataTpPer tpPer
    {
        get => tpPerField;
        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged(nameof(tpPer));
            }
        }
    }

    public string dProg
    {
        get => dProgField;
        set
        {
            if (dProgField is null || dProgField.Equals(value) != true)
            {
                dProgField = value;
                OnPropertyChanged(nameof(dProg));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaComDataTpPer
{

    /// <remarks/>
    [XmlEnum("1")]
    Item1,

    /// <remarks/>
    [XmlEnum("2")]
    Item2,

    /// <remarks/>
    [XmlEnum("3")]
    Item3
}

public partial class TCTeInfCteComplEntregaNoPeriodo : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaNoPeriodoTpPer tpPerField;
    private string dIniField;
    private string dFimField;

    public TCTeInfCteComplEntregaNoPeriodoTpPer tpPer
    {
        get => tpPerField;
        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged(nameof(tpPer));
            }
        }
    }

    public string dIni
    {
        get => dIniField;
        set
        {
            if (dIniField is null || dIniField.Equals(value) != true)
            {
                dIniField = value;
                OnPropertyChanged(nameof(dIni));
            }
        }
    }

    public string dFim
    {
        get => dFimField;
        set
        {
            if (dFimField is null || dFimField.Equals(value) != true)
            {
                dFimField = value;
                OnPropertyChanged(nameof(dFim));
            }
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaNoPeriodoTpPer
{

    /// <remarks/>
    [XmlEnum("4")]
    Item4
}

public partial class TCTeInfCteComplEntregaSemData : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaSemDataTpPer tpPerField;

    public TCTeInfCteComplEntregaSemDataTpPer tpPer
    {
        get => tpPerField;
        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged(nameof(tpPer));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaSemDataTpPer
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0
}

public partial class TCTeInfCteComplEntregaComHora : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaComHoraTpHor tpHorField;
    private string hProgField;

    public TCTeInfCteComplEntregaComHoraTpHor tpHor
    {
        get => tpHorField;
        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged(nameof(tpHor));
            }
        }
    }

    public string hProg
    {
        get => hProgField;
        set
        {
            if (hProgField is null || hProgField.Equals(value) != true)
            {
                hProgField = value;
                OnPropertyChanged(nameof(hProg));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaComHoraTpHor
{

    /// <remarks/>
    [XmlEnum("1")]
    Item1,

    /// <remarks/>
    [XmlEnum("2")]
    Item2,

    /// <remarks/>
    [XmlEnum("3")]
    Item3
}

public partial class TCTeInfCteComplEntregaNoInter : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaNoInterTpHor tpHorField;
    private string hIniField;
    private string hFimField;

    public TCTeInfCteComplEntregaNoInterTpHor tpHor
    {
        get => tpHorField;
        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged(nameof(tpHor));
            }
        }
    }

    public string hIni
    {
        get => hIniField;
        set
        {
            if (hIniField is null || hIniField.Equals(value) != true)
            {
                hIniField = value;
                OnPropertyChanged(nameof(hIni));
            }
        }
    }

    public string hFim
    {
        get => hFimField;
        set
        {
            if (hFimField is null || hFimField.Equals(value) != true)
            {
                hFimField = value;
                OnPropertyChanged(nameof(hFim));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaNoInterTpHor
{

    /// <remarks/>
    [XmlEnum("4")]
    Item4
}

public partial class TCTeInfCteComplEntregaSemHora : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaSemHoraTpHor tpHorField;

    public TCTeInfCteComplEntregaSemHoraTpHor tpHor
    {
        get => tpHorField;
        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged(nameof(tpHor));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteComplEntregaSemHoraTpHor
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0
}

public partial class TCTeInfCteComplObsCont : INotifyPropertyChanged
{
    private string xTextoField;
    private string xCampoField;

    public string xTexto
    {
        get => xTextoField;
        set
        {
            if (xTextoField is null || xTextoField.Equals(value) != true)
            {
                xTextoField = value;
                OnPropertyChanged(nameof(xTexto));
            }
        }
    }

    [XmlAttribute()]
    public string xCampo
    {
        get => xCampoField;
        set
        {
            if (xCampoField is null || xCampoField.Equals(value) != true)
            {
                xCampoField = value;
                OnPropertyChanged(nameof(xCampo));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteComplObsFisco : INotifyPropertyChanged
{
    private string xTextoField;
    private string xCampoField;

    public string xTexto
    {
        get => xTextoField;
        set
        {
            if (xTextoField is null || xTextoField.Equals(value) != true)
            {
                xTextoField = value;
                OnPropertyChanged(nameof(xTexto));
            }
        }
    }

    [XmlAttribute()]
    public string xCampo
    {
        get => xCampoField;
        set
        {
            if (xCampoField is null || xCampoField.Equals(value) != true)
            {
                xCampoField = value;
                OnPropertyChanged(nameof(xCampo));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Emitente : INotifyPropertyChanged
{
    private string cNPJField;
    private string ieField;
    private string xNomeField;
    private string xFantField;
    private Endereco enderEmitField;

    public Emitente() : base()
    {
        enderEmitField = new Endereco();
    }

    public string CNPJ
    {
        get => cNPJField;
        set
        {
            if (cNPJField is null || cNPJField.Equals(value) != true)
            {
                cNPJField = value;
                OnPropertyChanged(nameof(CNPJ));
            }
        }
    }

    [XmlIgnore()]
    public string CNPJ_Formatado
    {
        get
        {
            if (CNPJ != null)
            {
                return CNPJ.FormatRFBDocument();
            }
            else
            {
                return null;
            }
        }
    }

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string xFant
    {
        get => xFantField;
        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged(nameof(xFant));
            }
        }
    }

    [XmlElement("enderEmit")]
    public Endereco Endereco
    {
        get => enderEmitField;
        set
        {
            if (enderEmitField is null || enderEmitField.Equals(value) != true)
            {
                enderEmitField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Remetente : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string xFantField;
    private string foneField;
    private Endereco enderRemeField;
    private string emailField;
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNF> infNFField = [];
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNFe> infNFeField = [];
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfOutros> infOutrsField = [];
    private TEndReEnt locColetaField;

    public Remetente() : base()
    {
        // Me.locColetaField = New TEndReEnt()
        enderRemeField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string xFant
    {
        get => xFantField;
        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged(nameof(xFant));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    [XmlElement("enderReme")]
    public Endereco Endereco
    {
        get => enderRemeField;
        set
        {
            if (enderRemeField is null || enderRemeField.Equals(value) != true)
            {
                enderRemeField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(email));
            }
        }
    }

    [XmlElement("infNF")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNF> InfNF
    {
        get => infNFField;
        set
        {
            infNFField = value;
            OnPropertyChanged(nameof(InfNF));
        }
    }

    [XmlElement("infNFe")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNFe> InfNFe
    {
        get => infNFeField;
        set
        {
            infNFeField = value;
            OnPropertyChanged(nameof(InfNFe));
        }
    }

    [XmlIgnore()]
    public ICollection DocumentosReferenciados
    {
        get
        {
            var tmp = new List<object>();
            tmp.AddRange(InfNF);
            tmp.AddRange(InfNFe);
            tmp.AddRange(infOutros);
            return tmp;
        }
    }

    [XmlElement("infOutros")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfDocInfOutros> infOutros
    {
        get => infOutrsField;
        set
        {
            infOutrsField = value;
            OnPropertyChanged(nameof(infOutros));
        }
    }

    public TEndReEnt locColeta
    {
        get => locColetaField;
        set
        {
            if (locColetaField is null || locColetaField.Equals(value) != true)
            {
                locColetaField = value;
                OnPropertyChanged(nameof(locColeta));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Expedidor : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string foneField;
    private Endereco enderExpedField;
    private string emailField;

    public Expedidor() : base()
    {
        enderExpedField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    [XmlElement("enderExped")]
    public Endereco Endereco
    {
        get => enderExpedField;
        set
        {
            if (enderExpedField is null || enderExpedField.Equals(value) != true)
            {
                enderExpedField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(email));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Recebedor : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string foneField;
    private Endereco enderRecebField;
    private string emailField;

    public Recebedor() : base()
    {
        enderRecebField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    public Endereco enderReceb
    {
        get => enderRecebField;
        set
        {
            if (enderRecebField is null || enderRecebField.Equals(value) != true)
            {
                enderRecebField = value;
                OnPropertyChanged(nameof(enderReceb));
            }
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(email));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Destinatario : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string foneField;
    private string iSUFField;
    private Endereco enderDestField;
    private string emailField;
    private TEndReEnt locEntField;

    public Destinatario() : base()
    {
        locEntField = new TEndReEnt();
        enderDestField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    public string ISUF
    {
        get => iSUFField;
        set
        {
            if (iSUFField is null || iSUFField.Equals(value) != true)
            {
                iSUFField = value;
                OnPropertyChanged(nameof(ISUF));
            }
        }
    }

    [XmlElement("enderDest")]
    public Endereco Endereco
    {
        get => enderDestField;
        set
        {
            if (enderDestField is null || enderDestField.Equals(value) != true)
            {
                enderDestField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(email));
            }
        }
    }

    public TEndReEnt locEnt
    {
        get => locEntField;
        set
        {
            if (locEntField is null || locEntField.Equals(value) != true)
            {
                locEntField = value;
                OnPropertyChanged(nameof(locEnt));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TomadorTipo03 : INotifyPropertyChanged
{
    private TipoTomador tomaField;

    public TipoTomador toma
    {
        get => tomaField;
        set
        {
            if (tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged(nameof(toma));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TomadorTipo3 : TomadorTipo03
{
}

public partial class TomadorTipo04 : INotifyPropertyChanged
{
    private TipoTomador tomaField;
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string xFantField;
    private string foneField;
    private Endereco enderTomaField;
    private string emailField;

    public TomadorTipo04() : base()
    {
        enderTomaField = new Endereco();
    }

    public TipoTomador toma
    {
        get => tomaField;
        set
        {
            if (tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged(nameof(toma));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
    {
        get => itemElementNameField;
        set => itemElementNameField = value;
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public string xFant
    {
        get => xFantField;
        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged(nameof(xFant));
            }
        }
    }

    public string fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(fone));
            }
        }
    }

    [XmlElement("enderToma")]
    public Endereco Endereco
    {
        get => enderTomaField;
        set
        {
            if (enderTomaField is null || enderTomaField.Equals(value) != true)
            {
                enderTomaField = value;
                OnPropertyChanged(nameof(Endereco));
            }
        }
    }

    public string email
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(email));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ValoresPrestacaoServico : INotifyPropertyChanged
{
    private double? vTPrestField;
    private double? vRecField;
    private ObservableCollection<TCTeInfCteVPrestComp> compField;

    public ValoresPrestacaoServico() : base()
    {
        compField = [];
    }

    public double? vTPrest
    {
        get => vTPrestField;
        set
        {
            if (vTPrestField is null || vTPrestField.Equals(value) != true)
            {
                vTPrestField = value;
                OnPropertyChanged(nameof(vTPrest));
            }
        }
    }

    public double? vRec
    {
        get => vRecField;
        set
        {
            if (vRecField is null || vRecField.Equals(value) != true)
            {
                vRecField = value;
                OnPropertyChanged(nameof(vRec));
            }
        }
    }

    [XmlElement("Comp")]
    public ObservableCollection<TCTeInfCteVPrestComp> Comp
    {
        get => compField;
        set
        {
            if (compField is null || compField.Equals(value) != true)
            {
                compField = value;
                OnPropertyChanged(nameof(Comp));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteVPrestComp : INotifyPropertyChanged
{
    private string xNomeField;
    private double? vCompField;

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    public double? vComp
    {
        get => vCompField;
        set
        {
            if (vCompField is null || vCompField.Equals(value) != true)
            {
                vCompField = value;
                OnPropertyChanged(nameof(vComp));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Impostos : INotifyPropertyChanged
{
    private ICMS iCMSField;
    private InftributosFederais federaisField;
    private double? vTotTribField;
    private string infAdFiscoField;
    private DFeBase.TTribCTe ibsCbsField = null!;
    private decimal? vTotDFeField = 0.0M;

    public Impostos() : base()
    {
        iCMSField = new ICMS();
    }

    public ICMS ICMS
    {
        get => iCMSField;
        set
        {
            if (iCMSField is null || iCMSField.Equals(value) != true)
            {
                iCMSField = value;
                OnPropertyChanged(nameof(ICMS));
            }
        }
    }

    public InftributosFederais infTribFed
    {
        get => federaisField;
        set
        {
            if (federaisField is null || federaisField.Equals(value) != true)
            {
                federaisField = value;
                OnPropertyChanged(nameof(infTribFed));
            }
        }
    }

    public double? vTotTrib
    {
        get => vTotTribField;
        set
        {
            if (vTotTribField is null || vTotTribField.Equals(value) != true)
            {
                vTotTribField = value;
                OnPropertyChanged(nameof(vTotTrib));
            }
        }
    }

    public bool ShouldSerializevTotTrib() => vTotTribField.HasValue;

    public string infAdFisco
    {
        get => infAdFiscoField;
        set
        {
            if (infAdFiscoField is null || infAdFiscoField.Equals(value) != true)
            {
                infAdFiscoField = value;
                OnPropertyChanged(nameof(infAdFisco));
            }
        }
    }

    /// <summary>
    /// Grupo de informações do IBS e CBS
    /// </summary>
    [XmlElement("IBSCBS")]
    public DFeBase.TIBSCBSMonoTot IBSCBS
    {
        get => ibsCbsField;
        set
        {
            if (ibsCbsField is null || ibsCbsField.Equals(value) != true)
            {
                ibsCbsField = value;
                OnPropertyChanged(nameof(IBSCBS));
            }
        }
    }

    /// <summary>
    /// Valor total do documento fiscal (vTPrest + total do IBS + total da CBS) 
    /// </summary>
    [XmlElement("vTotDFe")]
    public decimal? vTotDFe
    {
        get => vTotDFeField;
        set
        {
            if (vTotDFeField is null || vTotDFeField.Equals(value) != true)
            {
                vTotDFeField = value;
                OnPropertyChanged(nameof(vTotDFe));
            }
        }
    }

    public bool ShouldSerializevTotDFe() => vTotDFeField.HasValue;


    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesCteNormal : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormInfCarga infCargaField;
    private TCTeInfCteInfCTeNormInfDoc infDocField;
    private ObservableCollection<CTeNormalEmitenteDocumentonterior> docAntField;
    private ObservableCollection<TCTeInfCteInfCTeNormSeg> segField;
    private TCTeInfCteInfCTeNormInfModal infModalField;
    private ObservableCollection<TCTeInfCteInfCTeNormPeri> periField;
    private ObservableCollection<TCTeInfCteInfCTeNormVeicNovos> veicNovosField;
    private TCTeInfCteInfCTeNormCobr cobrField;
    private TCTeInfCteInfCTeNormInfCteSub infCteSubField;

    public InformacoesCteNormal() : base()
    {
        // Me.infCteSubField = New TCTeInfCteInfCTeNormInfCteSub()
        // Me.cobrField = New TCTeInfCteInfCTeNormCobr()
        veicNovosField = [];
        periField = [];
        infModalField = new TCTeInfCteInfCTeNormInfModal();
        segField = [];
        docAntField = [];
        infDocField = new TCTeInfCteInfCTeNormInfDoc();
        infCargaField = new TCTeInfCteInfCTeNormInfCarga();
    }

    public TCTeInfCteInfCTeNormInfCarga infCarga
    {
        get => infCargaField;
        set
        {
            if (infCargaField is null || infCargaField.Equals(value) != true)
            {
                infCargaField = value;
                OnPropertyChanged(nameof(infCarga));
            }
        }
    }

    public TCTeInfCteInfCTeNormInfDoc infDoc
    {
        get => infDocField;
        set
        {
            if (infDocField is null || infDocField.Equals(value) != true)
            {
                infDocField = value;
                OnPropertyChanged(nameof(infDoc));
            }
        }
    }

    [XmlArrayItem("emiDocAnt", IsNullable = false)]
    public ObservableCollection<CTeNormalEmitenteDocumentonterior> docAnt
    {
        get => docAntField;
        set
        {
            if (docAntField is null || docAntField.Equals(value) != true)
            {
                docAntField = value;
                OnPropertyChanged(nameof(docAnt));
            }
        }
    }

    public bool ShouldSerializedocAnt()
    {
        if (docAntField != null)
        {
            return docAntField.Count > 0;
        }
        else
        {
            return false;
        }
    }

    [XmlElement("seg")]
    public ObservableCollection<TCTeInfCteInfCTeNormSeg> seg
    {
        get => segField;
        set
        {
            if (segField is null || segField.Equals(value) != true)
            {
                segField = value;
                OnPropertyChanged(nameof(seg));
            }
        }
    }

    public TCTeInfCteInfCTeNormInfModal infModal
    {
        get => infModalField;
        set
        {
            if (infModalField is null || infModalField.Equals(value) != true)
            {
                infModalField = value;
                OnPropertyChanged(nameof(infModal));
            }
        }
    }

    [XmlElement("peri")]
    public ObservableCollection<TCTeInfCteInfCTeNormPeri> peri
    {
        get => periField;
        set
        {
            if (periField is null || periField.Equals(value) != true)
            {
                periField = value;
                OnPropertyChanged(nameof(peri));
            }
        }
    }

    [XmlElement("veicNovos")]
    public ObservableCollection<TCTeInfCteInfCTeNormVeicNovos> veicNovos
    {
        get => veicNovosField;
        set
        {
            if (veicNovosField is null || veicNovosField.Equals(value) != true)
            {
                veicNovosField = value;
                OnPropertyChanged(nameof(veicNovos));
            }
        }
    }

    public TCTeInfCteInfCTeNormCobr cobr
    {
        get => cobrField;
        set
        {
            if (cobrField is null || cobrField.Equals(value) != true)
            {
                cobrField = value;
                OnPropertyChanged(nameof(cobr));
            }
        }
    }

    public TCTeInfCteInfCTeNormInfCteSub infCteSub
    {
        get => infCteSubField;
        set
        {
            if (infCteSubField is null || infCteSubField.Equals(value) != true)
            {
                infCteSubField = value;
                OnPropertyChanged(nameof(infCteSub));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfCarga : INotifyPropertyChanged
{
    private double? vCargaField;
    private string proPredField;
    private string xOutCatField;
    private ObservableCollection<TCTeInfCteInfCTeNormInfCargaInfQ> infQField;

    public TCTeInfCteInfCTeNormInfCarga() : base()
    {
        infQField = [];
    }

    public double? vCarga
    {
        get => vCargaField;
        set
        {
            if (vCargaField is null || vCargaField.Equals(value) != true)
            {
                vCargaField = value;
                OnPropertyChanged(nameof(vCarga));
            }
        }
    }

    public string proPred
    {
        get => proPredField;
        set
        {
            if (proPredField is null || proPredField.Equals(value) != true)
            {
                proPredField = value;
                OnPropertyChanged(nameof(proPred));
            }
        }
    }

    public string xOutCat
    {
        get => xOutCatField;
        set
        {
            if (xOutCatField is null || xOutCatField.Equals(value) != true)
            {
                xOutCatField = value;
                OnPropertyChanged(nameof(xOutCat));
            }
        }
    }

    [XmlElement("infQ")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfCargaInfQ> infQ
    {
        get => infQField;
        set
        {
            if (infQField is null || infQField.Equals(value) != true)
            {
                infQField = value;
                OnPropertyChanged(nameof(infQ));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfCargaInfQ : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormInfCargaInfQCUnid cUnidField;
    private string tpMedField;
    private string qCargaField;

    public TCTeInfCteInfCTeNormInfCargaInfQCUnid cUnid
    {
        get => cUnidField;
        set
        {
            if (cUnidField.Equals(value) != true)
            {
                cUnidField = value;
                OnPropertyChanged(nameof(cUnid));
            }
        }
    }

    public string tpMed
    {
        get => tpMedField;
        set
        {
            if (tpMedField is null || tpMedField.Equals(value) != true)
            {
                tpMedField = value;
                OnPropertyChanged(nameof(tpMed));
            }
        }
    }

    public string qCarga
    {
        get => qCargaField;
        set
        {
            if (qCargaField is null || qCargaField.Equals(value) != true)
            {
                qCargaField = value;
                OnPropertyChanged(nameof(qCarga));
            }
        }
    }

    public override string ToString() =>
        // Return MyBase.ToString()
        qCarga + "/" + tpMed;

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteInfCTeNormInfCargaInfQCUnid
{

    /// <remarks/>
    [XmlEnum("00")]
    Item00,

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("02")]
    Item02,

    /// <remarks/>
    [XmlEnum("03")]
    Item03,

    /// <remarks/>
    [XmlEnum("04")]
    Item04,

    /// <remarks/>
    [XmlEnum("05")]
    Item05
}

public partial class TCTeInfCteInfCTeNormInfDoc : INotifyPropertyChanged
{
    private ObservableCollection<object> itemsField;

    public TCTeInfCteInfCTeNormInfDoc() : base()
    {
        itemsField = [];
    }

    [XmlElement("infNF", typeof(TCTeInfCteInfCTeNormInfDocInfNF))]
    [XmlElement("infNFe", typeof(TCTeInfCteInfCTeNormInfDocInfNFe))]
    [XmlElement("infOutros", typeof(TCTeInfCteInfCTeNormInfDocInfOutros))]
    public ObservableCollection<object> Items
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfDocInfNF : INotifyPropertyChanged
{
    private string nRomaField;
    private string nPedField;
    private TModNF modField;
    private string serieField;
    private string nDocField;
    private string dEmiField;
    private string vBCField;
    private string vICMSField;
    private string vBCSTField;
    private string vSTField;
    private string vProdField;
    private string vNFField;
    private string nCFOPField;
    private string nPesoField;
    private string pINField;
    private string dPrevField;
    private ObservableCollection<object> itemsField;

    public TCTeInfCteInfCTeNormInfDocInfNF() : base()
    {
        itemsField = [];
    }

    public string nRoma
    {
        get => nRomaField;
        set
        {
            if (nRomaField is null || nRomaField.Equals(value) != true)
            {
                nRomaField = value;
                OnPropertyChanged(nameof(nRoma));
            }
        }
    }

    public string nPed
    {
        get => nPedField;
        set
        {
            if (nPedField is null || nPedField.Equals(value) != true)
            {
                nPedField = value;
                OnPropertyChanged(nameof(nPed));
            }
        }
    }

    public TModNF mod
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(mod));
            }
        }
    }

    public string serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(serie));
            }
        }
    }

    public string nDoc
    {
        get => nDocField;
        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged(nameof(nDoc));
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public string vBC
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(vBC));
            }
        }
    }

    public string vICMS
    {
        get => vICMSField;
        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged(nameof(vICMS));
            }
        }
    }

    public string vBCST
    {
        get => vBCSTField;
        set
        {
            if (vBCSTField is null || vBCSTField.Equals(value) != true)
            {
                vBCSTField = value;
                OnPropertyChanged(nameof(vBCST));
            }
        }
    }

    public string vST
    {
        get => vSTField;
        set
        {
            if (vSTField is null || vSTField.Equals(value) != true)
            {
                vSTField = value;
                OnPropertyChanged(nameof(vST));
            }
        }
    }

    public string vProd
    {
        get => vProdField;
        set
        {
            if (vProdField is null || vProdField.Equals(value) != true)
            {
                vProdField = value;
                OnPropertyChanged(nameof(vProd));
            }
        }
    }

    public string vNF
    {
        get => vNFField;
        set
        {
            if (vNFField is null || vNFField.Equals(value) != true)
            {
                vNFField = value;
                OnPropertyChanged(nameof(vNF));
            }
        }
    }

    public string nCFOP
    {
        get => nCFOPField;
        set
        {
            if (nCFOPField is null || nCFOPField.Equals(value) != true)
            {
                nCFOPField = value;
                OnPropertyChanged(nameof(nCFOP));
            }
        }
    }

    public string nPeso
    {
        get => nPesoField;
        set
        {
            if (nPesoField is null || nPesoField.Equals(value) != true)
            {
                nPesoField = value;
                OnPropertyChanged(nameof(nPeso));
            }
        }
    }

    public string PIN
    {
        get => pINField;
        set
        {
            if (pINField is null || pINField.Equals(value) != true)
            {
                pINField = value;
                OnPropertyChanged(nameof(PIN));
            }
        }
    }

    public string dPrev
    {
        get => dPrevField;
        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged(nameof(dPrev));
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public override string ToString() => "NF"; // MyBase.ToString()

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TModNF
{

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("04")]
    Item04
}

public partial class TCTeInfCteInfCTeNormInfDocInfNFe : INotifyPropertyChanged
{
    private string chaveField;
    private string pINField;
    private string dPrevField;
    private ObservableCollection<object> itemsField;

    public TCTeInfCteInfCTeNormInfDocInfNFe() : base()
    {
        itemsField = [];
    }

    [XmlElement("chave")]
    public string Chave
    {
        get => chaveField;
        set
        {
            if (chaveField is null || chaveField.Equals(value) != true)
            {
                chaveField = value;
                OnPropertyChanged("chave");
            }
        }
    }

    public string PIN
    {
        get => pINField;
        set
        {
            if (pINField is null || pINField.Equals(value) != true)
            {
                pINField = value;
                OnPropertyChanged(nameof(PIN));
            }
        }
    }

    public string dPrev
    {
        get => dPrevField;
        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged(nameof(dPrev));
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public override string ToString() => "NFe"; // MyBase.ToString()

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfDocInfOutros : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc tpDocField;
    private string descOutrosField;
    private string nDocField;
    private string dEmiField;
    private string vDocFiscField;
    private string dPrevField;
    private ObservableCollection<object> itemsField;

    public TCTeInfCteInfCTeNormInfDocInfOutros() : base()
    {
        itemsField = [];
    }

    public TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc tpDoc
    {
        get => tpDocField;
        set
        {
            if (tpDocField.Equals(value) != true)
            {
                tpDocField = value;
                OnPropertyChanged(nameof(tpDoc));
            }
        }
    }

    public string descOutros
    {
        get => descOutrosField;
        set
        {
            if (descOutrosField is null || descOutrosField.Equals(value) != true)
            {
                descOutrosField = value;
                OnPropertyChanged(nameof(descOutros));
            }
        }
    }

    public string nDoc
    {
        get => nDocField;
        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged(nameof(nDoc));
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public string vDocFisc
    {
        get => vDocFiscField;
        set
        {
            if (vDocFiscField is null || vDocFiscField.Equals(value) != true)
            {
                vDocFiscField = value;
                OnPropertyChanged(nameof(vDocFisc));
            }
        }
    }

    public string dPrev
    {
        get => dPrevField;
        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged(nameof(dPrev));
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public override string ToString() => "Outros"; // MyBase.ToString()

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc
{

    /// <remarks/>
    [XmlEnum("00")]
    Item00,

    /// <remarks/>
    [XmlEnum("10")]
    Item10,

    /// <remarks/>
    [XmlEnum("99")]
    Item99
}

public partial class CTeNormalEmitenteDocumentonterior : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private NFe.Estado ufField;
    private string xNomeField;
    private ObservableCollection<TCTeInfCteInfCTeNormEmiDocAntIdDocAnt> idDocAntField;

    public CTeNormalEmitenteDocumentonterior() : base()
    {
        idDocAntField = [];
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(IE));
            }
        }
    }

    public NFe.Estado UF
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

    public string xNome
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(xNome));
            }
        }
    }

    [XmlElement("idDocAnt")]
    public ObservableCollection<TCTeInfCteInfCTeNormEmiDocAntIdDocAnt> idDocAnt
    {
        get => idDocAntField;
        set
        {
            if (idDocAntField is null || idDocAntField.Equals(value) != true)
            {
                idDocAntField = value;
                OnPropertyChanged(nameof(idDocAnt));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAnt : INotifyPropertyChanged
{
    private ObservableCollection<object> itemsField;

    public TCTeInfCteInfCTeNormEmiDocAntIdDocAnt() : base()
    {
        itemsField = [];
    }

    [XmlElement("idDocAntEle", typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle))]
    [XmlElement("idDocAntPap", typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap))]
    public ObservableCollection<object> Items
    {
        get => itemsField;
        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle : INotifyPropertyChanged
{
    private string chaveField;

    public string chave
    {
        get => chaveField;
        set
        {
            if (chaveField is null || chaveField.Equals(value) != true)
            {
                chaveField = value;
                OnPropertyChanged(nameof(chave));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap : INotifyPropertyChanged
{
    private TDocAssoc tpDocField;
    private string serieField;
    private string subserField;
    private string nDocField;
    private string dEmiField;

    public TDocAssoc tpDoc
    {
        get => tpDocField;
        set
        {
            if (tpDocField.Equals(value) != true)
            {
                tpDocField = value;
                OnPropertyChanged(nameof(tpDoc));
            }
        }
    }

    public string serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(serie));
            }
        }
    }

    public string subser
    {
        get => subserField;
        set
        {
            if (subserField is null || subserField.Equals(value) != true)
            {
                subserField = value;
                OnPropertyChanged(nameof(subser));
            }
        }
    }

    public string nDoc
    {
        get => nDocField;
        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged(nameof(nDoc));
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum TDocAssoc
{

    /// <remarks/>
    [XmlEnum("00")]
    Item00,

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("02")]
    Item02,

    /// <remarks/>
    [XmlEnum("03")]
    Item03,

    /// <remarks/>
    [XmlEnum("04")]
    Item04,

    /// <remarks/>
    [XmlEnum("05")]
    Item05,

    /// <remarks/>
    [XmlEnum("06")]
    Item06,

    /// <remarks/>
    [XmlEnum("07")]
    Item07,

    /// <remarks/>
    [XmlEnum("08")]
    Item08,

    /// <remarks/>
    [XmlEnum("09")]
    Item09,

    /// <remarks/>
    [XmlEnum("10")]
    Item10,

    /// <remarks/>
    [XmlEnum("11")]
    Item11,

    /// <remarks/>
    [XmlEnum("12")]
    Item12,

    /// <remarks/>
    [XmlEnum("99")]
    Item99
}

public partial class TCTeInfCteInfCTeNormSeg : INotifyPropertyChanged
{
    private ResponsavelSeguro respSegField;
    private string xSegField;
    private string nApolField;
    private string nAverField;
    private string vCargaField;

    public ResponsavelSeguro respSeg
    {
        get => respSegField;
        set
        {
            if (respSegField.Equals(value) != true)
            {
                respSegField = value;
                OnPropertyChanged(nameof(respSeg));
            }
        }
    }

    public string xSeg
    {
        get => xSegField;
        set
        {
            if (xSegField is null || xSegField.Equals(value) != true)
            {
                xSegField = value;
                OnPropertyChanged(nameof(xSeg));
            }
        }
    }

    public string nApol
    {
        get => nApolField;
        set
        {
            if (nApolField is null || nApolField.Equals(value) != true)
            {
                nApolField = value;
                OnPropertyChanged(nameof(nApol));
            }
        }
    }

    public string nAver
    {
        get => nAverField;
        set
        {
            if (nAverField is null || nAverField.Equals(value) != true)
            {
                nAverField = value;
                OnPropertyChanged(nameof(nAver));
            }
        }
    }

    public string vCarga
    {
        get => vCargaField;
        set
        {
            if (vCargaField is null || vCargaField.Equals(value) != true)
            {
                vCargaField = value;
                OnPropertyChanged(nameof(vCarga));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfModal : INotifyPropertyChanged
{
    private XElement anyField; // System.Xml.XmlElement
    private string versaoModalField;
    private object itemField;

    [XmlAnyElement()]
    public XElement Any // System.Xml.XmlElement
    {
        get => anyField;
        set // System.Xml.XmlElement)
        {
            if (anyField is null || anyField.Equals(value) != true)
            {
                anyField = value;
                OnPropertyChanged(nameof(Any));
            }
        }
    }

    [XmlAttribute()]
    public string versaoModal
    {
        get => versaoModalField;
        set
        {
            if (versaoModalField is null || versaoModalField.Equals(value) != true)
            {
                versaoModalField = value;
                OnPropertyChanged(nameof(versaoModal));
            }
        }
    }

    [XmlElement("rodo", typeof(CTeRodoviario))]
    public object ItemModal
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(ItemModal));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormPeri : INotifyPropertyChanged
{
    private string nONUField;
    private string xNomeAEField;
    private string xClaRiscoField;
    private string grEmbField;
    private string qTotProdField;
    private string qVolTipoField;
    private string pontoFulgorField;

    public string nONU
    {
        get => nONUField;
        set
        {
            if (nONUField is null || nONUField.Equals(value) != true)
            {
                nONUField = value;
                OnPropertyChanged(nameof(nONU));
            }
        }
    }

    public string xNomeAE
    {
        get => xNomeAEField;
        set
        {
            if (xNomeAEField is null || xNomeAEField.Equals(value) != true)
            {
                xNomeAEField = value;
                OnPropertyChanged(nameof(xNomeAE));
            }
        }
    }

    public string xClaRisco
    {
        get => xClaRiscoField;
        set
        {
            if (xClaRiscoField is null || xClaRiscoField.Equals(value) != true)
            {
                xClaRiscoField = value;
                OnPropertyChanged(nameof(xClaRisco));
            }
        }
    }

    public string grEmb
    {
        get => grEmbField;
        set
        {
            if (grEmbField is null || grEmbField.Equals(value) != true)
            {
                grEmbField = value;
                OnPropertyChanged(nameof(grEmb));
            }
        }
    }

    public string qTotProd
    {
        get => qTotProdField;
        set
        {
            if (qTotProdField is null || qTotProdField.Equals(value) != true)
            {
                qTotProdField = value;
                OnPropertyChanged(nameof(qTotProd));
            }
        }
    }

    public string qVolTipo
    {
        get => qVolTipoField;
        set
        {
            if (qVolTipoField is null || qVolTipoField.Equals(value) != true)
            {
                qVolTipoField = value;
                OnPropertyChanged(nameof(qVolTipo));
            }
        }
    }

    public string pontoFulgor
    {
        get => pontoFulgorField;
        set
        {
            if (pontoFulgorField is null || pontoFulgorField.Equals(value) != true)
            {
                pontoFulgorField = value;
                OnPropertyChanged(nameof(pontoFulgor));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormVeicNovos : INotifyPropertyChanged
{
    private string chassiField;
    private string cCorField;
    private string xCorField;
    private string cModField;
    private string vUnitField;
    private string vFreteField;

    public string chassi
    {
        get => chassiField;
        set
        {
            if (chassiField is null || chassiField.Equals(value) != true)
            {
                chassiField = value;
                OnPropertyChanged(nameof(chassi));
            }
        }
    }

    public string cCor
    {
        get => cCorField;
        set
        {
            if (cCorField is null || cCorField.Equals(value) != true)
            {
                cCorField = value;
                OnPropertyChanged(nameof(cCor));
            }
        }
    }

    public string xCor
    {
        get => xCorField;
        set
        {
            if (xCorField is null || xCorField.Equals(value) != true)
            {
                xCorField = value;
                OnPropertyChanged(nameof(xCor));
            }
        }
    }

    public string cMod
    {
        get => cModField;
        set
        {
            if (cModField is null || cModField.Equals(value) != true)
            {
                cModField = value;
                OnPropertyChanged(nameof(cMod));
            }
        }
    }

    public string vUnit
    {
        get => vUnitField;
        set
        {
            if (vUnitField is null || vUnitField.Equals(value) != true)
            {
                vUnitField = value;
                OnPropertyChanged(nameof(vUnit));
            }
        }
    }

    public string vFrete
    {
        get => vFreteField;
        set
        {
            if (vFreteField is null || vFreteField.Equals(value) != true)
            {
                vFreteField = value;
                OnPropertyChanged(nameof(vFrete));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormCobr : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormCobrFat fatField;
    private ObservableCollection<TCTeInfCteInfCTeNormCobrDup> dupField;

    public TCTeInfCteInfCTeNormCobr() : base()
    {
        dupField = [];
        fatField = new TCTeInfCteInfCTeNormCobrFat();
    }

    public TCTeInfCteInfCTeNormCobrFat fat
    {
        get => fatField;
        set
        {
            if (fatField is null || fatField.Equals(value) != true)
            {
                fatField = value;
                OnPropertyChanged(nameof(fat));
            }
        }
    }

    [XmlElement("dup")]
    public ObservableCollection<TCTeInfCteInfCTeNormCobrDup> dup
    {
        get => dupField;
        set
        {
            if (dupField is null || dupField.Equals(value) != true)
            {
                dupField = value;
                OnPropertyChanged(nameof(dup));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormCobrFat : INotifyPropertyChanged
{
    private string nFatField;
    private string vOrigField;
    private string vDescField;
    private string vLiqField;

    public string nFat
    {
        get => nFatField;
        set
        {
            if (nFatField is null || nFatField.Equals(value) != true)
            {
                nFatField = value;
                OnPropertyChanged(nameof(nFat));
            }
        }
    }

    public string vOrig
    {
        get => vOrigField;
        set
        {
            if (vOrigField is null || vOrigField.Equals(value) != true)
            {
                vOrigField = value;
                OnPropertyChanged(nameof(vOrig));
            }
        }
    }

    public string vDesc
    {
        get => vDescField;
        set
        {
            if (vDescField is null || vDescField.Equals(value) != true)
            {
                vDescField = value;
                OnPropertyChanged(nameof(vDesc));
            }
        }
    }

    public string vLiq
    {
        get => vLiqField;
        set
        {
            if (vLiqField is null || vLiqField.Equals(value) != true)
            {
                vLiqField = value;
                OnPropertyChanged(nameof(vLiq));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormCobrDup : INotifyPropertyChanged
{
    private string nDupField;
    private string dVencField;
    private string vDupField;

    public string nDup
    {
        get => nDupField;
        set
        {
            if (nDupField is null || nDupField.Equals(value) != true)
            {
                nDupField = value;
                OnPropertyChanged(nameof(nDup));
            }
        }
    }

    public string dVenc
    {
        get => dVencField;
        set
        {
            if (dVencField is null || dVencField.Equals(value) != true)
            {
                dVencField = value;
                OnPropertyChanged(nameof(dVenc));
            }
        }
    }

    public string vDup
    {
        get => vDupField;
        set
        {
            if (vDupField is null || vDupField.Equals(value) != true)
            {
                vDupField = value;
                OnPropertyChanged(nameof(vDup));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfCteSub : INotifyPropertyChanged
{
    private string chCteField;
    private object itemField;

    public string chCte
    {
        get => chCteField;
        set
        {
            if (chCteField is null || chCteField.Equals(value) != true)
            {
                chCteField = value;
                OnPropertyChanged(nameof(chCte));
            }
        }
    }

    [XmlElement("tomaICMS", typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMS))]
    [XmlElement("tomaNaoICMS", typeof(TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS))]
    public object Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfCteSubTomaICMS : INotifyPropertyChanged
{
    private object itemField;
    private PersonalidadeJuridica78 itemElementNameField;

    [XmlElement("refCte", typeof(string))]
    [XmlElement("refNF", typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF))]
    [XmlElement("refNFe", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public object Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica78 ItemElementName
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(ItemElementName));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private TModDoc modField;
    private string serieField;
    private string subserieField;
    private string nroField;
    private string valorField;
    private string dEmiField;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(ItemElementName));
            }
        }
    }

    public TModDoc mod
    {
        get => modField;
        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged(nameof(mod));
            }
        }
    }

    public string serie
    {
        get => serieField;
        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(serie));
            }
        }
    }

    public string subserie
    {
        get => subserieField;
        set
        {
            if (subserieField is null || subserieField.Equals(value) != true)
            {
                subserieField = value;
                OnPropertyChanged(nameof(subserie));
            }
        }
    }

    public string nro
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(nro));
            }
        }
    }

    public string valor
    {
        get => valorField;
        set
        {
            if (valorField is null || valorField.Equals(value) != true)
            {
                valorField = value;
                OnPropertyChanged(nameof(valor));
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum PersonalidadeJuridica7
{

    /// <remarks/>
    CNPJ,

    /// <remarks/>
    CPF
}

public enum TModDoc
{

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("1B")]
    Item1B,

    /// <remarks/>
    [XmlEnum("02")]
    Item02,

    /// <remarks/>
    [XmlEnum("2D")]
    Item2D,

    /// <remarks/>
    [XmlEnum("2E")]
    Item2E,

    /// <remarks/>
    [XmlEnum("04")]
    Item04,

    /// <remarks/>
    [XmlEnum("06")]
    Item06,

    /// <remarks/>
    [XmlEnum("07")]
    Item07,

    /// <remarks/>
    [XmlEnum("08")]
    Item08,

    /// <remarks/>
    [XmlEnum("8B")]
    Item8B,

    /// <remarks/>
    [XmlEnum("09")]
    Item09,

    /// <remarks/>
    [XmlEnum("10")]
    Item10,

    /// <remarks/>
    [XmlEnum("11")]
    Item11,

    /// <remarks/>
    [XmlEnum("13")]
    Item13,

    /// <remarks/>
    [XmlEnum("14")]
    Item14,

    /// <remarks/>
    [XmlEnum("15")]
    Item15,

    /// <remarks/>
    [XmlEnum("16")]
    Item16,

    /// <remarks/>
    [XmlEnum("17")]
    Item17,

    /// <remarks/>
    [XmlEnum("18")]
    Item18,

    /// <remarks/>
    [XmlEnum("20")]
    Item20,

    /// <remarks/>
    [XmlEnum("21")]
    Item21,

    /// <remarks/>
    [XmlEnum("22")]
    Item22,

    /// <remarks/>
    [XmlEnum("23")]
    Item23,

    /// <remarks/>
    [XmlEnum("24")]
    Item24,

    /// <remarks/>
    [XmlEnum("25")]
    Item25,

    /// <remarks/>
    [XmlEnum("26")]
    Item26,

    /// <remarks/>
    [XmlEnum("27")]
    Item27,

    /// <remarks/>
    [XmlEnum("28")]
    Item28,

    /// <remarks/>
    [XmlEnum("55")]
    Item55
}

public enum PersonalidadeJuridica78
{

    /// <remarks/>
    refCte,

    /// <remarks/>
    refNF,

    /// <remarks/>
    refNFe
}

public partial class TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS : INotifyPropertyChanged
{
    private string refCteAnuField;

    public string refCteAnu
    {
        get => refCteAnuField;
        set
        {
            if (refCteAnuField is null || refCteAnuField.Equals(value) != true)
            {
                refCteAnuField = value;
                OnPropertyChanged(nameof(refCteAnu));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesCteAnulacao : INotifyPropertyChanged
{
    private string chCteField;
    private string dEmiField;

    [XmlElement("chCte")]
    public string Chave
    {
        get => chCteField;
        set
        {
            if (chCteField is null || chCteField.Equals(value) != true)
            {
                chCteField = value;
                OnPropertyChanged("chCte");
            }
        }
    }

    public string dEmi
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(dEmi));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesCteComplementado : INotifyPropertyChanged
{
    private string chaveField;

    [XmlElement("chave")]
    public string Chave
    {
        get => chaveField;
        set
        {
            if (chaveField is null || chaveField.Equals(value) != true)
            {
                chaveField = value;
                OnPropertyChanged("chave");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class AutorizadoXML : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica79 itemElementNameField;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
    {
        get => itemField;
        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged(nameof(Item));
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica79 ItemElementName
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(ItemElementName));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public enum PersonalidadeJuridica79
{

    /// <remarks/>
    CNPJ,

    /// <remarks/>
    CPF
}

public class CteTotal : INotifyPropertyChanged
{
    private decimal? vTPrestField = 0.0M;
    private decimal? vTRecField = 0.0M;
    private decimal? vTotDFeField = 0.0M;


    /// <summary>
    /// Valor Total da Prestação do Serviço <br />
    /// Pode conter zeros quando o CT-e for de complemento de ICMS
    /// </summary>
    [XmlElement("vTPrest")]
    public decimal? vTPrest
    {
        get => vTPrestField;
        set
        {
            if (vTPrestField is null || vTPrestField.Equals(value) != true)
            {
                vTPrestField = value;
                OnPropertyChanged(nameof(vTPrest));
            }
        }
    }

    public bool ShouldSerializevTPrest() => vTPrestField.HasValue;


    /// <summary>
    /// Valor total a Receber
    /// </summary>
    [XmlElement("vTRec")]
    public decimal? vTRec
    {
        get => vTRecField;
        set
        {
            if (vTRecField is null || vTRecField.Equals(value) != true)
            {
                vTRecField = value;
                OnPropertyChanged(nameof(vTRec));
            }
        }
    }

    public bool ShouldSerializevTRec() => vTRecField.HasValue;


    /// <summary>
    /// Valor total do documento fiscal (vTPrest + total do IBS + total da CBS) 
    /// </summary>
    [XmlElement("vTotDFe")]
    public decimal? vTotDFe
    {
        get => vTotDFeField;
        set
        {
            if (vTotDFeField is null || vTotDFeField.Equals(value) != true)
            {
                vTotDFeField = value;
                OnPropertyChanged(nameof(vTotDFe));
            }
        }
    }

    public bool ShouldSerializevTotDFe() => vTotDFeField.HasValue;


    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}