using System.IO.Compression;

namespace EficazFramework.SPED.Schemas.CTe;

[Serializable()]
[XmlType(Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("distDFeInt", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class PedidoDistribuicaoDFe
{
    private static XmlSerializer sSerializer;

    [XmlElement("tpAmb", Namespace = null, Order = 0)]
    public NFe.Ambiente Ambiente { get; set; }

    /// <remarks/>
    [XmlElement("cUFAutor", Namespace = null, Order = 1)]
    public NFe.OrgaoIBGE UF_Autor { get; set; }

    /// <remarks/>
    [XmlElement("CNPJ", typeof(string), Namespace = null, Order = 2)]
    [XmlElement("CPF", typeof(string), Namespace = null, Order = 2)]
    [XmlChoiceIdentifier("ItemElementName")]
    public string CNPJ_CPF { get; set; }

    /// <remarks/>
    [XmlElement(Order = 3)]
    [XmlIgnore()]
    public PersonalidadeJuridica7 ItemElementName { get; set; }

    /// <remarks/>
    [XmlElement("consNSU", typeof(distDFeIntConsNSU), Namespace = null, Order = 4)]
    [XmlElement("distNSU", typeof(distDFeIntDistNSU), Namespace = null, Order = 4)]
    public object NSUObject { get; set; }

    /// <remarks/>
    [XmlAttribute()]
    public VersaoServicoDistribuicaoDF versao { get; set; }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(PedidoDistribuicaoDFe));
            return sSerializer;
        }
    }


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
            var ns = new XmlSerializerNamespaces();
            ns.Add("", "http://www.portalfiscal.inf.br/cte");
            Serializer.Serialize(memoryStream, this, ns);
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
    public static bool CanDeserialize(string xml, ref PedidoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref PedidoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static PedidoDistribuicaoDFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (PedidoDistribuicaoDFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoDistribuicaoDFe Deserialize(System.IO.Stream s) =>
        (PedidoDistribuicaoDFe)Serializer.Deserialize(s);


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
    /// Deserializes xml markup from file into an TEnvEvento object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static PedidoDistribuicaoDFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<PedidoDistribuicaoDFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

public partial class distDFeIntConsNSU
{
    [XmlElement(DataType = "token", Order = 0)]
    public string NSU { get; set; }
}

public partial class distDFeIntDistNSU
{
    [XmlElement(DataType = "token", Order = 0)]
    public string ultNSU { get; set; }
}



[Serializable()]
[XmlType(AnonymousType = true, Namespace = "http://www.portalfiscal.inf.br/cte")]
[XmlRoot("retDistDFeInt", Namespace = "http://www.portalfiscal.inf.br/cte", IsNullable = false)]
public partial class RetornoDistribuicaoDFe
{
    private static XmlSerializer sSerializer;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public NFe.Ambiente tpAmb { get; set; }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string verAplic { get; set; }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string cStat { get; set; }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string xMotivo { get; set; }

    /// <remarks/>
    [XmlElement(Order = 4)]
    public string dhResp { get; set; }

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 5)]
    public string ultNSU { get; set; }

    /// <remarks/>
    [XmlElement(DataType = "token", Order = 6)]
    public string maxNSU { get; set; }

    /// <remarks/>
    [XmlElement(Order = 7)]
    public retDistDFeIntLoteDistDFeInt loteDistDFeInt { get; set; }

    /// <remarks/>
    [XmlAttribute()]
    public VersaoServicoDistribuicaoDF versao { get; set; }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(RetornoDistribuicaoDFe));
            return sSerializer;
        }
    }

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
    public virtual XDocument SerializeToXMLDocument()
    {
        string str = Serialize();
        if (!string.IsNullOrEmpty(str) | string.IsNullOrWhiteSpace(str))
        {
            var doc = XDocument.Load(Serialize());
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
    public static bool CanDeserialize(string xml, ref RetornoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoDistribuicaoDFe Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (RetornoDistribuicaoDFe)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoDistribuicaoDFe Deserialize(System.IO.Stream s) =>
        (RetornoDistribuicaoDFe)Serializer.Deserialize(s);


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
    /// Deserializes xml markup from file into an TEnvEvento object
    /// </summary>
    /// <param name="source">target stream of outupt xml file</param>
    /// <param name="obj">Output TEnvEvento object</param>
    /// <param name="exception">output Exception value if deserialize failed</param>
    /// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoDistribuicaoDFe obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoDistribuicaoDFe obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoDistribuicaoDFe LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<RetornoDistribuicaoDFe> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

public partial class retDistDFeIntLoteDistDFeInt
{
    [XmlElement("docZip", Order = 0)]
    public retDistDFeIntLoteDistDFeIntDocZip[] DocZip { get; set; }
}

public partial class retDistDFeIntLoteDistDFeIntDocZip
{
    [XmlAttribute(DataType = "token")]
    public string NSU { get; set; }

    [XmlAttribute()]
    public string schema { get; set; }

    [XmlText(DataType = "base64Binary")]
    public byte[] Value { get; set; }

    public async Task<byte[]> DescompactaAsync()
    {
        if (Value is null)
            return null;
        byte[] buffer = null;
        using (var compressedStream = new System.IO.MemoryStream(Value))
        {
            using (var deflatedStream = new System.IO.MemoryStream())
            {
                using (var decompressionStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    try
                    {
                        await decompressionStream.CopyToAsync(deflatedStream);
                        deflatedStream.Position = 0L;
                        buffer = deflatedStream.ToArray();
                    }
                    catch (Exception deflatEx)
                    {
                        Debug.WriteLine(deflatEx.Message);
                    }

                    decompressionStream.Dispose();
                }

                deflatedStream.Dispose();
            }

            compressedStream.Dispose();
        }
        return buffer; // Encoding.UTF8.GetString(buffer, 0, msgLength)
    }

    public async Task<string> DecodedValueAsync()
    {
        var buffer = await DescompactaAsync();
        return Encoding.UTF8.GetString(buffer, 0, buffer.Length);
    }

    public Schemas.XmlDocumentType DocumentType
    {
        get => (schema ?? "") switch
        {
            "procCTe_v2.00.xsd" => XmlDocumentType.CTeWithProtocol,
            "procCTe_v3.00.xsd" => XmlDocumentType.CTeWithProtocol,
            "procEventoCTe_v3.00.xsd" => XmlDocumentType.CTeEvent,
            _ => XmlDocumentType.Unknown
        };
    }

    public async Task<IXmlSpedDocument> GetInstanceAsync()
    {
        var ms = new System.IO.MemoryStream(await DescompactaAsync());
        IXmlSpedDocument r = DocumentType switch
        {
            XmlDocumentType.CTeWithProtocol => await ProcessoCTe.LoadFromAsync(ms, false),
            XmlDocumentType.CTeEvent => await ProcessoEvento.LoadFromAsync(ms, false),
            _ => null
        };
        ms.Dispose();
        return r;
    }

    public async Task SaveAsync(System.IO.Stream target)
    {
        var buffer = await DescompactaAsync();
        await target.WriteAsync(buffer, 0, buffer.Length);
    }

    public override string ToString() => $"Schema: {schema} | NSU: {NSU}";
}
