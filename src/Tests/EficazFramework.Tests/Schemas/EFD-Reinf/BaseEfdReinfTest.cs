namespace EficazFramework.SPED.Schemas.EFD_Reinf;

public abstract class BaseEfdReinfTest<T> : Tests.BaseTest where T : Evento
{
    internal const string _cnpj = "34785515000166";
    internal Versao _versao = Versao.v2_01_01;

    /// <summary>
    /// Informa o namespace principal (xmlns) para validação do documento XML
    /// </summary>
    public string ValidationSchemaNamespace { get; set; }

    /// <summary>
    /// Informa a ID do Recurso que contém o schema XSD para validação do documento XML.
    /// </summary>
    public string ValidationSchema { get; set; }

    /// <summary>
    /// Action executada quando uma nova instância de <see cref="T"/>
    /// é criada pela leitura do arquivo XML do evento que está sendo lido / testado.
    /// </summary>
    /// <returns></returns>
    public Action<T> InstanciaDesserializada { get; set; }

    internal void TestaEvento()
    {
        // criação da instância e alimentação dos campos
        T instancia = CriaInstanciaEvento();

        // serialização para xml (escrita)
        XmlDocument doc = EscreveEventoXml(instancia);

        // validação do XML pelo schema
        ValidaSchemaXsd(doc, instancia);

        // deserialização para nova instância (leitura de xml)
        T novaInstancia = Activator.CreateInstance<T>();
        InstanciaDesserializada?.Invoke(novaInstancia);
        novaInstancia = (T)novaInstancia.Read(doc.OuterXml);

        // comparação entre as duas instâncias
        ValidaInstanciasLeituraEscrita(instancia, novaInstancia);
    }

    /// <summary>
    /// Cria a instância do Evento do Tipo T, chama o método <see cref="PreencheCampos(T)"/>
    /// </summary>
    private T CriaInstanciaEvento()
    {
        T instancia = Activator.CreateInstance<T>();
        PreencheCampos(instancia);
        instancia.GeraEventoID();
        return instancia;
    }

    /// <summary>
    /// Utilize este método para preencher os campos do <paramref name="evento"/> <br/><br/>
    /// E preciso que a base do CNPJ seja igual ao do CNPJ do certificado digital e-CNPJ da Wayne Enterprises <br/><br/>
    /// CNPJ Informado no Certificado Digital de testes: 34785515000166
    /// </summary>
    /// <param name="evento"></param>
    public abstract void PreencheCampos(T evento);

    /// <summary>
    /// Efetua a Serialização (escrita) do evento para Xml
    /// </summary>
    /// <param name="evento"></param>
    /// <returns></returns>
    private XmlDocument EscreveEventoXml(T evento)
    {
        string xmlString = evento.Write(); // ou .ToString();
        Console.WriteLine(xmlString);
        XmlDocument doc = new();
        doc.LoadXml(xmlString);
        return doc;
    }


    private int _errorCount = 0;
    private void ValidaSchemaXsd(XmlDocument doc, T evento)
    {
        // zerando contador de erros
        _errorCount = 0;

        // assinando o documento XML com o certificado digital e-CNPJ de testes
        Utilities.IcpBrasilX509Certificate2 cert = new Utilities.IcpBrasilX509Certificate2($"{Environment.CurrentDirectory}\\Resources\\Certificados\\WayneEnterprisesInc.pfx", "1234");
        Utilities.XML.Sign.SignXml(doc, "Reinf", evento.TagToSign, cert, evento.SignAsSHA256, evento.EmptyURI);

        // adicionando os schemas para validação do documento XML
        ValidationEventHandler eventHandler = new(ValidationEventHandler);
        doc.Schemas.Add(ValidationSchemaNamespace, XmlReader.Create(new StringReader(ValidationSchema)));
        doc.Schemas.Add("http://www.w3.org/2000/09/xmldsig#", XmlReader.Create(new StringReader(Resources.Schemas.XML.Sign)));

        // executando a validação
        doc.Validate(eventHandler);
        _errorCount.Should().Be(0);
    }

    private void ValidationEventHandler(object sender, ValidationEventArgs e)
    {
        _errorCount += 1;
        switch (e.Severity)
        {
            case XmlSeverityType.Error:
                Console.WriteLine("Error: {0}", e.Message);
                break;
            case XmlSeverityType.Warning:
                Console.WriteLine("Warning {0}", e.Message);
                break;
        }
    }

    /// <summary>
    /// Utilize este método para comparar se o XML gerado a partir de <paramref name="instanciaPopulada"/>
    /// e escrito para <paramref name="instanciaXml"/> contém os mesmos valores nos campos
    /// </summary>
    /// <param name="instanciaPopulada">Instância criada no início do teste, que recebeu valores de
    /// <see cref="PreencheCampos(T)"/></param>
    /// <param name="instanciaXml">Instância resultante da leitura da string que contém o XML gerado
    /// a partir de <paramref name="instanciaPopulada"/></param>
    public abstract void ValidaInstanciasLeituraEscrita(T instanciaPopulada, T instanciaXml);

}