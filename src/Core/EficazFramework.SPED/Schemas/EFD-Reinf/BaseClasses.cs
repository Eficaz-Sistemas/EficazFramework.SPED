using System.IO;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;


#region IEfdReinfEvt Abstraction for API Usage

/// <summary>
/// Utilitário para geração do identificador único de evento, para sua transmissão.
/// </summary>
public static class ReinfTimeStampUtils
{
    public static Dictionary<string, int> TimestampDict { get; private set; } = new Dictionary<string, int>();

    /// <summary>
    /// Gera uma string única para ser utilizada como identificar de um evento da EFD-Reinf.
    /// </summary>
    /// <returns></returns>
    public static string GetTimeStampIDForEvent()
    {
        int ID = 1;
        string timeString = string.Format("{0:yyyyMMddHHmmss}", DateTime.Now);
        if (TimestampDict.ContainsKey(timeString))
        {
            ID = TimestampDict[timeString] + 1;
            TimestampDict[timeString] = ID;
        }
        else
        {
            TimestampDict.Add(timeString, 1);
        }

        return string.Format("{0}{1:00000}", timeString, ID);
    }
}


/// <summary>
/// Interface padrão para implementação em todos os eventos da escrituração.
/// </summary>
public abstract class IEfdReinfEvt : IXmlSignableDocument
{
    [XmlIgnore]
    public Versao Versao { get; set; } = Versao.v2_01_01;

    // Base Members
    private XmlSerializer sSerializer;

    /// <summary>
    /// Retorna uma nova instância de XmlSerializer(T) onde T representa a classe que está herdando <see cref="IEfdReinfEvt"/>
    /// </summary>
    public abstract XmlSerializer DefineSerializer();

    /// <summary>
    /// Gera uma ID única para o Evento a ser enviado para o portal do SPED.
    /// Cada tipo de evento da EFD-Reinf possui sua forma de geração.
    /// </summary>
    public abstract void GeraEventoID();

    /// <summary>
    /// Retorna o CNPJ do Contribuinte titular do evento.
    /// </summary>
    /// <returns></returns>
    public abstract string ContribuinteCNPJ();



    // IXmlSignableDocument Members

    /// <summary>
    /// Especifica qual Tag do XML do evento deve ser assinada por Certificado Digital
    /// </summary>
    public abstract string TagToSign { get; }

    /// <summary>
    /// Retorna a ID do evento, criada pelo método <see cref="GeraEventoID"/>
    /// </summary>
    public abstract string TagId { get; }

    /// <summary>
    /// Informa se a Uri de referência da Tag assinada deve ser vazia, ou se deve ser formada conforme especificações do Manual Técnico.
    /// </summary>
    public abstract bool EmptyURI { get; }

    /// <summary>
    /// Informa se o XML deve ser assinado utilizando criptografia SHA256.
    /// </summary>
    public abstract bool SignAsSHA256 { get; }



    // Implemented Members

    /// <summary>
    /// Substitui o método ToString() de object para retornar o resultado do método <see cref="Serialize"/>
    /// </summary>
    /// <returns></returns>
    public override string ToString() =>
        Serialize();

    /// <summary>
    /// Serializa o evento da EFD-Reinf para a representação em string do conteúdo do XML.
    /// </summary>
    /// <returns>string XML value</returns>
    public string Serialize()
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
    /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
    /// </summary>
    /// <returns></returns>
    public IEfdReinfEvt Deserialize(string xmlContent)
    {
        sSerializer = DefineSerializer();
        return Deserialize(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlContent))) as IEfdReinfEvt;
    }

    /// <summary>
    /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
    /// </summary>
    /// <returns></returns>
    public IEfdReinfEvt Deserialize(System.IO.Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as IEfdReinfEvt;
    }

}

#endregion

#region Generic

/// <summary>
/// Identificação de Período (iniValid e fimValid)
/// </summary>
/// <exclude />
public partial class ReinfEvtIdePeriodo : object, INotifyPropertyChanged
{
    // , [Namespace]:="http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/v1_05_01"
    private string iniValidField;
    private string fimValidField;

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(Order = 0)]
    public string iniValid
    {
        get
        {
            return iniValidField;
        }

        set
        {
            iniValidField = value;
            RaisePropertyChanged("iniValid");
        }
    }

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(Order = 1)]
    public string fimValid
    {
        get
        {
            return fimValidField;
        }

        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
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
/// Identificação do evento (Ambiente, Emissor e Versao)
/// </summary>
/// <exclude />
public partial class ReinfEvtIdeEvento : object, INotifyPropertyChanged
{
    // , [Namespace]:="http://www.reinf.esocial.gov.br/schemas/evtInfoContribuinte/v1_05_01"
    private Ambiente tpAmbField;
    private EmissorEvento procEmiField;
    private string verProcField;

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
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
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
/// Identificação do contribuinte
/// </summary>
/// <exclude />
public partial class ReinfEvtIdeContri : object, INotifyPropertyChanged
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private ReinfEvtRetIdeContriInfoComplContri infoComplContriField = null;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get
        {
            return tpInscField;
        }

        set
        {
            tpInscField = value;
            RaisePropertyChanged("tpInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrInsc
    {
        get
        {
            return nrInscField;
        }

        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public ReinfEvtRetIdeContriInfoComplContri infoComplContri
    {
        get
        {
            return infoComplContriField;
        }

        set
        {
            infoComplContriField = value;
            RaisePropertyChanged("infoComplContri");
        }
    }

    public string NumeroInscricaoTag()
    {
        return Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
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

/// <remarks/>
/// <exclude />
public partial class ReinfEvtRetIdeContriInfoComplContri : object, System.ComponentModel.INotifyPropertyChanged
{

    private string natJurField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string natJur
    {
        get
        {
            return this.natJurField;
        }
        set
        {
            this.natJurField = value;
            this.RaisePropertyChanged("natJur");
        }
    }

    public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

    protected void RaisePropertyChanged(string propertyName)
    {
        System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
        if ((propertyChanged != null))
        {
            propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

/// <summary>
/// Tabela 6 do Anexo IV: Relação de Serviços para registros R-2010 e R-2020s
/// </summary>
/// <exclude />
public class R2xxx_TabelaServicos : Dictionary<string, string>
{
    public R2xxx_TabelaServicos()
    {
        Add("--", "Não Aplicável");
        Add("100000001", "100000001 - Limpeza, conservação ou zeladoria");
        Add("100000002", "100000002 - Vigilância ou segurança");
        Add("100000003", "100000003 - Construção civil");
        Add("100000004", "100000004 - Serviços de natureza rural");
        Add("100000005", "100000005 - Digitação");
        Add("100000006", "100000006 - Preparação de dados para processamento");
        Add("100000007", "100000007 - Acabamento");
        Add("100000008", "100000008 - Embalagem");
        Add("100000009", "100000009 - Acondicionamento");
        Add("100000010", "100000010 - Cobrança");
        Add("100000011", "100000011 - Coleta ou reciclagem de lixo ou de resíduos");
        Add("100000012", "100000012 - Copa");
        Add("100000013", "100000013 - Hotelaria");
        Add("100000014", "100000014 - Corte ou ligação de serviços públicos");
        Add("100000015", "100000015 - Distribuição");
        Add("100000016", "100000016 - Treinamento e ensino");
        Add("100000017", "100000017 - Entrega de contas e de documentos");
        Add("100000018", "100000018 - Ligação de medidores");
        Add("100000019", "100000019 - Leitura de medidores");
        Add("100000020", "100000020 - Manutenção de instalações, de máquinas ou de equipamentos");
        Add("100000021", "100000021 - Montagem");
        Add("100000022", "100000022 - Operação de máquinas, de equipamentos e de veículos");
        Add("100000023", "100000023 - Operação de pedágio ou de terminal de transporte");
        Add("100000024", "100000024 - Operação de transporte de passageiros");
        Add("100000025", "100000025 - Portaria, recepção ou ascensorista");
        Add("100000026", "100000026 - Recepção, triagem ou movimentação de materiais");
        Add("100000027", "100000027 - Promoção de vendas ou de eventos");
        Add("100000028", "100000028 - Secretaria e expediente");
        Add("100000029", "100000029 - Saúde");
        Add("100000030", "100000030 - Telefonia ou telemarketing");
        Add("100000031", "100000031 - Trabalho temporário na forma da Lei nº 6.019, de janeiro de 1974");
    }
}

/// <summary>
/// Identificação do Evento (Indicador de Retificação, Número Recibo Retif., Período Apuração, Ambiente, Emissor e Versão) (R-2010, R-2020, R-2040 e R-2060)
/// </summary>
/// <exclude />
public partial class ReinfEvtIdeEvento_R20xx : object, INotifyPropertyChanged
{
    private IndicadorRetificacao indRetifField = IndicadorRetificacao.Original;
    private string nrReciboField;
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public IndicadorRetificacao indRetif
    {
        get
        {
            return indRetifField;
        }

        set
        {
            indRetifField = value;
            RaisePropertyChanged("indRetif");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string nrRecibo
    {
        get
        {
            return nrReciboField;
        }

        set
        {
            nrReciboField = value;
            RaisePropertyChanged("nrRecibo");
        }
    }

    /// <remarks/>
    [XmlElement(DataType = "gYearMonth", Order = 2)]
    public string perApur
    {
        get
        {
            return perApurField;
        }

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
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
    [XmlElement(Order = 4)]
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 5)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
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
/// Identificação do Evento (Período Apuracao, Ambiente, Emissor e Versao)
/// </summary>
/// <exclude />
public partial class ReinfEvtIdeEventoPeriodicoFechamento : object, INotifyPropertyChanged
{
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string perApur
    {
        get
        {
            return perApurField;
        }

        set
        {
            perApurField = value;
            RaisePropertyChanged("perApur");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
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
    [XmlElement(Order = 2)]
    public EmissorEvento procEmi
    {
        get
        {
            return procEmiField;
        }

        set
        {
            procEmiField = value;
            RaisePropertyChanged("procEmi");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string verProc
    {
        get
        {
            return verProcField;
        }

        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
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

/// <exclude />
public partial class ReinfEvtFechaEvPerIdeRespInf : object, INotifyPropertyChanged
{
    private string nmRespField;
    private string cpfRespField;
    private string telefoneField;
    private string emailField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nmResp
    {
        get
        {
            return nmRespField;
        }

        set
        {
            nmRespField = value;
            RaisePropertyChanged("nmResp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 1)]
    public string cpfResp
    {
        get
        {
            return cpfRespField;
        }

        set
        {
            cpfRespField = value;
            RaisePropertyChanged("cpfResp");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public string telefone
    {
        get
        {
            return telefoneField;
        }

        set
        {
            telefoneField = value;
            RaisePropertyChanged("telefone");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 3)]
    public string email
    {
        get
        {
            return emailField;
        }

        set
        {
            emailField = value;
            RaisePropertyChanged("email");
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

#endregion

/// <summary>
/// # Escrituração Fiscal Digital de Retenções e Outras Informações Fiscais<br/>
/// ## Publico Alvo<br/>
///  - Pessoas Físicas e Jurídicas;<br/>
///  - Ocorrência de valores de tributos ou contribuições previdenciárias retidos.<br/>
/// ## Guia<br/>
/// Obrigação acessória que deve ser enviada mensalmente (ou a cada competência Janeiro, havendo a persistência da situação 'Sem Movimento'), para compor os valores de tributos ou contribuições previdenciárias retidas (substituídas) na DCTF-Web, 
/// de forma permitir o cálculo mensal das obrigações do contribuinte por meio deste.
/// ## Objetivo<br/>
/// Tem por objeto a escrituração de rendimentos pagos e retenções de Imposto de Renda, Contribuição Social do contribuinte exceto aquelas relacionadas ao trabalho e informações sobre a receita bruta para a apuração das contribuições previdenciárias substituídas.<br/>
/// ## Links Úteis<br/>
/// - [Manual de Orientação ao Usuário, v2.1.1.1](http://sped.rfb.gov.br/arquivo/show/6084)<br/>
/// - [Manual de Orientação ao Desenvolvedor, v2.0](http://sped.rfb.gov.br/arquivo/show/6118)<br/>
/// - [Layout, v2.1.1](http://sped.rfb.gov.br/pasta/show/6041)<br/>
/// - [Schemas XSD, v.2.1.1](http://sped.rfb.gov.br/arquivo/show/6048)<br/>
/// - [Perguntas e Respostas](http://sped.rfb.gov.br/pastaperguntas/show/1497)<br/>
/// ## Implementação<br/>
/// </summary>
internal class NamespaceDoc { }