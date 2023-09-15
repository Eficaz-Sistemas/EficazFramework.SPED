using System.Collections.Generic;

namespace EficazFramework.SPED.Services.EFD_Reinf;

public abstract class MovEfdReinfTest<T> : Tests.BaseTest where T : Schemas.EFD_Reinf.Evento
{
    internal string CnpjCpf { get; private set; } = "34785515000166";
    internal Schemas.EFD_Reinf.Versao _versao = Schemas.EFD_Reinf.Versao.v2_01_01;
    internal Schemas.EFD_Reinf.IdentificacaoContribuinte contribuinte = new()
    {
        nrInsc = "",
        tpInsc = Schemas.EFD_Reinf.PersonalidadeJuridica.CNPJ
    };
    internal bool GeraDadosCadastrais { get; set; } = true;
    internal bool ReciclaDadosCadastrais { get; set; } = true;
    internal string[] CodigosResultadoEsperado = { "0", "2" };

    [SetUp]
    public void OverrideParameters()
    {
        string _cnpj = Configuration["SSL:EFDREINF:CertificateCnpjCpf"];
        if (!string.IsNullOrEmpty(_cnpj))
        {
            CnpjCpf = _cnpj;
            contribuinte.nrInsc = _cnpj;
        }
    }


    internal async Task<Response> TestaEvento(Schemas.EFD_Reinf.Versao versao)
    {
        // criação da instância e alimentação dos campos
        T instancia = CriaInstanciaEvento(versao);

        // criação das informações cadastrais
        R1000Test cad = new() 
        {
            LogToConsole = false,
            CnpjCpf = CnpjCpf,
        };
        cad.Contribuinte.nrInsc = CnpjCpf;
        if (GeraDadosCadastrais)
            await cad.Envia01Inclusao(instancia.Versao);

        // envio do evento <T>
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

        // remoção dos dados cadastrais
        if (ReciclaDadosCadastrais)
            await cad.Envia04InclusaoRemocaoDados(instancia.Versao);

        // assert
        retornoConsulta.retornoLoteEventosAssincrono.status.cdResposta.Should().BeOneOf(CodigosResultadoEsperado);
        retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.Should().NotBeNull();

        foreach (LoteEventoRetornoInfo evt in retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.evento)
        {
            if (evt.retornoEventoFechamentoInfo != null)
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else if (evt.retornoEventoRetInfo != null)
                evt?.retornoEventoRetInfo.evtRet.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else if (evt.retornoEventoFechamentoRetInfo != null)
                evt?.retornoEventoFechamentoRetInfo.evtRetCons.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else
                evt?.retornoEventoInfo.evtTotal.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
        }
        return retornoConsulta;
    }

    internal async Task<Response> TestaLoteEvento(Schemas.EFD_Reinf.Versao versao, int tamanhoLote)
    {
        // criação da instância e alimentação dos campos
        IList<Schemas.EFD_Reinf.Evento> instancias = CriaLoteEvento(versao, tamanhoLote);

        // criação das informações cadastrais
        R1000Test cad = new()
        {
            LogToConsole = false,
            CnpjCpf = CnpjCpf
        };
        cad.Contribuinte.nrInsc = CnpjCpf;
        if (GeraDadosCadastrais)
            await cad.Envia01Inclusao(instancias.First().Versao);

        // envio do evento <T>
        var retornoEnvio = await EnviaLoteEvento(instancias);
        retornoEnvio.retornoLoteEventosAssincrono.status.cdResposta.Should().Be("1");
        var protocolo = retornoEnvio.retornoLoteEventosAssincrono.dadosRecepcaoLote.protocoloEnvio;

        // aguardar o processamento do lote
        await Task.Delay(150);

        // consulta do protocolo
        var retornoConsulta = await ConsultaProtocolo(protocolo);
        while (retornoConsulta.retornoLoteEventosAssincrono.status.cdResposta == "1")
        {
            await Task.Delay(150);
            retornoConsulta = await ConsultaProtocolo(protocolo);
        }

        // remoção dos dados cadastrais
        if (ReciclaDadosCadastrais)
            await cad.Envia04InclusaoRemocaoDados(instancias.First().Versao);

        // assert
        retornoConsulta.retornoLoteEventosAssincrono.status.cdResposta.Should().BeOneOf(CodigosResultadoEsperado);
        retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.Should().NotBeNull();

        foreach (LoteEventoRetornoInfo evt in retornoConsulta.retornoLoteEventosAssincrono.retornoEventos.evento)
        {
            if (evt.retornoEventoFechamentoInfo != null)
                evt?.retornoEventoFechamentoInfo.evtTotalContrib.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else if (evt.retornoEventoRetInfo != null)
                evt?.retornoEventoRetInfo.evtRet.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else if (evt.retornoEventoFechamentoRetInfo != null)
                evt?.retornoEventoFechamentoRetInfo.evtRetCons.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
            else
                evt?.retornoEventoInfo.evtTotal.ideRecRetorno.ideStatus.cdRetorno.Should().BeOneOf(CodigosResultadoEsperado);
        }
        return retornoConsulta;
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
    private IList<Schemas.EFD_Reinf.Evento> CriaLoteEvento(Schemas.EFD_Reinf.Versao versao, int tamanhoLote)
    {
        var result = new List<Schemas.EFD_Reinf.Evento>();
        for (int i = 0; i < tamanhoLote; i++)
        {
            T instancia = Activator.CreateInstance<T>();
            instancia.Versao = versao;
            PreencheCampos(instancia, i);
            instancia.GeraEventoID();
            result.Add(instancia);  
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
        var r = await _ws.EnviaEventosAsync(new List<Schemas.EFD_Reinf.Evento>() { evento }, contribuinte, Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais);
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
        var r = await _ws.EnviaEventosAsync(eventos, contribuinte, Schemas.EFD_Reinf.Ambiente.ProducaoRestrita_DadosReais);
        r.Should().NotBeNull();
        return r;
    }

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

