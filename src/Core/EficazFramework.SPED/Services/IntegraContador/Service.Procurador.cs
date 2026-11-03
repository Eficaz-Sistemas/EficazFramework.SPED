using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;
using EficazFramework.SPED.Utilities;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;

namespace EficazFramework.SPED.Services.IntegraContador;

#nullable enable

public partial class IntegraContadorService
{
    /// <summary>
    /// Assina o termo de autorização (XMLDSig RSA-SHA256, enveloped + C14N, URI vazia) e o retorna em Base64.
    /// </summary>
    /// <param name="termo">Termo de autorização.</param>
    /// <param name="certificadoAutor">Certificado do autor do pedido de dados (procurador); quando nulo, usa o certificado do serviço.</param>
    /// <exception cref="ArgumentNullException">Termo ou certificado não informados.</exception>
    public virtual string AssinarTermo(TermoAutorizacao termo, IcpBrasilX509Certificate2? certificadoAutor = null)
    {
        if (termo is null)
            throw new ArgumentNullException(nameof(termo), "O termo de autorização não foi informado.");

        var certificado = certificadoAutor;
        if (certificado is null)
        {
            if (!ValidaCertificado())
                throw new ArgumentNullException(nameof(certificadoAutor), "Nenhum certificado digital foi fornecido para assinatura do termo de autorização.");
            certificado = Certificado;
        }

        var xml = termo.GerarXml();
        certificado.SignXml(xml, TermoAutorizacao.ElementoRaiz, TermoAutorizacao.ElementoRaiz, signAsSHA256: true, emptyURI: true);
        return Convert.ToBase64String(Encoding.UTF8.GetBytes(xml.OuterXml));
    }

    /// <summary>
    /// Envia o termo de autorização assinado (AUTENTICAPROCURADOR / ENVIOXMLASSINADO81) e obtém o token do procurador,
    /// que passa a ser o <see cref="TokenProcurador"/> padrão do serviço.
    /// </summary>
    /// <remarks>
    /// Se o termo ainda estiver válido no cache do Serpro, a resposta é HTTP 304 sem corpo: o token é lido do cabeçalho
    /// ETag e a expiração do cabeçalho Expires.
    /// </remarks>
    /// <param name="termoAssinadoBase64">Termo assinado, em Base64 (ver <see cref="AssinarTermo"/>).</param>
    /// <param name="autorPedidoDados">Autor do pedido de dados (procurador) que assinou o termo; passa a ser o <see cref="AutorPedidoDados"/> padrão.</param>
    /// <param name="contribuinte">Contribuinte da requisição (padrão: o próprio autor do pedido de dados).</param>
    /// <param name="ambiente">Ambiente (padrão: <see cref="Ambiente"/>).</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual async Task<RespostaIntegraContador<RetornoAutenticaProcurador>> AutenticarProcuradorAsync(
        string termoAssinadoBase64,
        Identificacao autorPedidoDados,
        Identificacao? contribuinte = null,
        Ambiente? ambiente = null,
        CancellationToken ct = default)
    {
        if (string.IsNullOrWhiteSpace(termoAssinadoBase64))
            throw new ArgumentNullException(nameof(termoAssinadoBase64), "O termo de autorização assinado não foi informado.");

        if (autorPedidoDados is null)
            throw new ArgumentNullException(nameof(autorPedidoDados), "O autor do pedido de dados não foi informado.");

        var resposta = await ExecutarAsync<EnvioXmlAssinado, RetornoAutenticaProcurador>(
            Catalogo.AutenticaProcurador.EnviarXmlAssinado,
            contribuinte ?? autorPedidoDados,
            new EnvioXmlAssinado(termoAssinadoBase64),
            new OpcoesRequisicao(ambiente, autorPedidoDados),
            ct);

        if (resposta.StatusCode == (int)HttpStatusCode.NotModified && resposta.Retorno?.Token is null)
        {
            var token = resposta.ETag is null ? null : Regex.Match(resposta.ETag, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");
            if (token is { Success: true })
                resposta.Retorno = new RetornoAutenticaProcurador { Token = token.Value, DataHoraExpiracao = resposta.Expires?.LocalDateTime };
        }

        if (resposta.Retorno?.Token is { Length: > 0 } tokenProcurador)
        {
            TokenProcurador = tokenProcurador;
            AutorPedidoDados = autorPedidoDados;
        }
        return resposta;
    }

    /// <summary>
    /// Gera e assina o termo de autorização e o envia (AUTENTICAPROCURADOR), obtendo o token do procurador.
    /// </summary>
    /// <param name="termo">Termo de autorização.</param>
    /// <param name="certificadoAutor">Certificado do autor do pedido de dados (procurador); quando nulo, usa o certificado do serviço.</param>
    /// <param name="ambiente">Ambiente (padrão: <see cref="Ambiente"/>).</param>
    /// <param name="ct">Token de cancelamento.</param>
    public virtual Task<RespostaIntegraContador<RetornoAutenticaProcurador>> AutenticarProcuradorAsync(
        TermoAutorizacao termo,
        IcpBrasilX509Certificate2? certificadoAutor = null,
        Ambiente? ambiente = null,
        CancellationToken ct = default)
    {
        var assinado = AssinarTermo(termo, certificadoAutor);
        return AutenticarProcuradorAsync(assinado, new Identificacao(termo.NumeroAutor, termo.TipoAutor), null, ambiente, ct);
    }
}
