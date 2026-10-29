# Integra Contador (SERPRO)

O **Integra Contador** é a API REST do SERPRO que expõe serviços da Receita Federal (Simples Nacional, MEI, DCTFWeb, Sicalc, Caixa Postal, Parcelamentos, etc.) para escritórios de contabilidade e empresas. O framework implementa o cliente `IntegraContadorService` (namespace `EficazFramework.SPED.Services.IntegraContador`) e os bodies de requisição/resposta (namespace `EficazFramework.SPED.Schemas.IntegraContador`) dos serviços **em produção** do [catálogo oficial](https://apicenter.estaleiro.serpro.gov.br/documentacao/api-integra-contador/pt/catalogo_de_servicos/).

---

## 🔑 Pré-requisitos

1. Contratar o produto **Integra Contador** na Loja Serpro e obter, na área do cliente, a **Consumer Key** e o **Consumer Secret**.
2. Certificado digital **e-CNPJ** ICP-Brasil do contratante (o mesmo usado na contratação). Ele é usado no mTLS de todas as chamadas.
3. Para atuar em nome de clientes (procurador), o contribuinte deve ter outorgado **procuração eletrônica no e-CAC** ao autor do pedido de dados.

---

## 🚀 Configurando o serviço

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Services.IntegraContador;
using EficazFramework.SPED.Utilities;

using var servico = new IntegraContadorService
{
    // certificado e-CNPJ do contratante (mTLS)
    SelecionaCertificado = () => new IcpBrasilX509Certificate2(@"C:\Certificados\contratante.pfx", "senha"),
    ConsumerKey = "<consumer key>",
    ConsumerSecret = "<consumer secret>",
    Contratante = Identificacao.Cnpj("11222333000181")
};
```

> [!NOTE]
> A autenticação na Loja Serpro (`POST /authenticate`, `client_credentials`) é feita automaticamente na primeira requisição. Os tokens (`access_token` e `jwt_token`) ficam em memória (`servico.Token`) e são renovados antes de expirar ou ao receber HTTP 401. Use **uma instância por contratante** e descarte-a ao terminar.

### Ambiente de demonstração (Trial)
```csharp
servico.Ambiente = Ambiente.Trial; // token fixo, sem autenticação; usar os dados fictícios dos cenários de teste
```

---

## 📡 Chamando os serviços

Cada serviço em produção tem um método tipado, nomeado com o prefixo do sistema (`Pgdasd…`, `Pgmei…`, `Ccmei…`, `DctfWeb…`, `Mit…`, `Sicalc…`, `PagtoWeb…`, `CaixaPostal…`, `Dte…`, `Sitfis…`, `Parcelamento…`, `EventosAtualizacao…`, `PnrContador…`, `Procuracoes…`, `EProcesso…`). Todos retornam `RespostaIntegraContador<T>`:

| Propriedade | Conteúdo |
|:--|:--|
| `StatusCode` / `Sucesso` | Status HTTP e indicador de sucesso (2xx). Erros HTTP **não** lançam exceção. |
| `Mensagens` | Mensagens de retorno (`Codigo`, `Texto`). |
| `Retorno` | Conteúdo de `dados` desserializado no tipo do serviço. |
| `Dados` | Conteúdo bruto de `dados` (JSON ou Base64). |
| `ResponseId`, `ETag`, `Expires` | Identificador da resposta e cabeçalhos relevantes (204/304). |

```csharp
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

var contribuinte = Identificacao.Cnpj("00000000000100");
var resposta = await servico.PgdasdGerarDasAsync(contribuinte, new GerarDas { PeriodoApuracao = "202501" });

if (resposta.Sucesso)
{
    var das = resposta.Retorno![0];
    File.WriteAllBytes(@"C:\DAS\das.pdf", Convert.FromBase64String(das.Pdf!));
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

### Chamada genérica
Qualquer serviço do catálogo (`Catalogo`) pode ser chamado diretamente, tipado ou não:

```csharp
// tipado: dados serializados e retorno desserializado
var tipada = await servico.ExecutarAsync<object, JsonElement>(Catalogo.Pgdasd.ConsultarExtratoDas, contribuinte, new { numeroDas = "07202501234567890" });

// não tipado: dados já em JSON, retorno bruto em resposta.Dados
var bruta = await servico.ExecutarAsync(Catalogo.Dte.ConsultarSituacao, contribuinte, dadosJson: null);
```

### Opções por requisição
```csharp
var opcoes = new OpcoesRequisicao(
    Ambiente: Ambiente.Producao,
    AutorPedidoDados: Identificacao.Cnpj("99888777000166"), // padrão: servico.AutorPedidoDados ou o contratante
    TokenProcurador: "<token>",                              // padrão: servico.TokenProcurador
    RequestTag: "CLIENTE-001");                             // X-Request-Tag (até 32 caracteres)
```

---

## 🧾 Procurador (AUTENTICAPROCURADOR)

Quando o **autor do pedido de dados** (ex.: o escritório de contabilidade com procuração do cliente) é diferente do contratante, ele precisa assinar um **Termo de Autorização** permitindo que o contratante faça as requisições em seu nome. O token obtido vale até o fim do dia seguinte e passa a ser enviado automaticamente no cabeçalho `autenticar_procurador_token`.

```csharp
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;

var termo = new TermoAutorizacao
{
    CnpjContratante = "11222333000181",
    NomeContratante = "EMPRESA CONTRATANTE LTDA",
    NumeroAutor = "99888777000166",
    NomeAutor = "ESCRITORIO CONTABIL LTDA",
    TipoAutor = TipoIdentificacao.CNPJ,
    Vigencia = DateTime.Today.AddYears(1)
};

// assina com o certificado do autor (e-CPF ou e-CNPJ) e envia; o token fica em servico.TokenProcurador
var certificadoAutor = new IcpBrasilX509Certificate2(@"C:\Certificados\escritorio.pfx", "senha");
var autenticacao = await servico.AutenticarProcuradorAsync(termo, certificadoAutor);
Console.WriteLine($"Token válido até {autenticacao.Retorno?.DataHoraExpiracao}");
```

> [!TIP]
> Se o termo ainda estiver válido no cache do SERPRO, a resposta é **HTTP 304** e o token é lido do cabeçalho `ETag`. Guarde o token e reenvie o termo apenas após a expiração.

---

## 🗂️ Serviços disponíveis

Cada sistema tem uma página com exemplos preenchidos de chamada, os dados enviados e o retorno (fictício):

| Solução | Sistema | Descrição | Exemplos |
|:--|:--|:--|:--:|
| Integra-SN | PGDASD | DAS e declaração mensal do Simples Nacional | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Pgdasd.md) |
| Integra-SN | REGIMEAPURACAO | Opção pelo regime de caixa / competência | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/RegimeApuracao.md) |
| Integra-SN | DEFIS | Declaração de Informações Socioeconômicas e Fiscais | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Defis.md) |
| Integra-MEI | PGMEI | DAS do MEI, benefícios e dívida ativa | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Pgmei.md) |
| Integra-MEI | CCMEI | Certificado da Condição de MEI | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Ccmei.md) |
| Integra-DCTFWeb | DCTFWEB | Guias, recibos, declaração e transmissão da DCTFWeb | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/DctfWeb.md) |
| Integra-DCTFWeb | MIT | Módulo de Inclusão de Tributos | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Mit.md) |
| Integra-Procurações | PROCURACOES | Procurações eletrônicas | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Procuracoes.md) |
| Integra-Sicalc | SICALC | Consolidação e emissão de DARF | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Sicalc.md) |
| Integra-CaixaPostal | CAIXAPOSTAL | Mensagens da Caixa Postal do e-CAC | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/CaixaPostal.md) |
| Integra-CaixaPostal | DTE | Domicílio Tributário Eletrônico | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Dte.md) |
| Integra-Pagamento | PAGTOWEB | Pagamentos e comprovantes de arrecadação | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/PagtoWeb.md) |
| Integra-SITFIS | SITFIS | Relatório de Situação Fiscal | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Sitfis.md) |
| Integra-Parcelamento | PARCSN, PARCSN-ESP, PERTSN, RELPSN, PARCMEI, PARCMEI-ESP, PERTMEI, RELPMEI | Parcelamentos do Simples Nacional e do MEI | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/Parcelamento.md) |
| Integra-Contador-Gerenciador | AUTENTICAPROCURADOR | Termo de autorização e token do procurador | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/AutenticaProcurador.md) |
| Integra-Contador-Gerenciador | EVENTOSATUALIZACAO | Eventos de atualização de PF e PJ | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/EventosAtualizacao.md) |
| Integra-Redesim | PNRCONTADOR | Vínculos e renúncia de responsabilidade contábil | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/PnrContador.md) |
| Integra-e-Processo | EPROCESSO | Processos por interessado | [![Static Badge](https://img.shields.io/badge/consultar-green)](IntegraContador/EProcesso.md) |

Os identificadores (`idSistema`, `idServico`, `versaoSistema` e endpoint) de cada serviço estão na classe estática `Catalogo`.
