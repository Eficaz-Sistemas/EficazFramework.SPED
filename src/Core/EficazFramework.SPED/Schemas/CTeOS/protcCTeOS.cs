using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EficazFramework.SPED.Extensions;
using EficazFramework.SPED.Schemas.CTe;
using EficazFramework.SPED.Utilities.XML;

namespace EficazFramework.SPED.Schemas.CTeOS;

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("cteOSProc", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class ProcessoCTeOS : INotifyPropertyChanged, IXmlSpedDocument
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public ProcessoCTeOS() : base()
    {
        protCTeField = new ProtocoloAutorizacao();
        cTeField = new CTeOS();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private CTeOS cTeField;
    private ProtocoloAutorizacao protCTeField;
    private string versaoField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public CTeOS CTeOS
    {
        get
        {
            return cTeField;
        }

        set
        {
            if (cTeField is null || cTeField.Equals(value) != true)
            {
                cTeField = value;
                OnPropertyChanged("CTeOS");
            }
        }
    }

    [XmlElement("protCTe")]
    public ProtocoloAutorizacao ProtocoloAutorizacao
    {
        get
        {
            return protCTeField;
        }

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(ProcessoCTeOS));
            }

            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType
    {
        get
        {
            return XmlDocumentType.CTeOSWithProtocol;
        }
    }

    [XmlIgnore()]
    public DateTime? DataEmissao
    {
        get
        {
            return CTeOS.Informacoes.IdentificacaoOperacao.DataEmissao;
        }
    }

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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            // stringReader.ReadToEnd() 'TESTING...
            return (ProcessoCTeOS)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), ProcessoCTeOS)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static ProcessoCTeOS Deserialize(System.IO.Stream s)
    {
        return (ProcessoCTeOS)Serializer.Deserialize(s);
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

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<ProcessoCTeOS> LoadFromAsync(System.IO.Stream source)
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
        // Catch inner_load As Exception
        // #If DEBUG Then
        // Debug.WriteLine(inner_load.ToString)
        // #End If
        // Return Nothing
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

    public static async Task<ProcessoCTeOS> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
    {
        if (source is null)
            throw new ArgumentException(Resources.Strings.Validation.Classes_Load_NullStreamExceptionMessage);
        System.IO.StreamReader sr = null;
        try
        {
            // file = New System.IO.FileStream(fileName, FileMode.Open, FileAccess.Read)
            sr = new System.IO.StreamReader(source);
            string xmlString = await sr.ReadToEndAsync();
            if (xmlString.Contains("<retCTeConsultaDFe"))
            {
                int startindex = xmlString.IndexOf("<procCTe");
                int length = xmlString.IndexOf("</procCTe>") - startindex + 11;
                xmlString = "<?xml version=" + '"' + "1.0" + '"' + "?>" + '\n' + xmlString.Substring(startindex, length).Replace("</procCTe>", "</cteProc>").Replace("<procCTe", "<cteProc xmlns=" + '"' + "http://www.portalfiscal.inf.br/cte" + '"');
                xmlString = xmlString.Replace("</cteProc><", "</cteProc>");
            }
            // sr.Close()
            // file.Close()
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

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
}

[System.CodeDom.Compiler.GeneratedCode("System.Xml", "4.0.30319.18053")]
[Serializable()]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("CTe", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class CTeOS : INotifyPropertyChanged, IXmlSpedDocument
{

    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public CTeOS() : base()
    {
        signatureField = new SignatureType();
        infCteField = new InformacoesCTe();
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    private InformacoesCTe infCteField;
    private SignatureType signatureField;
    private static XmlSerializer sSerializer;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    [XmlElement("infCte")]
    public InformacoesCTe Informacoes
    {
        get
        {
            return infCteField;
        }

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

    private static XmlSerializer Serializer
    {
        get
        {
            if (sSerializer is null)
            {
                sSerializer = new XmlSerializer(typeof(CTeOS));
            }

            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType
    {
        get
        {
            return XmlDocumentType.CTeOSWithoutProtocol;
        }
    }

    [XmlIgnore()]
    public DateTime? DataEmissao
    {
        get
        {
            return Informacoes.IdentificacaoOperacao.DataEmissao;
        }
    }

    [XmlIgnore()]
    public string Chave
    {
        get
        {
            // Return Me.Informacoes.IdentificacaoOperacao.Chave
            if (Informacoes.Id != null)
                return System.Text.RegularExpressions.Regex.Replace(Informacoes.Id, "[^0-9]", "");
            else
                return string.Empty;
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public event PropertyChangedEventHandler PropertyChanged;

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
    public virtual void OnPropertyChanged(string propertyName)
    {
        var handler = PropertyChanged;
        if (handler != null)
        {
            handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /* TODO ERROR: Skipped EndRegionDirectiveTrivia */
    /* TODO ERROR: Skipped RegionDirectiveTrivia */
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
            // stringReader.ReadToEnd() 'TESTING...
            return (CTeOS)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        // Return CType(Serializer.Deserialize(stringReader), CTe)
        finally
        {
            if (stringReader != null)
            {
                stringReader.Dispose();
            }
        }
    }

    public static CTeOS Deserialize(System.IO.Stream s)
    {
        return (CTeOS)Serializer.Deserialize(s);
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

            if (sr != null)
            {
                sr.Dispose();
            }
        }
    }

    public static async Task<CTeOS> LoadFromAsync(System.IO.Stream source)
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

    public static async Task<CTeOS> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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
        // Catch inner_load As Exception
        // #If DEBUG Then
        // Debug.WriteLine(inner_load.ToString)
        // #End If
        // Return Nothing
        finally
        {
            if (sr != null & close_stream == true)
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
    private static XmlSerializer sSerializer;

    public Tomador() : base()
    {
        enderTomaField = new Endereco();
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
                sSerializer = new XmlSerializer(typeof(Tomador));
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
