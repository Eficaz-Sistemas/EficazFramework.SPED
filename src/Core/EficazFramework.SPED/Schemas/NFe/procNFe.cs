using EficazFramework.SPED.Extensions;
using Microsoft.VisualBasic.CompilerServices;

namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("procNFe", IsNullable = false)]
public partial class ProcessoNFeBase : INotifyPropertyChanged, IXmlSpedDocument
{
    public ProcessoNFeBase() : base()
    {
        nFeField = new ProcessoNFe();
    }

    private ProcessoNFe nFeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    [XmlElement("nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe")]
    public ProcessoNFe Processo
    {
        get => nFeField;        
        set
        {
            if (nFeField is null || nFeField.Equals(value) != true)
            {
                nFeField = value;
                OnPropertyChanged(nameof(Processo));
            }
        }
    }

    [XmlAttribute(AttributeName = "schema")]
    public string Schema
    {
        get => versaoField;
        set
        {
            if (versaoField is null || versaoField.Equals(value) != true)
            {
                versaoField = value;
                OnPropertyChanged(nameof(Schema));
            }
        }
    }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(ProcessoNFeBase));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.NFeWithProtocol_Base;

    public DateTime? DataEmissao => Processo.DataEmissao;

    public string Chave
    {
        get
        {
            // Return Me.Processo.Chave
            if (Processo.NFe.InformacoesNFe.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(Processo.NFe.InformacoesNFe.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public override string ToString() => base.ToString();// Return Me.NFe.InformacoesNFe.IdentificacaoOperacao.Chave

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
    public static bool CanDeserialize(string xml, ref ProcessoNFeBase obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ProcessoNFeBase obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoNFeBase Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ProcessoNFeBase)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoNFeBase Deserialize(System.IO.Stream s) => (ProcessoNFeBase)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFeBase obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFeBase obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoNFeBase LoadFrom(System.IO.Stream source, bool close_stream = true)
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
            if (source != null & close_stream == true)
            {
                source.Dispose();
            }

            sr?.Dispose();
        }
    }

    public static async Task<ProcessoNFeBase> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}

[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("nfeProc", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class ProcessoNFe : INotifyPropertyChanged, IXmlSpedDocument
{
    public ProcessoNFe() : base()
    {
        protNFeField = new ProtocoloRecebimento();
        nFeField = new NFe();
    }

    private NFe nFeField;
    private ProtocoloRecebimento protNFeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public NFe NFe
    {
        get => nFeField;
        set
        {
            if (nFeField is null || nFeField.Equals(value) != true)
            {
                nFeField = value;
                OnPropertyChanged(nameof(NFe));
            }
        }
    }

    [XmlElement("protNFe")]
    public ProtocoloRecebimento ProtocoloAutorizacao
    {
        get => protNFeField;
        set
        {
            if (protNFeField is null || protNFeField.Equals(value) != true)
            {
                protNFeField = value;
                OnPropertyChanged(nameof(ProtocoloAutorizacao));
            }
        }
    }

    [XmlAttribute(AttributeName = "versao")]
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
            sSerializer ??= new XmlSerializer(typeof(ProcessoNFe));
            return sSerializer;
        }
    }

    [XmlIgnore()]
    public XmlDocumentType DocumentType => XmlDocumentType.NFeWithProtocol;

    [XmlIgnore()]
    public DateTime? DataEmissao => NFe.InformacoesNFe.IdentificacaoOperacao.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.NFe.InformacoesNFe.Id
            if (NFe.InformacoesNFe.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(NFe.InformacoesNFe.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }


    public event PropertyChangedEventHandler PropertyChanged;

    public static void RefreshSerializer() => sSerializer = null;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public override string ToString() => base.ToString();// Return Me.NFe.InformacoesNFe.IdentificacaoOperacao.Chave

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
    public static bool CanDeserialize(string xml, ref ProcessoNFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ProcessoNFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoNFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (ProcessoNFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoNFe Deserialize(System.IO.Stream s) => (ProcessoNFe)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoNFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoNFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<ProcessoNFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}

[Serializable()]
[XmlType(TypeName = "NFe", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot("NFe", Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = false)]
public partial class NFe : INotifyPropertyChanged, IXmlSpedDocument
{
    public NFe() : base()
    {
        signatureField = new SignatureType();
        infNFeField = new InformacoesNFe();
    }

    private InformacoesNFe infNFeField;
    private SignatureType signatureField;
    private static XmlSerializer sSerializer;

    [XmlElement("infNFe")]
    public InformacoesNFe InformacoesNFe
    {
        get => infNFeField;
        set
        {
            if (infNFeField is null || infNFeField.Equals(value) != true)
            {
                infNFeField = value;
                OnPropertyChanged(nameof(InformacoesNFe));
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
            sSerializer ??= new XmlSerializer(typeof(NFe));
            return sSerializer;
        }
    }

    [XmlIgnore()]
    public XmlDocumentType DocumentType => XmlDocumentType.NFeWithoutProtocol;

    [XmlIgnore()]
    public DateTime? DataEmissao => InformacoesNFe.IdentificacaoOperacao.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.InformacoesNFe.Id
            if (InformacoesNFe.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(InformacoesNFe.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
    public static bool CanDeserialize(string xml, ref NFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref NFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static NFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            // stringReader.ReadToEnd() 'TESTING...
            return (NFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProcessoNFeBase)
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static NFe Deserialize(System.IO.Stream s) => (NFe)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref NFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref NFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static NFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<NFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
            if (sr != null & close_stream == true)
            {
                sr.Dispose();
            }
        }
    }
}

public partial class InformacoesNFe : INotifyPropertyChanged
{
    public InformacoesNFe() : base()
    {
        // Me.canaField = New TNFeInfNFeCana()
        // Me.compraField = New TNFeInfNFeCompra()
        // Me.exportaField = New TNFeInfNFeExporta()
        // Me.infAdicField = New TNFeInfNFeInfAdic()
        // Me.cobrField = New TNFeInfNFeCobr()
        // Me.transpField = New InformacoesTransporte()
        // Me.totalField = New Totais()
        detField = [];
        // Me.entregaField = New Local()
        // Me.retiradaField = New Local()
        // Me.destField = New Destinatario()
        // Me.avulsaField = New Fisco()
        // Me.emitField = New Emitente()
        // Me.ideField = New IdentificacaoNFe()
    }

    private IdentificacaoNFe ideField;
    private Emitente emitField;
    private Fisco avulsaField;
    private Destinatario destField;
    private Local retiradaField;
    private Local entregaField;
    private List<Item> detField;
    private Totais totalField;
    private InformacoesTransporte transpField;
    private Cobranca cobrField;
    private Pagamento pagField;
    private InformacoesAdicionais infAdicField;
    private Exportacao exportaField;
    private Compra compraField;
    private Cana canaField;
    private string versaoField;
    private string idField;
    private static XmlSerializer sSerializer;

    [XmlElement("ide")]
    public IdentificacaoNFe IdentificacaoOperacao
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

    [XmlElement("avulsa")]
    public Fisco Avulsa
    {
        get => avulsaField;
        set
        {
            if (avulsaField is null || avulsaField.Equals(value) != true)
            {
                avulsaField = value;
                OnPropertyChanged(nameof(Avulsa));
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

    [XmlElement("retirada")]
    public Local LocalRetirada
    {
        get => retiradaField;
        set
        {
            if (retiradaField is null || retiradaField.Equals(value) != true)
            {
                retiradaField = value;
                OnPropertyChanged(nameof(LocalRetirada));
            }
        }
    }

    [XmlElement("entrega")]
    public Local LocalEntrega
    {
        get => entregaField;
        set
        {
            if (entregaField is null || entregaField.Equals(value) != true)
            {
                entregaField = value;
                OnPropertyChanged(nameof(LocalEntrega));
            }
        }
    }

    [XmlElement("det")]
    public List<Item> Items
    {
        get => detField;
        set
        {
            if (detField is null || detField.Equals(value) != true)
            {
                detField = value;
                OnPropertyChanged(nameof(Items));
            }
        }
    }

    [XmlElement("total")]
    public Totais Totais
    {
        get => totalField;
        set
        {
            if (totalField is null || totalField.Equals(value) != true)
            {
                totalField = value;
                OnPropertyChanged(nameof(Totais));
            }
        }
    }

    [XmlElement("transp")]
    public InformacoesTransporte Transporte
    {
        get => transpField;
        set
        {
            if (transpField is null || transpField.Equals(value) != true)
            {
                transpField = value;
                OnPropertyChanged(nameof(Transporte));
            }
        }
    }

    [XmlElement("cobr")]
    public Cobranca Cobranca
    {
        get => cobrField;
        set
        {
            if (cobrField is null || cobrField.Equals(value) != true)
            {
                cobrField = value;
                OnPropertyChanged(nameof(Cobranca));
            }
        }
    }

    [XmlElement("pag")]
    public Pagamento Pagamento
    {
        get => pagField;
        set
        {
            if (pagField is null || pagField.Equals(value) != true)
            {
                pagField = value;
                OnPropertyChanged(nameof(Pagamento));
            }
        }
    }

    [XmlElement("infAdic")]
    public InformacoesAdicionais InformacoesAdicionais
    {
        get => infAdicField;
        set
        {
            if (infAdicField is null || infAdicField.Equals(value) != true)
            {
                infAdicField = value;
                OnPropertyChanged(nameof(InformacoesAdicionais));
            }
        }
    }

    [XmlElement("exporta")]
    public Exportacao Exportacao
    {
        get => exportaField;
        set
        {
            if (exportaField is null || exportaField.Equals(value) != true)
            {
                exportaField = value;
                OnPropertyChanged(nameof(Exportacao));
            }
        }
    }

    [XmlElement("compra")]
    public Compra InformacaoAdicionalCompra
    {
        get => compraField;
        set
        {
            if (compraField is null || compraField.Equals(value) != true)
            {
                compraField = value;
                OnPropertyChanged(nameof(InformacaoAdicionalCompra));
            }
        }
    }

    [XmlElement("cana")]
    public Cana Cana
    {
        get => canaField;
        set
        {
            if (canaField is null || canaField.Equals(value) != true)
            {
                canaField = value;
                OnPropertyChanged(nameof(Cana));
            }
        }
    }

    [XmlAttribute(AttributeName = "versao")]
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

    [XmlAttribute("Id")]
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class IdentificacaoNFe : INotifyPropertyChanged
{
    public IdentificacaoNFe() : base()
    {
        nFrefField = [];
    }

    private OrgaoIBGE cUFField;
    private string cNFField;
    private string natOpField;
    private FormaDePagamento indPagField;
    private ModeloDocumento modField;
    private int serieField;
    private long nNFField;
    private DateTime? dEmiField;
    private DateTime? dhEmiField;
    private DateTime? dSaiEntField;
    private DateTime? dhSaiEntField;
    private TimeSpan? hSaiEntField;
    private OperacaoNFe tpNFField;
    private string cMunFGField;
    private List<ReferenciaDocFiscal> nFrefField;
    private TipoImpressao tpImpField;
    private FormaEmissao tpEmisField;
    private string cDVField;
    private Ambiente tpAmbField;
    private FinalidadeEmissao finNFeField;
    private ProcessoEmissao procEmiField;
    private string verProcField;
    private DateTime? dhContField;
    private string xJustField;
    private bool _conumidorFinalField = false; // NEW 15/12/2016
    private TipoAtendimento _tpAtendimentoField; // NEW 15/12/2016
    private DestinoOperacao _destOperacao; // NEW 15/12/2016

    [XmlElement("cUF")]
    public OrgaoIBGE UF
    {
        get => cUFField;
        set
        {
            if (cUFField.Equals(value) != true)
            {
                cUFField = value;
                OnPropertyChanged(nameof(UF));
            }
        }
    }

    [XmlElement("cNF")]
    public string Chave
    {
        get => cNFField;
        set
        {
            if (cNFField is null || cNFField.Equals(value) != true)
            {
                cNFField = value;
                OnPropertyChanged(nameof(Chave));
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

    [XmlElement("indPag")]
    public FormaDePagamento FormaDePagamento
    {
        get => indPagField;
        set
        {
            if (indPagField.Equals(value) != true)
            {
                indPagField = value;
                OnPropertyChanged(nameof(FormaDePagamento));
            }
        }
    }

    [XmlElement("mod")]
    public ModeloDocumento Modelo
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
    public int Serie
    {
        get => serieField;
        set
        {
            if (serieField == default || serieField.Equals(value) != true)
            {
                serieField = value;
                OnPropertyChanged(nameof(Serie));
            }
        }
    }

    [XmlElement("nNF")]
    public long Numero
    {
        get => nNFField;
        set
        {
            if (nNFField == default || nNFField.Equals(value) != true)
            {
                nNFField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    /// <summary>
    /// Fornece valores válidos para NFe 2.00 e 3.10
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    public DateTime? DataEmissao
    {
        get
        {
            if (DataHoraEmissao.HasValue == true)
            {
                return dhEmiField.Value.Date;
            }
            else
            {
                return dEmiField;
            }
        }
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(DataEmissao));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00
    /// Utilize o campo 'DataEmissao' (Date?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dEmi")]
    public string DataEmissaoXML
    {
        get
        {
            if (DataEmissao.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataEmissao);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dEmiField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                }
                else
                {
                    dEmiField = default;
                }

                OnPropertyChanged(nameof(DataEmissao));
            }
        }
    }

    public bool ShouldSerializeDataEmissaoXML() => dEmiField.HasValue;

    /// <summary>
    /// v3.10
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dhEmi")]
    public DateTime? DataHoraEmissao
    {
        get => dhEmiField;
        set
        {
            if (dhEmiField is null || dhEmiField.Equals(value) != true)
            {
                dhEmiField = value;
                OnPropertyChanged(nameof(DataHoraEmissao));
            }
        }
    }

    public bool ShouldSerializeDataHoraEmissao() => dhEmiField.HasValue;

    /// <summary>
    /// Fornece valores válidos para NFe 2.00 e 3.10
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    public DateTime? DataSaidaEntrada
    {
        get
        {
            if (DataHoraSaidaEntrada.HasValue == true)
            {
                return dhSaiEntField.Value.Date;
            }
            else
            {
                return dSaiEntField;
            }
        }
        set
        {
            if (dSaiEntField is null || dSaiEntField.Equals(value) != true)
            {
                dSaiEntField = value;
                OnPropertyChanged(nameof(DataSaidaEntrada));
            }
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e 2.00
    /// Utilize o campo 'DataSaidaEntrada' (Date?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dSaiEnt")]
    public string DataSaidaEntradaXML
    {
        get
        {
            if (DataSaidaEntrada.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataSaidaEntrada);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dSaiEntField is null || dSaiEntField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    if (dt.Length >= 3)
                    {
                        dSaiEntField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                    }
                    else
                    {
                        dSaiEntField = default;
                    }
                }
                else
                {
                    dSaiEntField = default;
                }

                OnPropertyChanged(nameof(DataSaidaEntrada));
            }
        }
    }

    public bool ShouldSerializeDataSaidaEntradaXML() => dSaiEntField.HasValue;

    /// <summary>
    /// Fornece valores válidos para NFe 2.00 e 3.10
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlIgnore()]
    public TimeSpan? HoraSaidaEntrada
    {
        get
        {
            if (DataHoraSaidaEntrada.HasValue == true)
            {
                if (dhSaiEntField.Value.Hour != 0 & dhSaiEntField.Value.Minute != 0 & dhSaiEntField.Value.Second != 0)
                {
                    return dhSaiEntField.Value.TimeOfDay;
                }
                else
                {
                    return default;
                }
            }
            else
            {
                return hSaiEntField;
            }
        }
        set
        {
            if (hSaiEntField is null || hSaiEntField.Equals(value) != true)
            {
                hSaiEntField = value;
                OnPropertyChanged(nameof(HoraSaidaEntrada));
            }
        }
    }

    public bool ShouldSerializeHoraSaidaEntrada() => hSaiEntField.HasValue;

    /// <summary>
    /// v3.10
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dhSaiEnt")]
    public DateTime? DataHoraSaidaEntrada
    {
        get => dhSaiEntField;
        set
        {
            if (dhSaiEntField is null || dhSaiEntField.Equals(value) != true)
            {
                dhSaiEntField = value;
                OnPropertyChanged(nameof(DataHoraSaidaEntrada));
            }
        }
    }

    public bool ShouldSerializeDataHoraSaidaEntrada() => dhSaiEntField.HasValue;

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'HoraSaidaEntrada' (TimeSpan?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("hSaiEnt")]
    public string HoraSaidaEntradaXML
    {
        get
        {
            if (HoraSaidaEntrada.HasValue == true)
            {
                string str = string.Format("{0:00}", HoraSaidaEntrada.Value.Hours) + ":" + string.Format("{0:00}", HoraSaidaEntrada.Value.Minutes) + ":" + string.Format("{0:00}", HoraSaidaEntrada.Value.Seconds);
                return str;
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (hSaiEntField is null || hSaiEntField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split(":");
                    if (dt.Length >= 3)
                    {
                        hSaiEntField = new TimeSpan(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2]));
                    }
                    else
                    {
                        hSaiEntField = default;
                    }
                }
                else
                {
                    hSaiEntField = default;
                }

                OnPropertyChanged(nameof(HoraSaidaEntrada));
            }
        }
    }

    public bool ShouldSerializeHoraSaidaEntradaXML() => hSaiEntField.HasValue;

    [XmlElement("tpNF")]
    public OperacaoNFe TipoOperacao
    {
        get => tpNFField;
        set
        {
            if (tpNFField.Equals(value) != true)
            {
                tpNFField = value;
                OnPropertyChanged(nameof(TipoOperacao));
            }
        }
    }

    [XmlElement("cMunFG")]
    public string CodigoMunicipio
    {
        get => cMunFGField;
        set
        {
            if (cMunFGField is null || cMunFGField.Equals(value) != true)
            {
                cMunFGField = value;
                OnPropertyChanged(nameof(CodigoMunicipio));
            }
        }
    }

    [XmlElement("NFref")]
    public List<ReferenciaDocFiscal> NotasFiscaisReferenciadas
    {
        get => nFrefField;
        set
        {
            if (nFrefField is null || nFrefField.Equals(value) != true)
            {
                nFrefField = value;
                OnPropertyChanged(nameof(NotasFiscaisReferenciadas));
            }
        }
    }

    [XmlElement("tpImp")]
    public TipoImpressao TipoImpressao
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
    public string ChaveDigitoVerificador
    {
        get => cDVField;
        set
        {
            if (cDVField is null || cDVField.Equals(value) != true)
            {
                cDVField = value;
                OnPropertyChanged(nameof(ChaveDigitoVerificador));
            }
        }
    }

    [XmlElement("tpAmb")]
    public Ambiente Ambiente
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

    [XmlElement("finNFe")]
    public FinalidadeEmissao Finalidade
    {
        get => finNFeField;
        set
        {
            if (finNFeField.Equals(value) != true)
            {
                finNFeField = value;
                OnPropertyChanged(nameof(Finalidade));
            }
        }
    }

    [XmlElement("procEmi")]
    public ProcessoEmissao ProcessoDeEmissao
    {
        get => procEmiField;
        set
        {
            if (procEmiField.Equals(value) != true)
            {
                procEmiField = value;
                OnPropertyChanged(nameof(ProcessoDeEmissao));
            }
        }
    }

    [XmlElement("verProc")]
    public string VersaoProcessoEmissao
    {
        get => verProcField;
        set
        {
            if (verProcField is null || verProcField.Equals(value) != true)
            {
                verProcField = value;
                OnPropertyChanged(nameof(VersaoProcessoEmissao));
            }
        }
    }

    [XmlIgnore()]
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

    [XmlElement("indFinal")]
    public bool ConsumidorFinal // NEW!!! 15/12/2016
    {
        get => _conumidorFinalField;
        set
        {
            if (value != _conumidorFinalField)
            {
                _conumidorFinalField = value;
                OnPropertyChanged(nameof(ConsumidorFinal));
            }
        }
    }

    [XmlElement("indPres")]
    public TipoAtendimento TipoAtendimento // NEW!!! 15/12/2016
    {
        get => _tpAtendimentoField;
        set
        {
            _tpAtendimentoField = value;
            OnPropertyChanged(nameof(TipoAtendimento));
        }
    }

    [XmlElement("idDest")]
    public DestinoOperacao DestinoOperacao // NEW!!! 15/12/2016
    {
        get => _destOperacao;
        set
        {
            _destOperacao = value;
            OnPropertyChanged(nameof(DestinoOperacao));
        }
    }

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'DataHoraContingencia' (Date?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dhCont")]
    public string DataHoraContingenciaXML
    {
        get
        {
            if (DataHoraContingencia.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", DataHoraContingencia);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dhContField is null || dhContField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    if (dt.Length >= 3)
                    {
                        dhContField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2].Substring(0, 2)));
                    }
                    else
                    {
                        dhContField = default;
                    }
                }
                else
                {
                    dhContField = default;
                }

                OnPropertyChanged(nameof(DataHoraContingencia));
            }
        }
    }

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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ProtocoloRecebimento : INotifyPropertyChanged
{
    public ProtocoloRecebimento() : base()
    {
        // Me.signatureField = New SignatureType()
        // Me.infProtField = New InformacoesProtocolo()
    }

    private InformacoesProtocolo infProtField;
    private SignatureType signatureField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    [XmlElement("infProt")]
    public InformacoesProtocolo InformacoesProtocolo
    {
        get => infProtField;
        set
        {
            if (infProtField is null || infProtField.Equals(value) != true)
            {
                infProtField = value;
                OnPropertyChanged(nameof(InformacoesProtocolo));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesProtocolo : INotifyPropertyChanged
{
    private Ambiente tpAmbField;
    private string verAplicField;
    private string chNFeField;
    private DateTime dhRecbtoField;
    private string nProtField;
    private byte[] digValField;
    private string cStatField;
    private string xMotivoField;
    private string idField;
    private static XmlSerializer sSerializer;

    [XmlElement("tpAmb")]
    public Ambiente Ambiente
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

    [XmlElement("verAplic")]
    public string VersaoAplicativo
    {
        get => verAplicField;
        set
        {
            if (verAplicField is null || verAplicField.Equals(value) != true)
            {
                verAplicField = value;
                OnPropertyChanged(nameof(VersaoAplicativo));
            }
        }
    }

    [XmlElement("chNFe")]
    public string ChaveNFe
    {
        get => chNFeField;
        set
        {
            if (chNFeField is null || chNFeField.Equals(value) != true)
            {
                chNFeField = value;
                OnPropertyChanged(nameof(ChaveNFe));
            }
        }
    }

    private string chave_codificada = null;

    [XmlIgnore]
    public string ChaveNFeCodificada => chave_codificada;

    private byte[] chaveArray;

    [XmlIgnore]
    public byte[] ChaveNFeCodificadaByte => chaveArray;

    public string ChaveNFeFormatada
    {
        get
        {
            var builder = new System.Text.StringBuilder();
            for (int i = 0; i <= 10; i++)
            {
                builder.Append(ChaveNFe.AsSpan(i * 4, 4));
                if (i < 10)
                {
                    builder.Append(' ');
                }
            }

            return builder.ToString();
        }
    }

    [XmlElement("dhRecbto")]
    public DateTime DataHoraRecebimento
    {
        get => dhRecbtoField;
        set
        {
            if (dhRecbtoField.Equals(value) != true)
            {
                dhRecbtoField = value;
                OnPropertyChanged(nameof(DataHoraRecebimento));
            }
        }
    }

    [XmlElement("nProt")]
    public string Protocolo
    {
        get => nProtField;
        set
        {
            if (nProtField is null || nProtField.Equals(value) != true)
            {
                nProtField = value;
                OnPropertyChanged(nameof(Protocolo));
            }
        }
    }

    [XmlElement("digVal", DataType = "base64Binary")]
    public byte[] DigestValue
    {
        get => digValField;
        set
        {
            if (digValField is null || digValField.Equals(value) != true)
            {
                digValField = value;
                OnPropertyChanged(nameof(DigestValue));
            }
        }
    }

    [XmlElement("cStat")]
    public string StatusNFeCodigo
    {
        get => cStatField;
        set
        {
            if (cStatField is null || cStatField.Equals(value) != true)
            {
                cStatField = value;
                OnPropertyChanged(nameof(StatusNFeCodigo));
            }
        }
    }

    [XmlElement("xMotivo")]
    public string StatusNfeMotivo
    {
        get => xMotivoField;
        set
        {
            if (xMotivoField is null || xMotivoField.Equals(value) != true)
            {
                xMotivoField = value;
                OnPropertyChanged(nameof(StatusNfeMotivo));
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

    public void SetCodeBarRaw(string encodedString, byte[] encodedArray)
    {
        chave_codificada = encodedString;
        chaveArray = encodedArray;
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Local : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string xLgrField;
    private string nroField;
    private string xCplField;
    private string xBairroField;
    private string cMunField;
    private string xMunField;
    private Estado ufField;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica")]
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
    public PersonalidadeJuridica PersonalidadeJuridica
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(PersonalidadeJuridica));
            }
        }
    }

    [XmlElement("xLgr")]
    public string Logradouro
    {
        get => xLgrField;
        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged(nameof(Logradouro));
            }
        }
    }

    [XmlElement("nro")]
    public string Numero
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    [XmlElement("xCpl")]
    public string Complemento
    {
        get => xCplField;
        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged(nameof(Complemento));
            }
        }
    }

    [XmlElement("xBairro")]
    public string Bairro
    {
        get => xBairroField;
        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged(nameof(Bairro));
            }
        }
    }

    [XmlElement("cMun")]
    public string MunicipioCodigo
    {
        get => cMunField;
        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged(nameof(MunicipioCodigo));
            }
        }
    }

    [XmlElement("xMun")]
    public string MunicipioNome
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(MunicipioNome));
            }
        }
    }

    [XmlElement("UF")]
    public Estado UF
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Endereco : INotifyPropertyChanged
{
    private string xLgrField;
    private string nroField;
    private string xCplField;
    private string xBairroField;
    private string cMunField;
    private string xMunField;
    private Estado ufField;
    private string cEPField;
    private string cPaisField;
    private string xPaisField;
    private string foneField;

    [XmlElement("xLgr")]
    public string Logradouro
    {
        get => xLgrField;
        set
        {
            if (xLgrField is null || xLgrField.Equals(value) != true)
            {
                xLgrField = value;
                OnPropertyChanged(nameof(Logradouro));
            }
        }
    }

    [XmlElement("nro")]
    public string Numero
    {
        get => nroField;
        set
        {
            if (nroField is null || nroField.Equals(value) != true)
            {
                nroField = value;
                OnPropertyChanged(nameof(Numero));
            }
        }
    }

    [XmlElement("xCpl")]
    public string Complemento
    {
        get => xCplField;
        set
        {
            if (xCplField is null || xCplField.Equals(value) != true)
            {
                xCplField = value;
                OnPropertyChanged(nameof(Complemento));
            }
        }
    }

    [XmlElement("xBairro")]
    public string Bairro
    {
        get => xBairroField;
        set
        {
            if (xBairroField is null || xBairroField.Equals(value) != true)
            {
                xBairroField = value;
                OnPropertyChanged(nameof(Bairro));
            }
        }
    }

    [XmlElement("cMun")]
    public string MunicipioCodigo
    {
        get => cMunField;
        set
        {
            if (cMunField is null || cMunField.Equals(value) != true)
            {
                cMunField = value;
                OnPropertyChanged(nameof(MunicipioCodigo));
            }
        }
    }

    [XmlElement("xMun")]
    public string MunicipioNome
    {
        get => xMunField;
        set
        {
            if (xMunField is null || xMunField.Equals(value) != true)
            {
                xMunField = value;
                OnPropertyChanged(nameof(MunicipioNome));
            }
        }
    }

    public Estado UF
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

    [XmlIgnore()]
    public string CEPFormatado
    => CEP?.FormatCEP() ?? null;

    [XmlElement("cPais")]
    public string PaisCodigo
    {
        get => cPaisField;
        set
        {
            if (cPaisField is null || cPaisField.Equals(value) != true)
            {
                cPaisField = value;
                OnPropertyChanged(nameof(PaisCodigo));
            }
        }
    }

    [XmlElement("xPais")]
    public string PaisNome
    {
        get => xPaisField;
        set
        {
            if (xPaisField is null || xPaisField.Equals(value) != true)
            {
                xPaisField = value;
                OnPropertyChanged(nameof(PaisNome));
            }
        }
    }

    [XmlElement("fone")]
    public string Fone
    {
        get => foneField;
        set
        {
            if (foneField is null || foneField.Equals(value) != true)
            {
                foneField = value;
                OnPropertyChanged(nameof(Fone));
            }
        }
    }

    public string FoneFormatado
    {
        get
        {
            try
            {
                long @int = Conversions.ToLong(Fone);
                return string.Format("{0:(00)0000-0000}", @int);
            }
            catch (Exception)
            {
                return Fone;
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Emitente : INotifyPropertyChanged
{
    public Emitente() : base()
    {
        enderEmitField = new Endereco();
    }

    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string xNomeField;
    private string xFantField;
    private Endereco enderEmitField;
    private string ieField;
    private string iESTField;
    private string imField;
    private string cNAEField;
    private RegimeTributario cRTField;

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

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("EmitentePersonalidadeJuridica")]
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
    public PersonalidadeJuridica EmitentePersonalidadeJuridica
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged("ItemElementName");
            }
        }
    }

    [XmlElement("xNome")]
    public string RazaoSocial
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(RazaoSocial));
            }
        }
    }

    [XmlIgnore()]
    public string CNPJ_CPFFormatado => CNPJ_CPF?.FormatRFBDocument() ?? null;

    [XmlElement("xFant")]
    public string NomeFantasia
    {
        get => xFantField;
        set
        {
            if (xFantField is null || xFantField.Equals(value) != true)
            {
                xFantField = value;
                OnPropertyChanged(nameof(NomeFantasia));
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

    [XmlElement("IE")]
    public string InscricaoEstadual
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(InscricaoEstadual));
            }
        }
    }

    [XmlIgnore()]
    public string IEFormatado => InscricaoEstadual?.FormatIE(Endereco.UF.ToString()) ?? null;

    [XmlElement("IEST")]
    public string InscricaoEstadualST
    {
        get => iESTField;
        set
        {
            if (iESTField is null || iESTField.Equals(value) != true)
            {
                iESTField = value;
                OnPropertyChanged(nameof(InscricaoEstadualST));
            }
        }
    }

    [XmlElement("IM")]
    public string InscricaoMunicipal
    {
        get => imField;
        set
        {
            if (imField is null || imField.Equals(value) != true)
            {
                imField = value;
                OnPropertyChanged(nameof(InscricaoMunicipal));
            }
        }
    }

    public string CNAE
    {
        get => cNAEField;
        set
        {
            if (cNAEField is null || cNAEField.Equals(value) != true)
            {
                cNAEField = value;
                OnPropertyChanged(nameof(CNAE));
            }
        }
    }

    [XmlElement("CRT")]
    public RegimeTributario RegimeTributario
    {
        get => cRTField;
        set
        {
            if (cRTField.Equals(value) != true)
            {
                cRTField = value;
                OnPropertyChanged(nameof(RegimeTributario));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

/// <summary>
/// Informações do fisco emitente, grupo de uso exclusivo do fisco.
/// </summary>
public partial class Fisco : INotifyPropertyChanged
{
    private string cNPJField;
    private string xOrgaoField;
    private string matrField;
    private string xAgenteField;
    private string foneField;
    private Estado ufField;
    private string nDARField;
    private string dEmiField;
    private string vDARField;
    private string repEmiField;
    private DateTime? dPagField;

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

    [XmlElement("xOrgao")]
    public string Orgao
    {
        get => xOrgaoField;
        set
        {
            if (xOrgaoField is null || xOrgaoField.Equals(value) != true)
            {
                xOrgaoField = value;
                OnPropertyChanged(nameof(Orgao));
            }
        }
    }

    [XmlElement("matr")]
    public string AgenteMatricula
    {
        get => matrField;
        set
        {
            if (matrField is null || matrField.Equals(value) != true)
            {
                matrField = value;
                OnPropertyChanged(nameof(AgenteMatricula));
            }
        }
    }

    [XmlElement("xAgente")]
    public string AgenteNome
    {
        get => xAgenteField;
        set
        {
            if (xAgenteField is null || xAgenteField.Equals(value) != true)
            {
                xAgenteField = value;
                OnPropertyChanged(nameof(AgenteNome));
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

    public Estado UF
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

    /// <summary>
    /// Número do Documento de Arrecadação Estadual
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("nDAR")]
    public string NumeroDAR
    {
        get => nDARField;
        set
        {
            if (nDARField is null || nDARField.Equals(value) != true)
            {
                nDARField = value;
                OnPropertyChanged(nameof(NumeroDAR));
            }
        }
    }

    /// <summary>
    /// Data de emissão do Documento de Arrecadação Estadual
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dEmi")]
    public string DataEmissaoDAR
    {
        get => dEmiField;
        set
        {
            if (dEmiField is null || dEmiField.Equals(value) != true)
            {
                dEmiField = value;
                OnPropertyChanged(nameof(DataEmissaoDAR));
            }
        }
    }

    /// <summary>
    /// Valor Total do Documento de Arrecadação Estadual
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vDAR")]
    public string ValorDAR
    {
        get => vDARField;
        set
        {
            if (vDARField is null || vDARField.Equals(value) != true)
            {
                vDARField = value;
                OnPropertyChanged(nameof(ValorDAR));
            }
        }
    }

    [XmlElement("repEmi")]
    public string ReparticaoFiscal
    {
        get => repEmiField;
        set
        {
            if (repEmiField is null || repEmiField.Equals(value) != true)
            {
                repEmiField = value;
                OnPropertyChanged(nameof(ReparticaoFiscal));
            }
        }
    }

    [XmlElement("dPag")]
    public DateTime? DataPagamentoDAR
    {
        get => dPagField;
        set
        {
            if (dPagField is null || dPagField.Equals(value) != true)
            {
                dPagField = value;
                OnPropertyChanged(nameof(DataPagamentoDAR));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Destinatario : INotifyPropertyChanged
{
    public Destinatario() : base()
    {
        enderDestField = new Endereco();
    }

    private string itemField;
    private PersonalidadeJuridica itemElementNameField;
    private string _idEstrangeiroField;
    private string xNomeField;
    private Endereco enderDestField;
    private string ieField;
    private string iSUFField;
    private string emailField;

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("DestinatarioPersonalidadeJuridica")]
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
    public string CNPJ_CPFFormatado => CNPJ_CPF?.FormatRFBDocument() ?? null;

    [XmlIgnore()]
    public PersonalidadeJuridica DestinatarioPersonalidadeJuridica
    {
        get => itemElementNameField;
        set
        {
            if (itemElementNameField.Equals(value) != true)
            {
                itemElementNameField = value;
                OnPropertyChanged(nameof(DestinatarioPersonalidadeJuridica));
            }
        }
    }

    [XmlElement("idEstrangeiro")]
    public string idEstrangeiro
    {
        get => _idEstrangeiroField;
        set
        {
            if (_idEstrangeiroField is null || _idEstrangeiroField.Equals(value) != true)
            {
                _idEstrangeiroField = value;
                OnPropertyChanged(nameof(idEstrangeiro));
            }
        }
    }

    [XmlElement("xNome")]
    public string RazaoSocial
    {
        get => xNomeField;
        set
        {
            if (xNomeField is null || xNomeField.Equals(value) != true)
            {
                xNomeField = value;
                OnPropertyChanged(nameof(RazaoSocial));
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

    [XmlElement("IE")]
    public string InscricaoEstadual
    {
        get => ieField;
        set
        {
            if (ieField is null || ieField.Equals(value) != true)
            {
                ieField = value;
                OnPropertyChanged(nameof(InscricaoEstadual));
            }
        }
    }

    [XmlIgnore()]
    public string IEFormatado => InscricaoEstadual?.FormatIE(Endereco.UF.ToString()) ?? null;

    [XmlElement("ISUF")]
    public string InscricaoSuframa
    {
        get => iSUFField;
        set
        {
            if (iSUFField is null || iSUFField.Equals(value) != true)
            {
                iSUFField = value;
                OnPropertyChanged(nameof(InscricaoSuframa));
            }
        }
    }

    [XmlElement("email")]
    public string eMail
    {
        get => emailField;
        set
        {
            if (emailField is null || emailField.Equals(value) != true)
            {
                emailField = value;
                OnPropertyChanged(nameof(eMail));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DeclaracaoImportacao : INotifyPropertyChanged
{
    private string nDIField;
    private DateTime? dDIField;
    private string xLocDesembField;
    private Estado uFDesembField;
    private DateTime? dDesembField;
    private TipoViaTransporteDI ctpViaTransp = TipoViaTransporteDI.EntradaSaidaFicticia;
    private double? cAFRMMField;
    private TipoIntermedioDI ctpIntermedio = TipoIntermedioDI.ContaPropria;
    private string cExportadorField;
    private List<ProdutoDeclaracaoImportacao> adiField;

    public DeclaracaoImportacao() : base()
    {
        adiField = [];
    }

    public string nDI
    {
        get => nDIField;
        set
        {
            if (nDIField is null || nDIField.Equals(value) != true)
            {
                nDIField = value;
                OnPropertyChanged(nameof(nDI));
            }
        }
    }

    public DateTime? dDI
    {
        get => dDIField;
        set
        {
            if (dDIField is null || dDIField.Equals(value) != true)
            {
                dDIField = value;
                OnPropertyChanged(nameof(dDI));
            }
        }
    }

    public bool ShouldSerializedDI() => dDIField.HasValue;

    public string xLocDesemb
    {
        get => xLocDesembField;
        set
        {
            if (xLocDesembField is null || xLocDesembField.Equals(value) != true)
            {
                xLocDesembField = value;
                OnPropertyChanged(nameof(xLocDesemb));
            }
        }
    }

    public Estado UFDesemb
    {
        get => uFDesembField;
        set
        {
            if (uFDesembField.Equals(value) != true)
            {
                uFDesembField = value;
                OnPropertyChanged(nameof(UFDesemb));
            }
        }
    }

    public DateTime? dDesemb
    {
        get => dDesembField;
        set
        {
            if (dDesembField is null || dDesembField.Equals(value) != true)
            {
                dDesembField = value;
                OnPropertyChanged(nameof(dDesemb));
            }
        }
    }

    public bool ShouldSerializedDesemb() => dDesembField.HasValue;

    public TipoViaTransporteDI tpViaTransp
    {
        get => ctpViaTransp;
        set
        {
            if (ctpViaTransp.Equals(value) != true)
            {
                ctpViaTransp = value;
                OnPropertyChanged(nameof(tpViaTransp));
            }
        }
    }

    [XmlElement("vAFRMM")]
    public double? ValorAFRMM
    {
        get => cAFRMMField;
        set
        {
            if (cAFRMMField is null || cAFRMMField.Equals(value) != true)
            {
                cAFRMMField = value;
                OnPropertyChanged(nameof(ValorAFRMM));
            }
        }
    }

    public bool ShouldSerializedValorAFRMM() => cAFRMMField.HasValue;

    public TipoIntermedioDI tpIntermedio
    {
        get => ctpIntermedio;
        set
        {
            if (ctpIntermedio.Equals(value) != true)
            {
                ctpIntermedio = value;
                OnPropertyChanged(nameof(tpIntermedio));
            }
        }
    }

    public string cExportador
    {
        get => cExportadorField;
        set
        {
            if (cExportadorField is null || cExportadorField.Equals(value) != true)
            {
                cExportadorField = value;
                OnPropertyChanged(nameof(cExportador));
            }
        }
    }

    [XmlElement("adi")]
    public List<ProdutoDeclaracaoImportacao> adi
    {
        get => adiField;
        set
        {
            if (adiField is null || adiField.Equals(value) != true)
            {
                adiField = value;
                OnPropertyChanged(nameof(adi));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class ProdutoDeclaracaoImportacao : INotifyPropertyChanged
{
    private string nAdicaoField;
    private string nSeqAdicField;
    private string cFabricanteField;
    private string vDescDIField;

    public string nAdicao
    {
        get => nAdicaoField;
        set
        {
            if (nAdicaoField is null || nAdicaoField.Equals(value) != true)
            {
                nAdicaoField = value;
                OnPropertyChanged(nameof(nAdicao));
            }
        }
    }

    public string nSeqAdic
    {
        get => nSeqAdicField;
        set
        {
            if (nSeqAdicField is null || nSeqAdicField.Equals(value) != true)
            {
                nSeqAdicField = value;
                OnPropertyChanged(nameof(nSeqAdic));
            }
        }
    }

    public string cFabricante
    {
        get => cFabricanteField;
        set
        {
            if (cFabricanteField is null || cFabricanteField.Equals(value) != true)
            {
                cFabricanteField = value;
                OnPropertyChanged(nameof(cFabricante));
            }
        }
    }

    public string vDescDI
    {
        get => vDescDIField;
        set
        {
            if (vDescDIField is null || vDescDIField.Equals(value) != true)
            {
                vDescDIField = value;
                OnPropertyChanged(nameof(vDescDI));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Totais : INotifyPropertyChanged
{
    public Totais() : base()
    {
        // Me.retTribField = New TNFeInfNFeTotalRetTrib()
        // Me.iSSQNtotField = New TNFeInfNFeTotalISSQNtot()
        // Me.iCMSTotField = New TotalICMS()
    }

    private TotalICMS iCMSTotField;
    private TotalISSQN iSSQNtotField;
    private TotalRetencaoTributos retTribField;

    [XmlElement("ICMSTot")]
    public TotalICMS ICMS
    {
        get => iCMSTotField;
        set
        {
            if (iCMSTotField is null || iCMSTotField.Equals(value) != true)
            {
                iCMSTotField = value;
                OnPropertyChanged(nameof(ICMS));
            }
        }
    }

    [XmlElement("ISSQNtot")]
    public TotalISSQN ISSQN
    {
        get => iSSQNtotField;
        set
        {
            if (iSSQNtotField is null || iSSQNtotField.Equals(value) != true)
            {
                iSSQNtotField = value;
                OnPropertyChanged(nameof(ISSQN));
            }
        }
    }

    [XmlElement("retTrib")]
    public TotalRetencaoTributos Retencoes
    {
        get => retTribField;
        set
        {
            if (retTribField is null || retTribField.Equals(value) != true)
            {
                retTribField = value;
                OnPropertyChanged(nameof(Retencoes));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TotalICMS : INotifyPropertyChanged
{
    private double? vBCField;
    private double? vICMSField;
    private double? vBCSTField;
    private double? vSTField;
    private double? vProdField;
    private double? vFreteField;
    private double? vSegField;
    private double? vDescField;
    private double? vIIField;
    private double? vIPIField;
    private double? vIPIDevolField;
    private double? vPISField;
    private double? vCOFINSField;
    private double? vOutroField;
    private double? vNFField;

    [XmlElement("vBC")]
    public double? BaseDeCalculo
    {
        get => vBCField;
        set
        {
            if (vBCField is null || vBCField.Equals(value) != true)
            {
                vBCField = value;
                OnPropertyChanged(nameof(BaseDeCalculo));
            }
        }
    }

    public bool ShouldSerializeBaseDeCalculo() => vBCField.HasValue;

    [XmlElement("vICMS")]
    public double? ICMS
    {
        get => vICMSField;
        set
        {
            if (vICMSField is null || vICMSField.Equals(value) != true)
            {
                vICMSField = value;
                OnPropertyChanged(nameof(ICMS));
            }
        }
    }

    public bool ShouldSerializeICMS() => vICMSField.HasValue;

    [XmlElement("vBCST")]
    public double? BaseDeCalculoST
    {
        get => vBCSTField;
        set
        {
            if (vBCSTField is null || vBCSTField.Equals(value) != true)
            {
                vBCSTField = value;
                OnPropertyChanged(nameof(BaseDeCalculoST));
            }
        }
    }

    public bool ShouldSerializeBaseDeCalculoST() => vBCSTField.HasValue;

    [XmlElement("vST")]
    public double? ICMSST
    {
        get => vSTField;
        set
        {
            if (vSTField is null || vSTField.Equals(value) != true)
            {
                vSTField = value;
                OnPropertyChanged(nameof(ICMSST));
            }
        }
    }

    public bool ShouldSerializeICMSST() => vSTField.HasValue;

    [XmlElement("vProd")]
    public double? Produtos
    {
        get => vProdField;
        set
        {
            if (vProdField is null || vProdField.Equals(value) != true)
            {
                vProdField = value;
                OnPropertyChanged(nameof(Produtos));
            }
        }
    }

    public bool ShouldSerializeProdutos() => vProdField.HasValue;

    [XmlElement("vFrete")]
    public double? Frete
    {
        get => vFreteField;
        set
        {
            if (vFreteField is null || vFreteField.Equals(value) != true)
            {
                vFreteField = value;
                OnPropertyChanged(nameof(Frete));
            }
        }
    }

    public bool ShouldSerializeFrete() => vFreteField.HasValue;

    [XmlElement("vSeg")]
    public double? Seguros
    {
        get => vSegField;
        set
        {
            if (vSegField is null || vSegField.Equals(value) != true)
            {
                vSegField = value;
                OnPropertyChanged(nameof(Seguros));
            }
        }
    }

    public bool ShouldSerializeSeguros() => vSegField.HasValue;

    [XmlElement("vDesc")]
    public double? Desconto
    {
        get => vDescField;
        set
        {
            if (vDescField is null || vDescField.Equals(value) != true)
            {
                vDescField = value;
                OnPropertyChanged(nameof(Desconto));
            }
        }
    }

    public bool ShouldSerializeDesconto() => vDescField.HasValue;

    /// <summary>
    /// What the hell is that?
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("vII")]
    public double? II
    {
        get => vIIField;
        set
        {
            if (vIIField is null || vIIField.Equals(value) != true)
            {
                vIIField = value;
                OnPropertyChanged(nameof(II));
            }
        }
    }

    public bool ShouldSerializeII() => vIIField.HasValue;

    [XmlElement("vIPI")]
    public double? IPI
    {
        get => vIPIField;
        set
        {
            if (vIPIField is null || vIPIField.Equals(value) != true)
            {
                vIPIField = value;
                OnPropertyChanged(nameof(IPI));
            }
        }
    }

    public bool ShouldSerializeIPI() => vIPIField.HasValue;

    [XmlElement("vIPIDevol")]
    public double? vIPIDevol
    {
        get => vIPIDevolField;
        set
        {
            if (vIPIDevolField is null || vIPIDevolField.Equals(value) != true)
            {
                vIPIDevolField = value;
                OnPropertyChanged(nameof(vIPIDevol));
            }
        }
    }

    public bool ShouldSerializevIPIDevol() => vIPIDevolField.HasValue;

    [XmlElement("vPIS")]
    public double? PIS
    {
        get => vPISField;
        set
        {
            if (vPISField is null || vPISField.Equals(value) != true)
            {
                vPISField = value;
                OnPropertyChanged(nameof(PIS));
            }
        }
    }

    public bool ShouldSerializePIS() => vPISField.HasValue;

    [XmlElement("vCOFINS")]
    public double? COFINS
    {
        get => vCOFINSField;
        set
        {
            if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
            {
                vCOFINSField = value;
                OnPropertyChanged(nameof(COFINS));
            }
        }
    }

    public bool ShouldSerializeCOFINS() => vCOFINSField.HasValue;

    [XmlElement("vOutro")]
    public double? Outros
    {
        get => vOutroField;
        set
        {
            if (vOutroField is null || vOutroField.Equals(value) != true)
            {
                vOutroField = value;
                OnPropertyChanged(nameof(Outros));
            }
        }
    }

    public bool ShouldSerializeOutros() => vOutroField.HasValue;

    [XmlElement("vNF")]
    public double? TotalNF
    {
        get => vNFField;
        set
        {
            if (vNFField is null || vNFField.Equals(value) != true)
            {
                vNFField = value;
                OnPropertyChanged(nameof(TotalNF));
            }
        }
    }

    public bool ShouldSerializeTotalNF() => vNFField.HasValue;

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TotalISSQN : INotifyPropertyChanged
{
    private double? vServField;
    private double? vBCField;
    private double? vISSField;
    private double? vPISField;
    private double? vCOFINSField;

    public double? vServ
    {
        get => vServField;
        set
        {
            if (vServField is null || vServField.Equals(value) != true)
            {
                vServField = value;
                OnPropertyChanged(nameof(vServ));
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

    public double? vISS
    {
        get => vISSField;
        set
        {
            if (vISSField is null || vISSField.Equals(value) != true)
            {
                vISSField = value;
                OnPropertyChanged(nameof(vISS));
            }
        }
    }

    public double? vPIS
    {
        get => vPISField;
        set
        {
            if (vPISField is null || vPISField.Equals(value) != true)
            {
                vPISField = value;
                OnPropertyChanged(nameof(vPIS));
            }
        }
    }

    public double? vCOFINS
    {
        get => vCOFINSField;
        set
        {
            if (vCOFINSField is null || vCOFINSField.Equals(value) != true)
            {
                vCOFINSField = value;
                OnPropertyChanged(nameof(vCOFINS));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class TotalRetencaoTributos : INotifyPropertyChanged
{
    private string vRetPISField;
    private string vRetCOFINSField;
    private string vRetCSLLField;
    private string vBCIRRFField;
    private string vIRRFField;
    private string vBCRetPrevField;
    private string vRetPrevField;

    public string vRetPIS
    {
        get => vRetPISField;
        set
        {
            if (vRetPISField is null || vRetPISField.Equals(value) != true)
            {
                vRetPISField = value;
                OnPropertyChanged(nameof(vRetPIS));
            }
        }
    }

    public string vRetCOFINS
    {
        get => vRetCOFINSField;
        set
        {
            if (vRetCOFINSField is null || vRetCOFINSField.Equals(value) != true)
            {
                vRetCOFINSField = value;
                OnPropertyChanged(nameof(vRetCOFINS));
            }
        }
    }

    public string vRetCSLL
    {
        get => vRetCSLLField;
        set
        {
            if (vRetCSLLField is null || vRetCSLLField.Equals(value) != true)
            {
                vRetCSLLField = value;
                OnPropertyChanged(nameof(vRetCSLL));
            }
        }
    }

    public string vBCIRRF
    {
        get => vBCIRRFField;
        set
        {
            if (vBCIRRFField is null || vBCIRRFField.Equals(value) != true)
            {
                vBCIRRFField = value;
                OnPropertyChanged(nameof(vBCIRRF));
            }
        }
    }

    public string vIRRF
    {
        get => vIRRFField;
        set
        {
            if (vIRRFField is null || vIRRFField.Equals(value) != true)
            {
                vIRRFField = value;
                OnPropertyChanged(nameof(vIRRF));
            }
        }
    }

    public string vBCRetPrev
    {
        get => vBCRetPrevField;
        set
        {
            if (vBCRetPrevField is null || vBCRetPrevField.Equals(value) != true)
            {
                vBCRetPrevField = value;
                OnPropertyChanged(nameof(vBCRetPrev));
            }
        }
    }

    public string vRetPrev
    {
        get => vRetPrevField;
        set
        {
            if (vRetPrevField is null || vRetPrevField.Equals(value) != true)
            {
                vRetPrevField = value;
                OnPropertyChanged(nameof(vRetPrev));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Cobranca : INotifyPropertyChanged
{
    private CobrancaFatura fatField;
    private List<CobrancaDuplicata> dupField;

    public Cobranca() : base()
    {
        dupField = [];
        // Me.fatField = New TNFeInfNFeCobrFat()
    }

    public CobrancaFatura fat
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
    public List<CobrancaDuplicata> dup
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

    public bool MostraFatura
    {
        get
        {
            if (dup is null)
            {
                return true;
            }
            else if (dup.Count <= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class CobrancaFatura : INotifyPropertyChanged
{
    private string nFatField;
    private double? vOrigField;
    private double? vDescField;
    private double? vLiqField;

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

    public double? vOrig
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

    public double? vDesc
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

    public double? vLiq
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public override string ToString() => string.Format("FATURA: Valor original: {0:c2}" + '\r' + "Desconto: {1:c2}" + '\r' + "Valor Líquido: {2:c2}", vOrig, vDesc, vLiq);
}

public partial class CobrancaDuplicata : INotifyPropertyChanged
{
    private string nDupField;
    private DateTime? dVencField;
    private double? vDupField;

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

    [XmlIgnore()]
    public DateTime? dVenc
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

    /// <summary>
    /// Campo em formato string para escrita do XML no padrão exigido pela NF-e
    /// Utilize o campo 'dVenc' (Date?) para trabalho. Ambos estarão
    /// automaticamente em sincronia
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("dVenc")]
    public string dVencXML
    {
        get
        {
            if (dVenc.HasValue == true)
            {
                return string.Format("{0:yyyy-MM-dd}", dVenc);
            }
            else
            {
                return null;
            }
        }
        set
        {
            if (dVencField is null || dVencField.Equals(value) != true)
            {
                if (value != null)
                {
                    var dt = value.Split("-");
                    dVencField = new DateTime(Conversions.ToInteger(dt[0]), Conversions.ToInteger(dt[1]), Conversions.ToInteger(dt[2]));
                }
                else
                {
                    dVencField = default;
                }

                OnPropertyChanged(nameof(dVenc));
            }
        }
    }

    public double? vDup
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

    public bool ShouldSerializevDup() => vDupField.HasValue;

    public event PropertyChangedEventHandler PropertyChanged;

    public override string ToString() => string.Format("Nº {0}, venc.: {1:dd/MM/yyyy}, valor: {2:c2}", nDup, dVenc, vDup);

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesAdicionais : INotifyPropertyChanged
{
    private string infAdFiscoField;
    private string infCplField;
    private List<InformacoesAdicionaisObsContribuite> obsContField;
    private List<InformacoesAdicionaisObsFisco> obsFiscoField;
    private List<InformacoesAdicionaisProcRef> procRefField;

    public InformacoesAdicionais() : base()
    {
        procRefField = new List<InformacoesAdicionaisProcRef>();
        obsFiscoField = new List<InformacoesAdicionaisObsFisco>();
        obsContField = new List<InformacoesAdicionaisObsContribuite>();
    }

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

    public string infCpl
    {
        get => infCplField;
        set
        {
            if (infCplField is null || infCplField.Equals(value) != true)
            {
                infCplField = value;
                OnPropertyChanged(nameof(infCpl));
            }
        }
    }

    [XmlElement("obsCont")]
    public List<InformacoesAdicionaisObsContribuite> obsCont
    {
        get => obsContField;
        set
        {
            if (obsContField is null || obsContField.Equals(value) != true)
            {
                obsContField = value;
                OnPropertyChanged(nameof(obsCont));
            }
        }
    }

    [XmlElement("obsFisco")]
    public List<InformacoesAdicionaisObsFisco> obsFisco
    {
        get => obsFiscoField;
        set
        {
            if (obsFiscoField is null || obsFiscoField.Equals(value) != true)
            {
                obsFiscoField = value;
                OnPropertyChanged(nameof(obsFisco));
            }
        }
    }

    [XmlElement("procRef")]
    public List<InformacoesAdicionaisProcRef> procRef
    {
        get => procRefField;
        set
        {
            if (procRefField is null || procRefField.Equals(value) != true)
            {
                procRefField = value;
                OnPropertyChanged(nameof(procRef));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesAdicionaisObsContribuite : INotifyPropertyChanged
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesAdicionaisObsFisco : INotifyPropertyChanged
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class InformacoesAdicionaisProcRef : INotifyPropertyChanged
{
    private string nProcField;
    private IndicadorProcessoReferenciado indProcField;

    public string nProc
    {
        get => nProcField;
        set
        {
            if (nProcField is null || nProcField.Equals(value) != true)
            {
                nProcField = value;
                OnPropertyChanged(nameof(nProc));
            }
        }
    }

    public IndicadorProcessoReferenciado indProc
    {
        get => indProcField;
        set
        {
            if (indProcField.Equals(value) != true)
            {
                indProcField = value;
                OnPropertyChanged(nameof(indProc));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Exportacao : INotifyPropertyChanged
{
    private Estado uFEmbarqField;
    private string xLocEmbarqField;

    public Estado UFEmbarq
    {
        get => uFEmbarqField;
        set
        {
            if (uFEmbarqField.Equals(value) != true)
            {
                uFEmbarqField = value;
                OnPropertyChanged(nameof(UFEmbarq));
            }
        }
    }

    public string xLocEmbarq
    {
        get => xLocEmbarqField;
        set
        {
            if (xLocEmbarqField is null || xLocEmbarqField.Equals(value) != true)
            {
                xLocEmbarqField = value;
                OnPropertyChanged(nameof(xLocEmbarq));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Compra : INotifyPropertyChanged
{
    private string xNEmpField;
    private string xPedField;
    private string xContField;

    public string xNEmp
    {
        get => xNEmpField;
        set
        {
            if (xNEmpField is null || xNEmpField.Equals(value) != true)
            {
                xNEmpField = value;
                OnPropertyChanged(nameof(xNEmp));
            }
        }
    }

    public string xPed
    {
        get => xPedField;
        set
        {
            if (xPedField is null || xPedField.Equals(value) != true)
            {
                xPedField = value;
                OnPropertyChanged(nameof(xPed));
            }
        }
    }

    public string xCont
    {
        get => xContField;
        set
        {
            if (xContField is null || xContField.Equals(value) != true)
            {
                xContField = value;
                OnPropertyChanged(nameof(xCont));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class Cana : INotifyPropertyChanged
{
    private string safraField;
    private string refField;
    private List<CanaDiario> forDiaField;
    private string qTotMesField;
    private string qTotAntField;
    private string qTotGerField;
    private List<CanaDeducao> deducField;
    private string vForField;
    private string vTotDedField;
    private string vLiqForField;

    public Cana() : base()
    {
        deducField = new List<CanaDeducao>();
        forDiaField = new List<CanaDiario>();
    }

    public string safra
    {
        get => safraField;
        set
        {
            if (safraField is null || safraField.Equals(value) != true)
            {
                safraField = value;
                OnPropertyChanged(nameof(safra));
            }
        }
    }

    public string @ref
    {
        get => refField;
        set
        {
            if (refField is null || refField.Equals(value) != true)
            {
                refField = value;
                OnPropertyChanged(nameof(@ref));
            }
        }
    }

    [XmlElement("forDia")]
    public List<CanaDiario> forDia
    {
        get => forDiaField;
        set
        {
            if (forDiaField is null || forDiaField.Equals(value) != true)
            {
                forDiaField = value;
                OnPropertyChanged(nameof(forDia));
            }
        }
    }

    public string qTotMes
    {
        get => qTotMesField;
        set
        {
            if (qTotMesField is null || qTotMesField.Equals(value) != true)
            {
                qTotMesField = value;
                OnPropertyChanged(nameof(qTotMes));
            }
        }
    }

    public string qTotAnt
    {
        get => qTotAntField;
        set
        {
            if (qTotAntField is null || qTotAntField.Equals(value) != true)
            {
                qTotAntField = value;
                OnPropertyChanged(nameof(qTotAnt));
            }
        }
    }

    public string qTotGer
    {
        get => qTotGerField;
        set
        {
            if (qTotGerField is null || qTotGerField.Equals(value) != true)
            {
                qTotGerField = value;
                OnPropertyChanged(nameof(qTotGer));
            }
        }
    }

    [XmlElement("deduc")]
    public List<CanaDeducao> deduc
    {
        get => deducField;
        set
        {
            if (deducField is null || deducField.Equals(value) != true)
            {
                deducField = value;
                OnPropertyChanged(nameof(deduc));
            }
        }
    }

    public string vFor
    {
        get => vForField;
        set
        {
            if (vForField is null || vForField.Equals(value) != true)
            {
                vForField = value;
                OnPropertyChanged(nameof(vFor));
            }
        }
    }

    public string vTotDed
    {
        get => vTotDedField;
        set
        {
            if (vTotDedField is null || vTotDedField.Equals(value) != true)
            {
                vTotDedField = value;
                OnPropertyChanged(nameof(vTotDed));
            }
        }
    }

    public string vLiqFor
    {
        get => vLiqForField;
        set
        {
            if (vLiqForField is null || vLiqForField.Equals(value) != true)
            {
                vLiqForField = value;
                OnPropertyChanged(nameof(vLiqFor));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class CanaDiario : INotifyPropertyChanged
{
    private string qtdeField;
    private string diaField;

    public string qtde
    {
        get => qtdeField;
        set
        {
            if (qtdeField is null || qtdeField.Equals(value) != true)
            {
                qtdeField = value;
                OnPropertyChanged(nameof(qtde));
            }
        }
    }

    [XmlAttribute()]
    public string dia
    {
        get => diaField;
        set
        {
            if (diaField is null || diaField.Equals(value) != true)
            {
                diaField = value;
                OnPropertyChanged(nameof(dia));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class CanaDeducao : INotifyPropertyChanged
{
    private string xDedField;
    private string vDedField;

    public string xDed
    {
        get => xDedField;
        set
        {
            if (xDedField is null || xDedField.Equals(value) != true)
            {
                xDedField = value;
                OnPropertyChanged(nameof(xDed));
            }
        }
    }

    public string vDed
    {
        get => vDedField;
        set
        {
            if (vDedField is null || vDedField.Equals(value) != true)
            {
                vDedField = value;
                OnPropertyChanged(nameof(vDed));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

/// <summary>
/// NF-e 4.00
/// </summary>
public partial class Pagamento : INotifyPropertyChanged
{
    private List<DetalhamentoPagamento> detPagField;

    public Pagamento() : base()
    {
        detPagField = new List<DetalhamentoPagamento>();
        // Me.fatField = New TNFeInfNFeCobrFat()
    }

    [XmlElement("detPag")]
    public List<DetalhamentoPagamento> DetalhamentoPagamentos
    {
        get => detPagField;
        set
        {
            if (detPagField is null || detPagField.Equals(value) != true)
            {
                detPagField = value;
                OnPropertyChanged("detPag");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoPagamento : INotifyPropertyChanged
{
    private FormaDePagamento? indPagField; // = FormaDePagamento.Vista
    private FormaPagamento tPagField = FormaPagamento.SemPagto;
    private double? vPagField;
    private double? vTrocoField;
    private DetalhamentoPagamentoCartao card;

    public FormaDePagamento? indPag
    {
        get => indPagField;
        set
        {
            if (indPagField.Equals(value) != true)
            {
                indPagField = value;
                OnPropertyChanged(nameof(indPag));
            }
        }
    }

    public bool ShouldSerializeindPag() => indPag.HasValue;

    public FormaPagamento tPag
    {
        get => tPagField;
        set
        {
            if (tPagField.Equals(value) != true)
            {
                tPagField = value;
                OnPropertyChanged(nameof(tPag));
            }
        }
    }

    public double? vPag
    {
        get => vPagField;
        set
        {
            if (vPagField is null || vPagField.Equals(value) != true)
            {
                vPagField = value;
                OnPropertyChanged(nameof(vPag));
            }
        }
    }

    public bool ShouldSerializevPag() => vPagField.HasValue;

    [XmlElement("card")]
    public DetalhamentoPagamentoCartao DetalhamentoCartao
    {
        get => card;
        set
        {
            if (card is null || card.Equals(value) != true)
            {
                card = value;
                OnPropertyChanged(nameof(DetalhamentoCartao));
            }
        }
    }

    public double? vTroco
    {
        get => vTrocoField;
        set
        {
            if (vTrocoField is null || vTrocoField.Equals(value) != true)
            {
                vTrocoField = value;
                OnPropertyChanged(nameof(vTroco));
            }
        }
    }

    public bool ShouldSerializevTroco() => vTrocoField.HasValue;

    public event PropertyChangedEventHandler PropertyChanged;

    public override string ToString() => string.Format("Indicador {0}, Forma: {1}, valor: {2:c2}", indPag, tPag, vPag);

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

public partial class DetalhamentoPagamentoCartao : INotifyPropertyChanged
{
    private TipoIntegracaoPgCartao tpIntegraField = TipoIntegracaoPgCartao.TEF_eCommerce;
    private string cnpjField;
    private BandeiraCartaoCredito tBandField = BandeiraCartaoCredito.Outros;
    private string cAutField;

    public TipoIntegracaoPgCartao tpIntegra
    {
        get => tpIntegraField;
        set
        {
            if (tpIntegraField.Equals(value) != true)
            {
                tpIntegraField = value;
                OnPropertyChanged(nameof(tpIntegra));
            }
        }
    }

    public string CNPJ
    {
        get => cnpjField;
        set
        {
            if (cnpjField is null || cnpjField.Equals(value) != true)
            {
                cnpjField = value;
                OnPropertyChanged(nameof(CNPJ));
            }
        }
    }

    public BandeiraCartaoCredito tBand
    {
        get => tBandField;
        set
        {
            if (tBandField.Equals(value) != true)
            {
                tBandField = value;
                OnPropertyChanged(nameof(tBand));
            }
        }
    }

    public string cAut
    {
        get => cAutField;
        set
        {
            if (cAutField is null || cAutField.Equals(value) != true)
            {
                cAutField = value;
                OnPropertyChanged(nameof(cAut));
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}