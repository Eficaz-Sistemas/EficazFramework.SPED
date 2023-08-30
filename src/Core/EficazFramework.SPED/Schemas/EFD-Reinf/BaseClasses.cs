using System.IO;

namespace EficazFramework.SPED.Schemas.EFD_Reinf;


/// <summary>
/// Abstração padrão para implementação em todos os eventos da escrituração.
/// </summary>
public abstract class Evento : EfdReinfBindableObject, IXmlSignableDocument
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
    /// Gera uma ID única para o Evento a ser enviado para o portal do SPED.
    /// Cada tipo de evento da EFD-Reinf possui sua forma de geração.
    /// </summary>
    public abstract void GeraEventoID();

    /// <summary>
    /// Retorna o CNPJ do Contribuinte titular do evento.
    /// </summary>
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
    public Evento Read(string xmlContent)
    {
        sSerializer = DefineSerializer();
        return Read(new MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlContent))) as Evento;
    }

    /// <summary>
    /// Efetua a leitura do evento em XML e retorna uma instância do Evento/> 
    /// </summary>
    public Evento Read(System.IO.Stream xmlStream)
    {
        sSerializer = DefineSerializer();
        var result = sSerializer.Deserialize(xmlStream);
        return result as Evento;
    }

}


/// <summary>
/// Identificação de Período (iniValid e fimValid)
/// </summary>
/// <exclude/>
public partial class IdentificacaoPeriodo : EfdReinfBindableObject
{
    private string iniValidField;
    private string fimValidField;

    /// <summary>
    /// AAAA-MM
    /// </summary>
    [XmlElement(Order = 0)]
    public string iniValid
    {
        get => iniValidField;
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
        get => fimValidField;
        set
        {
            fimValidField = value;
            RaisePropertyChanged("fimValid");
        }
    }
}


/// <summary>
/// Identificação do evento (Ambiente, Emissor e Versao)
/// </summary>
/// <exclude/>
public partial class IdentificacaoEvento : EfdReinfBindableObject
{
    private Ambiente tpAmbField;
    private EmissorEvento procEmiField;
    private string verProcField;

    [XmlElement(Order = 0)]
    public Ambiente tpAmb
    {
        get => tpAmbField;
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
        get => procEmiField;
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
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }
}


/// <summary>
/// Identificação do Evento (Indicador de Retificação, Número Recibo Retif., Período Apuração, Ambiente, Emissor e Versão) (R-2010, R-2020, R-2040 e R-2060)
/// </summary>
/// <exclude/>
public partial class IdentificacaoEventoPeriodico : EfdReinfBindableObject
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
        get => indRetifField;
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
        get => nrReciboField;
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
        get => perApurField;
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
        get => tpAmbField;
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
        get => procEmiField;
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
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }
}


/// <summary>
/// Identificação do Evento (Período Apuracao, Ambiente, Emissor e Versao)
/// </summary>
/// <exclude/>
public partial class IdentificacaoEventoFechamento : EfdReinfBindableObject
{
    private string perApurField;
    private Ambiente tpAmbField = Ambiente.Producao;
    private EmissorEvento procEmiField = EmissorEvento.AppContribuinte;
    private string verProcField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string perApur
    {
        get => perApurField;
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
        get => tpAmbField;
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
        get => procEmiField;
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
        get => verProcField;
        set
        {
            verProcField = value;
            RaisePropertyChanged("verProc");
        }
    }
}


/// <summary>
/// Identificação do contribuinte
/// </summary>
/// <exclude/>
public partial class IdentificacaoContribuinte : EfdReinfBindableObject
{
    private PersonalidadeJuridica tpInscField;
    private string nrInscField;
    private InformacaoComplementarContribuinte infoComplContriField = null;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public PersonalidadeJuridica tpInsc
    {
        get => tpInscField;
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
        get => nrInscField;
        set
        {
            nrInscField = value;
            RaisePropertyChanged("nrInsc");
        }
    }

    /// <remarks/>
    [XmlElement(Order = 2)]
    public InformacaoComplementarContribuinte infoComplContri
    {
        get => infoComplContriField;
        set
        {
            infoComplContriField = value;
            RaisePropertyChanged("infoComplContri");
        }
    }

    public string NumeroInscricaoTag() =>
        Extensions.String.ToFixedLenghtString(nrInsc, 14, Extensions.Alignment.Left, "0");
}


/// <exclude/>
public partial class InformacaoComplementarContribuinte : EfdReinfBindableObject
{
    private string natJurField;

    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(DataType = "integer")]
    public string natJur
    {
        get => natJurField;
        set
        {
            natJurField = value;
            RaisePropertyChanged("natJur");
        }
    }
}


/// <summary>
/// Identificação do Responsável pelo Envio dos Eventos
/// </summary>
/// <exclude/>
public partial class IdentificacaoResponsavel : EfdReinfBindableObject
{
    private string nmRespField;
    private string cpfRespField;
    private string telefoneField;
    private string emailField;

    /// <remarks/>
    [XmlElement(Order = 0)]
    public string nmResp
    {
        get => nmRespField;
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
        get => cpfRespField;
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
        get => telefoneField;
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
        get => emailField;
        set
        {
            emailField = value;
            RaisePropertyChanged("email");
        }
    }
}

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
/// - [Manual de Orientação ao Usuário, v2.1.2.1](http://sped.rfb.gov.br/arquivo/show/7261)<br/>
/// - [Manual de Orientação ao Desenvolvedor, v2.3](http://sped.rfb.gov.br/arquivo/show/7258)<br/>
/// - [Layout, v2.1.2](http://sped.rfb.gov.br/pasta/show/7184)<br/>
/// - [Schemas XSD, v.2.1.2](http://sped.rfb.gov.br/item/show/7196)<br/>
/// - [Perguntas e Respostas](http://sped.rfb.gov.br/pastaperguntas/show/1497)<br/>
/// ## Implementação<br/>
/// </summary>
internal class NamespaceDoc { }