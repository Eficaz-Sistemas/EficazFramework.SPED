using EficazFramework.SPED.Schemas.eSocial;

namespace EficazFramework.SPED.Services.eSocial;

public class BaseESocialTests : Tests.BaseTest
{
    [TearDown]
    public async Task TearDown()
    {
        // Sem empregador configurado o teste foi ignorado: não há o que limpar no ambiente do eSocial.
        if (CnpjCpfConfigurado is null)
            return;

        await LimpaDadosCadastraisInternalAsync();
    }

    /// <summary>CNPJ/CPF do empregador de testes (<c>SSL:ESOCIAL:CertificateCnpjCpf</c>); <see langword="null"/> se não configurado.</summary>
    private string CnpjCpfConfigurado
    {
        get
        {
            var valor = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"];
            return string.IsNullOrWhiteSpace(valor) || valor.Length < 8 ? null : valor;
        }
    }

    /// <summary>
    /// CNPJ/CPF do empregador de testes. Sem a configuração (User Secrets), o teste é ignorado em vez de falhar:
    /// os testes do eSocial são de integração e exigem certificado e empregador reais em produção restrita.
    /// </summary>
    internal string CnpjCpfEmpregador =>
        CnpjCpfConfigurado
        ?? throw new IgnoreException("Configure SSL:ESOCIAL:CertificateCnpjCpf, CertificatePath e CertificatePassword nos User Secrets do projeto de testes para executar os testes do eSocial.");

    /// <summary>Raiz do CNPJ (8 dígitos) do empregador de testes.</summary>
    internal string RaizCnpjEmpregador => CnpjCpfEmpregador[..8];

    internal EficazFramework.SPED.Services.eSocial.ESocialServices CreateClient()
    {
        var client = new ESocialServices
        {
            SelecionaCertificado = InstanciaCertificado
        };
        return client;
    }


    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    internal Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificado => () =>
    {
        string path = Configuration["SSL:ESOCIAL:CertificatePath"];
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:ESOCIAL:CertificatePassword"]);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };

    internal static TClient CreateClient<TClient>(params string[] args)
        where TClient : ISoapClient
    {
        ISoapClient client = TClient.Create(args);
        return (TClient)client;
    }

    /// <summary>
    /// Utilize este método em testes de eventos de Admissao, Apuracoes, etc, para gerar a carga inicial de S-1000 a S-1020
    /// Concluindo o teste, chame <see cref="LimpaDadosCadastraisInternalAsync"/> para assegurar que não sobrem dados residuais.
    /// </summary>
    /// <returns></returns>
    internal async Task EnviaDadosCadastraisInternalAsync()
    {
        var empregador = new EficazFramework.SPED.Schemas.eSocial.Empregador()
        {
            nrInsc = RaizCnpjEmpregador,
            tpInsc = Schemas.eSocial.PersonalidadeJuridica.CNPJ
        };
        var s1000 = new EficazFramework.SPED.Schemas.eSocial.S1000();
        EficazFramework.SPED.Schemas.eSocial.S1000Test.PreencheCamposInclusao(s1000, CnpjCpfEmpregador);

        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificado;
        var result = await client.EnviaEventosAsync(null, null, Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais);
        result.Should().NotBeNull();

    }


    /// <summary>
    /// Este método limpa a base de dados em homologação do e-Social.
    /// Deve ser chamado ao final de cada teste
    /// </summary>
    /// <returns></returns>
    internal async Task LimpaDadosCadastraisInternalAsync()
    {

        var empregador = new EficazFramework.SPED.Schemas.eSocial.Empregador()
        {
            nrInsc = RaizCnpjEmpregador,
            tpInsc = Schemas.eSocial.PersonalidadeJuridica.CNPJ
        };
        var s1000 = new EficazFramework.SPED.Schemas.eSocial.S1000()
        {
            evtInfoEmpregador = new S1000InfoEmpregador()
            {
                ideEvento = new IdentificacaoCadastro()
                {
                    tpAmb = Ambiente.ProducaoRestrita_DadosReais,
                    procEmi = EmissorEvento.AppEmpregador,
                    verProc = "2.2"
                },
                ideEmpregador = new()
                {
                    tpInsc = PersonalidadeJuridica.CNPJ,
                    nrInsc = RaizCnpjEmpregador
                },
                infoEmpregador = new S1000InfoEmpregadorAcao()
                {
                    Item = new S1000Inclusao()
                    {
                        idePeriodo = new IdePeriodo()
                        {
                            iniValid = $"{DateTime.Now.AddMonths(-1):yyyy-MM}"
                        },
                        infoCadastro = new S1000InfoCadastro()
                        {
                            classTrib = "00",
                        }
                    }
                }
            }
        };

        var client = CreateClient();
        client.SelecionaCertificado = InstanciaCertificado;
        var result = await client.EnviaEventosAsync([s1000], empregador, Schemas.eSocial.Ambiente.ProducaoRestrita_DadosReais);
        result.Should().NotBeNull();
        result.retornoEnvioLoteEventos.status.cdResposta.Should().Be(201);
    }

}
