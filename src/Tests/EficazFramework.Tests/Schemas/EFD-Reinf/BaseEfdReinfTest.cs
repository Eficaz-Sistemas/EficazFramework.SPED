﻿using EficazFramework.SPED.Schemas.eSocial;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace EficazFramework.SPED.Schemas.EFD_Reinf.v2_01_01;

public abstract class BaseEfdReinfTest<T> : EficazFramework.SPED.Tests.BaseTest where T : IEfdReinfEvt
{
    internal void TestaEvento()
    {
        // criação da instância e alimentação dos campos
        T instancia = CriaInstanciaEvento();

        // serialização para xml (escrita)
        XmlDocument doc = EscreveEventoXml(instancia);

        // validação do XML pelo schema
        ValidaSchemaXsd(doc, "", "", "");

        // deserialização para nova instância (leitura de xml)
        T novaInstancia = Activator.CreateInstance<T>();
        novaInstancia.Deserialize(doc.OuterXml);    
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
    /// Utilize este método para preencher os campos do <paramref name="evento"/>
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
        string xmlString = evento.Serialize(); // ou .ToString();
        XmlDocument doc = new();
        doc.LoadXml(xmlString);
        return doc;
    }

    /// <summary>
    /// Informa ao validador do evento qual tag do XmlDocument que deve 
    /// ser assinada pelo Certificado Digital.
    /// </summary>
    public abstract string SignatureTag { get; }

    /// <summary>
    /// Informa ao validador o schema XSD ao qual o XmlDocument deve ser validado.
    /// Internamente, o validador irá criar uma instância de XmlSchemaSet utilizando
    /// o método XmlReader.Create(). <br/><br/>
    /// Esta propriedade deve passar o conteúdo do XSD em string. Considere armazenar
    /// o conteúdo deste schema em arquivo de Rescurso.
    /// </summary>
    public abstract string ValidationSchema { get; }

    /// <summary>
    /// Informa ao validador qual deve ser o Namespace principal (xmlns) em que o XmlDocument
    /// deve ser validado.
    /// </summary>
    public abstract string ValidationSchemaNamespace { get; }

    private int _errorCount = 0;
    private void ValidaSchemaXsd(XmlDocument doc)
    {
        _errorCount = 0;
        XmlReaderSettings settings = new()
        {
            ValidationType = ValidationType.Schema
        };
        settings.Schemas.Add(ValidationSchemaNamespace, XmlReader.Create(new StringReader(ValidationSchema)));
        settings.Schemas.Add("http://www.w3.org/2000/09/xmldsig#", XmlReader.Create(new StringReader(Resources.Schemas.XML.Sign)));


        Utilities.IcpBrasil_X509Certificate2 cert = new Utilities.IcpBrasil_X509Certificate2($"{Environment.CurrentDirectory}\\Resources\\Certificados\\WayneEnterprisesInc.pfx", "hccdlb32");
        //cert.SignXml(document, "Reinf", ValidationTag, true, true);

        ValidationEventHandler eventHandler = new(ValidationEventHandler);
        doc.Validate(eventHandler);
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
