# PAGTOWEB — Integra-Pagamento

O **PagtoWeb** consulta os documentos de arrecadação (DARF, DAS, DJE etc.) **pagos** pelo contribuinte, com seus desmembramentos, conta os pagamentos que atendem a um filtro e emite o **comprovante de arrecadação** em PDF.

[← Integra Contador](../IntegraContador.md)

---

## 🗂️ Serviços

| idServico | Endpoint | Versão | Método do `IntegraContadorService` | Retorno (`T`) |
|:--|:--|:--|:--|:--|
| `PAGAMENTOS71` | `/Consultar` | 1.0 | `PagtoWebConsultarPagamentosAsync` | `List<DocumentoArrecadacao>` |
| `COMPARRECADACAO72` | `/Emitir` | 1.0 | `PagtoWebEmitirComprovanteAsync` | `ComprovanteArrecadacao` |
| `CONTACONSDOCARRPG73` | `/Consultar` | 1.0 | `PagtoWebContarPagamentosAsync` | `int` |

Os identificadores estão em `Catalogo.PagtoWeb` (`ConsultarPagamentos`, `EmitirComprovante`, `ContarPagamentos`).

---

## 🚀 Preparação

Os exemplos consideram o `servico` configurado como em [Integra Contador](../IntegraContador.md#-configurando-o-serviço) e o contribuinte abaixo:

```csharp
using EficazFramework.SPED.Schemas.IntegraContador;
using EficazFramework.SPED.Schemas.IntegraContador.IntegraPagamento;
using EficazFramework.SPED.Services.IntegraContador;

var contribuinte = Identificacao.Cnpj("00000000000100");
```

Os filtros (`FiltroPagamentos`) podem ser combinados e sempre se referem ao contribuinte da requisição; filtros não informados (`null`) não são enviados.

---

## 💳 PAGAMENTOS71 — Consultar pagamentos

Lista os documentos de arrecadação pagos, paginados (`ConsultaPagamentos` = filtros + `PrimeiroDaPagina`/`TamanhoDaPagina`, máximo 100 por página).

```csharp
var consulta = new ConsultaPagamentos
{
    NumeroDocumentoLista = ["07202501234567890"],
    CodigoReceitaLista = ["1708", "5952"],
    IntervaloDataArrecadacao = new IntervaloData
    {
        DataInicial = new DateOnly(2025, 1, 1),
        DataFinal = new DateOnly(2025, 3, 31)
    },
    IntervaloValorTotalDocumento = new IntervaloValor
    {
        ValorInicial = 100m,
        ValorFinal = 50000.00m
    },
    CodigoTipoDocumentoLista = ["04", "09"],   // 04 - DARF, 09 - DAS
    PrimeiroDaPagina = 0,
    TamanhoDaPagina = 50
};

var resposta = await servico.PagtoWebConsultarPagamentosAsync(contribuinte, consulta);

if (resposta.Sucesso)
{
    foreach (var doc in resposta.Retorno ?? [])
    {
        Console.WriteLine($"{doc.Tipo?.DescricaoAbreviada} {doc.NumeroDocumento} - pago em {doc.DataArrecadacao:dd/MM/yyyy}: {doc.ValorTotal:N2}");
        Console.WriteLine($"  Receita {doc.ReceitaPrincipal?.Codigo} - {doc.ReceitaPrincipal?.Descricao} (PA {doc.PeriodoApuracao:MM/yyyy})");

        foreach (var item in doc.Desmembramentos ?? [])
            Console.WriteLine($"  #{item.Sequencial} {item.ReceitaPrincipal?.Codigo}-{item.ReceitaPrincipal?.ExtensaoReceita?.Codigo}: " +
                              $"principal {item.ValorPrincipal:N2}, multa {item.ValorMulta:N2}, juros {item.ValorJuros:N2}");
    }
}
else
{
    foreach (var msg in resposta.Mensagens ?? [])
        Console.WriteLine($"{msg.Codigo}: {msg.Texto}");
}
```

Para a próxima página, some `TamanhoDaPagina` a `PrimeiroDaPagina` e repita a chamada enquanto a lista retornada vier cheia.

#### Dados enviados
```json
{
  "primeiroDaPagina": 0,
  "tamanhoDaPagina": 50,
  "numeroDocumentoLista": ["07202501234567890"],
  "codigoReceitaLista": ["1708", "5952"],
  "intervaloDataArrecadacao": {
    "dataInicial": "2025-01-01",
    "dataFinal": "2025-03-31"
  },
  "intervaloValorTotalDocumento": {
    "valorInicial": 100,
    "valorFinal": 50000.00
  },
  "codigoTipoDocumentoLista": ["04", "09"]
}
```

#### Retorno (fictício)
```json
[
  {
    "numeroDocumento": "07202501234567890",
    "tipo": {
      "codigo": "4",
      "descricao": "DOCUMENTO DE ARRECADAÇÃO DE RECEITAS FEDERAIS",
      "descricaoAbreviada": "DARF"
    },
    "periodoApuracao": "2025-01-31T00:00:00-03:00",
    "dataArrecadacao": "2025-02-20T00:00:00-03:00",
    "dataVencimento": "2025-02-20T00:00:00-03:00",
    "receitaPrincipal": {
      "codigo": "1708",
      "descricao": "IRRF - Remuneração de Serviços Prestados por Pessoa Jurídica",
      "extensaoReceita": null
    },
    "referencia": null,
    "valorTotal": 1500.00,
    "valorPrincipal": 1500.00,
    "valorMulta": null,
    "valorJuros": null,
    "valorSaldoTotal": null,
    "valorSaldoPrincipal": null,
    "valorSaldoMulta": null,
    "valorSaldoJuros": null,
    "desmembramentos": [
      {
        "sequencial": "1",
        "receitaPrincipal": {
          "codigo": "1708",
          "descricao": "IRRF - Remuneração de Serviços Prestados por Pessoa Jurídica",
          "extensaoReceita": {
            "codigo": "1",
            "descricao": "IRRF - SERVIÇOS PRESTADOS POR PJ"
          }
        },
        "periodoApuracao": "2025-01-31T00:00:00-03:00",
        "dataVencimento": "2025-02-20T00:00:00-03:00",
        "valorTotal": 1500.00,
        "valorPrincipal": 1500.00,
        "valorMulta": 0,
        "valorJuros": 0,
        "valorSaldoTotal": 0,
        "valorSaldoPrincipal": 0,
        "valorSaldoMulta": 0,
        "valorSaldoJuros": 0,
        "cib": null
      }
    ]
  }
]
```
Mensagens: `[Sucesso-PAGTOWEB] Requisição efetuada com sucesso.`

---

## 📄 COMPARRECADACAO72 — Emitir comprovante de arrecadação

Emite o comprovante de pagamento (PDF em Base64) de um documento pago.

```csharp
var resposta = await servico.PagtoWebEmitirComprovanteAsync(contribuinte, "07202501234567890");

if (resposta.Sucesso && resposta.Retorno?.Pdf is { } pdf)
    File.WriteAllBytes(@"C:\Comprovantes\07202501234567890.pdf", Convert.FromBase64String(pdf));
```

#### Dados enviados
```json
{
  "numeroDocumento": "07202501234567890"
}
```

#### Retorno (fictício)
```json
{
  "pdf": "JVBERi0xLjQK..."
}
```
Mensagens: `[Sucesso-PAGTOWEB] Requisição efetuada com sucesso.`

> [!NOTE]
> Os exemplos da documentação retornam `{"pdf": "..."}`, mas a tabela de saída descreve apenas o Base64. Se `dados` vier somente com o Base64, o método o atribui a `ComprovanteArrecadacao.Pdf` — o uso é o mesmo nos dois casos.

---

## 🔢 CONTACONSDOCARRPG73 — Contar pagamentos

Retorna a quantidade de documentos pagos que atendem aos filtros (útil para dimensionar a paginação do serviço 71).

```csharp
var filtro = new FiltroPagamentos
{
    CodigoReceitaLista = ["1708"],
    IntervaloDataArrecadacao = new IntervaloData
    {
        DataInicial = new DateOnly(2025, 1, 1),
        DataFinal = new DateOnly(2025, 12, 31)
    },
    IntervaloValorTotalDocumento = new IntervaloValor
    {
        ValorInicial = 10m,
        ValorFinal = 100000m
    },
    CodigoTipoDocumentoLista = ["04"]
};

var resposta = await servico.PagtoWebContarPagamentosAsync(contribuinte, filtro);

if (resposta.Sucesso)
    Console.WriteLine($"{resposta.Retorno} DARF(s) de IRRF pagos em 2025");
```

#### Dados enviados
```json
{
  "codigoReceitaLista": ["1708"],
  "intervaloDataArrecadacao": {
    "dataInicial": "2025-01-01",
    "dataFinal": "2025-12-31"
  },
  "intervaloValorTotalDocumento": {
    "valorInicial": 10,
    "valorFinal": 100000
  },
  "codigoTipoDocumentoLista": ["04"]
}
```

#### Retorno (fictício)
```json
12
```
Mensagens: `[Sucesso-PAGTOWEB] Requisição efetuada com sucesso.`

> [!NOTE]
> - O parâmetro do serviço 73 é tipado como `FiltroPagamentos`: mesmo que seja passado um `ConsultaPagamentos`, a paginação (`primeiroDaPagina`/`tamanhoDaPagina`) **não** é enviada.
> - `CodigoTipoDocumentoLista` usa códigos de até 2 posições (`04` DARF, `07` DJE, `08` DARF SIMPLES, `09` DAS), mas o retorno traz `tipo.codigo` sem zero à esquerda (`"4"`).
> - As datas de pesquisa (`IntervaloData`) são enviadas como `yyyy-MM-dd`; as datas do retorno (`PeriodoApuracao`, `DataArrecadacao`, `DataVencimento`) são lidas como `DateTimeOffset`.
> - `IntervaloValor` é enviado como número, mantendo as casas do `decimal` (`50000.00m` → `50000.00`).
