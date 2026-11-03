# SITFIS — Integra-SITFIS

O **SITFIS** emite o **Relatório de Situação Fiscal** do contribuinte (pendências e débitos na Receita Federal e na PGFN), em PDF. A emissão é assíncrona: primeiro se solicita um protocolo e depois se aciona a emissão com esse protocolo, aguardando enquanto o relatório estiver em processamento.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `SOLICITARPROTOCOLO91` | `/Apoiar` | 2.0 | `SitfisSolicitarProtocoloAsync` | `ProtocoloRelatorioSitfis` |
| `RELATORIOSITFIS92` | `/Emitir` | 2.0 | `SitfisEmitirRelatorioAsync` | `RelatorioSitfis` |
| — (91 + 92 com novas tentativas) | — | — | `SitfisObterRelatorioAsync` | `RelatorioSitfis` |

Os identificadores estão em `Catalogo.Sitfis` (`SolicitarProtocolo`, `EmitirRelatorio`).

---

## 🚀 Preparação

Os exemplos consideram o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) e o contribuinte abaixo:

```csharp
using System.Net;
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSITFIS;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

---

## 🔄 Fluxo de emissão

1. **SOLICITARPROTOCOLO91** devolve o `protocoloRelatorio` e um `tempoEspera` (milissegundos) a aguardar antes da emissão.
2. **RELATORIOSITFIS92** é chamado com o protocolo:
   - **HTTP 200** — relatório pronto: `RelatorioSitfis.Pdf` (Base64).
   - **HTTP 202** — em processamento: `dados` traz um novo `tempoEspera`.
   - **HTTP 204** — em processamento, sem corpo: o tempo vem no cabeçalho `ETag` (`"tempoEspera:4000"`) e o método o atribui a `RelatorioSitfis.TempoEspera`.
3. Enquanto a resposta for 202/204, aguarde o `TempoEspera` e chame o 92 novamente com o **mesmo** protocolo.

O método `SitfisObterRelatorioAsync` faz todo esse fluxo.

---

## ⚡ SitfisObterRelatorioAsync — Fluxo completo

Solicita o protocolo, aguarda o `tempoEspera` inicial e aciona a emissão até obter o PDF ou atingir `maxTentativas` chamadas do serviço 92 (padrão **5**). Entre as tentativas aguarda o `tempoEspera` informado pela API ou, se ausente, `servico.EsperaPadraoSitfis` (padrão 2 segundos).

```csharp
servico.EsperaPadraoSitfis = TimeSpan.FromSeconds(3); // opcional

using var cts = new CancellationTokenSource(TimeSpan.FromMinutes(2));
var resposta = await servico.SitfisObterRelatorioAsync(contribuinte, maxTentativas: 8, ct: cts.Token);

if (resposta.StatusCode == (int)HttpStatusCode.OK && resposta.Retorno?.Pdf is { } pdf)
{
    File.WriteAllBytes(@"C:\SITFIS\00000000000100.pdf", Convert.FromBase64String(pdf));
}
else if (resposta.StatusCode is (int)HttpStatusCode.Accepted or (int)HttpStatusCode.NoContent)
{
    // esgotou as tentativas com o relatório ainda em processamento
    Console.WriteLine($"Relatório ainda em processamento; tente novamente em {resposta.Retorno?.TempoEspera} ms.");
}
else
{
    // falha na solicitação do protocolo ou na emissão
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

> [!NOTE]
> Se a solicitação do protocolo falhar, o método retorna o envelope dessa resposta (status, mensagens) **sem** `Retorno` e não chama a emissão. O `CancellationToken` também interrompe as esperas. Note que 202/204 são considerados `Sucesso` (2xx): verifique a presença do `Pdf`.

---

## 🎫 SOLICITARPROTOCOLO91 — Solicitar protocolo

Serviço de apoio (não tarifado), sem dados de entrada.

```csharp
var resposta = await servico.SitfisSolicitarProtocoloAsync(contribuinte);

if (resposta.Sucesso || resposta.StatusCode == (int)HttpStatusCode.NotModified)
{
    var protocolo = resposta.Retorno!.ProtocoloRelatorio!;
    if (resposta.Retorno.TempoEspera is > 0 and var espera)
        await Task.Delay(espera);
    // segue para a emissão (RELATORIOSITFIS92) com o protocolo
}
```

#### Dados enviados
Nenhum — `pedidoDados.dados` é enviado vazio (`""`).

#### Retorno (fictício)
```json
{
  "protocoloRelatorio": "+S7N6c04XNZUVzmxWT7SzpkZA4xeDQC9Z2T2GBJ5usn8LyouyWXbsy6mKsLyEImRkDjF4NAL25KiSXOLjnz...",
  "tempoEspera": 2000
}
```
Mensagens: `[Sucesso-Sitfis-SC01] Protocolo do relatório de situação fiscal gerado com sucesso.`

> [!NOTE]
> O protocolo vale apenas na data da solicitação. Se já houver protocolo válido e ainda não utilizado, a API responde **HTTP 304** (sem `dados`) com o protocolo no cabeçalho `ETag` (`"protocoloRelatorio:..."`); o método o lê e preenche `Retorno.ProtocoloRelatorio` normalmente. Como 304 não é 2xx, `Sucesso` é `false` nesse caso.

---

## 📑 RELATORIOSITFIS92 — Emitir relatório

Aciona a emissão a partir do protocolo. Use diretamente quando quiser controlar as tentativas (ex.: guardar o protocolo e consultar mais tarde, em outro processo).

```csharp
var protocolo = (await servico.SitfisSolicitarProtocoloAsync(contribuinte)).Retorno!.ProtocoloRelatorio!;

while (true)
{
    var resposta = await servico.SitfisEmitirRelatorioAsync(contribuinte, protocolo);

    if (resposta.StatusCode == (int)HttpStatusCode.OK && resposta.Retorno?.Pdf is { } pdf)
    {
        File.WriteAllBytes(@"C:\SITFIS\00000000000100.pdf", Convert.FromBase64String(pdf));
        break;
    }

    if (resposta.StatusCode is not ((int)HttpStatusCode.Accepted or (int)HttpStatusCode.NoContent))
    {
        foreach (var msg in resposta.Mensagens ?? [])
            Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
        break;
    }

    await Task.Delay(resposta.Retorno?.TempoEspera ?? 2000); // em processamento
}
```

#### Dados enviados
```json
{
  "protocoloRelatorio": "+S7N6c04XNZUVzmxWT7SzpkZA4xeDQC9Z2T2GBJ5usn8LyouyWXbsy6mKsLyEImRkDjF4NAL25KiSXOLjnz..."
}
```

#### Retorno (fictício) — HTTP 202, em processamento
```json
{
  "tempoEspera": 4000
}
```
Mensagens: `[Sucesso-Sitfis-SC02] A emissão relatório de situação fiscal está em processamento.`

#### Retorno (fictício) — HTTP 204, em processamento
Sem corpo; cabeçalho `ETag: "tempoEspera:4000"` → `resposta.Retorno.TempoEspera == 4000`.

#### Retorno (fictício) — HTTP 200, relatório pronto
```json
[
  {
    "pdf": "JVBERi0xLjQK..."
  }
]
```
Mensagens: `[Sucesso-Sitfis-SC03] Relatório de situação fiscal emitido com sucesso.`

> [!NOTE]
> - O exemplo da documentação retorna `dados` como **array de um objeto**; o objeto direto (`{"pdf": "..."}`) também é aceito. O `tempoEspera` pode vir como número ou texto.
> - O token do procurador (`autenticar_procurador_token`) não é enviado no endpoint `/Apoiar` (serviço 91), pois a API não o aceita ali; no serviço 92 (`/Emitir`) ele é enviado normalmente.
> - O protocolo é Base64 e pode conter `+` e `/`; na requisição real, o `+` é enviado escapado (`\u002B`), o que é equivalente em JSON.
