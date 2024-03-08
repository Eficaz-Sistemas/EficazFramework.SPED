using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;
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
                OnPropertyChanged("CTe");
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
                OnPropertyChanged("Versao");
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
                OnPropertyChanged("CTe");
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
                OnPropertyChanged("ProtocoloAutorizacao");
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
                OnPropertyChanged("Versao");
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

Serializable()]
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
                OnPropertyChanged("Informacoes");
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
        autXMLField = new ObservableCollection<AutorizadoXML>();
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
        get
        {
            return ideField;
        }

        set
        {
            if (ideField is null || ideField.Equals(value) != true)
            {
                ideField = value;
                OnPropertyChanged("IdentificacaoOperacao");
            }
        }
    }

    [XmlElement("compl")]
    public ComplementoCTe Complemento
    {
        get
        {
            return complField;
        }

        set
        {
            if (complField is null || complField.Equals(value) != true)
            {
                complField = value;
                OnPropertyChanged("Complemento");
            }
        }
    }

    [XmlElement("emit")]
    public Emitente Emitente
    {
        get
        {
            return emitField;
        }

        set
        {
            if (emitField is null || emitField.Equals(value) != true)
            {
                emitField = value;
                OnPropertyChanged("Emitente");
            }
        }
    }

    [XmlElement("toma3", typeof(TomadorTipo3))]
    [XmlElement("toma03", typeof(TomadorTipo03))]
    [XmlElement("toma4", typeof(TomadorTipo04))]
    [XmlElement("toma", typeof(CTeOS.Tomador))]
    public object Tomador
    {
        get
        {
            return tomaField;
        }

        set
        {
            if (tomaField is null || tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged("Tomador");
            }
        }
    }

    [XmlElement("rem")]
    public Remetente Remetente
    {
        get
        {
            return remField;
        }

        set
        {
            if (remField is null || remField.Equals(value) != true)
            {
                remField = value;
                OnPropertyChanged("Remetente");
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
        get
        {
            return expedField;
        }

        set
        {
            if (expedField is null || expedField.Equals(value) != true)
            {
                expedField = value;
                OnPropertyChanged("Expedidor");
            }
        }
    }

    [XmlElement("receb")]
    public Recebedor Recebedor
    {
        get
        {
            return recebField;
        }

        set
        {
            if (recebField is null || recebField.Equals(value) != true)
            {
                recebField = value;
                OnPropertyChanged("Recebedor");
            }
        }
    }

    [XmlElement("dest")]
    public Destinatario Destinatario
    {
        get
        {
            return destField;
        }

        set
        {
            if (destField is null || destField.Equals(value) != true)
            {
                destField = value;
                OnPropertyChanged("Destinatario");
            }
        }
    }

    [XmlElement("vPrest")]
    public ValoresPrestacaoServico Valores
    {
        get
        {
            return vPrestField;
        }

        set
        {
            if (vPrestField is null || vPrestField.Equals(value) != true)
            {
                vPrestField = value;
                OnPropertyChanged("Valores");
            }
        }
    }

    [XmlElement("imp")]
    public Impostos Impostos
    {
        get
        {
            return impField;
        }

        set
        {
            if (impField is null || impField.Equals(value) != true)
            {
                impField = value;
                OnPropertyChanged("Impostos");
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
        get
        {
            return itemField;
        }

        set
        {
            if (itemField is null || itemField.Equals(value) != true)
            {
                itemField = value;
                OnPropertyChanged("InformacaoCTePorTipo");
            }
        }
    }

    [XmlElement("autXML")]
    public ObservableCollection<AutorizadoXML> AutorizadosDownloadXML
    {
        get
        {
            return autXMLField;
        }

        set
        {
            if (autXMLField is null || autXMLField.Equals(value) != true)
            {
                autXMLField = value;
                OnPropertyChanged("AutorizadosDownloadXML");
            }
        }
    }

    [XmlAttribute("versao")]
    public string Versao
    {
        get
        {
            return versaoField;
        }

        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged("Versao");
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(InformacoesCTe));
            }

            return sSerializer;
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

    public static InformacoesCTe Deserialize(System.IO.Stream s)
    {
        return (InformacoesCTe)Serializer.Deserialize(s);
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    [XmlElement("cUF")]
    public NFe.OrgaoIBGE CodigoIBGE
    {
        get
        {
            return cUFField;
        }

        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged("cUF");
            }
        }
    }

    [XmlElement("cCT")]
    public string Chave
    {
        get
        {
            return cCTField;
        }

        set
        {
            if (cCTField is null || cCTField.Equals(value) != true)
            {
                cCTField = value;
                OnPropertyChanged("Chave");
            }
        }
    }

    [XmlElement("CFOP")]
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

    [XmlElement("natOp")]
    public string NaturezaOperacao
    {
        get
        {
            return natOpField;
        }

        set
        {
            if (natOpField is null || natOpField.Equals(value) != true)
            {
                natOpField = value;
                OnPropertyChanged("NaturezaOperacao");
            }
        }
    }

    [XmlElement("forPag")]
    public FormaPagamento FormaPagamento
    {
        get
        {
            return forPagField;
        }

        set
        {
            if (forPagField.Equals(value) != true)
            {
                forPagField = value;
                OnPropertyChanged("FormaPagamento");
            }
        }
    }

    [XmlElement("mod")]
    public Modelo Modelo
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("Modelo");
            }
        }
    }

    [XmlElement("serie")]
    public string Serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("Serie");
            }
        }
    }

    [XmlElement("nCT")]
    public long? Numero
    {
        get
        {
            return nCTField;
        }

        set
        {
            if (nCTField is null || nCTField.Equals(value) != true)
            {
                nCTField = value;
                OnPropertyChanged("Numero");
            }
        }
    }

    [XmlElement("dhEmi")]
    public DateTime? DataEmissao
    {
        get
        {
            return dhEmiField;
        }

        set
        {
            if (dhEmiField is null || dhEmiField.Equals(value) != true)
            {
                dhEmiField = value;
                OnPropertyChanged("DataEmissao");
            }
        }
    }

    public bool ShouldSerializeDataEmissao()
    {
        return dhEmiField.HasValue;
    }

    [XmlElement("tpImp")]
    public FormatoImpressao TipoImpressao
    {
        get
        {
            return tpImpField;
        }

        set
        {
            if (tpImpField.Equals(value) != true)
            {
                tpImpField = value;
                OnPropertyChanged("TipoImpressao");
            }
        }
    }

    [XmlElement("tpEmis")]
    public FormaEmissao FormaEmissao
    {
        get
        {
            return tpEmisField;
        }

        set
        {
            if (tpEmisField.Equals(value) != true)
            {
                tpEmisField = value;
                OnPropertyChanged("FormaEmissao");
            }
        }
    }

    [XmlElement("cDV")]
    public string DigitoVerificador
    {
        get
        {
            return cDVField;
        }

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
        get
        {
            return tpAmbField;
        }

        set
        {
            if (tpAmbField.Equals(value) != true)
            {
                tpAmbField = value;
                OnPropertyChanged("Ambiente");
            }
        }
    }

    [XmlElement("tpCTe")]
    public TipoCTe Finalidade
    {
        get
        {
            return tpCTeField;
        }

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
        get
        {
            return procEmiField;
        }

        set
        {
            if (procEmiField.Equals(value) != true)
            {
                procEmiField = value;
                OnPropertyChanged("ProcessoEmissao");
            }
        }
    }

    [XmlElement("verProc")]
    public string VersaoAplicativoEmissor
    {
        get
        {
            return verProcField;
        }

        set
        {
            if (verProcField is null || verProcField.Equals(value) != true)
            {
                verProcField = value;
                OnPropertyChanged("VersaoAplicativoEmissor");
            }
        }
    }

    [XmlElement("refCTE")]
    public string ChaveCteReferenciado
    {
        get
        {
            return refCTEField;
        }

        set
        {
            if (refCTEField is null || refCTEField.Equals(value) != true)
            {
                refCTEField = value;
                OnPropertyChanged("ChaveCteReferenciado");
            }
        }
    }

    [XmlElement("cMunEnv")]
    public string MunicipioEnvioCodigo
    {
        get
        {
            return cMunEnvField;
        }

        set
        {
            if (cMunEnvField is null || cMunEnvField.Equals(value) != true)
            {
                cMunEnvField = value;
                OnPropertyChanged("MunicipioEnvioCodigo");
            }
        }
    }

    [XmlElement("xMunEnv")]
    public string MunicipioEnvioNome
    {
        get
        {
            return xMunEnvField;
        }

        set
        {
            if (xMunEnvField is null || xMunEnvField.Equals(value) != true)
            {
                xMunEnvField = value;
                OnPropertyChanged("MunicipioEnvioNome");
            }
        }
    }

    [XmlElement("UFEnv")]
    public NFe.Estado UFEnvio
    {
        get
        {
            return uFEnvField;
        }

        set
        {
            if (uFEnvField.Equals(value) != true)
            {
                uFEnvField = value;
                OnPropertyChanged("UFEnvio");
            }
        }
    }

    [XmlElement("modal")]
    public ModalidadeTransporte Modalidade
    {
        get
        {
            return modalField;
        }

        set
        {
            if (modalField.Equals(value) != true)
            {
                modalField = value;
                OnPropertyChanged("Modalidade");
            }
        }
    }

    [XmlElement("tpServ")]
    public TiposServico TipoServico
    {
        get
        {
            return tpServField;
        }

        set
        {
            if (tpServField.Equals(value) != true)
            {
                tpServField = value;
                OnPropertyChanged("TipoServico");
            }
        }
    }

    [XmlElement("cMunIni")]
    public string MunicipioInicioCodigo
    {
        get
        {
            return cMunIniField;
        }

        set
        {
            if (cMunIniField is null || cMunIniField.Equals(value) != true)
            {
                cMunIniField = value;
                OnPropertyChanged("MunicipioInicioCodigo");
            }
        }
    }

    [XmlElement("xMunIni")]
    public string MunicipioInicioNome
    {
        get
        {
            return xMunIniField;
        }

        set
        {
            if (xMunIniField is null || xMunIniField.Equals(value) != true)
            {
                xMunIniField = value;
                OnPropertyChanged("MunicipioInicioNome");
            }
        }
    }

    [XmlElement("UFIni")]
    public NFe.Estado UFInicio
    {
        get
        {
            return uFIniField;
        }

        set
        {
            if (uFIniField.Equals(value) != true)
            {
                uFIniField = value;
                OnPropertyChanged("UFInicio");
            }
        }
    }

    [XmlElement("cMunFim")]
    public string MunicipioFimCodigo
    {
        get
        {
            return cMunFimField;
        }

        set
        {
            if (cMunFimField is null || cMunFimField.Equals(value) != true)
            {
                cMunFimField = value;
                OnPropertyChanged("MunicipioFimCodigo");
            }
        }
    }

    [XmlElement("xMunFim")]
    public string MunicipioFimNome
    {
        get
        {
            return xMunFimField;
        }

        set
        {
            if (xMunFimField is null || xMunFimField.Equals(value) != true)
            {
                xMunFimField = value;
                OnPropertyChanged("MunicipioFimNome");
            }
        }
    }

    [XmlElement("UFFim")]
    public NFe.Estado UFFim
    {
        get
        {
            return uFFimField;
        }

        set
        {
            if (uFFimField.Equals(value) != true)
            {
                uFFimField = value;
                OnPropertyChanged("UFFim");
            }
        }
    }

    [XmlElement("retira")]
    public Retira retira
    {
        get
        {
            return retiraField;
        }

        set
        {
            if (retiraField.Equals(value) != true)
            {
                retiraField = value;
                OnPropertyChanged("retira");
            }
        }
    }

    [XmlElement("xDetRetira")]
    public string xDetRetira
    {
        get
        {
            return xDetRetiraField;
        }

        set
        {
            if (xDetRetiraField is null || xDetRetiraField.Equals(value) != true)
            {
                xDetRetiraField = value;
                OnPropertyChanged("xDetRetira");
            }
        }
    }

    [XmlElement("toma3", typeof(TomadorTipo3))]
    [XmlElement("toma03", typeof(TomadorTipo03))]
    [XmlElement("toma4", typeof(TomadorTipo04))]
    [XmlElement("toma", typeof(CTeOS.Tomador))]
    public object Tomador
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
                OnPropertyChanged("Tomador");
            }
        }
    }

    [XmlElement("dhCont")]
    public DateTime? DataHoraContingencia
    {
        get
        {
            return dhContField;
        }

        set
        {
            if (dhContField is null || dhContField.Equals(value) != true)
            {
                dhContField = value;
                OnPropertyChanged("DataHoraContingencia");
            }
        }
    }

    public bool ShouldSerializeDataHoraContingencia()
    {
        return dhContField.HasValue;
    }

    [XmlElement("xJust")]
    public string JustificativaContingencia
    {
        get
        {
            return xJustField;
        }

        set
        {
            if (xJustField is null || xJustField.Equals(value) != true)
            {
                xJustField = value;
                OnPropertyChanged("JustificativaContingencia");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(IdentificacaoOperacao));
            }

            return sSerializer;
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class ProtocoloAutorizacao : INotifyPropertyChanged
{
    private TProtCTeInfProt infProtField;
    private SignatureType signatureField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public ProtocoloAutorizacao() : base()
    {
        // Me.signatureField = New SignatureType()
        infProtField = new TProtCTeInfProt();
    }

    public TProtCTeInfProt infProt
    {
        get
        {
            return infProtField;
        }

        set
        {
            if (infProtField is null || infProtField.Equals(value) != true)
            {
                infProtField = value;
                OnPropertyChanged("infProt");
            }
        }
    }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature
    {
        get
        {
            return signatureField;
        }

        set
        {
            if (signatureField is null || signatureField.Equals(value) != true)
            {
                signatureField = value;
                OnPropertyChanged("Signature");
            }
        }
    }

    [XmlAttribute()]
    public string versao
    {
        get
        {
            return versaoField;
        }

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
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ProtocoloAutorizacao));
            }

            return sSerializer;
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
    public static bool CanDeserialize(string xml, ref ProtocoloAutorizacao obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ProtocoloAutorizacao obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProtocoloAutorizacao Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ProtocoloAutorizacao)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProtocoloAutorizacao)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static ProtocoloAutorizacao Deserialize(System.IO.Stream s)
    {
        return (ProtocoloAutorizacao)Serializer.Deserialize(s);
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
    public static bool CanLoadFrom(System.IO.Stream source, ref ProtocoloAutorizacao obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref ProtocoloAutorizacao obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProtocoloAutorizacao LoadFrom(System.IO.Stream source)
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

    public static async Task<ProtocoloAutorizacao> LoadFromAsync(System.IO.Stream source)
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public NFe.Ambiente tpAmb
    {
        get
        {
            return tpAmbField;
        }

        set
        {
            if (tpAmbField.Equals(value) != true)
            {
                tpAmbField = value;
                OnPropertyChanged("tpAmb");
            }
        }
    }

    public string verAplic
    {
        get
        {
            return verAplicField;
        }

        set
        {
            if (verAplicField is null || verAplicField.Equals(value) != true)
            {
                verAplicField = value;
                OnPropertyChanged("verAplic");
            }
        }
    }

    public string chCTe
    {
        get
        {
            return chCTeField;
        }

        set
        {
            if (chCTeField is null || chCTeField.Equals(value) != true)
            {
                chCTeField = value;
                OnPropertyChanged("chCTe");
            }
        }
    }

    private string chave_codificada = null;

    [XmlIgnore]
    public string ChaveCTeCodificada
    {
        get
        {
            return chave_codificada;
        }
    }

    private byte[] chaveArray;

    [XmlIgnore]
    public byte[] ChaveCTeCodificadaByte
    {
        get
        {
            return chaveArray;
        }
    }

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
        get
        {
            return _logo;
        }

        set
        {
            _logo = value;
            OnPropertyChanged("Logo");
        }
    }

    public DateTime dhRecbto
    {
        get
        {
            return dhRecbtoField;
        }

        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged("dhRecbto");
            }
        }
    }

    public string nProt
    {
        get
        {
            return nProtField;
        }

        set
        {
            if (nProtField is null || nProtField.Equals(value) != true)
            {
                nProtField = value;
                OnPropertyChanged("nProt");
            }
        }
    }

    [XmlElement(DataType = "base64Binary")]
    public byte[] digVal
    {
        get
        {
            return digValField;
        }

        set
        {
            if (digValField is null || digValField.Equals(value) != true)
            {
                digValField = value;
                OnPropertyChanged("digVal");
            }
        }
    }

    public string cStat
    {
        get
        {
            return cStatField;
        }

        set
        {
            if (cStatField is null || cStatField.Equals(value) != true)
            {
                cStatField = value;
                OnPropertyChanged("cStat");
            }
        }
    }

    public string xMotivo
    {
        get
        {
            return xMotivoField;
        }

        set
        {
            if (xMotivoField is null || xMotivoField.Equals(value) != true)
            {
                xMotivoField = value;
                OnPropertyChanged("xMotivo");
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TProtCTeInfProt));
            }

            return sSerializer;
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

    public void SetCodeBarRaw(string encodedString, byte[] encodedArray)
    {
        chave_codificada = encodedString;
        chaveArray = encodedArray;
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureType : INotifyPropertyChanged
{
    private SignedInfoType signedInfoField;
    private SignatureValueType signatureValueField;
    private KeyInfoType keyInfoField;
    private string idField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(SignatureType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignedInfoType : INotifyPropertyChanged
{
    private SignedInfoTypeCanonicalizationMethod canonicalizationMethodField;
    private SignedInfoTypeSignatureMethod signatureMethodField;
    private ReferenceType referenceField;
    private string idField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(SignedInfoType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignedInfoTypeCanonicalizationMethod : INotifyPropertyChanged
{
    private string algorithmField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(SignedInfoTypeCanonicalizationMethod));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignedInfoTypeSignatureMethod : INotifyPropertyChanged
{
    private string algorithmField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(SignedInfoTypeSignatureMethod));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class ReferenceType : INotifyPropertyChanged
{
    private ObservableCollection<TransformType> transformsField;
    private ReferenceTypeDigestMethod digestMethodField;
    private byte[] digestValueField;
    private string idField;
    private string uRIField;
    private string typeField;
    private static XmlSerializer sSerializer;

    public ReferenceType() : base()
    {
        digestMethodField = new ReferenceTypeDigestMethod();
        transformsField = new ObservableCollection<TransformType>();
    }

    [XmlArrayItem("Transform", IsNullable = false)]
    public ObservableCollection<TransformType> Transforms
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ReferenceType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class TransformType : INotifyPropertyChanged
{
    private ObservableCollection<string> xPathField;
    private TTransformURI algorithmField;
    private static XmlSerializer sSerializer;

    public TransformType() : base()
    {
        xPathField = new ObservableCollection<string>();
    }

    [XmlElement("XPath")]
    public ObservableCollection<string> XPath
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TransformType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class ReferenceTypeDigestMethod : INotifyPropertyChanged
{
    private string algorithmField;
    private static XmlSerializer sSerializer;

    public ReferenceTypeDigestMethod() : base()
    {
        algorithmField = "http://www.w3.org/2000/09/xmldsig#sha1";
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ReferenceTypeDigestMethod));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class SignatureValueType : INotifyPropertyChanged
{
    private string idField;
    private byte[] valueField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(SignatureValueType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class KeyInfoType : INotifyPropertyChanged
{
    private X509DataType x509DataField;
    private string idField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(KeyInfoType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
public partial class X509DataType : INotifyPropertyChanged
{
    private byte[] x509CertificateField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(X509DataType));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TUnidCarga : INotifyPropertyChanged
{
    private TtipoUnidCarga tpUnidCargaField;
    private string idUnidCargaField;
    private ObservableCollection<TUnidCargaLacUnidCarga> lacUnidCargaField;
    private string qtdRatField;
    private static XmlSerializer sSerializer;

    public TUnidCarga() : base()
    {
        lacUnidCargaField = new ObservableCollection<TUnidCargaLacUnidCarga>();
    }

    public TtipoUnidCarga tpUnidCarga
    {
        get
        {
            return tpUnidCargaField;
        }

        set
        {
            if (tpUnidCargaField.Equals(value) != true)
            {
                tpUnidCargaField = value;
                OnPropertyChanged("tpUnidCarga");
            }
        }
    }

    public string idUnidCarga
    {
        get
        {
            return idUnidCargaField;
        }

        set
        {
            if (idUnidCargaField is null || idUnidCargaField.Equals(value) != true)
            {
                idUnidCargaField = value;
                OnPropertyChanged("idUnidCarga");
            }
        }
    }

    [XmlElement("lacUnidCarga")]
    public ObservableCollection<TUnidCargaLacUnidCarga> lacUnidCarga
    {
        get
        {
            return lacUnidCargaField;
        }

        set
        {
            if (lacUnidCargaField is null || lacUnidCargaField.Equals(value) != true)
            {
                lacUnidCargaField = value;
                OnPropertyChanged("lacUnidCarga");
            }
        }
    }

    public string qtdRat
    {
        get
        {
            return qtdRatField;
        }

        set
        {
            if (qtdRatField is null || qtdRatField.Equals(value) != true)
            {
                qtdRatField = value;
                OnPropertyChanged("qtdRat");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TUnidCarga));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TUnidCargaLacUnidCarga : INotifyPropertyChanged
{
    private string nLacreField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TUnidCargaLacUnidCarga));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TUnidadeTransp : INotifyPropertyChanged
{
    private TtipoUnidTransp tpUnidTranspField;
    private string idUnidTranspField;
    private ObservableCollection<TUnidadeTranspLacUnidTransp> lacUnidTranspField;
    private ObservableCollection<TUnidCarga> infUnidCargaField;
    private string qtdRatField;
    private static XmlSerializer sSerializer;

    public TUnidadeTransp() : base()
    {
        infUnidCargaField = new ObservableCollection<TUnidCarga>();
        lacUnidTranspField = new ObservableCollection<TUnidadeTranspLacUnidTransp>();
    }

    public TtipoUnidTransp tpUnidTransp
    {
        get
        {
            return tpUnidTranspField;
        }

        set
        {
            if (tpUnidTranspField.Equals(value) != true)
            {
                tpUnidTranspField = value;
                OnPropertyChanged("tpUnidTransp");
            }
        }
    }

    public string idUnidTransp
    {
        get
        {
            return idUnidTranspField;
        }

        set
        {
            if (idUnidTranspField is null || idUnidTranspField.Equals(value) != true)
            {
                idUnidTranspField = value;
                OnPropertyChanged("idUnidTransp");
            }
        }
    }

    [XmlElement("lacUnidTransp")]
    public ObservableCollection<TUnidadeTranspLacUnidTransp> lacUnidTransp
    {
        get
        {
            return lacUnidTranspField;
        }

        set
        {
            if (lacUnidTranspField is null || lacUnidTranspField.Equals(value) != true)
            {
                lacUnidTranspField = value;
                OnPropertyChanged("lacUnidTransp");
            }
        }
    }

    [XmlElement("infUnidCarga")]
    public ObservableCollection<TUnidCarga> infUnidCarga
    {
        get
        {
            return infUnidCargaField;
        }

        set
        {
            if (infUnidCargaField is null || infUnidCargaField.Equals(value) != true)
            {
                infUnidCargaField = value;
                OnPropertyChanged("infUnidCarga");
            }
        }
    }

    public string qtdRat
    {
        get
        {
            return qtdRatField;
        }

        set
        {
            if (qtdRatField is null || qtdRatField.Equals(value) != true)
            {
                qtdRatField = value;
                OnPropertyChanged("qtdRat");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TUnidadeTransp));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TUnidadeTranspLacUnidTransp : INotifyPropertyChanged
{
    private string nLacreField;
    private static XmlSerializer sSerializer;

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TUnidadeTranspLacUnidTransp));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class ICMS : INotifyPropertyChanged
{
    private DetalhamentoICMS itemField;
    private Tributacao_ICMS_Identifier itemElementNameField;
    private static XmlSerializer sSerializer;

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
        get
        {
            return itemField;
        }

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
        get
        {
            return itemElementNameField;
        }

        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("TributacaoIndentifier");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ICMS));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public class InftributosFederais : INotifyPropertyChanged
{
    private double? _vINSS;

    public double? vINSS
    {
        get
        {
            return _vINSS;
        }

        set
        {
            if (_vINSS is null || _vINSS.Equals(value) != true)
            {
                _vINSS = value;
                OnPropertyChanged("vINSS");
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public NFe.CST_ICMS CST
    {
        get
        {
            return cSTField;
        }

        set
        {
            if (cSTField.Equals(value) != true)
            {
                cSTField = value;
                OnPropertyChanged("CST");
            }
        }
    }

    public double? vBC
    {
        get
        {
            return vBCField;
        }

        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged("vBC");
            }
        }
    }

    public bool ShouldSerializevBC()
    {
        return vBCField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);
    }

    public double? pRedBC
    {
        get
        {
            return pRedBCField;
        }

        set
        {
            if (pRedBCField is null || pRedBCField.Equals(value) != true)
            {
                pRedBCField = value;
                OnPropertyChanged("pRedBC");
            }
        }
    }

    public bool ShouldSerializepRedBC()
    {
        return pRedBCField.HasValue & (CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);
    }

    public double? pICMS
    {
        get
        {
            return pICMSField;
        }

        set
        {
            if (pICMSField is null || pICMSField.Equals(value) != true)
            {
                pICMSField = value;
                OnPropertyChanged("pICMS");
            }
        }
    }

    public bool ShouldSerializepICMS()
    {
        return pICMSField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);
    }

    public double? vICMS
    {
        get
        {
            return vICMSField;
        }

        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged("vICMS");
            }
        }
    }

    public bool ShouldSerializevICMS()
    {
        return vICMSField.HasValue & (CST == NFe.CST_ICMS.CST_00 | CST == NFe.CST_ICMS.CST_20 | CST == NFe.CST_ICMS.CST_90);
    }

    public double? vBCSTRet
    {
        get
        {
            return vBCSTRetField;
        }

        set
        {
            if (vBCSTRetField is null || vBCSTRetField.Equals(value) != true)
            {
                vBCSTRetField = value;
                OnPropertyChanged("vBCSTRet");
            }
        }
    }

    public bool ShouldSerializevBCSTRet()
    {
        return vBCSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;
    }

    public double? vICMSSTRet
    {
        get
        {
            return vICMSSTRetField;
        }

        set
        {
            if (vICMSSTRetField is null || vICMSSTRetField.Equals(value) != true)
            {
                vICMSSTRetField = value;
                OnPropertyChanged("vICMSSTRet");
            }
        }
    }

    public bool ShouldSerializevICMSSTRet()
    {
        return vICMSSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;
    }

    public double? pICMSSTRet
    {
        get
        {
            return pICMSSTRetField;
        }

        set
        {
            if (pICMSSTRetField is null || pICMSSTRetField.Equals(value) != true)
            {
                pICMSSTRetField = value;
                OnPropertyChanged("pICMSSTRet");
            }
        }
    }

    public bool ShouldSerializepICMSSTRet()
    {
        return pICMSSTRetField.HasValue & CST == NFe.CST_ICMS.CST_60;
    }

    public double? vCred
    {
        get
        {
            return vCredField;
        }

        set
        {
            if (vCredField is null || vCredField.Equals(value) != true)
            {
                vCredField = value;
                OnPropertyChanged("vCred");
            }
        }
    }

    public bool ShouldSerializevCred()
    {
        return vCredField.HasValue & (CST == NFe.CST_ICMS.CST_60 | CST == NFe.CST_ICMS.CST_90);
    }

    public double? pRedBCOutraUF
    {
        get
        {
            return pRedBCOutraUFField;
        }

        set
        {
            if (pRedBCOutraUFField is null || pRedBCOutraUFField.Equals(value) != true)
            {
                pRedBCOutraUFField = value;
                OnPropertyChanged("pRedBCOutraUF");
            }
        }
    }

    public bool ShouldSerializepRedBCOutraUF()
    {
        return pRedBCOutraUFField.HasValue;
    }

    public string vBCOutraUF
    {
        get
        {
            return Conversions.ToString(vBCOutraUFField);
        }

        set
        {
            if (vBCOutraUFField is null || vBCOutraUFField.Equals(value) != true)
            {
                vBCOutraUFField = value.ToNullableDouble();
                OnPropertyChanged("vBCOutraUF");
            }
        }
    }

    public bool ShouldSerializevBCOutraUF()
    {
        return vBCOutraUFField.HasValue;
    }

    public string pICMSOutraUF
    {
        get
        {
            return Conversions.ToString(pICMSOutraUFField);
        }

        set
        {
            if (pICMSOutraUFField is null || pICMSOutraUFField.Equals(value) != true)
            {
                pICMSOutraUFField = value.ToNullableDouble();
                OnPropertyChanged("pICMSOutraUF");
            }
        }
    }

    public bool ShouldSerializepICMSOutraUF()
    {
        return pICMSOutraUFField.HasValue;
    }

    public string vICMSOutraUF
    {
        get
        {
            return Conversions.ToString(vICMSOutraUFField);
        }

        set
        {
            if (vICMSOutraUFField is null || vICMSOutraUFField.Equals(value) != true)
            {
                vICMSOutraUFField = value.ToNullableDouble();
                OnPropertyChanged("vICMSOutraUF");
            }
        }
    }

    public bool ShouldSerializevICMSOutraUF()
    {
        return vICMSOutraUFField.HasValue;
    }

    public DetalhamentoICMSIndicadorSN indSN
    {
        get
        {
            return indSNField;
        }

        set
        {
            if (indSNField.Equals(value) != true)
            {
                indSNField = value;
                OnPropertyChanged("indSN");
            }
        }
    }

    public bool ShouldSerializeindSN()
    {
        return vCredField.HasValue == false & CST != NFe.CST_ICMS.CST_60 & CST != NFe.CST_ICMS.CST_90;
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(DetalhamentoICMS));
            }

            return sSerializer;
        }
    }

    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string xLgr
    {
        get
        {
            return xLgrField;
        }

        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged("xLgr");
            }
        }
    }

    public string nro
    {
        get
        {
            return nroField;
        }

        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged("nro");
            }
        }
    }

    public string xCpl
    {
        get
        {
            return xCplField;
        }

        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged("xCpl");
            }
        }
    }

    public string xBairro
    {
        get
        {
            return xBairroField;
        }

        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged("xBairro");
            }
        }
    }

    public string cMun
    {
        get
        {
            return cMunField;
        }

        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged("cMun");
            }
        }
    }

    public string xMun
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
                OnPropertyChanged("xMun");
            }
        }
    }

    public NFe.Estado UF
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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TEndReEnt));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public string xLgr
    {
        get
        {
            return xLgrField;
        }

        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged("xLgr");
            }
        }
    }

    public string nro
    {
        get
        {
            return nroField;
        }

        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged("nro");
            }
        }
    }

    public string xCpl
    {
        get
        {
            return xCplField;
        }

        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged("xCpl");
            }
        }
    }

    public string xBairro
    {
        get
        {
            return xBairroField;
        }

        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged("xBairro");
            }
        }
    }

    public string cMun
    {
        get
        {
            return cMunField;
        }

        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged("cMun");
            }
        }
    }

    public string xMun
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
                OnPropertyChanged("xMun");
            }
        }
    }

    public string CEP
    {
        get
        {
            return cEPField;
        }

        set
        {
            if (cEPField is null || cEPField.Equals(value) != true)
            {
                cEPField = value;
                OnPropertyChanged("CEP");
            }
        }
    }

    public TUF_sem_EX UF
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

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TEndeEmi));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public string xLgr
    {
        get
        {
            return xLgrField;
        }

        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged("xLgr");
            }
        }
    }

    public string nro
    {
        get
        {
            return nroField;
        }

        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged("nro");
            }
        }
    }

    public string xCpl
    {
        get
        {
            return xCplField;
        }

        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged("xCpl");
            }
        }
    }

    public string xBairro
    {
        get
        {
            return xBairroField;
        }

        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged("xBairro");
            }
        }
    }

    public string cMun
    {
        get
        {
            return cMunField;
        }

        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged("cMun");
            }
        }
    }

    public string xMun
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
                OnPropertyChanged("xMun");
            }
        }
    }

    public string CEP
    {
        get
        {
            return cEPField;
        }

        set
        {
            if (cEPField is null || cEPField.Equals(value) != true)
            {
                cEPField = value;
                OnPropertyChanged("CEP");
                OnPropertyChanged("CEPFormatado");
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

    public string cPais
    {
        get
        {
            return cPaisField;
        }

        set
        {
            if (cPaisField is null || cPaisField.Equals(value) != true)
            {
                cPaisField = value;
                OnPropertyChanged("cPais");
            }
        }
    }

    public string xPais
    {
        get
        {
            return xPaisField;
        }

        set
        {
            if (xPaisField is null || xPaisField.Equals(value) != true)
            {
                xPaisField = value;
                OnPropertyChanged("xPais");
            }
        }
    }

    public string fone
    {
        get
        {
            return fonefield;
        }

        set
        {
            if (fonefield is null || fonefield.Equals(value) != true)
            {
                fonefield = value;
                OnPropertyChanged("fone");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Endereco));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public ComplementoCTe() : base()
    {
        obsFiscoField = new ObservableCollection<TCTeInfCteComplObsFisco>();
        obsContField = new ObservableCollection<TCTeInfCteComplObsCont>();
        entregaField = new TCTeInfCteComplEntrega();
        fluxoField = new TCTeInfCteComplFluxo();
    }

    public string xCaracAd
    {
        get
        {
            return xCaracAdField;
        }

        set
        {
            if (xCaracAdField is null || xCaracAdField.Equals(value) != true)
            {
                xCaracAdField = value;
                OnPropertyChanged("xCaracAd");
            }
        }
    }

    public string xCaracSer
    {
        get
        {
            return xCaracSerField;
        }

        set
        {
            if (xCaracSerField is null || xCaracSerField.Equals(value) != true)
            {
                xCaracSerField = value;
                OnPropertyChanged("xCaracSer");
            }
        }
    }

    public string xEmi
    {
        get
        {
            return xEmiField;
        }

        set
        {
            if (xEmiField is null || xEmiField.Equals(value) != true)
            {
                xEmiField = value;
                OnPropertyChanged("xEmi");
            }
        }
    }

    public TCTeInfCteComplFluxo fluxo
    {
        get
        {
            return fluxoField;
        }

        set
        {
            if (fluxoField is null || fluxoField.Equals(value) != true)
            {
                fluxoField = value;
                OnPropertyChanged("fluxo");
            }
        }
    }

    public TCTeInfCteComplEntrega Entrega
    {
        get
        {
            return entregaField;
        }

        set
        {
            if (entregaField is null || entregaField.Equals(value) != true)
            {
                entregaField = value;
                OnPropertyChanged("Entrega");
            }
        }
    }

    public string origCalc
    {
        get
        {
            return origCalcField;
        }

        set
        {
            if (origCalcField is null || origCalcField.Equals(value) != true)
            {
                origCalcField = value;
                OnPropertyChanged("origCalc");
            }
        }
    }

    public string destCalc
    {
        get
        {
            return destCalcField;
        }

        set
        {
            if (destCalcField is null || destCalcField.Equals(value) != true)
            {
                destCalcField = value;
                OnPropertyChanged("destCalc");
            }
        }
    }

    public string xObs
    {
        get
        {
            return xObsField;
        }

        set
        {
            if (xObsField is null || xObsField.Equals(value) != true)
            {
                xObsField = value;
                OnPropertyChanged("xObs");
            }
        }
    }

    [XmlElement("ObsCont")]
    public ObservableCollection<TCTeInfCteComplObsCont> ObsCont
    {
        get
        {
            return obsContField;
        }

        set
        {
            if (obsContField is null || obsContField.Equals(value) != true)
            {
                obsContField = value;
                OnPropertyChanged("ObsCont");
            }
        }
    }

    [XmlElement("ObsFisco")]
    public ObservableCollection<TCTeInfCteComplObsFisco> ObsFisco
    {
        get
        {
            return obsFiscoField;
        }

        set
        {
            if (obsFiscoField is null || obsFiscoField.Equals(value) != true)
            {
                obsFiscoField = value;
                OnPropertyChanged("ObsFisco");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ComplementoCTe));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplFluxo : INotifyPropertyChanged
{
    private string xOrigField;
    private ObservableCollection<TCTeInfCteComplFluxoPass> passField;
    private string xDestField;
    private string xRotaField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplFluxo() : base()
    {
        passField = new ObservableCollection<TCTeInfCteComplFluxoPass>();
    }

    public string xOrig
    {
        get
        {
            return xOrigField;
        }

        set
        {
            if (xOrigField is null || xOrigField.Equals(value) != true)
            {
                xOrigField = value;
                OnPropertyChanged("xOrig");
            }
        }
    }

    [XmlElement("pass")]
    public ObservableCollection<TCTeInfCteComplFluxoPass> pass
    {
        get
        {
            return passField;
        }

        set
        {
            if (passField is null || passField.Equals(value) != true)
            {
                passField = value;
                OnPropertyChanged("pass");
            }
        }
    }

    public string xDest
    {
        get
        {
            return xDestField;
        }

        set
        {
            if (xDestField is null || xDestField.Equals(value) != true)
            {
                xDestField = value;
                OnPropertyChanged("xDest");
            }
        }
    }

    public string xRota
    {
        get
        {
            return xRotaField;
        }

        set
        {
            if (xRotaField is null || xRotaField.Equals(value) != true)
            {
                xRotaField = value;
                OnPropertyChanged("xRota");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplFluxo));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplFluxoPass : INotifyPropertyChanged
{
    private string xPassField;
    private static XmlSerializer sSerializer;

    public string xPass
    {
        get
        {
            return xPassField;
        }

        set
        {
            if (xPassField is null || xPassField.Equals(value) != true)
            {
                xPassField = value;
                OnPropertyChanged("xPass");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplFluxoPass));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntrega : INotifyPropertyChanged
{
    private object itemField;
    private object item1Field;
    private static XmlSerializer sSerializer;

    [XmlElement("comData", typeof(TCTeInfCteComplEntregaComData))]
    [XmlElement("noPeriodo", typeof(TCTeInfCteComplEntregaNoPeriodo))]
    [XmlElement("semData", typeof(TCTeInfCteComplEntregaSemData))]
    public object Item
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
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlElement("comHora", typeof(TCTeInfCteComplEntregaComHora))]
    [XmlElement("noInter", typeof(TCTeInfCteComplEntregaNoInter))]
    [XmlElement("semHora", typeof(TCTeInfCteComplEntregaSemHora))]
    public object Item1
    {
        get
        {
            return item1Field;
        }

        set
        {
            if (item1Field is null || item1Field.Equals(value) != true)
            {
                item1Field = value;
                OnPropertyChanged("Item1");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntrega));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaComData : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaComDataTpPer tpPerField;
    private string dProgField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaComDataTpPer tpPer
    {
        get
        {
            return tpPerField;
        }

        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged("tpPer");
            }
        }
    }

    public string dProg
    {
        get
        {
            return dProgField;
        }

        set
        {
            if (dProgField is null || dProgField.Equals(value) != true)
            {
                dProgField = value;
                OnPropertyChanged("dProg");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaComData));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaNoPeriodo : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaNoPeriodoTpPer tpPerField;
    private string dIniField;
    private string dFimField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaNoPeriodoTpPer tpPer
    {
        get
        {
            return tpPerField;
        }

        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged("tpPer");
            }
        }
    }

    public string dIni
    {
        get
        {
            return dIniField;
        }

        set
        {
            if (dIniField is null || dIniField.Equals(value) != true)
            {
                dIniField = value;
                OnPropertyChanged("dIni");
            }
        }
    }

    public string dFim
    {
        get
        {
            return dFimField;
        }

        set
        {
            if (dFimField is null || dFimField.Equals(value) != true)
            {
                dFimField = value;
                OnPropertyChanged("dFim");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaNoPeriodo));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TCTeInfCteComplEntregaNoPeriodoTpPer
{

    /// <remarks/>
    [XmlEnum("4")]
    Item4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaSemData : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaSemDataTpPer tpPerField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaSemDataTpPer tpPer
    {
        get
        {
            return tpPerField;
        }

        set
        {
            if (tpPerField.Equals(value) != true)
            {
                tpPerField = value;
                OnPropertyChanged("tpPer");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaSemData));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TCTeInfCteComplEntregaSemDataTpPer
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaComHora : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaComHoraTpHor tpHorField;
    private string hProgField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaComHoraTpHor tpHor
    {
        get
        {
            return tpHorField;
        }

        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged("tpHor");
            }
        }
    }

    public string hProg
    {
        get
        {
            return hProgField;
        }

        set
        {
            if (hProgField is null || hProgField.Equals(value) != true)
            {
                hProgField = value;
                OnPropertyChanged("hProg");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaComHora));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaNoInter : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaNoInterTpHor tpHorField;
    private string hIniField;
    private string hFimField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaNoInterTpHor tpHor
    {
        get
        {
            return tpHorField;
        }

        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged("tpHor");
            }
        }
    }

    public string hIni
    {
        get
        {
            return hIniField;
        }

        set
        {
            if (hIniField is null || hIniField.Equals(value) != true)
            {
                hIniField = value;
                OnPropertyChanged("hIni");
            }
        }
    }

    public string hFim
    {
        get
        {
            return hFimField;
        }

        set
        {
            if (hFimField is null || hFimField.Equals(value) != true)
            {
                hFimField = value;
                OnPropertyChanged("hFim");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaNoInter));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TCTeInfCteComplEntregaNoInterTpHor
{

    /// <remarks/>
    [XmlEnum("4")]
    Item4
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplEntregaSemHora : INotifyPropertyChanged
{
    private TCTeInfCteComplEntregaSemHoraTpHor tpHorField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteComplEntregaSemHoraTpHor tpHor
    {
        get
        {
            return tpHorField;
        }

        set
        {
            if (tpHorField.Equals(value) != true)
            {
                tpHorField = value;
                OnPropertyChanged("tpHor");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplEntregaSemHora));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TCTeInfCteComplEntregaSemHoraTpHor
{

    /// <remarks/>
    [XmlEnum("0")]
    Item0
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplObsCont : INotifyPropertyChanged
{
    private string xTextoField;
    private string xCampoField;
    private static XmlSerializer sSerializer;

    public string xTexto
    {
        get
        {
            return xTextoField;
        }

        set
        {
            if (xTextoField is null || xTextoField.Equals(value) != true)
            {
                xTextoField = value;
                OnPropertyChanged("xTexto");
            }
        }
    }

    [XmlAttribute()]
    public string xCampo
    {
        get
        {
            return xCampoField;
        }

        set
        {
            if (xCampoField is null || xCampoField.Equals(value) != true)
            {
                xCampoField = value;
                OnPropertyChanged("xCampo");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplObsCont));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteComplObsFisco : INotifyPropertyChanged
{
    private string xTextoField;
    private string xCampoField;
    private static XmlSerializer sSerializer;

    public string xTexto
    {
        get
        {
            return xTextoField;
        }

        set
        {
            if (xTextoField is null || xTextoField.Equals(value) != true)
            {
                xTextoField = value;
                OnPropertyChanged("xTexto");
            }
        }
    }

    [XmlAttribute()]
    public string xCampo
    {
        get
        {
            return xCampoField;
        }

        set
        {
            if (xCampoField is null || xCampoField.Equals(value) != true)
            {
                xCampoField = value;
                OnPropertyChanged("xCampo");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteComplObsFisco));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class Emitente : INotifyPropertyChanged
{
    private string cNPJField;
    private string ieField;
    private string xNomeField;
    private string xFantField;
    private Endereco enderEmitField;
    private static XmlSerializer sSerializer;

    public Emitente() : base()
    {
        enderEmitField = new Endereco();
    }

    public string CNPJ
    {
        get
        {
            return cNPJField;
        }

        set
        {
            if (cNPJField is null || cNPJField.Equals(value) != true)
            {
                cNPJField = value;
                OnPropertyChanged("CNPJ");
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
        get
        {
            return ieField;
        }

        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string xFant
    {
        get
        {
            return xFantField;
        }

        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged("xFant");
            }
        }
    }

    [XmlElement("enderEmit")]
    public Endereco Endereco
    {
        get
        {
            return enderEmitField;
        }

        set
        {
            if (enderEmitField is null || enderEmitField.Equals(value) != true)
            {
                enderEmitField = value;
                OnPropertyChanged("Endereco");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Emitente));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNF> infNFField = new ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNF>();
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNFe> infNFeField = new ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNFe>();
    private ObservableCollection<TCTeInfCteInfCTeNormInfDocInfOutros> infOutrsField = new ObservableCollection<TCTeInfCteInfCTeNormInfDocInfOutros>();
    private TEndReEnt locColetaField;
    private static XmlSerializer sSerializer;

    public Remetente() : base()
    {
        // Me.locColetaField = New TEndReEnt()
        enderRemeField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string xFant
    {
        get
        {
            return xFantField;
        }

        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged("xFant");
            }
        }
    }

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    [XmlElement("enderReme")]
    public Endereco Endereco
    {
        get
        {
            return enderRemeField;
        }

        set
        {
            if (enderRemeField is null || enderRemeField.Equals(value) != true)
            {
                enderRemeField = value;
                OnPropertyChanged("Endereco");
            }
        }
    }

    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged("email");
            }
        }
    }

    [XmlElement("infNF")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNF> InfNF
    {
        get
        {
            return infNFField;
        }

        set
        {
            infNFField = value;
            OnPropertyChanged("InfNF");
        }
    }

    [XmlElement("infNFe")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfDocInfNFe> InfNFe
    {
        get
        {
            return infNFeField;
        }

        set
        {
            infNFeField = value;
            OnPropertyChanged("InfNFe");
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
        get
        {
            return infOutrsField;
        }

        set
        {
            infOutrsField = value;
            OnPropertyChanged("infOutros");
        }
    }

    public TEndReEnt locColeta
    {
        get
        {
            return locColetaField;
        }

        set
        {
            if (locColetaField is null || locColetaField.Equals(value) != true)
            {
                locColetaField = value;
                OnPropertyChanged("locColeta");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Remetente));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class Expedidor : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string foneField;
    private Endereco enderExpedField;
    private string emailField;
    private static XmlSerializer sSerializer;

    public Expedidor() : base()
    {
        enderExpedField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    [XmlElement("enderExped")]
    public Endereco Endereco
    {
        get
        {
            return enderExpedField;
        }

        set
        {
            if (enderExpedField is null || enderExpedField.Equals(value) != true)
            {
                enderExpedField = value;
                OnPropertyChanged("Endereco");
            }
        }
    }

    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged("email");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Expedidor));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class Recebedor : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string foneField;
    private Endereco enderRecebField;
    private string emailField;
    private static XmlSerializer sSerializer;

    public Recebedor() : base()
    {
        enderRecebField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    public Endereco enderReceb
    {
        get
        {
            return enderRecebField;
        }

        set
        {
            if (enderRecebField is null || enderRecebField.Equals(value) != true)
            {
                enderRecebField = value;
                OnPropertyChanged("enderReceb");
            }
        }
    }

    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged("email");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Recebedor));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public Destinatario() : base()
    {
        locEntField = new TEndReEnt();
        enderDestField = new Endereco();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    public string ISUF
    {
        get
        {
            return iSUFField;
        }

        set
        {
            if (iSUFField is null || iSUFField.Equals(value) != true)
            {
                iSUFField = value;
                OnPropertyChanged("ISUF");
            }
        }
    }

    [XmlElement("enderDest")]
    public Endereco Endereco
    {
        get
        {
            return enderDestField;
        }

        set
        {
            if (enderDestField is null || enderDestField.Equals(value) != true)
            {
                enderDestField = value;
                OnPropertyChanged("Endereco");
            }
        }
    }

    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged("email");
            }
        }
    }

    public TEndReEnt locEnt
    {
        get
        {
            return locEntField;
        }

        set
        {
            if (locEntField is null || locEntField.Equals(value) != true)
            {
                locEntField = value;
                OnPropertyChanged("locEnt");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Destinatario));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TomadorTipo03 : INotifyPropertyChanged
{
    private TipoTomador tomaField;
    private static XmlSerializer sSerializer;

    public TipoTomador toma
    {
        get
        {
            return tomaField;
        }

        set
        {
            if (tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged("toma");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TomadorTipo03));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TomadorTipo3 : TomadorTipo03
{
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public TomadorTipo04() : base()
    {
        enderTomaField = new Endereco();
    }

    public TipoTomador toma
    {
        get
        {
            return tomaField;
        }

        set
        {
            if (tomaField.Equals(value) != true)
            {
                tomaField = value;
                OnPropertyChanged("toma");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
    {
        get
        {
            return itemElementNameField;
        }

        set
        {
            itemElementNameField = value;
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public string xFant
    {
        get
        {
            return xFantField;
        }

        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged("xFant");
            }
        }
    }

    public string fone
    {
        get
        {
            return foneField;
        }

        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged("fone");
            }
        }
    }

    [XmlElement("enderToma")]
    public Endereco Endereco
    {
        get
        {
            return enderTomaField;
        }

        set
        {
            if (enderTomaField is null || enderTomaField.Equals(value) != true)
            {
                enderTomaField = value;
                OnPropertyChanged("Endereco");
            }
        }
    }

    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged("email");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TomadorTipo04));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class ValoresPrestacaoServico : INotifyPropertyChanged
{
    private double? vTPrestField;
    private double? vRecField;
    private ObservableCollection<TCTeInfCteVPrestComp> compField;
    private static XmlSerializer sSerializer;

    public ValoresPrestacaoServico() : base()
    {
        compField = new ObservableCollection<TCTeInfCteVPrestComp>();
    }

    public double? vTPrest
    {
        get
        {
            return vTPrestField;
        }

        set
        {
            if (vTPrestField is null || vTPrestField.Equals(value) != true)
            {
                vTPrestField = value;
                OnPropertyChanged("vTPrest");
            }
        }
    }

    public double? vRec
    {
        get
        {
            return vRecField;
        }

        set
        {
            if (vRecField is null || vRecField.Equals(value) != true)
            {
                vRecField = value;
                OnPropertyChanged("vRec");
            }
        }
    }

    [XmlElement("Comp")]
    public ObservableCollection<TCTeInfCteVPrestComp> Comp
    {
        get
        {
            return compField;
        }

        set
        {
            if (compField is null || compField.Equals(value) != true)
            {
                compField = value;
                OnPropertyChanged("Comp");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ValoresPrestacaoServico));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteVPrestComp : INotifyPropertyChanged
{
    private string xNomeField;
    private double? vCompField;
    private static XmlSerializer sSerializer;

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    public double? vComp
    {
        get
        {
            return vCompField;
        }

        set
        {
            if (vCompField is null || vCompField.Equals(value) != true)
            {
                vCompField = value;
                OnPropertyChanged("vComp");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteVPrestComp));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class Impostos : INotifyPropertyChanged
{
    private ICMS iCMSField;
    private InftributosFederais federaisField;
    private double? vTotTribField;
    private string infAdFiscoField;
    private static XmlSerializer sSerializer;

    public Impostos() : base()
    {
        iCMSField = new ICMS();
    }

    public ICMS ICMS
    {
        get
        {
            return iCMSField;
        }

        set
        {
            if (iCMSField is null || iCMSField.Equals(value) != true)
            {
                iCMSField = value;
                OnPropertyChanged("ICMS");
            }
        }
    }

    public InftributosFederais infTribFed
    {
        get
        {
            return federaisField;
        }

        set
        {
            if (federaisField is null || federaisField.Equals(value) != true)
            {
                federaisField = value;
                OnPropertyChanged("infTribFed");
            }
        }
    }

    public double? vTotTrib
    {
        get
        {
            return vTotTribField;
        }

        set
        {
            if (vTotTribField is null || vTotTribField.Equals(value) != true)
            {
                vTotTribField = value;
                OnPropertyChanged("vTotTrib");
            }
        }
    }

    public bool ShouldSerializevTotTrib()
    {
        return vTotTribField.HasValue;
    }

    public string infAdFisco
    {
        get
        {
            return infAdFiscoField;
        }

        set
        {
            if (infAdFiscoField is null || infAdFiscoField.Equals(value) != true)
            {
                infAdFiscoField = value;
                OnPropertyChanged("infAdFisco");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(Impostos));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public InformacoesCteNormal() : base()
    {
        // Me.infCteSubField = New TCTeInfCteInfCTeNormInfCteSub()
        // Me.cobrField = New TCTeInfCteInfCTeNormCobr()
        veicNovosField = new ObservableCollection<TCTeInfCteInfCTeNormVeicNovos>();
        periField = new ObservableCollection<TCTeInfCteInfCTeNormPeri>();
        infModalField = new TCTeInfCteInfCTeNormInfModal();
        segField = new ObservableCollection<TCTeInfCteInfCTeNormSeg>();
        docAntField = new ObservableCollection<CTeNormalEmitenteDocumentonterior>();
        infDocField = new TCTeInfCteInfCTeNormInfDoc();
        infCargaField = new TCTeInfCteInfCTeNormInfCarga();
    }

    public TCTeInfCteInfCTeNormInfCarga infCarga
    {
        get
        {
            return infCargaField;
        }

        set
        {
            if (infCargaField is null || infCargaField.Equals(value) != true)
            {
                infCargaField = value;
                OnPropertyChanged("infCarga");
            }
        }
    }

    public TCTeInfCteInfCTeNormInfDoc infDoc
    {
        get
        {
            return infDocField;
        }

        set
        {
            if (infDocField is null || infDocField.Equals(value) != true)
            {
                infDocField = value;
                OnPropertyChanged("infDoc");
            }
        }
    }

    [XmlArrayItem("emiDocAnt", IsNullable = false)]
    public ObservableCollection<CTeNormalEmitenteDocumentonterior> docAnt
    {
        get
        {
            return docAntField;
        }

        set
        {
            if (docAntField is null || docAntField.Equals(value) != true)
            {
                docAntField = value;
                OnPropertyChanged("docAnt");
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
        get
        {
            return segField;
        }

        set
        {
            if (segField is null || segField.Equals(value) != true)
            {
                segField = value;
                OnPropertyChanged("seg");
            }
        }
    }

    public TCTeInfCteInfCTeNormInfModal infModal
    {
        get
        {
            return infModalField;
        }

        set
        {
            if (infModalField is null || infModalField.Equals(value) != true)
            {
                infModalField = value;
                OnPropertyChanged("infModal");
            }
        }
    }

    [XmlElement("peri")]
    public ObservableCollection<TCTeInfCteInfCTeNormPeri> peri
    {
        get
        {
            return periField;
        }

        set
        {
            if (periField is null || periField.Equals(value) != true)
            {
                periField = value;
                OnPropertyChanged("peri");
            }
        }
    }

    [XmlElement("veicNovos")]
    public ObservableCollection<TCTeInfCteInfCTeNormVeicNovos> veicNovos
    {
        get
        {
            return veicNovosField;
        }

        set
        {
            if (veicNovosField is null || veicNovosField.Equals(value) != true)
            {
                veicNovosField = value;
                OnPropertyChanged("veicNovos");
            }
        }
    }

    public TCTeInfCteInfCTeNormCobr cobr
    {
        get
        {
            return cobrField;
        }

        set
        {
            if (cobrField is null || cobrField.Equals(value) != true)
            {
                cobrField = value;
                OnPropertyChanged("cobr");
            }
        }
    }

    public TCTeInfCteInfCTeNormInfCteSub infCteSub
    {
        get
        {
            return infCteSubField;
        }

        set
        {
            if (infCteSubField is null || infCteSubField.Equals(value) != true)
            {
                infCteSubField = value;
                OnPropertyChanged("infCteSub");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(InformacoesCteNormal));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfCarga : INotifyPropertyChanged
{
    private double? vCargaField;
    private string proPredField;
    private string xOutCatField;
    private ObservableCollection<TCTeInfCteInfCTeNormInfCargaInfQ> infQField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfCarga() : base()
    {
        infQField = new ObservableCollection<TCTeInfCteInfCTeNormInfCargaInfQ>();
    }

    public double? vCarga
    {
        get
        {
            return vCargaField;
        }

        set
        {
            if (vCargaField is null || vCargaField.Equals(value) != true)
            {
                vCargaField = value;
                OnPropertyChanged("vCarga");
            }
        }
    }

    public string proPred
    {
        get
        {
            return proPredField;
        }

        set
        {
            if (proPredField is null || proPredField.Equals(value) != true)
            {
                proPredField = value;
                OnPropertyChanged("proPred");
            }
        }
    }

    public string xOutCat
    {
        get
        {
            return xOutCatField;
        }

        set
        {
            if (xOutCatField is null || xOutCatField.Equals(value) != true)
            {
                xOutCatField = value;
                OnPropertyChanged("xOutCat");
            }
        }
    }

    [XmlElement("infQ")]
    public ObservableCollection<TCTeInfCteInfCTeNormInfCargaInfQ> infQ
    {
        get
        {
            return infQField;
        }

        set
        {
            if (infQField is null || infQField.Equals(value) != true)
            {
                infQField = value;
                OnPropertyChanged("infQ");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCarga));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfCargaInfQ : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormInfCargaInfQCUnid cUnidField;
    private string tpMedField;
    private string qCargaField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfCargaInfQCUnid cUnid
    {
        get
        {
            return cUnidField;
        }

        set
        {
            if (cUnidField.Equals(value) != true)
            {
                cUnidField = value;
                OnPropertyChanged("cUnid");
            }
        }
    }

    public string tpMed
    {
        get
        {
            return tpMedField;
        }

        set
        {
            if (tpMedField is null || tpMedField.Equals(value) != true)
            {
                tpMedField = value;
                OnPropertyChanged("tpMed");
            }
        }
    }

    public string qCarga
    {
        get
        {
            return qCargaField;
        }

        set
        {
            if (qCargaField is null || qCargaField.Equals(value) != true)
            {
                qCargaField = value;
                OnPropertyChanged("qCarga");
            }
        }
    }

    public override string ToString()
    {
        // Return MyBase.ToString()
        return qCarga + "/" + tpMed;
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCargaInfQ));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfDoc : INotifyPropertyChanged
{
    private ObservableCollection<object> itemsField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfDoc() : base()
    {
        itemsField = new ObservableCollection<object>();
    }

    [XmlElement("infNF", typeof(TCTeInfCteInfCTeNormInfDocInfNF))]
    [XmlElement("infNFe", typeof(TCTeInfCteInfCTeNormInfDocInfNFe))]
    [XmlElement("infOutros", typeof(TCTeInfCteInfCTeNormInfDocInfOutros))]
    public ObservableCollection<object> Items
    {
        get
        {
            return itemsField;
        }

        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Items");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfDoc));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfDocInfNF() : base()
    {
        itemsField = new ObservableCollection<object>();
    }

    public string nRoma
    {
        get
        {
            return nRomaField;
        }

        set
        {
            if (nRomaField is null || nRomaField.Equals(value) != true)
            {
                nRomaField = value;
                OnPropertyChanged("nRoma");
            }
        }
    }

    public string nPed
    {
        get
        {
            return nPedField;
        }

        set
        {
            if (nPedField is null || nPedField.Equals(value) != true)
            {
                nPedField = value;
                OnPropertyChanged("nPed");
            }
        }
    }

    public TModNF mod
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("mod");
            }
        }
    }

    public string serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("serie");
            }
        }
    }

    public string nDoc
    {
        get
        {
            return nDocField;
        }

        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged("nDoc");
            }
        }
    }

    public string dEmi
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("dEmi");
            }
        }
    }

    public string vBC
    {
        get
        {
            return vBCField;
        }

        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged("vBC");
            }
        }
    }

    public string vICMS
    {
        get
        {
            return vICMSField;
        }

        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged("vICMS");
            }
        }
    }

    public string vBCST
    {
        get
        {
            return vBCSTField;
        }

        set
        {
            if (vBCSTField is null || vBCSTField.Equals(value) != true)
            {
                vBCSTField = value;
                OnPropertyChanged("vBCST");
            }
        }
    }

    public string vST
    {
        get
        {
            return vSTField;
        }

        set
        {
            if (vSTField is null || vSTField.Equals(value) != true)
            {
                vSTField = value;
                OnPropertyChanged("vST");
            }
        }
    }

    public string vProd
    {
        get
        {
            return vProdField;
        }

        set
        {
            if (vProdField is null || vProdField.Equals(value) != true)
            {
                vProdField = value;
                OnPropertyChanged("vProd");
            }
        }
    }

    public string vNF
    {
        get
        {
            return vNFField;
        }

        set
        {
            if (vNFField is null || vNFField.Equals(value) != true)
            {
                vNFField = value;
                OnPropertyChanged("vNF");
            }
        }
    }

    public string nCFOP
    {
        get
        {
            return nCFOPField;
        }

        set
        {
            if (nCFOPField is null || nCFOPField.Equals(value) != true)
            {
                nCFOPField = value;
                OnPropertyChanged("nCFOP");
            }
        }
    }

    public string nPeso
    {
        get
        {
            return nPesoField;
        }

        set
        {
            if (nPesoField is null || nPesoField.Equals(value) != true)
            {
                nPesoField = value;
                OnPropertyChanged("nPeso");
            }
        }
    }

    public string PIN
    {
        get
        {
            return pINField;
        }

        set
        {
            if (pINField is null || pINField.Equals(value) != true)
            {
                pINField = value;
                OnPropertyChanged("PIN");
            }
        }
    }

    public string dPrev
    {
        get
        {
            return dPrevField;
        }

        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged("dPrev");
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get
        {
            return itemsField;
        }

        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Items");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfDocInfNF));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        return "NF"; // MyBase.ToString()
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
public enum TModNF
{

    /// <remarks/>
    [XmlEnum("01")]
    Item01,

    /// <remarks/>
    [XmlEnum("04")]
    Item04
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfDocInfNFe : INotifyPropertyChanged
{
    private string chaveField;
    private string pINField;
    private string dPrevField;
    private ObservableCollection<object> itemsField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfDocInfNFe() : base()
    {
        itemsField = new ObservableCollection<object>();
    }

    [XmlElement("chave")]
    public string Chave
    {
        get
        {
            return chaveField;
        }

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
        get
        {
            return pINField;
        }

        set
        {
            if (pINField is null || pINField.Equals(value) != true)
            {
                pINField = value;
                OnPropertyChanged("PIN");
            }
        }
    }

    public string dPrev
    {
        get
        {
            return dPrevField;
        }

        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged("dPrev");
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get
        {
            return itemsField;
        }

        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Items");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfDocInfNFe));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        return "NFe"; // MyBase.ToString()
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfDocInfOutros : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc tpDocField;
    private string descOutrosField;
    private string nDocField;
    private string dEmiField;
    private string vDocFiscField;
    private string dPrevField;
    private ObservableCollection<object> itemsField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormInfDocInfOutros() : base()
    {
        itemsField = new ObservableCollection<object>();
    }

    public TCTeInfCteInfCTeNormInfDocInfOutrosTpDoc tpDoc
    {
        get
        {
            return tpDocField;
        }

        set
        {
            if (tpDocField.Equals(value) != true)
            {
                tpDocField = value;
                OnPropertyChanged("tpDoc");
            }
        }
    }

    public string descOutros
    {
        get
        {
            return descOutrosField;
        }

        set
        {
            if (descOutrosField is null || descOutrosField.Equals(value) != true)
            {
                descOutrosField = value;
                OnPropertyChanged("descOutros");
            }
        }
    }

    public string nDoc
    {
        get
        {
            return nDocField;
        }

        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged("nDoc");
            }
        }
    }

    public string dEmi
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("dEmi");
            }
        }
    }

    public string vDocFisc
    {
        get
        {
            return vDocFiscField;
        }

        set
        {
            if (vDocFiscField is null || vDocFiscField.Equals(value) != true)
            {
                vDocFiscField = value;
                OnPropertyChanged("vDocFisc");
            }
        }
    }

    public string dPrev
    {
        get
        {
            return dPrevField;
        }

        set
        {
            if (dPrevField is null || dPrevField.Equals(value) != true)
            {
                dPrevField = value;
                OnPropertyChanged("dPrev");
            }
        }
    }

    [XmlElement("infUnidCarga", typeof(TUnidCarga))]
    [XmlElement("infUnidTransp", typeof(TUnidadeTransp))]
    public ObservableCollection<object> Items
    {
        get
        {
            return itemsField;
        }

        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Items");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfDocInfOutros));
            }

            return sSerializer;
        }
    }

    public override string ToString()
    {
        return "Outros"; // MyBase.ToString()
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class CTeNormalEmitenteDocumentonterior : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private NFe.Estado ufField;
    private string xNomeField;
    private ObservableCollection<TCTeInfCteInfCTeNormEmiDocAntIdDocAnt> idDocAntField;
    private static XmlSerializer sSerializer;

    public CTeNormalEmitenteDocumentonterior() : base()
    {
        idDocAntField = new ObservableCollection<TCTeInfCteInfCTeNormEmiDocAntIdDocAnt>();
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 PersonalidadeJuridica7
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
                OnPropertyChanged("PersonalidadeJuridica");
            }
        }
    }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica7")]
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

    public string IE
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
                OnPropertyChanged("IE");
            }
        }
    }

    public NFe.Estado UF
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

    public string xNome
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
                OnPropertyChanged("xNome");
            }
        }
    }

    [XmlElement("idDocAnt")]
    public ObservableCollection<TCTeInfCteInfCTeNormEmiDocAntIdDocAnt> idDocAnt
    {
        get
        {
            return idDocAntField;
        }

        set
        {
            if (idDocAntField is null || idDocAntField.Equals(value) != true)
            {
                idDocAntField = value;
                OnPropertyChanged("idDocAnt");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(CTeNormalEmitenteDocumentonterior));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAnt : INotifyPropertyChanged
{
    private ObservableCollection<object> itemsField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormEmiDocAntIdDocAnt() : base()
    {
        itemsField = new ObservableCollection<object>();
    }

    [XmlElement("idDocAntEle", typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle))]
    [XmlElement("idDocAntPap", typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap))]
    public ObservableCollection<object> Items
    {
        get
        {
            return itemsField;
        }

        set
        {
            if (itemsField is null || itemsField.Equals(value) != true)
            {
                itemsField = value;
                OnPropertyChanged("Items");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAnt));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle : INotifyPropertyChanged
{
    private string chaveField;
    private static XmlSerializer sSerializer;

    public string chave
    {
        get
        {
            return chaveField;
        }

        set
        {
            if (chaveField is null || chaveField.Equals(value) != true)
            {
                chaveField = value;
                OnPropertyChanged("chave");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntEle));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap : INotifyPropertyChanged
{
    private TDocAssoc tpDocField;
    private string serieField;
    private string subserField;
    private string nDocField;
    private string dEmiField;
    private static XmlSerializer sSerializer;

    public TDocAssoc tpDoc
    {
        get
        {
            return tpDocField;
        }

        set
        {
            if (tpDocField.Equals(value) != true)
            {
                tpDocField = value;
                OnPropertyChanged("tpDoc");
            }
        }
    }

    public string serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("serie");
            }
        }
    }

    public string subser
    {
        get
        {
            return subserField;
        }

        set
        {
            if (subserField is null || subserField.Equals(value) != true)
            {
                subserField = value;
                OnPropertyChanged("subser");
            }
        }
    }

    public string nDoc
    {
        get
        {
            return nDocField;
        }

        set
        {
            if (nDocField is null || nDocField.Equals(value) != true)
            {
                nDocField = value;
                OnPropertyChanged("nDoc");
            }
        }
    }

    public string dEmi
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("dEmi");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormEmiDocAntIdDocAntIdDocAntPap));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormSeg : INotifyPropertyChanged
{
    private ResponsavelSeguro respSegField;
    private string xSegField;
    private string nApolField;
    private string nAverField;
    private string vCargaField;
    private static XmlSerializer sSerializer;

    public ResponsavelSeguro respSeg
    {
        get
        {
            return respSegField;
        }

        set
        {
            if (respSegField.Equals(value) != true)
            {
                respSegField = value;
                OnPropertyChanged("respSeg");
            }
        }
    }

    public string xSeg
    {
        get
        {
            return xSegField;
        }

        set
        {
            if (xSegField is null || xSegField.Equals(value) != true)
            {
                xSegField = value;
                OnPropertyChanged("xSeg");
            }
        }
    }

    public string nApol
    {
        get
        {
            return nApolField;
        }

        set
        {
            if (nApolField is null || nApolField.Equals(value) != true)
            {
                nApolField = value;
                OnPropertyChanged("nApol");
            }
        }
    }

    public string nAver
    {
        get
        {
            return nAverField;
        }

        set
        {
            if (nAverField is null || nAverField.Equals(value) != true)
            {
                nAverField = value;
                OnPropertyChanged("nAver");
            }
        }
    }

    public string vCarga
    {
        get
        {
            return vCargaField;
        }

        set
        {
            if (vCargaField is null || vCargaField.Equals(value) != true)
            {
                vCargaField = value;
                OnPropertyChanged("vCarga");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormSeg));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfModal : INotifyPropertyChanged
{
    private XElement anyField; // System.Xml.XmlElement
    private string versaoModalField;
    private object itemField;
    private static XmlSerializer sSerializer;

    [XmlAnyElement()]
    public XElement Any // System.Xml.XmlElement
    {
        get
        {
            return anyField;
        }

        set // System.Xml.XmlElement)
        {
            if (anyField is null || anyField.Equals(value) != true)
            {
                anyField = value;
                OnPropertyChanged("Any");
            }
        }
    }

    [XmlAttribute()]
    public string versaoModal
    {
        get
        {
            return versaoModalField;
        }

        set
        {
            if (versaoModalField is null || versaoModalField.Equals(value) != true)
            {
                versaoModalField = value;
                OnPropertyChanged("versaoModal");
            }
        }
    }

    [XmlElement("rodo", typeof(CTeRodoviario))]
    public object ItemModal
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
                OnPropertyChanged("ItemModal");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfModal));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormPeri : INotifyPropertyChanged
{
    private string nONUField;
    private string xNomeAEField;
    private string xClaRiscoField;
    private string grEmbField;
    private string qTotProdField;
    private string qVolTipoField;
    private string pontoFulgorField;
    private static XmlSerializer sSerializer;

    public string nONU
    {
        get
        {
            return nONUField;
        }

        set
        {
            if (nONUField is null || nONUField.Equals(value) != true)
            {
                nONUField = value;
                OnPropertyChanged("nONU");
            }
        }
    }

    public string xNomeAE
    {
        get
        {
            return xNomeAEField;
        }

        set
        {
            if (xNomeAEField is null || xNomeAEField.Equals(value) != true)
            {
                xNomeAEField = value;
                OnPropertyChanged("xNomeAE");
            }
        }
    }

    public string xClaRisco
    {
        get
        {
            return xClaRiscoField;
        }

        set
        {
            if (xClaRiscoField is null || xClaRiscoField.Equals(value) != true)
            {
                xClaRiscoField = value;
                OnPropertyChanged("xClaRisco");
            }
        }
    }

    public string grEmb
    {
        get
        {
            return grEmbField;
        }

        set
        {
            if (grEmbField is null || grEmbField.Equals(value) != true)
            {
                grEmbField = value;
                OnPropertyChanged("grEmb");
            }
        }
    }

    public string qTotProd
    {
        get
        {
            return qTotProdField;
        }

        set
        {
            if (qTotProdField is null || qTotProdField.Equals(value) != true)
            {
                qTotProdField = value;
                OnPropertyChanged("qTotProd");
            }
        }
    }

    public string qVolTipo
    {
        get
        {
            return qVolTipoField;
        }

        set
        {
            if (qVolTipoField is null || qVolTipoField.Equals(value) != true)
            {
                qVolTipoField = value;
                OnPropertyChanged("qVolTipo");
            }
        }
    }

    public string pontoFulgor
    {
        get
        {
            return pontoFulgorField;
        }

        set
        {
            if (pontoFulgorField is null || pontoFulgorField.Equals(value) != true)
            {
                pontoFulgorField = value;
                OnPropertyChanged("pontoFulgor");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormPeri));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormVeicNovos : INotifyPropertyChanged
{
    private string chassiField;
    private string cCorField;
    private string xCorField;
    private string cModField;
    private string vUnitField;
    private string vFreteField;
    private static XmlSerializer sSerializer;

    public string chassi
    {
        get
        {
            return chassiField;
        }

        set
        {
            if (chassiField is null || chassiField.Equals(value) != true)
            {
                chassiField = value;
                OnPropertyChanged("chassi");
            }
        }
    }

    public string cCor
    {
        get
        {
            return cCorField;
        }

        set
        {
            if (cCorField is null || cCorField.Equals(value) != true)
            {
                cCorField = value;
                OnPropertyChanged("cCor");
            }
        }
    }

    public string xCor
    {
        get
        {
            return xCorField;
        }

        set
        {
            if (xCorField is null || xCorField.Equals(value) != true)
            {
                xCorField = value;
                OnPropertyChanged("xCor");
            }
        }
    }

    public string cMod
    {
        get
        {
            return cModField;
        }

        set
        {
            if (cModField is null || cModField.Equals(value) != true)
            {
                cModField = value;
                OnPropertyChanged("cMod");
            }
        }
    }

    public string vUnit
    {
        get
        {
            return vUnitField;
        }

        set
        {
            if (vUnitField is null || vUnitField.Equals(value) != true)
            {
                vUnitField = value;
                OnPropertyChanged("vUnit");
            }
        }
    }

    public string vFrete
    {
        get
        {
            return vFreteField;
        }

        set
        {
            if (vFreteField is null || vFreteField.Equals(value) != true)
            {
                vFreteField = value;
                OnPropertyChanged("vFrete");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormVeicNovos));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormCobr : INotifyPropertyChanged
{
    private TCTeInfCteInfCTeNormCobrFat fatField;
    private ObservableCollection<TCTeInfCteInfCTeNormCobrDup> dupField;
    private static XmlSerializer sSerializer;

    public TCTeInfCteInfCTeNormCobr() : base()
    {
        dupField = new ObservableCollection<TCTeInfCteInfCTeNormCobrDup>();
        fatField = new TCTeInfCteInfCTeNormCobrFat();
    }

    public TCTeInfCteInfCTeNormCobrFat fat
    {
        get
        {
            return fatField;
        }

        set
        {
            if (fatField is null || fatField.Equals(value) != true)
            {
                fatField = value;
                OnPropertyChanged("fat");
            }
        }
    }

    [XmlElement("dup")]
    public ObservableCollection<TCTeInfCteInfCTeNormCobrDup> dup
    {
        get
        {
            return dupField;
        }

        set
        {
            if (dupField is null || dupField.Equals(value) != true)
            {
                dupField = value;
                OnPropertyChanged("dup");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormCobr));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormCobrFat : INotifyPropertyChanged
{
    private string nFatField;
    private string vOrigField;
    private string vDescField;
    private string vLiqField;
    private static XmlSerializer sSerializer;

    public string nFat
    {
        get
        {
            return nFatField;
        }

        set
        {
            if (nFatField is null || nFatField.Equals(value) != true)
            {
                nFatField = value;
                OnPropertyChanged("nFat");
            }
        }
    }

    public string vOrig
    {
        get
        {
            return vOrigField;
        }

        set
        {
            if (vOrigField is null || vOrigField.Equals(value) != true)
            {
                vOrigField = value;
                OnPropertyChanged("vOrig");
            }
        }
    }

    public string vDesc
    {
        get
        {
            return vDescField;
        }

        set
        {
            if (vDescField is null || vDescField.Equals(value) != true)
            {
                vDescField = value;
                OnPropertyChanged("vDesc");
            }
        }
    }

    public string vLiq
    {
        get
        {
            return vLiqField;
        }

        set
        {
            if (vLiqField is null || vLiqField.Equals(value) != true)
            {
                vLiqField = value;
                OnPropertyChanged("vLiq");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormCobrFat));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormCobrDup : INotifyPropertyChanged
{
    private string nDupField;
    private string dVencField;
    private string vDupField;
    private static XmlSerializer sSerializer;

    public string nDup
    {
        get
        {
            return nDupField;
        }

        set
        {
            if (nDupField is null || nDupField.Equals(value) != true)
            {
                nDupField = value;
                OnPropertyChanged("nDup");
            }
        }
    }

    public string dVenc
    {
        get
        {
            return dVencField;
        }

        set
        {
            if (dVencField is null || dVencField.Equals(value) != true)
            {
                dVencField = value;
                OnPropertyChanged("dVenc");
            }
        }
    }

    public string vDup
    {
        get
        {
            return vDupField;
        }

        set
        {
            if (vDupField is null || vDupField.Equals(value) != true)
            {
                vDupField = value;
                OnPropertyChanged("vDup");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormCobrDup));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfCteSub : INotifyPropertyChanged
{
    private string chCteField;
    private object itemField;
    private static XmlSerializer sSerializer;

    public string chCte
    {
        get
        {
            return chCteField;
        }

        set
        {
            if (chCteField is null || chCteField.Equals(value) != true)
            {
                chCteField = value;
                OnPropertyChanged("chCte");
            }
        }
    }

    [XmlElement("tomaICMS", typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMS))]
    [XmlElement("tomaNaoICMS", typeof(TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS))]
    public object Item
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
                OnPropertyChanged("Item");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCteSub));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfCteSubTomaICMS : INotifyPropertyChanged
{
    private object itemField;
    private PersonalidadeJuridica78 itemElementNameField;
    private static XmlSerializer sSerializer;

    [XmlElement("refCte", typeof(string))]
    [XmlElement("refNF", typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF))]
    [XmlElement("refNFe", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public object Item
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
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica78 ItemElementName
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
                OnPropertyChanged("ItemElementName");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMS));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
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
    private static XmlSerializer sSerializer;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
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
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName
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
                OnPropertyChanged("ItemElementName");
            }
        }
    }

    public TModDoc mod
    {
        get
        {
            return modField;
        }

        set
        {
            if (modField.Equals(value) != true)
            {
                modField = value;
                OnPropertyChanged("mod");
            }
        }
    }

    public string serie
    {
        get
        {
            return serieField;
        }

        set
        {
            if (serieField is null || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged("serie");
            }
        }
    }

    public string subserie
    {
        get
        {
            return subserieField;
        }

        set
        {
            if (subserieField is null || subserieField.Equals(value) != true)
            {
                subserieField = value;
                OnPropertyChanged("subserie");
            }
        }
    }

    public string nro
    {
        get
        {
            return nroField;
        }

        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged("nro");
            }
        }
    }

    public string valor
    {
        get
        {
            return valorField;
        }

        set
        {
            if (valorField is null || valorField.Equals(value) != true)
            {
                valorField = value;
                OnPropertyChanged("valor");
            }
        }
    }

    public string dEmi
    {
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("dEmi");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCteSubTomaICMSRefNF));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte", IncludeInSchema = false)]
public enum PersonalidadeJuridica7
{

    /// <remarks/>
    CNPJ,

    /// <remarks/>
    CPF
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte", IncludeInSchema = false)]
public enum PersonalidadeJuridica78
{

    /// <remarks/>
    refCte,

    /// <remarks/>
    refNF,

    /// <remarks/>
    refNFe
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS : INotifyPropertyChanged
{
    private string refCteAnuField;
    private static XmlSerializer sSerializer;

    public string refCteAnu
    {
        get
        {
            return refCteAnuField;
        }

        set
        {
            if (refCteAnuField is null || refCteAnuField.Equals(value) != true)
            {
                refCteAnuField = value;
                OnPropertyChanged("refCteAnu");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(TCTeInfCteInfCTeNormInfCteSubTomaNaoICMS));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class InformacoesCteAnulacao : INotifyPropertyChanged
{
    private string chCteField;
    private string dEmiField;
    private static XmlSerializer sSerializer;

    [XmlElement("chCte")]
    public string Chave
    {
        get
        {
            return chCteField;
        }

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
        get
        {
            return dEmiField;
        }

        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged("dEmi");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(InformacoesCteAnulacao));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class InformacoesCteComplementado : INotifyPropertyChanged
{
    private string chaveField;
    private static XmlSerializer sSerializer;

    [XmlElement("chave")]
    public string Chave
    {
        get
        {
            return chaveField;
        }

        set
        {
            if (chaveField is null || chaveField.Equals(value) != true)
            {
                chaveField = value;
                OnPropertyChanged("chave");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(InformacoesCteComplementado));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
public partial class AutorizadoXML : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica79 itemElementNameField;
    private static XmlSerializer sSerializer;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("ItemElementName")]
    public string Item
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
                OnPropertyChanged("Item");
            }
        }
    }

    [XmlIgnore()]
    public PersonalidadeJuridica79 ItemElementName
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
                OnPropertyChanged("ItemElementName");
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(AutorizadoXML));
            }

            return sSerializer;
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

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte", IncludeInSchema = false)]
public enum PersonalidadeJuridica79
{

    /// <remarks/>
    CNPJ,

    /// <remarks/>
    CPF
}