# PGMEI — Programa Gerador do DAS do MEI

O sistema **PGMEI** (solução Integra-MEI) permite gerar o DAS do Microempreendedor Individual (em PDF ou somente com o código de barras), registrar benefícios por período de apuração e consultar os períodos inscritos em dívida ativa. Os bodies ficam no namespace `EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI`; o `Das` de retorno é compartilhado com o PGDASD e fica em `EficazFramework.SPED.Schemas.IntegraContador`.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `GERARDASPDF21` | Emitir | 1.0 | `PgmeiGerarDasPdfAsync` | `List<Das>` |
| `GERARDASCODBARRA22` | Emitir | 1.0 | `PgmeiGerarDasCodigoBarrasAsync` | `List<Das>` |
| `ATUBENEFICIO23` | Emitir | 1.0 | `PgmeiAtualizarBeneficioAsync` | `List<RetornoAtualizarBeneficio>` |
| `DIVIDAATIVA24` | Consultar | 1.0 | `PgmeiConsultarDividaAtivaAsync` | `List<DebitoDividaAtiva>` |

Os identificadores também estão em `Catalogo.Pgmei` (ex.: `Catalogo.Pgmei.GerarDasPdf`).

---

## 🔑 Pré-requisito

Os exemplos abaixo assumem o `servico` configurado conforme [Configurando o serviço](../IntegraContador.md#-configurando-o-serviço) e o contribuinte (CNPJ do MEI):

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

> [!NOTE]
> Existem duas classes `GerarDas`: `IntegraMEI.GerarDas` (PGMEI) e `IntegraSN.GerarDas` (PGDASD), com os mesmos campos. Se os dois namespaces forem importados no mesmo arquivo, qualifique o nome ou use um alias (ex.: `using GerarDasMei = EficazFramework.SPED.Schemas.IntegraContador.IntegraMEI.GerarDas;`).

> [!NOTE]
> Todos os métodos lançam `ArgumentNullException` quando `dados` é `null`. Erros HTTP **não** lançam exceção: verifique `resposta.Sucesso`, `resposta.StatusCode` e `resposta.Mensagens`. Os retornos abaixo mostram o conteúdo de `dados` já decodificado (o Base64 dos PDFs está truncado).

---

## 🧾 GERARDASPDF21 — Gerar DAS (PDF)

Gera o DAS do MEI para o período de apuração, com o PDF em Base64. `DataConsolidacao` (`AAAAMMDD`) é opcional e permite calcular multa e juros para uma data futura.

```csharp
var resposta = await servico.PgmeiGerarDasPdfAsync(contribuinte, new GerarDas
{
    PeriodoApuracao = "202501",
    DataConsolidacao = "20250320"
});

if (resposta.Sucesso)
{
    foreach (var das in resposta.Retorno ?? [])
    {
        File.WriteAllBytes($@"C:\PGMEI\das-{das.CnpjCompleto}-202501.pdf", Convert.FromBase64String(das.Pdf!));

        foreach (var detalhe in das.Detalhamento ?? [])
        {
            Console.WriteLine($"{das.RazaoSocial} - DAS {detalhe.NumeroDocumento} - PA {detalhe.PeriodoApuracao}");
            Console.WriteLine($"Vencimento {detalhe.DataVencimento}, pagável até {detalhe.DataLimiteAcolhimento}: total {detalhe.Valores?.Total:N2}");
            Console.WriteLine(detalhe.Observacao2);

            foreach (var tributo in detalhe.Composicao ?? [])
                Console.WriteLine($"  {tributo.Codigo} {tributo.Denominacao}: {tributo.Valores?.Total:N2}");
        }
    }
}
```

**Dados enviados**
```json
{ "periodoApuracao": "202501", "dataConsolidacao": "20250320" }
```

**Retorno (fictício)**
```json
[
  {
    "cnpjCompleto": "00000000000100",
    "razaoSocial": "FULANO DE TAL 00000000000",
    "pdf": "JVBERi0xLjQK...",
    "detalhamento": [
      {
        "periodoApuracao": "202501",
        "numeroDocumento": "07202506012345678",
        "dataVencimento": "20250220",
        "dataLimiteAcolhimento": "20250320",
        "valores": { "principal": 81.90, "multa": 7.56, "juros": 0.82, "total": 90.28 },
        "observacao1": "CPF: 000.000.000-00",
        "observacao2": "Tributos (R$): INSS 75,90 ICMS 1,00 ISS 5,00",
        "observacao3": "PGMEI(Versao:3.16.2)",
        "composicao": [
          { "periodoApuracao": 202501, "codigo": "0151", "denominacao": "INSS - SIMPLES NACIONAL - MEI - 01/2025", "valores": { "principal": 75.90, "multa": 7.01, "juros": 0.76, "total": 83.67 } },
          { "periodoApuracao": 202501, "codigo": "0083", "denominacao": "ICMS - SIMPLES NACIONAL - MEI - SP - 01/2025", "valores": { "principal": 1.00, "multa": 0.09, "juros": 0.01, "total": 1.10 } },
          { "periodoApuracao": 202501, "codigo": "0125", "denominacao": "ISS - SIMPLES NACIONAL - MEI - SAO PAULO (SP) - 01/2025", "valores": { "principal": 5.00, "multa": 0.46, "juros": 0.05, "total": 5.51 } }
        ]
      }
    ]
  }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGMEI]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> A documentação descreve `detalhamento` ora como **objeto**, ora como **lista**, e `composicao[].periodoApuracao` ora como texto, ora como número (como no exemplo acima). O `Das` aceita todas as formas: `Das.Detalhamento` é sempre `List<DetalhamentoDas>` e `ComposicaoDas.PeriodoApuracao`/`Codigo` são sempre `string`. Em DAS de mais de um período, `DetalhamentoDas.PeriodoApuracao` vem como `"Diversos"`.

---

## 🔢 GERARDASCODBARRA22 — Gerar DAS (código de barras)

Gera o DAS do MEI **sem o PDF**, retornando apenas a linha do código de barras em `DetalhamentoDas.CodigoDeBarras` (cada item é um bloco de números). `Das.Pdf` vem nulo.

```csharp
var resposta = await servico.PgmeiGerarDasCodigoBarrasAsync(contribuinte, new GerarDas
{
    PeriodoApuracao = "202502",
    DataConsolidacao = "20250320"
});

if (resposta.Sucesso)
{
    var detalhe = resposta.Retorno![0].Detalhamento![0];
    var linhaDigitavel = string.Join(" ", detalhe.CodigoDeBarras ?? []);
    Console.WriteLine($"DAS {detalhe.NumeroDocumento} - {detalhe.Valores?.Total:N2} - vencimento {detalhe.DataVencimento}");
    Console.WriteLine(linhaDigitavel);
}
```

**Dados enviados**
```json
{ "periodoApuracao": "202502", "dataConsolidacao": "20250320" }
```

**Retorno (fictício)**
```json
[
  {
    "cnpjCompleto": "00000000000100",
    "razaoSocial": "FULANO DE TAL 00000000000",
    "detalhamento": [
      {
        "periodoApuracao": "202502",
        "valores": { "juros": 0.00, "multa": 0.00, "principal": 81.90, "total": 81.90 },
        "dataLimiteAcolhimento": "20250320",
        "dataVencimento": "20250320",
        "numeroDocumento": "07202507023456789",
        "codigoDeBarras": [ "858000000001", "819000000002", "000000000003", "000000000004" ],
        "observacao1": "CPF: 000.000.000-00",
        "observacao2": "Tributos (R$): INSS 75,90 ICMS 1,00 ISS 5,00",
        "observacao3": "PGMEI(Versao:3.16.2)",
        "composicao": [
          { "codigo": "0151", "denominacao": "INSS - SIMPLES NACIONAL - MEI - 02/2025", "periodoApuracao": 202502, "valores": { "juros": 0.00, "multa": 0.00, "principal": 75.90, "total": 75.90 } },
          { "codigo": "0083", "denominacao": "ICMS - SIMPLES NACIONAL - MEI - SP - 02/2025", "periodoApuracao": 202502, "valores": { "juros": 0.00, "multa": 0.00, "principal": 1.00, "total": 1.00 } },
          { "codigo": "0125", "denominacao": "ISS - SIMPLES NACIONAL - MEI - SAO PAULO (SP) - 02/2025", "periodoApuracao": 202502, "valores": { "juros": 0.00, "multa": 0.00, "principal": 5.00, "total": 5.00 } }
        ]
      }
    ]
  }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGMEI]","texto":"Requisição efetuada com sucesso."}]`

---

## 🎁 ATUBENEFICIO23 — Atualizar benefício

Registra benefício para as apurações informadas do ano-calendário. O retorno indica, para cada período original, o período que o agrupa para emissão do DAS.

```csharp
var resposta = await servico.PgmeiAtualizarBeneficioAsync(contribuinte, new AtualizarBeneficio
{
    AnoCalendario = 2025,
    InfoBeneficio =
    [
        new InfoBeneficio { PeriodoApuracao = "202503", IndicadorBeneficio = true },
        new InfoBeneficio { PeriodoApuracao = "202504", IndicadorBeneficio = true }
    ]
});

if (resposta.Sucesso)
{
    foreach (var item in resposta.Retorno ?? [])
        Console.WriteLine($"PA {item.PaOriginal}: benefício {item.IndicadorBeneficio} - agrupado em {item.PaAgrupado}");
}
```

**Dados enviados**
```json
{
  "anoCalendario": 2025,
  "infoBeneficio": [
    { "periodoApuracao": "202503", "indicadorBeneficio": true },
    { "periodoApuracao": "202504", "indicadorBeneficio": true }
  ]
}
```

**Retorno (fictício)**
```json
[
  { "paOriginal": "202503", "indicadorBeneficio": true, "paAgrupado": "202504" },
  { "paOriginal": "202504", "indicadorBeneficio": true, "paAgrupado": "202503" }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGMEI]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> Em `AtualizarBeneficio`, `AnoCalendario` é **numérico** (`int`), enquanto `InfoBeneficio.PeriodoApuracao` é texto (`AAAAMM`).

---

## ⚠️ DIVIDAATIVA24 — Consultar dívida ativa

Consulta os períodos do ano-calendário com débitos inscritos em dívida ativa.

```csharp
var resposta = await servico.PgmeiConsultarDividaAtivaAsync(contribuinte, new ConsultarDividaAtiva { AnoCalendario = "2022" });

if (resposta.Sucesso)
{
    foreach (var debito in resposta.Retorno ?? [])
        Console.WriteLine($"{debito.PeriodoApuracao} - {debito.Tributo} ({debito.EnteFederado}): {debito.Valor:N2} - {debito.SituacaoDebito}");

    Console.WriteLine($"Total em dívida ativa: {resposta.Retorno?.Sum(d => d.Valor ?? 0):N2}");
}
```

**Dados enviados**
```json
{ "anoCalendario": "2022" }
```

**Retorno (fictício)**
```json
[
  { "periodoApuracao": "202203", "tributo": "INSS", "valor": 60.60, "enteFederado": "Uniao", "situacaoDebito": "ENVIADO A  PFN" },
  { "periodoApuracao": "202204", "tributo": "INSS", "valor": 60.60, "enteFederado": "Uniao", "situacaoDebito": "ENVIADO A  PFN" },
  { "periodoApuracao": "202205", "tributo": "INSS", "valor": 60.60, "enteFederado": "Uniao", "situacaoDebito": "ENVIADO A  PFN" }
]
```
HTTP 200 — `mensagens`: `[{"codigo":"[Sucesso-PGMEI]","texto":"Requisição efetuada com sucesso."}]`

> [!NOTE]
> Aqui `ConsultarDividaAtiva.AnoCalendario` é **texto** (`string`), conforme a documentação — diferente de `AtualizarBeneficio.AnoCalendario`, que é `int`.
