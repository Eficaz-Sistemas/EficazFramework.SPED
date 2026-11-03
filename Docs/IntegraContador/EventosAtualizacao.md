# EVENTOSATUALIZACAO — Eventos de Atualização

Monitora, para lotes de até 1000 contribuintes (PF ou PJ), a data da última atualização em DCTFWeb, Caixa Postal ou Pagamentos, permitindo consultar os demais serviços apenas quando algo mudou. O fluxo é assíncrono: **solicitar** (recebe um protocolo) → aguardar → **obter**. Os serviços usam o endpoint `/Monitorar`, que não é tarifado.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `SOLICEVENTOSPF131` | `/Monitorar` | 1.0 | `EventosSolicitarPFAsync` | `RetornoSolicitacaoEventos` |
| `SOLICEVENTOSPJ132` | `/Monitorar` | 1.0 | `EventosSolicitarPJAsync` | `RetornoSolicitacaoEventos` |
| `OBTEREVENTOSPF133` | `/Monitorar` | 1.0 | `EventosObterPFAsync` | `List<EventoAtualizacao>` |
| `OBTEREVENTOSPJ134` | `/Monitorar` | 1.0 | `EventosObterPJAsync` | `List<EventoAtualizacao>` |

Cada método tem duas sobrecargas: uma de conveniência (lista de NIs ou protocolo + código do evento) e outra com `Identificacao` + DTO (`SolicitacaoEventos` / `ObtencaoEventos`).

### Eventos monitoráveis (`CodigoEventoAtualizacao`)

| Constante | Código | Evento |
|:--|:--|:--|
| `CodigoEventoAtualizacao.DctfWeb` | `E0301` | DCTFWeb: recebimento de apuração ou transmissão de declaração |
| `CodigoEventoAtualizacao.CaixaPostal` | `E0601` | Caixa Postal: nova mensagem para o contribuinte |
| `CodigoEventoAtualizacao.Pagamento` | `E0701` | Pagamento: novo documento, alteração, cancelamento ou bloqueio |

---

## 🚀 Preparação

Os exemplos assumem o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço).

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.Gerenciador;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

Nestes serviços o contribuinte é um **lote**: `contribuinte.numero` leva os NIs separados por vírgula e `contribuinte.tipo` é `3` (`TipoIdentificacao.LotePF`) ou `4` (`TipoIdentificacao.LotePJ`). O helper estático `IntegraContadorService.LoteEventos` monta essa identificação: descarta itens vazios, remove espaços e valida de 1 a `IntegraContadorService.MaximoNisLoteEventos` (1000) NIs.

```csharp
var lote = IntegraContadorService.LoteEventos(
    [contribuinte.Numero, "11111111000191", "22222222000172"],
    TipoIdentificacao.LotePJ);
// lote.Numero == "00000000000100,11111111000191,22222222000172"; lote.Tipo == TipoIdentificacao.LotePJ
```

---

## 📨 SOLICEVENTOSPJ132 / SOLICEVENTOSPF131 — Solicitar eventos

```csharp
// sobrecarga de conveniência: lista de CNPJs + código do evento
var solicitacao = await servico.EventosSolicitarPJAsync(
    [contribuinte.Numero, "11111111000191", "22222222000172"],
    CodigoEventoAtualizacao.CaixaPostal);

// equivalente, com Identificacao + DTO
solicitacao = await servico.EventosSolicitarPJAsync(
    IntegraContadorService.LoteEventos([contribuinte.Numero, "11111111000191", "22222222000172"], TipoIdentificacao.LotePJ),
    new SolicitacaoEventos { Evento = CodigoEventoAtualizacao.CaixaPostal });

if (solicitacao.Sucesso && solicitacao.Retorno is { } protocolo)
    Console.WriteLine($"Protocolo {protocolo.Protocolo}: aguardar ~{protocolo.TempoEsperaMedioEmMs} ms; válido por {protocolo.TempoLimiteEmMin} min");
```

Para pessoas físicas, use `EventosSolicitarPFAsync` com CPFs (lote tipo 3):

```csharp
var solicitacaoPF = await servico.EventosSolicitarPFAsync(["00000000191", "11111111111"], CodigoEventoAtualizacao.DctfWeb);
```

**Dados enviados** — o lote vai em `contribuinte`; `pedidoDados.dados` leva só o evento:

```json
{
  "contribuinte": { "numero": "00000000000100,11111111000191,22222222000172", "tipo": 4 },
  "pedidoDados": {
    "idSistema": "EVENTOSATUALIZACAO",
    "idServico": "SOLICEVENTOSPJ132",
    "versaoSistema": "1.0",
    "dados": "{\"evento\":\"E0601\"}"
  }
}
```

`pedidoDados.dados` decodificado:

```json
{"evento":"E0601"}
```

**Retorno (fictício)**

```json
{
  "protocolo": "a65f3455-fa91-419b-b0ad-c4ac50695abf",
  "TempoEsperaMedioEmMs": 5000,
  "TempoLimiteEmMin": 20
}
```

Mensagens: `[Sucesso-EVENTOSATUALIZACAO]` — Requisição efetuada com sucesso.

---

## 📥 OBTEREVENTOSPJ134 / OBTEREVENTOSPF133 — Obter eventos

Após o tempo médio de espera (e antes de `TempoLimiteEmMin`), obtenha os eventos com o protocolo e o **mesmo** código de evento da solicitação.

```csharp
var protocolo = solicitacao.Retorno!;
await Task.Delay(protocolo.TempoEsperaMedioEmMs ?? 5000);

// sobrecarga de conveniência: protocolo + evento
var eventos = await servico.EventosObterPJAsync(protocolo.Protocolo!, CodigoEventoAtualizacao.CaixaPostal);

// equivalente, com Identificacao (número vazio, tipo do lote) + DTO
eventos = await servico.EventosObterPJAsync(
    new Identificacao(string.Empty, TipoIdentificacao.LotePJ),
    new ObtencaoEventos { Protocolo = protocolo.Protocolo!, Evento = CodigoEventoAtualizacao.CaixaPostal });

if (eventos.Sucesso)
{
    foreach (var evento in eventos.Retorno ?? [])
    {
        if (evento.AcessoNegado)
            Console.WriteLine($"{evento.Ni}: sem procuração");
        else if (evento.SemAtualizacao)
            Console.WriteLine($"{evento.Ni}: sem atualização");
        else
            Console.WriteLine($"{evento.Ni}: nova mensagem na Caixa Postal em {evento.DataEvento:dd/MM/yyyy}"); // Data = "AAMMDD"
    }
}
```

Para pessoas físicas, use `EventosObterPFAsync(protocolo, evento)` (lote tipo 3).

**Dados enviados** — `contribuinte.numero` vazio, com o tipo do lote:

```json
{
  "contribuinte": { "numero": "", "tipo": 4 },
  "pedidoDados": {
    "idSistema": "EVENTOSATUALIZACAO",
    "idServico": "OBTEREVENTOSPJ134",
    "versaoSistema": "1.0",
    "dados": "{\"protocolo\":\"a65f3455-fa91-419b-b0ad-c4ac50695abf\",\"evento\":\"E0601\"}"
  }
}
```

`pedidoDados.dados` decodificado:

```json
{"protocolo":"a65f3455-fa91-419b-b0ad-c4ac50695abf","evento":"E0601"}
```

**Retorno (fictício)** — matriz `[NI, data AAMMDD]`:

```json
[
  ["00000000000100", "261027"],
  ["11111111000191", ""],
  ["22222222000172", "x"]
]
```

Mensagens: `[Sucesso-EVENTOSATUALIZACAO]` — Requisição efetuada com sucesso.

| NI | `Data` | `DataEvento` | `SemAtualizacao` | `AcessoNegado` |
|:--|:--|:--|:--|:--|
| 00000000000100 | `261027` | 27/10/2026 | `false` | `false` |
| 11111111000191 | `""` | `null` | `true` | `false` |
| 22222222000172 | `x` | `null` | `false` | `true` |

> [!NOTE]
> Cada linha da matriz é lida por `EventoAtualizacaoJsonConverter` como `EventoAtualizacao` (`Ni`, `Data`). A data vem vazia quando o contribuinte não teve atualização e `"x"` (`EventoAtualizacao.SemProcuracao`) quando não há procuração (acesso negado). `RetornoSolicitacaoEventos` mapeia `TempoEsperaMedioEmMs` e `TempoLimiteEmMin` com inicial maiúscula, como no retorno oficial. As sobrecargas lançam `ArgumentNullException` sem evento/protocolo e `LoteEventos` lança `ArgumentOutOfRangeException` para lote vazio, com mais de 1000 NIs ou tipo que não seja `LotePF`/`LotePJ`.
