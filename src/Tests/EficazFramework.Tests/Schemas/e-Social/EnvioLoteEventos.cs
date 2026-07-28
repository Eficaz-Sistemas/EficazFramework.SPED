using EficazFramework.SPED.Services.eSocial;
using System.Xml.Linq;

namespace EficazFramework.SPED.Schemas.eSocial;

public class EnvioLoteEventosTest
{
    [Test]
    public void ValidaSerializacaoEDesserializacaoRequest()
    {
        var request = new Request
        {
            Versao = VersaoRest.v1_1_1,
            envioLoteEventos = new EficazFramework.SPED.Services.eSocial.EnvioLoteEventos
            {
                grupo = 1,
                ideEmpregador = new Empregador
                {
                    tpInsc = PersonalidadeJuridica.CNPJ,
                    nrInsc = "34785515000166"
                },
                ideTransmissor = new IdeTransmissor
                {
                    tpInsc = PersonalidadeJuridica.CNPJ,
                    nrInsc = "34785515000166"
                },
                eventos = new System.Collections.Generic.List<EficazFramework.SPED.Services.eSocial.TArquivoEsocial>()
            }
        };

        var s1000 = new S1000 { Versao = Versao.v_S_01_03_00 };
        S1000Test.PreencheCamposInclusao(s1000, "12345678000100");
        s1000.GeraEventoID();

        var xmlS1000 = s1000.Write();
        var xDocS1000 = XDocument.Parse(xmlS1000);

        request.envioLoteEventos.eventos.Add(new EficazFramework.SPED.Services.eSocial.TArquivoEsocial
        {
            Id = s1000.evtInfoEmpregador.Id,
            Any = xDocS1000.Root
        });

        // Testar a Serialização (Escrita)
        string xml = request.Write();

        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("eSocial");
        xml.Should().Contain("envioLoteEventos");
        xml.Should().Contain("ideEmpregador");
        xml.Should().Contain("ideTransmissor");
        xml.Should().Contain("eventos");
        xml.Should().Contain("evento");
        xml.Should().Contain(s1000.evtInfoEmpregador.Id);

        // Testar a Desserialização (Leitura)
        var parsedRequest = new Request().Read(xml);

        parsedRequest.Should().NotBeNull();
        parsedRequest.envioLoteEventos.Should().NotBeNull();
        parsedRequest.envioLoteEventos.grupo.Should().Be(1);
        
        parsedRequest.envioLoteEventos.ideEmpregador.Should().NotBeNull();
        parsedRequest.envioLoteEventos.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        parsedRequest.envioLoteEventos.ideEmpregador.nrInsc.Should().Be("34785515000166");

        parsedRequest.envioLoteEventos.ideTransmissor.Should().NotBeNull();
        parsedRequest.envioLoteEventos.ideTransmissor.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        parsedRequest.envioLoteEventos.ideTransmissor.nrInsc.Should().Be("34785515000166");

        parsedRequest.envioLoteEventos.eventos.Should().NotBeNull();
        parsedRequest.envioLoteEventos.eventos.Should().HaveCount(1);
        
        var evtStr = parsedRequest.envioLoteEventos.eventos[0];
        evtStr.Should().NotBeNull();
        evtStr.Id.Should().Be(s1000.evtInfoEmpregador.Id);
        evtStr.Any.Should().NotBeNull();
        evtStr.Any.Name.LocalName.Should().Be("eSocial");
    }

    [Test]
    public void ValidaSchemaXsd()
    {
        var request = new Request
        {
            Versao = VersaoRest.v1_1_1,
            envioLoteEventos = new EficazFramework.SPED.Services.eSocial.EnvioLoteEventos
            {
                grupo = 1,
                ideEmpregador = new Empregador
                {
                    tpInsc = PersonalidadeJuridica.CNPJ,
                    nrInsc = "34785515000166"
                },
                ideTransmissor = new IdeTransmissor
                {
                    tpInsc = PersonalidadeJuridica.CNPJ,
                    nrInsc = "34785515000166"
                },
                eventos = new System.Collections.Generic.List<EficazFramework.SPED.Services.eSocial.TArquivoEsocial>()
            }
        };

        var s1000 = new S1000 { Versao = Versao.v_S_01_03_00 };
        S1000Test.PreencheCamposInclusao(s1000, "12345678000100");
        s1000.GeraEventoID();
        
        // Assinar o S1000 (Opcional se o Schema do Lote não exigir validação strict do conteúdo <any>)
        // Mas para garantir o schema xsd completo, geramos o xml do evento.
        var xmlS1000 = s1000.Write();
        var xDocS1000 = XDocument.Parse(xmlS1000);

        request.envioLoteEventos.eventos.Add(new EficazFramework.SPED.Services.eSocial.TArquivoEsocial
        {
            Id = s1000.evtInfoEmpregador.Id,
            Any = xDocS1000.Root
        });

        string xml = request.Write();

        var doc = new System.Xml.XmlDocument();
        doc.LoadXml(xml);

        int errorCount = 0;
        var eventHandler = new System.Xml.Schema.ValidationEventHandler((sender, e) =>
        {
            errorCount++;
            Console.WriteLine($"[XSD {e.Severity}] {e.Message}");
        });

        string loteNamespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/v1_1_1";
        doc.Schemas.Add(loteNamespace, System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.Schemas.eSocial.EnvioLoteEventos_v1_1_1)));
        
        // Adicionando schema do evento e assinatura, pois o xs:any pode tentar validar o evento S-1000 se processContents="lax" ou "strict"
        string eventoNamespace = "http://www.esocial.gov.br/schema/evt/evtInfoEmpregador/v_S_01_03_00";
        doc.Schemas.Add(eventoNamespace, System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.Schemas.eSocial.S1000_v_S_01_03_00)));
        doc.Schemas.Add(eventoNamespace, System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.Schemas.eSocial.tipos)));
        doc.Schemas.Add("http://www.w3.org/2000/09/xmldsig#", System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.Schemas.XML.Sign)));

        doc.Validate(eventHandler);

        errorCount.Should().Be(0);
    }
}
