# REGIMEAPURACAO — Regime de Apuração do Simples Nacional

O sistema **REGIMEAPURACAO** (solução Integra-SN) permite efetuar e consultar a opção anual pelo regime de apuração das receitas do Simples Nacional (**competência** ou **caixa**). Os bodies ficam no namespace `EficazFramework.SPED.Schemas.IntegraContador.IntegraSN`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `EFETUAROPCAOREGIME101` | Declarar | 1.0 | `RegimeApuracaoEfetuarOpcaoAsync` | `OpcaoRegime` |
| `CONSULTARANOSCALENDARIOS102` | Consultar | 1.0 | `RegimeApuracaoConsultarAnosCalendarioAsync` | `List<AnoCalendarioRegime>` |
| `CONSULTAROPCAOREGIME103` | Consultar | 1.0 | `RegimeApuracaoConsultarOpcaoAsync` | `OpcaoRegime` |
| `CONSULTARRESOLUCAO104` | Consultar | 1.0 | `RegimeApuracaoConsultarResolucaoAsync` | `ResolucaoRegime` |

Os identificadores também estão em `Catalogo.RegimeApuracao` (ex.: `Catalogo.RegimeApuracao.EfetuarOpcao`).

---

## 🔑 Pré-requisito

Os exemplos abaixo assumem o `servico` configurado conforme [Configurando o serviço](../IntegraContador.md#-configurando-o-serviço) e o contribuinte:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraSN;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!NOTE]
> Os métodos que recebem `dados` lançam `ArgumentNullException` quando ele é `null`. Erros HTTP **não** lançam exceção: verifique `resposta.Sucesso`, `resposta.StatusCode` e `resposta.Mensagens`. Os retornos abaixo mostram o conteúdo de `dados` já decodificado (o Base64 dos PDFs está truncado).

---

## ✍️ EFETUAROPCAOREGIME101 — Efetuar a opção pelo regime

Efetiva a opção anual pelo regime de apuração. `TipoRegime` e `DescritivoRegime` devem ser coerentes entre si e `DeAcordoResolucao` deve ser `true`.

```csharp
var resposta = await servico.RegimeApuracaoEfetuarOpcaoAsync(contribuinte, new EfetuarOpcaoRegime
{
    AnoOpcao = 2025,
    TipoRegime = 1,               // 0 - Competência; 1 - Caixa
    DescritivoRegime = "CAIXA",   // "COMPETENCIA" ou "CAIXA"
    DeAcordoResolucao = true
});

if (resposta.Sucesso)
{
    var opcao = resposta.Retorno!;
    Console.WriteLine($"{opcao.CnpjMatriz}: regime {opcao.RegimeEscolhido} para {opcao.AnoCalendario}, opção em {opcao.DataHoraOpcao}");
    File.WriteAllBytes($@"C:\RegimeApuracao\demonstrativo-{opcao.AnoCalendario}.pdf", Convert.FromBase64String(opcao.DemonstrativoPdf!));
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

**Dados enviados**
```json
{ "anoOpcao": 2025, "tipoRegime": 1, "descritivoRegime": "CAIXA", "deAcordoResolucao": true }
```

**Retorno (fictício)**
```json
{
  "cnpjMatriz": "00000000000100",
  "anoCalendario": 2025,
  "regimeEscolhido": "CAIXA",
  "dataHoraOpcao": 20250110093012,
  "demonstrativoPdf": "JVBERi0xLjQK...",
  "textoResolucao": "Resolução CGSN nº 140, de 22 de maio de 2018."
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-REGIMEAPURACAO]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> `TipoRegime` é um `int` (0 - Competência; 1 - Caixa) e não um enum; o `DescritivoRegime` reforça a escolha e deve corresponder ao tipo. `OpcaoRegime.DataHoraOpcao` é `long?` no formato `AAAAMMDDHHMMSS`.

---

## 📅 CONSULTARANOSCALENDARIOS102 — Consultar anos-calendário com opção

Lista todas as opções pelo regime de apuração já efetivadas. O serviço não tem dados de entrada (`pedidoDados.dados` é enviado vazio).

```csharp
var resposta = await servico.RegimeApuracaoConsultarAnosCalendarioAsync(contribuinte);

if (resposta.Sucesso)
{
    foreach (var ano in resposta.Retorno ?? [])
        Console.WriteLine($"{ano.AnoCalendario}: {ano.RegimeApurado}");
}
```

**Dados enviados**
```json
""
```

**Retorno (fictício)**
```json
[
  { "anoCalendario": 2025, "regimeApurado": "CAIXA" },
  { "anoCalendario": 2024, "regimeApurado": "COMPETENCIA" },
  { "anoCalendario": 2023, "regimeApurado": "COMPETENCIA" }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-REGIMEAPURACAO]","texto":"Requisição efetuada com sucesso."}]`

---

## 🔎 CONSULTAROPCAOREGIME103 — Consultar a opção de um ano-calendário

Retorna a opção efetivada para o ano-calendário, com o demonstrativo em PDF.

```csharp
var resposta = await servico.RegimeApuracaoConsultarOpcaoAsync(contribuinte, new ConsultarOpcaoRegime { AnoCalendario = 2025 });

if (resposta.Sucesso)
{
    var opcao = resposta.Retorno!;
    Console.WriteLine($"Regime {opcao.RegimeEscolhido} (opção em {opcao.DataHoraOpcao})");
    if (opcao.RegimeEscolhido == "CAIXA")
        Console.WriteLine(opcao.TextoResolucao);
    File.WriteAllBytes($@"C:\RegimeApuracao\demonstrativo-{opcao.AnoCalendario}.pdf", Convert.FromBase64String(opcao.DemonstrativoPdf!));
}
```

**Dados enviados**
```json
{ "anoCalendario": 2025 }
```

**Retorno (fictício)**
```json
{
  "cnpjMatriz": "00000000000100",
  "anoCalendario": 2025,
  "regimeEscolhido": "CAIXA",
  "dataHoraOpcao": 20250110093012,
  "demonstrativoPdf": "JVBERi0xLjQK...",
  "textoResolucao": "Resolução CGSN nº 140, de 22 de maio de 2018."
}
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-REGIMEAPURACAO]","texto":"Requisição efetuada com sucesso."}]`

---

## 📜 CONSULTARRESOLUCAO104 — Consultar a resolução do regime de caixa

Retorna o texto fixo da resolução aplicável ao regime de caixa no ano-calendário (útil para exibir ao usuário antes de efetuar a opção).

```csharp
var resposta = await servico.RegimeApuracaoConsultarResolucaoAsync(contribuinte, new ConsultarResolucaoRegime { AnoCalendario = 2025 });

if (resposta.Sucesso)
    Console.WriteLine(resposta.Retorno!.TextoResolucao);
```

**Dados enviados**
```json
{ "anoCalendario": 2025 }
```

**Retorno (fictício)**
```json
{ "textoResolucao": "Resolução CGSN nº 140, de 22 de maio de 2018." }
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-REGIMEAPURACAO]","texto":"Requisição efetuada com sucesso."}]`
