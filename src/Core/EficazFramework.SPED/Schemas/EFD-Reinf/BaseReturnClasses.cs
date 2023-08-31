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


