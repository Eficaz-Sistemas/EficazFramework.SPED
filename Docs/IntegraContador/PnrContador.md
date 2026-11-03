# PNRCONTADOR — Renúncia de responsabilidade contábil (Integra-Redesim)

Permite ao profissional ou à empresa contábil consultar as empresas com vínculo contabilista ativo, solicitar a renúncia a um vínculo (comunicada via REDESIM), acompanhar a solicitação, consultar as renúncias realizadas e emitir o comprovante.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `CONSVINCULOS261` | `/Consultar` | 1.0 | `PnrContadorConsultarVinculosAsync` | `PaginaVinculos` |
| `SOLICRENUNCIA262` | `/Declarar` | 1.0 | `PnrContadorSolicitarRenunciaAsync` | `RetornoSolicitacaoRenuncia` |
| `CONSRENUNCIA263` | `/Consultar` | 1.0 | `PnrContadorConsultarRenunciasAsync` | `PaginaRenuncias` |
| `COMPRENUNCIA264` | `/Emitir` | 1.0 | `PnrContadorEmitirComprovanteAsync` | `string` (PDF em Base64) |
| `SITSOLICRENUNCIA265` | `/Consultar` | 1.0 | `PnrContadorSituacaoSolicitacaoAsync` | `SituacaoSolicitacaoRenuncia` |

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço). Aqui o contribuinte é a **própria empresa contábil**, que também deve ser o autor do pedido de dados (diretamente ou via [AUTENTICAPROCURADOR](AutenticaProcurador.md)).

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraRedesim;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100"); // empresa contábil

// o autor do pedido de dados deve ser o contador (PF ou PJ)
var opcoes = new OpcoesRequisicao(AutorPedidoDados: contribuinte);
```

---

## 🔗 CONSVINCULOS261 — Consultar vínculos

Lista as empresas com vínculo contabilista ativo com o contador, com paginação por cursor (`lastCnpj`).

```csharp
var consulta = new ConsultaVinculos { Pagination = new PaginacaoVinculos { Size = 50 } }; // máx. 50; LastCnpj nulo na 1ª página
PaginaVinculos? pagina = null;
do
{
    var resposta = await servico.PnrContadorConsultarVinculosAsync(contribuinte, consulta, opcoes);
    if (!resposta.Sucesso)
        break;

    pagina = resposta.Retorno;
    foreach (var empresa in pagina?.Cnpjs ?? [])
        Console.WriteLine($"{empresa.Cnpj} ({empresa.TipoEstabelecimento}) {empresa.NomeMunicipio}/{empresa.Uf} [{empresa.CodigoMunicipio}] - situação {empresa.SituacaoCadastral?.Codigo} {empresa.SituacaoCadastral?.Descricao}");

    consulta.Pagination.LastCnpj = pagina?.LastCnpj; // cursor da próxima página
}
while (pagina?.Cnpjs?.Count == consulta.Pagination.Size);
```

**Dados enviados** (`pedidoDados.dados`) — primeira página e página seguinte:

```json
{"pagination":{"size":50}}
```

```json
{"pagination":{"size":50,"lastCnpj":"33333333000144"}}
```

**Retorno (fictício)**

```json
{
  "cnpjs": [
    {
      "cnpj": "22222222000172",
      "tipoEstabelecimento": "Matriz",
      "situacaoCadastral": { "codigo": "02", "descricao": "Ativa" },
      "uf": "SP",
      "codigoMunicipio": "7107",
      "nomeMunicipio": "SAO PAULO"
    },
    {
      "cnpj": "33333333000144",
      "tipoEstabelecimento": "Filial",
      "situacaoCadastral": { "codigo": "02", "descricao": null },
      "uf": "BA",
      "codigoMunicipio": "3849",
      "nomeMunicipio": null
    }
  ],
  "totalInThePage": 2,
  "totalInTheDatabase": 2,
  "lastCnpj": "33333333000144"
}
```

Mensagens: `[Sucesso-PNRCONTADOR]` — Requisição efetuada com sucesso.

---

## ✍️ SOLICRENUNCIA262 — Solicitar renúncia

```csharp
var resposta = await servico.PnrContadorSolicitarRenunciaAsync(contribuinte, new SolicitacaoRenuncia
{
    SolicitacaoRenunciaContador = new DadosSolicitacaoRenuncia
    {
        Cnpj = "22222222000172",                 // empresa renunciada
        CnpjEmpresaContabil = contribuinte.Numero, // renunciante PJ (ou CpfContador, se PF)
        CpfPreenchedor = "00000000191"           // responsável pelo e-CNPJ do autor
    },
    CienciaDeclaracoes = true                    // aceite das declarações exigidas
}, opcoes);

if (resposta.Sucesso)
    Console.WriteLine($"Solicitação {resposta.Retorno?.IdSolicitacao} registrada");
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"solicitacaoRenunciaContador":{"cnpj":"22222222000172","cnpjEmpresaContabil":"00000000000100","cpfPreenchedor":"00000000191"},"cienciaDeclaracoes":true}
```

**Retorno (fictício)**

```json
{
  "idSolicitacao": "PNRCONTADOR-20261028-af81730aeb29c9fdac15"
}
```

Mensagens: `[Sucesso-PNRCONTADOR]` — Requisição efetuada com sucesso.

> [!NOTE]
> O autor do pedido de dados deve ter o mesmo NI de `CpfContador` ou de `CnpjEmpresaContabil`. `CienciaDeclaracoes = true` representa o aceite às declarações (renúncia ao vínculo; comunicação ao Estado e ao Município via REDESIM; comunicação imediata à pessoa jurídica; irretratabilidade). Sem `Cnpj` ou `CpfPreenchedor`, o método lança `ArgumentNullException` sem enviar a requisição.

---

## ⏳ SITSOLICRENUNCIA265 — Situação da solicitação de renúncia

Recomenda-se aguardar **ao menos 30 segundos** após a solicitação.

```csharp
await Task.Delay(TimeSpan.FromSeconds(30));

var resposta = await servico.PnrContadorSituacaoSolicitacaoAsync(
    contribuinte,
    new ConsultaSituacaoRenuncia { IdSolicitacao = "PNRCONTADOR-20261028-af81730aeb29c9fdac15" },
    opcoes);

if (resposta.Sucesso && resposta.Retorno is { } situacao)
{
    Console.WriteLine(situacao.MensagemRetorno);
    if (situacao.Resultado == true && situacao.Renuncia is { } renuncia)
        Console.WriteLine($"Renúncia {renuncia.Id} efetivada em {renuncia.DataRenunciaUtc:u}");
}
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"idSolicitacao":"PNRCONTADOR-20261028-af81730aeb29c9fdac15"}
```

**Retorno (fictício)**

```json
{
  "resultado": true,
  "mensagemRetorno": "Sua renúncia à empresa 22222222000172 foi efetuada com sucesso!",
  "renuncia": {
    "id": 2558,
    "cnpjRenunciada": "22222222000172",
    "dataRenuncia": "1793206000000",
    "cnpjSolicitante": "00000000000100",
    "cnpjRenunciante": "00000000000100",
    "cpfSolicitante": null,
    "cpfRenunciante": null,
    "cpfLogado": "00000000191"
  }
}
```

Mensagens: `[Sucesso-PNRCONTADOR]` — Requisição efetuada com sucesso.

> [!NOTE]
> Enquanto a solicitação não é processada (ou se for negada), `Resultado` é `false` e `Renuncia` é nula — ex.: `{"resultado":false,"mensagemRetorno":"Em processamento","renuncia":null}`.

---

## 📚 CONSRENUNCIA263 — Consultar renúncias

Período (`AAAA-MM-DD`) e paginação são opcionais; sem filtro, chame `PnrContadorConsultarRenunciasAsync(contribuinte)` (envia `{}`).

```csharp
// atalho que formata as datas: ConsultaRenuncias.Periodo(inicio, fim, page, pageSize)
var filtro = ConsultaRenuncias.Periodo(new DateTime(2026, 10, 1), new DateTime(2026, 10, 31), page: 0, pageSize: 10);
// equivalente: new ConsultaRenuncias { DtInicio = "2026-10-01", DtFim = "2026-10-31", Page = 0, PageSize = 10 }

var resposta = await servico.PnrContadorConsultarRenunciasAsync(contribuinte, filtro, opcoes);

if (resposta.Sucesso && resposta.Retorno is { } pagina)
{
    Console.WriteLine($"Página {pagina.Number + 1}/{pagina.TotalPages} ({pagina.TotalElements} renúncias)");
    foreach (var renuncia in pagina.Content ?? [])
        Console.WriteLine($"{renuncia.Id}: {renuncia.CnpjRenunciada} em {renuncia.DataRenunciaUtc:u} por {renuncia.CnpjRenunciante ?? renuncia.CpfRenunciante}");
}
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"dtInicio":"2026-10-01","dtFim":"2026-10-31","page":0,"pageSize":10}
```

**Retorno (fictício)**

```json
{
  "content": [
    {
      "id": 2558,
      "cnpjRenunciada": "22222222000172",
      "dataRenuncia": "1793206000000",
      "cnpjSolicitante": "00000000000100",
      "cnpjRenunciante": "00000000000100",
      "cpfSolicitante": null,
      "cpfRenunciante": null,
      "cpfLogado": "00000000191"
    }
  ],
  "pageable": {
    "pageNumber": 0,
    "pageSize": 10,
    "sort": { "sorted": false, "empty": true, "unsorted": true },
    "offset": 0,
    "paged": true,
    "unpaged": false
  },
  "last": true,
  "totalElements": 1,
  "totalPages": 1,
  "size": 10,
  "number": 0,
  "sort": { "sorted": false, "empty": true, "unsorted": true },
  "numberOfElements": 1,
  "first": true,
  "empty": false
}
```

Mensagens: `[Sucesso-PNRCONTADOR]` — Requisição efetuada com sucesso.

> [!NOTE]
> `dataRenuncia` é um timestamp Unix em **milissegundos** (o exemplo oficial o traz como texto); `Renuncia.DataRenunciaUtc` faz a conversão (no exemplo, 2026-10-28 16:46:40 UTC). Pelo menos um dos campos solicitante (CPF/CNPJ) e um dos campos renunciante vêm sempre preenchidos.

---

## 📄 COMPRENUNCIA264 — Emitir comprovante de renúncia

```csharp
var resposta = await servico.PnrContadorEmitirComprovanteAsync(
    contribuinte,
    new EmissaoComprovanteRenuncia { IdRenuncia = 2558 }, // Renuncia.Id
    opcoes);

if (resposta.Sucesso && resposta.Retorno is { } pdf)
    File.WriteAllBytes(@"C:\PNR\renuncia-2558.pdf", Convert.FromBase64String(pdf));
```

**Dados enviados** (`pedidoDados.dados`)

```json
{"idRenuncia":2558}
```

**Retorno (fictício)** — `dados` é o próprio PDF em Base64 (não é JSON), entregue sem conversão em `Retorno`:

```json
"JVBERi0xLjQK..."
```

Mensagens: `[Sucesso-PNRCONTADOR]` — Requisição efetuada com sucesso.
