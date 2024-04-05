using System.IO;

namespace EficazFramework.SPED.Schemas.eSocial;

/// <exclude/>
public abstract class ESocialBindableObject : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    protected void RaisePropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}

/// <summary>
/// Abstração padrão para implementação em todos os eventos da escrituração.
/// </summary>
[XmlRoot("eSocial")]
public abstract class Evento : ESocialBindableObject, IXmlSignableDocument
{
    internal const string root = "eSocial";

    /// <summary>
    /// <see cref="EficazFramework.SPED.Schemas.EFD_Reinf.Versao"/> do schema para leitura / escrita
    /// </summary>
    [XmlIgnore]
    public Versao Versao { get; set; } = Versao.v_S_01_02_00;

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