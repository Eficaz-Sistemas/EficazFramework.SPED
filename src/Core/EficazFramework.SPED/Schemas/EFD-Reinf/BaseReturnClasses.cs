using System.IO;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;


/// <summary>
/// Abstração padrão para implementação em todos os eventos de retorno (R-9001, R-9005, R-9011 e R-9015).
/// </summary>
public abstract class EventoRetorno : EfdReinfBindableObject
{
    /// <summary>
    /// <see cref="EficazFramework.SPED.Schemas.EFD_Reinf.Versao"/> do schema para leitura / escrita
    /// </summary>
    [XmlIgnore]
    public Versao Versao { get; set; } = Versao.v2_01_02;

    // Base Members
    private XmlSerializer sSerializer;

    /// <summary>
    /// Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando <see cref="Evento"/>
    /// </summary>
    public abstract XmlSerializer DefineSerializer();


    /// <summary>
    /// Retorna o CNPJ do Contribuinte titular do evento.
    /// </summary>
    public abstract string ContribuinteCNPJ();


    // Implemented Members

    /// <summary>
    /// Substitui o método ToString() de object para retornar o resultado do método <see cref="Serialize"/>
    /// </summary>
    public override string ToString() =>
        Write();

    /// <summary>
    /// Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML.
    /// </summary>
    /// <returns>string XML value</returns>
    public string Write()
    {
        System.IO.StreamReader streamReader = null;
        System.IO.MemoryStream memoryStream = null;
        try
        {
            memoryStream = new System.IO.MemoryStream();
            sSerializer = DefineSerializer();
            using (var xmlwriter = XmlWriter.Create(memoryStream, new XmlWriterSettings()
            {
                Indent = true,

            }))
            {
                sSerializer.Serialize(xmlwriter, this);
            }
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
    /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
    /// </summary>
    public EventoRetorno Read(string xmlContent)
    {
        sSerializer = DefineSerializer();
        var encoder = System.Text.Encoding.UTF8;
        if (!xmlContent.Contains("utf-8"))
            encoder = System.Text.Encoding.Unicode;

        return Read(new MemoryStream(encoder.GetBytes(xmlContent))) as EventoRetorno;
    }

    /// <summary>
    /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
    /// </summary>
    public EventoRetorno Read(System.IO.Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as EventoRetorno;
    }

}


/// <summary>
/// Evento Totalizador
/// </summary>
/// <exclude/>
public partial class EventoRetornoTotal : EfdReinfBindableObject
{
    private IdentificacaoEventoRetorno ideEventoField;
    private IdentificacaoContribuinte ideContriField;
    private EventoTotalReciboRetorno ideRecRetornoField;
    private EventoTotalDadosProcessamento infoRecEvField;
    //private TotalContribuinteR9015 infoCR_CNRField;
    //private TotalContribuinteR9015 infoTotalCRField;
    private string idField;

    [XmlElement()]
    public IdentificacaoEventoRetorno ideEvento
    {
        get => ideEventoField;
        set
        {
            ideEventoField = value;
            RaisePropertyChanged(nameof(ideEvento));
        }
    }

    [XmlElement()]
    public IdentificacaoContribuinte ideContri
    {
        get => ideContriField;
        set
        {
            ideContriField = value;
            RaisePropertyChanged(nameof(ideContri));
        }
    }

    [XmlElement()]
    public EventoTotalReciboRetorno ideRecRetorno
    {
        get => ideRecRetornoField;
        set
        {
            ideRecRetornoField = value;
            RaisePropertyChanged(nameof(ideRecRetorno));
        }
    }

    [XmlElement()]
    public EventoTotalDadosProcessamento infoRecEv
    {
        get => infoRecEvField;
        set
        {
            infoRecEvField = value;
            RaisePropertyChanged(nameof(infoRecEv));
        }
    }

    ///// <summary>
    ///// Informacoes relativas a totalizadores pela natureza do rendimento e codigo de receita (apenas R-9015)
    ///// </summary>
    //[XmlElement()]
    //public TotalContribuinteR9015 infoCR_CNR
    //{
    //    get => infoCR_CNRField;
    //    set
    //    {
    //        infoCR_CNRField = value;
    //        RaisePropertyChanged(nameof(infoCR_CNR));
    //    }
    //}

    ///// <summary>
    ///// Informacoes relativas a totalizadores por codigo de receita (apenas R-9015)
    ///// </summary>
    //[XmlElement()]
    //public TotalContribuinteR9015 infoTotalCR
    //{
    //    get => infoTotalCRField;
    //    set
    //    {
    //        infoTotalCRField = value;
    //        RaisePropertyChanged(nameof(infoTotalCR));
    //    }
    //}


    [XmlAttribute(DataType = "ID")]
    public string id
    {
        get => idField;
        set
        {
            idField = value;
            RaisePropertyChanged(nameof(id));
        }
    }
}


/// <summary>
/// Identificação de Período (perApur). Utilizado nos retornos
/// </summary>
/// <exclude/>
public partial class IdentificacaoEventoRetorno : EfdReinfBindableObject
{
    private string perApurField;

    [XmlElement(DataType = "gYearMonth")]
    public string perApur
    {
        get => perApurField;
        set
        {
            perApurField = value;
            RaisePropertyChanged(nameof(perApur));
        }
    }
}


/// <summary>
/// Status de retorno dos eventos enviados
/// </summary>
public partial class EventoTotalReciboRetorno : EfdReinfBindableObject
{
    private EventoTotalStatusRetorno ideStatusField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public EventoTotalStatusRetorno ideStatus
    {
        get => ideStatusField;
        set
        {
            ideStatusField = value;
            RaisePropertyChanged(nameof(ideStatus));
        }
    }
}


/// <summary>
/// Detalhamento do status de retorno dos eventos enviados
/// </summary>
public partial class EventoTotalStatusRetorno : EfdReinfBindableObject
{
    private string cdRetornoField;
    private string descRetornoField;
    private EventoTotalRegistroOcorrencias[] regOcorrsField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string cdRetorno
    {
        get => cdRetornoField;
        set
        {
            cdRetornoField = value;
            RaisePropertyChanged(nameof(cdRetorno));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string descRetorno
    {
        get => descRetornoField;
        set
        {
            descRetornoField = value;
            RaisePropertyChanged(nameof(descRetorno));
        }
    }

    /// <remarks/>
    [XmlElement("regOcorrs", Order = 2)]
    public EventoTotalRegistroOcorrencias[] regOcorrs
    {
        get => regOcorrsField;
        set
        {
            regOcorrsField = value;
            RaisePropertyChanged(nameof(regOcorrs));
        }
    }
}


public partial class EventoTotalRegistroOcorrencias : EfdReinfBindableObject
{
    private string tpOcorrField;
    private string localErroAvisoField;
    private string codRespField;
    private string dscRespField;

    /// <remarks/>
    [XmlElement(DataType = "integer", Order = 0)]
    public string tpOcorr
    {
        get => tpOcorrField;
        set
        {
            tpOcorrField = value;
            RaisePropertyChanged(nameof(tpOcorr));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string localErroAviso
    {
        get => localErroAvisoField;
        set
        {
            localErroAvisoField = value;
            RaisePropertyChanged(nameof(localErroAviso));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string codResp
    {
        get => codRespField;
        set
        {
            codRespField = value;
            RaisePropertyChanged(nameof(codResp));
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string dscResp
    {
        get => dscRespField;
        set
        {
            dscRespField = value;
            RaisePropertyChanged(nameof(dscResp));
        }
    }
}


public partial class EventoTotalDadosProcessamento : EfdReinfBindableObject
{
    private string nrRecArqBaseField;
    private string nrProtEntrField;
    private string nrProtLoteField;
    private DateTimeOffset dhRecepcaoField;
    private DateTimeOffset dhProcessField;
    private string tpEvField;
    private string idEvField;
    private string hashField;
    private IndicadorFechamentoReabertura? fechRettField;

    /// <summary>
    /// Recibo do arquivo de origem. Adicionado na versão 2.01.02
    /// </summary>
    public string nrRecArqBase
    {
        get => nrRecArqBaseField;
        set
        {
            nrRecArqBaseField = value;
            RaisePropertyChanged(nameof(nrRecArqBase));
        }
    }

    /// <summary>
    /// Numero do protocolo de entrega do lote (retorno da série R-2000)
    /// </summary>
    public string nrProtEntr
    {
        get => nrProtEntrField;
        set
        {
            nrProtEntrField = value;
            RaisePropertyChanged(nameof(nrProtEntr));
        }
    }

    /// <summary>
    /// Numero do protocolo de entrega do lote (retorno da série R-4000)
    /// </summary>
    public string nrProtLote
    {
        get => nrProtLoteField;
        set
        {
            nrProtLoteField = value;
            RaisePropertyChanged(nameof(nrProtLote));
        }
    }

    /// <summary>
    /// Data e hora da recepcao do evento
    /// </summary>
    public DateTimeOffset dhRecepcao
    {
        get => dhRecepcaoField;
        set
        {
            dhRecepcaoField = value;
            RaisePropertyChanged(nameof(dhRecepcao));
        }
    }

    /// <summary>
    /// Data e hora do processamento
    /// </summary>
    public DateTimeOffset dhProcess
    {
        get => dhProcessField;
        set
        {
            dhProcessField = value;
            RaisePropertyChanged(nameof(dhProcess));
        }
    }

    /// <summary>
    /// Tipo do evento
    /// </summary>
    public string tpEv
    {
        get => tpEvField;
        set
        {
            tpEvField = value;
            RaisePropertyChanged(nameof(tpEv));
        }
    }

    /// <summary>
    /// ID do Evento
    /// </summary>
    public string idEv
    {
        get => idEvField;
        set
        {
            idEvField = value;
            RaisePropertyChanged(nameof(idEv));
        }
    }

    public string hash
    {
        get => hashField;
        set
        {
            hashField = value;
            RaisePropertyChanged(nameof(hash));
        }
    }

    public IndicadorFechamentoReabertura? fechRet
    {
        get => fechRettField;
        set
        {
            fechRettField = value;
            RaisePropertyChanged(nameof(fechRet));
        }
    }

    public bool ShouldSerializefechRet() =>
        fechRet.HasValue;
}