using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.CTe;

namespace EficazFramework.SPED.Schemas.CTeOS;

[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("cteOSProc", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class ProcessoCTeOS : INotifyPropertyChanged, IXmlSpedDocument
{
    public ProcessoCTeOS() : base()
    {
        protCTeField = new ProtocoloAutorizacao();
        cTeField = new CTeOS();
    }

    private CTeOS cTeField;
    private ProtocoloAutorizacao protCTeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    public CTeOS CTeOS
    {
        get => cTeField;
        set
        {
            if (cTeField is null || cTeField.Equals(value) != true)
            {
                cTeField = value;
                OnPropertyChanged(nameof(CTeOS));
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
            sSerializer ??= new XmlSerializer(typeof(ProcessoCTeOS));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeOSWithProtocol;

    [XmlIgnore()]
    public DateTime? DataEmissao => CTeOS.Informacoes.IdentificacaoOperacao.DataEmissao;

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.CTe.Informacoes.IdentificacaoOperacao.Chave
            if (CTeOS.Informacoes.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(CTeOS.Informacoes.Id, "[^0-9]", "");
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
    public static bool CanDeserialize(string xml, ref ProcessoCTeOS obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref ProcessoCTeOS obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static ProcessoCTeOS Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (ProcessoCTeOS)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static ProcessoCTeOS Deserialize(System.IO.Stream s) => (ProcessoCTeOS)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoCTeOS obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref ProcessoCTeOS obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static ProcessoCTeOS LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<ProcessoCTeOS> LoadFromAsync(System.IO.Stream source)
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

    public static async Task<ProcessoCTeOS> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
            Debug.WriteLine(inner_load.ToString());
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
public partial class CTeOS : INotifyPropertyChanged, IXmlSpedDocument
{

    public CTeOS() : base()
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
            sSerializer ??= new XmlSerializer(typeof(CTeOS));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.CTeOSWithoutProtocol;

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
    public static bool CanDeserialize(string xml, ref CTeOS obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref CTeOS obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static CTeOS Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (CTeOS)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static CTeOS Deserialize(System.IO.Stream s) => (CTeOS)Serializer.Deserialize(s);


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
    public static bool CanLoadFrom(System.IO.Stream source, ref CTeOS obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref CTeOS obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static CTeOS LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<CTeOS> LoadFromAsync(System.IO.Stream source)
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

    public static async Task<CTeOS> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

public partial class Tomador : INotifyPropertyChanged
{
    private string itemField;
    private PersonalidadeJuridica7 itemElementNameField;
    private string ieField;
    private string xNomeField;
    private string xFantField;
    private string foneField;
    private Endereco enderTomaField;
    private string emailField;

    public Tomador() : base()
    {
        enderTomaField = new Endereco();
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

    public virtual void OnPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
