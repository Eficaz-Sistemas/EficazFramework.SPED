using EficazFramework.SPED.Schemas.eSocial;

namespace EficazFramework.SPED.Services.eSocial;

public class BaseESocialTests : Tests.BaseTest
{
    [TearDown]
    public async Task TearDown() =>
        await LimpaDadosCadastraisInternalAsync();

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
            nrInsc = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"],
            tpInsc = Schemas.eSocial.PersonalidadeJuridica.CNPJ
        };
        var s1000 = new EficazFramework.SPED.Schemas.eSocial.S1000();
        EficazFramework.SPED.Schemas.eSocial.S1000Test.PreencheCamposInclusao(s1000, Configuration["SSL:ESOCIAL:CertificateCnpjCpf"]);

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
            nrInsc = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"],
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
                    nrInsc = Configuration["SSL:ESOCIAL:CertificateCnpjCpf"]
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
        result.retornoEnvioLoteEventos.status.cdResposta.Should().Be(1012);
        result.retornoEnvioLoteEventos.status.descResposta.Should().Contain("removido com sucesso da base de dados da Producao Restrita do eSocial");
    }

}
