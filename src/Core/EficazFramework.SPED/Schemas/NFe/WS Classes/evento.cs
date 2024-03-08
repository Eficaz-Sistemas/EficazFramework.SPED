namespace EficazFramework.SPED.Schemas.NFe;

[Serializable()]
[XmlType(TypeName = "envEvento", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class PedidoEnvioEvento
{

    private static XmlSerializer sSerializer;

    /// <summary>
    /// ATENÇÃO:
    /// Identificador de controle do Lote de Envio do Evento.
    /// Número sequencial autoincremental único para identificação do Lote. A responsabilidade de gerar e controlar o
    /// identificador é exclusiva do autor do evento. O Web Service não faz qualquer uso ou controle deste identificador.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("idLote")]
    public string Lote { get; set; }


    /// <summary>
    /// Máximo de eventos suportados por Lote: 20;
    /// Cada evento deve ser assinado digitalmente na tag 'infEvento'.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("evento")]
    public List<Evento> Eventos { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public string Versao { get; set; }  

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(PedidoEnvioEvento));
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
    public static bool CanDeserialize(string xml, ref PedidoEnvioEvento obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref PedidoEnvioEvento obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static PedidoEnvioEvento Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (PedidoEnvioEvento)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static PedidoEnvioEvento Deserialize(System.IO.Stream s) =>
        (PedidoEnvioEvento)Serializer.Deserialize(s);

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
    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoEnvioEvento obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref PedidoEnvioEvento obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static PedidoEnvioEvento LoadFrom(System.IO.Stream source, bool close_stream = true)
    {
        // Dim file As System.IO.FileStream = Nothing
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

    public static async Task<PedidoEnvioEvento> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

public partial class Evento
{
    private string versaoField;

    [XmlElement("infEvento")]
    public InformacaoEvento InformacaoEvento { get; set; }

    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature { get; set; }

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
                if (InformacaoEvento is not null)
                    InformacaoEvento.EventoVersao = value;
            }
        }
    }


    public virtual void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

    public event PropertyChangedEventHandler PropertyChanged;
}

public partial class InformacaoEvento
{
    public InformacaoEvento() : base()
    {
        detEventoField = new();
    }

    private string chNFeField;
    private CodigoEvento tpEventoField;
    private string nSeqEventoField;
    private string verEventoField;
    private DetalheEvento detEventoField;
    private string idField;

    [XmlElement("cOrgao")]
    public OrgaoIBGE Orgao { get; set; }

    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("CNPJ", typeof(string))]
    [XmlElement("CPF", typeof(string))]
    [XmlChoiceIdentifier("PersonalidadeJuridica")]
    public string CNPJ_CPF { get; set; }

    [XmlIgnore()]
    public PersonalidadeJuridica PersonalidadeJuridica { get; set; }

    [XmlElement("chNFe")]
    public string ChaveNFe
    {
        get => chNFeField;
        set
        {
            if (chNFeField is null || chNFeField.Equals(value) != true)
            {
                chNFeField = value;
                Regenerate_ID();
            }
        }
    }

    [XmlIgnore]
    public DateTime? EventoData { get; set; }

    [XmlElement("dhEvento")]
    public string EventoDataString
    {
        get
        {
            if (EventoData.HasValue == true)
            {
                return EventoData.Value.ToString("yyyy-MM-ddTHH:mm:sszzz");
            }
            else
            {
                return DateTime.Now.ToString("AAAA-MM-DDThh:mm:ssTZD");
            }
        }
        set => EventoData = DateTime.Parse(value);
    }

    [XmlElement("tpEvento")]
    public CodigoEvento EventoCodigo
    {
        get => tpEventoField;
        set
        {
            if (tpEventoField.Equals(value) != true)
            {
                tpEventoField = value;

                if (EventoDetalhes is not null)
                {
                    EventoDetalhes.EventoDescricao = value switch
                    {
                        CodigoEvento.Confirmacao => "Confirmacao da Operacao",
                        CodigoEvento.NaoRealizada => "Operacao nao Realizada",
                        CodigoEvento.Desconhecimento => "Desconhecimento da Operacao",
                        CodigoEvento.Ciencia => "Ciencia da Operacao",
                        _ => "Não Aplicável"
                    };
                    Regenerate_ID();
                }
            }
        }
    }

    /// <summary>
    /// Sequencial do evento. INFORMAR 1.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("nSeqEvento")]
    public string EventoNumeroSequencial
    {
        get => nSeqEventoField;
        set
        {
            if (nSeqEventoField is null || nSeqEventoField.Equals(value) != true)
            {
                nSeqEventoField = value;
                Regenerate_ID();
            }
        }
    }

    [XmlElement("verEvento")]
    public string EventoVersao { get; set; }

    [XmlElement("detEvento")]
    public DetalheEvento EventoDetalhes { get; set; }

    /// <summary>
    /// Identificador da TAG a ser assinada.
    /// A regra de formação do ID é:
    /// "ID" + tpEvento + chave da NFe + nSeqEvento.
    /// É gerado automaticamente.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlAttribute(DataType = "ID")]
    public string Id { get; set; }


    public void Regenerate_ID()
    {
        var buider = new System.Text.StringBuilder();
        buider.Append("ID");
        buider.Append((int)EventoCodigo);

        if (!string.IsNullOrEmpty(ChaveNFe) | string.IsNullOrWhiteSpace(ChaveNFe))
            buider.Append(ChaveNFe);

        buider.Append("01");
        Id = buider.ToString();
    }
}

public partial class DetalheEvento
{
    [XmlElement("descEvento")]
    public string EventoDescricao { get; set; }

    /// <summary>
    /// Utilizar este campo apenas quando o evento for "Operação não Realizada".
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement("xJust")]
    public string Justificativa { get; set; }

    [XmlElement("xCorrecao")]
    public string Correcao { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public VersaoServicoEvento Versao { get; set; }
}

// # Retorno #

[Serializable()]
[XmlType(TypeName = "retEnvEvento", Namespace = "http://www.portalfiscal.inf.br/nfe")]
[XmlRoot(Namespace = "http://www.portalfiscal.inf.br/nfe", IsNullable = true)]
public partial class RetornoEnvioEvento : IXmlSpedDocument
{
    private static XmlSerializer sSerializer;

    [XmlElement("idLote")]
    public string Lote { get; set; }

    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("verAplic")]
    public string VersaoAplicativo { get; set; }

    [XmlElement("cOrgao")]
    public OrgaoIBGE Orgao { get; set; }

    [XmlElement("cStat")]
    public string RespostaCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string RespostaDescricao { get; set; }

    [XmlElement("retEvento")]
    public List<EventoRetorno> ResultadoEventos { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public string Versao { get; set; }

    private static XmlSerializer Serializer
    {
        get
        {
            sSerializer ??= new XmlSerializer(typeof(RetornoEnvioEvento));
            return sSerializer;
        }
    }

    public XmlDocumentType DocumentType => XmlDocumentType.NFeRetEvent;

    public DateTime? DataEmissao => ResultadoEventos.FirstOrDefault()?.InformacaoEventoRetorno.EventoDataRegistro;

    public string Chave => ResultadoEventos.FirstOrDefault()?.InformacaoEventoRetorno.ChaveNFe;

    public override string ToString()
    {
        var b = new System.Text.StringBuilder();
        foreach (EventoRetorno ev in ResultadoEventos)
            b.AppendLine(ev.InformacaoEventoRetorno.ToString());
        return b.ToString();
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
    public static bool CanDeserialize(string xml, ref RetornoEnvioEvento obj, ref Exception exception)
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

    public static bool CanDeserialize(string xml, ref RetornoEnvioEvento obj)
    {
        Exception exception = null;
        return CanDeserialize(xml, ref obj, ref exception);
    }

    public static RetornoEnvioEvento Deserialize(string xml)
    {
        System.IO.StringReader stringReader = null;
        try
        {
            stringReader = new System.IO.StringReader(xml);
            return (RetornoEnvioEvento)Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader));
        }
        finally
        {
            stringReader?.Dispose();
        }
    }

    public static RetornoEnvioEvento Deserialize(System.IO.Stream s) =>
        (RetornoEnvioEvento)Serializer.Deserialize(s);

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
    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoEnvioEvento obj, ref Exception exception)
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

    public static bool CanLoadFrom(System.IO.Stream source, ref RetornoEnvioEvento obj)
    {
        Exception exception = null;
        return CanLoadFrom(source, ref obj, ref exception);
    }

    public static RetornoEnvioEvento LoadFrom(System.IO.Stream source, bool close_stream = true)
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

    public static async Task<RetornoEnvioEvento> LoadFromAsync(System.IO.Stream source, bool close_stream = true)
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

public partial class EventoRetorno
{
    [XmlElement("infEvento")]
    public InformacaoEventoRetorno InformacaoEventoRetorno { get; set; }

    /// <summary>
    /// Assinatura digital do documento XML. Deverá ser aplicada no elemento infEvento.
    /// </summary>
    /// <value></value>
    /// <returns></returns>
    /// <remarks></remarks>
    [XmlElement(Namespace = "http://www.w3.org/2000/09/xmldsig#")]
    public SignatureType Signature { get; set; }

    [XmlAttribute(AttributeName = "versao")]
    public string Versao { get; set; }

    public override string ToString() =>
        InformacaoEventoRetorno.ToString();
}

public partial class InformacaoEventoRetorno
{
    private DateTime? dhRegEventoField;

    [XmlElement("tpAmb")]
    public Ambiente Ambiente { get; set; }

    [XmlElement("verAplic")]
    public string VersaoAplicativo { get; set; }

    [XmlElement("cOrgao")]
    public OrgaoIBGE Orgao { get; set; }

    [XmlElement("cStat")]
    public string RespostaCodigo { get; set; }

    [XmlElement("xMotivo")]
    public string RespostaDescricao { get; set; }

    [XmlElement("chNFe")]
    public string ChaveNFe { get; set; }

    [XmlElement("tpEvento")]
    public CodigoEvento EventoCodigo { get; set; }

    [XmlElement("nSeqEvento")]
    public string EventoNumeroSequencial { get; set; }

    [XmlIgnore()]
    public DateTime? EventoDataRegistro { get; set; }

    [XmlElement("dhRegEvento")]
    public string EventoDataRegistro_XML
    {
        get => dhRegEventoField.ToString();
        set
        {
            var result = default(DateTime);
            if (dhRegEventoField is null || DateTime.TryParse(value, out result) || dhRegEventoField.Equals(value) != true)
            {
                dhRegEventoField = result;
            }
        }
    }

    [XmlElement("nProt")]
    public string Protocolo { get; set; }

    [XmlAttribute(DataType = "ID")]
    public string Id { get; set; }


    public override string ToString()
    {
        var b = new System.Text.StringBuilder();
        b.AppendLine("NF-e: " + ChaveNFe);
        b.Append("Resultado: ");
        b.Append(RespostaCodigo);
        b.Append(" - ");
        b.Append(RespostaDescricao);
        return b.ToString();
    }

    public void Regenerate_ID()
    {
        var buider = new System.Text.StringBuilder();
        buider.Append("ID");
        buider.Append((int)EventoCodigo);
        if (!string.IsNullOrEmpty(ChaveNFe) | string.IsNullOrWhiteSpace(ChaveNFe))
        {
            buider.Append(ChaveNFe);
        }
        buider.Append("01");
        Id = buider.ToString();
    }
}