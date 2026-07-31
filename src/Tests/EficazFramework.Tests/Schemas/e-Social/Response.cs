using System;
using EficazFramework.SPED.Services.eSocial;
using NUnit.Framework;

namespace EficazFramework.SPED.Schemas.eSocial;

public class ResponseTest
{
    [Test]
    public void ValidaSerializacaoEDesserializacaoResponse()
    {
        var response = new Response
        {
            Versao = VersaoSoap.v1_1_0,
            retornoEnvioLoteEventos = new RetornoEnvioLoteEventos
            {
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
                status = new StatusEnvio
                {
                    cdResposta = 201,
                    descResposta = "Lote recebido com sucesso.",
                    ocorrencias = new System.Collections.Generic.List<DetalhamentoOcorrencia>
                    {
                        new DetalhamentoOcorrencia
                        {
                            codigo = 1,
                            descricao = "Lote recebido com sucesso.",
                            tipo = 1,
                            localizacao = "Lote"
                        }
                    }
                },
                dadosRecepcaoLote = new DadosRecepcao
                {
                    dhRecepcao = new DateTime(2023, 1, 1, 12, 0, 0),
                    versaoAplicativoRecepcao = "1.0.0",
                    protocoloEnvio = "1.2.202301.123456789"
                }
            }
        };

        // Testar a Serialização (Escrita)
        string xml = response.Write();

        xml.Should().NotBeNullOrEmpty();
        xml.Should().Contain("eSocial");
        xml.Should().Contain("retornoEnvioLoteEventos");
        xml.Should().Contain("ideEmpregador");
        xml.Should().Contain("ideTransmissor");
        xml.Should().Contain("status");
        xml.Should().Contain("dadosRecepcaoLote");
        xml.Should().Contain("34785515000166");
        xml.Should().Contain("201");
        xml.Should().Contain("Lote recebido com sucesso.");
        xml.Should().Contain("1.2.202301.123456789");

        // Testar a Desserialização (Leitura)
        var parsedResponse = new Response().Read(xml);

        parsedResponse.Should().NotBeNull();
        parsedResponse.retornoEnvioLoteEventos.Should().NotBeNull();
        
        parsedResponse.retornoEnvioLoteEventos.ideEmpregador.Should().NotBeNull();
        parsedResponse.retornoEnvioLoteEventos.ideEmpregador.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        parsedResponse.retornoEnvioLoteEventos.ideEmpregador.nrInsc.Should().Be("34785515000166");

        parsedResponse.retornoEnvioLoteEventos.ideTransmissor.Should().NotBeNull();
        parsedResponse.retornoEnvioLoteEventos.ideTransmissor.tpInsc.Should().Be(PersonalidadeJuridica.CNPJ);
        parsedResponse.retornoEnvioLoteEventos.ideTransmissor.nrInsc.Should().Be("34785515000166");

        parsedResponse.retornoEnvioLoteEventos.status.Should().NotBeNull();
        parsedResponse.retornoEnvioLoteEventos.status.cdResposta.Should().Be(201);
        parsedResponse.retornoEnvioLoteEventos.status.descResposta.Should().Be("Lote recebido com sucesso.");

        parsedResponse.retornoEnvioLoteEventos.dadosRecepcaoLote.Should().NotBeNull();
        parsedResponse.retornoEnvioLoteEventos.dadosRecepcaoLote.dhRecepcao.Should().Be(new DateTime(2023, 1, 1, 12, 0, 0));
        parsedResponse.retornoEnvioLoteEventos.dadosRecepcaoLote.versaoAplicativoRecepcao.Should().Be("1.0.0");
        parsedResponse.retornoEnvioLoteEventos.dadosRecepcaoLote.protocoloEnvio.Should().Be("1.2.202301.123456789");
    }

    [Test]
    public void ValidaSchemaXsd()
    {
        var response = new Response
        {
            Versao = VersaoSoap.v1_1_0,
            retornoEnvioLoteEventos = new RetornoEnvioLoteEventos
            {
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
                status = new StatusEnvio
                {
                    cdResposta = 201,
                    descResposta = "Lote recebido com sucesso.",
                    ocorrencias = new System.Collections.Generic.List<DetalhamentoOcorrencia>
                    {
                        new DetalhamentoOcorrencia
                        {
                            codigo = 1,
                            descricao = "Lote recebido com sucesso.",
                            tipo = 1,
                            localizacao = "Lote"
                        }
                    }
                },
                dadosRecepcaoLote = new DadosRecepcao
                {
                    dhRecepcao = new DateTime(2023, 1, 1, 12, 0, 0),
                    versaoAplicativoRecepcao = "1.0.0",
                    protocoloEnvio = "1.2.202301.123456789"
                }
            }
        };

        string xml = response.Write();

        var doc = new System.Xml.XmlDocument();
        doc.LoadXml(xml);

        int errorCount = 0;
        var eventHandler = new System.Xml.Schema.ValidationEventHandler((sender, e) =>
        {
            errorCount++;
            Console.WriteLine($"[XSD {e.Severity}] {e.Message}");
        });

        string loteNamespace = "http://www.esocial.gov.br/schema/lote/eventos/envio/retornoEnvio/v1_1_0";
        doc.Schemas.Add(loteNamespace, System.Xml.XmlReader.Create(new System.IO.StringReader(Resources.Schemas.eSocial.RetornoEnvioLoteEventos_v1_1_0)));

        doc.Validate(eventHandler);

        errorCount.Should().Be(0);
    }
}
