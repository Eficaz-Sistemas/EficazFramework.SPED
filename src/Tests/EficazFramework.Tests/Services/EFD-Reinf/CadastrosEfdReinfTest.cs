using System.Collections.Generic;

namespace EficazFramework.SPED.Services.EFD_Reinf;

public abstract class CadastrosEfdReinfTest<T> : Tests.BaseTest where T : Schemas.EFD_Reinf.Evento
{
    internal string CnpjCpf { get; set; } = "34785515000166";
    internal Schemas.EFD_Reinf.IdentificacaoContribuinte Contribuinte { get; set; } = new()
    {
        nrInsc = "",
        tpInsc = Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ
    };

    [SetUp]
    public void OverrideParameters()
    {
        string _cnpj = Configuration["SSL:EFDREINF:CertificateCnpjCpf"];
        if (!string.IsNullOrEmpty(_cnpj))
        {
            CnpjCpf = _cnpj;
            Contribuinte.nrInsc = _cnpj;
        }
    }


    internal bool LogToConsole { get; set; } = true;

    /// <summary>
    /// Executa o teste de um único evento cadastral
    /// </summary>
    /// <param name="versao"></param>
    /// <returns></returns>
    internal async Task<RetornoLoteEventos> TestaEvento(Schemas.EFD_Reinf.Versao versao)
    {
        // criação da instância e alimentação dos campos
        T instancia = CriaInstanciaEvento(versao);
        var retornoEnvio = await EnviaEvento(instancia);
        retornoEnvio.retornoLoteEventosAssincrono.status.cdResposta.Should().Be("1");
        var protocolo = retornoEnvio.retornoLoteEventosAssincrono.dadosRecepcaoLote.protocoloEnvio;

        // aguardar o processamento do lote
        await Task.Delay(1000);

        // consulta do protocolo
        var retornoConsulta = await ConsultaProtocolo(protocolo);
        while (retornoConsulta.retornoLoteEventosAssincrono.status.cdResposta == "1")
        {
            await Task.Delay(500);
            retornoConsulta = await ConsultaProtocolo(protocolo);
        }
        retornoConsulta.retornoLoteEventosAssincrono.status.cdResposta.Should().Be("2");
        retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.Should().NotBeNull();

        foreach (LoteEventoRetornoInfo evt in retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.evento)
            evt.retornoEventoInfo.evtTotal.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(new[] { "0", "2" });

        return retornoConsulta.retornoLoteEventosAssincrono;
    }


    /// <summary>
    /// Executa o teste de envio de um lote de eventos cadastrais
    /// </summary>
    /// <param name="versao"></param>
    /// <param name="tamanhoLote"></param>
    /// <returns></returns>
    internal async Task<RetornoLoteEventos> TestaLoteEvento(Schemas.EFD_Reinf.Versao versao, int tamanhoLote)
    {
        // criação da instância e alimentação dos campos
        IList<T> instancias = CriaLoteEvento(versao, tamanhoLote);
        var retornoEnvio = await EnviaLoteEvento((IList<Schemas.EFD_Reinf.Evento>)instancias);
        retornoEnvio.retornoLoteEventosAssincrono.status.cdResposta.Should().Be("1");
        var protocolo = retornoEnvio.retornoLoteEventosAssincrono.dadosRecepcaoLote.protocoloEnvio;

        // aguardar o processamento do lote
        await Task.Delay(150);

        // consulta do protocolo
        var retornoConsulta = await ConsultaProtocolo(protocolo);
        foreach (LoteEventoRetornoInfo evt in retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.evento)
            evt.retornoEventoInfo.evtTotal.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(new[] { "2" });

        return retornoConsulta.retornoLoteEventosAssincrono;
    }


    /// <summary>
    /// Cria a instância do Evento do Tipo T, pelo método <see cref="PreencheCampos(T)"/>
    /// </summary>
    private T CriaInstanciaEvento(Schemas.EFD_Reinf.Versao versao)
    {
        T instancia = Activator.CreateInstance<T>();
        instancia.Versao = versao;
        PreencheCampos(instancia);
        instancia.GeraEventoID();
        return instancia;
    }


    /// <summary>
    /// Cria um lote de instâncias do Evento do Tipo T, pelo método <see cref="PreencheCampos(T)"/>
    /// </summary>
    private IList<T> CriaLoteEvento(Schemas.EFD_Reinf.Versao versao, int tamanhoLote)
    {
        var result = new List<T>();
        for (int i = 0; i <= tamanhoLote; i++)
        {
            T instancia = Activator.CreateInstance<T>();
            instancia.Versao = versao;
            PreencheCampos(instancia, i);
            instancia.GeraEventoID();
        }
        return result;
    }


    /// <summary>
    /// Utilize este método para preencher os campos do <paramref name="evento"/> <br/><br/>
    /// </summary>
    /// <param name="evento"></param>
    public abstract void PreencheCampos(T evento, int index = 0);


    /// <summary>
    /// Executa a transmissão do evento para ambiente de produção.
    /// Será considerada a versão do evento para a versão do WebService.
    /// </summary>
    /// <param name="evento"></param>
    /// <returns></returns>
    public async Task<Response> EnviaEvento(Schemas.EFD_Reinf.Evento evento)
    {
        var _ws = new EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices
        {
            SelecionaCertificado = InstanciaCertificado
        };
        var r = await _ws.EnviaEventosAsync(new List<Schemas.EFD_Reinf.Evento>() { evento }, Contribuinte, Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais);
        r.Should().NotBeNull();
        return r;
    }


    /// <summary>
    /// Executa a transmissão do lote de eventos para ambiente de produção.
    /// Será considerada a versão do primeiro evento para a versão do WebService.
    /// </summary>
    /// <param name="eventos"></param>
    /// <returns></returns>
    public async Task<Response> EnviaLoteEvento(IList<Schemas.EFD_Reinf.Evento> eventos)
    {
        var _ws = new EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices
        {
            SelecionaCertificado = InstanciaCertificado
        };
        var r = await _ws.EnviaEventosAsync(eventos, Contribuinte, Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais);
        r.Should().NotBeNull();
        return r;
    }


    /// <summary>
    /// Realiza a pesquisa de protocolo dos eventos enviados, para teste do retorno
    /// </summary>
    /// <param name="protocolo"></param>
    /// <returns></returns>
    public async Task<Response> ConsultaProtocolo(string protocolo)
    {
        var _ws = new EficazFramework.SPED.Services.EFD_Reinf.EfdReinfServices
        {
            SelecionaCertificado = InstanciaCertificado
        };
        var r = await _ws.ConsultaLoteAsync(protocolo, Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais);
        r.Should().NotBeNull();
        return r;
    }


    /// <summary>
    /// Define o certificado digital a ser utilizado nas requests.
    /// </summary>
    /// <returns></returns>
    private Func<Utilities.IcpBrasilX509Certificate2> InstanciaCertificado => () =>
    {
        string path = Configuration["SSL:EFDREINF:CertificatePath"];
        if (!string.IsNullOrEmpty(path) && Path.Exists(path))
            return new Utilities.IcpBrasilX509Certificate2(path, Configuration["SSL:EFDREINF:CertificatePassword"]);

        return new Utilities.IcpBrasilX509Certificate2(Resources.Certificados.WayneEnterprisesInc, "1234");
    };
}

